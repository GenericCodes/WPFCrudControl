using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using GenericCodes.Core.Entities;
using GenericCodes.Core.Helper;
using GenericCodes.Core.Repositories;
using GenericCodes.Core.UnitOfWork;
using GenericCodes.Resources;
using GenericCodes.CRUD.WPF.Core;
using GenericCodes.CRUD.WPF.Core.MVVM;
using GenericCodes.CRUD.WPF.UIServices;
using Microsoft.Practices.ServiceLocation;

namespace GenericCodes.CRUD.WPF.ViewModel.CRUDBases
{
    public abstract class GenericCrudBase<T> : ObservableObject where T : Entity, new() 
    {
        private readonly IDialogService _dialogService;

        #region Constructor
       
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericCRUDBase"/> class.
        /// </summary>
        /// <param name="searchCriteriaViewModel">The SearchCriteriaViewModel object <see cref="SearchCriteriaBase{T}"/></param>
        /// <param name="addEditEntityViewModel">The AddEditEntityViewModel object <see cref="AddEditEntityBase{T}"/></param>
        public GenericCrudBase(SearchCriteriaBase<T> searchCriteriaViewModel, AddEditEntityBase<T> addEditEntityViewModel)
        {
            _dialogService = ServiceLocator.Current.GetInstance<IDialogService>();

            SearchCriteriaViewModel = searchCriteriaViewModel;
            
            AddEditEntityViewModel = addEditEntityViewModel;
            
            Pager = new Pager();
            Pager.PageChanged += LoadData;

            Sorting = new Sorting();
            Sorting.SortingChanged += LoadData;

            SearchCriteriaViewModel.SearchChanged += () =>
            {
                Pager.CurrentPage = 1;
                LoadData();
            };
        }

        #endregion

        private string _popupWindowStyleName = "DefaultPopupWindowStyle";
        /// <summary>
        /// Gets or sets the pop-up window style name
        /// <para>the pop-up window style name <see cref="string"/></para>
        /// </summary>
        protected string PopupWindowStyleName
        {
            get
            {
                return _popupWindowStyleName;
            }
            set
            {
                _popupWindowStyleName = value;
            }
        }

        protected Expression<Func<T, object>>[] ListingIncludes = null;
        #region public Properties
        /// <summary>
        /// Gets or sets the sorting object
        /// <para>The Sorting object <see cref="CRUDBases.Sorting"/></para>
        /// </summary>

        public Sorting Sorting { get; set; }
        /// <summary>
        /// Gets or sets the Pager object
        /// <para>The Pager object <see cref="CRUDBases.Pager"/></para>
        /// </summary>
        public Pager Pager { get; set; }

        private bool _enableSortingPaging = true;
        /// <summary>
        /// Gets or sets The EnableSortingPaging flag
        /// </summary>
        public bool EnableSortingPaging
        {
            get { return _enableSortingPaging; }
            set { Set(() => EnableSortingPaging, ref _enableSortingPaging, value); }
        }
        /// <summary>
        /// Gets or sets the SearchCriteriaViewModel object <see cref="SearchCriteriaBase{T}"/>
        /// </summary>
        public SearchCriteriaBase<T> SearchCriteriaViewModel { get; set; }
        /// <summary>
        /// Gets or sets the AddEditEntityViewModel object <see cref="AddEditEntityBase{T}"/>
        /// </summary>
        public virtual AddEditEntityBase<T> AddEditEntityViewModel { get; set; }

        private ObservableCollection<T> _dataList = null;
        /// <summary>
        /// Gets or sets the list of data the will be displayed in Crud dataGrid
        /// <para> The DataList <see cref="ObservableCollection{T}"/></para>
        /// </summary>
        public ObservableCollection<T> DataList
        {
            get
            {
                return _dataList;
            }
            set
            {
                Set(() => DataList, ref _dataList, value);
            }
        }
        #endregion

        #region Delegates
        /// <summary>
        /// Represent delegate that will be called when error raised <see cref="Action{Exception}"/>
        /// </summary>
        protected event Action<Exception> ErrorRaised;

        /// <summary>
        /// Represent delegate that will be called after Retrieving Data <see cref="Action{List{T}}"/>
        /// </summary>
        protected Action<List<T>> PostDataRetrievalDelegate;
        /// <summary>
        /// Represent delegate that will be called before add or edit entity <see cref="Action{PopupTypeEnum}"/>
        /// </summary>
        protected Action<PopupTypeEnum> PreAddEditDelegate { get; set; }
        /// <summary>
        /// Represent delegate that will be called after add or edit entity <see cref="Action{PopupTypeEnum}"/>
        /// </summary>
        protected Action<PopupTypeEnum> PostAddEditDelegate { get; set; }

        #endregion

        #region Commands
        private RelayCommand<T> _editEntityCmd;
        /// <summary>
        /// The EditEntity command
        /// when command execute invoke method <see cref="EditEntityCmdExecution(T)"/>
        /// </summary>
        public RelayCommand<T> EditEntityCmd
        {
            get
            {
                return _editEntityCmd ?? (_editEntityCmd = new RelayCommand<T>(EditEntityCmdExecution));
            }
        }

        private RelayCommand _addEntityCmd;
        /// <summary>
        /// The AddEntity command
        /// when command execute invoke method <see cref="AddEntityCmdExecution"/>
        /// </summary>
        public RelayCommand AddEntityCmd
        {
            get
            {
                return _addEntityCmd ?? (_addEntityCmd = new RelayCommand(AddEntityCmdExecution));
            }
        }

        private RelayCommand _deleteEntityCmd;
        /// <summary>
        /// The Delete entity command
        /// when command execute invoke method <see cref="DeleteEntityCmdExecution"/>
        /// </summary>
        public RelayCommand DeleteEntityCmd
        {
            get
            {
                return _deleteEntityCmd ?? (_deleteEntityCmd = new RelayCommand(DeleteEntityCmdExecution, () =>
                {
                    return DataList != null && DataList.Any(d => d.IsSelected);
                }));
            }
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Show confirmation dialog to confirm delete, and delete selected entities from Database. 
        /// </summary>
        public virtual void DeleteEntityCmdExecution()
        {
            var deletedDevices = DataList.Where(i => i.IsSelected).ToList();

            var confirmResult = _dialogService.ShowConfirmDialog(Resource.DeleteConfirmationTitle,
                Resource.DeleteConfirmationMsg);

            if (confirmResult)
            {
                int affected = DeleteItems(deletedDevices);
                if (affected > 0)
                {
                    LoadData();
                }
            }
        }
        /// <summary>
        /// Called when addEntity command executed. 
        /// <para>Mark AddEditEntity pop-up type as Add pop-up, invoke PreAddEditDelegate, Show Add pop-up window 
        /// And if IsSavedSuccessfully: 
        /// load data in Crud dataGrid  and invoke PostAddEditDelegate otherwise window will not close </para>
        /// </summary>
        public virtual void AddEntityCmdExecution()
        {
            TryCatch(() =>
            {
                AddEditEntityViewModel.PopupType = PopupTypeEnum.Add;
                AddEditEntityViewModel.Entity = new T();

                if (PreAddEditDelegate != null)
                    PreAddEditDelegate(AddEditEntityViewModel.PopupType);

                _dialogService.ShowAddEditWindow(PopupTypeEnum.Add, AddEditEntityViewModel, PopupWindowStyleName);
                if (AddEditEntityViewModel.IsSavedSuccessfully)
                {
                    LoadData();
                    if (PostAddEditDelegate != null)
                        PostAddEditDelegate(AddEditEntityViewModel.PopupType);
                }
            });
        }
        /// <summary>
        /// Called when EditEntity command executed. 
        /// <para>Mark AddEditEntity  pop-up type as edit  pop-up, Set Entity that will be updated to uiEntity, 
        /// invoke PreAddEditDelegate, Show Add  pop-up window And if IsSavedSuccessfully: 
        /// load data in Crud dataGrid and invoke PostAddEditDelegate otherwise window will not close </para>
        /// </summary>
        /// <param name="uiEntity">the entity that should be updated</param>
        public virtual void EditEntityCmdExecution(T entity)
        {
            TryCatch(() =>
            {
                entity.BeginEdit();
                AddEditEntityViewModel.PopupType = PopupTypeEnum.Edit;
                AddEditEntityViewModel.Entity = entity;
                if (PreAddEditDelegate != null)
                    PreAddEditDelegate(AddEditEntityViewModel.PopupType);
                entity.Validate();
                _dialogService.ShowAddEditWindow(PopupTypeEnum.Edit, AddEditEntityViewModel, PopupWindowStyleName);
                if (AddEditEntityViewModel.IsSavedSuccessfully)
                {
                    LoadData();
                    if (PostAddEditDelegate != null)
                        PostAddEditDelegate(AddEditEntityViewModel.PopupType);
                }
            });
        }
        /// <summary>
        /// Reload data with specific search criteria 
        /// </summary>
        public virtual void LoadData()
        {
            TryCatch(() =>
            {
                Expression<Func<T, bool>> searchPredicates = (o) => true;

                if (SearchCriteriaViewModel != null)
                {
                    searchPredicates = SearchCriteriaViewModel.GetSearchCriteria();
                }

                int totalRecords;

                var dataList = GetData(searchPredicates, Sorting.SortingPropertyValue, Sorting.SortDirectionValue,
                    Pager.CurrentPage,
                    Pager.PageSize, _enableSortingPaging, out totalRecords);

                Pager.TotalRecords = totalRecords;

                if (PostDataRetrievalDelegate != null)
                    PostDataRetrievalDelegate(dataList);

                DataList = new ObservableCollection<T>(dataList);
            });
        }

        /// <summary>
        /// Delete list from database 
        /// </summary>
        /// <param name="deletedItems"> SelectedItems <see cref="List{T}"/> </param>
        /// <returns> number of items have been deleted </returns>
        public virtual int DeleteItems(List<T> deletedDevices)
        {
            int affected = 0;
            TryCatch(() =>
            {
                using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
                {
                    var repo = unitOfWork.Repository<T>();
                    deletedDevices.ForEach(item => repo.Delete(item));
                    affected = unitOfWork.SaveChanges();
                }
            });
            return affected;
        }
        /// <summary>
        /// Reload data and refresh search criteria
        /// </summary>
        public virtual void RefreshData()
        {
            LoadData();
            SearchCriteriaViewModel.RefreshSearchCriteria();
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Get data from Database with specific criteria
        /// </summary>
        /// <param name="searchPredicate">Search predicate expression</param>
        /// <param name="sortingColumnValue">Sorting column value</param>
        /// <param name="sortDirectionValue">Sorting Direction</param>
        /// <param name="currentPage">Current Page</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="enableSortingPaging">Enable sorting paging flag</param>
        /// <param name="totalRecords">Total number of  records</param>
        /// <returns> Return List of items <see cref="List{T}"/></returns>
        private List<T> GetData(Expression<Func<T, bool>> searchPredicate, string sortingColumnValue,
            ListSortDirection sortDirectionValue, int currentPage, int pageSize, bool enableSortingPaging,
            out int totalRecords)
        {
            var repo = ServiceLocator.Current.GetInstance<IRepository<T>>();

            var query = repo.Queryable();

            if (ListingIncludes != null && ListingIncludes.Length > 0)
                query = query.IncludeMultiple(ListingIncludes);

            if (searchPredicate != null)
                query = query.Where(searchPredicate);

            totalRecords = query.Count();

            if (enableSortingPaging)
            {
                if (!string.IsNullOrEmpty(sortingColumnValue))
                    query = query.SortBy(sortingColumnValue, sortDirectionValue);

                query = query.Skip((currentPage - 1) * pageSize).Take(pageSize);
            }
            var list = query.ToList();

            return list;
        } 
        #endregion

        #region Helpers
        private void TryCatch(Action method)
        {
            try
            {
                method();
            }
            catch (Exception ex)
            {
                if (ErrorRaised != null) ErrorRaised(ex);
            }
        }
        #endregion
    }
}

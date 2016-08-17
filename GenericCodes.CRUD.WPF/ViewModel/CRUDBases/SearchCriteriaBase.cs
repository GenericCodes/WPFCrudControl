using System;
using System.Linq.Expressions;
using GenericCodes.Core.Entities;
using GenericCodes.CRUD.WPF.Core.MVVM;

namespace GenericCodes.CRUD.WPF.ViewModel.CRUDBases
{
    public abstract class SearchCriteriaBase<T> : ObservableObject where T : Entity
    {
        #region public Properties
        /// <summary>
        /// Represent delegate that will be called when search changed
        /// </summary>
        public event Action SearchChanged; 
        #endregion

        #region public Methods
        /// <summary>
        /// create search criteria (expression tree ) that will be used when get data
        /// </summary>
        /// <returns> Expression tree that will be used when get data <see cref="Expression{Func{T,Boolean}}"/></returns>
        public abstract Expression<Func<T, bool>> GetSearchCriteria();
        /// <summary>
        /// Reset Search Criteria
        /// </summary>
        public abstract void ResetSearchCriteria();
        /// <summary>
        /// refresh Search criteria
        /// </summary>
        public virtual void RefreshSearchCriteria()
        {
        } 
        #endregion

        #region Commands
        private RelayCommand _searchCmd;
        /// <summary>
        /// The SearchCriteria Cmd 
        /// </summary>
        public RelayCommand SearchCmd
        {
            get
            {
                return _searchCmd
                    ?? (_searchCmd = new RelayCommand(HandleSearchChanged));
            }
        }

        private RelayCommand _resetCriteriaCmd;
        /// <summary>
        /// The ResetCriteria Command
        /// </summary>
        public RelayCommand ResetCriteriaCmd
        {
            get
            {
                return _resetCriteriaCmd
                    ?? (_resetCriteriaCmd = new RelayCommand(() =>
                    {
                        ResetSearchCriteria();
                        HandleSearchChanged();
                    }));
            }
        } 
        #endregion

        private void HandleSearchChanged()
        {
            if (SearchChanged != null)
                SearchChanged();
        }
    }
}

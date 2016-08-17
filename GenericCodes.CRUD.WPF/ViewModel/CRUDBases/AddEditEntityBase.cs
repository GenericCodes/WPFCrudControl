using System;
using GenericCodes.Core.Entities;
using GenericCodes.Core.UnitOfWork;
using GenericCodes.CRUD.WPF.Core;
using GenericCodes.CRUD.WPF.Core.MVVM;
using Microsoft.Practices.ServiceLocation;

//using GalaSoft.MvvmLight.Command;

namespace GenericCodes.CRUD.WPF.ViewModel.CRUDBases
{
    /// <summary>
    /// Represent the AddEditEntity object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AddEditEntityBase<T> : PopupViewModelBase where T : Entity, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddEditEntityBase{T}<Entity>"/> class.
        /// </summary>
        public AddEditEntityBase() { }

        #region Public Properties
        /// <summary>
        /// Gets or sets the Crud Pop-up window type.
        /// </summary>
        public PopupTypeEnum PopupType { get; set; }
        /// <summary>
        /// Gets or sets if data saved successfully or not.
        /// </summary>
        public bool IsSavedSuccessfully { get; set; }

        private T _entity;
        /// <summary>
        /// Gets or sets the Entity that will be added and updated.
        /// <para>The Entity object. <see cref="GenericCodes.Core.Entities.Entity>"/></para>
        /// </summary>

        public T Entity
        {
            get { return _entity; }
            set { Set(() => Entity, ref _entity, value); }
        }
        #endregion

        #region Public Delegates
        /// <summary>
        /// Represent delegate that will be called after click reset in add mode <see cref="Action"/>
        /// </summary>
        public Action CallBackAfterRestingInAddMode { get; set; }
        /// <summary>
        /// Represent delegate that will be called after click reset in Edit mode <see cref="Action"/>
        /// </summary>
        public Action CallBackWhenRestingInEditMode { get; set; } 
        #endregion

        #region Command
        private RelayCommand _saveCommand;
        /// <summary>
        /// The Save command
        /// </summary>
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(Save));
            }
        }


        private RelayCommand _resetCommand;
        /// <summary>
        /// The Reset command
        /// </summary>
        public RelayCommand ResetCommand
        {
            get
            {
                return _resetCommand ?? (_resetCommand = new RelayCommand(ResetValues));
            }
        }
        #endregion

        #region public Methods
        /// <summary>
        /// Reset entity properties values in add and edit mode
        /// </summary>
        public virtual void ResetValues()
        {
            if (PopupType == PopupTypeEnum.Add)
            {
                Entity = new T();
                if (CallBackAfterRestingInAddMode!=null)
                    CallBackAfterRestingInAddMode();
            }
            else
            {
                Entity.CancelEdit();
                if (CallBackWhenRestingInEditMode!=null)
                    CallBackWhenRestingInEditMode();

                Entity.Validate();
            }
        }

        /// <summary>
        /// The entry point of validate and save entity object in add or edit mode
        /// </summary>
        public virtual void Save()
        {
            _entity.Validate();

            if (_entity.HasErrors)
                return;

            IsSavedSuccessfully = PopupType == PopupTypeEnum.Add ? InsertEnity() : UpdateEnity();

            if (IsSavedSuccessfully)
                this.CloseAssociatedWindow();
        }

        /// <summary>
        /// Update entity in database 
        /// </summary>
        /// <returns>return true in case entity has been updated successfully otherwise false </returns>
        public virtual bool UpdateEnity()
        {
            int affected = 0;
            using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
            {
                var repo = unitOfWork.Repository<T>();
                repo.Update(Entity);
                affected = unitOfWork.SaveChanges();
            }
            return affected > 0;
        }
        /// <summary>
        /// Add entity in database 
        /// </summary>
        /// <returns>return true in case entity has been added successfully otherwise false </returns>
        public virtual bool InsertEnity()
        {
            int affected = 0;
            using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
            {
                var repo = unitOfWork.Repository<T>();
                repo.Insert(Entity);
                affected = unitOfWork.SaveChanges();
            }
            return affected > 0;
        }
        /// <summary>
        /// Called while Window is closing 
        /// </summary>
        public override void Closing()
        {
            if (PopupType == PopupTypeEnum.Edit)
            {
                if (!IsSavedSuccessfully)
                {
                    Entity.CancelEdit();
                }
                Entity.Validate();
            }
        }
        #endregion
    }
}

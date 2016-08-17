using System;
using GenericCodes.CRUD.WPF.Core.MVVM;

namespace GenericCodes.CRUD.WPF.ViewModel.CRUDBases
{
    public abstract class PopupViewModelBase : ObservableObject
    {
        public PopupViewModelBase()
        {
        }
        /// <summary>
        ///Represent delegate that will be called when Window closed
        /// </summary>
        public Action CloseAssociatedWindow { get; set; }

        private RelayCommand _closeAssociatedCommand;
        /// <summary>
        /// The Close associated window command
        /// </summary>
        public RelayCommand CloseAssociatedWindowCommand
        {
            get
            {
                return _closeAssociatedCommand ?? (_closeAssociatedCommand = new RelayCommand(() =>
                {
                    CloseAssociatedWindow();
                }));
            }
        }
        /// <summary>
        /// Called while Window is closing 
        /// </summary>
        public virtual void Closing() { }

    }
}

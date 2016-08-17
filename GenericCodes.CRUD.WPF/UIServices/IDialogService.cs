using GenericCodes.CRUD.WPF.Core;
using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;

namespace GenericCodes.CRUD.WPF.UIServices
{
    public interface IDialogService
    {
        /// <summary>
        /// Show Add/Edit Popup Window
        /// </summary>
        /// <param name="type">Window Type</param>
        /// <param name="viewModel">The viewmodel that will be bound to window data context</param>
        /// <param name="windowStyleName">Window style name</param>
        void ShowAddEditWindow(PopupTypeEnum type, PopupViewModelBase viewModel, string windowStyleName);
        /// <summary>
        /// Show confirmation dialog
        /// </summary>
        /// <param name="title">Dialog Title</param>
        /// <param name="message">Dialog Message</param>
        /// <returns>return true if it is confirmed otherwise return false</returns>
        bool ShowConfirmDialog(string title, string message);
    }
}

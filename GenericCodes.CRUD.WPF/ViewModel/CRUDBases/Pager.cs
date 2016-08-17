using System;
using GenericCodes.CRUD.WPF.Core.MVVM;

namespace GenericCodes.CRUD.WPF.ViewModel.CRUDBases
{
    public class Pager : ObservableObject
    {
        public Pager()
        {
        }

        #region Properties
        /// <summary>
        /// The PageChanged event
        /// </summary>
        public event Action PageChanged;

        private int _pageSize = 10;
        /// <summary>
        /// Gets or sets Page Size
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                Set(() => PageSize, ref _pageSize, value);
                HandlePageChaned();
            }
        }

        private int _currentPage = 1;
        /// <summary>
        /// Gets or sets Current page
        /// </summary>
        public int CurrentPage
        {
            set { Set(() => CurrentPage, ref _currentPage, value); }
            get { return _currentPage; }
        }

        private int _totalRecords;
        /// <summary>
        /// Gets or sets number of total records
        /// </summary>
        public int TotalRecords
        {
            set { Set(() => TotalRecords, ref _totalRecords, value); }
            get { return _totalRecords; }
        }
        /// <summary>
        /// Gets number of total pages
        /// </summary>
        public int TotalPages
        {
            get { return (int)Math.Ceiling((double)TotalRecords / _pageSize); }
        }

        #endregion

        #region Commands

        private RelayCommand _firstPageCommand;
        /// <summary>
        /// The FirstPage command
        /// Navigate to first page
        /// </summary>
        public RelayCommand FirstPageCommand
        {
            get
            {
                return _firstPageCommand ?? (_firstPageCommand = new RelayCommand(() =>
                {
                    CurrentPage = 1;
                    HandlePageChaned();
                }, () => _currentPage > 1));
            }
        }

        private RelayCommand _lastPageCommand;
        /// <summary>
        /// The LastPage command
        /// navigate to last page
        /// </summary>
        public RelayCommand LastPageCommand
        {
            get
            {
                return _lastPageCommand ?? (_lastPageCommand = new RelayCommand(() =>
                {
                    CurrentPage = TotalPages;
                    HandlePageChaned();
                }, () => _currentPage < TotalPages));
            }
        }

        private RelayCommand _nextPageCommand;
        /// <summary>
        /// The NextPage command
        /// navigate to next page
        /// </summary>
        public RelayCommand NextPageCommand
        {
            get
            {
                return _nextPageCommand ?? (_nextPageCommand = new RelayCommand(() =>
                {

                    CurrentPage++;
                    HandlePageChaned();
                }, () => _currentPage < TotalPages));
            }
        }

        private RelayCommand _prevPageCommand;
        /// <summary>
        /// the PreviousPage command
        /// Naviagte to previous page
        /// </summary>
        public RelayCommand PrevPageCommand
        {
            get
            {
                return _prevPageCommand ?? (_prevPageCommand = new RelayCommand(() =>
                {

                    CurrentPage--;
                    HandlePageChaned();
                }, () => _currentPage > 1));
            }
        }

        #endregion

        private void HandlePageChaned()
        {
            if (PageChanged!=null)
            {
                PageChanged();
            }
        }
    }
}

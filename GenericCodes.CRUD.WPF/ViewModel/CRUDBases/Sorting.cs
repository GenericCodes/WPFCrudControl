using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using GenericCodes.CRUD.WPF.Core;
using GenericCodes.CRUD.WPF.Core.MVVM;

namespace GenericCodes.CRUD.WPF.ViewModel.CRUDBases
{
    public class Sorting : ObservableObject
    {

        public Sorting()
        {
        }

        #region Public Properties
        /// <summary>
        /// The SortingChanged event
        /// </summary>
        public event Action SortingChanged;


        private ObservableCollection<SortingProperty> _sortingProperties;
        /// <summary>
        /// Gets or sets Sorting Properties
        /// </summary>
        public virtual ObservableCollection<SortingProperty> SortingProperties
        {
            get { return _sortingProperties; }
            set
            {
                Set(() => SortingProperties, ref _sortingProperties, value);
                _sortingPropertyValue = SortingProperties.First().PropertyPath;
                RaisePropertyChanged(() => SortingPropertyValue);
            }
        }

        private ListSortDirection _sortDirectionValue;
        /// <summary>
        /// Gets or sets Sorting Direction
        /// </summary>
        public ListSortDirection SortDirectionValue
        {
            get { return _sortDirectionValue; }
            set
            {
                Set(() => SortDirectionValue, ref _sortDirectionValue, value);
                HandleSortingChanged();
            }
        }


        private string _sortingPropertyValue;
        /// <summary>
        /// Gets or sets SortingProperty Value
        /// </summary>
        public string SortingPropertyValue
        {
            get { return _sortingPropertyValue; }
            set
            {
                Set(() => SortingPropertyValue, ref _sortingPropertyValue, value);
                HandleSortingChanged();
            }
        }
        #endregion

        private void HandleSortingChanged()
        {
            if (SortingChanged!=null)
            {
                SortingChanged();
            }
        }
    }
}

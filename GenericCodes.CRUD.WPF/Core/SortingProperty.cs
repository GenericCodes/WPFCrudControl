using System.ComponentModel;

namespace GenericCodes.CRUD.WPF.Core
{
    /// <summary>
    /// Represents a displayable SortingProperty.
    /// </summary>
    public class SortingProperty : INotifyPropertyChanged
    {
        private string _propertyPath;

        /// <summary>
        /// Gets or sets the Property Name.
        /// </summary>
        /// <value>The Property Name.</value>
        public string PropertyPath
        {
            get { return _propertyPath; }

            set
            {
                this._propertyPath = value;
                OnPropertyChanged("PropertyPath");
            }
        }
        private string _displayName;

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName
        {
            get { return this._displayName; }
            set
            {
                if (this._displayName != value)
                {
                    this._displayName = value;
                    OnPropertyChanged("DisplayName");
                }
            }
        }
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

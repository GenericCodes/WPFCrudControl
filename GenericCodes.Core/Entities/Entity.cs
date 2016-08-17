using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GenericCodes.Core.Entities
{
    public class Entity : INotifyDataErrorInfo, IEditableObject, INotifyPropertyChanged
    {
        private bool _isSelected;
        /// <summary>
        /// Gets or sets The isSelected
        /// </summary>
        [NotMapped]
        public virtual bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _isSelectable = true;
        /// <summary>
        /// Gets or sets the canSelected 
        /// </summary>
        [NotMapped]
        public virtual bool IsSelectable
        {
            get
            {
                return _isSelectable;
            }
            set
            {
                if (_isSelectable != value)
                {
                    _isSelectable = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///  This method is called by the Set accessor of each property.
        ///  The CallerMemberName attribute that is applied to the optional propertyName
        ///  parameter causes the property name of the caller to be substituted as an argument.
        /// </summary>
        /// <param name="propertyName">The propertyName</param>

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Validation
        private ConcurrentDictionary<string, List<string>> _errors = new ConcurrentDictionary<string, List<string>>();

        /// <summary>
        /// Error changed Event
        /// </summary>
        public event System.EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        /// <summary>
        /// Handle error changed event
        /// </summary>
        /// <param name="propertyName"> The property name</param>
        public void OnErrorsChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return;
            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// Get Errors on specific property
        /// </summary>
        /// <param name="propertyName">The Property name</param>
        /// <returns></returns>
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return null;

            List<string> errorsForName;
            _errors.TryGetValue(propertyName, out errorsForName);
            return errorsForName;
        }
        /// <summary>
        /// Check if entity has Errors
        /// </summary>
        public bool HasErrors
        {
            get { return _errors.Any(kv => kv.Value != null && kv.Value.Count > 0); }
        }

        public Task ValidateAsync()
        {
            return Task.Run(() => Validate());
        }

        private object _lock = new object();
        /// <summary>
        /// Validate entity against its validations attributes
        /// </summary>
        public void Validate()
        {
            lock (_lock)
            {
                var validationContext = new ValidationContext(this, null, null);
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateObject(this, validationContext, validationResults, true);

                foreach (var kv in _errors.ToList())
                {
                    if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                    {
                        List<string> outLi;
                        _errors.TryRemove(kv.Key, out outLi);
                        OnErrorsChanged(kv.Key);
                    }
                }

                var q = from r in validationResults
                        from m in r.MemberNames
                        group r by m into g
                        select g;

                foreach (var prop in q)
                {
                    var messages = prop.Select(r => r.ErrorMessage).ToList();

                    if (_errors.ContainsKey(prop.Key))
                    {
                        List<string> outLi;
                        _errors.TryRemove(prop.Key, out outLi);
                    }
                    _errors.TryAdd(prop.Key, messages);
                    OnErrorsChanged(prop.Key);
                }
            }
        }

        #endregion

        #region EditableObject

        private Hashtable props = null;

        #region IEditableObject Members

        /// <summary>
        /// Set object in edit mode and save current values
        /// </summary>
        public void BeginEdit()
        {
            //exit if in Edit mode
            if (null != props) return;

            //enumerate properties
            PropertyInfo[] properties = (this.GetType()).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            props = new Hashtable(properties.Length - 1);

            for (int i = 0; i < properties.Length; i++)
            {
                //check if there is set accessor
                if (null != properties[i].GetSetMethod())
                {
                    object value = properties[i].GetValue(this, null);
                    props.Add(properties[i].Name, value);
                }
            }
        }

        /// <summary>
        /// Reject changes made to object since method BeginEdit() was called
        /// </summary>
        public void CancelEdit()
        {
            //check for unappropriated call sequence
            if (null == props) return;

            //restore old values
            PropertyInfo[] properties = (this.GetType()).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < properties.Length; i++)
            {
                //check if there is set accessor
                if (null != properties[i].GetSetMethod())
                {
                    object value = props[properties[i].Name];
                    properties[i].SetValue(this, value, null);
                }
            }

            //delete current values            
            //props = null;
        }

        /// <summary>
        /// Commit changes in object since method BeginEdit() was called
        /// </summary>
        public void EndEdit()
        {
            //delete current values            
            props = null;
            BeginEdit();
        }

        #endregion

        #endregion
    }
}

using System;
using System.Windows.Markup;

namespace GenericCodes.CRUD.WPF.Converters
{
    public abstract class BaseConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}

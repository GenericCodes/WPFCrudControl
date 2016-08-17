using System;
using System.Windows;
using System.Windows.Controls;

namespace GenericCodes.CRUD.WPF.Core
{
    /// <summary>
    /// Represents Crud DataGridColumn
    /// </summary>
    public class CustomDataGridColumn : DataGridColumn
    {
        public CustomDataGridColumn()
        {
            ColumnType = ColumnTypeEnum.TextColumn;
            IsReadOnly = true;
        }
        /// <summary>
        /// Gets or sets the Crud column Binding.
        /// </summary>
        public string BindingExpression { get; set; }
        /// <summary>
        /// Gets or sets the Crud column Type.
        /// </summary>
        public ColumnTypeEnum ColumnType { get; set; }
        /// <summary>
        /// Gets or sets the Crud column Template.
        /// </summary>
        public DataTemplate DataGridColumnTemplate { get; set; }
        /// <summary>
        ///  When overridden in a derived class, gets a read-only element that is bound to
        //   the System.Windows.Controls.DataGridBoundColumn.Binding property value of the
        //   column.
        /// </summary>
        /// <param name="cell"> The cell that will contain the generated element.</param>
        /// <param name="dataItem"> The data item that is represented by the row that contains the intended cell.</param>
        /// <returns>
        ///  A new read-only element that is bound to the System.Windows.Controls.DataGridBoundColumn.Binding
        //  property value of the column.
        /// </returns>
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            FrameworkElement control = null;

            switch (ColumnType)
            {
                case ColumnTypeEnum.TextColumn:
                    control = new TextBlock();
                    control.SetBinding(TextBlock.TextProperty, BindingExpression);
                    break;

                case ColumnTypeEnum.TemplateColumn:
                    control = (FrameworkElement)DataGridColumnTemplate.LoadContent();
                    break;
            }

            return control;
        }

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            throw new NotImplementedException();
        }
    }
}

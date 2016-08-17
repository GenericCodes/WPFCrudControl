using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using GenericCodes.CRUD.WPF.Core;
using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;

namespace GenericCodes.CRUD.WPF.Views.CRUD
{
    /// <summary>
    /// Interaction logic for GenericCRUDControl.xaml
    /// </summary>
    public partial class GenericCrudControl : UserControl
    {
        public GenericCrudControl()
        {
            
            InitializeComponent();
            SetValue(ColumnsProperty, new ObservableCollection<CustomDataGridColumn>());
            SetValue(SortingPropertiesProperty, new ObservableCollection<SortingProperty>());
        }

        #region Dependency Property
        /// <summary>
        /// Identifies the PagerPreviousPageBtnStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty PagerPreviousPageBtnStyleProperty = DependencyProperty.Register("PagerPreviousPageBtnStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["PagerPreviousPageButtonStyle"] as Style));
        /// <summary>
        /// Gets or sets PagerPreviousPage Button Style.
        /// </summary>
        public Style PagerPreviousPageBtnStyle
        {
            get { return (Style)this.GetValue(PagerPreviousPageBtnStyleProperty); }
            set { SetValue(PagerPreviousPageBtnStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the PagerFirstPageBtnStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty PagerFirstPageBtnStyleProperty = DependencyProperty.Register("PagerFirstPageBtnStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["PagerFirstPageButtonStyle"] as Style));
        /// <summary>
        /// Gets or sets PagerFirstPage Button Style.
        /// </summary>
        public Style PagerFirstPageBtnStyle
        {
            get { return (Style)this.GetValue(PagerFirstPageBtnStyleProperty); }
            set { SetValue(PagerFirstPageBtnStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the PagerNextPageBtnStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty PagerNextPageBtnStyleProperty = DependencyProperty.Register("PagerNextPageBtnStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["PagerNextPageButtonStyle"] as Style));
        /// <summary>
        /// Gets or sets PagerNextPage Button Style.
        /// </summary>
        public Style PagerNextPageBtnStyle
        {
            get { return (Style)this.GetValue(PagerNextPageBtnStyleProperty); }
            set { SetValue(PagerNextPageBtnStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the PagerLastPageBtnStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty PagerLastPageBtnStyleProperty = DependencyProperty.Register("PagerLastPageBtnStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["PagerLastPageButtonStyle"] as Style));
        /// <summary>
        /// Gets or sets PagerLastPage Button Style.
        /// </summary>
        public Style PagerLastPageBtnStyle
        {
            get { return (Style)this.GetValue(PagerLastPageBtnStyleProperty); }
            set { SetValue(PagerLastPageBtnStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the PagerCurrentPageTextBoxStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty PagerCurrentPageTextBoxStyleProperty = DependencyProperty.Register("PagerCurrentPageTextBoxStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["PagerCurrentPageTextBoxStyle"] as Style));
        /// <summary>
        /// Gets or sets PagerCurrentPage TextBox Style.
        /// </summary>
        public Style PagerCurrentPageTextBoxStyle
        {
            get { return (Style)this.GetValue(PagerCurrentPageTextBoxStyleProperty); }
            set { SetValue(PagerCurrentPageTextBoxStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the PagerTotalRecordLabelStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty PagerTotalRecordLabelStyleProperty = DependencyProperty.Register("PagerTotalRecordLabelStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["PagerTotalRecordLabelStyle"] as Style));
        /// <summary>
        /// Gets or sets PagerTotalRecord Label Style.
        /// </summary>
        public Style PagerTotalRecordLabelStyle
        {
            get { return (Style)this.GetValue(PagerTotalRecordLabelStyleProperty); }
            set { SetValue(PagerTotalRecordLabelStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the PagerPageSizeLabelStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty PagerPageSizeLabelStyleProperty = DependencyProperty.Register("PagerPageSizeLabelStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["PagerPageSizeLabelStyle"] as Style));
        /// <summary>
        /// Gets or sets PagerPageSize Label Style.
        /// </summary>
        public Style PagerPageSizeLabelStyle
        {
            get { return (Style)this.GetValue(PagerPageSizeLabelStyleProperty); }
            set { SetValue(PagerPageSizeLabelStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the PagerTotalRecordValueStyle dependency property.
        /// </summary>

        public static readonly DependencyProperty PagerTotalRecordValueStyleProperty = DependencyProperty.Register("PagerTotalRecordValueStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["PagerTotalRecordValueStyle"] as Style));
        /// <summary>
        /// Gets or sets PagerTotalRecordValue Label Style.
        /// </summary>
        public Style PagerTotalRecordValueStyle
        {
            get { return (Style)this.GetValue(PagerTotalRecordValueStyleProperty); }
            set { this.SetValue(PagerTotalRecordValueStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the PagerPageSizeComboBoxStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty PagerPageSizeComboBoxStyleProperty = DependencyProperty.Register("PagerPageSizeComboBoxStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["PagerPageSizeComboBoxStyle"] as Style));
        /// <summary>
        /// Gets or sets PagerPageSize ComboBox Style
        /// </summary>
        public Style PagerPageSizeComboBoxStyle
        {
            get { return (Style)this.GetValue(PagerPageSizeComboBoxStyleProperty); }
            set { this.SetValue(PagerPageSizeComboBoxStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the SearchButtonStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchButtonStyleProperty = DependencyProperty.Register("SearchButtonStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["CRUDSearchButtonStyle"] as Style));
        /// <summary>
        /// Gets or sets SearchButton Style
        /// </summary>
        public Style SearchButtonStyle
        {
            get { return (Style)this.GetValue(SearchButtonStyleProperty); }
            set { this.SetValue(SearchButtonStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the SortingByLabelStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty SortingByLabelStyleProperty = DependencyProperty.Register("SortingByLabelStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["SortingByLabelStyle"] as Style));
        /// <summary>
        /// Gets or sets SortingBy Label Style
        /// </summary>
        public Style SortingByLabelStyle
        {
            get { return (Style)this.GetValue(SortingByLabelStyleProperty); }
            set { this.SetValue(SortingByLabelStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the SortingTypeLabelStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty SortingTypeLabelStyleProperty = DependencyProperty.Register("SortingTypeLabelStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["SortingTypeLabelStyle"] as Style));
        /// <summary>
        /// Gets or sets SortingType Label Style
        /// </summary>
        public Style SortingTypeLabelStyle
        {
            get { return (Style)this.GetValue(SortingTypeLabelStyleProperty); }
            set { this.SetValue(SortingTypeLabelStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the SortingByComboBoxStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty SortingByComboBoxStyleProperty = DependencyProperty.Register("SortingByComboBoxStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["SortingByComboBoxStyle"] as Style));
        /// <summary>
        /// Gets or sets SortingBy ComboBox Style
        /// </summary>
        public Style SortingByComboBoxStyle
        {
            get { return (Style)this.GetValue(SortingByComboBoxStyleProperty); }
            set { this.SetValue(SortingByComboBoxStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the SortingTypeComboBoxStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty SortingTypeComboBoxStyleProperty = DependencyProperty.Register("SortingTypeComboBoxStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["SortingTypeComboBoxStyle"] as Style));
        /// <summary>
        /// Gets or sets SortingType ComboBox Style
        /// </summary>
        public Style SortingTypeComboBoxStyle
        {
            get { return (Style)this.GetValue(SortingTypeComboBoxStyleProperty); }
            set { this.SetValue(SortingTypeComboBoxStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the ResetButtonStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty ResetButtonStyleProperty = DependencyProperty.Register("ResetButtonStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["CRUDResetButtonStyle"] as Style));
        /// <summary>
        /// Gets or sets ResetButton Style
        /// </summary>
        public Style ResetButtonStyle
        {
            get { return (Style)this.GetValue(ResetButtonStyleProperty); }
            set { SetValue(ResetButtonStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the DeleteButtonStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty DeleteButtonStyleProperty = DependencyProperty.Register("DeleteButtonStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["CRUDDeleteButtonStyle"] as Style));
        /// <summary>
        /// Gets or sets DeleteButton Style
        /// </summary>
        public Style DeleteButtonStyle
        {
            get { return (Style)this.GetValue(DeleteButtonStyleProperty); }
            set { SetValue(DeleteButtonStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the AddButtonStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty AddButtonStyleProperty = DependencyProperty.Register("AddButtonStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["CRUDAddButtonStyle"] as Style));
        /// <summary>
        /// Gets or sets AddButton Style
        /// </summary>
        public Style AddButtonStyle
        {
            get { return (Style)this.GetValue(AddButtonStyleProperty); }
            set { SetValue(AddButtonStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the EditButtonStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty EditButtonStyleProperty = DependencyProperty.Register("EditButtonStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["CRUDEditButtonStyle"] as Style));
        /// <summary>
        /// Gets or sets Edit Button Style
        /// </summary>
        public Style EditButtonStyle
        {
            get { return (Style)this.GetValue(EditButtonStyleProperty); }
            set { this.SetValue(EditButtonStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the SearchGroupBoxStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchGroupBoxStyleProperty = DependencyProperty.Register("SearchGroupBoxStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["CRUDSearchGroupBoxStyle"] as Style));
        /// <summary>
        /// Gets or sets Search GroupBox Style
        /// </summary>
        public Style SearchGroupBoxStyle
        {
            get { return (Style)this.GetValue(SearchGroupBoxStyleProperty); }
            set { this.SetValue(SearchGroupBoxStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the IsSelectedCheckBoxStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty IsSelectedCheckBoxStyleProperty = DependencyProperty.Register("IsSelectedCheckBoxStyle", typeof(Style), typeof(GenericCrudControl), new PropertyMetadata(Application.Current.Resources["CRUDIsSelectedCheckBoxStyle"] as Style));
        /// <summary>
        /// Gets or sets IsSelected CheckBox Style
        /// </summary>
        public Style IsSelectedCheckBoxStyle
        {
            get { return (Style)this.GetValue(IsSelectedCheckBoxStyleProperty); }
            set { SetValue(IsSelectedCheckBoxStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the "" dependency property.
        /// </summary>
        public static readonly DependencyProperty DataGridStyleProperty = DependencyProperty.Register("DataGridStyle", typeof(Style), typeof(GenericCrudControl));
        /// <summary>
        /// Gets or sets DataGrid Cell style
        /// </summary>
        public Style DataGridStyle
        {
            get { return (Style)this.GetValue(DataGridStyleProperty); }
            set { SetValue(DataGridStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the DataGridCellStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty DataGridCellStyleProperty = DependencyProperty.Register("DataGridCellStyle", typeof(Style), typeof(GenericCrudControl));
        /// <summary>
        /// Gets or sets DataGrid Cell style
        /// </summary>
        public Style DataGridCellStyle
        {
            get { return (Style)this.GetValue(DataGridCellStyleProperty); }
            set { SetValue(DataGridCellStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the DataGridRowStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty DataGridRowStyleProperty = DependencyProperty.Register("DataGridRowStyle", typeof(Style), typeof(GenericCrudControl));
        /// <summary>
        /// Gets or sets DataGrid Row style
        /// </summary>
        public Style DataGridRowStyle
        {
            get { return (Style)this.GetValue(DataGridRowStyleProperty); }
            set { this.SetValue(DataGridRowStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the DataGridRowHeaderStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty DataGridRowHeaderStyleProperty = DependencyProperty.Register("DataGridRowHeaderStyle", typeof(Style), typeof(GenericCrudControl));
        /// <summary>
        /// Gets or sets DataGrid Row Header style
        /// </summary>
        public Style DataGridRowHeaderStyle
        {
            get { return (Style)this.GetValue(DataGridRowHeaderStyleProperty); }
            set { SetValue(DataGridRowHeaderStyleProperty, value); }
        }
        /// <summary>
        /// Identifies the DataGridColumnHeaderStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty DataGridColumnHeaderStyleProperty = DependencyProperty.Register("DataGridColumnHeaderStyle", typeof(Style), typeof(GenericCrudControl));
        /// <summary>
        /// Gets or sets DataGrid Column Header style
        /// </summary>
        public Style DataGridColumnHeaderStyle
        {
            get { return (Style)this.GetValue(DataGridColumnHeaderStyleProperty); }
            set { SetValue(DataGridColumnHeaderStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the CustomColumns dependency property.
        /// </summary>
        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
            "Columns", typeof(ObservableCollection<CustomDataGridColumn>),
            typeof(GenericCrudControl),
            new UIPropertyMetadata(new ObservableCollection<CustomDataGridColumn>()));
        /// <summary>
        /// Gets or sets Crud dataGrid columns
        /// </summary>
        public ObservableCollection<CustomDataGridColumn> Columns
        {
            get { return (ObservableCollection<CustomDataGridColumn>)this.GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        /// <summary>
        /// Identifies the SortingProperties dependency property.
        /// </summary>
        public static readonly DependencyProperty SortingPropertiesProperty = DependencyProperty.Register("SortingProperties", typeof(ObservableCollection<SortingProperty>), typeof(GenericCrudControl), new UIPropertyMetadata(new ObservableCollection<SortingProperty>()));
        /// <summary>
        /// Gets or sets sorting properties.
        /// </summary>
        public ObservableCollection<SortingProperty> SortingProperties
        {
            get { return (ObservableCollection<SortingProperty>)this.GetValue(SortingPropertiesProperty); }
            set { SetValue(SortingPropertiesProperty, value); }
        }


        /// <summary>
        /// Identifies the EnableSortingPaging dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableSortingPagingProperty = DependencyProperty.Register("EnableSortingPaging", typeof(bool), typeof(GenericCrudControl), new UIPropertyMetadata(true));
        /// <summary>
        /// Gets or sets EnableSortingPaging flag.
        /// </summary>
        public bool EnableSortingPaging
        {
            get { return (bool)GetValue(EnableSortingPagingProperty); }
            set { SetValue(EnableSortingPagingProperty, value); }
        }


        /// <summary>
        /// Identifies the EnableAdd dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableAddProperty = DependencyProperty.Register("EnableAdd", typeof(bool), typeof(GenericCrudControl), new UIPropertyMetadata(true));
        /// <summary>
        /// Gets or sets EnableAdd flag.
        /// </summary>
        public bool EnableAdd
        {
            get { return (bool)GetValue(EnableAddProperty); }
            set { SetValue(EnableAddProperty, value); }
        }

        /// <summary>
        /// Identifies the EnableDelete dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableDeleteProperty = DependencyProperty.Register("EnableDelete", typeof(bool), typeof(GenericCrudControl), new UIPropertyMetadata(true));
        /// <summary>
        /// Gets or sets EnableDelete flag.
        /// </summary>
        public bool EnableDelete
        {
            get { return (bool)GetValue(EnableDeleteProperty); }
            set { SetValue(EnableDeleteProperty, value); }
        }

        /// <summary>
        /// Identifies the EnableSearch dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableSearchProperty = DependencyProperty.Register("EnableSearch", typeof(bool), typeof(GenericCrudControl), new UIPropertyMetadata(true));
        /// <summary>
        /// Gets or sets EnableSearch flag.
        /// </summary>
        public bool EnableSearch
        {
            get { return (bool)GetValue(EnableSearchProperty); }
            set { SetValue(EnableSearchProperty, value); }
        }
        #endregion

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 1;
                var dataGrid = (DataGrid)sender;
                if (dataGrid.Columns.Count > 2)
                {
                    e.Handled = true;
                    return;
                }
                foreach (var customColumn in Columns)
                    dataGrid.Columns.Insert(i++, customColumn);

                MethodInfo loadDataMethod = this.DataContext.GetType().GetMethod("LoadData");
                loadDataMethod.Invoke(this.DataContext, null);
            }
            catch (Exception )
            {
            }
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var sortingpanel = (StackPanel)sender;
                var sortingVM = sortingpanel.DataContext as Sorting;
                if (sortingVM.SortingProperties != null && sortingVM.SortingProperties.Count > 0)
                {
                    e.Handled = true;
                    return;
                }
                sortingVM.SortingProperties = SortingProperties;
            }
            catch (Exception)
            {

            }   
        }
    }
}

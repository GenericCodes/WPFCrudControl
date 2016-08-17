using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GenericCodes.Core.Repositories;
using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;
using Northwind.DAL.Models;
using PropertyChanged;

namespace Northwind.Demo.ViewModel.Products
{
   
    public class ProductsSearchViewModel : SearchCriteriaBase<Product>
    {
        public ProductsSearchViewModel() : base()
        {

        }
        public ProductsSearchViewModel(IRepository<Category> categoryRepo, IRepository<Supplier> suppierRepo)
        {
            Categories = categoryRepo.Queryable().ToList();
            Suppliers = suppierRepo.Queryable().ToList();
        }

        private string _productNameSearchCriteria;
        public string ProductNameSearchCriteria
        {
            get { return _productNameSearchCriteria; }
            set
            {
                if (_productNameSearchCriteria != value)
                {
                    _productNameSearchCriteria = value;
                    RaisePropertyChanged(() => ProductNameSearchCriteria);
                }
            }
        }

        private int? _supplierIDSearchCriteria;
        public int? SupplierIDSearchCriteria
        {
            get { return _supplierIDSearchCriteria; }
            set
            {
                if (_supplierIDSearchCriteria != value)
                {
                    _supplierIDSearchCriteria = value;
                    RaisePropertyChanged(() => SupplierIDSearchCriteria);
                }
            }
        }
        private int? _categoryIDSearchCriteria;
        public int? CategoryIDSearchCriteria
        {
            get { return _categoryIDSearchCriteria; }
            set
            {
                if (_categoryIDSearchCriteria != value)
                {
                    _categoryIDSearchCriteria = value;
                    RaisePropertyChanged(() => CategoryIDSearchCriteria);
                }
            }
        }

        private List<Category> _categories;
        public List<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged(() => Categories);
            }
        }
        private List<Supplier> _suppliers;
        public List<Supplier> Suppliers
        {
            get { return _suppliers; }
            set
            {
                _suppliers = value;
                RaisePropertyChanged(() => Suppliers);
            }
        }
        public override Expression<Func<Product, bool>> GetSearchCriteria()
        {
            return
                product =>
                    (string.IsNullOrEmpty(ProductNameSearchCriteria) ||
                     product.ProductName.Contains(ProductNameSearchCriteria)) &&
                    (SupplierIDSearchCriteria == null || product.SupplierID == SupplierIDSearchCriteria) &&
                    (CategoryIDSearchCriteria == null || product.CategoryID == CategoryIDSearchCriteria);
        }

        public override void ResetSearchCriteria()
        {
            ProductNameSearchCriteria = string.Empty;
            SupplierIDSearchCriteria = null;
            CategoryIDSearchCriteria = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;
using Northwind.DAL.Models;
using Northwind.Service.Interfaces;

namespace Northwind.Demo.ViewModel.Products
{
    public class ProductsListViewModel : GenericCrudBase<Product>
    {
        public ProductsListViewModel(ProductsSearchViewModel productsSearchViewModel,
            ProductAddEditViewModel productAddEditViewModel, ICategoryService categoryService, ISuppliersService suppliersService)
            : base(productsSearchViewModel, productAddEditViewModel)
        {
            ListingIncludes = new Expression<Func<Product, object>>[]
            {
                p => p.Category,
                p => p.Supplier
            };

            PreAddEditDelegate = (type) =>
            {
                productAddEditViewModel.Categories = categoryService.GetALL();
                productAddEditViewModel.Suppliers = suppliersService.GetALL();
            };
        }
    }
}

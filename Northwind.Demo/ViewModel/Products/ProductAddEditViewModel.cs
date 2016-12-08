using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCodes.Core.Repositories;
using GenericCodes.Core.Services;
using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;
using Northwind.DAL.Models;
using Northwind.Service.Interfaces;
using Microsoft.Practices.ServiceLocation;
using GenericCodes.Core.UnitOfWork;

namespace Northwind.Demo.ViewModel.Products
{
    public class ProductAddEditViewModel : AddEditEntityBase<Product>
    {
        public ProductAddEditViewModel()
        {

        }

        private List<Category> _categories;
        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
                RaisePropertyChanged(() => Categories);
            }
        }
        private List<Supplier> _suppliers;
        public List<Supplier> Suppliers
        {
            get
            {
                return _suppliers;
            }
            set
            {
                _suppliers = value;
                RaisePropertyChanged(() => Suppliers);
            }
        }
    }
}

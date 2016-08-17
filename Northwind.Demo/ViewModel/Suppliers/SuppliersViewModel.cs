using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;
using Northwind.DAL.Models;
using Northwind.Service.Interfaces;
using Northwind.Demo.Views.Suppliers;
using GenericCodes.Core.Repositories;

namespace Northwind.Demo.ViewModel.Suppliers
{
    public class SuppliersViewModel : GenericCrudBase<Supplier>
    {
        public SuppliersViewModel(SuppliersSearchViewModel supplierSearch, ISuppliersService supplierService, SuppliersAddEditViewModel suppliersAddEdit)
            : base(supplierSearch, suppliersAddEdit)
        {           
            PostDataRetrievalDelegate = (list) =>
            {
                supplierService.UpdateCanSelect(list);
            };
           
        }

        
    }
}

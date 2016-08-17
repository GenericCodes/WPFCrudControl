using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;
using Northwind.DAL.Models;
using Northwind.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Demo.ViewModel.Suppliers
{
    public class SuppliersAddEditViewModel : AddEditEntityBase<Supplier>
    {
        public SuppliersAddEditViewModel()
            : base()
        {

        }
    }
}

using System.Collections.Generic;
using GenericCodes.Core.Services;
using Northwind.DAL.Models;

namespace Northwind.Service.Interfaces
{
    public interface ISuppliersService : IService<Supplier>
    {
        void UpdateCanSelect(List<Supplier> entities);
        List<Supplier> GetALL();
    }
}

using Northwind.DAL.Models;
using Northwind.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCodes.Core.Services;
using GenericCodes.Core.Repositories;
using GenericCodes.Core.UnitOfWork;
using Microsoft.Practices.ServiceLocation;

namespace Northwind.Service
{
    public class SuppliersService : Service<Supplier>, ISuppliersService
    {
        public SuppliersService(IRepository<Supplier> repository) : base(repository)
        {

        }
        public List<Supplier> GetALL()
        {
            using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
            {
                var suppliers = unitOfWork.Repository<Supplier>().List().ToList();
                return suppliers;
            }
        }
        public void UpdateCanSelect(List<Supplier> entities)
        {
            bool isUsed;
            using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
            {
                var productRepo = unitOfWork.Repository<Product>();
                List<int> usedIds = productRepo.List(p => p.SupplierID.HasValue).Select(p => p.SupplierID.Value).ToList();
                entities.ForEach(t =>
                {
                    isUsed = usedIds.Contains(t.SupplierID);
                    t.IsSelectable = (!isUsed);
                });
            }
        }
    }
}

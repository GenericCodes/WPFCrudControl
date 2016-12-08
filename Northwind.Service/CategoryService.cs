using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCodes.Core.Repositories;
using Northwind.DAL.Models;
using Northwind.Service.Interfaces;
using GenericCodes.Core.Services;
using GenericCodes.Core.UnitOfWork;
using Microsoft.Practices.ServiceLocation;

namespace Northwind.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository) : base(repository)
        {

        }
        public List<Category> GetALL()
        {
            using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
            {
                var categories = unitOfWork.Repository<Category>().List().ToList();
                return categories;
            }
        }
    }
}

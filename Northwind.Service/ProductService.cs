using GenericCodes.Core.Repositories;
using GenericCodes.Core.Services;
using Northwind.DAL.Models;
using Northwind.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCodes.Core.Helper;
using GenericCodes.Core.UnitOfWork;
using Microsoft.Practices.ServiceLocation;

namespace Northwind.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository)
            : base(repository)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCodes.Core.Services;
using Northwind.DAL.Models;

namespace Northwind.Service.Interfaces
{
    public interface ICategoryService : IService<Category>
    {
        List<Category> GetALL();
    }
}

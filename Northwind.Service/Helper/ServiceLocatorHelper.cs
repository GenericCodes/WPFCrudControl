using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using GenericCodes.Core.Repositories;
using GenericCodes.Core.UnitOfWork;


namespace Northwind.Service.Helper
{
    internal static class ServiceLocatorHelper
    {
        #region UnitOfWork
        public static IUnitOfWork NorthwindUnitOfWork
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IUnitOfWork>();
            }
        }
        
        #endregion
    }
}

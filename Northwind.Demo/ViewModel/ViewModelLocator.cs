/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:GenericWPFCRUD.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System.Data.Entity;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GenericCodes.Core.DbContext;
using GenericCodes.Core.Repositories;
using GenericCodes.Core.Services;
using GenericCodes.Core.UnitOfWork;
using GenericCodes.CRUD.WPF.UIServices;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Northwind.DAL;
using Northwind.DAL.Models;
using Northwind.Demo.ViewModel.Products;
using Northwind.Demo.ViewModel.Suppliers;
using Northwind.Service;
using Northwind.Service.Interfaces;
using PerThreadLifetimeManager = Northwind.Demo.Library.PerThreadLifetimeManager;
namespace Northwind.Demo.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {

            IUnityContainer container = new UnityContainer();

            #region register DataContext & UnitOfWork
            Database.SetInitializer<NorthwindContext>(new System.Data.Entity.NullDatabaseInitializer<NorthwindContext>());

            container.RegisterType<ApplicationDbContext, NorthwindContext>(new PerThreadLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Register Repositories
            container.RegisterType<IRepository<Supplier>, Repository<Supplier>>();
            container.RegisterType<IRepository<Product>, Repository<Product>>();
            container.RegisterType<IRepository<Category>, Repository<Category>>();
            #endregion

            #region Register App Services
            container.RegisterType<IDialogService, DialogService>(); 
            #endregion


            #region Register Business Services
            container.RegisterType<ISuppliersService, SuppliersService>();
            container.RegisterType<IProductService, ProductService>();
            //container.RegisterType<IService<Category>, Service<Category>>();
            #endregion

            #region Register ViewModels

            container.RegisterType<MainViewModel>();


            container.RegisterType<SuppliersViewModel>();
            container.RegisterType<SuppliersSearchViewModel>();
            container.RegisterType<SuppliersAddEditViewModel>();

            container.RegisterType<ProductsListViewModel>();
            container.RegisterType<ProductsSearchViewModel>();
            container.RegisterType<ProductAddEditViewModel>();

            #endregion

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public SuppliersViewModel  Suppliers
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SuppliersViewModel>();
            }
        }

        public ProductsListViewModel Products
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProductsListViewModel>();
            }
        }
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}
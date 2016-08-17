using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Demo.ViewModel.Suppliers
{
    public class SuppliersSearchViewModel : SearchCriteriaBase<Supplier>
    {
        public SuppliersSearchViewModel()
            : base()
        {

        }

        #region Public Properties

        private string _companyNameFilter = string.Empty;
        public string CompanyNameFilter
        {
            get { return _companyNameFilter; }
            set { Set(() => CompanyNameFilter, ref _companyNameFilter, value); }
        }

        private string _addressFilter = string.Empty;
        public string AddressFilter
        {
            get { return _addressFilter; }
            set { Set(() => AddressFilter, ref _addressFilter, value); }
        }

        private string _contactNameFilter = string.Empty;
        public string ContactNameFilter
        {
            get { return _contactNameFilter; }
            set { Set(() => ContactNameFilter, ref _contactNameFilter, value); }
        }

        private string _cityFilter = string.Empty;
        public string CityFilter
        {
            get { return _cityFilter; }
            set { Set(() => CityFilter, ref _cityFilter, value); }
        }

        private string _contactTitleFilter = string.Empty;
        public string ContactTitleFilter
        {
            get { return _contactTitleFilter; }
            set { Set(() => ContactTitleFilter, ref _contactTitleFilter, value); }
        }

        private string _regionFilter = string.Empty;
        public string RegionFilter
        {
            get { return _regionFilter; }
            set { Set(() => RegionFilter, ref _regionFilter, value); }
        }

        private string _countryFilter = string.Empty;
        public string CountryFilter
        {
            get { return _countryFilter; }
            set { Set(() => CountryFilter, ref _countryFilter, value); }
        }

        private string _phoneFilter = string.Empty;
        public string PhoneFilter
        {
            get { return _phoneFilter; }
            set { Set(() => PhoneFilter, ref _phoneFilter, value); }
        }
        #endregion
        public override System.Linq.Expressions.Expression<Func<Supplier, bool>> GetSearchCriteria()
        {
            return (supplier => (string.IsNullOrEmpty(_companyNameFilter) || supplier.CompanyName.ToLower().Contains(_companyNameFilter.ToLower())) &&
                                (string.IsNullOrEmpty(_addressFilter) || supplier.Address.ToLower().Contains(_addressFilter.ToLower())) &&
                                (string.IsNullOrEmpty(_cityFilter) || supplier.City.ToLower().Contains(_cityFilter.ToLower())) &&
                                (string.IsNullOrEmpty(_regionFilter) || supplier.Region.ToLower().Contains(_regionFilter.ToLower())) &&
                                (string.IsNullOrEmpty(_countryFilter) || supplier.Country.ToLower().Contains(_countryFilter.ToLower())) &&
                                (string.IsNullOrEmpty(_phoneFilter) || supplier.Phone.ToLower().Contains(_phoneFilter.ToLower())) &&
                                (string.IsNullOrEmpty(_contactNameFilter) || supplier.ContactName.ToLower().Contains(_contactNameFilter.ToLower())) &&
                                (string.IsNullOrEmpty(_contactTitleFilter) || supplier.ContactTitle.ToLower().Contains(_contactTitleFilter.ToLower())));
        }

        public override void ResetSearchCriteria()
        {
            CompanyNameFilter = string.Empty;
            AddressFilter = string.Empty;
            CityFilter = string.Empty;
            RegionFilter = string.Empty;
            CountryFilter = string.Empty;
            PhoneFilter = string.Empty;
            ContactTitleFilter = string.Empty;
            ContactNameFilter = string.Empty;
        }
    }
}

using GenericCodes.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.DAL.Models
{
   
    public partial class Product : Entity
    {
        public Product()
        {
            Order_Details = new HashSet<Order_Detail>();
        }

        public int ProductID { get; set; }

        private string _productName;
        [Required]
        [StringLength(40)]
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int? _supplierID;
        public int? SupplierID
        {
            get { return _supplierID; }
            set
            {
                if (_supplierID != value)
                {
                    _supplierID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int? _categoryID;
        public int? CategoryID
        {
            get { return _categoryID; }
            set
            {
                if (_categoryID != value)
                {
                    _categoryID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        private short? _unitsInStock;
        public short? UnitsInStock
        {
            get { return _unitsInStock; }
            set
            {
                if (_unitsInStock != value)
                {
                    _unitsInStock = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        private Category _category;
        public virtual Category Category
        {
            get { return _category; }
            set
            {
                _category = value;
                NotifyPropertyChanged();
            }
        }

        public virtual ICollection<Order_Detail> Order_Details { get; set; }

        private Supplier _supplier;
        public virtual Supplier Supplier
        {
            get { return _supplier; }
            set
            {
                _supplier = value;
                NotifyPropertyChanged();
            }
        }
    }
}

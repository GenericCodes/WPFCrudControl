using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenericCodes.Core.Entities;
using PropertyChanged;

namespace Northwind.DAL.Models
{
    [ImplementPropertyChanged]
    public partial class Supplier: Entity
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(30)]
        [Required]
        public string ContactName { get; set; }

        [StringLength(30)]
        public string ContactTitle { get; set; }

        [StringLength(60)]
        [Required]
        public string Address { get; set; }

        [StringLength(15)]
        [Required]
        public string City { get; set; }

        [StringLength(15)]
        
        public string Region { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(15)]
        [Required]
        public string Country { get; set; }

        [StringLength(24)]
        [Required]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [Column(TypeName = "ntext")]
        public string HomePage { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

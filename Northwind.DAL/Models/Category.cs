using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenericCodes.Core;
using GenericCodes.Core.Entities;

namespace Northwind.DAL.Models
{
    public partial class Category : GenericCodes.Core.Entities.Entity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

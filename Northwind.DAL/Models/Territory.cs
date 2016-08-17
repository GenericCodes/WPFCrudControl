using System.ComponentModel.DataAnnotations;

namespace Northwind.DAL.Models
{
    public partial class Territory
    {
        [StringLength(20)]
        public string TerritoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }

        public virtual Region Region { get; set; }
    }
}

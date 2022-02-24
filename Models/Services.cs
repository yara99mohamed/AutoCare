using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models
{
    public class Services
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "The Details Is Required.")]
        [Column(TypeName = "nvarchar(200)")]
        [DisplayName("Services Description")]
        public String Details { get; set; }

        [Required(ErrorMessage = "The Price Is Required.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }  

        [DisplayName("Price Of Points")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PriceInPoints { get; set; } 

        [DisplayName("Earned Points")]
        public int? EarnedPoints { get; set; }

        public ICollection<CheckUpsServices> CarCheckUpsServicese { get; set; }

        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

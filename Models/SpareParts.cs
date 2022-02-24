using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models
{
    public class SpareParts
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Details IS Required.")]
        [Column(TypeName = "nvarchar(200)")]
        public String Details { get; set; }

        [Required(ErrorMessage = "The Price Is Required.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int? points { get; set; }   

        public ICollection<CheckUpsSpareParts> CarCheckUpsSparePart { get; set; }

        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

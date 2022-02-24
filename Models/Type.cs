using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models
{
    public class Type
    {
      [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "The Type Of Car Is Required.")]
        [MaxLength(20, ErrorMessage = "Maximum 20 characters only")]
        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Type Car")]
        public String Name { get; set; }

        public ICollection<Car> car { get; set; }

        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

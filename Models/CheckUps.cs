using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models
{
    public class CheckUps
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage ="The Counter Is Required.")]
        public int Counter { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArriveDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LeaveDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost{ get; set; } 
        public int TotalPoints { get; set; }  

        public Car car { get; set; }
        [ForeignKey("car")]
        [DisplayName("Car Id")]
        public long? CarId { get; set; }


        public ICollection<CheckUpsServices> CarCheckUpsServicese { get; set; }
        public ICollection<CheckUpsSpareParts> CarCheckUpsSparePart { get; set; }

        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

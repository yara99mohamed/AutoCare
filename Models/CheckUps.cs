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
        //Add Display fOR Arrive Date
        [Display(Name = "Arrive Date")]
        public DateTime ArriveDate { get; set; }

        [DataType(DataType.Date)]
        //Add Display fOR Leaeve Date
        [Display(Name = "Leave Date")]
        public DateTime LeaveDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        //Add Display fOR Total Cost
        [Display(Name = "Total Cost")]
        public decimal TotalCost{ get; set; }

        //Add Display fOR Total Points
        [Display(Name = "Total Points")]
        public int TotalPoints { get; set; }  

        public Car car { get; set; }
        [ForeignKey("car")]
        //Add Display fOR Car Numbers
        [Display(Name = "Car Numbers")]
        public long? CarId { get; set; }


        public ICollection<CheckUpsServices> CarCheckUpsServicese { get; set; }
        public ICollection<CheckUpsSpareParts> CarCheckUpsSparePart { get; set; }

        //delete is Active 
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.ViewModels
{
    public class CheckUpsViewModel
    {
        [Required(ErrorMessage = "The Counter Is Required.")]
        public int Counter { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArriveDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LeaveDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost { get; set; }

        public int TotalPoints { get; set; }

        [ForeignKey("car")]
        [DisplayName("Car")]
        public long? CarId { get; set; }
    }
}

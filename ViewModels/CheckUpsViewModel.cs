using AutoCare.Models;
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
        [Display(Name = "Arrive Date")]
        public DateTime ArriveDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Leave Date")]
        public DateTime LeaveDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name ="Total Cost")]
        public decimal TotalCost { get; set; }

        [Display(Name = "Total Points")]
        public int TotalPoints { get; set; }

        [ForeignKey("car")]
        [Display(Name = "Car Numbers")]
        public long? CarId { get; set; }

        public List<Car> Cars { get; set; }
    }
}

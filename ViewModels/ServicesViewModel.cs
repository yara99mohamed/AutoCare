using AutoCare.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.ViewModels
{
    public class ServicesViewModel
    {
        public long Id { get; set; }
        
        [Required(ErrorMessage = "The Details Is Required.")]
        
        public String Details { get; set; }

        [Required(ErrorMessage = "The Price Is Required.")]
        public decimal Price { get; set; }

        public decimal? PriceInPoints { get; set; }

        public int? EarnedPoints { get; set; }

        public ICollection<CheckUpsServices> CarCheckUpsServicese { get; set; }

        //delete is Active 
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

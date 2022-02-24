using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.ViewModels
{
    public class TypeViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The Type Of Car Is Required.")]
        [MaxLength(20, ErrorMessage = "Maximum 20 characters only")]
        [DisplayName("Car Type")]
        public String Name { get; set; }
    }
}

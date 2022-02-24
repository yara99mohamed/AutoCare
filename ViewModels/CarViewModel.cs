using Models= AutoCare.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using  System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace AutoCare.ViewModels
{
    public class CarViewModel
    {

        public int Id { get; set; }
        [DisplayName("Car Numbers")]
        [Required(ErrorMessage = "The Car Number is required.")]
        public int CarNumber { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Car Letters")]
        [Required(ErrorMessage = "The Car Letter is required.")]
        [MinLength(3, ErrorMessage = "Pleaze Enter 3 Letters Only.")]
        [StringLength(3, ErrorMessage = "Pleaze Enter 3 Letters Only.")]
        public String CarLetter { get; set; }

        [DisplayName("Car Model")]
        [Required(ErrorMessage = "The Car Model Is Required.")]
        public int CarModel { get; set; }

        [DisplayName("User")]
        [Required(ErrorMessage = "The User Is Required.")]
        public long? UserId { get; set; }


        [Required(ErrorMessage = "The Type Is Required.")]
        [DisplayName("Type")]
        public long? TypeId { get; set; }

        public IEnumerable<Models.User> Users { get; set; }

       public IEnumerable<Models.Type> types { get; set; }
    }
}

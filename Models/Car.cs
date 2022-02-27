using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("Car Number")]
        [Required(ErrorMessage = "The Car Number is required.")]
       
        public int CarNumber { get; set; } 

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Car Letter")]
        [Required(ErrorMessage = "The Car Letter is required.")]
        [MinLength(3, ErrorMessage = "Pleaze Enter 3 Letters Only.")]
        [MaxLength(3, ErrorMessage = "Pleaze Enter 3 Letters Only.")]
        public String CarLetter { get; set; }

        [DisplayName("Car Model")]
        [Required(ErrorMessage = "The Car Model Is Required.")]        
        public int CarModel { get; set; } 

        public User user { get; set; }
        [ForeignKey("user")]
        [Required(ErrorMessage = "The User Id Is Required.")]
        [DisplayName("User")]
        public long? UserId { get; set; }  

        public Type type { get; set; }
        [ForeignKey("type")]
        [Required(ErrorMessage = "The Type Id Is Required.")]
        [DisplayName("Type")]
        public long? TypeId { get; set; }

        public ICollection<CheckUps> CarCheckUps { get; set; }

        //delete is Active 
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

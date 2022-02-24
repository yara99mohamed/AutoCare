using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models
{
    public class UserAddress
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Address Is Required.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters only")]  
        [Column(TypeName="nvarchar(50)")]
        public String Address { get; set; }

        [Required(ErrorMessage = "City Is Required.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters only")]
        [Column(TypeName = "nvarchar(50)")]
        public String City { get; set; }

        [Required(ErrorMessage = "Providence Is Required.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters only")]
        [Column(TypeName = "nvarchar(50)")]
        public String Providence { get; set; }

        public User user { get; set; }
        [ForeignKey("user")]
        [DisplayName("User Id")]
        public long? UserId { get; set; }

        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }      
    }
}

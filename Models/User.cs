using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("First Name")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only")]
        public String FirstName { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only")]
        public String LastName { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "This Field is required.")]
        public long Mobile{ get; set; }

        [DisplayName("National Id Number")]
        [Required(ErrorMessage = "The National Id Number is required.")]
        public long NationalIdNumber { get; set; }

        [Required(ErrorMessage = "Email Is Required .")]
        [Display(Name = "Email address")]
        [StringLength(40, ErrorMessage = "Email Must Be Less Than 40 Character & Numbers .")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Column(TypeName = "nvarchar(40)")]
        public String Email { get; set; }


        [Required(ErrorMessage = "PassWord Is Required.")]
        [MinLength(8, ErrorMessage = "PassWord Must Be More Than 8 Character Or Numbers.")]
        [StringLength(20, ErrorMessage = "PassWord Must Be Less Than 20 Character Or Numbers.")]
        [Column(TypeName = "nvarchar(20)")]
        [DataType(DataType.Password)]
        public String Password { get; set; }  

        public int? Points { get; set; }            

        public Role role { get; set; }
        [ForeignKey("role")]
        [DisplayName("Role Id")]
        public long? RolerId { get; set; }
        public ICollection<UserAddress> address { get; set; }
        public ICollection<Car> car { get; set; }

        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models
{
    public class Role
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name Roles Is Required.")]
        [Column(TypeName = "nvarchar(30)")]
        [StringLength(30, ErrorMessage = "Name Roles Must Be Less Than 30 Character .")]
        [DisplayName("Name Roles")]
        public String Name { get; set; }

        public ICollection<User> user { get; set; }

        //delete is Active 
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

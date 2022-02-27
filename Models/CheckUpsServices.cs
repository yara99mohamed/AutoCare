using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models
{
    public class CheckUpsServices
    {
        [Key]
        public long Id { get; set; }

        public CheckUps CarCheckUps { get; set; }
        [ForeignKey("CarCheckUps")]
        [DisplayName("Check Ups Id")]
        public long? CheckUpsId { get; set; }

        public Services CarService { get; set; }
        [ForeignKey("Services")]
        [DisplayName("Services")]
        public long? ServicesId { get; set; }

        //delete is Active 
        public string  CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

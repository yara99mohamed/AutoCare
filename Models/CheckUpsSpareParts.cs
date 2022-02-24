using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models
{
    public class CheckUpsSpareParts
    {
        [Key]
        public long Id { get; set; }

        public CheckUps CarCheckUps { get; set; }
        [ForeignKey("CarCheckUps")]
        [DisplayName("Check Ups")]
        public long? CheckUpsId { get; set; }

        public SpareParts CarSparePart { get; set; }
        [ForeignKey("CarSparePart")]
        [DisplayName("SpareParts")]
        public int? SparePartsId { get; set; }

        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

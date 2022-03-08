using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.ViewModels
{
    public class CheckUpsSparePartsViewModel
    {

        public long Id { get; set; }


        public long? CheckUpsId { get; set; }


        public int? SparePartsId { get; set; }

        public IEnumerable<Models.CheckUps> CheckUps { get; set; }

        public IEnumerable<Models.SpareParts> SpareParts { get; set; }


    }
}

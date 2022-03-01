using AutoCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.ViewModels
{
    public class CheckUpsServicesViewModel
    {
        public long Id { get; set; }

        
        public long? CheckUpsId { get; set; }

       
        public long? ServicesId { get; set; }

        public IEnumerable<Models.CheckUps> CheckUps { get; set; }

        public IEnumerable<Models.Services> Services { get; set; }
    }
}

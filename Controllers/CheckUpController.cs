using AutoCare.Models;
using AutoCare.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Controllers
{
    public class CheckUpController : Controller
    {
        private readonly IAutoRepository<CheckUps> _AutoCheckUpsRepository;
        public CheckUpController(IAutoRepository<CheckUps> context)
        {
            _AutoCheckUpsRepository = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _AutoCheckUpsRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    if(!ModelState.IsValid)
        //    {

        //    }
        //    return View();
        //}
    }
}

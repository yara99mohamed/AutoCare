using AutoCare.Models;
using AutoCare.Models.Repository;
using AutoCare.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IAutoRepository<Services> _services;
        private readonly IToastNotification _ToastNotification;
        public ServicesController(IAutoRepository<Services> services,
            IToastNotification ToastNotification)
        {
            _services = services;
            _ToastNotification = ToastNotification; 
        }


        public async Task<IActionResult> Index()
        {
            return View(await _services.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServicesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Servicesmodel = new Services()
                    {
                        Details = model.Details ,
                        Price = model.Price ,
                        PriceInPoints = model.PriceInPoints,
                        EarnedPoints = model.EarnedPoints,
                        CreateOn =model.CreateOn ,
                        ModifiedOn =model.ModifiedOn 
                    };  
                    _services.Add(Servicesmodel);
                    return RedirectToAction("Index", "Services");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(model);
            }


        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var service =await _services.Get(id);
            var ServicesEdit = new ServicesViewModel
            {
                Details = service.Details,
                Price = service.Price,
                PriceInPoints = service.PriceInPoints,
                EarnedPoints = service.EarnedPoints,
                
            };
            
            return View(ServicesEdit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,ServicesViewModel servicesView)
        {

            if (!ModelState.IsValid)
            {
                return View(servicesView);
            }
            var EditCarModel = await _services.Get(id);
            if (EditCarModel == null)
            {
                return NotFound();
            }
            var servicesModel = new Services
            {
               Details = servicesView.Details,
               Price = servicesView.Price,
               PriceInPoints = servicesView.PriceInPoints,
               EarnedPoints = servicesView.EarnedPoints
            };
            var result = await _services.Update(id, servicesModel);
            if (result > 0)
            {
                _ToastNotification.AddSuccessToastMessage("service Update Successfully!");
                return RedirectToAction("Index");
            }
            else
            {
                _ToastNotification.AddSuccessToastMessage("service Update Failed!");
                return View(servicesView);
            }
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var Deleteservice = await _services.Get(id);
            if (Deleteservice == null)
            {
                return NotFound();
            }
            var result = await _services.Delete(Deleteservice);
            if (result > 0)
            {
                _ToastNotification.AddAlertToastMessage("service Deleted!");
                return RedirectToAction("Index");
            }
            else
            {
                _ToastNotification.AddAlertToastMessage("Somthing Want Wrong!");
                return RedirectToAction("Index");
            }
        }


    }
}

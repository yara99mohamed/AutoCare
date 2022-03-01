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
    public class CheckUpsServicesController : Controller
    {
        private readonly IAutoRepository<CheckUpsServices> _CheckUpsServices;
        private readonly IAutoRepository<Services> _AutoServicesRepository;
        private readonly IAutoRepository<CheckUps> _AutoCheckUpsRepository;
        private readonly IToastNotification _ToastNotification;
        public CheckUpsServicesController(IAutoRepository<CheckUpsServices> checkUpsServices,
            IToastNotification ToastNotification,
            IAutoRepository<Services> AutoServicesRepository
            , IAutoRepository<CheckUps> AutoCheckUpsRepository)
        {
            _CheckUpsServices = checkUpsServices;
            _ToastNotification = ToastNotification;
            _AutoServicesRepository = AutoServicesRepository;
            _AutoCheckUpsRepository = AutoCheckUpsRepository;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _CheckUpsServices.GetAll());
        }

        public async Task<IActionResult> Create()
        {

            var data = new CheckUpsServicesViewModel
            {
                CheckUps = await _AutoCheckUpsRepository.GetAll(),
                Services = await _AutoServicesRepository.GetAll()
            };

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CheckUpsServicesViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.CheckUps = await _AutoCheckUpsRepository.GetAll();
                model.Services = await _AutoServicesRepository.GetAll();
                return View(model);
            }


            var checkupsServicesModel = new CheckUpsServices
            {
                CheckUpsId = model.CheckUpsId,
                ServicesId = model.ServicesId
            };
            var result = await _CheckUpsServices.Add(checkupsServicesModel);
            if (result > 0)
            {
                _ToastNotification.AddSuccessToastMessage("checkupsServices Created Successfully!");
                return RedirectToAction("Index");
            }


            else
            {
                _ToastNotification.AddSuccessToastMessage("checkupsServices Created Falied!");
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var checkUpsServices = await _CheckUpsServices.Get(id);
            if (checkUpsServices == null)
            {
                return NotFound();
            }
            var checkUpsServicesEdit = new CheckUpsServicesViewModel
            {
                
                CheckUpsId = checkUpsServices.CheckUpsId ,
                ServicesId = checkUpsServices.ServicesId ,
                CheckUps = await _AutoCheckUpsRepository.GetAll(),
                Services = await _AutoServicesRepository.GetAll()
            };
            
            return View(checkUpsServicesEdit);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, CheckUpsServicesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CheckUps = await _AutoCheckUpsRepository.GetAll();
                model.Services = await _AutoServicesRepository.GetAll();
                return View(model);
            }
            var EditcheckUpsServicesModel = await _CheckUpsServices.Get(id);
            if (EditcheckUpsServicesModel == null)
            {
                return NotFound();
            }

            var checkUpsServices = new CheckUpsServices
            {
               CheckUpsId = model.CheckUpsId,
               ServicesId = model.ServicesId
            };
            // ViewBag.id = id;
            var result = await _CheckUpsServices.Update(id, checkUpsServices);
            if (result > 0)
            {
                _ToastNotification.AddSuccessToastMessage("CheckUpsServices Update Successfully!");
                return RedirectToAction("Index");
            }
            
            else
            {
                model.CheckUps = await _AutoCheckUpsRepository.GetAll();
                model.Services = await _AutoServicesRepository.GetAll();
                _ToastNotification.AddSuccessToastMessage("CheckUpsServices Update Failed!");
                return View(model);
            }
        }



        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var DeletecheckUpsServices = await _CheckUpsServices.Get(id);
            if (DeletecheckUpsServices == null)
            {
                return NotFound();
            }
            var result = await _CheckUpsServices.Delete(DeletecheckUpsServices);
            if (result > 0)
            {
                _ToastNotification.AddAlertToastMessage("checkUpsServices Deleted!");
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



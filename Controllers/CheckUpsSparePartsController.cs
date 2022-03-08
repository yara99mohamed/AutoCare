using AutoCare.Models;
using AutoCare.Models.Repository;
using AutoCare.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Controllers
{
    public class CheckUpsSparePartsController : Controller
    {
        private readonly IAutoRepository<SpareParts> _autoSparePartsRepository;
        private readonly IAutoRepository<CheckUpsSpareParts> _checkUpsSpareParts;
        private readonly IToastNotification _toastNotification;
        private readonly IAutoRepository<CheckUps> _autoCheckUpsRepository;
       

        public CheckUpsSparePartsController(IAutoRepository<SpareParts> AutoSparePartsRepository,
            IAutoRepository<CheckUpsSpareParts> checkUpsSpareParts,
            IToastNotification ToastNotification,
            IAutoRepository<CheckUps> _AutoCheckUpsRepository)
        {
            _autoSparePartsRepository = AutoSparePartsRepository;
            _checkUpsSpareParts = checkUpsSpareParts;
            _toastNotification = ToastNotification;
            _autoCheckUpsRepository = _AutoCheckUpsRepository;
           
        }

        public async Task<IActionResult> Index()
        {
            return View(await _checkUpsSpareParts.GetAll());
        }

         public async Task<IActionResult> Create()
        {

            var data = new CheckUpsSparePartsViewModel
            {
                CheckUps = await _autoCheckUpsRepository.GetAll(),
                SpareParts = await _autoSparePartsRepository.GetAll()
            };

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CheckUpsSparePartsViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.CheckUps = await _autoCheckUpsRepository.GetAll();
                model.SpareParts = await _autoSparePartsRepository.GetAll();
                return View(model);
            }


            var checkupsSparePartsModel = new CheckUpsSpareParts
            {
                CheckUpsId = model.CheckUpsId,
                SparePartsId = model.SparePartsId
            };
            var result = await _checkUpsSpareParts.Add(checkupsSparePartsModel);
            if (result > 0)
            {
                _toastNotification.AddSuccessToastMessage("checkupsSpareParts Created Successfully!");
                return RedirectToAction("Index");
            }


            else
            {
                _toastNotification.AddSuccessToastMessage("checkupsSpareParts Created Falied!");
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
            var checkUpsSpareparts = await _checkUpsSpareParts.Get(id);
            if (checkUpsSpareparts == null)
            {
                return NotFound();
            }
            var checkUpsSparePartsEdit = new CheckUpsSparePartsViewModel
            {

                CheckUpsId = checkUpsSpareparts.CheckUpsId,
                SparePartsId = checkUpsSpareparts.SparePartsId,

                CheckUps = await _autoCheckUpsRepository.GetAll(),
                SpareParts = await _autoSparePartsRepository.GetAll()
            };

            return View(checkUpsSparePartsEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, CheckUpsSparePartsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CheckUps = await _autoCheckUpsRepository.GetAll();
                model.SpareParts = await _autoSparePartsRepository.GetAll();
                return View(model);
            }
            var EditcheckUpsSparePartsModel = await _checkUpsSpareParts.Get(id);
            if (EditcheckUpsSparePartsModel == null)
            {
                return NotFound();
            }

            var checkUpsSpareParts = new CheckUpsSpareParts
            {
                CheckUpsId = model.CheckUpsId,
                SparePartsId = model.SparePartsId
            };

            var result = await _checkUpsSpareParts.Update(id, checkUpsSpareParts);
            if (result > 0)
            {
                _toastNotification.AddSuccessToastMessage("checkUpsSpareParts Update Successfully!");
                return RedirectToAction("Index");
            }

            else
            {
                model.CheckUps = await _autoCheckUpsRepository.GetAll();
                model.SpareParts = await _autoSparePartsRepository.GetAll();
                _toastNotification.AddSuccessToastMessage("checkUpsSpareParts Update Failed!");
                return View(model);
            }
        }


        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var DeletecheckUpsSpareParts = await _checkUpsSpareParts.Get(id);
            if (DeletecheckUpsSpareParts == null)
            {
                return NotFound();
            }
            var result = await _checkUpsSpareParts.Delete(DeletecheckUpsSpareParts);
            if (result > 0)
            {
                _toastNotification.AddAlertToastMessage("checkUpsSpareParts Deleted!");
                return RedirectToAction("Index");
            }
            else
            {
                _toastNotification.AddAlertToastMessage("Somthing Want Wrong!");
                return RedirectToAction("Index");
            }
        }

    }
}

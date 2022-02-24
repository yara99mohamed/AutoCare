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
    public class TypeController : Controller
    {
        private readonly IAutoRepository<Models.Type> _AutoTypeRepository;
        private readonly IToastNotification _ToastNotification;
        public TypeController(IAutoRepository<Models.Type> Context, IToastNotification ToastNotification)
        {
            _AutoTypeRepository = Context;
            _ToastNotification = ToastNotification;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _AutoTypeRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var ConvertDataFromViewModelToModel = new TypeViewModel();
            return View(ConvertDataFromViewModelToModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypeViewModel type)
        {
            if (!ModelState.Any())
            {
                return View();
            }
            var ConvertDataFromViewModelToModel = new Models.Type
            {
                Name = type.Name,
            };
            var Result = await _AutoTypeRepository.Add(ConvertDataFromViewModelToModel);
            if (Result > 0)
            {
                _ToastNotification.AddSuccessToastMessage("Type Created Successfully!");
                return RedirectToAction("Index");
            }
            else if (Result == -1)
            {
                ModelState.AddModelError("Name", "The Type Aleardy Exist!");
                return View();
            }
            else
            {
                _ToastNotification.AddSuccessToastMessage("Type Created Failed!");
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var type = await _AutoTypeRepository.Get(id);
            if (type == null)
            {
                return NotFound();
            }
            var result = new TypeViewModel
            {
                Name = type.Name
            };
            return View(result);      
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id ,TypeViewModel type )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var EditType = await _AutoTypeRepository.Get(id);
            if (EditType == null)
            {
                return NotFound();
            }

            var ConvertDataFromViewModelToModel = new Models.Type
            {
                Name=type.Name
            };
            var result = await _AutoTypeRepository.Update(id, ConvertDataFromViewModelToModel);
            if(result>0)
            {
                return RedirectToAction("Index");
            }
            else if(result==-1)
            {
                ModelState.AddModelError("Name", "This Type Already exist!");
                return View(result);
            }
            return View(result);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if(id==null)
            {
                return BadRequest();
            }
            var DeleteType = await _AutoTypeRepository.Get(id);
            if(DeleteType == null)
            {
                return NotFound();
            }

            var result = await _AutoTypeRepository.Delete(DeleteType);
            if(result>0)
            {
                _ToastNotification.AddSuccessToastMessage("Type Deleted Successfully!");
                return RedirectToAction("Index");
            }
            else
            _ToastNotification.AddSuccessToastMessage("Type Deleted Falied!");
            return RedirectToAction("Index");
        }
    }
}
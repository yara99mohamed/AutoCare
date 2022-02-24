using AutoCare.Models;
using AutoCare.Models.Repository;
using AutoCare.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Controllers
{
    public class CarController : Controller
    {
        private readonly IAutoRepository<Car> _AutoCarRepository;
        private readonly IAutoRepository<User> _AutoUserRepository;
        private readonly IAutoRepository<Models.Type> _AutoTypeRepository;
        private readonly IToastNotification _ToastNotification;
        public CarController(IAutoRepository<Car> AutoCarRepository , IAutoRepository<User> AutoUserRepository, IAutoRepository<Models.Type> AutoTypeRepository, IToastNotification ToastNotification)
        {
            _AutoCarRepository = AutoCarRepository;
            _AutoUserRepository = AutoUserRepository;
            _AutoTypeRepository = AutoTypeRepository;
            _ToastNotification = ToastNotification;
        }
        public async Task<IActionResult> Index()
            {
              return View(await _AutoCarRepository.GetAll());
            }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CarOwner = new CarViewModel
            {
                Users = await _AutoUserRepository.GetAll(),
                types = await _AutoTypeRepository.GetAll()
            };

            return View(CarOwner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarViewModel CarView)
        {

            if (!ModelState.IsValid)
            {
                CarView.Users =await _AutoUserRepository.GetAll();
                CarView.types =await _AutoTypeRepository.GetAll();
                return View(CarView);
            }
            
            if (!(CarView.CarNumber.ToString().Length == 3))
            {
                CarView.Users =await _AutoUserRepository.GetAll();
                CarView.types =await _AutoTypeRepository.GetAll();
                ModelState.AddModelError("CarNumber", "Please Enter 3 Numbers! ");               
                return View(CarView);
            }

            var CarModelClass = new Car
            {                
                CarLetter = CarView.CarLetter,
                CarModel = CarView.CarModel,
                CarNumber = CarView.CarNumber,
                UserId = CarView.UserId,
                TypeId = CarView.TypeId
            };
            var result=await _AutoCarRepository.Add(CarModelClass);
            if (result > 0)
            {               
                _ToastNotification.AddSuccessToastMessage("Car Created Successfully!");
                return RedirectToAction("Index");               
            }
            else if (result == -1)
            {
                CarView.Users = await _AutoUserRepository.GetAll();
                CarView.types = await _AutoTypeRepository.GetAll();
                ModelState.AddModelError("CarNumber", "This Numbers  Already exists ");
                ModelState.AddModelError("CarLetter", "This Letters Already exists ");

                return View(CarView);
            }
            else
            {
                _ToastNotification.AddSuccessToastMessage("Car Created Falied!");
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var DeleteCar = await _AutoCarRepository.Get(id);
            if (DeleteCar == null)
            {
                return NotFound();
            }
            var result = await _AutoCarRepository.Delete(DeleteCar);
            if (result > 0)
            {
                _ToastNotification.AddAlertToastMessage("Car Deleted!");
                return RedirectToAction("Index");
            }
            else
            {
                _ToastNotification.AddAlertToastMessage("Somthing Want Wrong!");
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
            var Car = await _AutoCarRepository.Get(id);
            if (Car == null)
            {
                return NotFound();
            }
            var CarEdit = new CarViewModel
            {
                CarLetter = Car.CarLetter,
                CarModel = Car.CarModel,
                CarNumber = Car.CarNumber,
                TypeId = Car.TypeId,
                UserId = Car.UserId,
                types = await _AutoTypeRepository.GetAll(),
                Users = await _AutoUserRepository.GetAll()
            };
         //   ViewBag.id = id;
            return View(CarEdit);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(long id, CarViewModel CarView)
            {
                if (!ModelState.IsValid)
                {
                    CarView.Users = await _AutoUserRepository.GetAll();
                    CarView.types = await _AutoTypeRepository.GetAll();
                    return View(CarView);
                }
                var EditCarModel = await _AutoCarRepository.Get(id);
                if (EditCarModel == null)
                {
                    return NotFound();
                }

                if (!(CarView.CarNumber.ToString().Length == 3))
                {
                    CarView.Users = await _AutoUserRepository.GetAll();
                    CarView.types = await _AutoTypeRepository.GetAll();
                    ModelState.AddModelError("CarNumber", "Please Enter 3 Numbers! ");
                    return View(CarView);
                }

                var CarModel = new Car
                    {
                        CarLetter = CarView.CarLetter,
                        CarNumber = CarView.CarNumber,
                        CarModel = CarView.CarModel,
                        UserId = CarView.UserId,
                        TypeId = CarView.TypeId,
                    };
               // ViewBag.id = id;
                var result = await _AutoCarRepository.Update(id, CarModel);
                if (result > 0)
                    {
                           _ToastNotification.AddSuccessToastMessage("Car Update Successfully!");
                            return RedirectToAction("Index");
                    }
                else if (result == -1)
                {
                    CarView.Users = await _AutoUserRepository.GetAll();
                    CarView.types = await _AutoTypeRepository.GetAll();
                    ModelState.AddModelError("CarNumber", "This Numbers  Already exists ");
                    ModelState.AddModelError("CarLetter", "This Letters Already exists ");
                    return View(CarView);
                }
                else
                    {
                        CarView.Users = await _AutoUserRepository.GetAll();
                        CarView.types = await _AutoTypeRepository.GetAll();
                    _ToastNotification.AddSuccessToastMessage("Car Update Failed!");
                    return View(CarView);
                    }               
            }
    }
}

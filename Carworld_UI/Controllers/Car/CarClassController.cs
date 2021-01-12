using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carworld.Models;
using Carworld_Logic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Carworld.Controllers
{
    [Authorize]
    public class CarClassController : Controller
    {
        //Methods
        private List<CarClassModel> GetAllCarClasses()
        {
            List<CarClassModel> carClasses = new List<CarClassModel>();

            foreach (var carClass in new CarClassCollection().GetAll())
            {
                carClasses.Add(new CarClassModel()
                {
                    Id = carClass.Id,
                    Name = carClass.Name,
                });
            }
            return carClasses;
        }

        private CarClassModel GetCarClass(int carClassId)
        {
            CarClass databaseCarClass = new CarClassCollection().Get(carClassId);
            CarClassModel carClass = new CarClassModel()
            {
                Id = databaseCarClass.Id,
                Name = databaseCarClass.Name
            };
            return carClass;
        }

        private bool CreateCarClass(CarClassModel carClass)
        {
            CarClass carClassObject = new CarClass()
            {
                Name = carClass.Name
            };

            return new CarClassCollection().Create(carClassObject);
        }

        private bool UpdateCarClass(CarClassModel carClass)
        {
            CarClass databaseCarClass = new CarClassCollection().Get(carClass.Id);

            databaseCarClass.SetName(carClass.Name);

            return databaseCarClass.Update();
        }

        private bool DeleteCarClass(int carClassId)
        {
            return new CarClassCollection().Delete(carClassId);
        }
        //End methods

        public IActionResult Index()
        {
            return View(GetAllCarClasses());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarClassModel carClass)
        {
            if (CreateCarClass(carClass))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Edit(int carClassId)
        {
            return View(GetCarClass(carClassId));
        }

        [HttpPost]
        public IActionResult Edit(CarClassModel carClass)
        {
            if (UpdateCarClass(carClass))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Delete(int carClassId)
        {
            return View(GetCarClass(carClassId));
        }

        [HttpPost]
        public IActionResult Delete(CarClassModel carClass)
        {
            if (DeleteCarClass(carClass.Id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong deleting data from the server");
                return View(carClass);
            }
        }
    }
}

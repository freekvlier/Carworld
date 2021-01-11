using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carworld.Models;
using Logic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Carworld.Controllers
{
    public class CarClassController : Controller
    {
        //Methods
        private List<CarClassModel> getAllCarClasses()
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

        private bool createCarClass(CarClassModel carClass)
        {
            CarClass carClassObject = new CarClass()
            {
                Name = carClass.Name
            };

            if (new CarClassCollection().Create(carClassObject))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool updateCarClass(int carClassId, CarClassModel carClass)
        {
            CarClass databaseCarClass = new CarClassCollection().Get(carClassId);

            databaseCarClass.SetName(carClass.Name);

            if (databaseCarClass.Update())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool deleteCarClass(int carClassId)
        {
            return new CarClassCollection().Delete(carClassId);
        }
        //End methods

        public IActionResult Index()
        {
            return View(getAllCarClasses());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarClassModel carClass)
        {
            if (createCarClass(carClass))
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
        public IActionResult Edit(int carClassId, CarClassModel carClass)
        {
            if (updateCarClass(carClassId, carClass))
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
        public IActionResult Delete(int carClassId, CarClassModel carClass)
        {
            if (deleteCarClass(carClassId))
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

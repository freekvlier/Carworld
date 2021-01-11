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
        public IActionResult CarClasses()
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
            return View(carClasses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarClassModel carClass)
        {
            CarClass newCarClass = new CarClass()
            {
                Name = carClass.Name
            };

            if (new CarClassCollection().Create(newCarClass))
            {
                return RedirectToAction("CarClasses");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            CarClass databaseCarClass = new CarClassCollection().Get(id);
            CarClassModel carClass = new CarClassModel()
            {
                Id = databaseCarClass.Id,
                Name = databaseCarClass.Name
            };

            return View(carClass);
        }

        [HttpPost]
        public IActionResult Edit(int id, CarClassModel inputCarClass)
        {
            CarClass carClass = new CarClassCollection().Get(id);

            carClass.SetName(inputCarClass.Name);


            if (carClass.Update())
            {
                return RedirectToAction("CarClasses");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            CarClass databaseCarClass = new CarClassCollection().Get(id);
            CarClassModel carClass = new CarClassModel()
            {
                Id = databaseCarClass.Id,
                Name = databaseCarClass.Name,
            };
            return View(carClass);
        }

        [HttpPost]
        public IActionResult Delete(int id, CarClassModel carClass)
        {
            if (new CarClassCollection().Delete(id))
            {
                return RedirectToAction("CarClasses");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong deleting data from the server");
                return View(carClass);
            }
        }
    }
}

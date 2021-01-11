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
    public class FuelController : Controller
    {
        public IActionResult Fuel()
        {
            List<FuelModel> fuels = new List<FuelModel>();

            foreach (var fuel in new FuelCollection().GetAll())
            {
                fuels.Add(new FuelModel()
                {
                    Id = fuel.Id,
                    Name = fuel.Name,
                });
            }
            return View(fuels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FuelModel fuel)
        {
            Fuel newFuel = new Fuel()
            {
                Name = fuel.Name
            };

            if (new FuelCollection().Create(newFuel))
            {
                return RedirectToAction("Fuel");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            Fuel databaseFuel = new FuelCollection().Get(id);
            FuelModel fuel = new FuelModel()
            {
                Id = databaseFuel.Id,
                Name = databaseFuel.Name,
            };

            return View(fuel);
        }

        [HttpPost]
        public IActionResult Edit(int id, FuelModel inputFuel)
        {
            Fuel fuel = new FuelCollection().Get(id);

            fuel.SetName(inputFuel.Name);


            if (fuel.Update())
            {
                return RedirectToAction("Fuel");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            Fuel databaseFuel = new FuelCollection().Get(id);
            FuelModel fuel = new FuelModel()
            {
                Id = databaseFuel.Id,
                Name = databaseFuel.Name,
            };
            return View(fuel);
        }

        [HttpPost]
        public IActionResult Delete(int id, FuelModel fuel)
        {
            if (new FuelCollection().Delete(id))
            {
                return RedirectToAction("Fuel");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong deleting data from the server");
                return View(fuel);
            }
        }
    }
}

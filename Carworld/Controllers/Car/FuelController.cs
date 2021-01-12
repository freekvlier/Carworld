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
    [Authorize]
    public class FuelController : Controller
    {
        //Methods
        private List<FuelModel> getAllFuels()
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
            return fuels;
        }

        private FuelModel getFuel(int fuelId)
        {
            Fuel databaseFuel = new FuelCollection().Get(fuelId);
            FuelModel fuel = new FuelModel()
            {
                Id = databaseFuel.Id,
                Name = databaseFuel.Name,
            };
            return fuel;
        }

        private bool createFuel(FuelModel fuel)
        {
            Fuel fuelObject = new Fuel()
            {
                Name = fuel.Name
            };

            if (new FuelCollection().Create(fuelObject))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool updateFuel(FuelModel fuel)
        {
            Fuel fuelObject = new FuelCollection().Get(fuel.Id);

            fuelObject.SetName(fuel.Name);

            if (fuelObject.Update())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool deleteFuel(int fuelId)
        {
            return new FuelCollection().Delete(fuelId);
        }
        //End Methods

        public IActionResult Index()
        {
            return View(getAllFuels());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FuelModel fuel)
        {
            if (createFuel(fuel))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Edit(int fuelId)
        {
            return View(getFuel(fuelId));
        }

        [HttpPost]
        public IActionResult Edit(FuelModel fuel)
        {
            if (updateFuel(fuel))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Delete(int fuelId)
        {
            return View(getFuel(fuelId));
        }

        [HttpPost]
        public IActionResult Delete(FuelModel fuel)
        {
            if (deleteFuel(fuel.Id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong deleting data from the server");
                return View(fuel);
            }
        }
    }
}

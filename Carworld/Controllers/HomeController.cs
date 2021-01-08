using Carworld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace Carworld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Methods 
        private List<CarModel> getCars()
        {
            List<CarModel> cars = new List<CarModel>();

            foreach (Car car in new CarCollection().GetAll())
            {
                cars.Add(new CarModel
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    Year = car.Year,
                    Price = car.Price,
                    Horsepower = car.Horsepower,
                    Torque = car.Torque,
                    Acceleration = car.Acceleration,
                    Topspeed = car.Topspeed,
                    CarClass = car.CarClass,
                    Fuel = car.Fuel,
                    FuelConsumption = car.FuelConsumption,
                    MadeByUser = car.MadeByUser,
                    DisplayFuel = $"Het verbruik van {car.Fuel}: {car.FuelConsumption}"
                });
            }
            return cars;
        }

        private List<CarModel> getCarsSorted(string property)
        {
            List<CarModel> cars = new List<CarModel>();

            foreach (Car car in new CarCollection().GetAllSorted(property))
            {
                cars.Add(new CarModel
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    Year = car.Year,
                    Price = car.Price,
                    Horsepower = car.Horsepower,
                    Torque = car.Torque,
                    Acceleration = car.Acceleration,
                    Topspeed = car.Topspeed,
                    CarClass = car.CarClass,
                    Fuel = car.Fuel,
                    FuelConsumption = car.FuelConsumption,
                    MadeByUser = car.MadeByUser,
                    DisplayFuel = $"Het verbruik van {car.Fuel}: {car.FuelConsumption}"
                });
            }
            return cars;
        }

        public IActionResult Index()
        {
            return View(getCars());
        }

        [Route("/[action]")]
        public IActionResult Index(string sort)
        {
            switch (sort)
            {
                case "":
                    return View(getCars());
                case "Brand":
                    ViewBag.Filter = "Brand";
                    return View(getCarsSorted("Brand"));
                case "Price":
                    ViewBag.Filter = "Price";
                    return View(getCarsSorted("Price"));
                case "Horsepower":
                    ViewBag.Filter = "Horsepower";
                    return View(getCarsSorted("Horsepower"));
                case "Year":
                    ViewBag.Filter = "Year";
                    return View(getCarsSorted("Year"));
            }
            return View(getCars());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

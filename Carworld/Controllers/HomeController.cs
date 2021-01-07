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

        private CarModel getCar(int id)
        {
            Car getCar = new CarCollection().Get(id);
            CarModel car = new CarModel
            {
                Id = getCar.Id,
                Brand = getCar.Brand,
                Model = getCar.Model,
                Year = getCar.Year,
                Price = getCar.Price,
                Horsepower = getCar.Horsepower,
                Torque = getCar.Torque,
                Acceleration = getCar.Acceleration,
                Topspeed = getCar.Topspeed,
                CarClass = getCar.CarClass,
                Fuel = getCar.Fuel,
                FuelConsumption = getCar.FuelConsumption,
                MadeByUser = getCar.MadeByUser,
                DisplayFuel = $"Het verbruik van {getCar.Fuel}: {getCar.FuelConsumption}"
            };
            return car;
        }

        public IActionResult Index()
        {
            return View(getCars());
        }

        public IActionResult CarDetails(int id)
        {
            return View(getCar(id));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

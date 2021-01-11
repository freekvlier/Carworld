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
    public class SelectedCarController : Controller
    {
        private readonly IWebHostEnvironment envi;
        //Methods 
        private List<CarViewModel> getCars()
        {
            List<CarViewModel> cars = new List<CarViewModel>();

            foreach (Car car in new CarCollection().GetAll())
            {
                cars.Add(new CarViewModel
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
                    MadeByUser = new UserCollection().Get(car.MadeByUser).Username,
                    DisplayFuel = $"Het verbruik van {car.Fuel}: {car.FuelConsumption}"
                });
            }
            return cars;
        }

        private CarViewModel getCar(int id)
        {
            Car getCar = new CarCollection().Get(id);
            if (User.Identity.IsAuthenticated)
            {
                CarViewModel car = new CarViewModel
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
                    MadeByUser = new UserCollection().Get(getCar.MadeByUser).Username,
                    DisplayFuel = $"Het verbruik van {getCar.Fuel}: {getCar.FuelConsumption}",
                    Favorite = new FavoriteCollection().CheckFavorite((int)HttpContext.Session.GetInt32("UserId"), getCar.Id)
                };
                return car;
            }
            else
            {
                CarViewModel car = new CarViewModel
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
                    MadeByUser = new UserCollection().Get(getCar.MadeByUser).Username,
                    DisplayFuel = $"Het verbruik van {getCar.Fuel}: {getCar.FuelConsumption}",
                    Favorite = false
                };
                return car;
            }        
        }


        private List<BrandModel> GetBrands()
        {
            List<BrandModel> brands = new List<BrandModel>();

            foreach (var brand in new BrandCollection().GetAll())
            {
                brands.Add(new BrandModel { Id = brand.Id, Name = brand.Name, Origin = brand.Origin });
            }
            return brands;
        }

        private List<CarClassModel> GetCarClasses()
        {
            List<CarClassModel> carClasses = new List<CarClassModel>();

            foreach (var carClass in new CarClassCollection().GetAll())
            {
                carClasses.Add(new CarClassModel { Id = carClass.Id, Name = carClass.Name });
            }
            return carClasses;
        }

        private List<FuelModel> GetFuels()
        {
            List<FuelModel> fuels = new List<FuelModel>();

            foreach (var fuel in new FuelCollection().GetAll())
            {
                fuels.Add(new FuelModel { Id = fuel.Id, Name = fuel.Name });
            }
            return fuels;
        }

        public SelectedCarController(IWebHostEnvironment _environment)
        {
            envi = _environment;
        }
        //End methods


        [Route("/[action]")]
        public IActionResult CarDetails(int id)
        {
            return View(getCar(id));
        }

        [Authorize]
        [Route("/[action]")]
        public IActionResult Edit(int id)
        {
            ViewBag.Brands = GetBrands();
            ViewBag.Fuels = GetFuels();
            ViewBag.CarClasses = GetCarClasses();

            return View(getCar(id));
        }

        [Authorize]
        [HttpPost]
        [Route("/[action]")]
        public IActionResult Edit(int id, CarViewModel car)
        {
            ViewBag.Brands = GetBrands();
            ViewBag.Fuels = GetFuels();
            ViewBag.CarClasses = GetCarClasses();

            Car databaseCar = new CarCollection().Get(id);

            databaseCar.SetBrand(car.Brand);
            databaseCar.SetModel(car.Model);
            databaseCar.SetYear(car.Year);
            databaseCar.SetPrice(car.Price);
            databaseCar.SetHorsepower(car.Horsepower);
            databaseCar.SetTorque(car.Torque);
            databaseCar.SetAcceleration(car.Acceleration);
            databaseCar.SetTopspeed(car.Topspeed);
            databaseCar.SetCarClass(car.CarClass);
            databaseCar.SetFuel(car.Fuel);
            databaseCar.SetFuelConsumption(car.FuelConsumption);
            //carGet.SetMadeByUser(car.MadeByUser);

            if (databaseCar.Update())
            {
                return RedirectToAction("CarDetails");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            return View(getCar(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(CarViewModel car)
        {
            if (new CarCollection().Delete(car.Id))
            {
                //Delete Image
                string uploadsFolder = Path.Combine(envi.WebRootPath, "Images");
                string fileName = car.Id.ToString() + ".jpg";
                string filePath = Path.Combine(uploadsFolder, fileName);
                System.IO.File.Delete(filePath);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}

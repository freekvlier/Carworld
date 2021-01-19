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
    public class CarController : Controller
    {
        private readonly IWebHostEnvironment environment;

        public CarController(IWebHostEnvironment _environment)
        {
            environment = _environment;
        }

        //Methods
        private bool IsCarFavoriteFromUser(int carId)
        {
            if (User.Identity.IsAuthenticated)
            {
                return new FavoriteCollection().CheckFavorite(GetCurrentLoggedInUserId(), carId);
            }
            else
            {
                return false;
            }
        }

        private int GetCurrentLoggedInUserId()
        {
            return (int)HttpContext.Session.GetInt32("UserId");
        }

        private CarModel getCar(int carId)
        {
            Car getCar = new CarCollection().Get(carId);
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
                MadeByUser = new UserCollection().Get(getCar.MadeByUser).Username,
                Favorite = IsCarFavoriteFromUser(carId)
            };
            return car;
        }

        private List<BrandModel> GetBrands()
        {
            List<BrandModel> brands = new List<BrandModel>();

            foreach (var brand in new BrandCollection().GetAll())
            {
                brands.Add(new BrandModel { 
                    Id = brand.Id, 
                    Name = brand.Name, 
                    Origin = brand.Origin 
                });
            }
            return brands;
        }

        private List<CarClassModel> GetCarClasses()
        {
            List<CarClassModel> carClasses = new List<CarClassModel>();

            foreach (var carClass in new CarClassCollection().GetAll())
            {
                carClasses.Add(new CarClassModel { 
                    Id = carClass.Id,
                    Name = carClass.Name 
                });
            }
            return carClasses;
        }

        private List<FuelModel> GetFuels()
        {
            List<FuelModel> fuels = new List<FuelModel>();

            foreach (var fuel in new FuelCollection().GetAll())
            {
                fuels.Add(new FuelModel { Id = fuel.Id,
                    Name = fuel.Name 
                });
            }
            return fuels;
        }

        private bool CreateCar(CarModel car)
        {
            Car newCar = new Car()
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
                MadeByUser = GetCurrentLoggedInUserId()
            };

            int createdCarId = new CarCollection().Create(newCar);
            if (createdCarId > 0)
            {
                SaveImage(car.Image, createdCarId);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveImage(IFormFile image, int carId)
        {
            string uploadsFolder = Path.Combine(environment.WebRootPath, "Images");
            string fileName = carId.ToString() + ".jpg";
            string filePath = Path.Combine(uploadsFolder, fileName);
            using (var filestream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(filestream);
            }
        }

        private bool DeleteCar(int carId)
        {
            if (new CarCollection().Delete(carId))
            {
                DeleteImage(carId);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DeleteImage(int carId)
        {
            string uploadsFolder = Path.Combine(environment.WebRootPath, "Images");
            string fileName = carId.ToString() + ".jpg";
            string filePath = Path.Combine(uploadsFolder, fileName);
            System.IO.File.Delete(filePath);
        }

        private bool UpdateCar(CarModel car)
        {
            Car databaseCar = new CarCollection().Get(car.Id);

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

            return databaseCar.Update();
        }
        //End methods

        [Route("/User/[action]")]
        public IActionResult Create()
        {
            ViewBag.Brands = GetBrands();
            ViewBag.Fuels = GetFuels();
            ViewBag.CarClasses = GetCarClasses();

            return View();
        }

        [Route("/User/[action]")]
        [HttpPost]
        public IActionResult Create(CarModel car)
        {
            ViewBag.Brands = GetBrands();
            ViewBag.Fuels = GetFuels();
            ViewBag.CarClasses = GetCarClasses();

            if (CreateCar(car))
            {
                TempData.Add("Success", "Car has succesfully been uploaded to database");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
            }
            return View();
        }

        [AllowAnonymous]
        //[Route("/[action]")]
        public IActionResult Details(int carId)
        {
            return View(getCar(carId));
        }

        //[Route("/[action]")]
        public IActionResult Edit(int carId)
        {
            ViewBag.Brands = GetBrands();
            ViewBag.Fuels = GetFuels();
            ViewBag.CarClasses = GetCarClasses();

            return View(getCar(carId));
        }

        [HttpPost]
        //[Route("/[action]")]
        public IActionResult Edit(CarModel car)
        {
            ViewBag.Brands = GetBrands();
            ViewBag.Fuels = GetFuels();
            ViewBag.CarClasses = GetCarClasses();

            if (UpdateCar(car))
            {
                return RedirectToAction("Details");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Delete(int carId)
        {
            return View(getCar(carId));
        }

        [HttpPost]
        public IActionResult Delete(CarModel car)
        {
            if (DeleteCar(car.Id))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong deleting data from the server");
                return View();
            }
        }

    }
}

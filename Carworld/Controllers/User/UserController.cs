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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Carworld.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private List<CarViewModel> getFavoriteCars(int userId)
        {
            List<CarViewModel> cars = new List<CarViewModel>();

            foreach (Car car in new CarCollection().GetAllFavorites(userId))
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

        [Route("/[action]")]
        public IActionResult AddToFavorites(int id)
        {
            Favorite favorite = new Favorite()
            {
                CarId = id,
                UserId = (int)HttpContext.Session.GetInt32("UserId")
            };

            if(new FavoriteCollection().Create(favorite))
            {
                return RedirectToAction("CarDetails", "SelectedCar");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong adding car to favorites");
                return RedirectToAction("CarDetails", "SelectedCar");
            }         
        }

        public IActionResult Favorites()
        {
            return View(getFavoriteCars((int)HttpContext.Session.GetInt32("UserId")));
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
            return RedirectToAction("LoggedOut");
        }

        [AllowAnonymous]
        public IActionResult LoggedOut()
        {
            return View();
        }
    }
}

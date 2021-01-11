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
        //Methods
        private List<CarModel> getFavoriteCars(int userId)
        {
            List<CarModel> cars = new List<CarModel>();

            foreach (Car car in new CarCollection().GetAllFavorites(userId))
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
                    MadeByUser = new UserCollection().Get(car.MadeByUser).Username,
                });
            }
            return cars;
        }

        private int getCurrentLoggedInUserId()
        {
            return (int)HttpContext.Session.GetInt32("UserId");
        }

        private bool addCarToFavorites(int carId)
        {
            Favorite favoriteObject = new Favorite()
            {
                CarId = carId,
                UserId = getCurrentLoggedInUserId()
            };

            if (new FavoriteCollection().Create(favoriteObject))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool removeCarFromFavorites(int favoriteId)
        {
            if (new FavoriteCollection().DeleteFromUser(getCurrentLoggedInUserId(), favoriteId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task clearCurrentSession()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
        }
        //End Methods

        [Route("/[action]")]
        public IActionResult AddToFavorites(int carId)
        {
            if(addCarToFavorites(carId))
            {
                return RedirectToAction("Details", "Car", new { carId = carId });
            }
            else
            {
                TempData.Add("Alert", "Something went wrong adding car to favorites");
                return RedirectToAction("Details", "Car", new { carId = carId });
            }         
        }

        [Route("/[action]")]
        public IActionResult RemoveFromFavorites(int favoriteId)
        {
            if (removeCarFromFavorites(favoriteId))
            {
                return RedirectToAction("Details", "car", new { carId = favoriteId });
            }
            else
            {
                TempData.Add("Alert", "Something went removing car from favorites");
                return RedirectToAction("Details", "Car");
            }
        }

        public IActionResult Favorites()
        {
            return View(getFavoriteCars(getCurrentLoggedInUserId()));
        }

        public async Task<IActionResult> Logout()
        {
            await clearCurrentSession();
            return RedirectToAction("LoggedOut");
        }

        [AllowAnonymous]
        public IActionResult LoggedOut()
        {
            return View();
        }
    }
}

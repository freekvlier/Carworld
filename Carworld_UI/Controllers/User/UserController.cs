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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Carworld.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //Methods
        private List<CarModel> GetFavoriteCars(int userId)
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

        private int GetCurrentLoggedInUserId()
        {
            return (int)HttpContext.Session.GetInt32("UserId");
        }

        private bool AddCarToFavorites(int carId)
        {
            Favorite favoriteObject = new Favorite()
            {
                CarId = carId,
                UserId = GetCurrentLoggedInUserId()
            };

            return new FavoriteCollection().Create(favoriteObject);
        }

        private bool RemoveCarFromFavorites(int carId)
        {
            return new FavoriteCollection().DeleteFromUser(GetCurrentLoggedInUserId(), carId);
        }

        private async Task ClearCurrentSession()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
        }
        //End Methods

        [Route("/[action]")]
        public IActionResult AddToFavorites(int carId)
        {
            if(AddCarToFavorites(carId))
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
        public IActionResult RemoveFromFavorites(int carId)
        {
            if (RemoveCarFromFavorites(carId))
            {
                return RedirectToAction("Details", "car", new { carId = carId });
            }
            else
            {
                TempData.Add("Alert", "Something went removing car from favorites");
                return RedirectToAction("Details", "Car");
            }
        }

        public IActionResult Favorites()
        {
            return View(GetFavoriteCars(GetCurrentLoggedInUserId()));
        }

        public async Task<IActionResult> Logout()
        {
            await ClearCurrentSession();
            return RedirectToAction("LoggedOut");
        }

        [AllowAnonymous]
        public IActionResult LoggedOut()
        {
            return View();
        }
    }
}

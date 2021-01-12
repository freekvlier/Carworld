using Carworld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Carworld_Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

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
        private string GetUsername(int userId)
        {
            return new UserCollection().Get(userId).Username;
        }

        private List<CarModel> GetCars()
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
                    MadeByUser = new UserCollection().Get(car.MadeByUser).Username,
                });
            }
            return cars;
        }

        private List<CarModel> GetCarsSortedByProperty(string property)
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
                    MadeByUser = GetUsername(car.MadeByUser),
                });
            }
            return cars;
        }

        private void SetSessionVariables(User user)
        {
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetInt32("UserId", user.Id);
        }

        private bool LoginUser(UserModel user)
        {
            User userObject = new User()
            {
                Username = user.Username,
                Password = user.Password
            };

            user.Id = new UserCollection().GetId(userObject);

            if (user.Id >= 0)
            {
                SetSessionVariables(userObject);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task GenerateAuthenticationCookie(UserModel user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };

            var claimsIdentity = new ClaimsIdentity(claims, "CarworldIdentity");
  
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        private bool RegisterUser(UserRegisterModel user)
        {
            User registerUser = new User()
            {
                Email = user.Email,
                Username = user.Username,
                Password = user.Password
            };

            return new UserCollection().Create(registerUser);
        }
        
        private List<CarModel> GetCarsSortedByPropertyString(string property)
        {
            switch (property)
            {
                case "Brand":
                    return GetCarsSortedByProperty("Brand");
                case "Price":
                    return GetCarsSortedByProperty("Price");
                case "Horsepower":
                    return GetCarsSortedByProperty("Horsepower");
                case "Year":
                    return GetCarsSortedByProperty("Year");
                default:
                    return GetCars();
            }
        }
        //End methods

        public IActionResult Index()
        {
            return View(GetCars());
        }

        [Route("/[action]")]
        public IActionResult Index(string selectedSortMethod)
        {
            ViewBag.Filter = selectedSortMethod;
            return View(GetCarsSortedByPropertyString(selectedSortMethod));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel user, string url)
        {
            if (LoginUser(user))
            {
                await GenerateAuthenticationCookie(user);
                return Redirect("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel user)
        {
            if (RegisterUser(user))
            {
                return RedirectToAction("Login");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

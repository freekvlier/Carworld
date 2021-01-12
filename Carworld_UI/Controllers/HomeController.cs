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
        private string getUsername(int userId)
        {
            return new UserCollection().Get(userId).Username;
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
                    MadeByUser = new UserCollection().Get(car.MadeByUser).Username,
                });
            }
            return cars;
        }

        private List<CarModel> getCarsSortedByProperty(string property)
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
                    MadeByUser = getUsername(car.MadeByUser),
                });
            }
            return cars;
        }

        private void setSessionVariables(User user)
        {
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetInt32("UserId", user.Id);
        }

        private bool loginUser(UserModel user)
        {
            User userObject = new User()
            {
                Username = user.Username,
                Password = user.Password
            };

            user.Id = new UserCollection().GetId(userObject);

            if (user.Id >= 0)
            {
                setSessionVariables(userObject);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task generateAuthenticationCookie(UserModel user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };

            var claimsIdentity = new ClaimsIdentity(claims, "CarworldIdentity");
  
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        private bool registerUser(UserRegisterModel user)
        {
            User registerUser = new User()
            {
                Email = user.Email,
                Username = user.Username,
                Password = user.Password
            };

            if (new UserCollection().Create(registerUser))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private List<CarModel> getCarsSortedByPropertyString(string property)
        {
            switch (property)
            {
                case "Brand":
                    return getCarsSortedByProperty("Brand");
                case "Price":
                    return getCarsSortedByProperty("Price");
                case "Horsepower":
                    return getCarsSortedByProperty("Horsepower");
                case "Year":
                    return getCarsSortedByProperty("Year");
                default:
                    return getCars();
            }
        }
        //End methods

        public IActionResult Index()
        {
            return View(getCars());
        }

        [Route("/[action]")]
        public IActionResult Index(string selectedSortMethod)
        {
            ViewBag.Filter = selectedSortMethod;
            return View(getCarsSortedByPropertyString(selectedSortMethod));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel user, string url)
        {
            if (loginUser(user))
            {
                await generateAuthenticationCookie(user);
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
            if (registerUser(user))
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

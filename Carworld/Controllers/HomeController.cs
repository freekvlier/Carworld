using Carworld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Logic;
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

        private List<CarViewModel> getCarsSorted(string property)
        {
            List<CarViewModel> cars = new List<CarViewModel>();

            foreach (Car car in new CarCollection().GetAllSorted(property))
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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel user, string url)
        {
            User loginUser = new User(-1, null, user.Username, user.Password);

            int userId = new UserCollection().GetId(loginUser);

            if (userId >= 0)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "CarworldIdentity");
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetInt32("UserId", userId);

                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = false, ExpiresUtc = DateTime.Now.AddMinutes(20)});
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                //return Redirect(url == null ? "/Home" : url);
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
            User registerUser = new User(-1, user.Email, user.Username, user.Password);

            if (new UserCollection().Create(registerUser))
            {
                TempData.Add("Success", "Registered succesfully");
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

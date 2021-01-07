using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carworld.Models;
using Logic;

namespace Carworld.Controllers
{
    public class FavoriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

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
    public class BrandController : Controller
    {
        public IActionResult Brands()
        {
            List<BrandModel> brands = new List<BrandModel>();

            foreach (var brand in new BrandCollection().GetAll())
            {
                brands.Add(new BrandModel()
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Origin = brand.Origin
                });
            }
            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BrandModel brand)
        {
            Brand newBrand = new Brand()
            {
                Name = brand.Name,
                Origin = brand.Origin
            };

            if (new BrandCollection().Create(newBrand))
            {
                return RedirectToAction("Brands");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            Brand databaseBrand = new BrandCollection().Get(id);
            BrandModel brand = new BrandModel()
            {
                Id = databaseBrand.Id,
                Name = databaseBrand.Name,
                Origin = databaseBrand.Origin
            };

            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit(int id, BrandModel inputBrand)
        {
            Brand brand = new BrandCollection().Get(id);

            brand.SetName(inputBrand.Name);
            brand.SetOrigin(inputBrand.Origin);


            if (brand.Update())
            {
                return RedirectToAction("Brands");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            Brand databaseBrand = new BrandCollection().Get(id);
            BrandModel brand = new BrandModel()
            {
                Id = databaseBrand.Id,
                Name = databaseBrand.Name,
                Origin = databaseBrand.Origin
            };
            return View(brand);
        }

        [HttpPost]
        public IActionResult Delete(int id, BrandModel brand)
        {
            if (new BrandCollection().Delete(id))
            {
                return RedirectToAction("Brands");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong deleting data from the server");
                return View(brand);
            }
        }
    }
}

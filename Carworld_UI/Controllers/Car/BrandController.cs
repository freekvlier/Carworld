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
    public class BrandController : Controller
    {
        //Methods
        private List<BrandModel> getAllBrands()
        {
            List<BrandModel> brands = new List<BrandModel>();

            foreach (var brand in new BrandCollection().GetAll())
            {
                brands.Add(new BrandModel
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Origin = brand.Origin
                });
            }
            return brands;
        }

        private BrandModel getBrand(int brandId)
        {
            Brand databaseBrand = new BrandCollection().Get(brandId);
            BrandModel brand = new BrandModel()
            {
                Id = databaseBrand.Id,
                Name = databaseBrand.Name,
                Origin = databaseBrand.Origin
            };
            return brand;
        }

        private bool updateBrand(BrandModel brand)
        {
            Brand databaseBrand = new BrandCollection().Get(brand.Id);

            databaseBrand.SetName(brand.Name);
            databaseBrand.SetOrigin(brand.Origin);

            if (databaseBrand.Update())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool createBrand(BrandModel brand)
        {
            Brand newBrand = new Brand()
            {
                Name = brand.Name,
                Origin = brand.Origin
            };

            if (new BrandCollection().Create(newBrand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool deleteBrand(int brandId)
        {
            return new BrandCollection().Delete(brandId);
        }
        //End methods

        public IActionResult Index()
        {
            return View(getAllBrands());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BrandModel brand)
        {
            if (createBrand(brand))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Edit(int brandId)
        {
            return View(getBrand(brandId));
        }

        [HttpPost]
        public IActionResult Edit(BrandModel brand)
        {
            if (updateBrand(brand))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong uploading data to the server");
                return View();
            }
        }

        public IActionResult Delete(int brandId)
        {   
            return View(getBrand(brandId));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(BrandModel brand)
        {
            if (deleteBrand(brand.Id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData.Add("Alert", "Something went wrong deleting data from the server");
                return View(brand);
            }
        }
    }
}

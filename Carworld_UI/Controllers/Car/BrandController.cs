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
        private List<BrandModel> GetAllBrands()
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

        private BrandModel GetBrand(int brandId)
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

        private bool UpdateBrand(BrandModel brand)
        {
            Brand databaseBrand = new BrandCollection().Get(brand.Id);

            databaseBrand.SetName(brand.Name);
            databaseBrand.SetOrigin(brand.Origin);

            return databaseBrand.Update();
        }

        private bool CreateBrand(BrandModel brand)
        {
            Brand newBrand = new Brand()
            {
                Name = brand.Name,
                Origin = brand.Origin
            };

            return new BrandCollection().Create(newBrand);
        }

        private bool DeleteBrand(int brandId)
        {
            return new BrandCollection().Delete(brandId);
        }
        //End methods

        public IActionResult Index()
        {
            return View(GetAllBrands());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BrandModel brand)
        {
            if (CreateBrand(brand))
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
            return View(GetBrand(brandId));
        }

        [HttpPost]
        public IActionResult Edit(BrandModel brand)
        {
            if (UpdateBrand(brand))
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
            return View(GetBrand(brandId));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(BrandModel brand)
        {
            if (DeleteBrand(brand.Id))
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

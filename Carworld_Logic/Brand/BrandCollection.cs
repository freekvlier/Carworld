using System;
using System.Collections.Generic;
using System.Text;
using FactoryDAL;
using ContractLayer;

namespace Carworld_Logic
{
    public class BrandCollection
    {
        private readonly IBrandCollectionDAL brandCollectionDAL;

        public BrandCollection()
        {
            this.brandCollectionDAL = BrandFactoryDAL.GetCollectionDAL();
        }

        //Unit tests
        public BrandCollection(IBrandCollectionDAL brandCollectionDAL)
        {
            this.brandCollectionDAL = brandCollectionDAL;
        }

        public List<Brand> GetAll()
        {
            List<Brand> brandList = new List<Brand>();
            var brands = brandCollectionDAL.GetAll();

            foreach (var brand in brands)
            {
                brandList.Add(new Brand(brand.Id, brand.Name, brand.Origin));
            }
            
            return brandList;
        }

        public bool Create(Brand brand)
        {
            BrandDTO brandDTO = new BrandDTO() { 
                Id = 0, 
                Name = brand.Name, 
                Origin = brand.Origin 
            };

            return brandCollectionDAL.Create(brandDTO);
        }

        public bool Delete(int id)
        {
            return brandCollectionDAL.Delete(id);
        }

        public Brand Get(int id)
        {
            var Brand = brandCollectionDAL.Get(id);
            try
            {
                Brand brand = new Brand(Brand.Id, Brand.Name, Brand.Origin);
                return brand;
            }
            catch (Exception)
            {
                Brand brand = new Brand(0, "Empty", "Empty");
                return brand;
            }
        }
    }
}

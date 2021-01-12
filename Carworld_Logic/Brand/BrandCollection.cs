using System;
using System.Collections.Generic;
using System.Text;
using FactoryDAL;
using ContractLayer;

namespace Carworld_Logic
{
    public class BrandCollection
    {
        public List<Brand> GetAll()
        {
            List<Brand> brandList = new List<Brand>();
            var brands = BrandFactoryDAL.GetCollectionDAL().GetAll();

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

            return BrandFactoryDAL.GetCollectionDAL().Create(brandDTO);
        }

        public bool Delete(int id)
        {
            return BrandFactoryDAL.GetCollectionDAL().Delete(id);
        }

        public Brand Get(int id)
        {
            var Brand = BrandFactoryDAL.GetCollectionDAL().Get(id);
            Brand brand = new Brand(Brand.Id, Brand.Name, Brand.Origin);
            return brand;
        }
    }
}

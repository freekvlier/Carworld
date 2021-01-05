using System;
using System.Collections.Generic;
using System.Text;
using FactoryDAL;
using ContractLayer;

namespace Logic
{
    class BrandCollection
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

            if (BrandFactoryDAL.GetCollectionDAL().Create(brandDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Brand brand)
        {
            BrandDTO brandDTO = new BrandDTO()
            {
                Id = brand.Id,
                Name = brand.Name,
                Origin = brand.Origin
            };

            if (BrandFactoryDAL.GetCollectionDAL().Delete(brandDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Brand Get(int id)
        {
            var Brand = BrandFactoryDAL.GetCollectionDAL().Get(id);
            Brand brand = new Brand(Brand.Id, Brand.Name, Brand.Origin);
            return brand;
        }
    }
}

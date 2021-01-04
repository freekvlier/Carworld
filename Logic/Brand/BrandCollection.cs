using System;
using System.Collections.Generic;
using System.Text;
using FactoryDAL;

namespace Logic
{
    class BrandCollection
    {
        public List<Brand> getAll()
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
            if (BrandFactoryDAL.GetCollectionDAL().Create(null))
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
            if (BrandFactoryDAL.GetCollectionDAL().Delete(null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;

namespace Carworld_LogicTests
{
    public class BrandTestDAL : IBrandDAL, IBrandCollectionDAL
    {
        private List<BrandDTO> brandDTOs = new List<BrandDTO>();
        private int counter = 0;

        private int getCount()
        {
            int currentCount = counter;
            counter++;
            return currentCount;
        }


        public bool Create(BrandDTO brand)
        {
            if(brand.Name != "" & brand.Name != null & brand.Origin != "" & brand.Origin != null)
            {
                brand.Id = getCount();
                brandDTOs.Add(brand);
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BrandDTO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<BrandDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(BrandDTO brand)
        {
            throw new NotImplementedException();
        }
    }
}

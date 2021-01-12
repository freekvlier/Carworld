using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;

namespace Carworld_LogicTests
{
    public class BrandTestDAL : IBrandDAL, IBrandCollectionDAL
    {
        private List<BrandDTO> database = new List<BrandDTO>();
        private int idCounter = 0;

        private int getIdCount()
        {
            int currentIdCount = idCounter;
            idCounter++;
            return currentIdCount;
        }


        public bool Create(BrandDTO brand)
        {
            if(brand.Name != "" & brand.Name != null & brand.Origin != "" & brand.Origin != null)
            {
                brand.Id = getIdCount();
                database.Add(brand);
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                database.RemoveAt(database.FindIndex(x => x.Id == id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BrandDTO Get(int id)
        {
            BrandDTO get = database.Find(x => x.Id == id);

            return get;
        }

        public List<BrandDTO> GetAll()
        {
            return database;
        }

        public bool Update(BrandDTO brand)
        {
            throw new NotImplementedException();
        }
    }
}

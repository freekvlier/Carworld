using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Logic
{
    public class CarClassCollection
    {
        public List<CarClass> GetAll()
        {
            List<CarClass> carClassList = new List<CarClass>();
            var carClasses = CarClassFactoryDAL.GetCollectionDAL().GetAll();

            foreach (var carclass in carClasses)
            {
                carClassList.Add(new CarClass(carclass.Id, carclass.Name));
            }

            return carClassList;
        }

        public bool Create(CarClass carclass)
        {
            CarClassDTO carclassDTO = new CarClassDTO()
            {
                Id = 0,
                Name = carclass.Name,
            };

            if (CarClassFactoryDAL.GetCollectionDAL().Create(carclassDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(CarClass carclass)
        {
            CarClassDTO carclassDTO = new CarClassDTO()
            {
                Id = carclass.Id,
                Name = carclass.Name,
            };

            if (CarClassFactoryDAL.GetCollectionDAL().Delete(carclassDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CarClass Get(int id)
        {
            var carClassGet = CarClassFactoryDAL.GetCollectionDAL().Get(id);
            CarClass carClass = new CarClass(carClassGet.Id, carClassGet.Name);
            return carClass;
        }
    }
}

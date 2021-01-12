using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Carworld_Logic
{
    public class FuelCollection
    {
        public List<Fuel> GetAll()
        {
            List<Fuel> fuelList = new List<Fuel>();
            var fuels = FuelFactoryDAL.GetCollectionDAL().GetAll();

            foreach (var fuel in fuels)
            {
                fuelList.Add(new Fuel(fuel.Id, fuel.Name));
            }

            return fuelList;
        }

        public bool Create(Fuel fuel)
        {
            FuelDTO fuelDTO = new FuelDTO()
            {
                Id = 0,
                Name = fuel.Name,
            };

            return FuelFactoryDAL.GetCollectionDAL().Create(fuelDTO);
        }

        public bool Delete(int id)
        {
            return FuelFactoryDAL.GetCollectionDAL().Delete(id);
        }

        public Fuel Get(int id)
        {
            var fuelGet = FuelFactoryDAL.GetCollectionDAL().Get(id);
            Fuel fuel = new Fuel(fuelGet.Id, fuelGet.Name);

            return fuel;
        }
    }
}

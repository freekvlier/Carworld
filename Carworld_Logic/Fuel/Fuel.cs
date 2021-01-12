using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Carworld_Logic
{
    public class Fuel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Fuel()
        {

        }

        public Fuel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public bool Update()
        {
            FuelDTO fuelDTO = new FuelDTO
            {
                Id = this.Id,
                Name = this.Name
            };

            return FuelFactoryDAL.GetDAL().Update(fuelDTO);

        }

        public void SetName(string name)
        {
            this.Name = name;
        }
    }
}

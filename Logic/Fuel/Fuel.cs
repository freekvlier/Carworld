using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Logic
{
    public class Fuel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Fuel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Fuel()
        {

        }

        public bool Update()
        {
            FuelDTO fuelDTO = new FuelDTO
            {
                Id = this.Id,
                Name = this.Name
            };

            if (FuelFactoryDAL.GetDAL().Update(fuelDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetName(string name)
        {
            this.Name = name;
        }
    }
}

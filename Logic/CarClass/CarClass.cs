using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Logic
{
    public class CarClass
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CarClass(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public bool Update()
        {
            CarClassDTO carClassDTO = new CarClassDTO
            {
                Id = this.Id,
                Name = this.Name
            };

            if (CarClassFactoryDAL.GetDAL().Update(carClassDTO))
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

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

        public CarClass()
        {

        }

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

            return CarClassFactoryDAL.GetDAL().Update(carClassDTO);
        }

        public void SetName(string name)
        {
            this.Name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Logic
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int Price { get; set; }
        public int Horsepower { get; set; }
        public int Torque { get; set; }
        public double Acceleration { get; set; }
        public int Topspeed { get; set; }
        public string CarClass { get; set; }
        public string Fuel { get; set; }
        public double FuelConsumption { get; set; }
        public int MadeByUser { get; set; }

        public Car(int Id, string Brand, string Model, string Year, int Price, int Horsepower,
                   int Torque, double Acceleration, int Topspeed, string CarClass, 
                   string Fuel, double FuelConsumption, int MadeByUser)
        {
            this.Id = Id;
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.Price = Price;
            this.Horsepower = Horsepower;
            this.Torque = Torque;
            this.Acceleration = Acceleration;
            this.Topspeed = Topspeed;
            this.CarClass = CarClass;
            this.Fuel = Fuel;
            this.FuelConsumption = FuelConsumption;
            this.MadeByUser = MadeByUser;
        }

        public bool Update()
        {
            var brands = BrandFactoryDAL.GetCollectionDAL().GetAll();
            var carClasses = CarClassFactoryDAL.GetCollectionDAL().GetAll();
            var fuels = FuelFactoryDAL.GetCollectionDAL().GetAll();

            CarDTO carDTO = new CarDTO
            {
                Id = this.Id,
                BrandId = brands.FindIndex(item => item.Name == this.Brand),
                Model = this.Model,
                Year = this.Year,
                Price = this.Price,
                Horsepower = this.Horsepower,
                Torque = this.Torque,
                Acceleration = this.Acceleration,
                Topspeed = this.Topspeed,
                CarClassId = carClasses.FindIndex(item => item.Name == this.CarClass),
                FuelId = fuels.FindIndex(item => item.Name == this.Fuel),
                FuelConsumption = this.FuelConsumption,
                MadeByUser = this.MadeByUser
            };

            if (CarFactoryDAL.GetDAL().Update(carDTO))
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

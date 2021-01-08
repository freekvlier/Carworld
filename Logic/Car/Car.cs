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
        public int Year { get; set; }
        public int Price { get; set; }
        public int Horsepower { get; set; }
        public int Torque { get; set; }
        public double Acceleration { get; set; }
        public int Topspeed { get; set; }
        public string CarClass { get; set; }
        public string Fuel { get; set; }
        public double FuelConsumption { get; set; }
        public int MadeByUser { get; set; }

        public Car(int Id, string Brand, string Model, int Year, int Price, int Horsepower,
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

        public Car()
        {

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

        //Set functions
        public void SetBrand(string brand)
        {
            this.Brand = Brand;
        }

        public void SetModel(string model)
        {
            this.Model = model;
        }

        public void SetYear(int year)
        {
            this.Year = year;
        }

        public void SetPrice(int price)
        {
            this.Price = price;
        }

        public void SetHorsepower(int horsepower)
        {
            this.Horsepower = horsepower;
        }

        public void SetTorque(int torque)
        {
            this.Torque = torque;
        }

        public void SetAcceleration(double acceleration)
        {
            this.Acceleration = acceleration;
        }

        public void SetTopspeed(int topspeed)
        {
            this.Topspeed = topspeed;
        }

        public void SetCarClass(string carClass)
        {
            this.CarClass = carClass;
        }

        public void SetFuel(string fuel)
        {
            this.Fuel = fuel;
        }

        public void SetFuelConsumption(double fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption;
        }

        public void SetMadeByUser(int madeByUser)
        {
            this.MadeByUser = madeByUser;
        }
    }
}

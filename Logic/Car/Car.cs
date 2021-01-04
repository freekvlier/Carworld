using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int Price { get; set; }
        public int Power { get; set; }
        public int Torque { get; set; }
        public double Acceleration { get; set; }
        public int Topspeed { get; set; }
        public string Class { get; set; }
        public string Fuel { get; set; }
        public double FuelConsumption { get; set; }
        public int MadeByUser { get; set; }

        public Car(int Id, string Brand, string Model, string Year, int Price, int Power,
                   int Torque, double Acceleration, int Topspeed, string CarClass, 
                   string Fuel, double Consumption, int UserId)
        {
            this.Id = Id;
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.Price = Price;
            this.Power = Power;
            this.Torque = Torque;
            this.Acceleration = Acceleration;
            this.Topspeed = Topspeed;
            this.Class = CarClass;
            this.Fuel = Fuel;
            this.FuelConsumption = Consumption;
            this.MadeByUser = UserId;
        }
    }
}

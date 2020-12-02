using System;

namespace ContractLayer
{
    public class CarDTO
    {
        public int Id { get; set; }
        public int Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int Price { get; set; }
        public int Power { get; set; }
        public int Torque { get; set; }
        public double Acceleration { get; set; }
        public int Topspeed { get; set; }
        public int Class { get; set; }
        public int Fuel { get; set; }
        public double FuelConsumption { get; set; }
        public int UserId { get; set; }
    }
}

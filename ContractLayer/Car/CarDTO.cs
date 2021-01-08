using System;

namespace ContractLayer
{
    public class CarDTO
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public int Horsepower { get; set; }
        public int Torque { get; set; }
        public double Acceleration { get; set; }
        public int Topspeed { get; set; }
        public int CarClassId { get; set; }
        public int FuelId { get; set; }
        public double FuelConsumption { get; set; }
        public int MadeByUser { get; set; }
    }
}

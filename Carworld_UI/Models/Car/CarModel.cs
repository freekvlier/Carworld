using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Carworld.Models
{
    public class CarModel
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
        public string MadeByUser { get; set; }
        public bool Favorite { get; set; }
        public IFormFile Image { get; set; }
    }
}

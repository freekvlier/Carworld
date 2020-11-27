using System;

namespace DTO
{
    public class AutoDTO
    {
        public int Id { get; set; }
        public int Merk { get; set; }
        public string Model { get; set; }
        public string Jaar { get; set; }
        public int Prijs { get; set; }
        public int Vermogen { get; set; }
        public int Koppel { get; set; }
        public double Acceleratie { get; set; }
        public int Topsnelheid { get; set; }
        public int Klasse { get; set; }
        public int Brandstof { get; set; }
        public double Verbruik { get; set; }
        public int GebruikerId { get; set; }
    }
}

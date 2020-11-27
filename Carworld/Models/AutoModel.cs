using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carworld.Models
{
    public class AutoModel
    {
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
    }
}

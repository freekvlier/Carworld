using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Car
    {
        public int Id { get; set; }
        public string Merk { get; set; }
        public string Model { get; set; }
        public string Jaar { get; set; }
        public int Prijs { get; set; }
        public int Vermogen { get; set; }
        public int Koppel { get; set; }
        public double Acceleratie { get; set; }
        public int Topsnelheid { get; set; }
        public string Klasse { get; set; }
        public string Brandstof { get; set; }
        public double Verbruik { get; set; }
        public int GebruikerId { get; set; }

        public Car(int Id, string Merk, string Model, string Jaar, int Prijs, int Vermogen,
                   int Koppel, double Acceleratie, int Topsnelheid, string Klasse, 
                   string Brandstof, double Verbruik, int GebruikerId)
        {
            this.Id = Id;
            this.Merk = Merk;
            this.Model = Model;
            this.Jaar = Jaar;
            this.Prijs = Prijs;
            this.Vermogen = Vermogen;
            this.Koppel = Koppel;
            this.Acceleratie = Acceleratie;
            this.Topsnelheid = Topsnelheid;
            this.Klasse = Klasse;
            this.Brandstof = Brandstof;
            this.Verbruik = Verbruik;
            this.GebruikerId = GebruikerId;
        }

    }
}

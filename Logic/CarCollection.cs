using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Logic
{
    public class CarCollection
    {
        public List<Car> getCars()
        {
            
            //var autoDatabase = server.readAutosFromDatabase();
            //var merken = server.readMerkenFromDatabase();
            //var klasses = server.readKlassenFromDatabase();
            var brandstoffen = FuelFactoryDAL.GetCollectionDAL().GetAll();

            
            List<Car> cars = new List<Car>();
            /*
            foreach (var auto in autoDatabase)
            {
                autos.Add(new Auto(auto.Id, merken[auto.Merk].Naam, auto.Model, auto.Jaar, auto.Prijs, auto.Vermogen, auto.Koppel,
                                   auto.Acceleratie, auto.Topsnelheid, klasses[auto.Klasse].Naam, brandstoffen[auto.Brandstof].Naam,
                                   auto.Verbruik, auto.GebruikerId));
            }
            */
            return cars;
        }
    }
}

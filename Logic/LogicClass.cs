using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace Logic
{
    public class LogicClass
    {
        public static List<AutoDTO> getAutos()
        {
            SqlAccess server = new SqlAccess();
            return server.readAutosFromDatabase();
        }

        public static List<MerkDTO> getMerken()
        {
            SqlAccess server = new SqlAccess();
            return server.readMerkenFromDatabase();
        }

        public static List<BrandstofDTO> getBrandstoffen()
        {
            SqlAccess server = new SqlAccess();
            return server.readBrandstoffenFromDatabase();
        }

        public static List<KlasseDTO> getKlassen()
        {
            SqlAccess server = new SqlAccess();
            return server.readKlassenFromDatabase();
        }

        public static string getMerk(int nummer)
        {
            SqlAccess server = new SqlAccess();
            List<MerkDTO> merken = server.readMerkenFromDatabase();
            return merken[nummer].Naam;
        }

        public static AutosDTO getAllCarInformation()
        {
            //Get autos,merken en klassses, brandstoffen
            AutosDTO database = new AutosDTO();
            database.Autos = getAutos();
            database.Merken = getMerken();
            database.Brandstoffen = getBrandstoffen();
            database.Klassen = getKlassen();

            return database;
        }
    }
}

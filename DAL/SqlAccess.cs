using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Globalization;

namespace DAL
{
    public class SqlAccess
    {
        private SqlConnection DatabaseConnection()
        {
            string sqlConnectionString = "Server=mssql.fhict.local;Database=dbi454449;User Id=dbi454449;Password=454449ICT;";
            try
            {
                SqlConnection connection = new SqlConnection(sqlConnectionString);
                connection.Open();
                return connection;
            }
            catch (SqlException error)
            {
                Console.WriteLine("Error Connecting to Database: ");
                Console.WriteLine(error);
                return null;
            }
        }

        public List<AutoDTO> readAutosFromDatabase()
        {
            string SQL = "SELECT * FROM Autos";
            SqlCommand command = new SqlCommand(SQL, DatabaseConnection());

            List<AutoDTO> autos = new List<AutoDTO>();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AutoDTO auto = new AutoDTO();
                auto.Id = reader.GetInt32(0);
                auto.Merk = reader.GetInt32(1);
                auto.Model = reader.GetString(2);
                auto.Jaar = reader.GetString(3);
                auto.Prijs = reader.GetInt32(4);
                auto.Vermogen = reader.GetInt32(5);
                auto.Koppel = reader.GetInt32(6);
                auto.Acceleratie = reader.GetDouble(7);
                auto.Topsnelheid = reader.GetInt32(8);
                auto.Klasse = reader.GetInt32(9);
                auto.Brandstof = reader.GetInt32(10);
                auto.Verbruik = reader.GetDouble(11);
                auto.GebruikerId = reader.GetInt32(13);

                autos.Add(auto);
                //Console.WriteLine("SUCCESS-----------------------------");
                //Console.WriteLine(reader["Model"]);
            }
            return autos;
        }

        public bool insertAutoIntoDatabase(AutoDTO auto)
        {
            try
            {
                string SQL = $"INSERT INTO Autos (Merk, Model, Jaar, Prijs, Vermogen, Koppel, Acceleratie, Topsnelheid, Klasse, Brandstof, Verbruik, GebruikerId) VALUES ('{auto.Merk}', '{auto.Model}', '{auto.Jaar}', '{auto.Prijs}', '{auto.Vermogen}', '{auto.Koppel}', '{auto.Acceleratie.ToString(new CultureInfo("en-US"))}', '{auto.Topsnelheid}', '{auto.Klasse}', '{auto.Brandstof}', '{auto.Verbruik.ToString(new CultureInfo("en-US"))}', '{auto.GebruikerId}')";
                //string SQL = "INSERT INTO Autos (Merk, Model, Jaar, Prijs, Vermogen, Koppel, Acceleratie, Topsnelheid, Klasse, Brandstof, Verbruik, GebruikerId) VALUES ('0', 'Modelleke', '2020', '20000', '350', '400', '4.3', '298', '0', '0', '2.1', '0')";

                SqlCommand command = new SqlCommand(SQL, DatabaseConnection());
                SqlDataReader reader = command.ExecuteReader();
         
                return true;
            }
            catch (SqlException error)
            {
                Console.WriteLine(error);
                return false;
            }
        }

        public List<GebruikerDTO> readGebruikersFromDatabase()
        {
            string SQL = "SELECT * FROM Gebruikers";
            SqlCommand command = new SqlCommand(SQL, DatabaseConnection());

            List<GebruikerDTO> gebruikers = new List<GebruikerDTO>();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GebruikerDTO gebruiker = new GebruikerDTO();
                gebruiker.Id = reader.GetInt32(0);
                gebruiker.Email = reader.GetString(1);
                gebruiker.Gebruikersnaam = reader.GetString(2);
                gebruiker.Wachtwoord = reader.GetString(3);

                gebruikers.Add(gebruiker);
            }
            return gebruikers;
        }

        public bool insertGebruikerIntoDatabase(GebruikerDTO gebruiker)
        {
            try
            {
                string SQL = $"INSERT INTO Gebruikers (Email, Gebruikersnaam, Wachtwoord) VALUES ('{gebruiker.Email}', '{gebruiker.Gebruikersnaam}', '{gebruiker.Wachtwoord}')";
                //string SQL = "INSERT INTO Autos (Merk, Model, Jaar, Prijs, Vermogen, Koppel, Acceleratie, Topsnelheid, Klasse, Brandstof, Verbruik, GebruikerId) VALUES ('0', 'Modelleke', '2020', '20000', '350', '400', '4.3', '298', '0', '0', '2.1', '0')";

                SqlCommand command = new SqlCommand(SQL, DatabaseConnection());
                SqlDataReader reader = command.ExecuteReader();

                return true;
            }
            catch (SqlException error)
            {
                Console.WriteLine(error);
                return false;
            }
        }

        public List<BrandstofDTO> readBrandstoffenFromDatabase()
        {
            string SQL = "SELECT * FROM Brandstoffen";
            SqlCommand command = new SqlCommand(SQL, DatabaseConnection());

            List<BrandstofDTO> brandstoffen = new List<BrandstofDTO>();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BrandstofDTO brandstof = new BrandstofDTO();
                brandstof.Id = reader.GetInt32(0);
                brandstof.Naam = reader.GetString(1);

                brandstoffen.Add(brandstof);
            }
            return brandstoffen;
        }

        public List<KlasseDTO> readKlassenFromDatabase()
        {
            string SQL = "SELECT * FROM Klasse";
            SqlCommand command = new SqlCommand(SQL, DatabaseConnection());

            List<KlasseDTO> klassen = new List<KlasseDTO>();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                KlasseDTO klasse = new KlasseDTO();
                klasse.Id = reader.GetInt32(0);
                klasse.Naam = reader.GetString(1);

                klassen.Add(klasse);
            }
            return klassen;
        }

        public List<MerkDTO> readMerkenFromDatabase()
        {
            string SQL = "SELECT * FROM Merken";
            SqlCommand command = new SqlCommand(SQL, DatabaseConnection());

            List<MerkDTO> merken = new List<MerkDTO>();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MerkDTO merk = new MerkDTO();
                merk.Id = reader.GetInt32(0);
                merk.Naam = reader.GetString(1);
                merk.Herkomst = reader.GetString(2);

                merken.Add(merk);
            }
            return merken;
        }
    }
}

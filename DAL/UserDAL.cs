using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using ContractLayer;

namespace DAL
{
    public class UserDAL: IUserDAL, IUserCollectionDAL
    {
        string sqlConnectionString = "Server=mssql.fhict.local;Database=dbi454449;User Id=dbi454449;Password=454449ICT;";

        public bool Create(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDTO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserDTO fuel)
        {
            throw new NotImplementedException();
        }

        /*
        public List<GebruikerDTO> readGebruikersFromDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Gebruikers";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<GebruikerDTO> gebruikers = new List<GebruikerDTO>();
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
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool insertGebruikerIntoDatabase(GebruikerDTO gebruiker)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = $"INSERT INTO Gebruikers(Email, Gebruikersnaam, Wachtwoord) VALUES('{gebruiker.Email}', '{gebruiker.Gebruikersnaam}', '{gebruiker.Wachtwoord}')";
                    //string SQL = "INSERT INTO Autos (Merk, Model, Jaar, Prijs, Vermogen, Koppel, Acceleratie, Topsnelheid, Klasse, Brandstof, Verbruik, GebruikerId) VALUES ('0', 'Modelleke', '2020', '20000', '350', '400', '4.3', '298', '0', '0', '2.1', '0')";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            return true;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        */
    }
}

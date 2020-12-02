using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using ContractLayer;

namespace DAL
{
    public class CarDAL : ICarDAL, ICarCollectionDAL
    {
        private string sqlConnectionString = "Server=mssql.fhict.local;Database=dbi454449;User Id=dbi454449;Password=454449ICT;";

        public bool Create(CarDTO car)
        {
            throw new NotImplementedException();
        }

        public bool Delete(CarDTO car)
        {
            throw new NotImplementedException();
        }

        public CarDTO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<CarDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(CarDTO auto)
        {
            throw new NotImplementedException();
        }


        /*
        public List<CarDTO> readAutosFromDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Autos";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<CarDTO> autos = new List<CarDTO>();
                            while (reader.Read())
                            {
                                CarDTO car = new CarDTO();
                                car.Id = reader.GetInt32(0);
                                car.Merk = reader.GetInt32(1);
                                car.Model = reader.GetString(2);
                                car.Jaar = reader.GetString(3);
                                car.Prijs = reader.GetInt32(4);
                                car.Vermogen = reader.GetInt32(5);
                                car.Koppel = reader.GetInt32(6);
                                car.Acceleratie = reader.GetDouble(7);
                                car.Topsnelheid = reader.GetInt32(8);
                                car.Klasse = reader.GetInt32(9);
                                car.Brandstof = reader.GetInt32(10);
                                car.Verbruik = reader.GetDouble(11);
                                car.GebruikerId = reader.GetInt32(13);

                                autos.Add(car);
                            }
                            return autos;
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

        public bool insertAutoIntoDatabase(AutoDTO auto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = $"INSERT INTO Autos (Merk, Model, Jaar, Prijs, Vermogen, Koppel, Acceleratie, Topsnelheid, Klasse, Brandstof, Verbruik, GebruikerId) VALUES ('{auto.Merk}', '{auto.Model}', '{auto.Jaar}', '{auto.Prijs}', '{auto.Vermogen}', '{auto.Koppel}', '{auto.Acceleratie.ToString(new CultureInfo("en-US"))}', '{auto.Topsnelheid}', '{auto.Klasse}', '{auto.Brandstof}', '{auto.Verbruik.ToString(new CultureInfo("en-US"))}', '{auto.GebruikerId}')";
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

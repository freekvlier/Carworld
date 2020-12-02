using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ContractLayer;

namespace DAL
{
    public class CarClassDAL : ICarClassDAL, ICarClassCollectionDAL
    {
        private string sqlConnectionString = "Server=mssql.fhict.local;Database=dbi454449;User Id=dbi454449;Password=454449ICT;";

        public bool Create(CarClassDTO carclass)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "INSERT INTO Klasse (Naam) VALUES (@Name)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", carclass.Name);
                        if (command.ExecuteNonQuery() < 1)
                        {
                            return false;
                        }                       
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        public bool Delete(CarClassDTO carclass)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "DELETE FROM Klasse WHERE Naam = (@Name)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", carclass.Name);
                        if (command.ExecuteNonQuery() < 1)
                        {
                            return false;
                        }
                        //reseed();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        public List<CarClassDTO> GetAll()
        {
            CarClassDTO klasse = new CarClassDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Klasse";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<CarClassDTO> klassen = new List<CarClassDTO>();
                            while (reader.Read())
                            {
                                
                                klasse.Id = reader.GetInt32(0);
                                klasse.Name = reader.GetString(1);

                                klassen.Add(klasse);
                            }
                            return klassen;
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

        public CarClassDTO Get(int Id)
        {          
            CarClassDTO carClass = new CarClassDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Klasse WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", Id);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return carClass;
        }

        public bool Update(CarClassDTO carclass)
        {
            throw new NotImplementedException();
        }

        private void reseed()
        {
            int count = GetAll().Count - 1; 
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "DBCC CHECKIDENT(Klasse, RESEED, @count)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@count", count);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

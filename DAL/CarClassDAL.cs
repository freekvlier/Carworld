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
                    string sql = "INSERT INTO CarClass (Name) VALUES (@Name)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", carclass.Name);
                        if (command.ExecuteNonQuery() < 1)
                        {
                            return false;
                        }
                        connection.Close();
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

        public bool Update(CarClassDTO carclass)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "UPDATE CarClass SET Name = (@Name) WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", carclass.Name);
                        command.Parameters.AddWithValue("@Id", carclass.Id);
                        command.ExecuteNonQuery();
                        connection.Close();
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
                    string sql = "DELETE FROM CarClass WHERE Name = (@Name)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", carclass.Name);
                        if (command.ExecuteNonQuery() < 1)
                        {
                            return false;
                        }
                        //reseed();
                        connection.Close();
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
                    string sql = "SELECT * FROM CarClass";
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
                            connection.Close();
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
                    string sql = "SELECT * FROM CarClass WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Id", Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            carClass.Id = reader.GetInt32(0);
                            carClass.Name = reader.GetString(1);
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return carClass;
        }

        private void reseed()
        {
            int count = GetAll().Count - 1; 
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "DBCC CHECKIDENT(CarClass, RESEED, @count)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@count", count);
                        command.ExecuteNonQuery();
                        connection.Close();
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

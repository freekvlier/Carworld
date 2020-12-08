using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using ContractLayer;

namespace DAL
{
    public class FuelDAL: IFuelDAL, IFuelCollectionDAL
    {
        private string sqlConnectionString = "Server=mssql.fhict.local;Database=dbi454449;User Id=dbi454449;Password=454449ICT;";

        public bool Create(FuelDTO fuel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "INSERT INTO Fuel (Name) VALUES (@Name)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", fuel.Name);
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

        public bool Delete(FuelDTO brandstof)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "DELETE FROM Fuel WHERE Name = (@Name)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", brandstof.Name);
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

        public FuelDTO Get(int Id)
        {
            FuelDTO carClass = new FuelDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Fuel WHERE Id = (@Id)";
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

        public List<FuelDTO> GetAll()
        {
            List<FuelDTO> brandstoffen = new List<FuelDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Fuel";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                FuelDTO brandstof = new FuelDTO
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1)
                                };
                                brandstoffen.Add(brandstof);
                            }
                            
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return brandstoffen;
        }

        public bool Update(FuelDTO fuel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "UPDATE Fuel SET Name = (@Name) WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", fuel.Name);
                        command.Parameters.AddWithValue("@Id", fuel.Id);
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
    }
}

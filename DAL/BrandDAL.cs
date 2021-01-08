using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using ContractLayer;

namespace DAL
{
    public class BrandDAL : IBrandDAL, IBrandCollectionDAL
    {
        private string sqlConnectionString = "Server=mssql.fhict.local;Database=dbi454449;User Id=dbi454449;Password=454449ICT;";

        public bool Create(BrandDTO brand)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "INSERT INTO Brand (Name, Origin) VALUES (@Name, @Origin)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", brand.Name);
                        command.Parameters.AddWithValue("@Origin", brand.Origin);
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

        public bool Delete(BrandDTO brand)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "DELETE FROM Brands WHERE Name = (@Name)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", brand.Name);
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

        public BrandDTO Get(int Id)
        {
            BrandDTO brand = new BrandDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Brands WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Id", Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            brand.Id = reader.GetInt32(0);
                            brand.Name = reader.GetString(1);
                            brand.Origin = reader.GetString(2);
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return brand;
        }

        public List<BrandDTO> GetAll()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Brands ORDER BY Name";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<BrandDTO> brands = new List<BrandDTO>();
                            while (reader.Read())
                            {
                                BrandDTO brand = new BrandDTO
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Origin = reader.GetString(2)
                                };
                                brands.Add(brand);
                            }
                            connection.Close();
                            return brands;
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

        public bool Update(BrandDTO brand)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "UPDATE Brands SET Name = (@Name), Origin = @Origin WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", brand.Name);
                        command.Parameters.AddWithValue("@Name", brand.Origin);
                        command.Parameters.AddWithValue("@Id", brand.Id);
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

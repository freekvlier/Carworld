using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ContractLayer;

namespace DAL
{
    public class FavoriteDAL : IFavoriteDAL, IFavoriteCollectionDAL
    {
        private string sqlConnectionString = "Server=mssql.fhict.local;Database=dbi454449;User Id=dbi454449;Password=454449ICT;";

        public bool Create(FavoriteDTO favorite)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "INSERT INTO Favorites (UserId, CarId) VALUES (@UserId, @CarId)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@UserId", favorite.UserId);
                        command.Parameters.AddWithValue("@CarId", favorite.CarId);
                        if (command.ExecuteNonQuery() < 1)
                        {
                            connection.Close();
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

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "DELETE FROM Favorites WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Id", id);
                        if (command.ExecuteNonQuery() < 1)
                        {
                            connection.Close();
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

        public bool DeleteFromUser(int userId, int carId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "DELETE FROM Favorites WHERE UserId = (@UserId) AND CarId = (@CarId)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@CarId", carId);
                        if (command.ExecuteNonQuery() < 1)
                        {
                            connection.Close();
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

        public FavoriteDTO Get(int Id)
        {
            FavoriteDTO favorite = new FavoriteDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Favorites WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Id", Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            favorite.UserId = reader.GetInt32(0);
                            favorite.CarId = reader.GetInt32(1);
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

            return favorite;
        }


        public List<FavoriteDTO> GetAllByUserId(int userId)
        {
            List<FavoriteDTO> favorites = new List<FavoriteDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Favorites WHERE UserId = (@UserId)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@UserId", userId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FavoriteDTO favorite = new FavoriteDTO
                                {
                                    Id = reader.GetInt32(0),
                                    UserId = reader.GetInt32(1),
                                    CarId = reader.GetInt32(2)
                                };
                                favorites.Add(favorite);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

            return favorites;
        }

        public List<FavoriteDTO> GetAll()
        {
            List<FavoriteDTO> favorites = new List<FavoriteDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Favorites";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                FavoriteDTO favorite = new FavoriteDTO
                                {
                                    Id = reader.GetInt32(0),
                                    UserId = reader.GetInt32(1),
                                    CarId = reader.GetInt32(2)
                                };
                                favorites.Add(favorite);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

            return favorites;
        }

        public bool Update(FavoriteDTO favorite)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "UPDATE Favorites SET CarId = (@CarId) WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@CarId", favorite.CarId);
                        command.Parameters.AddWithValue("@Id", favorite.Id);
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

        public bool CheckFavorite(int userId, int carId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Favorites WHERE UserId = (@UserId) AND CarId = (@CarId)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@CarId", carId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            try
                            {
                                reader.GetInt32(0);
                            }
                            catch (SqlException e)
                            {
                                Console.WriteLine(e);
                                connection.Close();
                                return false;
                            }
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
    }
}

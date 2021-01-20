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
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "INSERT INTO Users (Email, Username, Password) VALUES (@Email, @Username, @Password)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
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

        public bool Delete(UserDTO user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "DELETE FROM Users WHERE Username = (@Username)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Username", user.Username);
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

        public List<UserDTO> GetAll()
        {
            List<UserDTO> users = new List<UserDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Users";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserDTO user = new UserDTO
                                {
                                    Id = reader.GetInt32(0),
                                    Email = reader.GetString(1),
                                    Username = reader.GetString(2),
                                    Password = reader.GetString(3)
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

            return users;
        }

        public UserDTO Get(int userId)
        {
            UserDTO user = new UserDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Users WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Id", userId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            user.Id = reader.GetInt32(0);
                            user.Email = reader.GetString(1);
                            user.Username = reader.GetString(2);                           
                            user.Password = reader.GetString(3);
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

            return user;
        }

        public bool Update(UserDTO user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "UPDATE Users SET Email = (@Email), Username = (@Username), Password = (@Password) WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
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

        public int GetId(UserDTO user)
        {
            int userId;
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT Id FROM Users WHERE Username = (@Username) AND Password = (@Password)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                userId = reader.GetInt32(0);
                            }
                            else
                            {
                                userId = -1;

                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                userId = -1;
                Console.WriteLine(e);
            }

            return userId;
        }
    }
}

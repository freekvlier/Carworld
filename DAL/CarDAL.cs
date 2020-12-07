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
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "INSERT INTO Cars (Brand, Model, Year, Price, Power, Torque, Acceleration, Topspeed, CarClass, Fuel, Consumption, UserId)" +
                                 " VALUES (@Brand, @Model, @Year, @Price, @Power, @Torque, @Acceleration, @Topspeed, @CarClass, @Fuel, @Consumption, @UserId)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Brand", car.Model);
                        command.Parameters.AddWithValue("@Model", car.Model);
                        command.Parameters.AddWithValue("@Year", car.Model);
                        command.Parameters.AddWithValue("@Price", car.Model);
                        command.Parameters.AddWithValue("@Power", car.Model);
                        command.Parameters.AddWithValue("@Torque", car.Model);
                        command.Parameters.AddWithValue("@Acceleration", car.Model);
                        command.Parameters.AddWithValue("@Topspeed", car.Model);
                        command.Parameters.AddWithValue("@CarClass", car.Model);
                        command.Parameters.AddWithValue("@Fuel", car.Model);
                        command.Parameters.AddWithValue("@Consumption", car.Model);
                        command.Parameters.AddWithValue("@UserId", car.Model);
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

        public bool Delete(CarDTO car)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "DELETE FROM Cars WHERE Model = (@Model)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Model", car.Model);
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

        public CarDTO Get(int Id)
        {
            CarDTO car = new CarDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Cars WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Id", Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            car.Id = reader.GetInt32(0);
                            car.Brand = reader.GetInt32(1);
                            car.Model = reader.GetString(2);
                            car.Year = reader.GetString(3);
                            car.Price = reader.GetInt32(4);
                            car.Power = reader.GetInt32(5);
                            car.Torque = reader.GetInt32(6);
                            car.Acceleration = reader.GetInt32(7);
                            car.Topspeed = reader.GetInt32(8);
                            car.Class = reader.GetInt32(9);
                            car.Fuel = reader.GetInt32(10);
                            car.FuelConsumption = reader.GetInt32(11);
                            car.UserId = reader.GetInt32(12);
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return car;
        }

        public List<CarDTO> GetAll()
        {
            CarDTO car = new CarDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Cars";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<CarDTO> cars = new List<CarDTO>();
                            while (reader.Read())
                            {
                                car.Id = reader.GetInt32(0);
                                car.Brand = reader.GetInt32(1);
                                car.Model = reader.GetString(2);
                                car.Year = reader.GetString(3);
                                car.Price = reader.GetInt32(4);
                                car.Power = reader.GetInt32(5);
                                car.Torque = reader.GetInt32(6);
                                car.Acceleration = reader.GetInt32(7);
                                car.Topspeed = reader.GetInt32(8);
                                car.Class = reader.GetInt32(9);
                                car.Fuel = reader.GetInt32(10);
                                car.FuelConsumption = reader.GetInt32(11);
                                car.UserId = reader.GetInt32(12);

                                cars.Add(car);
                            }
                            connection.Close();
                            return cars;
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

        public bool Update(CarDTO car)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "UPDATE Cars SET Name = (@Name) WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", car.Model);
                        command.Parameters.AddWithValue("@Id", car.Id);
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

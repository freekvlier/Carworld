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

        public int Create(CarDTO car)
        {
            int id;
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "INSERT INTO Cars (BrandId, Model, Year, Price, Horsepower, Torque, Acceleration, Topspeed, CarClassId, FuelId, FuelConsumption, MadeByUser) Output Inserted.Id " +
                                 " VALUES (@BrandId, @Model, @Year, @Price, @Horsepower, @Torque, @Acceleration, @Topspeed, @CarClassId, @FuelId, @FuelConsumption, @MadeByUser)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@BrandId", car.BrandId);
                        command.Parameters.AddWithValue("@Model", car.Model);
                        command.Parameters.AddWithValue("@Year", car.Year);
                        command.Parameters.AddWithValue("@Price", car.Price);
                        command.Parameters.AddWithValue("@Horsepower", car.Horsepower);
                        command.Parameters.AddWithValue("@Torque", car.Torque);
                        command.Parameters.AddWithValue("@Acceleration", car.Acceleration);
                        command.Parameters.AddWithValue("@Topspeed", car.Topspeed);
                        command.Parameters.AddWithValue("@CarClassId", car.CarClassId);
                        command.Parameters.AddWithValue("@FuelId", car.FuelId);
                        command.Parameters.AddWithValue("@FuelConsumption", car.FuelConsumption);
                        command.Parameters.AddWithValue("@MadeByUser", car.MadeByUser);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            id = reader.GetInt32(0);
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                id = -1;
            }

            return id;
        }

        public bool Delete(int carId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "DELETE FROM Cars WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Id", carId);
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

        public CarDTO Get(int carId)
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
                        command.Parameters.AddWithValue("@Id", carId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            car.Id = reader.GetInt32(0);
                            car.BrandId = reader.GetInt32(1);
                            car.Model = reader.GetString(2);
                            car.Year = reader.GetInt32(3);
                            car.Price = reader.GetInt32(4);
                            car.Horsepower = reader.GetInt32(5);
                            car.Torque = reader.GetInt32(6);
                            car.Acceleration = reader.GetDouble(7);
                            car.Topspeed = reader.GetInt32(8);
                            car.CarClassId = reader.GetInt32(9);
                            car.FuelId = reader.GetInt32(10);
                            car.FuelConsumption = reader.GetDouble(11);
                            car.MadeByUser = reader.GetInt32(12);
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
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Cars ORDER BY BrandId";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<CarDTO> cars = new List<CarDTO>();
                            while (reader.Read())
                            {
                                CarDTO car = new CarDTO
                                {
                                    Id = reader.GetInt32(0),
                                    BrandId = reader.GetInt32(1),
                                    Model = reader.GetString(2),
                                    Year = reader.GetInt32(3),
                                    Price = reader.GetInt32(4),
                                    Horsepower = reader.GetInt32(5),
                                    Torque = reader.GetInt32(6),
                                    Acceleration = reader.GetDouble(7),
                                    Topspeed = reader.GetInt32(8),
                                    CarClassId = reader.GetInt32(9),
                                    FuelId = reader.GetInt32(10),
                                    FuelConsumption = reader.GetDouble(11),
                                    MadeByUser = reader.GetInt32(12)
                                };
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

        public List<CarDTO> GetAllSorted(string property)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Cars ORDER BY ";
                    switch (property)
                    {
                        case "Brand":
                            sql += "BrandId";
                            break;
                        case "Price":
                            sql += "Price DESC";
                            break;
                        case "Horsepower":
                            sql += "Horsepower DESC";
                            break;
                        case "Year":
                            sql += "Year DESC";
                            break;
                        default:
                            sql += "BrandId";
                            break;
                    }
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<CarDTO> cars = new List<CarDTO>();
                            while (reader.Read())
                            {
                                CarDTO car = new CarDTO
                                {
                                    Id = reader.GetInt32(0),
                                    BrandId = reader.GetInt32(1),
                                    Model = reader.GetString(2),
                                    Year = reader.GetInt32(3),
                                    Price = reader.GetInt32(4),
                                    Horsepower = reader.GetInt32(5),
                                    Torque = reader.GetInt32(6),
                                    Acceleration = reader.GetDouble(7),
                                    Topspeed = reader.GetInt32(8),
                                    CarClassId = reader.GetInt32(9),
                                    FuelId = reader.GetInt32(10),
                                    FuelConsumption = reader.GetDouble(11),
                                    MadeByUser = reader.GetInt32(12)
                                };
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
                    string sql = "UPDATE Cars SET BrandId = (@BrandId), Model = (@Model), Year = (@Year)," +
                                 " Price = (@Price), Horsepower = (@Horsepower), Torque = (@Torque)," +
                                 " Acceleration = (@Acceleration), Topspeed = (@Topspeed), CarClassId = (@CarClassId)," +
                                 " FuelId = (@FuelId), FuelConsumption = (@FuelConsumption) WHERE Id = (@Id)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@BrandId", car.BrandId);
                        command.Parameters.AddWithValue("@Model", car.Model);
                        command.Parameters.AddWithValue("@Year", car.Year);
                        command.Parameters.AddWithValue("@Price", car.Price);
                        command.Parameters.AddWithValue("@Horsepower", car.Horsepower);
                        command.Parameters.AddWithValue("@Torque", car.Torque);
                        command.Parameters.AddWithValue("@Acceleration", car.Acceleration);
                        command.Parameters.AddWithValue("@Topspeed", car.Topspeed);
                        command.Parameters.AddWithValue("@CarClassId", car.CarClassId);
                        command.Parameters.AddWithValue("@FuelId", car.FuelId);
                        command.Parameters.AddWithValue("@FuelConsumption", car.FuelConsumption);
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

        public List<CarDTO> SearhModelName(string search)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Cars WHERE Model LIKE CONCAT('%', (@Search), '%') ORDER BY BrandId";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Search", search);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<CarDTO> cars = new List<CarDTO>();
                            while (reader.Read())
                            {
                                CarDTO car = new CarDTO
                                {
                                    Id = reader.GetInt32(0),
                                    BrandId = reader.GetInt32(1),
                                    Model = reader.GetString(2),
                                    Year = reader.GetInt32(3),
                                    Price = reader.GetInt32(4),
                                    Horsepower = reader.GetInt32(5),
                                    Torque = reader.GetInt32(6),
                                    Acceleration = reader.GetDouble(7),
                                    Topspeed = reader.GetInt32(8),
                                    CarClassId = reader.GetInt32(9),
                                    FuelId = reader.GetInt32(10),
                                    FuelConsumption = reader.GetDouble(11),
                                    MadeByUser = reader.GetInt32(12)
                                };
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
    }
}

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

        public bool Create(FuelDTO brandstof)
        {
            return false;
        }

        public bool Delete(FuelDTO brandstof)
        {
            return false;
        }

        public FuelDTO Get(int Id)
        {
            return new FuelDTO();
        }

        public List<FuelDTO> GetAll()
        {
            List<FuelDTO> brandstoffen = new List<FuelDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string sql = "SELECT * FROM Brandstoffen";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                FuelDTO brandstof = new FuelDTO();
                                brandstof.Id = reader.GetInt32(0);
                                brandstof.Name = reader.GetString(1);

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

        public bool Update(FuelDTO brandstof)
        {
            throw new NotImplementedException();
        }
    }
}

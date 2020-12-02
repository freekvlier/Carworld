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
            throw new NotImplementedException();
        }

        public bool Delete(BrandDTO brand)
        {
            throw new NotImplementedException();
        }

        public BrandDTO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<BrandDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(BrandDTO brand)
        {
            throw new NotImplementedException();
        }

        public List<BrandDTO> readBrandsFromDatabase()
        {
           try
           {
               using (SqlConnection connection = new SqlConnection(sqlConnectionString))
               {
                   string sql = "SELECT * FROM Merken";
                   using (SqlCommand command = new SqlCommand(sql, connection))
                   {
                       connection.Open();
                       using (SqlDataReader reader = command.ExecuteReader())
                       {
                           List<BrandDTO> brands = new List<BrandDTO>();
                           while (reader.Read())
                           {
                               BrandDTO brand = new BrandDTO();
                               brand.Id = reader.GetInt32(0);
                               brand.Name = reader.GetString(1);
                               brand.Origin = reader.GetString(2);

                               brands.Add(brand);
                           }
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
    }
}

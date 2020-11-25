using System;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class Class1
    {
        public void test()
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server=mssql.fhict.local;Database=dbi454449;User Id=dbi454449;Password=454449ICT;");
                connection.Open();

                string SQL = "SELECT * FROM Persons";
                SqlCommand command = new SqlCommand(SQL, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("SUCCESS-----------------------------");
                    Console.WriteLine(reader["FirstName"]);
                    Console.WriteLine("SUCCESS-----------------------------");
                }
            }
            catch (SqlException error)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine(error);
                Console.WriteLine("-----------------------------");
            }


        }
    }
}

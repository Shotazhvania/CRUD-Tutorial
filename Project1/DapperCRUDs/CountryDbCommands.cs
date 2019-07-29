using Project1.Work;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Project1.DapperCRUDs
{
    public static class CountryDbCommands
    {
        const string connectionString = @"Data Source=localhost;Initial Catalog=Project1Data; Integrated Security=true";

        //CRUD of Country
        public static List<Country> GetCountry()
        {
            string sqlString = @"
SELECT [ID], [Name], [AnimalsName], [Area]
FROM [Country]
";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                List<Country> countries = connection.Query<Country>(sqlString).ToList();

                return countries;
            }

        }
        public static void InsertCountry(Country country)
        {
            string query = "INSERT INTO  dbo.Country(Name,AnimalsName, Area) VALUES(@Name,@AnimalsName,@Area)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                cn.Execute(query, country);
            }
        }

        public static void UpdateCountry(Country country)
        {
            string query = "UPDATE Country SET Name = @NewName, AnimalsName = @AnimalsName, Area = @Area WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Execute(query, country);
            }
        }

        public static void DeleteCountry(int ID)
        {

            string query = "DELETE FROM Country WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Execute(query, new { ID });
            }
        }
    }
}

using Project1.Work;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Project1.ADONetCRUDs
{
    public  class CountryDbCommands : CRUDInterfaces.ICountryCRUD
    {

        const string connectionString = @"Data Source=localhost;Initial Catalog=Project1Data; Integrated Security=true";

        //CRUD of Country
        public  List<Country> GetTests()
        {
            string sqlString = @"
SELECT [ID], [Name], [AnimalsName], [Area]
FROM [Country]
";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlString, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Country> countries = new List<Country>();
                while (reader.Read())
                {
                    Country country = new Country
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Name = reader["Name"].ToString(),
                        AnimalsName = reader["AnimalsName"].ToString(),
                        Area = int.Parse(reader["Area"].ToString()),
                    };
                    countries.Add(country);

                }
                return countries;

            }

        }
        public  void InsertData(Country country)
        {
            string query = "INSERT INTO  dbo.Country(Name,AnimalsName, Area) VALUES(@Name,@AnimalsName,@Area)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Name", country.Name);
                cmd.Parameters.AddWithValue("@AnimalsName", country.AnimalsName);
                cmd.Parameters.AddWithValue("@Area", country.Area);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public  void UpdateData(int oldID, Country country)
        {
            string query = "UPDATE Country SET Name = @NewName, AnimalsName = @AnimalsName, Area = @Area WHERE ID = @oldID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@oldID", oldID);
                cmd.Parameters.AddWithValue("@NewName", country.Name);
                cmd.Parameters.AddWithValue("@AnimalsName", country.AnimalsName);
                cmd.Parameters.AddWithValue("@Area", country.Area);
                connection.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public  void DeleteData(int ID)
        {

            string query = "DELETE FROM Country WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}

using Project1.Work;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;


namespace Project1.DapperCRUDs
{
    public static class AppartmentDbCommands
    {
        const string connectionString = @"Data Source=localhost;Initial Catalog=Project1Data; Integrated Security=true";

        //CRUD of Building
        public static List<Appartment> GetTests2()
        {
            string sqlString = @"
SELECT [ID], [AppartmentNo], [Area]
FROM [Appartament]
";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlString, connection);

                connection.Open();

                List<Appartment> appartments = connection.Query<Appartment>(sqlString).ToList();

                return appartments;

            }

        }
        public static void InsertData(Appartment appartment)
        {
            string query = "INSERT INTO  dbo.Appartament(AppartmentNo,Area) VALUES(@AppartmentNo,@Area)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            
            {
                
                cn.Open();
                cn.Execute(query, appartment);
                cn.Close();
            }
        }
        public static void UpdateData(int oldID, Appartment appartment)
        {
            string query = "UPDATE Appartament SET AppartmentNo = @NewAppartmentNo, Are = @Area, HumansName = @HumansName BirthDate = @BirthDate WHERE ID = @oldID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            
            {
              
                connection.Open();

                connection.Execute(query, appartment);

            }
        }
        public static void DeleteData2(int ID)
        {

            string query = "DELETE FROM Appartament WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            
            {
                
                connection.Open();
                connection.Execute(query, new { ID });

            }
        }
    }
}

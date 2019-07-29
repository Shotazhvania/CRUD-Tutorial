using Project1.Work;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Project1.DapperCRUDs
{
    public static class BuildingDbCommands
    {
        const string connectionString = @"Data Source=localhost;Initial Catalog=Project1Data; Integrated Security=true";

        //CRUD of Building
        public static List<Building> GetBuilding()
        {
            string sqlString = @"
SELECT [ID], [Address], [AnimalsName], [BuildDate]
FROM [Building]
";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlString, connection);

                connection.Open();

                List<Building> buildings = connection.Query<Building>(sqlString).ToList();           
                return buildings;

            }

        }
        public static void InsertBuilding(Building building)
        {
            string query = "INSERT INTO  dbo.Building(Address,AnimalsName, BuildDate) VALUES(@Address,@AnimalsName,@BuildDate)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            
            {
                
                cn.Open();
                cn.Execute(query, building);
            }
        }
        public static void UpdateBuilding(int oldID, Building building)
        {
            string query = "UPDATE Building SET Address = @NewAddress, AnimalsName = @AnimalsName, BuildDate = @BuildDate WHERE ID = @oldID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            
            {
                
                connection.Open();

                connection.Execute(query, building);

            }
        }
        public static void DeleteBuilding(int ID)
        {

            string query = "DELETE FROM Building WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                connection.Execute(query, new { ID });

            }
        }
    }    
}

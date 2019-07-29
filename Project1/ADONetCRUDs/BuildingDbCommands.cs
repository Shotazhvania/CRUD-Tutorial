using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Project1.ADONetCRUDs
{
    public  class BuildingDbCommands : CRUDInterfaces.IBuildingCRUD
    {
        const string connectionString = @"Data Source=localhost;Initial Catalog=Project1Data; Integrated Security=true";

        //CRUD of Building
        public  List<Building> GetBuilding()
        {
            string sqlString = @"
SELECT [ID], [Address], [AnimalsName], [BuildDate]
FROM [Building]
";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlString, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Building> buildings = new List<Building>();
                while (reader.Read())
                {
                    Building building = new Building
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Address = reader["Address"].ToString(),
                        AnimalsName = reader["AnimalsName"].ToString(),
                        BuildDate = Convert.ToDateTime(reader["BuildDate"].ToString()),
                    };
                    buildings.Add(building);

                }
                return buildings;

            }

        }
        public  void InsertBuilding(Building building)
        {
            string query = "INSERT INTO  dbo.Building(Address,AnimalsName, BuildDate) VALUES(@Address,@AnimalsName,@BuildDate)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Address", building.Address);
                cmd.Parameters.AddWithValue("@AnimalsName", building.AnimalsName);
                cmd.Parameters.AddWithValue("@BuildDate", building.BuildDate);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public  void UpdateBuilding(int oldID, Building building)
        {
            string query = "UPDATE Building SET Address = @NewAddress, AnimalsName = @AnimalsName, BuildDate = @BuildDate WHERE ID = @oldID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@oldID", oldID);
                cmd.Parameters.AddWithValue("@NewAddress", building.Address);
                cmd.Parameters.AddWithValue("@AnimalsName", building.AnimalsName);
                cmd.Parameters.AddWithValue("@BuildDate", building.BuildDate);
                connection.Open();

                cmd.ExecuteNonQuery();

            }
        }
        public  void DeleteBuilding(int ID)
        {

            string query = "DELETE FROM Building WHERE ID = @ID";
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

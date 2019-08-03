using System;
using Project1;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Project1.ADONetCRUDs
{
    public class AppartmentDbCommands : CRUDInterfaces.IAppartmentCRUD
    {
        const string connectionString = @"Data Source=localhost;Initial Catalog=Project1Data; Integrated Security=true";
        //CRUD of Appartment
        public List<Appartment> GetAppartment()
        {
            string sqlString = @"
SELECT [ID], [AppartmentNo], [Area]
FROM [Appartment]
";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlString, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Appartment> appartments = new List<Appartment>();
                while (reader.Read())
                {
                    Appartment appartment = new Appartment
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        AppartmentNo = int.Parse(reader["AppartmentNo"].ToString()),
                        Area = int.Parse(reader["Area"].ToString()),
                    };
                    appartment.Humans =  new HumanDbCommands().GetHumansByApartment(appartment.ID);

                    appartments.Add(appartment);

                }
                return appartments;

            }

        }
        public void InsertAppartment(Appartment appartment)
        {
            string query = "INSERT INTO  dbo.Appartment(AppartmentNo,Area) VALUES(@AppartmentNo,@Area)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@AppartmentNo", appartment.AppartmentNo);
                cmd.Parameters.AddWithValue("@Area", appartment.Area);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public void UpdateAppartment(int oldID, Appartment appartment)
        {
            string query = "UPDATE Appartment SET AppartmentNo = @NewAppartmentNo, Area = @Area WHERE ID = @oldID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@oldID", oldID);
                cmd.Parameters.AddWithValue("@NewAppartmentNo", appartment.AppartmentNo);
                cmd.Parameters.AddWithValue("@Area", appartment.Area);
                connection.Open();

                cmd.ExecuteNonQuery();

            }
        }
        public void DeleteAppartment(int ID)
        {

            string query = "DELETE FROM Appartment WHERE ID = @ID";
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

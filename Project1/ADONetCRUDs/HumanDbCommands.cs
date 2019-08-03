using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Project1.ADONetCRUDs
{
    public  class HumanDbCommands : CRUDInterfaces.IHumanCRUD
    {
        const string connectionString = @"Data Source=localhost;Initial Catalog=Project1Data; Integrated Security=true";

        //CRUD of Human
        public  List<Human> GetHumansByApartment(int appartmentId)
        {
            string sqlString = @"
SELECT [Id], [Name], [BirthDate], [AppartmentId]
FROM [Human]
WHERE [AppartmentId] = @AppartmentId
";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@AppartmentId", appartmentId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Human> humans = new List<Human>();
                while (reader.Read())
                {
                    Human human = new Human
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"].ToString()),
                        AppartmentId = int.Parse(reader["AppartmentId"].ToString()),
                    };
                    humans.Add(human);

                }
                return humans;

            }
        }
        public  List<Human> GetHumans()
        {
            string sqlString = @"
SELECT [Id], [Name], [BirthDate], [AppartmentId]
FROM [Human]
";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlString, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Human> humans = new List<Human>();
                while (reader.Read())
                {
                    Human human = new Human
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"].ToString()),
                        AppartmentId = int.Parse(reader["AppartmentId"].ToString()),
                    };
                    humans.Add(human);

                }
                return humans;

            }

        }
        public  void InsertHuman(Human human)
        {
            string query = "INSERT INTO  dbo.Human(Name,BirthDate, AppartmentId) VALUES(@Name,@BirthDate,@AppartmentId)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Name", human.Name);
                cmd.Parameters.AddWithValue("@BirthDate", human.BirthDate);
                cmd.Parameters.AddWithValue("@AppartmentId", human.AppartmentId);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public  void UpdateHuman(int oldiD, Human human)
        {
            string query = "UPDATE Human SET Name = @NewName, BirthDate = @BirthDate, AppartmentId = @AppartmentId WHERE ID = @oldiD";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@oldiD", oldiD);
                cmd.Parameters.AddWithValue("@NewName", human.Name);
                cmd.Parameters.AddWithValue("@BirthDate", human.BirthDate);
                cmd.Parameters.AddWithValue("@AppartmentId", human.AppartmentId);
                connection.Open();

                cmd.ExecuteNonQuery();

            }
        }
        public  void DeleteHuman(int id)
        {
            string query = "DELETE FROM Human WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}

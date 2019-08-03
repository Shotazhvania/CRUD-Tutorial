using Project1.Work;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
namespace Project1.DapperCRUDs
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
                List<Human> humans = connection.Query<Human>(sqlString).ToList();
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
                List<Human> humans = connection.Query<Human>(sqlString).ToList();
                return humans;

            }

        }
        public  void InsertHuman(Human human)
        {
            string query = "INSERT INTO  dbo.Human(Name,BirthDate, AppartmentId) VALUES(@Name,@BirthDate,@AppartmentId)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            
            {
                
                cn.Open();
                cn.Execute(query, human);
            }
        }
        public  void UpdateHuman(int oldiD, Human human)
        {
            string query = "UPDATE Human SET Name = @NewName, BirthDate = @BirthDate, AppartmentId = @AppartmentId WHERE ID = @oldiD";
            using (SqlConnection connection = new SqlConnection(connectionString))          
            {
                connection.Open();

                connection.Execute(query, human);
            }
        }
        public  void DeleteHuman(int id)
        {
            string query = "DELETE FROM Human WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            
            {
                
                connection.Open();
                connection.Execute(query, new { id });

            }
        }
    }
}

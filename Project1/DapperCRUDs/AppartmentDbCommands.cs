using Project1.Work;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;


namespace Project1.DapperCRUDs
{
    public  class AppartmentDbCommands : CRUDInterfaces.IAppartmentCRUD
    {
        const string connectionString = @"Data Source=localhost;Initial Catalog=Project1Data; Integrated Security=true";

        //CRUD of Building
        public  List<Appartment> GetAppartment()
        {
            string sqlString = @"
SELECT [ID], [AppartmentNo], [Area]
FROM [Appartment]
";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlString, connection);
                 
                connection.Open();
  
                List<Appartment> appartments = connection.Query<Appartment>(sqlString).ToList();

                return appartments;

            }

        }
        public  void InsertAppartment(Appartment appartment)
        {
            string query = "INSERT INTO  dbo.Appartment(AppartmentNo,Area) VALUES(@AppartmentNo,@Area)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            
            {
                
                cn.Open();
                cn.Execute(query, appartment);
                cn.Close();
            }
        }
        public  void UpdateAppartment(int oldID, Appartment appartment)
        {
            string query = "UPDATE Appartament SET AppartmentNo = @NewAppartmentNo, Are = @Area, HumansName = @HumansName BirthDate = @BirthDate WHERE ID = @oldID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            
            {
              
                connection.Open();

                connection.Execute(query, appartment);

            }
        }
        public  void DeleteAppartment(int ID)
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

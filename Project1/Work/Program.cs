using System;
using System.Collections.Generic;
using Project1.Work;
using System.Data.SqlClient;

namespace Project1
{
    public class Program
    {
        const string connectionString = @"Data Source=localhost;Initial Catalog=Project1Data; Integrated Security=true";
        public static void Main(string[] args)
        {
            bool Numb2 = true;
            while (Numb2)
            {
                Console.WriteLine("Which information Do you want to fill? : Country(1), Building(2), Appartment(3), Human(4)");
                int Number;
                Number = int.Parse(Console.ReadLine());
                switch (Number)
                {
                    case 1:
                        ProcessCountry();
                        break;

                    case 2:
                        ProcessBuilding();
                        break;

                    case 3:
                        ProcessAppartment();
                        break;
                    case 4:
                        ProcessHumans();
                        break;
                    default:
                        Console.WriteLine("Nothing Info Found !!!");
                        break;

                }
            }
            Console.ReadKey();
        }

        private static void ProcessCountry() 
        {
            bool work = true;
            while (work)
            {
                Console.WriteLine("Choose which process Do you want in Country database : Insert(1), Update(2), Delete(3), Read(4), Exit(5)");
                int Num;
                Num = Int32.Parse(Console.ReadLine());

                switch (Num)
                {
                    case 1:
                        //InsertCountry
                        Console.WriteLine("Enter Country : Name, AnimalsName, Area :");
                        Country toAdd = new Country
                        {
                            Name = Console.ReadLine(),
                            AnimalsName = Console.ReadLine(),
                            Area = int.Parse(Console.ReadLine())
                        };
                        InsertData(toAdd);
                        break;
                    case 2:
                        //UpdateCountry
                        Console.WriteLine("Enter ID We Found in Database  and after write New Name, AnimalsName and  Area for Update :");
                        int ID = int.Parse(Console.ReadLine());

                        Country toUpdate = new Country
                        {
                            Name = Console.ReadLine(),
                            AnimalsName = Console.ReadLine(),
                            Area = int.Parse(Console.ReadLine())
                        };
                        UpdateData(ID, toUpdate);
                        break;

                    case 3:
                        //DeleteCountry
                        Console.WriteLine("Which ID information do you want to Delete ?");
                        Country toDelete = new Country
                        {
                            ID = int.Parse(Console.ReadLine()),

                        };
                        DeleteData(toDelete.ID);
                        break;

                    case 4:

                        // ReadCountry
                        List<Country> countries = GetTests();
                        foreach (Country country in countries)
                        {
                            Console.WriteLine(country.Description);
                        }
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("You Leave Country Process ");
                        work = false;
                        break;

                }
            }

        }

        private static void ProcessBuilding()
        {
            bool Numb1 = true;
            while (Numb1)
            {
                Console.WriteLine("Choose which process Do you want in Building database : Insert(1), Update(2), Delete(3), Read(4), Exit(5)");
                int Numb;
                Numb = Int32.Parse(Console.ReadLine());
                switch (Numb)
                {
                    case 1:
                        //InsertBuilding
                        Console.WriteLine("Enter Building : Address, AnimalsName, BuildDate :");
                        Building toAdd = new Building
                        {
                            Address = Console.ReadLine(),
                            AnimalsName = Console.ReadLine(),
                            BuildDate = Convert.ToDateTime(Console.ReadLine())
                        };
                        InsertData(toAdd);
                        break;
                    case 2:
                        //UpdateBuilding
                        Console.WriteLine("Enter ID We Found in Database  and after write New Address, AnimalsName and  BuildDate for Update :");
                        int ID = int.Parse(Console.ReadLine());

                        Building toUpdate = new Building
                        {
                            Address = Console.ReadLine(),
                            AnimalsName = Console.ReadLine(),
                            BuildDate = Convert.ToDateTime(Console.ReadLine())
                        };
                        UpdateData(ID, toUpdate);
                        break;
                    case 3:
                        //DeleteBuilding
                        Console.WriteLine("Which ID information do you want to Delete ?");
                        Building toDelete = new Building
                        {
                            ID = int.Parse(Console.ReadLine()),

                        };
                        DeleteData1(toDelete.ID);
                        break;
                    case 4:

                        // ReadBuilding
                        List<Building> buildings = GetTests1();
                        foreach (Building building in buildings)
                        {
                            Console.WriteLine(building.Description);
                        }
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("You leave Building Process ");
                        Numb1 = false;
                        break;

                }
            }

        }

        private static void ProcessAppartment()
        {
            bool Numb3 = true;
            while (Numb3)
            {
                Console.WriteLine("Choose which process Do you want in Appartament database : Insert(1), Update(2), Delete(3), Read(4), Exit(5)");
                int Numb;
                Numb = Int32.Parse(Console.ReadLine());
                switch (Numb)
                {
                    case 1:
                        //InsertAppartament
                        Console.WriteLine("Enter Appartament : AppartamentNo, Area :");
                        Appartment toAdd = new Appartment
                        {
                            AppartmentNo = int.Parse(Console.ReadLine()),
                            Area = int.Parse(Console.ReadLine()),
                        };
                        InsertData(toAdd);
                        break;
                    case 2:
                        //UpdateAppartament
                        Console.WriteLine("Enter ID We Found in Database  and after write New AppartamentNo, Area, HumansName and BirthDate for Update :");
                        int ID = int.Parse(Console.ReadLine());

                        Appartment toUpdate = new Appartment
                        {
                            ID = int.Parse(Console.ReadLine()),
                            AppartmentNo = int.Parse(Console.ReadLine()),
                            Area = int.Parse(Console.ReadLine()),
                        };
                        UpdateData(ID, toUpdate);
                        break;
                    case 3:
                        //DeleteAppartament
                        Console.WriteLine("Which ID information do you want to Delete ?");
                        Appartment toDelete = new Appartment
                        {
                            ID = int.Parse(Console.ReadLine()),

                        };
                        DeleteData2(toDelete.ID);
                        break;
                    case 4:

                        // ReadAppartament
                        List<Appartment> appartments = GetTests2();
                        foreach (Appartment appartment in appartments)
                        {
                            Console.WriteLine(appartment.Description);
                        }
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("You leave Appartment Process ");
                        Numb3 = false;
                        break;

                }
            }
        }

        private static void ProcessHumans()
        {
            bool work = true;
            while (work)
            {
                Console.WriteLine("Choose which process Do you want in Humans database : Insert(1), Update(2), Delete(3), Read(4), Exit(5)");
                int Num;
                Num = Int32.Parse(Console.ReadLine());

                switch (Num)
                {
                    case 1:
                        //InsertHuman
                        Console.WriteLine("Enter Humans : Name, BirthDate, AppartmentId :");
                        Human toAdd = new Human
                        {
                            Name = Console.ReadLine(),
                            BirthDate = Convert.ToDateTime(Console.ReadLine()),
                            AppartmentId = int.Parse(Console.ReadLine())
                        };
                        InsertHuman(toAdd);
                        break;
                    case 2:
                        //UpdateHuman
                        Console.WriteLine("Enter ID We Found in Database  and after write New Name, BirthDate and  AppartmentId for Update :");
                        int ID = int.Parse(Console.ReadLine());

                        Human toUpdate = new Human
                        {
                            Name = Console.ReadLine(),
                            BirthDate = Convert.ToDateTime(Console.ReadLine()),
                            AppartmentId = int.Parse(Console.ReadLine())
                        };
                        UpdateHuman(ID, toUpdate);
                        break;

                    case 3:
                        //DeleteHuman
                        Console.WriteLine("Which ID information do you want to Delete ?");
                        Human toDelete = new Human
                        {
                            Id = int.Parse(Console.ReadLine()),

                        };
                        DeleteHuman(toDelete.Id);
                        break;

                    case 4:

                        // ReadHuman
                        List<Human> humans = GetHumans();
                        foreach (Human human in humans)
                        {
                            Console.WriteLine(human.Description);
                        }
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("You Leave Human Process ");
                        work = false;
                        break;

                }
            }
        }


        //CRUD of Human
        private static List<Human> GetHumansByApartment(int appartmentId)
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
        private static List<Human> GetHumans()
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
        private static void InsertHuman(Human human)
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
        private static void UpdateHuman(int oldiD, Human human)
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
        private static void DeleteHuman(int id)
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

        //CRUD of Country
        private static List<Country> GetTests()
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
        private static void InsertData(Country country)
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
        private static void UpdateData(int oldID, Country country)
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
        private static void DeleteData(int ID)
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

        //CRUD of Building
        private static List<Building> GetTests1()
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
        private static void InsertData(Building building)
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
        private static void UpdateData(int oldID, Building building)
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
        private static void DeleteData1(int ID)
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

        //CRUD of Appartament
        private static List<Appartment> GetTests2()
        {
            string sqlString = @"
SELECT [ID], [AppartmentNo], [Area]
FROM [Appartament]
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
                    appartment.Humans = GetHumansByApartment(appartment.ID);

                    appartments.Add(appartment);

                }
                return appartments;

            }

        }
        private static void InsertData(Appartment appartment)
        {
            string query = "INSERT INTO  dbo.Appartament(AppartmentNo,Area) VALUES(@AppartmentNo,@Area)";
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
        private static void UpdateData(int oldID, Appartment appartment)
        {
            string query = "UPDATE Appartament SET AppartmentNo = @NewAppartmentNo, Are = @Area, HumansName = @HumansName BirthDate = @BirthDate WHERE ID = @oldID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@oldID", oldID);
                cmd.Parameters.AddWithValue("@NewAppartmentNo", appartment.AppartmentNo);
                cmd.Parameters.AddWithValue("@Area", appartment.Area);
                // cmd.Parameters.AddWithValue("@HumansName", appartment.HumansName);
                //cmd.Parameters.AddWithValue("@BirthDate", appartment.BirthDate);
                connection.Open();

                cmd.ExecuteNonQuery();

            }
        }
        private static void DeleteData2(int ID)
        {

            string query = "DELETE FROM Appartament WHERE ID = @ID";
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
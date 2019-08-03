using System;
using System.Collections.Generic;
using Project1.Work;
using System.Data.SqlClient;
using Project1.ADONetCRUDs;
using Project1.DapperCRUDs;

namespace Project1
{
    public static class Program
    {
        const string connectionString = @"Data Source=localhost;Initial Catalog=Project1Data; Integrated Security=true";

        static CRUDInterfaces.IAppartmentCRUD appartmentDb = new ADONetCRUDs.AppartmentDbCommands();
        static CRUDInterfaces.IBuildingCRUD buildingtDb = new ADONetCRUDs.BuildingDbCommands();
        static CRUDInterfaces.ICountryCRUD  countrytDb = new ADONetCRUDs.CountryDbCommands();
        static CRUDInterfaces.IHumanCRUD humantDb = new DapperCRUDs.HumanDbCommands();

        public static void Main(string[] args)
        {
            bool Numb2 = true;
            while (Numb2)
            {
                try
                {
                    Console.WriteLine("Which information Do you want to fill? : Country(1), Building(2), Appartment(3), Human(4), Exit(5)");
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
                            Console.WriteLine("Exit !");
                            break;
                    }
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);

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
                        countrytDb.InsertCountry(toAdd);
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
                        countrytDb.UpdateCountry(ID, toUpdate);
                        break;

                    case 3:
                        //DeleteCountry
                        Console.WriteLine("Which ID information do you want to Delete ?");
                        Country toDelete = new Country
                        {
                            ID = int.Parse(Console.ReadLine()),

                        };
                        countrytDb.DeleteCountry(toDelete.ID);
                        break;

                    case 4:

                        // ReadCountry
                        List<Country> countries = countrytDb.GetCountry();
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
                        buildingtDb.InsertBuilding(toAdd);
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
                        buildingtDb.UpdateBuilding(ID, toUpdate);
                        break;
                    case 3:
                        //DeleteBuilding
                        Console.WriteLine("Which ID information do you want to Delete ?");
                        Building toDelete = new Building
                        {
                            ID = int.Parse(Console.ReadLine()),

                        };
                        buildingtDb.DeleteBuilding(toDelete.ID);
                        break;
                    case 4:

                        // ReadBuilding
                        List<Building> buildings = buildingtDb.GetBuilding();
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
                        appartmentDb.InsertAppartment(toAdd);
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
                        appartmentDb.UpdateAppartment(ID, toUpdate);
                        break;
                    case 3:
                        //DeleteAppartament
                        Console.WriteLine("Which ID information do you want to Delete ?");
                        Appartment toDelete = new Appartment
                        {
                            ID = int.Parse(Console.ReadLine()),

                        };
                        appartmentDb.DeleteAppartment(toDelete.ID);
                        break;
                    case 4:

                        // ReadAppartament
                        List<Appartment> appartments = appartmentDb.GetAppartment();
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
                        humantDb.InsertHuman(toAdd);
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
                        humantDb.UpdateHuman(ID, toUpdate);
                        break;

                    case 3:
                        //DeleteHuman
                        Console.WriteLine("Which ID information do you want to Delete ?");
                        Human toDelete = new Human
                        {
                            Id = int.Parse(Console.ReadLine()),

                        };
                        humantDb.DeleteHuman(toDelete.Id);
                        break;

                    case 4:

                        // ReadHuman
                        List<Human> humans = humantDb.GetHumans();
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

    }
}
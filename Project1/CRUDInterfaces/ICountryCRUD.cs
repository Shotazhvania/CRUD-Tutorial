using Project1.Work;
using System.Collections.Generic;

namespace Project1.CRUDInterfaces
{
    interface ICountryCRUD
    {
        List<Country> GetCountry();
        void InsertCountry(Country country);

        void UpdateCountry(int iD, Country country);

        void DeleteCountry(int ID);
    }
}

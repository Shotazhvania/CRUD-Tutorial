using Project1.Work;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.CRUDInterfaces
{
    interface ICountryCRUD
    {
        List<Country> GetTests();
        void InsertData(Country country);

        void UpdateData(int oldID, Country country);

        void DeleteData(int ID);
    }
}

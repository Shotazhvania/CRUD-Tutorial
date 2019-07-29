using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.CRUDInterfaces
{
    interface IAppartmentCRUD
    {
        List<Appartment> GetTests2();
        void InsertData(Appartment appartment);
        void UpdateData(int oldID, Appartment appartment);
        void DeleteData2(int ID);
    }
}

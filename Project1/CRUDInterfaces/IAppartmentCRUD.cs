using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.CRUDInterfaces
{
    interface IAppartmentCRUD
    {
        List<Appartment> GetAppartment();
        void InsertAppartment(Appartment appartment);
        void UpdateAppartment(int oldID, Appartment appartment);
        void DeleteAppartment(int ID);
    }
}

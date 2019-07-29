using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.CRUDInterfaces
{
    interface IBuildingCRUD
    {
        List<Building> GetBuilding();
        void InsertBuilding(Building building);
        void UpdateBuilding(int oldID, Building building);
        void DeleteBuilding(int ID);
    }
}

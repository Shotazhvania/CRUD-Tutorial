using System.Collections.Generic;

namespace Project1.CRUDInterfaces
{
    interface IHumanCRUD
    {
        List<Human> GetHumansByApartment(int appartmentId);
        List<Human> GetHumans();
        void InsertHuman(Human human);
        void UpdateHuman(int oldiD, Human human);
        void DeleteHuman(int id);
    }
}

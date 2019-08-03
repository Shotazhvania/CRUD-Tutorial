using System.Collections.Generic;

namespace Project1
{
    public class Appartment
    {
        public int ID { get; set; }
        public int AppartmentNo { get; set; }
        public int Area { get; set; }
        public List<Human> Humans { get; set; } = new List<Human>();
        public string Description
        {
            get
            {
                string description = $"{ID} {AppartmentNo} {Area}";
                foreach (Human human in Humans)
                {
                    description += $"\n\t{human.Description}";
                }
                return description;
            }
        }
    }
}
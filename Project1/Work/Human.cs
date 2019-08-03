using System;

namespace Project1
{
    public class Human
    {
        public int Id { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public int AppartmentId { get; set; }

        public string Description
        {
            get
            {
                string description = $"{Id} {Name} {BirthDate.ToShortDateString()} {AppartmentId}";
                return description;
            }
        }
    }
}

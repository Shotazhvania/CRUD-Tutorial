using System;
namespace Project1
{

    public class Building
    {
        public int ID { get; set; }
        public string Address { get; internal set; }
        public string AnimalsName { get; set; }
        public DateTime BuildDate { get; internal set; }
        public Appartment[] Appartments { get; internal set; }

        public string Description
        {
            get
            {
                return $"{ID} {Address} {AnimalsName} {BuildDate}";
            }
        }
    }
}
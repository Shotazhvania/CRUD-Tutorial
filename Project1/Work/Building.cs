using System;
using System.Collections.Generic;

namespace Project1
{

    public class Building
    {
        public List<Building> buildings;

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
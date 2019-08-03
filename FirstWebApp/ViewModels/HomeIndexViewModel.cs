using Project1;
using Project1.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Building> Buildings { get; set; }
        public List<Country> Countries { get; set; }
        public List<Appartment> Appartments { get; set; }
        public List<Human> Humen { get; set; }
    }
}

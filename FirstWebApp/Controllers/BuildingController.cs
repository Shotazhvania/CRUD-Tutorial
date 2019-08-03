using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1;
using Project1.DapperCRUDs;

namespace FirstWebApp.Controllers
{
    public class BuildingController : Controller
    {
        public class WrapperBuilding
        {
            public List<Building> Buildings { get; set; }
        }

        public IActionResult GetBuilding()
        {
            List<Building> buildings = BuildingDbCommands.GetBuilding();
            return Json(buildings);
        }

        public IActionResult IndexBuilding()
        {
            List<Building> buildings = BuildingDbCommands.GetBuilding();
            return View(new Building
            {
                buildings = buildings

            });

        }
    }
}
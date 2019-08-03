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
        //Building
        public IActionResult GetBuilding()
        {
            List<Building> buildings = new BuildingDbCommands().GetBuilding();
            return Json(buildings);
        }

        public IActionResult List()
        {
            List<Building> buildings = new BuildingDbCommands().GetBuilding();
            return View(buildings);

        }
        public IActionResult Details(int id)
        {
            List<Building> buildings = new BuildingDbCommands().GetBuilding();
            Building building = buildings.First(a => a.ID == id);
            return View(building);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<Building> buildings = new BuildingDbCommands().GetBuilding();
            Building building = buildings.First(a => a.ID == id);
            return View(building);
        }

        [HttpPost]
        public IActionResult Edit(Building app)
        {
            new BuildingDbCommands().UpdateBuilding(app.ID, app);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            new BuildingDbCommands().DeleteBuilding(id);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Building building)
        {
            new BuildingDbCommands().InsertBuilding(building);
            return RedirectToAction("List");
        }
    }
}
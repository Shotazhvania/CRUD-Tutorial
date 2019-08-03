using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1;
using Project1.DapperCRUDs;

namespace FirstWebApp.Controllers
{
    public class AppartmentController : Controller
    {
        public IActionResult GetAppartment()
        {
            List<Appartment> appartments = new AppartmentDbCommands().GetAppartment();
            return Json(appartments);
        }

        public IActionResult List()
        {
            List<Appartment> appartments = new AppartmentDbCommands().GetAppartment();
            return View(appartments);

        }
        public IActionResult Details(int id)
        {
            List<Appartment> appartments =  new AppartmentDbCommands().GetAppartment();
            Appartment appartment = appartments.First(a => a.ID == id);
            return View(appartment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<Appartment> appartments = new AppartmentDbCommands().GetAppartment();
            Appartment appartment = appartments.First(a => a.ID == id);
            return View(appartment);
        }

        [HttpPost]
        public IActionResult Edit(Appartment app)
        {
            new Project1.ADONetCRUDs.AppartmentDbCommands().UpdateAppartment(app.ID, app);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            new Project1.ADONetCRUDs.AppartmentDbCommands().DeleteAppartment(id);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appartment appartment)
        {
            new Project1.ADONetCRUDs.AppartmentDbCommands().InsertAppartment(appartment);
            return RedirectToAction("List");
        }
    }
}
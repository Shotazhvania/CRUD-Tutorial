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
        public IActionResult GetGetTests2()
        {
            List<Appartment> appartments = AppartmentDbCommands.GetTests2();
            return Json(appartments);
        }

        public IActionResult List()
        {
            List<Appartment> appartments = AppartmentDbCommands.GetTests2();
            return View(appartments);

        }
        public IActionResult Details(int id)
        {
            List<Appartment> appartments = AppartmentDbCommands.GetTests2();
            Appartment appartment = appartments.First(a => a.ID == id);
            return View(appartment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<Appartment> appartments = AppartmentDbCommands.GetTests2();
            Appartment appartment = appartments.First(a => a.ID == id);
            return View(appartment);
        }

        [HttpPost]
        public IActionResult Edit(Appartment app)
        {
            new Project1.ADONetCRUDs.AppartmentDbCommands().UpdateData(app.ID, app);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            new Project1.ADONetCRUDs.AppartmentDbCommands().DeleteData2(id);
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
            new Project1.ADONetCRUDs.AppartmentDbCommands().InsertData(appartment);
            return RedirectToAction("List");
        }
    }
}
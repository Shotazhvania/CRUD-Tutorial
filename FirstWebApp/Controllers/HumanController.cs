using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1;
using Project1.ADONetCRUDs;
using Project1.DapperCRUDs;
using HumanDbCommands = Project1.ADONetCRUDs.HumanDbCommands;

namespace FirstWebApp.Controllers
{
    //Human
    public class HumanController : Controller
    {
        public IActionResult GetHumans()
        {
            List<Human> humen = new HumanDbCommands().GetHumans();
            return Json(humen);
        }

        public IActionResult List()
        {
            List<Human> humen = new HumanDbCommands().GetHumans();
            return View(humen);

        }
        public IActionResult Details(int id)
        {
            List<Human> humen = new HumanDbCommands().GetHumans();
            Human human = humen.First(a => a.ID == id);
            return View(human);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<Human> humen = new HumanDbCommands().GetHumans();
            Human human = humen.First(a => a.ID == id);
            return View(human);
        }

        [HttpPost]
        public IActionResult Edit(Human app)
        {
            new HumanDbCommands().UpdateHuman(app.ID, app);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            new HumanDbCommands().DeleteHuman(id);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Human human)
        {
            new HumanDbCommands().InsertHuman(human);
            return RedirectToAction("List");
        }

    }
}
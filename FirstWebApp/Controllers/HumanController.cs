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
        public class wrapper
        {
            public List<Human> humen { get; set; }
        }

        public IActionResult gethumans()
        {

            List<Human> humen = HumanDbCommands.GetHumans();

            return Json(humen);
        }

        public IActionResult index()
        {
            // listis wamogeba bazidan
            List<Human> humen = HumanDbCommands.GetHumans();

            return View(new wrapper
            {
                humen = humen
            });
        }
    
    }
}
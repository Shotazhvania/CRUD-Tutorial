using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstWebApp.Models;
using Project1;
using Project1.ADONetCRUDs;
using Project1.Work;
using BuildingDbCommands = Project1.DapperCRUDs.BuildingDbCommands;
using AppartmentDbCommands = Project1.DapperCRUDs.AppartmentDbCommands;
using FirstWebApp.ViewModels;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeIndexViewModel
            {
                Humen = HumanDbCommands.GetHumans(),
                Appartments = AppartmentDbCommands.GetTests2(),
                Countries = new CountryDbCommands().GetTests(),
                Buildings = BuildingDbCommands.GetBuilding()
            });
        }
        public IActionResult Indexs()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

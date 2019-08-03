using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstWebApp.Models;
using Project1.ADONetCRUDs;
using FirstWebApp.ViewModels;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeIndexViewModel
            {
                Humen = new HumanDbCommands().GetHumans(),
                Appartments = new AppartmentDbCommands().GetAppartment(),
                Countries = new CountryDbCommands().GetCountry(),
                Buildings = new BuildingDbCommands().GetBuilding()
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

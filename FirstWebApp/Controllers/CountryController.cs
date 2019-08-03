using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.ADONetCRUDs;
using Project1.DapperCRUDs;
using Project1.Work;

namespace FirstWebApp.Controllers
{
    public class CountryController : Controller
    {
            //Country
            public IActionResult GetCountry()
            {
                List<Country> countries = new Project1.ADONetCRUDs.CountryDbCommands().GetCountry();
                return Json(countries);
            }

            public IActionResult List()
            {
                List<Country> countries = new Project1.ADONetCRUDs.CountryDbCommands().GetCountry();
                return View(countries);

            }
            public IActionResult Details(int id)
            {
                List<Country> countries = new Project1.ADONetCRUDs.CountryDbCommands().GetCountry();
                Country country = countries.First(a => a.ID == id);
                return View(country);
            }

            [HttpGet]
            public IActionResult Edit(int id)
            {
                 List<Country> countries = new Project1.ADONetCRUDs.CountryDbCommands().GetCountry();
                 Country country = countries.First(a => a.ID == id);
                 return View(country);
            }

            [HttpPost]
            public IActionResult Edit(Country app)
            {
                new Project1.ADONetCRUDs.CountryDbCommands().UpdateCountry(app.ID, app);
                return RedirectToAction("List");
            }

            public IActionResult Delete(int id)
            {
                new Project1.ADONetCRUDs.CountryDbCommands().DeleteCountry(id);
                return RedirectToAction("List");
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Country country)
            {
                new Project1.ADONetCRUDs.CountryDbCommands().InsertCountry(country);
                return RedirectToAction("List");
            }
    }

}

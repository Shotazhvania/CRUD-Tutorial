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
            public class WrapperCountry
            {
                public List<Country> Countries { get; set; }
            }

            public IActionResult GetTests()
            {
                List<Country> countries = Project1.DapperCRUDs.CountryDbCommands.GetCountry();
                return Json(countries);
            }

            public IActionResult IndexCountry()
            {
                List<Country> countries = Project1.DapperCRUDs.CountryDbCommands.GetCountry();
                return View(new Country
                {
                    countries = countries

                });

            }
        
    }
}
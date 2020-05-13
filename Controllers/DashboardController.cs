using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspnetMvcTutorial.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Help()
        {
            return Content("help route");
        }

        public IActionResult Page(int id, string location)
        {
            string loc = Request.Query["location"];
            return Content("Page is: " + id.ToString() + " location is: " + location);
        }

        public IActionResult Create([FromBody] string name)
        {
            return Content("submitted for creationg:" + name);
        }
    }
}
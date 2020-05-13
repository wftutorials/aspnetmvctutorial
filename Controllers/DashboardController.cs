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


        [HttpPost]
        public IActionResult Create()
        {
            string name = Request.Form["name"];
            return Content("submitted the name as: " + name);
        }

        public IActionResult Login()
        {
            return Redirect("~/home/index");
        }

        public IActionResult Logout()
        {
            return RedirectToAction("help");
        }

        public IActionResult Home()
        {
            List<String> list = new List<String>();
            list.Add("List item 1");
            list.Add("List item 2");
            list.Add("List item 3");
            ViewData["items"] = list;
            ViewData["description"] = "My home page description";
            ViewData["pageTitle"] = "This is My Home Page";
            ViewData["show"] = false;
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using AspnetMvcTutorial.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySql.Data.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AspnetMvcTutorial.Controllers
{
    public class DashboardController : Controller
    {
        private wftutorialsContext _context;

        public DashboardController(wftutorialsContext context)
        {
            _context = context;
        }


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

        public IActionResult Users()
        {
            List<String> emails = new List<String>();
            string connectionString = "server=localhost;user=root;password=;database=wftutorials";
           // MySqlConnection conn = new MySqlConnection(connectionString);
            // conn.Open();
            // var command = new MySqlCommand("SELECT email FROM musers limit 10;", conn);
            // var reader = command.ExecuteReader();
            // while (reader.Read())
            // {
            //     var value = reader.GetValue(0).ToString();
            //     emails.Add(value);
            // do something with 'value'
            //  }
            return Content("test");
        }

        public IActionResult AllUsers()
        {
            var users = _context.Musers;
            Console.Write(users);
            List<String> emails = new List<String>();
            foreach ( Musers u in users)
            {
                emails.Add(u.Email);
            }
            return View(emails);
        }

        public IActionResult UsersPlay()
        {
            string output = "";
            var users = _context.Musers.Where(p => p.Gender == "Male");
            foreach(Musers u in users)
            {
                output += u.Email + " | " + u.Gender + "<br>";
            }
            Response.ContentType = "text/html";
            return Content("<html>" + output + "</html");
        }

     
    }
}
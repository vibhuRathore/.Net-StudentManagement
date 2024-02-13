using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            //Create an Instance of the ApplicationDbContext class
            ApplicationDbContext ctx = new ApplicationDbContext();
            //Fetch all the users, this will create the database behind the scene
            List<ApplicationUser> users = ctx.Users.ToList();
            return View();
        }
    }
}
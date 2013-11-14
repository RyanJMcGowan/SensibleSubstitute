using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Admin Console.";
            return View();
        }

        public ActionResult AddBlog()
        {
            ViewBag.Message = "Add a new post.";

            return View();
        }

        public ActionResult Manage()
        {
            //filter by author.
            ViewBag.Message = "Manage your Posts.";

            return View();
        }
    }
}

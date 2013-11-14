using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SensibleSubstitute.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Nav = "Home";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Nav = "About";
            return View();
        }

        public ActionResult Tags()
        {
            //Lists Keywords.
            ViewBag.Nav = "Index";
            return View();
        }

        public void Test(List<string> values)
        {
            ViewBag.Nav = "Index";
        }
    }
}

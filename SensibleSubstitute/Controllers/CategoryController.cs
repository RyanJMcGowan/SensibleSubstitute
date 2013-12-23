using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SensibleSubstitute.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Query(string type)
        {
            //Category/[Articles|News|Reviews|Dynamically-Generated-Category|Etc]/
            return View();
        }
    }
}

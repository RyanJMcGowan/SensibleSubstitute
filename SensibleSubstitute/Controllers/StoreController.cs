using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SensibleSubstitute.Controllers
{
    public class StoreController : Controller
    {
        //This controller is instantiated by the URL "~/partials/store"
        public ActionResult Store()
        {
            return View();
        }

    }
}

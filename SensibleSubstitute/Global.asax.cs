using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SensibleSubstitute.Controllers;

namespace SensibleSubstitute
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Defines additional folders to place Razor views.
            var razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().First();
            razorEngine.ViewLocationFormats = razorEngine.ViewLocationFormats.Concat(new string[] 
            { 
                //list Razor folders here.
                "~/src/app/{1}/{0}.cshtml"
            }).ToArray();
        }

        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                Response.Clear();

                var rd = new RouteData();
                //rd.DataTokens["area"] = "AreaName"; // In case controller is in another area
                rd.Values["controller"] = "Home";
                rd.Values["action"] = "Index";

                IController c = new HomeController();
                c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
            }
        }

    }
}
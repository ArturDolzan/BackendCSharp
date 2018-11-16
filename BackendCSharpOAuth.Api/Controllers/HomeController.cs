using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackendCSharpOAuth.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // string myVar = System.Configuration.ConfigurationManager.AppSettings["teste"];

            return View();

            //return Redirect(this.HttpContext.Request.Url + "/index.html");
        }

    }
}
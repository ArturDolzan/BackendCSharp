﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackendCSharpOAuth.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return Redirect(this.HttpContext.Request.Url + @"\index.html");
        }

    }
}
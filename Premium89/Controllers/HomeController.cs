﻿using Premium89.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Premium89.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ContentResult RefreshMenu()
        //{
        //    ConfigGUI.NavMenuInitialize();
        //    return Content("Success");
        //}

    }
}
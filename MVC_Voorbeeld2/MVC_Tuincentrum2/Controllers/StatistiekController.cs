﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tuincentrum2.Controllers
{
    [OverrideActionFilters]
    public class StatistiekController : Controller
    {
        // GET: Statistiek
        public ActionResult Index()
        {
            return View();
        }
    }
}
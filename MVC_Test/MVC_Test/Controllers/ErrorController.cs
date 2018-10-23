using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string boodschap)
        {
            return View("Index", model:boodschap);
        }
        public ActionResult NotFound404()
        {
            Response.StatusCode = 404;
            return View("NotFound", model:"404");
        }
        public ActionResult NotFound500()
        {
            Response.StatusCode = 500;
            return View("NotFound", model:"500");
        }

    }
}
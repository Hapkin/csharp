using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tuincentrum2.Controllers
{
    [RoutePrefix("Thuis")]
    [Route("{action=index}")]
    public class HomeController : Controller
    {
        //[Route]
        public ActionResult Index()
        {
            return View();
        }
        //[Route("Over")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        //[Route("Contacteer")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld2.Controllers
{
    public class WerknemerController : Controller
    {
        // GET: Werkenemer
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index(int? id)// niet verplicht om een parameter mee te geven
        {
            //return View();
            //return Content("Kiekeboe");
            return File(@"e:\etiketten\Cezarken.jpg", "image/jpg");
        }
        public ActionResult Read(int? id)
        {
            return View();
        }

        [NonAction]  // public method die niet via de brouwser kan worden opgeroepen
        public void GeenAction()
        {
        }
        [HttpPost]
        public ActionResult VerdubbelDeWeddes()
        {
            //return View();
            return Redirect("~/Werknemer/WeddesAangepast");
        }
        public ActionResult WeddesAangepast()
        {
            return View();
        }
    }
}
using MVC_Voorbeeld2.Models;
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
            return View("AndereNaam");
            //return Content("Kiekeboe");
            //return File(@"e:\etiketten\Cezarken.jpg", "image/jpg");
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

        [ActionName("Lijst")]  //je geeft een andere naam aan de action
        public ActionResult AlleWerknemers()
        {
            var werknemers = new List<Werknemer>();
            werknemers.Add(new Werknemer
            {
                Voornaam = "Steven",
                Wedde = 1000,
                Indienst = DateTime.Today
            });
            werknemers.Add(new Werknemer
            { Voornaam = "Prosper", Wedde = 2000, Indienst = DateTime.Today.AddDays(2) });

            //            return View(werknemers);
            return View("AlleWerknemers", werknemers);
            //mits de action een andere naam heeft gaat hij standaard op zoek naar de view lijst.cshtml
        }
    }
}
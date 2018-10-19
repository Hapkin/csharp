using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Test.Services;
using MVC_Test.Models;
using MVC_Test.DB;

namespace MVC_Test.Controllers
{
    public class HomeController : Controller
    {
        VideoVerhuurService DB = new VideoVerhuurService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FouteInlog()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Inloggen(Klant klant)
        {
            Klant BestaandeKlant = DB.InloggenKlant(klant);
            if (BestaandeKlant != null)
            {
                Session["klant"] = BestaandeKlant;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("FouteInlog", "Home", new {fout="fout" });
            }

        }
        public ActionResult Uitloggen()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
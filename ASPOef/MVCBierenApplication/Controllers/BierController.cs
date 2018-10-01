using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBierenApplication.Models;

namespace MVCBierenApplication.Controllers
{
    public class BierController : Controller
    {
        // GET: Bier
        public ActionResult Index()
        {
            List<Bier> lBieren = new List<Bier>();

            lBieren.Add(new Bier { ID = 1, Naam = "Palm", Alcohol = 5.1F });
            lBieren.Add(new Bier { ID = 2, Naam = "Jupiler", Alcohol = 5.2F });
            lBieren.Add(new Bier { ID = 3, Naam = "Petrus", Alcohol = 6.6F });
            lBieren.Add(new Bier { ID = 3, Naam = "Pilaarbijter", Alcohol = 7.2F });


            return View(lBieren);
        }
    }
}
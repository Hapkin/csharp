using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBierenApplication.Models;
using MVCBierenApplication.Services;
using MVCBierenApplication.DB;

namespace MVCBierenApplication.Controllers
{
    public class BierController : Controller
    {
        private BierenService bierenService = new BierenService();
        public ActionResult Index()
        {
            var bieren = bierenService.FindAll();
            return View(bieren);
        }


        //// GET: Bier
        //public ActionResult Index()
        //{
        //    List<Bier> lBieren = new List<Bier>();

        //    lBieren.Add(new Bier { ID = 1, Naam = "Palm", Alcohol = 5.1F });
        //    lBieren.Add(new Bier { ID = 2, Naam = "Jupiler", Alcohol = 5.2F });
        //    lBieren.Add(new Bier { ID = 3, Naam = "Petrus", Alcohol = 6.6F });
        //    lBieren.Add(new Bier { ID = 4, Naam = "Pilaarbijter", Alcohol = 7.2F });
        //    lBieren.Add(new Bier { ID = 5, Naam = "MXVV", Alcohol = 13.2F });
        //    lBieren.Add(new Bier { ID = 6, Naam = "Bananenbier", Alcohol = 0.5F });


        //    return View(lBieren);
        //}

        public ActionResult Verwijderen(int ID)
        {
            var bier = bierenService.Read(ID);
            return View(bier);
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            var bier = bierenService.Read(ID);
            this.TempData["bier"] = bier;
            bierenService.Delete(ID);
            return Redirect("~/Bier/Verwijderd");
        }
        public ActionResult Verwijderd()
        {
            var bier = (Bier)this.TempData["bier"];
            return View(bier);
        }
        [HttpGet]
        public ActionResult Toevoegen()
        {
            var bier = new Bier();
            return View(bier);
        }
        
        [HttpPost]
        public ActionResult Toevoegen(Bier b)
        {
            if (this.ModelState.IsValid)
            {
                bierenService.Add(b);
                return RedirectToAction("Index");
            }
            else
                return View(b);
        }
    }
}
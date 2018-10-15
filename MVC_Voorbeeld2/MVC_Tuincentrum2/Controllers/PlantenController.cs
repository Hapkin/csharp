using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Tuincentrum2.DB;
using MVC_Tuincentrum2.Filters;

namespace MVC_Tuincentrum2.Controllers
{
    //[StatistiekActionFilter]
    public class PlantenController : Controller
    {
        private EFTuincentrum db = new EFTuincentrum();

        // GET: Planten
        public ActionResult Index()
        {
            var planten = db.Planten.Include(p => p.Leveranciers).Include(p => p.Soorten);
            return View(planten.ToList());
        }

        // GET: Planten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planten planten = db.Planten.Find(id);
            if (planten == null)
            {
                return HttpNotFound();
            }
            return View(planten);
        }

        // GET: Planten/Create
        public ActionResult Create()
        {
            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam");
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Soort");
            return View();
        }

        // POST: Planten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlantNr,Naam,SoortNr,Levnr,Kleur,VerkoopPrijs")] Planten planten)
        {
            if (ModelState.IsValid)
            {
                db.Planten.Add(planten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam", planten.Levnr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Soort", planten.SoortNr);
            return View(planten);
        }

        [StatistiekActionFilter]
        // GET: Planten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planten planten = db.Planten.Find(id);
            if (planten == null)
            {
                return HttpNotFound();
            }
            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam", planten.Levnr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Soort", planten.SoortNr);
            return View(planten);
        }

        // POST: Planten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlantNr,Naam,SoortNr,Levnr,Kleur,VerkoopPrijs")] Planten planten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam", planten.Levnr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Soort", planten.SoortNr);
            return View(planten);
        }

        // GET: Planten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planten planten = db.Planten.Find(id);
            if (planten == null)
            {
                return HttpNotFound();
            }
            return View(planten);
        }

        // POST: Planten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planten planten = db.Planten.Find(id);
            db.Planten.Remove(planten);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpGet]
        public ViewResult Uploaden(int id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult FotoUpload(int id)
        {
            if (Request.Files.Count > 0)
            {
                var foto = Request.Files[0];
                var absoluutPadNaarDir = this.HttpContext.Server.MapPath("~/Images/Fotos");
                var absoluutPadNaarFoto = Path.Combine(absoluutPadNaarDir, id + ".jpg");
                foto.SaveAs(absoluutPadNaarFoto);
            }
            return RedirectToAction("Index");
        }
        public ContentResult ImageOrDefault(int id)
        {
            var imagePath = "/Images/Fotos/" + id + ".jpg";
            var imageSrc = System.IO.File.Exists(HttpContext.Server.MapPath("~/" + imagePath))
            ? imagePath : "/Images/default.jpg";
            return Content(imageSrc);
        }



        public ActionResult FindPlantenBySoortNaam(string soortnaam)
        {
            List<Planten> plantenLijst = new List<Planten>();
            plantenLijst = (from plant in db.Planten.Include("Soorten")
                            where plant.Soorten.Soort.StartsWith(soortnaam)
                            select plant).ToList();
            return View(plantenLijst);
        }
        public ActionResult FindPlantenByLeverancier(int? levnr)
        {
            List<Planten> plantenLijst = new List<Planten>();
            plantenLijst = (from plant in db.Planten.Include("Leveranciers")
                            where plant.Leveranciers.LevNr == levnr
                            select plant).ToList();
            return View(plantenLijst);
        }




        public ActionResult FindPlantenBetweenPrijzen(decimal minPrijs, decimal maxPrijs)
        {
            List<Planten> plantenLijst = new List<Planten>();
            plantenLijst = (from plant in db.Planten
                            where plant.VerkoopPrijs >= minPrijs &&
                            plant.VerkoopPrijs <= maxPrijs
                            select plant).ToList();
            ViewBag.minprijs = minPrijs;
            ViewBag.maxprijs = maxPrijs;
            return View(plantenLijst);
        }
        public ActionResult FindPlantenVanEenKleur(string kleur)
        {
            List<Planten> plantenLijst = new List<Planten>();
            plantenLijst = (from plant in db.Planten
                            where plant.Kleur == kleur
                            select plant).ToList();
            ViewBag.kleur = kleur;
            return View(plantenLijst);
        }





        [Route("plantinfo/{id:int}")]
        public ActionResult FindPlantById(int id)
        {
            var plant = db.Planten.Find(id);
            if (plant != null)
                return View("Details", plant);
            else
            {
                var planten =
                db.Planten.Include(p => p.Leveranciers).Include(p => p.Soorten);
                return View("Index", planten.ToList());
            }
        }
        [Route("plantinfo/{naam}")]
        public ActionResult FindPlantByName(string naam)
        {
            var plant = (from p in db.Planten
                         where p.Naam == naam
                         select p).FirstOrDefault();
            if (plant != null)
                return View("Details", plant);
            else
            {
                var planten =
                db.Planten.Include(p => p.Leveranciers).Include(p => p.Soorten);
                return View("Index", planten.ToList());
            }
        }

        [Route("plantenprijzen/{btw:values(inclusief|exclusief)}", Name = "btwinex")]
        public ActionResult PrijsLijst(string btw)
        {
            ViewBag.Btw = btw;
            return View(db.Planten.ToList());
        }
    }
}

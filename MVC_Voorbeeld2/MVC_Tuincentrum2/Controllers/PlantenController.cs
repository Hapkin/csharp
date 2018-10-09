using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Tuincentrum2.DB;

namespace MVC_Tuincentrum2.Controllers
{
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
    }
}

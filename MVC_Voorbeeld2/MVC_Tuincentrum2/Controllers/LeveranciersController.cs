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
    public class LeveranciersController : Controller
    {
        private EFTuincentrum db = new EFTuincentrum();

        // GET: Leveranciers
        public ActionResult Index()
        {
            return View(db.Leveranciers.ToList());
        }

        // GET: Leveranciers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leveranciers leveranciers = db.Leveranciers.Find(id);
            if (leveranciers == null)
            {
                return HttpNotFound();
            }
            return View(leveranciers);
        }

        // GET: Leveranciers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leveranciers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LevNr,Naam,Adres,PostNr,Woonplaats")] Leveranciers leveranciers)
        {
            if (ModelState.IsValid)
            {
                db.Leveranciers.Add(leveranciers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leveranciers);
        }

        // GET: Leveranciers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leveranciers leveranciers = db.Leveranciers.Find(id);
            if (leveranciers == null)
            {
                return HttpNotFound();
            }
            return View(leveranciers);
        }

        // POST: Leveranciers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LevNr,Naam,Adres,PostNr,Woonplaats,Test")] Leveranciers leveranciers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leveranciers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leveranciers);
        }

        // GET: Leveranciers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leveranciers leveranciers = db.Leveranciers.Find(id);
            if (leveranciers == null)
            {
                return HttpNotFound();
            }
            return View(leveranciers);
        }

        // POST: Leveranciers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leveranciers leveranciers = db.Leveranciers.Find(id);
            db.Leveranciers.Remove(leveranciers);
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

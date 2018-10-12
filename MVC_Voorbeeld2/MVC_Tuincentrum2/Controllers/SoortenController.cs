using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Tuincentrum2.DB;
using MVC_Tuincentrum2.Models;
using MVC_Tuincentrum2.Services;

namespace MVC_Tuincentrum2.Controllers
{
    public class SoortenController : Controller
    {
        private EFTuincentrum db = new EFTuincentrum();

        // GET: Soorten
        public ActionResult Index()
        {

            return View(db.Soorten.ToList());
        }

        // GET: Soorten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soorten soorten = db.Soorten.Find(id);
            if (soorten == null)
            {
                return HttpNotFound();
            }
            return View(soorten);
        }

        // GET: Soorten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Soorten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoortNr,Soort,MagazijnNr")] Soorten soorten)
        {
            if (ModelState.IsValid)
            {
                db.Soorten.Add(soorten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soorten);
        }

        // GET: Soorten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soorten soorten = db.Soorten.Find(id);
            if (soorten == null)
            {
                return HttpNotFound();
            }
            return View(soorten);
        }

        // POST: Soorten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoortNr,Soort,MagazijnNr")] Soorten soorten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soorten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soorten);
        }

        // GET: Soorten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soorten soorten = db.Soorten.Find(id);
            if (soorten == null)
            {
                return HttpNotFound();
            }
            return View(soorten);
        }

        // POST: Soorten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soorten soorten = db.Soorten.Find(id);
            db.Soorten.Remove(soorten);
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


        #region zoekformulier
        // GET: /Soort/Zoekform
        // Models/ZoekSoortViewModel.cs
        private SoortService soortService = new SoortService();
        public ViewResult ZoekForm()
        {
            return View(new ZoekSoortViewModel());
        }

        public ViewResult BeginNaam(ZoekSoortViewModel form)
        {
            //if (this.ModelState.IsValid)
            //{
            //    var query = from soort in db.Soorten
            //                where soort.Soort.StartsWith(form.beginNaam)
            //                orderby soort.Soort
            //                select soort;
            //    var soorten = query.ToList();
            //    form.Soorten = soorten;

            //}
            //return View("ZoekForm", form);
            if (this.ModelState.IsValid)
                form.Soorten = soortService.FindByBeginNaam(form.beginNaam);
            return View("ZoekForm", form);
        }
        #endregion
    }
}

using MVC_Voorbeeld3.Models;
using MVC_Voorbeeld3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld3.Controllers
{


    public class FiliaalController : Controller
    {
        private FiliaalService filiaalService = new FiliaalService();
        private HoofdZetelService hoofdZetelService = new HoofdZetelService();

        // GET: Filiaal
        public ActionResult Index()
        {
            var hoofdZetel = hoofdZetelService.Read();
            ViewBag.hoofdZetel = hoofdZetel;
            var filialen = filiaalService.FindAll();
            return View(filialen);
        }
        public ActionResult Filialen()
        {
            var hoofdZetel = hoofdZetelService.Read();
            ViewBag.hoofdZetel = hoofdZetel;
            var filialen = filiaalService.FindAll();
            return View("Index", filialen);
        }

        public ActionResult Verwijderen(int id)
        {
            var filiaal = filiaalService.Read(id);
            return View(filiaal);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var filiaal = filiaalService.Read(id);
            //een tijdelijke variable maken terwijl deze al verwijderd wordt...
            this.TempData["filiaal"] = filiaal;
            filiaalService.Delete(id);
            return Redirect("~/Filiaal/Verwijderd");
        }
        public ActionResult Verwijderd()
        {
            var filiaal = (Filiaal)this.TempData["filiaal"];
            return View(filiaal);
        }
    }
}
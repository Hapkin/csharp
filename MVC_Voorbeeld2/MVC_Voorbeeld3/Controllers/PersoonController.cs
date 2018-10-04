using MVC_Voorbeeld3.Models;
using MVC_Voorbeeld3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld3.Controllers
{
    public class PersoonController : Controller
    {
        private PersoonService persoonService = new PersoonService();
        public ActionResult Index()
        {
            return View("Personen", persoonService.FindAll());
        }
        public ActionResult Personen()
        {
            return View("Personen", persoonService.FindAll());
        }
        [HttpGet]
        public ActionResult VerwijderForm(int id)
        {
            return View(persoonService.FindByID(id));
        }
        [HttpPost]
        public ActionResult Verwijderen(int id)
        {
            persoonService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Opslag()
        {
            OpslagViewModel opslagViewModel = new OpslagViewModel();
            opslagViewModel.Percentage = 10;
            return View(opslagViewModel);
        }

        [HttpPost]
        public ActionResult Opslag(OpslagViewModel opslagViewModel)
        {
            /*
            //.value omdat de waardes null kunnen zijn => decimal? prop
            persoonService.Opslag(opslagViewModel.VanWedde.Value, opslagViewModel.TotWedde.Value, opslagViewModel.Percentage.Value);
            return RedirectToAction("Index");
            */

            if (this.ModelState.IsValid)
            {
                //geen validatiefouten
                persoonService.Opslag(opslagViewModel.VanWedde.Value,
                opslagViewModel.TotWedde.Value,
                opslagViewModel.Percentage.Value);
                return RedirectToAction("Index");
            }
            else
            {
                //wel validatiefouten
                return View(opslagViewModel);
            }
        }

        [HttpGet]
        public ActionResult VanTotWedde()
        {
            var form = new VanTotWeddeViewModel();
            return View(form);
        }
        [HttpGet]
        public ActionResult VanTotWeddeResultaat(VanTotWeddeViewModel form)
        {
            //if (this.ModelState.IsValid)
            //{
            //    form.Personen = persoonService.VanTotWedde(
            //    form.VanWedde.Value, form.TotWedde.Value);
            //}
            //return View("VanTotWedde", form);
            if (this.ModelState.IsValid)
            {
                var lijst = persoonService.VanTotWedde(
                form.VanWedde.Value, form.TotWedde.Value);
                if (lijst.Count <= 3)
                    // geen extra probleem
                    form.Personen = lijst;
                else
                    // wél een probleem
                    this.ModelState.AddModelError("", "Te veel resultaten");
            }
            return View("VanTotWedde", form);
        }
    }
}
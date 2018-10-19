using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Cultuurhuis.Services;
using MVC_Cultuurhuis.Models;
using MVC_Cultuurhuis.DB;

namespace MVC_Cultuurhuis.Controllers
{
    public class HomeController : Controller
    {
        CultuurService db = new CultuurService();

        public ActionResult Index(int? id)
        {
            var voorstellingenViewModel = new VoorstellingenViewModel();
            voorstellingenViewModel.Genres = db.GetAllGenres();
            voorstellingenViewModel.Voorstellingen = db.GetAlleVoorstellingenVanGenre(id);
            voorstellingenViewModel.Genre = db.GetGenre(id);

            if (Session.Keys.Count != 0)
                ViewBag.mandjeTonen = true;
            else
                ViewBag.mandjeTonen = false;

            return View(voorstellingenViewModel);
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Reserveren(int id)
        {
            Voorstelling gekozenVoorstelling = db.GetVoorstelling(id);
            return View(gekozenVoorstelling);
        }


        [HttpPost]
        public ActionResult Reserveer(int id, int aantalPlaatsen)
        {
            //uint aantalPlaatsen = uint.Parse(Request["aantalPlaatsen"]);
            var voorstellingInfo = db.GetVoorstelling(id);
            if (aantalPlaatsen > voorstellingInfo.VrijePlaatsen)
            {
                return RedirectToAction("Reserveer", "Home", new { id = id });
            }
            Session[id.ToString()] = aantalPlaatsen;
            return RedirectToAction("Mandje", "Home");
        }



        public ActionResult Mandje()
        {
            decimal teBetalen = 0;
            List<MandjeItem> mandjeItems = new List<MandjeItem>();
            foreach (string nummer in Session)
            {
                int voorstellingsnummer;
                if (int.TryParse(nummer, out voorstellingsnummer))
                {
                    Voorstelling voorstelling = db.GetVoorstelling(voorstellingsnummer);
                    if (voorstelling != null)
                    {
                        MandjeItem mandjeItem =
                        new MandjeItem(voorstellingsnummer, voorstelling.Titel,
                        voorstelling.Uitvoerders, voorstelling.Datum,
                        voorstelling.Prijs, Convert.ToInt16(Session[nummer]));
                        teBetalen += (mandjeItem.Plaatsen * mandjeItem.Prijs);
                        mandjeItems.Add(mandjeItem);
                    }
                }
            }
            ViewBag.teBetalen = teBetalen;
            return View(mandjeItems);
        }

        [HttpPost]
        public ActionResult Verwijderen()
        {
            foreach (var item in Request.Form.AllKeys)
            {
                if (Session[item] != null) Session.Remove(item);
            }
            return RedirectToAction("Mandje", "Home");
        }


    }
}
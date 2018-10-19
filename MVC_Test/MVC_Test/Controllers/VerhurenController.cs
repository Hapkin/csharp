using MVC_Test.Models;
using MVC_Test.DB;
using MVC_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_Test.Controllers
{
    public class VerhurenController : Controller
    {
        VideoVerhuurService DB = new VideoVerhuurService();

        // GET: Verhuren
        public ActionResult Index()
        {
            //return View();
            return View("Verhuren");
        }
        public ActionResult Verhuren(int? id)
        {
            VerhurenVM VM = new VerhurenVM();

            VM.lGenres = DB.GetAllGenres();
            //VM.lGenres = null;
            if (id != null)
            {
                VM.hetGenre = DB.GetGenre(id);
                VM.lFilms = DB.GetAlleFilmsOpGenre(id);
            }

            return View(VM);
        }
        public ActionResult Winkelwagentje()
        {

            return View();
        }

        public ActionResult Verwijderen(int id)
        {
            //Film gekozenfilm = DB.GetSelectedFilm(id);
            List<Film> li = (List<Film>)Session["cart"];
            //li.Remove(gekozenfilm);
            li.RemoveAt(id);

            Session["cart"] = li;

            return RedirectToAction("Winkelwagentje", "Verhuren");
        }
        public ActionResult Toevoegen(int id)
        {

            Film gekozenfilm = DB.GetSelectedFilm(id);
            if (Session["cart"] == null)
            {
                List<Film> li = new List<Film>();
                li.Add(gekozenfilm);
                Session["cart"] = li;
            }
            else
            {
                List<Film> li = (List<Film>)Session["cart"];
                if (li.Any(x => x.BandNr == id))
                {
                    //verwijzen naar error boodschap? is reeds opgenomen in de lijst
                }
                else
                {
                    li.Add(gekozenfilm);
                    Session["cart"] = li;
                }
                
            }
            return RedirectToAction("Winkelwagentje", "Verhuren");
        }

    }
}
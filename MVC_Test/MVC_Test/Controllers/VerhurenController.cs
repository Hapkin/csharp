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
            return RedirectToAction("Verhuren");
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
            WinkelWagenVM VM = new WinkelWagenVM();
            List<Film> gekozenFilms = (List<Film>)Session["cart"];
            VM.lFilms = gekozenFilms;
            VM.klant = (Klant)Session["klant"];
            return View(VM);
        }

        public ActionResult verwijderenVraag(int filmVerwijderenID)//Film filmVerwijderen, 
        {
            WinkelWagenVM VM = new WinkelWagenVM();

            List<Film> gekozenFilms = (List<Film>)Session["cart"];
            Film filmVerwijderen = gekozenFilms[filmVerwijderenID];

            VM.FilmVerwijderenID = filmVerwijderenID;
            VM.FilmVerwijderen = filmVerwijderen;
            return View(VM);
        }


        public ActionResult Verwijderen(int id)
        {
            List<Film> li = (List<Film>)Session["cart"];
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
                    //return RedirectToAction("Index", "Error", new { boodschap = "Je hebt deze film al gekozen" });
                    //return View("Index", "Error");
                }
                else
                {
                    li.Add(gekozenfilm);
                    Session["cart"] = li;
                }  
            }
            return RedirectToAction("Winkelwagentje", "Verhuren");
        }

        public ActionResult Afrekenen()
        {
            //return RedirectToAction("index");

            WinkelWagenVM VM = new WinkelWagenVM();
            string saveResult;

            if (Session["cart"] != null && Session["klant"] != null)
            {

                List<Film> li = (List<Film>)Session["cart"];
                VM.lFilms = li;
                VM.klant = (Klant)Session["klant"];

                saveResult = DB.SaveAll(VM.lFilms, VM.klant);

                if (saveResult == "OK")
                {
                    Session.Clear();
                    return View("Afrekenen", VM);
                }
                else
                {
                    //return View("index", "Error", new { boodschap = saveResult });
                    return RedirectToAction("index");
                }
            }
            else
            {
                return RedirectToAction("index");
            }
            
        }

        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Test.DB;

namespace MVC_Test.Services
{
    public class VideoVerhuurService
    {



        public List<Genre> GetAllGenres()
        {
            
            using (EFVideoVerhuur DB = new EFVideoVerhuur())
            {
                List<Genre> lGenre = DB.Genres.ToList();
                //List<Genre> lGenre = null;
                return lGenre;
            }
        }
        public Genre GetGenre(int? id)
        {
            using (EFVideoVerhuur DB = new EFVideoVerhuur())
            {
                return DB.Genres.Find(id);
            }
        }



        public List<Film> GetAlleFilmsOpGenre(int? id)
        {
            using (EFVideoVerhuur DB = new EFVideoVerhuur())
            {
                var query = from film in DB.Films.Include("Genres")
                            where film.GenreNr == id
                            orderby film.Titel
                            select film;
                return query.ToList();
            }
        }

        public Film GetSelectedFilm(int? id)
        {
            using (EFVideoVerhuur DB = new EFVideoVerhuur())
            {
                return DB.Films.Find(id);
            }
        }




        public Klant InloggenKlant(Klant testklant)
        {
            using (EFVideoVerhuur DB = new EFVideoVerhuur())
            {

                //Klant query = (Klant)from klant in DB.Klanten
                //            where klant.Naam.ToLower() == testklant.Naam.ToLower() //&& klant.PostCode == testklant.PostCode
                //            select klant;
                Klant klant = DB.Klanten.FirstOrDefault(x => x.Naam == testklant.Naam && x.PostCode == testklant.PostCode);


                return klant;
            }
        }
    }
}
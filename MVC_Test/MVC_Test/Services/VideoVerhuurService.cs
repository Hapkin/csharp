using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Test.DB;
using MVC_Test.Models;

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




        public Klant InloggenKlant(LoginVM testklant)
        {
            using (EFVideoVerhuur DB = new EFVideoVerhuur())
            {
                Klant klant = DB.Klanten.FirstOrDefault(x => x.Naam == testklant.Naam && x.PostCode == testklant.Postcode);
                return klant;
            }
        }

        public string SaveAll(List<Film> lFilms, Klant deKlant)
        {
            if (lFilms != null && deKlant != null)
            {
                using (EFVideoVerhuur DB = new EFVideoVerhuur())
                {
                    Klant DBKlant = DB.Klanten.FirstOrDefault(x => x.KlantNr == deKlant.KlantNr);
                    if (lFilms.Count() > 0 && DBKlant!=null)
                    {
                       

                        foreach (Film film in lFilms)
                        {
                            Film DBFilm = DB.Films.FirstOrDefault(f => f.BandNr == film.BandNr);
                            DBFilm.InVoorraad--;
                            DBFilm.UitVoorraad++;
                            DBKlant.HuurAantal++;

                        }
                        DB.SaveChanges();
                        return "OK";
                    }
                    else
                    {
                        return "Er zitten geen films in het winkelwagentje Of de gebruiker is niet gevonden.";
                    }
                }
            }
            else {
                //hier zou je niet mogen geraken...
                return "Er is iets misgegaan... Gelieve later opnieuw te proberen en/of ons te contacteren.";
            }
        }
    }
}
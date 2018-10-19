using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Cultuurhuis.DB;

namespace MVC_Cultuurhuis.Services
{
    //ALLE DB acties in using zodat de connectie wordt afgesloten.
    public class CultuurService
    {
        
        
        public List<Genre> GetAllGenres()
        {
            using (EFCultuurhuis DB = new EFCultuurhuis())
            {
                List<Genre> lGenre = DB.Genres.ToList();
                return lGenre;
            }
        }
        public Genre GetGenre(int? id)
        {
            using (EFCultuurhuis DB = new EFCultuurhuis())
            {
                return DB.Genres.Find(id);
            }
        }

        public List<Voorstelling> GetAlleVoorstellingenVanGenre(int? id)
        {
            using (EFCultuurhuis DB = new EFCultuurhuis())
            {
                var query = from voorstelling in DB.Voorstellingen.Include("Genres")
                            where voorstelling.GenreNr == id //&& voorstelling.Datum >= DateTime.Today 
                            orderby voorstelling.Datum
                            select voorstelling;
                return query.ToList();
            }
        }


       
        public Voorstelling GetVoorstelling(int? id)  //? waarom
        {
            using (var db = new EFCultuurhuis())
            {
                return db.Voorstellingen.Find(id);
            }
        }

    }
}
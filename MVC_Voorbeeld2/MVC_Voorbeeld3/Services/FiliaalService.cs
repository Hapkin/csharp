using MVC_Voorbeeld3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Voorbeeld3.Services
{
    public class FiliaalService
    {
        private static Dictionary<int, Filiaal> filialen = new Dictionary<int, Filiaal>();
        static FiliaalService()
        {
            filialen[1] = new Filiaal
            {
                ID = 1,
                Naam = "Antwerpen",
                Gebouwd = new DateTime(2003, 1, 1),
                Waarde = 2000000
            };
            filialen[2] = new Filiaal
            {
                ID = 2,
                Naam = "Wondelgem",
                Gebouwd = new DateTime(1979, 1, 1),
                Waarde = 2500000
            };
            filialen[3] = new Filiaal
            {
                ID = 3,
                Naam = "Haasrode",
                Gebouwd = new DateTime(1976, 1, 1),
                Waarde = 1000000
            };
            filialen[4] = new Filiaal
            {
                ID = 4,
                Naam = "Wevelgem",
                Gebouwd = new DateTime(1981, 1, 1),
                Waarde = 1600000
            };
            filialen[5] = new Filiaal
            {
                ID = 5,
                Naam = "Genk",
                Gebouwd = new DateTime(1990, 1, 1),
                Waarde = 4000000
            };
        }
        public List<Filiaal> FindAll()
        {
            //levert enkel de values op van de dictionary
            return filialen.Values.ToList();
        }
    }
}
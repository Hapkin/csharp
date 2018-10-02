using MVCBierenApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBierenApplication.Services
{
    public class BierenService
    {
        private static Dictionary<int, Bier> bieren =
        new Dictionary<int, Bier>();
        static BierenService()
        {
            bieren[1] = new Bier { ID = 1, Naam = "Romy pils", Alcohol = 4.5F };
            bieren[2] = new Bier { ID = 2, Naam = "Leffe blond", Alcohol = 2.5F };
            bieren[3] = new Bier { ID = 3, Naam = "Rodenbach", Alcohol = 3.5F };
            bieren[4] = new Bier { ID = 4, Naam = "Liefmans goudenband", Alcohol = 6F };
            bieren[5] = new Bier { ID = 5, Naam = "Duvel", Alcohol = 7F };
        }
        public List<Bier> FindAll()
        {
            return bieren.Values.ToList();
        }
        public Bier Read(int id)
        {
            return bieren[id];
        }
        public void Delete(int id)
        {
            bieren.Remove(id);
        }
    }
}
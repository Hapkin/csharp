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
            bieren[6] = new Bier { ID = 6, Naam = "Palm", Alcohol = 5.1F };
            bieren[7] = new Bier { ID = 7, Naam = "Jupiler", Alcohol = 5.2F };
            bieren[8] = new Bier { ID = 8, Naam = "Petrus", Alcohol = 6.6F };
            bieren[9] = new Bier { ID = 9, Naam = "Pilaarbijter", Alcohol = 7.2F };
            bieren[10] = new Bier { ID = 10, Naam = "MXVV", Alcohol = 13.2F };
            bieren[11] = new Bier { ID = 11, Naam = "Bananenbier", Alcohol = 0.5F };
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

        public void Add(Bier b)
        {
            b.ID = bieren.Keys.Max() + 1;
            bieren.Add(b.ID, b);
        }
    }
}
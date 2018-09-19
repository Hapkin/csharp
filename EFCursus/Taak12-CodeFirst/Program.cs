using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taak12_CodeFirst.DB;

namespace Taak12_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //tijdens opbouw
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CFContext>());


            
            using (var context = new CFContext())
            {
                //artikelgroep
                Artikelgroep artikelgroep = new Artikelgroep
                { ArtikelgroepId = 1, Naam = "test" };


                //artikels
                Artikel a1 = new FoodArtikel { Naam = "banaan", Houdbaarheid = 10, ArtikelgroepId = 1 };
                

                context.Artikels.Add(a1);

                Artikel a2= new NonFoodArtikel { Naam = "gsm", Garantie = 15 };
                context.Artikels.Add(a2);
                
                

                




                context.Artikelgroepen.Add(artikelgroep);
                
                context.SaveChanges();
            }
            


            Console.WriteLine("--done--");
            Console.ReadKey();
        }
    }
}

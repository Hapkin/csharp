using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    class Program
    {
        static void Main(string[] args)
        {
            //drop DB en maak ze opnieuw (collom toegevoegd) 
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFCFContext>());

            using (var context = new EFCFContext())
            {
                var jean = new Instructeur
                {
                    Voornaam = "Jean",
                    Familienaam = "Smits",
                    Wedde = 1000,
                    InDienst = new DateTime(1994, 8, 1),
                    HeeftRijbewijs = true
                };
                context.Instructeurs.Add(jean);
                context.SaveChanges();
                Console.WriteLine(jean.Id);
                // zoeken op primary key
                Console.WriteLine(context.Instructeurs.Find(1).Familienaam);
            }
            Console.ReadKey();
        }
    }
}

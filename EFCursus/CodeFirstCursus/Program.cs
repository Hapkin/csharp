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
                    HeeftRijbewijs = true,
                    Adres = new Adres
                    {
                        Straat = "Keizerslaan",
                        HuisNr = "11",
                        PostCode = "1000",
                        Gemeente = "Brussel"
                    }
                };
                context.Instructeurs.Add(jean);
                context.SaveChanges();
                Console.WriteLine(jean.InstructeurNr);
                // zoeken op primary key
                Console.WriteLine(context.Instructeurs.Find(1).Familienaam);
                // ===============
                // Inheritance TPH
                // ===============
                context.TPHCursussen.Add(new TPHKlassikaleCursus
                {
                    Naam = "Frans in 24 uur",
                    Van = DateTime.Today,
                    Tot = DateTime.Today
                });
                context.TPHCursussen.Add(new TPHZelfstudieCursus
                {
                    Naam = "Engels in 24 uur",
                    AantalDagen = 1
                });



                // ===============
                // Inheritance TPT
                // ===============
                context.TPTCursussen.Add(new TPTKlassikaleCursus
                {
                    Naam = "Frans in 24 uur",
                    Van = DateTime.Today,
                    Tot = DateTime.Today
                });
                context.TPTCursussen.Add(new TPTZelfstudieCursus
                {
                    Naam = "Engels in 24 uur",
                    AantalDagen = 1
                });

                // ===============
                // Inheritance TPC
                // ===============
                context.TPCCursussen.Add(new TPCKlassikaleCursus
                {
                    Naam = "Frans in 24 uur",
                    Van = DateTime.Today,
                    Tot = DateTime.Today
                });
                context.TPCCursussen.Add(new TPCZelfstudieCursus
                {
                    Naam = "Engels in 24 uur",
                    AantalDagen = 1
                });

                context.SaveChanges();
                Console.WriteLine("Einde");
            }
            Console.ReadKey();
        }
    }
}

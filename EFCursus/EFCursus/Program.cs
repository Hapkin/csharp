﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EFCursus
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.Write("Minimum wedde:");
            decimal minWedde;
            if (decimal.TryParse(Console.ReadLine(), out minWedde))
            {
                using (var entities = new EFOpleidingenEntities())
                {
                    Console.WriteLine(entities.GetType());

                    //foreach (var docent in entities.Docenten)
                    //{
                    //    Console.WriteLine(docent.Naam);
                    //}

                    var query = entities.Docenten
                        .Where(docent => docent.Wedde >= minWedde) // (1) 
                        .OrderBy(docent => docent.Voornaam) // (2) 
                        .ThenBy(docent => docent.Familienaam); // (3) 
                    foreach (var docent in query)
                    {
                        //Console.WriteLine("{0}: {1}", docent.Naam, docent.Wedde);
                    }






                }
            }
            else { Console.WriteLine("Tik een getal"); }


            //via Query

            Console.Write("Sorteren:1=op wedde, 2=op familienaam, 3=op voornaam:");
            var sorterenOp = Console.ReadLine();
            using (var entities = new EFOpleidingenEntities())
            {
                IQueryable<Docenten> query; // Het type van de variabele query is een 
                                            // LINQ-query die Docent-entities teruggeeft 
                switch (sorterenOp)
                {
                    case "1":
                        query = from docent in entities.Docenten
                                where docent.Wedde >= minWedde
                                orderby docent.Wedde
                                select docent;
                        break;
                    case "2":
                        query = from docent in entities.Docenten
                                where docent.Wedde >= minWedde
                                orderby docent.Familienaam
                                select docent; // deze query lijkt sterk op de vorige 
                        break;
                    case "3":
                        query = from docent in entities.Docenten
                                where docent.Wedde >= minWedde
                                orderby docent.Voornaam
                                select docent; // deze query lijkt sterk op de vorige 
                        break;
                    default:
                        Console.WriteLine("Verkeerde keuze");
                        query = null;
                        break;
                }
                if (query != null)
                {
                    foreach (var docent in query)
                    {
                        Console.WriteLine("{0}: {1}", docent.Naam, docent.Wedde);
                    }
                }
                else
                {
                    Console.WriteLine("U tikte geen getal");
                }



                //via Lambda
                Console.Write("Sorteren:1=op wedde, 2=op familienaam, 3=op voornaam:");
                var sorterenOpL = Console.ReadLine();
                Func<Docenten, Object> sorteerLambda;
                switch (sorterenOpL)
                {
                    case "1":
                        sorteerLambda = (docent) => docent.Wedde;
                        break;
                    case "2":
                        sorteerLambda = (docent) => docent.Familienaam;
                        break;
                    case "3":
                        sorteerLambda = (docent) => docent.Voornaam;
                        break;
                    default:
                        Console.WriteLine("Verkeerde keuze");
                        sorteerLambda = null;
                        break;
                }
                if (sorteerLambda != null)
                {
                    using (var entitiesL = new EFOpleidingenEntities())
                    {
                        var queryL = entities.Docenten
                        .Where(docent => docent.Wedde >= minWedde)
                        .OrderBy(sorteerLambda);
                        foreach (var docent in queryL)
                        {
                            Console.WriteLine("{0}: {1}", docent.Naam, docent.Wedde);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("U tikte geen getal");
                }
            }




            using (var entities = new EFOpleidingenEntities())
            {
                Console.Write("DocentNr.: 123");
                if (int.TryParse(Console.ReadLine(), out int docentNr))
                {
                    var docent = entities.Docenten.Find(docentNr);
                    Console.WriteLine(docent == null ? "Niet gevonden" : docent.Naam);
                }
                else
                {
                    Console.WriteLine("U tikte geen getal");
                }
            }*/


            /*
            using (var entities = new EFOpleidingenEntities())
            {
                //LINQ
                var query = from campus in entities.Campussen
                            orderby campus.Naam
                            select new { campus.CampusNr, campus.Naam }; // (1) 



                //LAMBDA
                query = entities.Campussen
                    .OrderBy(campus => campus.Naam)
                    .Select(campus => new { campus.CampusNr, campus.Naam });




                foreach (var campusDeel in query)
                {
                    Console.WriteLine("{0}: {1}", campusDeel.CampusNr, campusDeel.Naam);
                }
            }*/

            /*
            using (var entities = new EFOpleidingenEntities())
            {
                //LINQ
                var query = from docent in entities.Docenten
                            group docent by docent.Voornaam into VoornaamGroep
                            select new { VoornaamGroep, Voornaam = VoornaamGroep.Key }; // (1) 
                //LAMBDA
                var queryL = entities.Docenten
                    .GroupBy((docent) => docent.Voornaam,
                    (Voornaam, docenten) => new { Voornaam, VoornaamGroep = docenten });


                //lange weg?
                var q = entities.Docenten.GroupBy(p => p.Voornaam);
                foreach (var voornaam in q)
                {
                    Console.WriteLine(voornaam.Key);
                    Console.WriteLine(new string('-', voornaam.Key.Length));
                    var qnamen = entities.Docenten.Where(x => x.Voornaam == voornaam.Key);
                    foreach (var item in qnamen)
                    {
                        Console.WriteLine(item.Naam.ToString());
                    }
                }
                

                //q.ToList().ForEach(v => Console.WriteLine(v.Key.ToString()));


                foreach (var voornaamStatistiek in queryL)
                {
                    Console.WriteLine(voornaamStatistiek.Voornaam);
                    Console.WriteLine(new string('-', voornaamStatistiek.Voornaam.Length));
                    
                    foreach (var docent in voornaamStatistiek.VoornaamGroep)
                    {
                        Console.WriteLine(docent.Naam);
                    }
                    Console.WriteLine();
                }
            }*/

            /*
            //LAZY LOADING  => slecht
            using (var entities = new EFOpleidingenEntities())
            {
                Console.Write("Voornaam:");
                var voornaam = Console.ReadLine();
                var query = from docent in entities.Docenten
                            where docent.Voornaam == voornaam
                            select docent; // (1) 
                foreach (var docent in query)
                {
                    Console.WriteLine("{0} : {1}", docent.Naam, docent.Campus.Naam); // (2) 
                    //wanneer Campus.Naam wordt opgeroepen gaat EF een query starten om de campus naam te weten te komen...
                    //EF heeft 9 SQL-select-statements naar de database gestuurd:
                }
            }*/

            /*
            //EAGER LOADING  => 
            using (var entities = new EFOpleidingenEntities())
            {
                Console.Write("Voornaam:");
                var voornaam = Console.ReadLine();
                // Include gaat ervoor zorgen dat Campus mee ingelezen wordt
                var query = from docent in entities.Docenten.Include("Campus") // (1) 
                            where docent.Voornaam == voornaam
                            select docent;
                foreach (var docent in query)
                {
                    Console.WriteLine("{0}:{1}", docent.Naam, docent.Campus.Naam);
                    //EF heeft 1 SQL-select-statements naar de database gestuurd met een inner join
                }
            }*/
            /*
            using (var entities = new EFOpleidingenEntities())
            {
                Console.Write("Deel naam campus: Delos");
                var deelNaam = "Delos";
                //var query = from campus in entities.Campussen.Include("Docenten")
                //            where campus.Naam.Contains(deelNaam)
                //            orderby campus.Naam
                //            select campus;

                var query = entities.Campussen.Include("Docenten")
                    .Where(campus => campus.Naam.Contains(deelNaam))
                    .OrderBy(campus => campus.Naam);


                foreach (var campus in query)
                {
                    var campusNaam = campus.Naam;
                    Console.WriteLine(campusNaam);
                    Console.WriteLine(new string('-', campusNaam.Length));
                    foreach (var docent in campus.Docenten)
                    {
                        Console.WriteLine(docent.Naam);
                    }
                    Console.WriteLine();
                }
            }

            */

            //foreach (var campus in FindAllCampussen())
            //{ Console.WriteLine(campus.Naam); }

            /*
            var campus = new Campussen
            {
                Naam = "Naam2",
                Straat = "Straat1",
                HuisNr = "1",
                PostCode = "1111",
                Gemeente = "Gemeente"
            };
            var campus2 = new Campussen
            {
                Naam = "Naam3",
                Straat = "Straat1",
                HuisNr = "1",
                PostCode = "1111",
                Gemeente = "Gemeente"
            };
            using (var entities = new EFOpleidingenEntities())
            {
                entities.Campussen.Add(campus); // (1) 
                entities.Campussen.Add(campus2);
                entities.SaveChanges(); // (2) 
                Console.WriteLine(campus.CampusNr); // (3) 
            }*/
            /*
            Campussen campus4 = new Campussen
            {
                Naam = "Naam4",
                Straat = "Straat4",
                HuisNr = "4",
                PostCode = "4444",
                Gemeente = "Gemeente4"
            };
            var docent1 = new Docenten
            {
                Voornaam = "Voornaam1",
                Familienaam = "Familienaam1",
                Wedde = 1
            };
            //var a = campus4.Docenten.GetType();  // system.collection
            // docent associëren met campus door hem toe te voegen aan de verzameling docenten van die campus 
            campus4.Docenten.Add(docent1);
            using (var entities = new EFOpleidingenEntities())
            {
                entities.Campussen.Add(campus4);
                entities.SaveChanges();
            }*/

            /*
             var campus5 = new Campussen
            {
                Naam = "Naam5",
                Straat = "Straat5",
                HuisNr = "5",
                PostCode = "5555",
                Gemeente = "Gemeente5"
            };
            var docent2 = new Docenten
            {
                Voornaam = "Voornaam2",
                Familienaam = "Familienaam2",
                Wedde = 2
            };
            // docent associëren met campus door de property Campus van de docent in te vullen: 
            docent2.Campus = campus5;
            using (var entities = new EFOpleidingenEntities())
            {
                entities.Docenten.Add(docent2);
                entities.SaveChanges();
            }*/
            /*
            var docent3 = new Docenten
            {
                Voornaam = "Voornaam3",
                Familienaam = "Familienaam3",
                Wedde = 3
            };
            using (var entities = new EFOpleidingenEntities())
            {
                var campus1 = entities.Campussen.Find(1); // ZOEKEN OP PRIMARY KEY
                if (campus1 != null)
                {
                    entities.Docenten.Add(docent3);
                    docent3.Campus = campus1;
                    entities.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Campus 1 niet gevonden");
                }
            }*/
            /*
            var docent4 = new Docenten()
            {
                Voornaam = "Voornaam4",
                Familienaam = "Familienaam4",
                Wedde = 4,
                CampusNr = 1
            };
            using (var entities = new EFOpleidingenEntities())
            {
                
                entities.Docenten.Add(docent4);
                entities.SaveChanges();
            }

            var docent5 = new Docenten { Voornaam = "Voornaam5", Familienaam = "Familienaam5", Wedde = 5 };
            using (var entities = new EFOpleidingenEntities())
            {
                var campus1 = entities.Campussen.Find(1);
                if (campus1 != null)
                {
                    campus1.Docenten.Add(docent5);
                    entities.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Campus 1 niet gevonden");
                }


            }
            */
            /*
            Console.Write("DocentNr.:");
            if (int.TryParse(Console.ReadLine(), out int docentNr))
            {
                using (var entities = new EFOpleidingenEntities())
                {
                    var docent = entities.Docenten.Find(docentNr);
                    if (docent != null)
                    {
                        Console.WriteLine("Wedde:{0}", docent.Wedde);
                        Console.Write("Bedrag:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal bedrag))
                        {
                            docent.Opslag(bedrag);
                            entities.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Tik een getal");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Docent niet gevonden");
                    }
                }
            }
            else
            {
                Console.WriteLine("Tik een getal");
            }
            */
            /*
            using (var entities = new EFOpleidingenEntities())
            {
                var docent1 = entities.Docenten.Find(1);
                if (docent1 != null)
                {
                    var campus6 = entities.Campussen.Find(6);
                    if (campus6 != null)
                    {
                        docent1.Campus = campus6;
                        entities.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Campus 6 niet gevonden");
                    }
                }
                else
                {
                    Console.WriteLine("Docent 1 niet gevonden");
                }
            }
            using (var entities = new EFOpleidingenEntities())
            {
                var docent1 = entities.Docenten.Find(1);
                if (docent1 != null)
                {
                    docent1.CampusNr = 2;
                    entities.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Docent 1 niet gevonden");
                }
            }
            
            using (var entities = new EFOpleidingenEntities())
            {
                var docent1 = entities.Docenten.Find(1);
                if (docent1 != null)
                {
                    var campus3 = entities.Campussen.Find(3);
                    if (campus3 != null)
                    {
                        campus3.Docenten.Add(docent1);
                        entities.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Campus 3 niet gevonden");
                    }
                }
                else
                {
                    Console.WriteLine("Docent 1 niet gevonden");
                }
            }*/


            /*
            if (int.TryParse("15", out int docentNr))
            {
                using (var entities = new EFOpleidingenEntities())
                {
                    var docent = entities.Docenten.Find(docentNr);
                    if (docent != null)
                    {
                        entities.Docenten.Remove(docent);
                        entities.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Docent niet gevonden");
                    }
                }
            }
            else
            {
                Console.WriteLine("Tik een getal");
            }*/

            //h9TransactieScope();

            h11MeeropMeer();

            Console.ReadKey();
        }


        static List<Campussen> FindAllCampussen()
        {
            using (var entities = new EFOpleidingenEntities())
            {
                return (from campus in entities.Campussen
                        orderby campus.Naam
                        select campus).ToList();
            }
        }

        static void h9TransactieScope()
        {
            try
            {
                Console.Write("Artikel nr.: 10");
                var artikelNr = int.Parse(Console.ReadLine());
                Console.Write("Van magazijn nr.: 1");
                var vanMagazijnNr = int.Parse(Console.ReadLine());
                Console.Write("Naar magazijn nr: 2");
                var naarMagazijnNr = int.Parse(Console.ReadLine());
                Console.Write("Aantal stuks: (max 100)");
                var aantalStuks = int.Parse(Console.ReadLine());
                //VoorraadTransfer1(artikelNr, vanMagazijnNr, naarMagazijnNr, aantalStuks);
                VoorraadTransfer2(artikelNr, vanMagazijnNr, naarMagazijnNr, aantalStuks);
            }
            catch (FormatException)
            {
                Console.WriteLine("Tik een getal");
            }

        }
        static void VoorraadTransfer1(int artikelNr, int vanMagazijnNr, int naarMagazijnNr, int aantalStuks)
        { //geen eigen transactiebeheer
            using (var entities = new EFOpleidingenEntities())
            {
                var vanVoorraad = entities.Voorraden.Find(vanMagazijnNr, artikelNr);
                if (vanVoorraad != null)
                {
                    if (vanVoorraad.AantalStuks >= aantalStuks) // (1)
                    {
                        vanVoorraad.AantalStuks -= aantalStuks; // (2)
                        var naarVoorraad = entities.Voorraden.Find(naarMagazijnNr, artikelNr);
                        if (naarVoorraad != null) // voorraad aanpassen
                        {
                            naarVoorraad.AantalStuks += aantalStuks;
                        }
                        else // nieuwe voorraad aanmaken
                        {
                            naarVoorraad = new Voorraad
                            {
                                ArtikelNr = artikelNr,
                                MagazijnNr = naarMagazijnNr,
                                AantalStuks = aantalStuks
                            };
                            entities.Voorraden.Add(naarVoorraad);
                        }
                        entities.SaveChanges(); // (3)
                    }
                    else
                    {
                        Console.WriteLine("Te weinig voorraad voor transfer");
                    }
                }
                else
                {
                    Console.WriteLine("Artikel niet gevonden in magazijn {0}", vanMagazijnNr);
                }
            }
        }

        static void VoorraadTransfer2(int artikelNr, int vanMagazijnNr, int naarMagazijnNr, int aantalStuks)
        { //Repeatable read
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead
            };
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
            transactionOptions))
            {
                using (var entities = new EFOpleidingenEntities())
                {
                    var vanVoorraad = entities.Voorraden.Find(vanMagazijnNr, artikelNr);
                    if (vanVoorraad != null)
                    {
                        if (vanVoorraad.AantalStuks >= aantalStuks)
                        {
                            vanVoorraad.AantalStuks -= aantalStuks;
                            var naarVoorraad =
                            entities.Voorraden.Find(naarMagazijnNr, artikelNr);
                            if (naarVoorraad != null) // voorraad aanpassen
                            {
                                naarVoorraad.AantalStuks += aantalStuks;
                            }
                            else // nieuwe voorraad aanmaken
                            {
                                naarVoorraad = new Voorraad
                                {
                                    ArtikelNr = artikelNr,
                                    MagazijnNr = naarMagazijnNr,
                                    AantalStuks = aantalStuks
                                };
                                entities.Voorraden.Add(naarVoorraad);
                            }
                            entities.SaveChanges();
                            transactionScope.Complete();
                        }
                        else
                        {
                            Console.WriteLine("Te weinig voorraad voor transfer");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Artikel niet gevonden in magazijn {0}",
                        vanMagazijnNr);
                    }
                }
            }
        }

        static void h10RecordLocking()
        {
            try
            {
                Console.Write("Artikel nr.:");
                var artikelNr = int.Parse(Console.ReadLine());
                Console.Write("Magazijn nr.:");
                var magazijnNr = int.Parse(Console.ReadLine());
                Console.Write("Aantal stuks toevoegen:");
                var aantalStuks = int.Parse(Console.ReadLine());
                VoorraadBijvulling2(artikelNr, magazijnNr, aantalStuks);
            }
            catch (FormatException)
            {
                Console.WriteLine("Tik een getal");
            }

        }
        static void VoorraadBijvulling1(int artikelNr, int magazijnNr, int aantalStuks)
        {
            using (var entities = new EFOpleidingenEntities())
            {
                var voorraad = entities.Voorraden.Find(magazijnNr, artikelNr);
                if (voorraad != null)
                {
                    voorraad.AantalStuks += aantalStuks;
                    Console.WriteLine("Pas nu de voorraad aan met de Server Explorer," +
                    " druk daarna op Enter");
                    Console.ReadLine();
                    entities.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Voorraad niet gevonden");
                }
            }
        }
        static void VoorraadBijvulling2(int artikelNr, int magazijnNr, int aantalStuks)
        {
            using (var entities = new EFOpleidingenEntities())
            {
                var voorraad = entities.Voorraden.Find(magazijnNr, artikelNr);
                if (voorraad != null)
                {
                    voorraad.AantalStuks += aantalStuks;
                    Console.WriteLine("Pas nu de voorraad aan in de Server Explorer," +
                        " druk daarna op Enter");
                    Console.ReadLine();
                    try
                    {
                        entities.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        Console.WriteLine("Voorraad werd door andere applicatie aangepast.");
                    }
                }
                else
                {
                    Console.WriteLine("Voorraad niet gevonden");
                }
            }
        }

        static void h11MeeropMeer()
        {
            //lees per boek welke cursussen
            using (var entities = new EFOpleidingenEntities())
            {
                var query = from boek in entities.Boeken.Include("Cursussen")
                            orderby boek.Titel
                            select boek;
                foreach (var boek in query)
                {
                    Console.WriteLine(boek.Titel);
                    foreach (var cursus in boek.Cursussen)
                    {
                        Console.WriteLine("\t{0}", cursus.Naam);
                    }
                }
            }
            //lees per cursus welke boeken 
            using (var entities = new EFOpleidingenEntities())
            {
                var query = from cursus in entities.Cursussen.Include("Boeken")
                            orderby cursus.Naam
                            select cursus;
                foreach (var cursus in query)
                {
                    Console.WriteLine(cursus.Naam);
                    foreach (var boek in cursus.Boeken)
                    {
                        Console.WriteLine("\t{0}", boek.Titel);
                    }
                }
            }


            //maak een nieuw boek en koppel aan cursus Oracle
            /*using (var entities = new EFOpleidingenEntities())
            {
                var nieuwBoek = new Boek
                {
                    ISBNNr = "0-0788210-6-1",
                    Titel = "Oracle Backup & Recovery Handbook"
                };
                var oracleCursus = (from cursus in entities.Cursussen
                                    where cursus.Naam == "Oracle"
                                    select cursus).FirstOrDefault();
                if (oracleCursus != null)
                {
                    oracleCursus.Boeken.Add(nieuwBoek);
                    entities.SaveChanges();
                }
                else
                {
                    Console.WriteLine("cursus Oracle niet gevonden");
                }
            }*/
            Console.WriteLine("===============================================");
            //met de tussentabel veel op veel
            using (var entities = new EFOpleidingenEntities())
            {
                var query = from cursus2 in entities.Cursussen2.Include("BoekenCursussen2.Boek2") // (1)
                            orderby cursus2.Naam
                            select cursus2;
                foreach (var cursus in query)
                {
                    Console.WriteLine(cursus.Naam);
                    foreach (var boekCursus in cursus.BoekenCursussen2)
                    {
                        Console.WriteLine("\t{0}:{1}", boekCursus.VolgNr, boekCursus.Boek2.Titel);
                    }
                }
            }


            var nieuwBoek = new Boek2() { ISBNNr = "0-201-70431-5", Titel = "Modern C++ Design" };
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.Serializable
            };
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
            transactionOptions))
            {
                using (var entities = new EFOpleidingenEntities())
                {
                    // Cursus C++ ophalen
                    // én het hoogste volgnr. van boek gebruikt in die cursus.
                    // Met transactie met isolation level Serializable
                    // kan daarna niemand anders een boek toevoegen aan C++ cursus
                    // en is het nieuwe volgnr gelijk aan 1 + hoogst gelezen volgnr
                    var query = from cursus2 in entities.Cursussen2.Include("BoekenCursussen2")
                                where cursus2.Naam == "C++"
                                select new
                                {
                                    Cursus = cursus2,
                                    HoogsteVolgnr = cursus2.BoekenCursussen2.Max(boekCursus => boekCursus.VolgNr)
                                };
                    var queryResult = query.FirstOrDefault();
                    if (queryResult != null)
                    {
                        entities.BoekenCursussen2.Add(new BoekenCursus2
                        {
                            Boek2 = nieuwBoek,
                            Cursus2 = queryResult.Cursus,
                            VolgNr = queryResult.HoogsteVolgnr + 1
                        });
                        entities.SaveChanges();
                    }
                    transactionScope.Complete();
                }
            }


        }




    }

}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCursus
{
    class Program
    {
        static void Main(string[] args)
        {
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
            }


            Console.ReadLine();
            }


        }

    }




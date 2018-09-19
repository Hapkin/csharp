using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestEF.DB;

namespace TestEF
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new EFLandenStedenTalen())
            {
                Landen keuzeLand = null;
                #region Landen
                //toon alle landen
                var queryLanden = context.Landen
                        .OrderBy(land => land.Naam);

                Console.WriteLine("lijst van alle landen:");
                Console.WriteLine("=======================");
                foreach (var land in queryLanden)
                {
                    Console.WriteLine($"\t {land.LandCode} - {land.Naam}");
                }
                Console.WriteLine("-----------------------");

                //welk land wil je kiezen
                Console.Write("Landcode: ");
                string keuze = Console.ReadLine().ToUpper();

                bool valid = false;
                while (!valid)
                {
                    if (Regex.Matches(keuze, @"[a-zA-Z]").Count == 3)
                    {
                        foreach (Landen land in queryLanden)
                        {
                            if (land.LandCode == keuze)
                            {
                                keuzeLand = land;
                                valid = true;
                            }

                        }
                        

                    }
                    if(!valid)
                    {
                        Console.WriteLine("gelieve een juiste landcode te geven.");
                        keuze = Console.ReadLine().ToUpper();
                    }
                }
                #endregion Landen

                #region Steden+talen
                var querySteden = context.Steden
                        .Where(stad => stad.LandCode == keuze)
                        .OrderBy(stad => stad.Naam);


                Console.WriteLine($"lijst van alle steden in {keuzeLand.Naam}:");
                Console.WriteLine("=======================");
                foreach (var stad in querySteden)
                {
                    Console.WriteLine($"\t {stad.StadNr} - {stad.Naam}");
                }
                Console.WriteLine("-----------------------");
                Console.WriteLine($"Talen: ");

                foreach (Talen taal in keuzeLand.Talen)
                {
                    Console.WriteLine(taal.Naam);

                }

                #endregion Steden+talen

                #region nieuwe stad toevoegen
                bool validStad = false;
                string nieuwestad;
                Console.WriteLine("Welke stad wil je toevoegen?");
                nieuwestad = Console.ReadLine();

                while (!validStad)
                {
                    if (Regex.Matches(nieuwestad, @"[a-zA-Z]").Count == nieuwestad.Count()&&nieuwestad.Count()>2)
                    {
                        bool bestaatReeds = false;
                        foreach (Steden stad in querySteden)
                        {
                            if(stad.Naam == nieuwestad)
                            {
                                Console.WriteLine("Deze stad bestaat reeds. Geef een andere naam in:");
                                nieuwestad = Console.ReadLine();
                                bestaatReeds = true;
                            }
                        }
                        if (!bestaatReeds)
                        {
                            keuzeLand.Steden.Add(new Steden { Naam = nieuwestad });

                            validStad = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Gelieve een normale stadsnaam in te geven.");
                        nieuwestad = Console.ReadLine();
                    }
                }

                #endregion

                context.SaveChanges();
            }


            //Console.WriteLine(keuze);




            Console.WriteLine("Alles is opgeslagen. programma wordt afgesloten.");
            Console.ReadKey();
        }
    }


}

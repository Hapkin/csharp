using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taak1_EFBank
{
    class Program
    {
        static void Main(string[] args)
        {

            /*using (var entities = new EFBankEntities())
            {
                var query = from klant in entities.Klanten.Include("Rekeningen")
                            orderby klant.Voornaam
                            select klant;
                foreach (var klant in query)
                {
                    Console.WriteLine(klant.Voornaam);
                    var totaleSaldo = Decimal.Zero;
                    foreach (var rekening in klant.Rekeningen)
                    {
                        Console.WriteLine("{0}: {1}", rekening.RekeningNr, rekening.Saldo);
                        totaleSaldo += rekening.Saldo;
                    }
                    Console.WriteLine("Totaal: {0}", totaleSaldo);
                    Console.WriteLine();
                }
                Console.ReadKey();

            }*/




            //Taak7KlantWijzigen();
            //taak8Personeel();
            //taak9InheritanceRekeningen();
            taak10Views();

            Console.ReadLine();
        }

        /*
        static void Taak3()
        {
            using (var entities = new EFBankEntities())
            {
                var query = from klant in entities.Klanten orderby klant.Voornaam select klant;
                foreach (var klant in query)
                {
                    Console.WriteLine("{0}: {1}", klant.KlantNr, klant.Voornaam);
                }
                try
                {
                    Console.Write("KlantNr:");
                    var klantNr = int.Parse(Console.ReadLine());
                    var klant = entities.Klanten.Find(klantNr);
                    if (klant == null)
                    {
                        Console.WriteLine("Klant niet gevonden");
                    }
                    else
                    {
                        Console.Write("RekeningNr:");
                        var rekeningNr = Console.ReadLine();
                        var rekening = new Rekeningen { RekeningNr = rekeningNr, Soort = "Z" };
                        klant.Rekeningen.Add(rekening);
                        entities.SaveChanges();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Tik een getal");
                }
            }
        }*/


        static void Taak4Storten()
        {
            using (var entities = new EFBankEntities())
            {
                Console.Write("RekeningNr:");
                var rekeningNr = Console.ReadLine();
                var rekening = entities.Rekeningen.Find(rekeningNr);
                if (rekening == null)
                {
                    Console.WriteLine("Rekening niet gevonden");
                }
                else
                    try
                    {
                        Console.Write("Bedrag:");
                        var bedrag = decimal.Parse(Console.ReadLine());
                        if (bedrag <= Decimal.Zero)
                        {
                            Console.WriteLine("Tik een positief bedrag");
                        }
                        else
                        {
                            rekening.Storten(bedrag);
                            entities.SaveChanges();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Tik een bedrag");
                    }
            }
        }

        static void Taak5Verwijderen()
        {
            try
            {
                Console.Write("KlantNr:");
                var klantNr = int.Parse(Console.ReadLine());
                using (var entities = new EFBankEntities())
                {
                    var klant = entities.Klanten.Find(klantNr);
                    if (klant == null)
                    {
                        Console.WriteLine("Klant niet gevonden");
                    }
                    else
                    {
                        if (klant.Rekeningen.Count != 0)
                        {
                            Console.WriteLine("Klant heeft nog rekeningen");
                        }
                        else
                        {
                            entities.Klanten.Remove(klant);
                            entities.SaveChanges();
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Tik een getal");
            }
        }

        static void Taak6Overschrijven()
        {
            Console.WriteLine("rekening nr1: 123-4567890-02");
            Console.WriteLine("rekening nr2: 234-5678901-69");
            string rekening2 = "123-4567890-02";
            string rekening1 = "234-5678901-69";





            try
            {
                using (var entities = new EFBankEntities())
                {
                    var oRekening1 = entities.Rekeningen.Find(rekening1);
                    if (oRekening1 == null)
                    {
                        Console.WriteLine("Van-Rekening niet gevonden");
                    }
                    else
                    {
                        var oRekening2 = entities.Rekeningen.Find(rekening2);
                        if (oRekening2 == null)
                        {
                            Console.WriteLine("Naar-Rekening niet gevonden");
                        }
                        else
                        {
                            //beide rekeningen bestaan
                            Console.WriteLine("Hoeveel wil je overschrijven?");
                            decimal bedrag = 0;
                            while (bedrag <= 0)
                            {
                                Console.WriteLine("gelieve het bedrag in the geven");
                                if (!decimal.TryParse(Console.ReadLine(), out bedrag))
                                    bedrag = 0;
                                else
                                {
                                    if (bedrag > oRekening1.Saldo)
                                    {
                                        Console.WriteLine("Saldo ontoereikend.");
                                        bedrag = 0;
                                    }
                                }

                            }

                            //het bedrag is toereikend en positief
                            Console.WriteLine($"Rekening-Saldo: {oRekening1.Saldo}");
                            Console.WriteLine($"Rekening2-Saldo: {oRekening2.Saldo}");

                            oRekening1.Saldo -= bedrag;
                            oRekening2.Saldo += bedrag;

                            Console.WriteLine("------------------- Nieuwe saldos");
                            Console.WriteLine($"Rekening-Saldo: {oRekening1.Saldo}");
                            Console.WriteLine($"Rekening2-Saldo: {oRekening2.Saldo}");




                            entities.SaveChanges();
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Tik een getal");
            }







        }

        static void Taak7KlantWijzigen()
        {
            Console.Write("KlantNr:");
            try
            {
                var klantNr = int.Parse(Console.ReadLine());
                using (var entities = new EFBankEntities())
                {
                    var klant = entities.Klanten.Find(klantNr);
                    if (klant == null)
                    {
                        Console.WriteLine("Klant niet gevonden");
                    }
                    else
                    {
                        Console.Write("Voornaam:");
                        klant.Voornaam = Console.ReadLine();
                        entities.SaveChanges();
                    }
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Een andere gebruiker wijzigde deze klant");
            }
            catch (FormatException)
            {
                Console.WriteLine("Tik een getal");
            }
        }

        static void taak8Personeel()
        {
            using (var entities = new EFBankEntities())
            {


                var query = (from Mederwerkers in entities.Personeel
                             where Mederwerkers.Manager == null
                             select Mederwerkers).ToList();


                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Voornaam);
                //    item.Mederwerkers.ToList().ForEach(i => Console.WriteLine(i.Voornaam));
                //}


                taak8Afbeelden(query, 0);
            }
        }
        static void taak8Afbeelden(List<Personeel> personeel, int insprong)
        {
            foreach (var personeelslid in personeel)
            {
                Console.Write(new String('\t', insprong));
                Console.WriteLine(personeelslid.Voornaam);
                if (personeelslid.Mederwerkers.Count != 0)
                {
                    taak8Afbeelden(personeelslid.Mederwerkers.ToList(), insprong + 1);
                }
            }

        }


        static void taak9InheritanceRekeningen()
        {
            using (var entities = new EFBankEntities())
            {
                var query = from rekening in entities.Rekeningen
                                //orderby rekening.GetType()
                            where rekening is Zichtrekening
                            select rekening;

                foreach (var rekening in query)
                {
                    Console.WriteLine($"{rekening.RekeningNr}: saldo={rekening.Saldo } type: {rekening.GetType().Name}");
                }
            }

        }

        static void taak10Views()
        {
            using (var entities = new EFBankEntities())
            {
                var query = from TotaleSaldoPerKlant
                            in entities.TotaleSaldoPerKlant
                            orderby TotaleSaldoPerKlant.KlantNr,
                            TotaleSaldoPerKlant.Voornaam
                            select TotaleSaldoPerKlant;
                foreach (var klant in query)
                {
                    Console.WriteLine($"{klant.KlantNr} {klant.Voornaam}: {klant.TotaleSaldo}");
                }
            }

        }
    }
}

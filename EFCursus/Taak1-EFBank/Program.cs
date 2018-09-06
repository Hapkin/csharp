using System;
using System.Collections.Generic;
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






            Console.ReadLine();
        }

        public void Taak3()
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
        }


        public void Taak4Storten()
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

        public void Taak5Verwijderen()
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
    }
}

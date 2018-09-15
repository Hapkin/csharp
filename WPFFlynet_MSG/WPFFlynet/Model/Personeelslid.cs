using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static WPFFlynet.App;


namespace WPFFlynet.Personeel
{
    public abstract class Personeelslid : IKost
    {
        //  CONSTRUCTORS  //
        public Personeelslid(string id, string naam, decimal prijsPerDag)
        {
            this.PersoneelsID = id;
            this.Naam = naam;
            this.BasisKostprijsPerDag = prijsPerDag;

        }

        //   FIELDS   //
        private string personeelsIDValue;
        private string naamValue;


        // ENUM + PROPERTIES //
        public string PersoneelsID
        {
            get { return personeelsIDValue; }
            set {
                try { 
                if (value != "")
                        personeelsIDValue = value;
                else
                    throw new Exception("PersoneelsID mag niet leeg zijn");
                
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
                
        }
        public string Naam {
            get { return naamValue; }
            set
            {
                try
                {
                    if (value != "")
                        naamValue = value;
                    
                    else
                        throw new Exception("naam mag niet leeg zijn");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public decimal BasisKostprijsPerDag { get; set; }

        // METHODS + EVENTS //
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.PersoneelsID} - {this.Naam}");

            return sb.ToString();
        }
        public virtual decimal BerekenTotaleKostprijsPerDag()
        {
            decimal prijs = 0;
            prijs = this.BasisKostprijsPerDag;


            return prijs;
        }

    }
}

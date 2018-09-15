using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFlynet.Personeel
{
    public class Certificaat : INotifyPropertyChanged
    {
        //  CONSTRUCTORS  //


        //   FIELDS   //


        // ENUM + PROPERTIES //
        public string CertificaatAfkorting { get; set; }
        public string CertificaatOmschrijving { get; set; }

        // METHODS + EVENTS //
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Afkorting: {this.CertificaatAfkorting}");
            sb.AppendLine($"Omschrijving: {this.CertificaatOmschrijving}");


            return sb.ToString();
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

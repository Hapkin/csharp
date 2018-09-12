using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    public class Instructeur // (1)
    {
        public int Id { get; set; } // (2)
        public string Voornaam { get; set; } // (3)
        public string Familienaam { get; set; }
        [Column("maandwedde")]
        public decimal Wedde { get; set; }
        public DateTime InDienst { get; set; }
        public bool HeeftRijbewijs { get; set; }
        public void Opslag(decimal percentage)
        {
            Wedde *= (1M + percentage / 100M);
        }
    }
}

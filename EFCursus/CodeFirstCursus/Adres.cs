using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    [ComplexType] // (1)
    public class Adres
    {
        [Column("Straat")]
        public string Straat { get; set; }
        [Column("HuisNr")]
        public string HuisNr { get; set; }
        [Column("PostCode")]
        public string PostCode { get; set; }
        [Column("Gemeente")]
        public string Gemeente { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    [Table("TPCZelfstudiecursussen")] // using System.ComponentModel.DataAnnotations.Schema;
    public class TPCZelfstudieCursus : TPCCursus
    {
        public int AantalDagen { get; set; }
    }
}

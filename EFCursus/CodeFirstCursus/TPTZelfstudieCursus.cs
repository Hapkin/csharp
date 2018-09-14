using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    [Table("TPTZelfstudiecursussen")]
    public class TPTZelfstudieCursus : TPTCursus
    {
        public int AantalDagen { get; set; }
    }
}

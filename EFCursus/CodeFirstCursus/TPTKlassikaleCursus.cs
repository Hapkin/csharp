using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    [Table("TPTKlassikalecursussen")] // using System.ComponentModel.DataAnnotations.Schema;
    public class TPTKlassikaleCursus : TPTCursus
    {
        public DateTime Van { get; set; }
        public DateTime Tot { get; set; }
    }
}

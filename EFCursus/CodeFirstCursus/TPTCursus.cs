using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    [Table("TPTCursussen")]
    public abstract class TPTCursus
    {
        public int Id { get; set; }
        public string Naam { get; set; }
    }
}

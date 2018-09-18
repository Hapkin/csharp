using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taak12_CodeFirst.DB
{
    [Table("NonFoodArtikel")]
    public class NonFoodArtikel : Artikel
    {
        public int Garantie { get; set; }
    }
}

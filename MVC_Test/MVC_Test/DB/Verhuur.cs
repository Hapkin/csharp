namespace MVC_Test.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Verhuur")]
    public partial class Verhuur
    {
        [Key]
        public int VerhuurNr { get; set; }

        public int KlantNr { get; set; }

        public int BandNr { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public DateTime VerhuurDatum { get; set; }

        public virtual Film Films { get; set; }

        public virtual Klant Klanten { get; set; }
    }
}

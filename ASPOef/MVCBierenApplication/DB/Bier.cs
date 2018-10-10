namespace MVCBierenApplication.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bieren")]
    public partial class Bier
    {
        [DisplayFormat(DataFormatString = "{0:000}")]
        [Key]
        [Column("BierNr")]
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max. {1} tekens voor {0}")]
        public string Naam { get; set; }

        public int BrouwerNr { get; set; }

        public int SoortNr { get; set; }

        [UIHint("kleuren")]
        [AlcoholGrenzen(ErrorMessage = "{0} heeft een ongeldige waarde")]
        public float? Alcohol { get; set; }

        public virtual Brouwer Brouwers { get; set; }

        public virtual Soort Soorten { get; set; }
    }
    /*
    [DisplayFormat(DataFormatString = "{0:000}")]
        public int ID { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Max. {1} tekens voor {0}")]
        public string Naam { get; set; }
        [UIHint("kleuren")]
        [AlcoholGrenzen(ErrorMessage = "{0} heeft een ongeldige waarde")]
        public float Alcohol { get; set; } 
    
      */
}

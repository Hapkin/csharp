namespace MVC_Test.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klanten")]
    public partial class Klant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klant()
        {
            Verhuur = new HashSet<Verhuur>();
        }

        [Key]

        public int KlantNr { get; set; }

        
        [StringLength(50)]
        public string Naam { get; set; }

        [Required]
        [StringLength(50)]
        public string Voornaam { get; set; }

        [Required]
        [StringLength(50)]
        public string Straat_Nr { get; set; }

        
        public int PostCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Gemeente { get; set; }

        [Required]
        [StringLength(50)]
        public string KlantStat { get; set; }

        public int HuurAantal { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatumLid { get; set; }

        public bool Lidgeld { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verhuur> Verhuur { get; set; }


        

    }
}

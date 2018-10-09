namespace MVC_Tuincentrum2.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Leveranciers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Leveranciers()
        {
            Planten = new HashSet<Planten>();
        }

        [Key]
        public int LevNr { get; set; }

        [Required]
        [StringLength(30)]
        public string Naam { get; set; }

        [Required]
        [StringLength(30)]
        public string Adres { get; set; }

        [Required]
        [StringLength(10)]
        public string PostNr { get; set; }

        [Required]
        [StringLength(30)]
        public string Woonplaats { get; set; }

        [Range(0,256) ]
        public byte? Test { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Planten> Planten { get; set; }
    }
}

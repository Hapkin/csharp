namespace MVCBierenApplication.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Brouwer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brouwer()
        {
            Bieren = new HashSet<Bier>();
        }

        [Key]
        public int BrouwerNr { get; set; }

        [Required]
        [StringLength(50)]
        public string BrNaam { get; set; }

        [Required]
        [StringLength(50)]
        public string Adres { get; set; }

        public short PostCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Gemeente { get; set; }

        public int? Omzet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bier> Bieren { get; set; }
    }
}

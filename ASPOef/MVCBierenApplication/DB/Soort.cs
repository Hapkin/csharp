namespace MVCBierenApplication.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Soorten")]
    public partial class Soort
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Soort()
        {
            Bieren = new HashSet<Bier>();
        }

        [Key]
        public int SoortNr { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Soort")]
        public string Naam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bier> Bieren { get; set; }
    }
}

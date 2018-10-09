namespace MVC_Tuincentrum2.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Soorten")]
    public partial class Soorten
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Soorten()
        {
            Planten = new HashSet<Planten>();
        }

        [Key]
        public int SoortNr { get; set; }

        [Required]
        [StringLength(10)]
        public string Soort { get; set; }

        public byte MagazijnNr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Planten> Planten { get; set; }
    }
}

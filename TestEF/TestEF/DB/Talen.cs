namespace TestEF.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Talen")]
    public partial class Talen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Talen()
        {
            Landen = new HashSet<Landen>();
        }

        [Key]
        [StringLength(3)]
        public string TaalCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Naam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Landen> Landen { get; set; }
    }
}

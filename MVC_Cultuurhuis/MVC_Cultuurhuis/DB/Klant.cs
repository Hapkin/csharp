namespace MVC_Cultuurhuis.DB
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
            Reservaties = new HashSet<Reservatie>();
        }

        [Key]
        public int KlantNr { get; set; }

        [Required]
        [StringLength(50)]
        public string Voornaam { get; set; }

        [Required]
        [StringLength(50)]
        public string Familienaam { get; set; }

        [Required]
        [StringLength(50)]
        public string Straat { get; set; }

        [Required]
        [StringLength(50)]
        public string HuisNr { get; set; }

        [Required]
        [StringLength(50)]
        public string Postcode { get; set; }

        [Required]
        [StringLength(50)]
        public string Gemeente { get; set; }

        [Required]
        [StringLength(50)]
        public string GebruikersNaam { get; set; }

        [Required]
        [StringLength(50)]
        public string Paswoord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservatie> Reservaties { get; set; }
    }
}

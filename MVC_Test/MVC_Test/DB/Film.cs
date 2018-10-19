namespace MVC_Test.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            Verhuur = new HashSet<Verhuur>();
        }

        [Key]
        public int BandNr { get; set; }

        [Required]
        [StringLength(50)]
        public string Titel { get; set; }

        public int GenreNr { get; set; }

        public int InVoorraad { get; set; }

        public int UitVoorraad { get; set; }

        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Prijs { get; set; }

        public int TotaalVerhuurd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verhuur> Verhuur { get; set; }

        public virtual Genre Genres { get; set; }
    }
}

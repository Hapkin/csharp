namespace MVC_Cultuurhuis.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Voorstellingen")]
    public partial class Voorstelling
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Voorstelling()
        {
            Reservaties = new HashSet<Reservatie>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VoorstellingsNr { get; set; }

        [Required]
        [StringLength(50)]
        public string Titel { get; set; }

        [Required]
        [StringLength(50)]
        public string Uitvoerders { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public DateTime Datum { get; set; }

        public int GenreNr { get; set; }

        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Prijs { get; set; }

        public short VrijePlaatsen { get; set; }

        public virtual Genre Genres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservatie> Reservaties { get; set; }
    }
}

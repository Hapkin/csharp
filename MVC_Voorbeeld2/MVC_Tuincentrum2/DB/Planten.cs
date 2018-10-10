namespace MVC_Tuincentrum2.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Planten")]
    public partial class Planten
    {
        

        
        [Key]
        public int PlantNr { get; set; }

        [Required]
        [StringLength(30)]
        public string Naam { get; set; }

        public int SoortNr { get; set; }

        [ScaffoldColumn(false)]
        public int Levnr { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        [StringLength(10)]
        public string Kleur { get; set; }

        //[HiddenInput()]
        [Column(TypeName = "money")]
        [Range(0, 1000)]
        public decimal VerkoopPrijs { get; set; }

        [ScaffoldColumn(false)]
        public virtual Leveranciers Leveranciers { get; set; }

        public virtual Soorten Soorten { get; set; }

        
    }
}

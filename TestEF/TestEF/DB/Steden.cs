namespace TestEF.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Steden")]
    public partial class Steden
    {
        [Key]
        public int StadNr { get; set; }

        [Required]
        [StringLength(50)]
        public string Naam { get; set; }

        [Required]
        [StringLength(3)]
        public string LandCode { get; set; }

        public virtual Landen Land { get; set; }
    }
}

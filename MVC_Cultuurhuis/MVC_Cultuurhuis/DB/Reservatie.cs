namespace MVC_Cultuurhuis.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservatie
    {
        [Key]
        public int ReservatieNr { get; set; }

        public int KlantNr { get; set; }

        public int VoorstellingsNr { get; set; }

        public short Plaatsen { get; set; }

        public virtual Klant Klanten { get; set; }

        public virtual Voorstelling Voorstellingen { get; set; }
    }
}

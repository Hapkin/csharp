//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Taak1_EFBank
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rekeningen
    {
        public string RekeningNr { get; set; }
        public int KlantNr { get; set; }
        public decimal Saldo { get; set; }
        public string Soort { get; set; }
    
        public virtual Klanten Klanten { get; set; }
    }
}

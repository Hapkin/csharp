using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBierenApplication.Models
{
    public class Bier
    {
        [DisplayFormat(DataFormatString = "{0:000}")]
        public int ID { get; set; }
        public String Naam { get; set; }
        [UIHint("kleuren")]
        public float Alcohol { get; set; }
    }
}
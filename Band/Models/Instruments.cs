using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Band.Models
{
    public class Instruments
    {
        public int ID { get; set; }
        [Display(Name = "Instrument Name")]
        public string ReadableID { get; set; }
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "Make")]
        public string Make { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
    }
}
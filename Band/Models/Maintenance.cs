using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Band.Models
{
    public class Maintenance
    {
        [Display(Name = "Instrument ID")]
        public string InstrumentName { get; set; }
        [Display(Name = "Maintenance Comment")]
        public string MComment { get; set; }
         [Display(Name = "Maintenance Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MDate { get; set; }
        [Key]
        public int MaintenanceID { get; set; }
    }
}
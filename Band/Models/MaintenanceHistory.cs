using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Band.Models
{
    public class MaintenanceHistory
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Instrument ID")]
        [ForeignKey("ID")]
        public virtual Instruments InstID { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Total Cost")]
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
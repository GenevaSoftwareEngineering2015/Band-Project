using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Band.Models
{
    public class CheckOuts
    {
        [Display(Name = "Instrument Name")]
        public string InstrumentName { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Check Out Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Check In Date")]
        public DateTime? DateIn { get; set; }
        [Display(Name = "Check Out Comment")]
        public string Comment { get; set; }
        [Display(Name = "Check In Comment")]
        public string CommentIn { get; set; }
        [Display(Name = "Status")]
        public bool IsCheckedOut { get; set; }
        public int ID { get; set; }
      
    }
}
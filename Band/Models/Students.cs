using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Band.Models
{
    public class Students
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Student Name")]
        public string StudName { get; set; }
        [Display(Name = "Student Graduation Year")]
        public string StudGradYear { get; set; }
        [Display(Name = "Instrument Type")]
        public string StudInstType { get; set; }
        [Display(Name = "Instrument Name")]
        public string StudInstrument { get; set; }
        [Display(Name = "Home Address")]
        public string StudHome { get; set; }
        [Display(Name = "School Address")]
        public string StudSchool { get; set; }
        [Display(Name = "Box Number")]
        public string StudBox { get; set; }
        [Display(Name = "Pone Number")]
        public string StudPhone { get; set; }
    }
}
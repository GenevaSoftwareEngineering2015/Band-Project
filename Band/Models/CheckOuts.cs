using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Key, Column(Order = 0)]
        [Display(Name = "Check Out Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Check In Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateIn { get; set; }

        [Display(Name = "Check Out Comment")]
        public string Comment { get; set; }

        [Display(Name = "Check In Comment")]
        public string CommentIn { get; set; }

        [Display(Name = "Status")]
        public bool IsCheckedOut { get; set; }

        [Key, Column (Order = 1)]
        public int ID { get; set; }

        [ForeignKey("ID")]
        public virtual ICollection<Instruments> Instrument { get; set; }
      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Band.Models
{
    public class Instrument
    {
        public string InstrumentID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGrede.Models
{
    public class Koordinate
    {
        public decimal x;
        public decimal y;
    }
    public class OdvisnostiViewModel
    {
        public int IdGrede { get; set; }
        public Koordinate koo {get;set;}
    }
}
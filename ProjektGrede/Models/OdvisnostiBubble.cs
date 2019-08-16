using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGrede.Models
{
    public class KoordinateBubble
    {
        public DateTime x; //dan
        public decimal y; //vlaga
        public decimal r; //padavine+zalivanje -- pazi to je v pixlih
    }
    public class KoordinateBubble1
    {
        public decimal x; //dan
        public decimal y; //vlaga
        public decimal r; //padavine+zalivanje -- pazi to je v pixlih
    }
    public class OdvisnostiBubble
    {
        public int IdGrede { get; set; }
        public KoordinateBubble koo { get; set; }
    }
    public class OdvisnostiBubble1
    {
        public int IdGrede { get; set; }
        public KoordinateBubble1 koo { get; set; }
    }
}
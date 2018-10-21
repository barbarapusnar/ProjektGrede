using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGrede.Models
{
    //viewModel za Home
    public class VsiPodatki
    {
        public int Id { get; set; }
        public int IdGrede { get; set; }
        public System.DateTime Cas { get; set; }
        public decimal Temp1 { get; set; }
        public decimal Temp2 { get; set; }
        public decimal Temp3 { get; set; }
        public decimal Vlaga { get; set; }
        public decimal ZalivanjeNam2 { get; set; }
        public System.DateTime DatumVnosa { get; set; }
        public decimal KoličinaPadavin { get; set; }
        public decimal SkupajVoda { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGrede.Models;

namespace ProjektGrede.Controllers
{
    public class HomeController : Controller
    {
        GredeEntities ge = new GredeEntities();
        public ActionResult Index()
        {
            Vreme podatki = BranjeXML.Branje();
            if (podatki != null)
            {
                string zadnjiDatum = podatki.Date.ToString();
                DateTime datum = DateTime.Parse(zadnjiDatum);
                ViewData["datum"] = datum;
                if (datum.Hour > 20 | datum.Hour < 5)
                        ViewData["delDan"] = "night";
                else
                        ViewData["deldan"] = "day";
                
            }
            ViewData["temp"] = podatki.Temp2;          
            ViewData["vlaga"] = podatki.Humidity2;
            ViewData["padavine"] = podatki.Precipitation; //preveri, ko je dež
            ViewData["omocenost"] = podatki.Leafwetness2;
            List<VsiPodatki> dataVsi = new List<VsiPodatki>();
            List<decimal> padavine = new List<decimal>(); //kolikor je mm je l na m2, greda ima velikost??
            List<decimal> nam2 = new List<decimal>();
            var data = from element in ge.PodatkiSenzorjev
                       group element by element.IdGrede
                       into groups
                       orderby groups.Key
                       select groups.OrderByDescending(p => p.Cas).FirstOrDefault();
           
            var data1 = from element in ge.PodatkiVnos
                        group element by element.IDGrede
                      into g
                        orderby g.Key
                        select g.OrderByDescending(p => p.DatumVnosa).FirstOrDefault();
            var data5 = data1.ToList();
            var data2 = (from a in ge.PodatkiVnos
                         where a.IDGrede == 1
                         orderby a.DatumVnosa descending
                         select a).Take(2).ToList();
            TimeSpan š0 = DateTime.Now-data2.ElementAt(0).DatumVnosa ;
            int štDni0 = š0.Days+1;
            
            decimal izračunNam2 = 0;
            //preveri, če je bil vmes reset števca
            if (data2.ElementAt(0).NovoStanje - data2.ElementAt(1).NovoStanje > 0)
                izračunNam2 = (data2.ElementAt(0).NovoStanje - data2.ElementAt(1).NovoStanje) / 2.4m;
            else
                izračunNam2 = data2.ElementAt(0).NovoStanje/2.4m;
            nam2.Add(izračunNam2/štDni0);
            var data3 = (from a in ge.PodatkiVnos
                         where a.IDGrede == 2
                         orderby a.DatumVnosa descending
                         select a).Take(2).ToList();
            TimeSpan š1 = DateTime.Now-data3.ElementAt(0).DatumVnosa;
            int štDni1 = š1.Days+1;
            if (data3.ElementAt(0).NovoStanje - data3.ElementAt(1).NovoStanje > 0)
                izračunNam2 = (data3.ElementAt(0).NovoStanje - data3.ElementAt(1).NovoStanje) / 2.4m;
            else
                izračunNam2 = data3.ElementAt(0).NovoStanje/2.4m;
            nam2.Add(izračunNam2/štDni1);
            var data4 = (from a in ge.PodatkiVnos
                         where a.IDGrede == 3
                         orderby a.DatumVnosa descending
                         select a).Take(2).ToList();
            TimeSpan š2 =DateTime.Now- data4.ElementAt(0).DatumVnosa;
            int štDni2 = š2.Days+1;
            if (data4.ElementAt(0).NovoStanje - data4.ElementAt(1).NovoStanje > 0)
                izračunNam2 = (data4.ElementAt(0).NovoStanje - data4.ElementAt(1).NovoStanje) / 2.4m;
            else
                izračunNam2 = data4.ElementAt(0).NovoStanje / 2.4m;
            nam2.Add(izračunNam2/štDni2);
            
            foreach (var x1 in data1)
            {
                DateTime d1 = x1.DatumVnosa;
                DateTime d2 = DateTime.Now;
                decimal skupaj = BranjeXML.BranjePadavin(d1, d2);
                padavine.Add(skupaj);
            }
            //predpostavimo, da bi število dni isto
            int k = 0;
            foreach (var x in data)
            {
                VsiPodatki y = new VsiPodatki();
                y.Cas = x.Cas;
                y.IdGrede = x.IdGrede;
                y.Id = x.Id;
                y.Temp1 = x.Temp1;
                y.Temp2 = x.Temp2;
                y.Temp3 = x.Temp3;
                y.Vlaga = x.Vlaga;
                if (k==0)
                y.KoličinaPadavin = padavine.ElementAt(k)/štDni0;
                if (k == 1)
                    y.KoličinaPadavin = padavine.ElementAt(k) / štDni1;
                if (k == 2)
                    y.KoličinaPadavin = padavine.ElementAt(k) / štDni2;
                y.DatumVnosa = data5.ElementAt(k).DatumVnosa;
                y.ZalivanjeNam2 = nam2.ElementAt(k);
                y.SkupajVoda = y.ZalivanjeNam2 + y.KoličinaPadavin;
                dataVsi.Add(y);
                k++;
            }
            
            return View(dataVsi);
        }
        //public ActionResult _indexPostaje()
        //{
        //    var data = from element in ge.PodatkiSenzorjev
        //               group element by element.IdGrede
        //               into groups
        //               orderby groups.Key
        //               select groups.OrderByDescending(p => p.Id).FirstOrDefault();
        //    return View("_postaje", data);
        //}
        
    }
}
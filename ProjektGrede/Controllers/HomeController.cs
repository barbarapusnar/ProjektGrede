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
                if (zadnjiDatum.Length == 21)
                {
                    int dan = int.Parse(zadnjiDatum.Substring(0, 2));
                    int mesec = int.Parse(zadnjiDatum.Substring(3, 2));
                    int leto = int.Parse(zadnjiDatum.Substring(6, 4));
                    int ura = int.Parse(zadnjiDatum.Substring(11, 2));
                    int minuta = int.Parse(zadnjiDatum.Substring(14, 2));
                    DateTime datum = new DateTime(leto, mesec, dan, ura, minuta, 0);
                    ViewData["datum"] = datum;
                    if (datum.Hour > 20 | datum.Hour < 5)
                        ViewData["delDan"] = "night";
                    else
                        ViewData["deldan"] = "day";
                }
                else
                {
                    //int dan = int.Parse(zadnjiDatum.Substring(0, 2));
                    //int mesec = int.Parse(zadnjiDatum.Substring(3, 2));
                    //int leto = int.Parse(zadnjiDatum.Substring(6, 4));
                    //int ura = int.Parse(zadnjiDatum.Substring(11, 1));
                    //int minuta = int.Parse(zadnjiDatum.Substring(13, 2));
                    //DateTime datum = new DateTime(leto, mesec, dan, ura, minuta, 0);
                    DateTime datum = DateTime.Parse(zadnjiDatum);
                    ViewData["datum"] = datum;
                    if (datum.Hour > 20 | datum.Hour < 5)
                        ViewData["delDan"] = "night";
                    else
                        ViewData["deldan"] = "day";
                }
            }
            ViewData["temp"] = podatki.Temp2/10;          
            ViewData["vlaga"] = podatki.Humidity2/10;
            ViewData["padavine"] = podatki.Precipitation;
            ViewData["omocenost"] = podatki.Leafwetness2;
            var data = from element in ge.PodatkiSenzorjev
                       group element by element.IdGrede
                       into groups
                       orderby groups.Key
                       select groups.OrderByDescending(p => p.Id).FirstOrDefault();
            return View(data);
        }
        public ActionResult _indexPostaje()
        {
            var data = from element in ge.PodatkiSenzorjev
                       group element by element.IdGrede
                       into groups
                       orderby groups.Key
                       select groups.OrderByDescending(p => p.Id).FirstOrDefault();
            return View("_postaje", data);
        }
        
    }
}
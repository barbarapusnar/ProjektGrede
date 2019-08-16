using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektGrede.Models;

namespace ProjektGrede.Controllers
{
    public class VodaVlagaController : Controller
    {
        private GredeEntities db = new GredeEntities();
        private object koo;

        // GET: VodaVlaga
        public ActionResult Index(int ?id)
        {
            int stevilka = id ?? 1;

            //var data = from x in db.PodatkiSenzorjev
            //            where x.IdGrede == stevilka
            //            orderby x.Id descending
            //            select x;
            //podatki za eno uro prvih 15 minut od ure
            //var dataDan = (from x1 in db.VodaVlaga
            //              // where x1.IDGrede == stevilka                          
            //               orderby x1.Datum 
            //               select new OdvisnostiViewModel {IdGrede=(int)x1.IDGrede,koo=new Koordinate {x = (decimal)x1.Padavine, y = (decimal)x1.Vlaga } });
            var dataDan1 = (from x1 in db.VodaVlaga
                                // where x1.IDGrede == stevilka                          
                            orderby x1.Datum
                            select new OdvisnostiBubble { IdGrede = (int)x1.IDGrede, koo = new KoordinateBubble { x = (DateTime)x1.Datum, y = (decimal)x1.Vlaga, r = (decimal)x1.Padavine } });
            List<OdvisnostiBubble1> prirejeni = new List<OdvisnostiBubble1>();
            foreach (var x1 in dataDan1)
            {
                OdvisnostiBubble1 nov = new OdvisnostiBubble1();
                nov.IdGrede = x1.IdGrede;
                nov.koo = new KoordinateBubble1();
                nov.koo.y = x1.koo.y;
                nov.koo.r = x1.koo.r * 2;
                nov.koo.x = x1.koo.x.DayOfYear - DateTime.Parse("31.8.2018").DayOfYear;
                prirejeni.Add(nov);
            }
            ViewData["id"] = stevilka;
           // return View(dataDan);
            return View(prirejeni);
        }

        // GET: VodaVlaga/Details/5
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

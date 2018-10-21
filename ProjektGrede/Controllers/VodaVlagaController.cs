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

            var data = from x in db.PodatkiSenzorjev
                        where x.IdGrede == stevilka
                        orderby x.Id descending
                        select x;
            //podatki za eno uro prvih 15 minut od ure
            var dataDan = (from x1 in db.VodaVlaga
                          // where x1.IDGrede == stevilka                          
                           orderby x1.Datum 
                           select new OdvisnostiViewModel {IdGrede=(int)x1.IDGrede,koo=new Koordinate {x = (decimal)x1.Padavine, y = (decimal)x1.Vlaga } });
            ViewData["id"] = stevilka;
            return View(dataDan);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGrede.Models;
using X.PagedList;
using System.Data.Entity;

namespace ProjektGrede.Controllers
{
    public class PodatkiController : Controller
    {
        // GET: Podatki
        private GredeEntities db = new GredeEntities();

        // GET: Podatki
        public ActionResult Index(int? page)
        {
            var dataTable = (from x in db.PodatkiSenzorjev
                             orderby x.Id descending
                             select x).Take(12000);

            var dataGraph = (from x in dataTable
                             orderby x.Id descending
                             select x).Take(108);
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfData = dataTable.ToPagedList(pageNumber, 60); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfData = onePageOfData;

            var tpovp = from t in dataGraph
                        group t by new
                        {
                            t.Cas
                        } into g
                        select new
                        {
                            PovpTemp = g.Average(p => p.Temp2),
                            g.Key.Cas
                        };

            var vlpovp = from t in dataGraph
                         group t by new
                         {
                             t.Cas
                         } into g
                         select new
                         {
                             PovpVlg = g.Average(p => p.Vlaga),
                             g.Key.Cas
                         };

            ViewData["TempAvg"] = tpovp;
            ViewData["VlagaAvg"] = vlpovp;
           
            return View(dataTable);
        }

        public ActionResult Postaja(int? id)
        {
            int stevilka = id ?? 1;

            var data = (from x in db.PodatkiSenzorjev
                        where x.IdGrede == stevilka
                        orderby x.Id descending
                        select x).Take(100);
            //podatki za eno uro prvih 15 minut od ure
            var dataDan = (from x in db.PodatkiSenzorjev
                           where x.IdGrede == stevilka
                           where x.Cas.Minute<15
                           orderby x.Id descending
                           select new { x.Cas, x.Temp1, x.Temp2,x.Temp3,x.Vlaga }).Take(25);
            dataDan = dataDan.OrderBy(x => x.Cas);
            //za vsak teden povprečne temperature na dan
          
            var dataTeden = (from x in db.PodatkiSenzorjev
                             where x.IdGrede == stevilka
                             orderby x.Id descending
                             group x by DbFunctions.TruncateTime(x.Cas) into g
                             select new
                             {
                                 datum = g.Key,
                                 temp1Avg = g.Average(z => z.Temp1),
                                 temp2Avg = g.Average(z => z.Temp2),
                                 temp3Avg = g.Average(z => z.Temp3),
                                 vlagaAVG = g.Average(z => z.Vlaga)
                             });
            dataTeden = (from x in dataTeden
                         orderby x.datum descending
                         select x).Take(7);
            dataTeden = dataTeden.OrderBy(a => a.datum);
            var dataMesec = (from x in db.PodatkiSenzorjev
                             where x.IdGrede == stevilka
                             orderby x.Id descending
                             group x by DbFunctions.TruncateTime(x.Cas) into g
                             select new
                             {
                                 datum = g.Key,
                                 temp1Avg = g.Average(z => z.Temp1),
                                 temp2Avg = g.Average(z => z.Temp2),
                                 temp3Avg = g.Average(z => z.Temp3),
                                 vlagaAVG = g.Average(z => z.Vlaga)
                             });
            dataMesec = (from x in dataMesec
                         orderby x.datum descending
                         select x).Take(30);
            dataMesec = dataMesec.OrderBy(a => a.datum);
            ViewData["Dan"] = dataDan;
            ViewData["Teden"] = dataTeden;
            ViewData["Mesec"] = dataMesec;
            ViewData["id"] = stevilka;

            return View(data);
        }

        public ActionResult PostajaLive(int? id)
        {
            int stevilka = id ?? 1;

            var data = (from x in db.PodatkiSenzorjev
                        where x.IdGrede == stevilka
                        orderby x.Id descending
                        select x).Take(10);

            var model = from x in data
                        orderby x.Id
                        select x;

            ViewData["id"] = stevilka;

            return View(model);
        }

        public ActionResult _PostajaLive(int? id)
        {
            int stevilka = id ?? 1;

            var data = (from x in db.PodatkiSenzorjev
                        where x.IdGrede == stevilka
                        orderby x.Id descending
                        select x).Take(10);

            var model = from x in data
                        orderby x.Id
                        select x;

            return View("_podatki", model);
        }

    }
}
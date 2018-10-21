using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektGrede;
using ProjektGrede.Models;

namespace ProjektGrede.Controllers
{
    public class PodatkiVnosController : Controller
    {
        private GredeEntities db = new GredeEntities();
        private List<PodatkiVnos> stariPodatek=new List<PodatkiVnos>();
       //[Authorize]
        // GET: PodatkiVnos
        public ActionResult Index()
        {
            
            
            var data = from element in db.PodatkiVnos
                       group element by element.IDGrede
                         into groups
                       orderby groups.Key
                       select groups.OrderByDescending(p => p.DatumVnosa).FirstOrDefault();
            IEnumerable<PodatkiVnos> d = data.AsEnumerable<PodatkiVnos>();
            DateTime d1=d.ElementAt(1).DatumVnosa;
            DateTime d2 = DateTime.Now;
            decimal arsoPadavine=BranjeXML.BranjePadavin(d1, d2);
           
            ViewBag.ZadnjiDatum = d1;
            ViewBag.ArsoPadavine = arsoPadavine;
            return View(data);
          
        }
      
        //[Authorize]
        // GET: PodatkiVnos/Create
        public ActionResult Create()
        {
            return View();
        }
       // [Authorize]
        // POST: PodatkiVnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IDGrede,NovoStanje,DatumVnosa")] PodatkiVnos podatkiVnos)
        {
            
            if (ModelState.IsValid)
            {
                // podatkiVnos.IDGrede = 1;
                podatkiVnos.DatumVnosa = DateTime.Now;
                var data = from element in db.PodatkiVnos
                           group element by element.IDGrede
                         into groups
                           orderby groups.Key
                           select groups.OrderByDescending(p => p.DatumVnosa).FirstOrDefault();
                stariPodatek = data.ToList();
                var x = (from a in stariPodatek
                         where a.IDGrede == podatkiVnos.IDGrede
                         select a).FirstOrDefault();
                podatkiVnos.DatumPredZalivanje = x.DatumVnosa;
                if (podatkiVnos.NovoStanje>x.NovoStanje)
                   podatkiVnos.Razlika = podatkiVnos.NovoStanje - x.NovoStanje;
                else
                    podatkiVnos.Razlika = podatkiVnos.NovoStanje;
                db.PodatkiVnos.Add(podatkiVnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(podatkiVnos);
        }
      

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

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
        [Authorize]
        // GET: PodatkiVnos
        public ActionResult Index()
        {
            var data = from element in db.PodatkiVnos
                       group element by element.IDGrede
                         into groups
                       orderby groups.Key
                       select groups.OrderByDescending(p => p.Id).FirstOrDefault();
            return View(data);
          
        }
      
        [Authorize]
        // GET: PodatkiVnos/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
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

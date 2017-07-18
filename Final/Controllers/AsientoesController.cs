using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final.Models;

namespace Final.Controllers
{
    public class AsientoesController : Controller
    {
        private CineDBEntities db = new CineDBEntities();

        // GET: Asientoes
        public ActionResult Index()
        {
            var asiento = db.Asiento.Include(a => a.Sala);
            return View(asiento.ToList());
        }

        // GET: Asientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asiento.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            return View(asiento);
        }

        // GET: Asientoes/Create
        public ActionResult Create()
        {
            ViewBag.CodSala = new SelectList(db.Sala, "CodSala", "NombreSala");
            return View();
        }

        // POST: Asientoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodAsiento,DescripcionAsiento,CodSala,TipoAsiento,Disponible")] Asiento asiento)
        {
            if (ModelState.IsValid)
            {
                db.Asiento.Add(asiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodSala = new SelectList(db.Sala, "CodSala", "NombreSala", asiento.CodSala);
            return View(asiento);
        }

        // GET: Asientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asiento.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodSala = new SelectList(db.Sala, "CodSala", "NombreSala", asiento.CodSala);
            return View(asiento);
        }

        // POST: Asientoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodAsiento,DescripcionAsiento,CodSala,TipoAsiento,Disponible")] Asiento asiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodSala = new SelectList(db.Sala, "CodSala", "NombreSala", asiento.CodSala);
            return View(asiento);
        }

        // GET: Asientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asiento.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            return View(asiento);
        }

        // POST: Asientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asiento asiento = db.Asiento.Find(id);
            db.Asiento.Remove(asiento);
            db.SaveChanges();
            return RedirectToAction("Index");
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

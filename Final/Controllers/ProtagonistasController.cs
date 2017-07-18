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
    public class ProtagonistasController : Controller
    {
        private CineDBEntities db = new CineDBEntities();

        // GET: Protagonistas
        public ActionResult Index()
        {
            var protagonista = db.Protagonista.Include(p => p.Interprete).Include(p => p.Pelicula);
            return View(protagonista.ToList());
        }

        // GET: Protagonistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protagonista protagonista = db.Protagonista.Find(id);
            if (protagonista == null)
            {
                return HttpNotFound();
            }
            return View(protagonista);
        }

        // GET: Protagonistas/Create
        public ActionResult Create()
        {
            ViewBag.CodInterprete = new SelectList(db.Interprete, "CodInterprete", "Paterno");
            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula");
            return View();
        }

        // POST: Protagonistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodInterprete,CodPelicula,NombreProtagonista,EsPrincipal")] Protagonista protagonista)
        {
            if (ModelState.IsValid)
            {
                db.Protagonista.Add(protagonista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodInterprete = new SelectList(db.Interprete, "CodInterprete", "Paterno", protagonista.CodInterprete);
            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula", protagonista.CodPelicula);
            return View(protagonista);
        }

        // GET: Protagonistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protagonista protagonista = db.Protagonista.Find(id);
            if (protagonista == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodInterprete = new SelectList(db.Interprete, "CodInterprete", "Paterno", protagonista.CodInterprete);
            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula", protagonista.CodPelicula);
            return View(protagonista);
        }

        // POST: Protagonistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodInterprete,CodPelicula,NombreProtagonista,EsPrincipal")] Protagonista protagonista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(protagonista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodInterprete = new SelectList(db.Interprete, "CodInterprete", "Paterno", protagonista.CodInterprete);
            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula", protagonista.CodPelicula);
            return View(protagonista);
        }

        // GET: Protagonistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protagonista protagonista = db.Protagonista.Find(id);
            if (protagonista == null)
            {
                return HttpNotFound();
            }
            return View(protagonista);
        }

        // POST: Protagonistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Protagonista protagonista = db.Protagonista.Find(id);
            db.Protagonista.Remove(protagonista);
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

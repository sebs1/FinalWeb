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
    public class CinePeliculasController : Controller
    {
        private CineDBEntities db = new CineDBEntities();

        // GET: CinePeliculas
        public ActionResult Index()
        {
            var cinePelicula = db.CinePelicula.Include(c => c.Cine).Include(c => c.Pelicula);
            return View(cinePelicula.ToList());
        }

        // GET: CinePeliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinePelicula cinePelicula = db.CinePelicula.Find(id);
            if (cinePelicula == null)
            {
                return HttpNotFound();
            }
            return View(cinePelicula);
        }

        // GET: CinePeliculas/Create
        public ActionResult Create()
        {
            ViewBag.CodCine = new SelectList(db.Cine, "CodCine", "NombreCine");
            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula");
            return View();
        }

        // POST: CinePeliculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCine,CodPelicula,EnCartelera")] CinePelicula cinePelicula)
        {
            if (ModelState.IsValid)
            {
                db.CinePelicula.Add(cinePelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodCine = new SelectList(db.Cine, "CodCine", "NombreCine", cinePelicula.CodCine);
            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula", cinePelicula.CodPelicula);
            return View(cinePelicula);
        }

        // GET: CinePeliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinePelicula cinePelicula = db.CinePelicula.Find(id);
            if (cinePelicula == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodCine = new SelectList(db.Cine, "CodCine", "NombreCine", cinePelicula.CodCine);
            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula", cinePelicula.CodPelicula);
            return View(cinePelicula);
        }

        // POST: CinePeliculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCine,CodPelicula,EnCartelera")] CinePelicula cinePelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinePelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodCine = new SelectList(db.Cine, "CodCine", "NombreCine", cinePelicula.CodCine);
            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula", cinePelicula.CodPelicula);
            return View(cinePelicula);
        }

        // GET: CinePeliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinePelicula cinePelicula = db.CinePelicula.Find(id);
            if (cinePelicula == null)
            {
                return HttpNotFound();
            }
            return View(cinePelicula);
        }

        // POST: CinePeliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CinePelicula cinePelicula = db.CinePelicula.Find(id);
            db.CinePelicula.Remove(cinePelicula);
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

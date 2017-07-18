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
    public class FuncionsController : Controller
    {
        private CineDBEntities db = new CineDBEntities();

        // GET: Funcions
        public ActionResult Index()
        {
            var funcion = db.Funcion.Include(f => f.Pelicula);
            return View(funcion.ToList());
        }

        // GET: Funcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcion funcion = db.Funcion.Find(id);
            if (funcion == null)
            {
                return HttpNotFound();
            }
            return View(funcion);
        }

        // GET: Funcions/Create
        public ActionResult Create()
        {
            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula");
            return View();
        }

        // POST: Funcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodFuncion,HoraInicio,HoraFin,CodPelicula,FechaFuncion,Precio")] Funcion funcion)
        {
            if (ModelState.IsValid)
            {
                db.Funcion.Add(funcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula", funcion.CodPelicula);
            return View(funcion);
        }

        // GET: Funcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcion funcion = db.Funcion.Find(id);
            if (funcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula", funcion.CodPelicula);
            return View(funcion);
        }

        // POST: Funcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodFuncion,HoraInicio,HoraFin,CodPelicula,FechaFuncion,Precio")] Funcion funcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodPelicula = new SelectList(db.Pelicula, "CodPelicula", "NombrePelicula", funcion.CodPelicula);
            return View(funcion);
        }

        // GET: Funcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcion funcion = db.Funcion.Find(id);
            if (funcion == null)
            {
                return HttpNotFound();
            }
            return View(funcion);
        }

        // POST: Funcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcion funcion = db.Funcion.Find(id);
            db.Funcion.Remove(funcion);
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

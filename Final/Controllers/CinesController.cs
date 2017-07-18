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
    public class CinesController : Controller
    {
        private CineDBEntities db = new CineDBEntities();

        // GET: Cines
        public ActionResult Index()
        {
            return View(db.Cine.ToList());
        }

        // GET: Cines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cine.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            return View(cine);
        }

        // GET: Cines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCine,NombreCine,Direccion")] Cine cine)
        {
            if (ModelState.IsValid)
            {
                db.Cine.Add(cine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cine);
        }

        // GET: Cines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cine.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            return View(cine);
        }

        // POST: Cines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCine,NombreCine,Direccion")] Cine cine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cine);
        }

        // GET: Cines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cine.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            return View(cine);
        }

        // POST: Cines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cine cine = db.Cine.Find(id);
            db.Cine.Remove(cine);
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

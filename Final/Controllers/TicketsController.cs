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
    public class TicketsController : Controller
    {
        private CineDBEntities db = new CineDBEntities();

        // GET: Tickets
        public ActionResult Index()
        {
            var ticket = db.Ticket.Include(t => t.Asiento).Include(t => t.Funcion).Include(t => t.Persona);
            return View(ticket.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.CodAsiento = new SelectList(db.Asiento, "CodAsiento", "DescripcionAsiento");
            ViewBag.CodFuncion = new SelectList(db.Funcion, "CodFuncion", "CodFuncion");
            ViewBag.CodPersona = new SelectList(db.Persona, "CodPersona", "Paterno");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodTicket,Descripcion,CodAsiento,CodPersona,CodFuncion")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Ticket.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodAsiento = new SelectList(db.Asiento, "CodAsiento", "DescripcionAsiento", ticket.CodAsiento);
            ViewBag.CodFuncion = new SelectList(db.Funcion, "CodFuncion", "CodFuncion", ticket.CodFuncion);
            ViewBag.CodPersona = new SelectList(db.Persona, "CodPersona", "Paterno", ticket.CodPersona);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodAsiento = new SelectList(db.Asiento, "CodAsiento", "DescripcionAsiento", ticket.CodAsiento);
            ViewBag.CodFuncion = new SelectList(db.Funcion, "CodFuncion", "CodFuncion", ticket.CodFuncion);
            ViewBag.CodPersona = new SelectList(db.Persona, "CodPersona", "Paterno", ticket.CodPersona);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodTicket,Descripcion,CodAsiento,CodPersona,CodFuncion")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodAsiento = new SelectList(db.Asiento, "CodAsiento", "DescripcionAsiento", ticket.CodAsiento);
            ViewBag.CodFuncion = new SelectList(db.Funcion, "CodFuncion", "CodFuncion", ticket.CodFuncion);
            ViewBag.CodPersona = new SelectList(db.Persona, "CodPersona", "Paterno", ticket.CodPersona);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Ticket.Find(id);
            db.Ticket.Remove(ticket);
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

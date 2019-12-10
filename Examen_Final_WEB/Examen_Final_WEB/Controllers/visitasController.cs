using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen_Final_WEB.Models;

namespace Examen_Final_WEB.Controllers
{
    public class visitasController : Controller
    {
        private examenfinalEntities db = new examenfinalEntities();

        // GET: visitas
        public ActionResult Index()
        {
            var visitas = db.visitas.Include(v => v.contacto);
            return View(visitas.ToList());
        }

        // GET: visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: visitas/Create
        public ActionResult Create()
        {
            ViewBag.contactoRecibio = new SelectList(db.contactos, "Id", "nombre");
            return View();
        }

        // POST: visitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,motivoVisita,fechaVisita,horaEntrada,horaSalida,nombreCompleto,contactoRecibio")] visita visita)
        {
            if (ModelState.IsValid)
            {
                db.visitas.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactoRecibio = new SelectList(db.contactos, "Id", "nombre", visita.contactoRecibio);
            return View(visita);
        }

        // GET: visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactoRecibio = new SelectList(db.contactos, "Id", "nombre", visita.contactoRecibio);
            return View(visita);
        }

        // POST: visitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,motivoVisita,fechaVisita,horaEntrada,horaSalida,nombreCompleto,contactoRecibio")] visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactoRecibio = new SelectList(db.contactos, "Id", "nombre", visita.contactoRecibio);
            return View(visita);
        }

        // GET: visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            visita visita = db.visitas.Find(id);
            db.visitas.Remove(visita);
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

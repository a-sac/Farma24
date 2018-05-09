using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Farma24.Models;

namespace Farma24.Controllers
{
    public class MoradasController : Controller
    {
        private Farma24DBEntities db = new Farma24DBEntities();

        // GET: Moradas
        public ActionResult Index()
        {
            var moradas = db.Moradas.Include(m => m.Utilizador);
            return View(moradas.ToList());
        }

        // GET: Moradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morada morada = db.Moradas.Find(id);
            if (morada == null)
            {
                return HttpNotFound();
            }
            return View(morada);
        }

        // GET: Moradas/Create
        public ActionResult Create()
        {
            ViewBag.Utilizador_email = new SelectList(db.Utilizadors, "email", "password");
            return View();
        }

        // POST: Moradas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cidade,codPostal,rua,porta,Utilizador_email")] Morada morada)
        {
            if (ModelState.IsValid)
            {
                db.Moradas.Add(morada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Utilizador_email = new SelectList(db.Utilizadors, "email", "password", morada.Utilizador_email);
            return View(morada);
        }

        // GET: Moradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morada morada = db.Moradas.Find(id);
            if (morada == null)
            {
                return HttpNotFound();
            }
            ViewBag.Utilizador_email = new SelectList(db.Utilizadors, "email", "password", morada.Utilizador_email);
            return View(morada);
        }

        // POST: Moradas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cidade,codPostal,rua,porta,Utilizador_email")] Morada morada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(morada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Utilizador_email = new SelectList(db.Utilizadors, "email", "password", morada.Utilizador_email);
            return View(morada);
        }

        // GET: Moradas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morada morada = db.Moradas.Find(id);
            if (morada == null)
            {
                return HttpNotFound();
            }
            return View(morada);
        }

        // POST: Moradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Morada morada = db.Moradas.Find(id);
            db.Moradas.Remove(morada);
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

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
    public class FaturasController : Controller
    {
        private Farma24DBEntities db = new Farma24DBEntities();

        // GET: Faturas
        public ActionResult Index()
        {
            return View(db.Faturas.ToList());
        }

        // GET: Faturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Faturas.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return View(fatura);
        }

        // GET: Faturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "referencia,metodoPagamento")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                db.Faturas.Add(fatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fatura);
        }

        // GET: Faturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Faturas.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return View(fatura);
        }

        // POST: Faturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "referencia,metodoPagamento")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fatura);
        }

        // GET: Faturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Faturas.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return View(fatura);
        }

        // POST: Faturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fatura fatura = db.Faturas.Find(id);
            db.Faturas.Remove(fatura);
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

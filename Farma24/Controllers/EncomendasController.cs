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
    public class EncomendasController : Controller
    {
        private Farma24DBEntities db = new Farma24DBEntities();

        // GET: Encomendas
        public ActionResult Index()
        {
            var encomendas = db.Encomendas.Include(e => e.Fatura).Include(e => e.Morada1).Include(e => e.Utilizador);
            return View(encomendas.ToList());
        }

        // GET: Encomendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        // GET: Encomendas/Create
        public ActionResult Create()
        {
            ViewBag.Fatura_referencia = new SelectList(db.Faturas, "referencia", "metodoPagamento");
            ViewBag.morada = new SelectList(db.Moradas, "id", "cidade");
            ViewBag.email = new SelectList(db.Utilizadors, "email", "password");
            return View();
        }

        // POST: Encomendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,estado,email,morada,inicio,fim,custoTotal,detalhes,Fatura_referencia")] Encomenda encomenda)
        {
            if (ModelState.IsValid)
            {
                db.Encomendas.Add(encomenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fatura_referencia = new SelectList(db.Faturas, "referencia", "metodoPagamento", encomenda.Fatura_referencia);
            ViewBag.morada = new SelectList(db.Moradas, "id", "cidade", encomenda.morada);
            ViewBag.email = new SelectList(db.Utilizadors, "email", "password", encomenda.email);
            return View(encomenda);
        }

        // GET: Encomendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fatura_referencia = new SelectList(db.Faturas, "referencia", "metodoPagamento", encomenda.Fatura_referencia);
            ViewBag.morada = new SelectList(db.Moradas, "id", "cidade", encomenda.morada);
            ViewBag.email = new SelectList(db.Utilizadors, "email", "password", encomenda.email);
            return View(encomenda);
        }

        // POST: Encomendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,estado,email,morada,inicio,fim,custoTotal,detalhes,Fatura_referencia")] Encomenda encomenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encomenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fatura_referencia = new SelectList(db.Faturas, "referencia", "metodoPagamento", encomenda.Fatura_referencia);
            ViewBag.morada = new SelectList(db.Moradas, "id", "cidade", encomenda.morada);
            ViewBag.email = new SelectList(db.Utilizadors, "email", "password", encomenda.email);
            return View(encomenda);
        }

        // GET: Encomendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        // POST: Encomendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encomenda encomenda = db.Encomendas.Find(id);
            db.Encomendas.Remove(encomenda);
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

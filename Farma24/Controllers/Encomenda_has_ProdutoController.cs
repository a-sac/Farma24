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
    public class Encomenda_has_ProdutoController : Controller
    {
        private Farma24DBEntities db = new Farma24DBEntities();

        // GET: Encomenda_has_Produto
        public ActionResult Index()
        {
            var encomenda_has_Produto = db.Encomenda_has_Produto.Include(e => e.Encomenda1).Include(e => e.Produto1);
            return View(encomenda_has_Produto.ToList());
        }

        // GET: Encomenda_has_Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda_has_Produto encomenda_has_Produto = db.Encomenda_has_Produto.Find(id);
            if (encomenda_has_Produto == null)
            {
                return HttpNotFound();
            }
            return View(encomenda_has_Produto);
        }

        // GET: Encomenda_has_Produto/Create
        public ActionResult Create()
        {
            ViewBag.Encomenda = new SelectList(db.Encomendas, "id", "estado");
            ViewBag.Produto = new SelectList(db.Produtoes, "codBarras", "nome");
            return View();
        }

        // POST: Encomenda_has_Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Encomenda,Produto,quantidade,custo")] Encomenda_has_Produto encomenda_has_Produto)
        {
            if (ModelState.IsValid)
            {
                db.Encomenda_has_Produto.Add(encomenda_has_Produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Encomenda = new SelectList(db.Encomendas, "id", "estado", encomenda_has_Produto.Encomenda);
            ViewBag.Produto = new SelectList(db.Produtoes, "codBarras", "nome", encomenda_has_Produto.Produto);
            return View(encomenda_has_Produto);
        }

        // GET: Encomenda_has_Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda_has_Produto encomenda_has_Produto = db.Encomenda_has_Produto.Find(id);
            if (encomenda_has_Produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Encomenda = new SelectList(db.Encomendas, "id", "estado", encomenda_has_Produto.Encomenda);
            ViewBag.Produto = new SelectList(db.Produtoes, "codBarras", "nome", encomenda_has_Produto.Produto);
            return View(encomenda_has_Produto);
        }

        // POST: Encomenda_has_Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Encomenda,Produto,quantidade,custo")] Encomenda_has_Produto encomenda_has_Produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encomenda_has_Produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Encomenda = new SelectList(db.Encomendas, "id", "estado", encomenda_has_Produto.Encomenda);
            ViewBag.Produto = new SelectList(db.Produtoes, "codBarras", "nome", encomenda_has_Produto.Produto);
            return View(encomenda_has_Produto);
        }

        // GET: Encomenda_has_Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda_has_Produto encomenda_has_Produto = db.Encomenda_has_Produto.Find(id);
            if (encomenda_has_Produto == null)
            {
                return HttpNotFound();
            }
            return View(encomenda_has_Produto);
        }

        // POST: Encomenda_has_Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encomenda_has_Produto encomenda_has_Produto = db.Encomenda_has_Produto.Find(id);
            db.Encomenda_has_Produto.Remove(encomenda_has_Produto);
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

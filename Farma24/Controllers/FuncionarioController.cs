using Farma24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farma24.Controllers
{
    public class FuncionarioController : Controller
    {
        private Farma24DBEntities db = new Farma24DBEntities();

        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int? id)
        {
            var encomendas = db.Encomendas.Where(x => x.estado.Equals("Waiting"));
            if (encomendas.Any())
            {
                var encomenda = encomendas.First();
                Funcionario f = new Funcionario(encomenda);
                return View(f);
            }

            return RedirectToAction("Create", "Funcionario");
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
           
            return View();

        }

        // POST: Funcionario/Create
        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {
            return RedirectToAction("Details","Funcionario");
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Funcionario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Update(int id)
        {
            var encomendas = db.Encomendas.Where(x => x.id == id);
            var encomenda = encomendas.First();
            encomenda.estado = "Done";
            db.SaveChanges();
            return RedirectToAction("Index", "Produtoes");
        }
    }
}

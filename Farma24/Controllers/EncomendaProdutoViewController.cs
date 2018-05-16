using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Farma24.Models;

namespace Farma24.Controllers
{
    public class EncomendaProdutoViewController : Controller
    {
        private Farma24DBEntities db = new Farma24DBEntities();
        // GET: EncomendaProduto
        public ActionResult Create(int? id)
        {
            EncomendaProdutoView EncomendaProdutoView = new EncomendaProdutoView()
            {
                encomenda = getStandBy(),
                encomendaHasProduto =  new Encomenda_has_Produto(),
                produto = db.Produtoes.Find(id)
                   
            };
            return View(EncomendaProdutoView);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "encomenda,encomendaHasProduto,produto")] EncomendaProdutoView encomendaProduto, int? id)
        {
            if(encomendaProduto != null)
            {

                encomendaProduto.encomenda = getStandBy();
                encomendaProduto.produto = db.Produtoes.Find(id);
                var EncomendaId = encomendaProduto.encomenda.id;
                var ProdCodBarras = encomendaProduto.produto.codBarras;
                var encomendasHasProduto = db.Encomenda_has_Produto.Where(x =>
                    x.Encomenda.Equals(EncomendaId) && x.Produto.Equals(ProdCodBarras));
                if (!encomendasHasProduto.Any() )
                {
                    encomendaProduto.encomendaHasProduto.Encomenda = encomendaProduto.encomenda.id;
                    encomendaProduto.encomendaHasProduto.Produto = encomendaProduto.produto.codBarras;
                    encomendaProduto.encomendaHasProduto.custo =
                        encomendaProduto.produto.preco * encomendaProduto.encomendaHasProduto.quantidade;
                    //encomendaProduto.encomenda.Encomenda_has_Produto.Add(encomendaProduto.encomendaHasProduto);
                    //encomendaProduto.produto.Encomenda_has_Produto.Add(encomendaProduto.encomendaHasProduto);


                    if (ModelState.IsValid)
                    {
                        db.Encomenda_has_Produto.Add(encomendaProduto.encomendaHasProduto);
                        db.SaveChanges();
                        return RedirectToAction("Index","Produtoes");
                    }
                }
                else
                {
                    encomendasHasProduto.First().quantidade += encomendaProduto.encomendaHasProduto.quantidade;
                    encomendasHasProduto.First().custo += encomendaProduto.encomendaHasProduto.custo;

                    if (ModelState.IsValid)
                    {
                        db.Encomenda_has_Produto.AddOrUpdate(encomendasHasProduto.First());
                        db.SaveChanges();
                        return RedirectToAction("Index","Produtoes");
                    }
                }

            }

                return View(encomendaProduto);
        }
        
        public Encomenda getStandBy()
        {
            var mail= User.Identity.Name;
            var user = db.Utilizadors.Find(mail);
            var encomenda = user.Encomendas.Where(x => x.estado.Equals("StandBy"));
            if (!encomenda.Any() )
            {
                Encomenda e = new Encomenda
                {
                    estado = "StandBy",
                    email = mail,
                    morada = db.Moradas.First(x => x.Utilizador_email == mail).id,
                    inicio = DateTime.Now,
                    custoTotal = 0
                };
                db.Encomendas.Add(e);
                db.SaveChanges();
                return e;
            }

            return encomenda.First();
        }
    }



}
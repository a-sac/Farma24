using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Farma24.Models;

namespace Farma24.Controllers
{
    public class RegisterViewController : Controller
    {
        private Farma24DBEntities db = new Farma24DBEntities();
        // GET: Register
        public ActionResult Index()
        {
            RegisterView RegisterView = new RegisterView()
            {
                Utilizador = new Utilizador(),
                Morada = new Morada()
            };

            return View(RegisterView);
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "Utilizador, Morada")] RegisterView registerView)
        {
            if(registerView != null)
            {
                registerView.Morada.Utilizador_email = registerView.Utilizador.email;
                registerView.Utilizador.SetUser();
                if (ModelState.IsValid)
                {
                    db.Utilizadors.Add(registerView.Utilizador);
                    db.Moradas.Add(registerView.Morada);
                    db.SaveChanges();
                    return RedirectToAction("Index","Produtoes");

                }
                else
                {
                    return View(registerView);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
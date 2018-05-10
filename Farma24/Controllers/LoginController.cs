using System.Web.Mvc;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using Farma24.Helper;
using Farma24.Models;

namespace Farma24.Controllers
{
    public class LoginController : Controller
    {
        private Farma24DBEntities db = new Farma24DBEntities();
        // GET
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            //email = UtilizadorHelper.FromBase64(email);
            if (ModelState.IsValid)
            {
                var utilizadores = (from u in db.Utilizadors
                    where u.email == email && u.password == password
                    select u);
                Utilizador utilizador = utilizadores.ToList().ElementAt<Utilizador>(0);
                            HttpCookie cookie = LoginHelper.CreateAuthorizeTicket(utilizador.email, utilizador.role);
                            Response.Cookies.Add(cookie);
                    }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect");
                return View("Index");
            }

            return RedirectToAction("LoginSucess", "Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Produtoes");
        }

        public ActionResult LoginSucess()
        {
            return RedirectToAction("Index", "Produtoes");
        }
    }
}
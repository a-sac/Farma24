using System;
using System.Web;
using System.Web.Security;

namespace Farma24.Helper
{
    public class LoginHelper
    {
        public static HttpCookie CreateAuthorizeTicket(string email, string roles)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1, // versão
                email,  // email
                DateTime.Now, // data de criação
                DateTime.Now.AddMinutes(30),  // validade
                false,   // se o cookie fica persistente ou não
                roles); //dados do utilizador

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
            return cookie;
        }

    }
}
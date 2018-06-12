using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Farma24.Models;

namespace Farma24
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Farma24DBEntities db = new Farma24DBEntities();
            var admin = db.Utilizadors.Where(u => u.role.Equals("admin"));
            if (!admin.Any())
            {
                var u = Utilizador.SetupAdmin();
                db.Utilizadors.Add(u);
                db.SaveChanges();
            }
            var staff = db.Utilizadors.Where(u => u.role.Equals("staff"));
            if (!staff.Any())
            {
                var s = Utilizador.SetupStaff();
                db.Utilizadors.Add(s);
                db.SaveChanges();
            }
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User == null) return;
            if (!HttpContext.Current.User.Identity.IsAuthenticated) return;
            if (HttpContext.Current.User.Identity is FormsIdentity)
            {
                var id = (FormsIdentity)HttpContext.Current.User.Identity;
                FormsAuthenticationTicket ticket = id.Ticket;
                string userData = ticket.UserData;
                string[] roles = userData.Split(',');
                HttpContext.Current.User = new GenericPrincipal(id, roles);
            }
        }
    }
}

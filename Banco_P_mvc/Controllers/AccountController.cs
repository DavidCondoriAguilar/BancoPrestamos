using Banco_P_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Banco_P_mvc.Controllers
{
    public class AccountController : Controller
    {
        private AplicacionBDContext db = new AplicacionBDContext();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Empleado model, string returnUrl)
        {

            // Find the user in the database
            var empleado = db.Empleados
                .FirstOrDefault(e => e.UsuarioEmpleado == model.UsuarioEmpleado && e.ClaveEmpleado == model.ClaveEmpleado);

            if (empleado != null)
            {
                // Set authentication cookie
                FormsAuthentication.SetAuthCookie(model.UsuarioEmpleado, false);
                // Create session
                Session["Usuario"] = empleado.UsuarioEmpleado;
                Session["EmpleadoId"] = empleado.ClaveEmpleado;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: /Account/Logout
        public ActionResult Logout()
        {
            // Sign out from forms authentication
            FormsAuthentication.SignOut();

            // Destroy the session
            Session.Clear();
            Session.Abandon();

            // Redirect to the login page
            return RedirectToAction("Login", "Account");
        }
    }
}

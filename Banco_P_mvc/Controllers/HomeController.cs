using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionTiendita.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //Verificar la sesión en cada acción
        private void VerificarSesion()
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login");
            }
        }
        public ActionResult Index()
        {
            VerificarSesion();
            return View();
        }


        public ActionResult About()
        {
            VerificarSesion();
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            VerificarSesion();
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
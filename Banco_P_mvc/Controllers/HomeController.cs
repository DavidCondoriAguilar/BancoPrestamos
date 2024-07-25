using Banco_P_mvc.Models;
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

        private AplicacionBDContext _context = new AplicacionBDContext();

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

            var totalClientes = _context.Clientes.Count();
            var totalCuentas = _context.Cuentas.Count();
            var totalEmpleados = _context.Empleados.Count();
            var totalPrestamos = _context.Prestamos.Count();
            var totalSucursales = _context.Sucursales.Count();
            var totalTransferencias = _context.Transferencias.Count();

            // Pasar los datos a la vista
            ViewBag.TotalClientes = totalClientes;
            ViewBag.TotalCuentas = totalCuentas;
            ViewBag.TotalEmpleados = totalEmpleados;
            ViewBag.TotalPrestamos = totalPrestamos;
            ViewBag.TotalSucursales = totalSucursales;
            ViewBag.TotalTransferencias = totalTransferencias;

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
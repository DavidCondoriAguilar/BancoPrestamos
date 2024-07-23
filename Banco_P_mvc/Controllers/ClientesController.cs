using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Banco_P_mvc.Models;

namespace Banco_P_mvc.Controllers
{
    public class ClientesController : Controller
    {
        private AplicacionBDContext db = new AplicacionBDContext();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Empleado);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.Cod_Emp = new SelectList(db.Empleados, "Cod_Emp", "DNI_Emp");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dni_Cli,Nom_Cli,Ape_Pat_Cli,Ape_Mat_Cli,Tel_Cli,Cor_cli,Dir_cli,Dis_cli,Fec_Ing_Cli,Fec_Nac_Cli,Cod_Emp")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                // Verificar si el cliente ya existe
                var existingCliente = db.Clientes.FirstOrDefault(c => c.Dni_Cli == cliente.Dni_Cli);
                if (existingCliente != null)
                {
                    // Agregar un mensaje de error al ModelState si el cliente ya existe
                    ModelState.AddModelError("Dni_Cli", "Ya existe un cliente con este DNI.");
                }
                else
                {
                    // Si el cliente no existe, agregarlo a la base de datos
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            // Si el ModelState no es válido o ya existe un cliente con el mismo DNI, re-renderizar la vista
            ViewBag.Cod_Emp = new SelectList(db.Empleados, "Cod_Emp", "DNI_Emp", cliente.Cod_Emp);
            return View(cliente);
        }


        // GET: Clientes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_Emp = new SelectList(db.Empleados, "Cod_Emp", "DNI_Emp", cliente.Cod_Emp);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dni_Cli,Nom_Cli,Ape_Pat_Cli,Ape_Mat_Cli,Tel_Cli,Cor_cli,Dir_cli,Dis_cli,Fec_Ing_Cli,Fec_Nac_Cli,Cod_Emp")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_Emp = new SelectList(db.Empleados, "Cod_Emp", "DNI_Emp", cliente.Cod_Emp);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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

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
    public class DetalleAperturasController : Controller
    {
        private AplicacionBDContext db = new AplicacionBDContext();

        // GET: DetalleAperturas
        public ActionResult Index()
        {
            var detallesApertura = db.DetallesApertura.Include(d => d.Cliente).Include(d => d.Cuenta);
            return View(detallesApertura.ToList());
        }

        // GET: DetalleAperturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleApertura detalleApertura = db.DetallesApertura.Find(id);
            if (detalleApertura == null)
            {
                return HttpNotFound();
            }
            return View(detalleApertura);
        }

        // GET: DetalleAperturas/Create
        public ActionResult Create()
        {
            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli");
            ViewBag.Num_Cue = new SelectList(db.Cuentas, "Num_Cue", "Ruc_Cli");
            return View();
        }

        // POST: DetalleAperturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Ape,Dni_Cli,Num_Cue,Fec_Ape")] DetalleApertura detalleApertura)
        {
            if (ModelState.IsValid)
            {
                db.DetallesApertura.Add(detalleApertura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli", detalleApertura.Dni_Cli);
            ViewBag.Num_Cue = new SelectList(db.Cuentas, "Num_Cue", "Ruc_Cli", detalleApertura.Num_Cue);
            return View(detalleApertura);
        }

        // GET: DetalleAperturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleApertura detalleApertura = db.DetallesApertura.Find(id);
            if (detalleApertura == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli", detalleApertura.Dni_Cli);
            ViewBag.Num_Cue = new SelectList(db.Cuentas, "Num_Cue", "Ruc_Cli", detalleApertura.Num_Cue);
            return View(detalleApertura);
        }

        // POST: DetalleAperturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Ape,Dni_Cli,Num_Cue,Fec_Ape")] DetalleApertura detalleApertura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleApertura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli", detalleApertura.Dni_Cli);
            ViewBag.Num_Cue = new SelectList(db.Cuentas, "Num_Cue", "Ruc_Cli", detalleApertura.Num_Cue);
            return View(detalleApertura);
        }

        // GET: DetalleAperturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleApertura detalleApertura = db.DetallesApertura.Find(id);
            if (detalleApertura == null)
            {
                return HttpNotFound();
            }
            return View(detalleApertura);
        }

        // POST: DetalleAperturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleApertura detalleApertura = db.DetallesApertura.Find(id);
            db.DetallesApertura.Remove(detalleApertura);
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

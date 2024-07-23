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
    public class TransferenciasController : Controller
    {
        private AplicacionBDContext db = new AplicacionBDContext();

        // GET: Transferencias
        public ActionResult Index()
        {
            var transferencias = db.Transferencias.Include(t => t.Cuenta);
            return View(transferencias.ToList());
        }

        // GET: Transferencias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transferencia transferencia = db.Transferencias.Find(id);
            if (transferencia == null)
            {
                return HttpNotFound();
            }
            return View(transferencia);
        }

        // GET: Transferencias/Create
        public ActionResult Create()
        {
            ViewBag.Num_Cue = new SelectList(db.Cuentas, "Num_Cue", "Ruc_Cli");
            return View();
        }

        // POST: Transferencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Tra,Mon_Tra,Cue_Tra,Fec_Tra,Tra_Int,Num_Cue")] Transferencia transferencia)
        {
            if (ModelState.IsValid)
            {
                db.Transferencias.Add(transferencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Num_Cue = new SelectList(db.Cuentas, "Num_Cue", "Ruc_Cli", transferencia.Num_Cue);
            return View(transferencia);
        }

        // GET: Transferencias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transferencia transferencia = db.Transferencias.Find(id);
            if (transferencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Num_Cue = new SelectList(db.Cuentas, "Num_Cue", "Ruc_Cli", transferencia.Num_Cue);
            return View(transferencia);
        }

        // POST: Transferencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Tra,Mon_Tra,Cue_Tra,Fec_Tra,Tra_Int,Num_Cue")] Transferencia transferencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transferencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Num_Cue = new SelectList(db.Cuentas, "Num_Cue", "Ruc_Cli", transferencia.Num_Cue);
            return View(transferencia);
        }

        // GET: Transferencias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transferencia transferencia = db.Transferencias.Find(id);
            if (transferencia == null)
            {
                return HttpNotFound();
            }
            return View(transferencia);
        }

        // POST: Transferencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Transferencia transferencia = db.Transferencias.Find(id);
            db.Transferencias.Remove(transferencia);
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

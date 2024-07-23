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
    public class DetalleSolicitudsController : Controller
    {
        private AplicacionBDContext db = new AplicacionBDContext();

        // GET: DetalleSolicituds
        public ActionResult Index()
        {
            var detallesSolicitud = db.DetallesSolicitud.Include(d => d.Cliente).Include(d => d.Prestamo);
            return View(detallesSolicitud.ToList());
        }

        // GET: DetalleSolicituds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSolicitud detalleSolicitud = db.DetallesSolicitud.Find(id);
            if (detalleSolicitud == null)
            {
                return HttpNotFound();
            }
            return View(detalleSolicitud);
        }

        // GET: DetalleSolicituds/Create
        public ActionResult Create()
        {
            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli");
            ViewBag.Cod_Pre = new SelectList(db.Prestamos, "Cod_Pre", "Cod_Suc");
            return View();
        }

        // POST: DetalleSolicituds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Solicitud,Dni_Cli,Cod_Pre,Fec_Sol")] DetalleSolicitud detalleSolicitud)
        {
            if (ModelState.IsValid)
            {
                db.DetallesSolicitud.Add(detalleSolicitud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli", detalleSolicitud.Dni_Cli);
            ViewBag.Cod_Pre = new SelectList(db.Prestamos, "Cod_Pre", "Cod_Suc", detalleSolicitud.Cod_Pre);
            return View(detalleSolicitud);
        }

        // GET: DetalleSolicituds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSolicitud detalleSolicitud = db.DetallesSolicitud.Find(id);
            if (detalleSolicitud == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli", detalleSolicitud.Dni_Cli);
            ViewBag.Cod_Pre = new SelectList(db.Prestamos, "Cod_Pre", "Cod_Suc", detalleSolicitud.Cod_Pre);
            return View(detalleSolicitud);
        }

        // POST: DetalleSolicituds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Solicitud,Dni_Cli,Cod_Pre,Fec_Sol")] DetalleSolicitud detalleSolicitud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleSolicitud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli", detalleSolicitud.Dni_Cli);
            ViewBag.Cod_Pre = new SelectList(db.Prestamos, "Cod_Pre", "Cod_Suc", detalleSolicitud.Cod_Pre);
            return View(detalleSolicitud);
        }

        // GET: DetalleSolicituds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSolicitud detalleSolicitud = db.DetallesSolicitud.Find(id);
            if (detalleSolicitud == null)
            {
                return HttpNotFound();
            }
            return View(detalleSolicitud);
        }

        // POST: DetalleSolicituds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleSolicitud detalleSolicitud = db.DetallesSolicitud.Find(id);
            db.DetallesSolicitud.Remove(detalleSolicitud);
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

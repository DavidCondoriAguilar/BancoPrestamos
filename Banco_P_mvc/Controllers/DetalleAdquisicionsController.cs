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
    public class DetalleAdquisicionsController : Controller
    {
        private AplicacionBDContext db = new AplicacionBDContext();

        // GET: DetalleAdquisicions
        public ActionResult Index()
        {
            var detallesAdquisicion = db.DetallesAdquisicion.Include(d => d.Cliente).Include(d => d.Seguro);
            return View(detallesAdquisicion.ToList());
        }

        // GET: DetalleAdquisicions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleAdquisicion detalleAdquisicion = db.DetallesAdquisicion.Find(id);
            if (detalleAdquisicion == null)
            {
                return HttpNotFound();
            }
            return View(detalleAdquisicion);
        }

        // GET: DetalleAdquisicions/Create
        public ActionResult Create()
        {
            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli");
            ViewBag.Cod_Seg = new SelectList(db.Seguros, "Cod_Seg", "Num_Tar");
            return View();
        }

        // POST: DetalleAdquisicions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Det_Adq,Dni_Cli,Cod_Seg,Fec_adq")] DetalleAdquisicion detalleAdquisicion)
        {
            if (ModelState.IsValid)
            {
                db.DetallesAdquisicion.Add(detalleAdquisicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                
            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli", detalleAdquisicion.Dni_Cli);
            ViewBag.Cod_Seg = new SelectList(db.Seguros, "Cod_Seg", "Num_Tar", detalleAdquisicion.Cod_Seg);
            return View(detalleAdquisicion);
        }

        // GET: DetalleAdquisicions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleAdquisicion detalleAdquisicion = db.DetallesAdquisicion.Find(id);
            if (detalleAdquisicion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli", detalleAdquisicion.Dni_Cli);
            ViewBag.Cod_Seg = new SelectList(db.Seguros, "Cod_Seg", "Num_Tar", detalleAdquisicion.Cod_Seg);
            return View(detalleAdquisicion);
        }

        // POST: DetalleAdquisicions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Det_Adq,Dni_Cli,Cod_Seg,Fec_adq")] DetalleAdquisicion detalleAdquisicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleAdquisicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dni_Cli = new SelectList(db.Clientes, "Dni_Cli", "Nom_Cli", detalleAdquisicion.Dni_Cli);
            ViewBag.Cod_Seg = new SelectList(db.Seguros, "Cod_Seg", "Num_Tar", detalleAdquisicion.Cod_Seg);
            return View(detalleAdquisicion);
        }

        // GET: DetalleAdquisicions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleAdquisicion detalleAdquisicion = db.DetallesAdquisicion.Find(id);
            if (detalleAdquisicion == null)
            {
                return HttpNotFound();
            }
            return View(detalleAdquisicion);
        }

        // POST: DetalleAdquisicions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleAdquisicion detalleAdquisicion = db.DetallesAdquisicion.Find(id);
            db.DetallesAdquisicion.Remove(detalleAdquisicion);
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

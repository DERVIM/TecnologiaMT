using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TecnologiaMT.Models;

namespace TecnologiaMT.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR")]
    public class TipoFacturasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: TipoFacturas
        public ActionResult Index()
        {
            return View(db.TipoFacturas.ToList());
        }

        // GET: TipoFacturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFactura tipoFactura = db.TipoFacturas.Find(id);
            if (tipoFactura == null)
            {
                return HttpNotFound();
            }
            return View(tipoFactura);
        }

        // GET: TipoFacturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoFacturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_TipoFac,Nombre")] TipoFactura tipoFactura)
        {
            TipoFactura cat = db.TipoFacturas.Where(x => x.Cod_TipoFac.Trim() == tipoFactura.Cod_TipoFac.Trim())
                 .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.TipoFacturas.Add(tipoFactura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoFactura);
        }

        // GET: TipoFacturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFactura tipoFactura = db.TipoFacturas.Find(id);
            if (tipoFactura == null)
            {
                return HttpNotFound();
            }
            return View(tipoFactura);
        }

        // POST: TipoFacturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_TipoFac,Nombre")] TipoFactura tipoFactura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoFactura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoFactura);
        }

        // GET: TipoFacturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFactura tipoFactura = db.TipoFacturas.Find(id);
            if (tipoFactura == null)
            {
                return HttpNotFound();
            }
            return View(tipoFactura);
        }

        // POST: TipoFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoFactura tipoFactura = db.TipoFacturas.Find(id);
            db.TipoFacturas.Remove(tipoFactura);
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

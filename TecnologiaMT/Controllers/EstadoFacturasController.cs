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
    [Authorize(Roles = "ADMINISTRADOR,VENDEDOR")]
    public class EstadoFacturasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: EstadoFacturas
        public ActionResult Index()
        {
            return View(db.EstadoFacturas.ToList());
        }

        // GET: EstadoFacturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoFactura estadoFactura = db.EstadoFacturas.Find(id);
            if (estadoFactura == null)
            {
                return HttpNotFound();
            }
            return View(estadoFactura);
        }

        // GET: EstadoFacturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoFacturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_EstadoFac,Nombre")] EstadoFactura estadoFactura)
        {
            EstadoFactura cat = db.EstadoFacturas.Where(x => x.Cod_EstadoFac.Trim() == estadoFactura.Cod_EstadoFac.Trim())
          .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.EstadoFacturas.Add(estadoFactura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoFactura);
        }

        // GET: EstadoFacturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoFactura estadoFactura = db.EstadoFacturas.Find(id);
            if (estadoFactura == null)
            {
                return HttpNotFound();
            }
            return View(estadoFactura);
        }

        // POST: EstadoFacturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_EstadoFac,Nombre")] EstadoFactura estadoFactura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoFactura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoFactura);
        }

        // GET: EstadoFacturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoFactura estadoFactura = db.EstadoFacturas.Find(id);
            if (estadoFactura == null)
            {
                return HttpNotFound();
            }
            return View(estadoFactura);
        }

        // POST: EstadoFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoFactura estadoFactura = db.EstadoFacturas.Find(id);
            db.EstadoFacturas.Remove(estadoFactura);
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

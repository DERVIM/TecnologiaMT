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
    [Authorize(Roles = "ADMINISTRADOR,VENDEDOR,COBRADOR")]
    public class ProveedorsController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Proveedors
        public ActionResult Index()
        {
            var proveedores = db.Proveedores.Include(p => p.RazonSocial);
            return View(proveedores.ToList());
        }

        // GET: Proveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedors/Create
        public ActionResult Create()
        {
            ViewBag.RazonSocialId = new SelectList(db.RazonSociales, "Id", "Nombre");
            return View();
        }

        // POST: Proveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Proveedor,Identificacion,Nombres,Apellidos,Telefono,Correo,RazonSocialId")] Proveedor proveedor)
        {
            Proveedor cat = db.Proveedores.Where(x => x.Cod_Proveedor.Trim() == proveedor.Cod_Proveedor.Trim())
                  .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.Proveedores.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RazonSocialId = new SelectList(db.RazonSociales, "Id", "Nombre", proveedor.RazonSocialId);
            return View(proveedor);
        }

        // GET: Proveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.RazonSocialId = new SelectList(db.RazonSociales, "Id", "Nombre", proveedor.RazonSocialId);
            return View(proveedor);
        }

        // POST: Proveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Proveedor,Identificacion,Nombres,Apellidos,Telefono,Correo,RazonSocialId")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RazonSocialId = new SelectList(db.RazonSociales, "Id", "Nombre", proveedor.RazonSocialId);
            return View(proveedor);
        }

        // GET: Proveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            db.Proveedores.Remove(proveedor);
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

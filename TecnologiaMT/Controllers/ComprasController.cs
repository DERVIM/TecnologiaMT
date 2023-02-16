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
    public class ComprasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Compras
        public ActionResult Index()
        {
            var compras = db.Compras.Include(c => c.Empleado).Include(c => c.Proveedor).Include(c => c.Retencion).Include(c => c.TipoPago);
            return View(compras.ToList());
        }
        [HttpPost]
        public ActionResult Index(CompraVM oCompraVM)
        {
            Compra oCompra = oCompraVM.oCompra;

            oCompra.DetalleCompra = oCompraVM.oDetalleCompra;

            db.Compras.Add(oCompra);
            db.SaveChanges();

            return Json(new { respuesta = true });
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Nombres");
            ViewBag.ProveedorId = new SelectList(db.Proveedores, "Id", "Nombres");
            ViewBag.RetencionId = new SelectList(db.Retenciones, "Id", "Nombre");
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Nombre");
            return View();
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Compra,Fecha,Total,EmpleadoId,ProveedorId,RetencionId,TipoPagoId")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compras.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Nombres", compra.EmpleadoId);
            ViewBag.ProveedorId = new SelectList(db.Proveedores, "Id", "Nombres", compra.ProveedorId);
            ViewBag.RetencionId = new SelectList(db.Retenciones, "Id", "Nombre", compra.RetencionId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Nombre", compra.TipoPagoId);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Nombres", compra.EmpleadoId);
            ViewBag.ProveedorId = new SelectList(db.Proveedores, "Id", "Nombres", compra.ProveedorId);
            ViewBag.RetencionId = new SelectList(db.Retenciones, "Id", "Nombre", compra.RetencionId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Nombre", compra.TipoPagoId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Compra,Fecha,Total,EmpleadoId,ProveedorId,RetencionId,TipoPagoId")] Compra compra)
        {
            Compra cat = db.Compras.Where(x => x.Cod_Compra.Trim() == compra.Cod_Compra.Trim())
               .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Nombres", compra.EmpleadoId);
            ViewBag.ProveedorId = new SelectList(db.Proveedores, "Id", "Nombres", compra.ProveedorId);
            ViewBag.RetencionId = new SelectList(db.Retenciones, "Id", "Nombre", compra.RetencionId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Nombre", compra.TipoPagoId);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compras.Find(id);
            db.Compras.Remove(compra);
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

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
    public class ventasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: ventas
        public ActionResult Index()
        {
            var ventas = db.ventas.Include(v => v.Empleado).Include(v => v.TipoFactura).Include(v => v.EstadoFactura).Include(v => v.Cliente).Include(v => v.Retencion).Include(v => v.TipoPago);
            return View(ventas.ToList());
        }

        // GET: ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venta venta = db.ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: ventas/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Nombres");
            ViewBag.TipoFacturaId = new SelectList(db.TipoFacturas, "Id", "Nombre");
            ViewBag.EstadoFacturaId = new SelectList(db.EstadoFacturas, "Id", "Nombre");
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombres");
            ViewBag.RetencionId = new SelectList(db.Retenciones, "Id", "Nombre");
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Nombre");
            return View();
        }

        // POST: ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Venta,Fecha,Total,EmpleadoId,TipoFacturaId,EstadoFacturaId,ClienteId,RetencionId,TipoPagoId")] venta venta)
        {
            venta cat = db.ventas.Where(x => x.Cod_Venta.Trim() == venta.Cod_Venta.Trim())
                  .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.ventas.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Nombres", venta.EmpleadoId);
            ViewBag.TipoFacturaId = new SelectList(db.TipoFacturas, "Id", "Nombre", venta.TipoFacturaId);
            ViewBag.EstadoFacturaId = new SelectList(db.EstadoFacturas, "Id", "Nombre", venta.EstadoFacturaId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombres", venta.ClienteId);
            ViewBag.RetencionId = new SelectList(db.Retenciones, "Id", "Nombre", venta.RetencionId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Nombre", venta.TipoPagoId);
            return View(venta);
        }

        // GET: ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venta venta = db.ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Nombres", venta.EmpleadoId);
            ViewBag.TipoFacturaId = new SelectList(db.TipoFacturas, "Id", "Nombre", venta.TipoFacturaId);
            ViewBag.EstadoFacturaId = new SelectList(db.EstadoFacturas, "Id", "Nombre", venta.EstadoFacturaId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombres", venta.ClienteId);
            ViewBag.RetencionId = new SelectList(db.Retenciones, "Id", "Nombre", venta.RetencionId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Nombre", venta.TipoPagoId);
            return View(venta);
        }

        // POST: ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Venta,Fecha,Total,EmpleadoId,TipoFacturaId,EstadoFacturaId,ClienteId,RetencionId,TipoPagoId")] venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Nombres", venta.EmpleadoId);
            ViewBag.TipoFacturaId = new SelectList(db.TipoFacturas, "Id", "Nombre", venta.TipoFacturaId);
            ViewBag.EstadoFacturaId = new SelectList(db.EstadoFacturas, "Id", "Nombre", venta.EstadoFacturaId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombres", venta.ClienteId);
            ViewBag.RetencionId = new SelectList(db.Retenciones, "Id", "Nombre", venta.RetencionId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Nombre", venta.TipoPagoId);
            return View(venta);
        }

        // GET: ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venta venta = db.ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            venta venta = db.ventas.Find(id);
            db.ventas.Remove(venta);
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

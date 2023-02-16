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
    public class CuotasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Cuotas
        public ActionResult Index()
        {
            var cuotas = db.Cuotas.Include(c => c.TipoPago).Include(c => c.Renta);
            return View(cuotas.ToList());
        }

        // GET: Cuotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuota cuota = db.Cuotas.Find(id);
            if (cuota == null)
            {
                return HttpNotFound();
            }
            return View(cuota);
        }

        // GET: Cuotas/Create
        public ActionResult Create()
        {
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Cod_TipoP");
            ViewBag.RentaId = new SelectList(db.Rentas, "Id", "Cod_Renta");
            return View();
        }

        // POST: Cuotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Cuota,Fecha,TotalAbonado,TipoPagoId,RentaId")] Cuota cuota)
        {
            Cuota cat = db.Cuotas.Where(x => x.Cod_Cuota.Trim() == cuota.Cod_Cuota.Trim())
                 .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.Cuotas.Add(cuota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Cod_TipoP", cuota.TipoPagoId);
            ViewBag.RentaId = new SelectList(db.Rentas, "Id", "Cod_Renta", cuota.RentaId);
            return View(cuota);
        }

        // GET: Cuotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuota cuota = db.Cuotas.Find(id);
            if (cuota == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Cod_TipoP", cuota.TipoPagoId);
            ViewBag.RentaId = new SelectList(db.Rentas, "Id", "Cod_Renta", cuota.RentaId);
            return View(cuota);
        }

        // POST: Cuotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Cuota,Fecha,TotalAbonado,TipoPagoId,RentaId")] Cuota cuota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Cod_TipoP", cuota.TipoPagoId);
            ViewBag.RentaId = new SelectList(db.Rentas, "Id", "Cod_Renta", cuota.RentaId);
            return View(cuota);
        }

        // GET: Cuotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuota cuota = db.Cuotas.Find(id);
            if (cuota == null)
            {
                return HttpNotFound();
            }
            return View(cuota);
        }

        // POST: Cuotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuota cuota = db.Cuotas.Find(id);
            db.Cuotas.Remove(cuota);
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

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
    public class AsistenciaTecnicasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: AsistenciaTecnicas
        public ActionResult Index()
        {
            var asistenciaTecnicas = db.AsistenciaTecnicas.Include(a => a.Empleado).Include(a => a.Cliente).Include(a => a.TipoPago);
            return View(asistenciaTecnicas.ToList());
        }

        // GET: AsistenciaTecnicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsistenciaTecnica asistenciaTecnica = db.AsistenciaTecnicas.Find(id);
            if (asistenciaTecnica == null)
            {
                return HttpNotFound();
            }
            return View(asistenciaTecnica);
        }

        // GET: AsistenciaTecnicas/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Cod_Emp");
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cod_Cli");
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Cod_TipoP");
            return View();
        }

        // POST: AsistenciaTecnicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_AsisTec,Fecha,Direccion,Total,Descripcion,EmpleadoId,ClienteId,TipoPagoId")] AsistenciaTecnica asistenciaTecnica)
        {
            AsistenciaTecnica cat = db.AsistenciaTecnicas.Where(x => x.Cod_AsisTec.Trim() == asistenciaTecnica.Cod_AsisTec.Trim())
               .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.AsistenciaTecnicas.Add(asistenciaTecnica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Cod_Emp", asistenciaTecnica.EmpleadoId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cod_Cli", asistenciaTecnica.ClienteId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Cod_TipoP", asistenciaTecnica.TipoPagoId);
            return View(asistenciaTecnica);
        }

        // GET: AsistenciaTecnicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsistenciaTecnica asistenciaTecnica = db.AsistenciaTecnicas.Find(id);
            if (asistenciaTecnica == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Cod_Emp", asistenciaTecnica.EmpleadoId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cod_Cli", asistenciaTecnica.ClienteId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Cod_TipoP", asistenciaTecnica.TipoPagoId);
            return View(asistenciaTecnica);
        }

        // POST: AsistenciaTecnicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_AsisTec,Fecha,Direccion,Total,Descripcion,EmpleadoId,ClienteId,TipoPagoId")] AsistenciaTecnica asistenciaTecnica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistenciaTecnica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Cod_Emp", asistenciaTecnica.EmpleadoId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cod_Cli", asistenciaTecnica.ClienteId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagos, "Id", "Cod_TipoP", asistenciaTecnica.TipoPagoId);
            return View(asistenciaTecnica);
        }

        // GET: AsistenciaTecnicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsistenciaTecnica asistenciaTecnica = db.AsistenciaTecnicas.Find(id);
            if (asistenciaTecnica == null)
            {
                return HttpNotFound();
            }
            return View(asistenciaTecnica);
        }

        // POST: AsistenciaTecnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsistenciaTecnica asistenciaTecnica = db.AsistenciaTecnicas.Find(id);
            db.AsistenciaTecnicas.Remove(asistenciaTecnica);
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

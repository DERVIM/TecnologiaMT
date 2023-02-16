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
    public class RentasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Rentas
        public ActionResult Index()
        {
            var rentas = db.Rentas.Include(r => r.Empleado).Include(r => r.Cliente);
            return View(rentas.ToList());
        }

        // GET: Rentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renta renta = db.Rentas.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            return View(renta);
        }

        // GET: Rentas/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Cod_Emp");
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cod_Cli");
            return View();
        }

        // POST: Rentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Renta,Total_Renta,Fecha_Inicio,Fecha_Final,EmpleadoId,ClienteId")] Renta renta)
        {
            Renta cat = db.Rentas.Where(x => x.Cod_Renta.Trim() == renta.Cod_Renta.Trim())
                  .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.Rentas.Add(renta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Cod_Emp", renta.EmpleadoId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cod_Cli", renta.ClienteId);
            return View(renta);
        }

        // GET: Rentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renta renta = db.Rentas.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Cod_Emp", renta.EmpleadoId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cod_Cli", renta.ClienteId);
            return View(renta);
        }

        // POST: Rentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Renta,Total_Renta,Fecha_Inicio,Fecha_Final,EmpleadoId,ClienteId")] Renta renta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(renta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Cod_Emp", renta.EmpleadoId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cod_Cli", renta.ClienteId);
            return View(renta);
        }

        // GET: Rentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renta renta = db.Rentas.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            return View(renta);
        }

        // POST: Rentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Renta renta = db.Rentas.Find(id);
            db.Rentas.Remove(renta);
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

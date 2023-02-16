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
    public class RetencionsController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Retencions
        public ActionResult Index()
        {
            return View(db.Retenciones.ToList());
        }

        // GET: Retencions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retencion retencion = db.Retenciones.Find(id);
            if (retencion == null)
            {
                return HttpNotFound();
            }
            return View(retencion);
        }

        // GET: Retencions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Retencions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Reten,Nombre,Porcentaje")] Retencion retencion)
        {
            Retencion cat = db.Retenciones.Where(x => x.Cod_Reten.Trim() == retencion.Cod_Reten.Trim())
                 .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.Retenciones.Add(retencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(retencion);
        }

        // GET: Retencions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retencion retencion = db.Retenciones.Find(id);
            if (retencion == null)
            {
                return HttpNotFound();
            }
            return View(retencion);
        }

        // POST: Retencions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Reten,Nombre,Porcentaje")] Retencion retencion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retencion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(retencion);
        }

        // GET: Retencions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retencion retencion = db.Retenciones.Find(id);
            if (retencion == null)
            {
                return HttpNotFound();
            }
            return View(retencion);
        }

        // POST: Retencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Retencion retencion = db.Retenciones.Find(id);
            db.Retenciones.Remove(retencion);
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

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
    public class RazonSocialsController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: RazonSocials
        public ActionResult Index()
        {
            return View(db.RazonSociales.ToList());
        }

        // GET: RazonSocials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazonSocial razonSocial = db.RazonSociales.Find(id);
            if (razonSocial == null)
            {
                return HttpNotFound();
            }
            return View(razonSocial);
        }

        // GET: RazonSocials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RazonSocials/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_RaSocial,Nombre")] RazonSocial razonSocial)
        {
            RazonSocial cat = db.RazonSociales.Where(x => x.Cod_RaSocial.Trim() == razonSocial.Cod_RaSocial.Trim())
                  .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.RazonSociales.Add(razonSocial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(razonSocial);
        }

        // GET: RazonSocials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazonSocial razonSocial = db.RazonSociales.Find(id);
            if (razonSocial == null)
            {
                return HttpNotFound();
            }
            return View(razonSocial);
        }

        // POST: RazonSocials/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_RaSocial,Nombre")] RazonSocial razonSocial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(razonSocial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(razonSocial);
        }

        // GET: RazonSocials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazonSocial razonSocial = db.RazonSociales.Find(id);
            if (razonSocial == null)
            {
                return HttpNotFound();
            }
            return View(razonSocial);
        }

        // POST: RazonSocials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RazonSocial razonSocial = db.RazonSociales.Find(id);
            db.RazonSociales.Remove(razonSocial);
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

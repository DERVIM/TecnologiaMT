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
    public class Estado_ProductoController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Estado_Producto
        public ActionResult Index()
        {
            return View(db.Estado_Productos.ToList());
        }

        // GET: Estado_Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Producto estado_Producto = db.Estado_Productos.Find(id);
            if (estado_Producto == null)
            {
                return HttpNotFound();
            }
            return View(estado_Producto);
        }

        // GET: Estado_Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado_Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_EsPro,Nombre,Observacion")] Estado_Producto estado_Producto)
        {
            Estado_Producto cat = db.Estado_Productos.Where(x => x.Cod_EsPro.Trim() == estado_Producto.Cod_EsPro.Trim())
            .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.Estado_Productos.Add(estado_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Producto);
        }

        // GET: Estado_Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Producto estado_Producto = db.Estado_Productos.Find(id);
            if (estado_Producto == null)
            {
                return HttpNotFound();
            }
            return View(estado_Producto);
        }

        // POST: Estado_Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_EsPro,Nombre,Observacion")] Estado_Producto estado_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Producto);
        }

        // GET: Estado_Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Producto estado_Producto = db.Estado_Productos.Find(id);
            if (estado_Producto == null)
            {
                return HttpNotFound();
            }
            return View(estado_Producto);
        }

        // POST: Estado_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Producto estado_Producto = db.Estado_Productos.Find(id);
            db.Estado_Productos.Remove(estado_Producto);
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

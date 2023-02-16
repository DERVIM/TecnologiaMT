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
    public class ProductoesController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Productoes
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Marca).Include(p => p.Categoria).Include(p => p.Estado_Producto);
            return View(productos.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre");
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre");
            ViewBag.Estado_ProductoId = new SelectList(db.Estado_Productos, "Id", "Nombre");
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Prod,Nombre,Modelo,Num_Serie,Stock,PrecioCompra,PrecioVenta,Pre_UniRenta,Descripcion,MarcaId,CategoriaId,Estado_ProductoId")] Producto producto)
        {
            Producto cat = db.Productos.Where(x => x.Cod_Prod.Trim() == producto.Cod_Prod.Trim())
                  .DefaultIfEmpty().FirstOrDefault();
            if (cat != null)
                ModelState.AddModelError("Codigo", "Ya existe ese código en BD");

            if (ModelState.IsValid)
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", producto.MarcaId);
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", producto.CategoriaId);
            ViewBag.Estado_ProductoId = new SelectList(db.Estado_Productos, "Id", "Nombre", producto.Estado_ProductoId);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", producto.MarcaId);
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", producto.CategoriaId);
            ViewBag.Estado_ProductoId = new SelectList(db.Estado_Productos, "Id", "Nombre", producto.Estado_ProductoId);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Prod,Nombre,Modelo,Num_Serie,Stock,PrecioCompra,PrecioVenta,Pre_UniRenta,Descripcion,MarcaId,CategoriaId,Estado_ProductoId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", producto.MarcaId);
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", producto.CategoriaId);
            ViewBag.Estado_ProductoId = new SelectList(db.Estado_Productos, "Id", "Nombre", producto.Estado_ProductoId);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult BuscarProducto(string item)
        { 
            var resultad = db.Productos.Where(x => x.Nombre.Contains(item)).Select(x => x.Nombre).Take(5).ToList();
            return Json(resultad, JsonRequestBehavior.AllowGet);

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

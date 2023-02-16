using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TecnologiaMT.Models;

namespace TecnologiaMT.Views
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        ApplicationDbContext context;
        //private ModeloContainer db = new ModeloContainer();

        public UsuariosController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var Usuario = context.Users.ToList();
            return View(Usuario);

        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var User = context.Users.Find(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolId = new SelectList(context.Roles, "Id", "Name", User.Id);
            return View(User);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Password,ConfirmPassword,RolId")] ApplicationUser User)
        {
            if (ModelState.IsValid)
            {
                context.Entry(User).State = EntityState.Modified;
                context.SaveChanges();
                TempData["Message"] = "Cliente Modificado con exito";
                return RedirectToAction("Index");
            }
            ViewBag.RolId = new SelectList(context.Roles, "Id", "Name", User.Id);
            return View(User);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var User = context.Users.Find(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        //// POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var Usuarios = context.Users.Find(id);
            context.Users.Remove(Usuarios);
            context.SaveChanges();
            TempData["Message"] = " Eliminado con exito";
            return RedirectToAction("Index");
        }
    }
}
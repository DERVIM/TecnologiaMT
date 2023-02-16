using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TecnologiaMT.Controllers
{
    public class SalirController : Controller
    {
        // GET: Salir
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
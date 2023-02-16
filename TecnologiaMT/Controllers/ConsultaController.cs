using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecnologiaMT.Models;
using Rotativa;
namespace TecnologiaMT.Controllers
{
    public class ConsultaController : Controller
    {
        private ModeloContainer db = new ModeloContainer();
        // GET: Consulta
        public ActionResult Index(Cliente cliente)
        {       
            return View();
        }

        public ActionResult InformeCliente()
        {
            return View(db.Clientes.ToList());
        }
        public ActionResult ImprimirBus()
        {
            return new ActionAsPdf("InformeCliente")
            {
                FileName = "Reporte_Cliente.pdf",
                Cookies = Request.Cookies.AllKeys.ToDictionary(x => x, x => Request.Cookies[x].Value)
            };
        }
    }
}

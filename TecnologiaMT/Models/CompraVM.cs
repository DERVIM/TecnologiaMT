using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TecnologiaMT.Models;

namespace TecnologiaMT.Models
{
    public class CompraVM
    {
      public Compra oCompra { get; set; }
        public List<DetalleCompra> oDetalleCompra { get; set; }
    }
}
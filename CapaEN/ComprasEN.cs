using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class ComprasEN
    {
        public int idPedido { get; set; }
        public string Documento { get; set; }
        public string usuario { get; set; }
        public string observacion { get; set; }
        public int idTecnico { get; set; }

        public int noOrdenCompra { get; set; }
        public string fechaOrdenCompra { get; set; }
        public double montoReal { get; set; }
        public int idccValeDetalle { get; set; }
        public int idccVale { get; set; }
        public int idProveedor { get; set; }
        public string proveedor { get; set; }
        public string nit { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

    }
}

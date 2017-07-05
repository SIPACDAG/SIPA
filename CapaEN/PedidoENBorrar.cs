using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class PedidoENBorrar
    {
        public int idPedido { get; set; }
        public string fechaPedido { get; set; }
        public int idAccion { get; set; }
        public int idTipoPedido { get; set; }
        public int idSolicitante { get; set; }
        public int idJefeDireccion { get; set; }
        public int idGerente { get; set; }
        public int idDirFinanciera { get; set; }
        public string Justificacion { get; set; }
        
        public int AprobadoFinanciero { get; set; }
        public string observacionFinanciero { get; set; }
        public string usuario { get; set; }

        public int idpedidoDetalle { get; set; }
        public int idPac { get; set; }
        public int cantidad { get; set; }
        public int idUnidadMedida { get; set; }
        public string descripcion { get; set; }
        public double costoEstimado { get; set; }
        public int idDetalleAccion { get; set; }
        


        public int existencia { get; set; }
        public string observacionAlmacen { get; set; }

        public int ccidVale { get; set; }
        public int ccidValeDetalle { get; set; }
        public int idSubGerente { get; set; }

        // Gastos varios
        public int idGasto { get; set; }
        public int idGastoTipo { get; set; }
        public int idFand { get; set; }
        public int idGastoDetalle { get; set; }


        public string pro { get; set; }
        public string spro { get; set; }
        public string act { get; set; }
        public double reajuste { get; set; }
        
    }
}

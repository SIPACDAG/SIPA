using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
   public class PoaEN
    {
       public int idPoa { get; set; }
       public int idestado { get; set; }
       public int idUnidad { get; set; }
       public int anio { get; set; }
       public double monto { get; set; }
       public int idAccion { get; set; }
       public string accion { get; set; }
       public int noActividades { get; set; }
       public int idDependencia { get; set; }
       public int idProducto { get; set; }
       public string fechaInicio { get; set; }
       public string fechaFin { get; set; }
       public string usuario { get; set; }
       public int idDetalleAccion { get; set; }
       public string NoReglon { get; set; }
       public double Costo { get; set; }
       public int idFinanciamiento { get; set; }
       
       public int idBeneficiario  { get ; set; }
       public int cantidadBen { get; set; }
       public int idBenAccion { get; set; }
       public string mensaje { get; set; }
    }
}

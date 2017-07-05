using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class PacEN
    {
        public int idPac { get; set; }
        public int idDetalleAccion { get; set; }
        public int idModalidad { get; set; }
        public int idExcepcion { get; set; }
        public string descripcion { get; set; }
        public double montototal { get; set; }
        public string usuario { get; set; }

        public int idPacDetalle { get; set; }
        public int mes { get; set; }
        public int cantidad { get; set; }
        public double montomes { get; set; }
        

        public int idPoa { get; set; }
        public int idAccion { get; set; }
        public int anio  {get; set;}
        public int idUnidad { get; set;}
             
            

    }
}

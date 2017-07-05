using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
   public class CmiEN
    {
       public int Id_Poa { get; set; }

       public int Id_Unidad { get; set; }

       public string Codigo { get; set; }

       public decimal Monto { get; set; }

       public int Anio { get; set; }

       public int Id_Estado { get; set; }

       public DateTime Fecha_Estado { get; set; }

       public string Usuario_Estado { get; set; }

       public string mensaje { get; set; }
    }
}

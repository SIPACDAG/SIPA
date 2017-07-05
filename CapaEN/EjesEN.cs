using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class EjesEN
    {
        public int Id_Eje_Estrategico{ get; set; }

        public String Eje_Estrategico{ get; set; }

        public int Id_Plan { get; set; }

        public int Codigo_Eje { get; set; }

        public string NOMBRE_PLAN { get; set; }

        public string DESCRIPCION { get; set; }

        public int ANIO_INI { get; set; }

        public int ANIO_FIN { get; set; }

        public string USUARIO { get; set; }

    }
}

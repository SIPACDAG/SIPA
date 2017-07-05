using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class MetasOperativasEN
    {
        public int Id_Meta_Operativa{ get; set; }

        public int Id_Kpi_Operativo { get; set; }

        public int Anio { get; set; }

        public string Nombre { get; set; }

        public int Id_Respondable { get; set; }

        public string Meta_Propuesta { get; set; }

        public string Usuario { get; set; }

    }
}

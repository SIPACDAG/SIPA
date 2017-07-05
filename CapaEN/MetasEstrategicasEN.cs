using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class MetasEstrategicasEN
    {
        public int Id_Meta{ get; set; }

        public int Id_Kpi { get; set; }
        
        public string Nombre { get; set; }

        public string Meta_Propuesta { get; set; }

        public int Id_Respondable { get; set; }

        public string Usuario { get; set; }

        public int Anio { get; set; }

        public int Codigo_Meta_Estrategica { get; set; }

        public string Formula { get; set; }

        public int Id_Objetivo_Estrategico { get; set; }

        public string Kpi { get; set; }

        public System.Data.DataTable Unidades { get; set; }

    }
}

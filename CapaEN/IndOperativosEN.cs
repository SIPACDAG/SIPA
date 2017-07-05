using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class IndOperativosEN
    {
        public int Id_Kpi_Operativo{ get; set; }

        public int Id_Objetivo_Operativo{ get; set; }

        public int Id_Meta_Estrategica { get; set; }

        public string Nombre{ get; set; }

        public int Anio { get; set; }

        public string Descripcion { get; set; }

        public string Formula { get; set; }

        public string Usuario{ get; set; }

    }
}

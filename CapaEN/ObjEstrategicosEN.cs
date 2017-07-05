using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class ObjEstrategicosEN
    {
        public int Id_Objetivo_Estrategico{ get; set; }

        public String Objetivo_Estrategico { get; set; }

        public int Anio { get; set; }

        public int Anio_Fin { get; set; }

        public int Id_Eje_Estrategico { get; set; }

        public int Codigo_Objetivo_Estrategico { get; set; }

        public int Id_Responsable { get; set; }

        public string Medios { get; set; }

        public string Normativa { get; set; }

        public string Usuario{ get; set; }

    }
}

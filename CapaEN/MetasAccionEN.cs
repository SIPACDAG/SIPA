using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class MetasAccionEN
    {
        public int Id_Meta_Accion{ get; set; }

        public int Id_Accion { get; set; }

        public int Id_Meta_Operativa { get; set; }

        public String Meta_General{ get; set; }

        public String Meta_1 { get; set; }

        public String Meta_2{ get; set; }

        public String Meta_3{ get; set; }

        public Decimal Ponderacion1 { get; set; }

        public Decimal Ponderacion2 { get; set; }
        
        public Decimal Ponderacion3 { get; set; }
        
        public Decimal Ponderacion { get; set; }

        public Decimal Presupuesto { get; set; }

        public Decimal Debito { get; set; }

        public Decimal Credito { get; set; }

        public Decimal Presupuesto_Modificado { get; set; }

        public String Responsable{ get; set; }

        public int No_Actividades { get; set; }

        public int Enero { get; set; }

        public int Febrero { get; set; }

        public int Marzo { get; set; }

        public int Abril { get; set; }

        public int Mayo { get; set; }

        public int Junio { get; set; }

        public int Julio { get; set; }

        public int Agosto { get; set; }

        public int Septiembre { get; set; }

        public int Octubre { get; set; }

        public int Noviembre { get; set; }

        public int Diciembre { get; set; }

        public int Anio { get; set; }

        public string Usuario { get; set; }
    }
}

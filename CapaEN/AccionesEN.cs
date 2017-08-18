using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class AccionesEN
    {
        public int Id_Accion{ get; set; }

        public int Id_Poa { get; set; }

        public int Id_Dependencia { get; set; }

        public int Id_Objetivo_Operativo{ get; set; }

        public int Id_Meta_Operativa { get; set; }
        
        public int Codigo { get; set; }

        public String Accion{ get; set; }

        public String Meta_General{ get; set; }

        public String Meta_1 { get; set; }

        public String Meta_2{ get; set; }

        public String Meta_3{ get; set; }

        public Decimal Ponderacion { get; set; }

        public Decimal Ponderacion1 { get; set; }
        
        public Decimal Ponderacion2 { get; set; }
        
        public Decimal Ponderacion3 { get; set; }

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

        public int Id_Unidad { get; set; }

        public string Usuario { get; set; }
    }

    public class AccionesDetEN
    {
        public int Id_Detalle { get; set; }

        public int Id_Accion { get; set; }

        public string No_Renglon { get; set; }

        public decimal Monto { get; set; }

        public int Id_Tipo_Financiamiento { get; set; }

        public string Id_Insumo { get; set; }

        public int Id_Tipo_Detalle { get; set; }

        public string Usuario { get; set; }
    }

    public class AccionesDetTransferenciasEN
    {
        public string vid_poa { get; set; }
        public string vid_accion_origen { get; set; }
        public string vid_detalle { get; set; }
        public string vmonto_actual_origen { get; set; }
        public string vmonto_nuevo_origen { get; set; }
        public string vcodificado_origen { get; set; }
        public string vdebito { get; set; }
        public string vdestino_debito { get; set; }
        public string vid_accion_destino { get; set; }
        public string vid_detalle_destino { get; set; }
        public string vno_renglon_ppto { get; set; }
        public string vmonto_actual_destino { get; set; }
        public string vmonto_nuevo_destino { get; set; }
        public string vcodificado_destino { get; set; }
        public string vcredito { get; set; }
        public string vorigen_credito { get; set; }
        public string vjustificacion { get; set; }
        public string vusuario { get; set; }
    }
}

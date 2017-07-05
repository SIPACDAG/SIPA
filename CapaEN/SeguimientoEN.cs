using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaEN
{
    public class SeguimientoCalendarioEN
    {
        public string ID_SEGUIMIENTO_CALENDARIO { get; set; }
        public string ID_PLAN { get; set; }
        public string ANIO { get; set; }
        public string ENTREGA_ENERO { get; set; }
        public string ENTREGA_FEBRERO { get; set; }
        public string ENTREGA_MARZO { get; set; }
        public string ENTREGA_ABRIL { get; set; }
        public string ENTREGA_MAYO { get; set; }
        public string ENTREGA_JUNIO { get; set; }
        public string ENTREGA_JULIO { get; set; }
        public string ENTREGA_AGOSTO { get; set; }
        public string ENTREGA_SEPTIEMBRE { get; set; }
        public string ENTREGA_OCTUBRE { get; set; }
        public string ENTREGA_NOVIEMBRE { get; set; }
        public string ENTREGA_DICIEMBRE { get; set; }

        public string ID_ESTADO { get; set; }
        public string ACTIVO { get; set; }
        public string USUARIO { get; set; }
    }

    public class SEGUIMIENTOS_CMI
    {
        //ENCABEZADO
        public string ID_SEGUIMIENTO_CMI { get; set; }
        public string ID_POA { get; set; }
        public string ID_UNIDAD { get; set; }
        public string ANIO { get; set; }
        public string NO_CUATRIMESTRE { get; set; }
        public string MES { get; set; }
        public string ID_ESTADO { get; set; }
        public string ANEXO { get; set; }
        public string ID_SEGUIMIENTO_CALENDARIO { get; set; }
        public string OBSERVACIONES_RECHAZO { get; set; }
        public string OBSERVACIONES_DGE { get; set; }
        public string FECHA_RECEPCION { get; set; }
        public string ACTIVO { get; set; }
        public string USUARIO { get; set; }
    }

    public class SEGUIMIENTOS_CMI_DET
    {
        public string ID_SEGUIMIENTO_CMI_DET { get; set; }
        public string ID_SEGUIMIENTO_CMI { get; set; }
        public string ID_ACCION { get; set; }
        public string DESCRIPCION { get; set; }
        public string PPTO_ANUAL { get; set; }
        public string AVANCE_PPTO_CUATRIMESTRAL { get; set; }
        public string AVANCE_PPTO_ACUMULADO { get; set; }
        public string SALDO { get; set; }
        public string MEDIOS_VERIFICACION { get; set; }
        public string AVANCE_KPI { get; set; }
        public string DESCRIPCION_AVANCE_KPI { get; set; }
        public string ANEXO { get; set; }
        public string OBSERVACIONES_DGE { get; set; }
        public string PLAN_ACCION { get; set; }
        public string ACTIVO { get; set; }
        public string USUARIO { get; set; }

        public DataSet armarDsSeguimientoDetalles()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("ID_SEGUIMIENTO_CMI_DET", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("ID_SEGUIMIENTO_CMI", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("ID_ACCION", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("DESCRIPCION", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("PPTO_ANUAL", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("AVANCE_PPTO_CUATRIMESTRAL", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("AVANCE_PPTO_ACUMULADO", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("SALDO", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("MEDIOS_VERIFICACION", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("AVANCE_KPI", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("DESCRIPCION_AVANCE_KPI", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("ANEXO", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("OBSERVACIONES_DGE", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("PLAN_ACCION", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("ACTIVO", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("USUARIO", Type.GetType("System.String"));

            return ds;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaEN
{
    public class PedidosEN
    {
        //ENCABEZADO DEL PEDIDDO
        public int ID_PEDIDO { get; set; }
        public int ID_POA { get; set; }
        public string FECHA_PEDIDO { get; set; }
        public int ID_ACCION { get; set; }
        public int ID_TIPO_PEDIDO { get; set; }
        public int ID_SOLICITANTE { get; set; }
        public int ID_JEFE_DIRECCION { get; set; }
        public int ID_GERENTE { get; set; }
        public int ID_DIREC_FINANCIERA { get; set; }
        public string JUSTIFICACION { get; set; }
        public int DESTINO { get; set; }
        public int ID_FAND { get; set; }
        public int ID_TIPO_ANEXO { get; set; }

        public int ESTADO_FINANCIERO { get; set; }
        public string OBSERVACION_FINANCIERO { get; set; }
        public string USUARIO_FINANCIERO { get; set; }
        public int EXISTENCIA { get; set; }
        public string OBSERVACIONES_ALMACEN { get; set; }

        public string TOTAL_EN_LETRAS { get; set; }

        public string USUARIO { get; set; }
        
        //DETALLE DEL PEDIDO
        public int ID_PEDIDO_DETALLE { get; set; }
        public decimal CANTIDAD_ESTIMADA { get; set; }
        public decimal COSTO_ESTIMADO { get; set; }
        public int ID_UNIDAD_MEDIDA { get; set; }
        public int ID_PAC { get; set; }
        public string DESCRIPCION { get; set; }
        public int ID_DETALLE_ACCION { get; set; }
        public int ID_INSUMO { get; set; }
        public int ID_PROVEEDOR { get; set; }
        public string PROGRAMA { get; set; }
        public string SUBPROGRAMA { get; set; }
        public string ACTIVIDAD { get; set; }
        public double REAJUSTE { get; set; }
        //public string VCOSTO_PEDIDO_MULTIANUAL { get; set; }
        public string VCANTIDAD_PEDIDO_MULTIANUAL { get; set; }
        public string VCOSTO_PEDIDO_MULTIANUAL { get; set; }
        
        //VALES
        public int ccidVale { get; set; }
        public int ccidValeDetalle { get; set; }
        public int idSubGerente { get; set; }

        //GASTOS VARIOS
        public int idGasto { get; set; }
        public int idGastoTipo { get; set; }
        public int idFand { get; set; }
        public int idGastoDetalle { get; set; }

        //ESPECIFICACION DEL PEDIDO
        public int ID_ESPECIFICACION { get; set; }


        public string VID_PEDIDO_DETALLE { get; set; }
        public string VCOSTO_REAL { get; set; }
        public string VNO_ORDEN_COMPRA { get; set; }
        public string VFECHA_ORDEN_COMPRA { get; set; }
        public string VLIQUIDACIONES_PARCIALES { get; set; }
        public string VIVA { get; set; }
        public string VID_TIPO_DOCUMENTO { get; set; }
        public string VID_PROVEEDOR { get; set; }
        public string MULTIANUAL { get; set; }
        
    }

    public class AJUSTE_PEDIDO
    {
        //ENCABEZADO
        public string VID_AJUSTE_PEDIDO { get; set; }
        public string VID_POA { get; set; }
        public string VID_UNIDAD { get; set; }
        public string VANIO { get; set; }
        public string VID_TIPO_DOCUMENTO { get; set; }
        public string VID_PEDIDO { get; set; }
        public string VNO_SOLICITUD { get; set; }
        public string VANIO_SOLICITUD { get; set; }
        public string VFECHA_AJUSTE { get; set; }
        public string VJUSTIFICACION { get; set; }
        public string VOBSERVACIONES { get; set; }
        public string VID_ESTADO_AJUSTE { get; set; }
        public string VANULADO { get; set; }
        public string VID_SOLICITANTE { get; set; }
        public string VID_SUBGERENTE_DIRECTOR { get; set; }
        public string VID_ANALISTA_PPTO { get; set; }
        public string VUSUARIO { get; set; }
        public string VOPCION { get; set; }


    }

    public class AJUSTE_PEDIDO_DET
    {
        public string VID_AJUSTE_PEDIDO_DET { get; set; }
        public string VID_AJUSTE_PEDIDO { get; set; }
        public string VID_PEDIDO_DETALLE { get; set; }
        public string VMONTO_AJUSTE { get; set; }
        public string VOBSERVACIONES { get; set; }
        public string VID_DETALLE_ACCION { get; set; }
        public string VUSUARIO { get; set; }
        public string VOPCION { get; set; }


        public DataSet ArmarDsAjustePedidoDetalles()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("VID_AJUSTE_PEDIDO_DET", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VID_AJUSTE_PEDIDO", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VID_PEDIDO_DETALLE", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VMONTO_AJUSTE", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VOBSERVACIONES", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VID_DETALLE_ACCION", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VUSUARIO", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VOPCION", Type.GetType("System.String"));
            
            return ds;
        }
    }
}

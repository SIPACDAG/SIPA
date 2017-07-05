using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using CapaEN;
using System.Web.UI.WebControls;
using System.Web;
using System.Data;
using NumeroaLetras;
namespace CapaLN
{
   public class PedidoLNBorrar
    {
       PedidoADBorrar pedidoAD;
       public DataTable rptPedido(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.rptPedido(pedidoEN);
       }
       public DataTable rptPedidoDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.rptPedidoDetalle(pedidoEN);
       }
       public DataTable rptVale(PedidoENBorrar pedidoEN)
       {
           DataTable tabla;
           DataTable tblDatosLetras = new DataTable();
           NumeroALetras clsNaLetras = new NumeroALetras();
           string NoVale, FechaVale, Justificacion, Solicitante, JefeDireccion, SubGerente, NoAccion, MontoTotal, MontoLetras;

           tblDatosLetras.Columns.Add("NoVale", Type.GetType("System.String")); //0
           tblDatosLetras.Columns.Add("FechaVale", Type.GetType("System.String")); //1
           tblDatosLetras.Columns.Add("Justificacion", Type.GetType("System.String")); //2
           tblDatosLetras.Columns.Add("Solicitante", Type.GetType("System.String")); //3
           tblDatosLetras.Columns.Add("JefeDireccion", Type.GetType("System.String")); //4
           tblDatosLetras.Columns.Add("SubGerente", Type.GetType("System.String")); //5
           tblDatosLetras.Columns.Add("NoAccion", Type.GetType("System.String")); //6
           tblDatosLetras.Columns.Add("MontoTotal", Type.GetType("System.String")); //7
           tblDatosLetras.Columns.Add("MontoLetras", Type.GetType("System.String")); //8

           pedidoAD = new PedidoADBorrar();
           tabla = pedidoAD.rptVale(pedidoEN);


           
           NoVale =Convert.ToString(tabla.Rows[0][0]).ToLower();
           FechaVale= Convert.ToString(tabla.Rows[0][1]).ToLower();
           Justificacion=Convert.ToString(tabla.Rows[0][2]); 
           Solicitante=Convert.ToString(tabla.Rows[0][3]); 
           JefeDireccion=Convert.ToString(tabla.Rows[0][4]); 
           SubGerente=Convert.ToString(tabla.Rows[0][5]); 
           NoAccion=Convert.ToString(tabla.Rows[0][6]).ToLower();
           MontoTotal=Convert.ToString(tabla.Rows[0][7]).ToUpper();

           MontoLetras = clsNaLetras.NumerosLetrasQuetzales(Convert.ToDecimal(tabla.Rows[0][7])).ToLower();

           tblDatosLetras.Rows.Add(NoVale, FechaVale, Justificacion, Solicitante, JefeDireccion, SubGerente, NoAccion, MontoTotal, MontoLetras);
           return tblDatosLetras;
       }
       public DataTable rptValeDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.rptValeDetalle(pedidoEN);
       }
       public DataTable rptGasto(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.rptGasto(pedidoEN);
       }
       public DataTable rptGastoDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.rptGastoDetalle(pedidoEN);
       }
       public void gridclsSaldoAcPedido(GridView grid, PedidoENBorrar pedidoEN,int tipoDoc)
       {
           pedidoAD = new PedidoADBorrar();
           grid.DataSource = pedidoAD.gridclsSaldoAcPedido(pedidoEN, tipoDoc);
           grid.DataBind();
       
       }
       public DataTable clsSaldoCodificacion(PedidoENBorrar pedidoEN, int tipoDoc)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.clsSaldoCodificacion(pedidoEN,tipoDoc);
       }
       public double saldoPacPac(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.saldoPacPac(pedidoEN);
       }
       public int pacidDetalleAccion(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.pacidDetalleAccion(pedidoEN);
       }
       public void dropAccionesPedido(DropDownList drop, PedidoENBorrar pedidoEN,int tipoDoc)
       {
           drop.ClearSelection();
           drop.Items.Clear();
           drop.AppendDataBoundItems = true;
           drop.Items.Add("<< Eliga Reglon >>");
           drop.Items[0].Value = "0";
           pedidoAD = new PedidoADBorrar();
           drop.DataSource = pedidoAD.dropAccionesPedido(pedidoEN,tipoDoc);
           drop.DataTextField = "texto";
           drop.DataValueField = "id";
           drop.DataBind();
       }
       public void dropAccion(DropDownList drop,PedidoENBorrar pedidoEN)
       {
           drop.ClearSelection();
           drop.Items.Clear();
           drop.AppendDataBoundItems = true;
           drop.Items.Add("<< Eliga Accion >>");
           drop.Items[0].Value = "0";
           pedidoAD = new PedidoADBorrar();
           drop.DataSource = pedidoAD.DropAcciones(pedidoEN);
           drop.DataTextField = "texto";
           drop.DataValueField = "id";
           drop.DataBind();
       }

       public void dropEmpleado(DropDownList drop,PedidoENBorrar pedidoEN, int idUnidad)
       {
           drop.ClearSelection();
           drop.Items.Clear();
           drop.AppendDataBoundItems = true;
           drop.Items.Add("<< Eliga Solicitante >>");
           drop.Items[0].Value = "0";
           pedidoAD = new PedidoADBorrar();
           drop.DataSource = pedidoAD.dropEmpleado(pedidoEN, idUnidad);
           drop.DataTextField = "texto";
           drop.DataValueField = "id";
           drop.DataBind();

       }

       public void dropJefeDireccion(DropDownList drop,PedidoENBorrar pedidoEN)
       {
           drop.ClearSelection();
           drop.Items.Clear();
           drop.AppendDataBoundItems = true;
           drop.Items.Add("<< Eliga Jefe Direccion >>");
           drop.Items[0].Value = "0";
           pedidoAD = new PedidoADBorrar();
           drop.DataSource = pedidoAD.dropJefeDireccion(pedidoEN);
           drop.DataTextField = "texto";
           drop.DataValueField = "id";
           drop.DataBind();

       }
       public void dropTipoPedido(DropDownList drop)
       {
           drop.ClearSelection();
           drop.Items.Clear();
           drop.AppendDataBoundItems = true;
           drop.Items.Add("<< Eliga Tipo Pedido >>");
           drop.Items[0].Value = "0";
           pedidoAD = new PedidoADBorrar();
           drop.DataSource = pedidoAD.dropTipoPedido();
           drop.DataTextField = "texto";
           drop.DataValueField = "id";
           drop.DataBind();
       }
       
    public void dropUnidadMedida(DropDownList drop,PedidoENBorrar pedidoEN)
       {
           drop.ClearSelection();
           drop.Items.Clear();
           drop.AppendDataBoundItems = true;
           drop.Items.Add("<< Eliga Unidad Medida >>");
           drop.Items[0].Value = "0";
           pedidoAD = new PedidoADBorrar();
           drop.DataSource = pedidoAD.dropUnidadMedida(pedidoEN);
           drop.DataTextField = "texto";
           drop.DataValueField = "id";
           drop.DataBind();
       }
   public void dropNoPacAccion(DropDownList drop, PedidoENBorrar pedidoEN)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga El No. de PAC >>");
            drop.Items[0].Value = "0";
            pedidoAD = new PedidoADBorrar();
            drop.DataSource = pedidoAD.pacNoAccion(pedidoEN);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

       public int maxidPedido()
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.maxidPedido();
        }
       public void gridEstadoPedido(GridView grid, PedidoENBorrar pedidoEN)
       { 
            pedidoAD = new PedidoADBorrar();
            grid.DataSource = pedidoAD.gridEstadoPedido(pedidoEN);
            grid.DataBind();
       
       }
       public void gridEstadoVale(GridView grid, PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           grid.DataSource = pedidoAD.gridEstadoVale(pedidoEN);
           grid.DataBind();
       }
       public void gridEstadoExistencia(GridView grid, PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           grid.DataSource = pedidoAD.gridEstadoExistencia(pedidoEN);
           grid.DataBind();

       }
       public void gridPedidoDetalleFinan(GridView grid, PedidoENBorrar pedidoEN, int tipoDoc)
       {
           pedidoAD = new PedidoADBorrar();
           grid.DataSource = pedidoAD.gridPedidoDetalleFinan(pedidoEN, tipoDoc);
           grid.DataBind();

       }
       public void dvPedidoFinan(DetailsView dv)
       {
           pedidoAD = new PedidoADBorrar();
           dv.DataSource = pedidoAD.dvPedidoFinan();
           dv.DataBind();
        }
       public void dvPedidoEncargado(DetailsView dv, PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           dv.DataSource = pedidoAD.dvPedidoEncargado(pedidoEN);
           dv.DataBind();
       }
       public void dvPedidoExistencia(DetailsView dv)
       {
           pedidoAD = new PedidoADBorrar();
           dv.DataSource = pedidoAD.dvPedidoExistencia();
           dv.DataBind();
       }

       public void griMPedidoD(GridView grid, PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           grid.DataSource = pedidoAD.gridMPedidoD(pedidoEN,1);
           grid.DataBind();

       }
       public DataTable datosMPedidoD(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.gridMPedidoD(pedidoEN,2);
       }
       public DataTable datosMPedido(PedidoENBorrar pedidoEN)
       { 
          pedidoAD = new PedidoADBorrar();
          return pedidoAD.datosMPedido(pedidoEN);
       }
       public DataTable datosMVale(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.datosMVale(pedidoEN);
       }
       public DataTable datosMValeDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.datosMValeDetalle(pedidoEN, 2);
           
       }
       public void gridMValeD(GridView grid, PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           grid.DataSource = pedidoAD.datosMValeDetalle(pedidoEN, 1);
           grid.DataBind();
       }
       public void gridPedidoVerSaldos(GridView grid, PedidoENBorrar pedidoEN,int op)
       {
           pedidoAD = new PedidoADBorrar();
           grid.DataSource = pedidoAD.PedidoVerSaldos(pedidoEN, op);
           grid.DataBind();
       }
       public void gridPedidoDetalleVerSaldos(GridView grid, PedidoENBorrar pedidoEN, int op)
       {
           pedidoAD = new PedidoADBorrar();
           grid.DataSource = pedidoAD.PedidoDetalleVerSaldos(pedidoEN, op);
           grid.DataBind();
       }
       public int insertarPedido(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.insertarPedido(pedidoEN);
       }

       public int insertarPedidoDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.insertarPedidoDetalle(pedidoEN);
       }
       public int valNoPacPedidoD(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.valNoPacPedidoD(pedidoEN);
       }
       public int modificarPedidoDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.modificarPedidoDetalle(pedidoEN);
       }
       public int modificarPedido(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.modificarPedido(pedidoEN);
       }
       public void Codificar_Reglon(PedidoENBorrar pedidoEN,int tipoDoc)
       {
           pedidoAD = new PedidoADBorrar();
           pedidoAD.Codificar_Reglon(pedidoEN, tipoDoc);
       }
       public int Modificar_ProSproAct(string par, PedidoENBorrar pedidoEN, int tipoDoc, int op)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Modificar_ProSproAct(par, pedidoEN, tipoDoc, op);
       }
       public int Aprobar_Pedido(PedidoENBorrar pedidoEN,int tipoDoc)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Aprobar_Pedido(pedidoEN, tipoDoc);
       }
       public int Aprobar_EncargadoP(PedidoENBorrar pedidoEN,int tipoDoc)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Aprobar_EncargadoP(pedidoEN, tipoDoc);
       }
       public int Aprobar_ExistenciaP(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Aprobar_ExistenciaP(pedidoEN);
       }
       public int Rechazar_Pedido(PedidoENBorrar pedidoEN, int tipoDoc)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Rechazar_Pedido(pedidoEN, tipoDoc);
       }
       public int Quitar_Detalle(PedidoENBorrar pedidoEN, int tipoDoc)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Quitar_Detalle(pedidoEN, tipoDoc);
       }
       public int Rechazar_EncargadoP(PedidoENBorrar pedidoEN, int tipoDoc)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Rechazar_EncargadoP(pedidoEN, tipoDoc);
       }
       public int Rechazar_ExistenciaP(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Rechazar_ExistenciaP(pedidoEN);
       }
       public int Insertar_ccVale(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Insertar_ccVale(pedidoEN);
       }
       public int Modificar_ccVale(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Modificar_ccVale(pedidoEN);
       }
       public int Insertar_ccValeDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Insertar_ccValeDetalle(pedidoEN);
       }
       public int Modificar_ccValeDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Modificar_ccValeDetalle(pedidoEN);
       }
       public int maxccidVale()
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.maxccidVale();
       }
       public int EliminarPedidoDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.EliminarPedidoDetalle(pedidoEN);
       }
       public int Eliminar_ccValeDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Eliminar_ccValeDetalle(pedidoEN);
       }
       public double sumaValeDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.sumaValeDetalle(pedidoEN);
       }

       //  --------- Gastos Varios ------------
       public void dropGastoTipo(DropDownList drop)
       {
           drop.ClearSelection();
           drop.Items.Clear();
           drop.AppendDataBoundItems = true;
           drop.Items.Add("<< Eliga Tipo de Gasto >>");
           drop.Items[0].Value = "0";
           pedidoAD = new PedidoADBorrar();
           drop.DataSource = pedidoAD.dropgastoTipo();
           drop.DataTextField = "texto";
           drop.DataValueField = "id";
           drop.DataBind();
       }
       public void dropFAND(DropDownList drop)
       {
           drop.ClearSelection();
           drop.Items.Clear();
           drop.AppendDataBoundItems = true;
           drop.Items.Add("<< Eliga FADN >>");
           drop.Items[0].Value = "0";
           pedidoAD = new PedidoADBorrar();
           drop.DataSource = pedidoAD.dropFAND();
           drop.DataTextField = "texto";
           drop.DataValueField = "id";
           drop.DataBind();
       }
       public void gridEstadoGasto(GridView grid, PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           grid.DataSource = pedidoAD.gridEstadoGasto(pedidoEN);
           grid.DataBind();
       }
       public int Insertar_Gasto(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Insertar_Gasto(pedidoEN);
       }
       public int Insertar_GastoDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Insertar_GastoDetalle(pedidoEN);
       }
       public int MaxidGasto()
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.MaxidGasto();
       }
       public DataTable DatosMGasto(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.DatosMGasto(pedidoEN);
           
       }
       public void gridMGastoD(GridView grid, PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           grid.DataSource = pedidoAD.DatosMGastoDetalle(pedidoEN, 1);
           grid.DataBind();
       }
       public DataTable datosMGastoDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.DatosMGastoDetalle(pedidoEN, 2);

       }
       public int Modificar_GastoDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Modificar_GastoDetalle(pedidoEN);
       }
       public int Modificar_Gasto(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Modificar_Gasto(pedidoEN);
       }

       public void dvPedidoReajuste(DetailsView dv, PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           dv.DataSource = pedidoAD.dvPedidoReajuste(pedidoEN);
           dv.DataBind();
       }
       public void gridPedidoDetalleReajuste(GridView grid, PedidoENBorrar pedidoEN, int tipoDoc)
       {
           pedidoAD = new PedidoADBorrar();
           grid.DataSource = pedidoAD.gridPedidoDetalleReajuste(pedidoEN, tipoDoc);
           grid.DataBind();
       }
       public int Insertar_Reajuste(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Insertar_Reajuste(pedidoEN);
       }
       public int Eliminar_GastoDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Eliminar_GastoDetalle(pedidoEN);
       }
       public void dvGastoaPedido(DetailsView dv, PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           dv.DataSource = pedidoAD.dvGastoaPedido(pedidoEN);
           dv.DataBind();
       }
       public int Insertar_GastoaPedido(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Insertar_GastoaPedido(pedidoEN);
       }

       public int Insertar_GastoaPedidoDetalle(PedidoENBorrar pedidoEN)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Insertar_GastoaPedidoDetalle(pedidoEN);
       }
       public int Insertar_Anulacion(PedidoENBorrar pedidoEN, int tipoDoc)
       {
           pedidoAD = new PedidoADBorrar();
           return pedidoAD.Insertar_Anulacion(pedidoEN, tipoDoc);
       }


    }
}

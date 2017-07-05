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

namespace CapaLN
{
    public class ComprasLN
    {
        ComprasAD comprasAD;
        public DataTable dvPedidoComp(ComprasEN comprasEN)
        {
            comprasAD = new ComprasAD();
            return comprasAD.dvPedidoComp(comprasEN,1);
            //dv.DataSource = comprasAD.dvPedidoComp(comprasEN);
            //dv.DataBind();
        }
        public void dvPedidoComp(DetailsView dv,ComprasEN comprasEN)
        {
            comprasAD = new ComprasAD();
            dv.DataSource = comprasAD.dvPedidoComp(comprasEN,2);
            dv.DataBind();
        }
        public void dvPedidoCompTec(DetailsView dv, ComprasEN comprasEN)
        {
            comprasAD = new ComprasAD();
            dv.DataSource = comprasAD.dvPedidoComp(comprasEN, 3);
            dv.DataBind();
        }
        public void dvPedidoFinanTec(DetailsView dv, ComprasEN comprasEN)
        {
            comprasAD = new ComprasAD();
            dv.DataSource = comprasAD.dvPedidoComp(comprasEN, 5);
            dv.DataBind();
        }
        public void dvccValeCompTec(DetailsView dv, ComprasEN comprasEN)
        {
            comprasAD = new ComprasAD();
            dv.DataSource = comprasAD.dvPedidoComp(comprasEN, 4);
            dv.DataBind();
        }
        public void gridPedidoDetalleComp(GridView grid, ComprasEN comprasEN, int tipoDoc)
        {
            comprasAD = new ComprasAD();
            grid.DataSource = comprasAD.gridPedidoDetalleComp(comprasEN, tipoDoc);
            grid.DataBind();

        }
        public int EstadoIngresoCompras(ComprasEN comprasEN, int tipoDoc)
        {
            comprasAD = new ComprasAD();
            return comprasAD.EstadoIngresoCompras(comprasEN, tipoDoc);
        }
        public int Insertar_IngresoCompras(ComprasEN comprasEN, int tipoDoc)
        {
            comprasAD = new ComprasAD();
            return comprasAD.Insertar_IngresoCompras(comprasEN, tipoDoc);
        }
        public void dropTecnicoCompras(DropDownList drop)
        {
           drop.ClearSelection();
           drop.Items.Clear();
           drop.AppendDataBoundItems = true;
           drop.Items.Add("<< Eliga Tecnico  >>");
           drop.Items[0].Value = "0";
           comprasAD = new ComprasAD();
           drop.DataSource = comprasAD.dropTecnicoCompras();
           drop.DataTextField = "texto";
           drop.DataValueField = "id";
           drop.DataBind();

       }
        public void dropProveedor(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Proveedor  >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("-- Agregar Nuevo --");
            //drop.Items[1].Value = "-1";
            comprasAD = new ComprasAD();
            drop.DataSource = comprasAD.dropProveedor();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        public int Insertar_RechazarCompras(ComprasEN comprasEN, int tipoDoc)
        {
            comprasAD = new ComprasAD();
            return comprasAD.Insertar_RechazarCompras(comprasEN, tipoDoc);
        }
        public int Insertar_AnulacionCompras(ComprasEN comprasEN)
        {
            comprasAD = new ComprasAD();
            return comprasAD.Insertar_Anulacion(comprasEN,1);
        }
        public int Insertar_Tecnico(ComprasEN comprasEN)
        {
            comprasAD = new ComprasAD();
            return comprasAD.Insertar_Tecnico(comprasEN);
        }
        public int Insertar_CostoRealPedido(ComprasEN comprasEN,int op)
        {
            comprasAD = new ComprasAD();
            return comprasAD.Insertar_CostoRealPedido(comprasEN, op);
        }
        public int Insertar_Proveedores(ComprasEN comprasEN)
        {
            comprasAD = new ComprasAD();
            return comprasAD.Insertar_Proveedores(comprasEN);
        }

        public int Insertar_GastoCostoReal(ComprasEN comprasEN, int op)
        {
            comprasAD = new ComprasAD();
            return comprasAD.Insertar_GastoCostoReal(comprasEN, op);
        }
        public int Insertar_CostoRealVale(ComprasEN comprasEN)
        {
            comprasAD = new ComprasAD();
            return comprasAD.Insertar_CostoRealVale(comprasEN);
        }

        public void dropPedidoTecnico(DropDownList drop, ComprasEN comprasEN)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga PEDIDO  >>");
            drop.Items[0].Value = "0";
            comprasAD = new ComprasAD();
            drop.DataSource = comprasAD.dropPedidoTecnico(comprasEN);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        public void gridProveedor(GridView grid)
        {
            comprasAD = new ComprasAD();
            grid.DataSource = comprasAD.gridProveedor();
            grid.DataBind();

        }
    }
}

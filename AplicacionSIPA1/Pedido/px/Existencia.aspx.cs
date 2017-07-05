using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Pedido
{
    public partial class Existencia : System.Web.UI.Page
    {
        PedidoLNBorrar pedidoLN;
        PedidoENBorrar pedidoEN;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                pedidoLN = new PedidoLNBorrar();
                pedidoEN = new PedidoENBorrar();
                pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                pedidoLN.gridEstadoExistencia(gridEstado, pedidoEN);
            }

        }

        protected void gridEstado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            pedidoLN = new PedidoLNBorrar();
            pedidoEN = new PedidoENBorrar();
            gridEstado.PageIndex = e.NewPageIndex;
            pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
            pedidoLN.gridEstadoPedido(gridEstado, pedidoEN);

        }

       
    }
}
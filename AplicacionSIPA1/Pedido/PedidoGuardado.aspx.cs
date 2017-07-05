using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Pedido
{
    public partial class PedidoGuardado : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            

            string pedido = this.Request.QueryString["No"];
            if (pedido != null)
            {
                lblNoPedido.Text = pedido;
                lblMensaje.Text = this.Request.QueryString["msg"];
                lblAccion.Text = this.Request.QueryString["acc"];

                if (lblMensaje.Text == "VALE")
                {
                    btnPedido.Text = "Nuevo Vale";
                    btnPedido.PostBackUrl = "~/Pedido/ValeIngreso.aspx";
                    btnListado.Text = "Listado de VALES";
                    btnListado.PostBackUrl = "~/Pedido/ValeListado.aspx";
                }
                if (lblMensaje.Text == "REQUISICION")
                {
                    btnPedido.Text = "Nueva Requisicion";
                    btnPedido.PostBackUrl = "~/Pedido/PedidoIngreso.aspx";
                    btnListado.Text = "Listado de PEDIDOS";
                    btnListado.PostBackUrl = "~/Pedido/PedidoListado.aspx";
                }

                if (lblMensaje.Text == "GASTO")
                {
                    btnPedido.Text = "Nuevo Gasto";
                    btnPedido.PostBackUrl = "~/Pedido/GastoIngreso.aspx";
                    btnListado.Text = "Listado de GASTOS";
                    btnListado.PostBackUrl = "~/Pedido/GastoListado.aspx";
                }
            }
        }

        protected void btnPedido_Click(object sender, EventArgs e)
        {

        }

        protected void btnListado_Click(object sender, EventArgs e)
        {

        }
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
          
        }
        protected void btnEnvio_Click(object sender, EventArgs e)
        {
          

        }
    }
}
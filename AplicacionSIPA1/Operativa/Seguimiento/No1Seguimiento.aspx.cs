using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Operativa.Seguimiento
{
    public partial class No1Seguimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pedido = this.Request.QueryString["No"];
            if (pedido != null)
            {
                lblNoPedido.Text = pedido;
                lblMensaje.Text = this.Request.QueryString["msg"];
                lblAccion.Text = this.Request.QueryString["acc"];

                if (lblMensaje.Text == "SUBGERENCIA")
                {
                    btnNuevo.PostBackUrl = "~/Operativa/Seguimiento/VoBoN1.aspx";
                }
                if (lblMensaje.Text == "ANALISTA")
                {
                    btnNuevo.PostBackUrl = "~/Operativa/Seguimiento/VoBoN2.aspx";

                }

                if (lblMensaje.Text == "ESTRATEGIA")
                {
                    btnNuevo.PostBackUrl = "~/Operativa/Seguimiento/VoBoN3.aspx";
                }
            }
        }

        protected void btnPedido_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnListado_Click(object sender, EventArgs e)
        {

        }
    }
}
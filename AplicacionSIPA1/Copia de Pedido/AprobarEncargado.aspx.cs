using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Pedido
{
    public partial class AprobarEncargado : System.Web.UI.Page
    {
        PedidoLN pedidoLN;
        PedidoEN pedidoEN;
        double total = 0;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                pedidoLN = new PedidoLN();
                pedidoEN = new PedidoEN();
                pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                pedidoLN.dvPedidoEncargado(dvPedido, pedidoEN);

                pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);

                pedidoLN.gridPedidoDetalleFinan(gridDetalle, pedidoEN, tipoDoc());
                pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                pedidoLN.gridclsSaldoAcPedido(gridSaldos, pedidoEN, tipoDoc());


            }
        }

        protected void dvPedido_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            pedidoLN = new PedidoLN();
            pedidoEN = new PedidoEN();
            dvPedido.PageIndex = e.NewPageIndex;
            pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
            pedidoLN.dvPedidoEncargado(dvPedido, pedidoEN);
            pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);

            pedidoLN.gridPedidoDetalleFinan(gridDetalle, pedidoEN, tipoDoc());
            pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
            pedidoLN.gridclsSaldoAcPedido(gridSaldos, pedidoEN, tipoDoc());
        }

        protected void gridDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double suma = 0;
            pedidoLN = new PedidoLN();
            pedidoEN = new PedidoEN();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                suma = (Convert.ToDouble(e.Row.Cells[5].Text));
                e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma);
                total += suma;
                suma = 0;



            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total";
                e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total);
            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            if (dvPedido.Rows.Count > 0)
            {
                pedidoLN = new PedidoLN();
                pedidoEN = new PedidoEN();
                pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;


                if (pedidoLN.Aprobar_EncargadoP(pedidoEN, tipoDoc()) == 0)
                {


                    pedidoLN.dvPedidoEncargado(dvPedido, pedidoEN);
                    pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                    pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                    pedidoLN.gridPedidoDetalleFinan(gridDetalle, pedidoEN, tipoDoc());
                    pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                    pedidoLN.gridclsSaldoAcPedido(gridSaldos, pedidoEN, tipoDoc());

                    string mensaje;
                    mensaje = "Solicitud Aprobada";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    mostrarMsg(0, mensaje);
                }
                else
                {

                    string mensaje;
                    mensaje = "Error: No fue Posible Aprobar la Solicitud";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    mostrarMsg(1, mensaje);
                }
            }
        }

        private void mostrarMsg(int op, string msg)
        {
            if (op == 0)
            {
                this.lblSuccess.Visible = true;
                this.lblError.Visible = false;
                this.lblSuccess.ForeColor = System.Drawing.Color.White;
                this.lblSuccess.Text = msg;
            }
            if (op == 1)
            {
                this.lblSuccess.Visible = false;
                this.lblError.Visible = true;
                this.lblError.Text = msg;
            }
            if (op == 2)
            {
                this.lblSuccess.Visible = false;
                this.lblError.Visible = false;
                this.lblError.Text = "";
                this.lblSuccess.Text = "";
            }


        }


        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            if (dvPedido.Rows.Count > 0)
            {
                Page.Validate("vacios");
                if (Page.IsValid)
                {
                    pedidoLN = new PedidoLN();
                    pedidoEN = new PedidoEN();
                    pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                    pedidoEN.observacionFinanciero = "Encargado: " + txtMensaje.Text;
                    pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;


                    if (pedidoLN.Rechazar_EncargadoP(pedidoEN, tipoDoc()) == 0)
                    {


                        pedidoLN.dvPedidoEncargado(dvPedido, pedidoEN);
                        pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                        pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);

                        pedidoLN.gridPedidoDetalleFinan(gridDetalle, pedidoEN, tipoDoc());
                        pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                        pedidoLN.gridclsSaldoAcPedido(gridSaldos, pedidoEN, tipoDoc());

                        string mensaje;
                        mensaje = "Solicitud Rechazada con Exito. ";
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                        mostrarMsg(0, mensaje);
                        txtMensaje.Text = String.Empty;
                    }
                    else
                    {

                        string mensaje;
                        mensaje = "Error: No fue Posible Rechazar la Solicitud";
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                        mostrarMsg(1, mensaje);
                    }

                }
            }
        }



        protected void txtMensaje_TextChanged(object sender, EventArgs e)
        {

        }

        private int tipoDoc()
        {
            int tipo = 0;
            if (dvPedido.Rows.Count > 0)
            {

                switch (dvPedido.Rows[1].Cells[1].Text)
                {
                    case "PEDIDO": tipo = 1;
                        break;
                    case "VALE": tipo = 2;
                        break;
                    case "GASTO": tipo = 3;
                        break;
                }
            }
            return tipo;
        }

        protected void gridDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}

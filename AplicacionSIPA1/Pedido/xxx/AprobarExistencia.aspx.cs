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
    public partial class AprobarExistencia : System.Web.UI.Page
    {
        PedidoLNBorrar pedidoLN;
        PedidoENBorrar pedidoEN;
        double total = 0;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                pedidoLN = new PedidoLNBorrar();
                pedidoEN = new PedidoENBorrar();
                pedidoLN.dvPedidoExistencia(dvPedido);

                pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                pedidoLN.gridPedidoDetalleFinan(gridDetalle, pedidoEN,1);
                pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
            


            }
        }

        protected void dvPedido_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            pedidoLN = new PedidoLNBorrar();
            pedidoEN = new PedidoENBorrar();
            dvPedido.PageIndex = e.NewPageIndex;
            pedidoLN.dvPedidoExistencia(dvPedido);
            pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
            pedidoLN.gridPedidoDetalleFinan(gridDetalle, pedidoEN,1);
            pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
            
        }

        protected void gridDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double suma = 0;
            pedidoLN = new PedidoLNBorrar();
            pedidoEN = new PedidoENBorrar();
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
                pedidoLN = new PedidoLNBorrar();
                pedidoEN = new PedidoENBorrar();
                pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                if (pedidoLN.Rechazar_ExistenciaP(pedidoEN) == 0)
                {

                    pedidoLN.dvPedidoExistencia(dvPedido);
                    pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                    pedidoLN.gridPedidoDetalleFinan(gridDetalle, pedidoEN,1);
                    pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
            

                    string mensaje;
                    mensaje = "No Existencia Exitosa";
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
                    pedidoLN = new PedidoLNBorrar();
                    pedidoEN = new PedidoENBorrar();
                    pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                    pedidoEN.observacionFinanciero = txtMensaje.Text;
                    pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                    if (pedidoLN.Aprobar_ExistenciaP(pedidoEN) == 0)
                    {

                        pedidoLN.dvPedidoExistencia(dvPedido);
                        pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                        pedidoLN.gridPedidoDetalleFinan(gridDetalle, pedidoEN,1);
                        pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
            

                        string mensaje;
                        mensaje = "Aprobacion de Existencia Exitosa. ";
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




    }
}

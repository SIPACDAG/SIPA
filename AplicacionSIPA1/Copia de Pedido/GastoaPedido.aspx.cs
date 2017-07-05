using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Pedido
{
    public partial class GastoaPedido : System.Web.UI.Page
    {
        PedidoLN pedidoLN;
        PedidoEN pedidoEN;
        double total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                int NoGasto = PreviousPage.NoGasto;
                lblidGasto.Text = Convert.ToString(NoGasto);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                pedidoLN = new PedidoLN();
                pedidoEN = new PedidoEN();
                pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                pedidoEN.idGasto = Convert.ToInt32(lblidGasto.Text);
                pedidoLN.dvGastoaPedido(dvPedido, pedidoEN);

                pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                pedidoLN.gridPedidoDetalleReajuste(gridDetalle, pedidoEN, tipoDoc());

            }
        }

        protected void gridDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            pedidoLN = new PedidoLN();
            pedidoEN = new PedidoEN();
            double suma = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                suma = (Convert.ToDouble(e.Row.Cells[5].Text));
                e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma);
                total += suma;
                suma = 0;


                DropDownList dropPac = (DropDownList)e.Row.FindControl("dropPac");

                pedidoEN.idAccion = Convert.ToInt32(dvPedido.Rows[3].Cells[1].Text);
                pedidoLN.dropNoPacAccion(dropPac, pedidoEN);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total";
                e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total);
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

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            this.Page.Validate("vacios");
            if (this.Page.IsValid)
            {
                int contarPac = 0;
                for (int i = 0; i <= gridDetalle.Rows.Count - 1; i++)
                 {
                     GridViewRow fila = gridDetalle.Rows[i];
                     DropDownList dropPc = new DropDownList();
                     dropPc = (DropDownList)gridDetalle.Rows[i].FindControl("dropPac");

                     if (Convert.ToInt32(dropPc.SelectedValue) > 0)
                     {
                     contarPac += 1;
                     }
                 }

                if (contarPac == gridDetalle.Rows.Count)
                {
                    pedidoLN = new PedidoLN();
                    pedidoEN = new PedidoEN();
                    int maxidpedido = 0;
                    pedidoEN.idGasto = Convert.ToInt32(lblidGasto.Text);
                    pedidoLN.Insertar_GastoaPedido(pedidoEN);
                    maxidpedido = pedidoLN.maxidPedido();
                    for (int i = 0; i <= gridDetalle.Rows.Count - 1; i++)
                    {
                        GridViewRow filaGrid = gridDetalle.Rows[i];
                        int Nopac = 0;
                        Nopac = Convert.ToInt32(((DropDownList)filaGrid.Cells[7].FindControl("dropPac")).SelectedValue);

                        pedidoEN.idGastoDetalle = Convert.ToInt32(filaGrid.Cells[0].Text);
                        pedidoEN.idPac = Nopac;
                        pedidoEN.idPedido = maxidpedido;
                        pedidoLN.Insertar_GastoaPedidoDetalle(pedidoEN);

                    }
                    pedidoEN.idPedido = Convert.ToInt32(lblidGasto.Text);
                    pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                    pedidoEN.observacionFinanciero = "Sistema:" + "Para Crear Pedido No:" + Convert.ToString(maxidpedido);
                    pedidoLN.Insertar_Anulacion(pedidoEN, 3);
                    Response.Redirect("NoPedido.aspx?No=" + maxidpedido + "&msg=Pedido");
                 
                }
                else
                {
                    string mensaje;
                    mensaje = "Seleccione Pac ";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);

                }

                
            }

        }
    }
}
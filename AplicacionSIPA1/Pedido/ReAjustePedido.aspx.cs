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
    public partial class ReAjustePedido : System.Web.UI.Page
    {
        PedidoLNBorrar pedidoLN;
        PedidoENBorrar pedidoEN;
        double total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                int NoPedido = PreviousPage.NoPedido;
                lblidPedido.Text = Convert.ToString(NoPedido);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                pedidoLN = new PedidoLNBorrar();
                pedidoEN = new PedidoENBorrar();
                pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                pedidoEN.idPedido = Convert.ToInt32(lblidPedido.Text);
                pedidoLN.dvPedidoReajuste(dvPedido, pedidoEN);

                pedidoEN.idPedido = Convert.ToInt32(dvPedido.SelectedValue);
                pedidoLN.gridPedidoDetalleReajuste(gridDetalle, pedidoEN, tipoDoc());
                


            }
        }

        protected void gridDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double suma = 0;
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
                pedidoLN = new PedidoLNBorrar();
                pedidoEN = new PedidoENBorrar();

                
                for (int i = 0; i <= gridDetalle.Rows.Count - 1; i++)
                {
                    GridViewRow filaGrid = gridDetalle.Rows[i];
                    double costoReal = 0;
                    costoReal = Convert.ToDouble(((TextBox)filaGrid.Cells[7].FindControl("txtCostoReal")).Text);
                     
                    
                    pedidoEN.idpedidoDetalle = Convert.ToInt32(filaGrid.Cells[0].Text);
                    pedidoEN.reajuste = costoReal;
                    pedidoEN.idPedido = Convert.ToInt32(lblidPedido.Text);
                    pedidoLN.Insertar_Reajuste(pedidoEN);

                }
                Response.Redirect("NoPedido.aspx?No=" + Convert.ToInt32(lblidPedido.Text) + "&msg=PEDIDO");
            }

        }
        }
    }
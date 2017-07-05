using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using CapaLN;
using CapaEN;
namespace AplicacionSIPA1.Reporteria
{
    public partial class saldosUnidadDetalle : System.Web.UI.Page
    {
        PedidoLNBorrar pedidoLN;
        PedidoENBorrar pedidoEN;
        double totalc, totalcr=0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                int idop = PreviousPage.idop;
                lblop.Text = Convert.ToString(idop);
                int idP = PreviousPage.idP;
                lblidP.Text = Convert.ToString(idP);
            }

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                try
                {
                    pedidoEN = new PedidoENBorrar();
                    pedidoLN = new PedidoLNBorrar();
                    pedidoEN.idPedido = Convert.ToInt32(lblidP.Text);
                    pedidoLN.gridPedidoVerSaldos(gridPedidos, pedidoEN, Convert.ToInt32(lblop.Text));
                }
                catch (Exception ex)
                {

                    //Label1.Text = ex.Message;
                }
                
            }
        }

        protected void gridDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double sumac,sumacr = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                sumac = (Convert.ToDouble(e.Row.Cells[5].Text));
                e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumac);
                totalc += sumac;
                sumac = 0;


                sumacr = (Convert.ToDouble(e.Row.Cells[6].Text));
                e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumacr);
                totalcr += sumacr;
                sumacr = 0;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total";
                e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalc);
                e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalcr);
                totalc = 0;
                totalcr = 0;
            }
        }

        protected void gridPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            pedidoEN = new PedidoENBorrar();
            pedidoLN = new PedidoLNBorrar();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int id = Convert.ToInt32(gridPedidos.DataKeys[e.Row.RowIndex].Value);

                int op = 0;

                switch (e.Row.Cells[1].Text)
                {
                    case "PEDIDO": op = 1;
                        break;
                    case "VALE": op = 2;
                        break;
                    case "GASTO": op = 3;
                        break;
                }

                GridView gridDetalle = (GridView)e.Row.FindControl("gridDetalle");
                pedidoEN.idPedido=id;

                pedidoLN.gridPedidoDetalleVerSaldos(gridDetalle, pedidoEN, op);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                
            }
        }

        protected void gridPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

using CapaLN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Pac
{
    public partial class ModificacionPac : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlanEstrategicoLN planEstrategicoLN = new PlanEstrategicoLN();
            PlanOperativoLN planOperativoLN = new PlanOperativoLN();
            PedidosLN pedidoLN = new PedidosLN();
            string usuario = Session["Usuario"].ToString().ToLower();
            if (!IsPostBack)
            {
                try
                {
                    int anioActual = (DateTime.Now.Year);

                    planEstrategicoLN.DdlAniosPlan(ddlAnio, 2016, 2020);
                    ListItem item = ddlAnio.Items.FindByValue(anioActual.ToString());
                    if (item != null)
                        ddlAnio.SelectedValue = anioActual.ToString();

                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlUnidades(ddlUnidad, usuario);
                    pedidoLN = new PedidosLN();
                    int unidad = int.Parse(ddlUnidad.SelectedValue);
                    //if (unidad > 0)
                    //{
                    //    dvPedido.DataSource = pedidoLN.PedidoPACItem(unidad);
                    //    dvPedido.DataBind();
                        
                    //    var detalle = pedidoLN.PedidoDetallePac(unidad, int.Parse(dvPedido.Rows[0].Cells[1].Text));
                    //    for (int i = 0; i < detalle.Tables[0].Rows.Count; i++)
                    //    {
                    //        int fil = i + 1;
                    //        tabla_pedido.Rows.Add(NewRow());
                    //        tabla_pedido.Rows[fil].Cells.Add(NewCell());
                    //        tabla_pedido.Rows[fil].Cells.Add(NewCell());
                    //        tabla_pedido.Rows[fil].Cells.Add(NewCell());
                    //        tabla_pedido.Rows[fil].Cells.Add(NewCell());
                    //        tabla_pedido.Rows[fil].Cells.Add(NewCell());
                    //        tabla_pedido.Rows[fil].Cells.Add(NewCell());
                    //        tabla_pedido.Rows[fil].Cells.Add(NewCell());
                    //        tabla_pedido.Rows[fil].Cells.Add(NewCell());

                    //        tabla_pedido.Rows[fil].Cells[0].Text = detalle.Tables[0].Rows[i]["Solicitud"].ToString();
                    //        tabla_pedido.Rows[fil].Cells[1].Text = detalle.Tables[0].Rows[i]["Descripcion"].ToString();
                    //        tabla_pedido.Rows[fil].Cells[2].Text = detalle.Tables[0].Rows[i]["Monto"].ToString();
                    //        tabla_pedido.Rows[fil].Cells[3].Text = detalle.Tables[0].Rows[i]["PAC"].ToString();
                    //        tabla_pedido.Rows[fil].Cells[4].Text = detalle.Tables[0].Rows[i]["No. Renglon PAC"].ToString();
                    //        tabla_pedido.Rows[fil].Cells[5].Text = detalle.Tables[0].Rows[i]["No. Renglon Ppto"].ToString();
                    //        tabla_pedido.Rows[fil].Cells[6].Controls.Add(DdlRenglones(sender,e));
                    //        tabla_pedido.Rows[fil].Cells[7].Controls.Add(BotonEditar(detalle.Tables[0].Rows[i]["Monto"].ToString()));
                    //        tabla_pedido.Rows[fil].Cells[7].Controls.Add(BotonGuardar(detalle.Tables[0].Rows[i]["PAC"].ToString()));
                    //    }
                    //}

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private DropDownList DdlRenglones(object sender, EventArgs e)
        {
            DropDownList drop = new DropDownList();
            PacLN pac = new PacLN();
            //pac.ddlPacAccion(drop, int.Parse(ddlUnidad.SelectedValue), int.Parse(dvPedido.Rows[4].Cells[1].Text));
            drop.CssClass = "form-control";
            ///drop.SelectedIndexChanged = GuardarPAC(sender,e);
            return drop;
        }

        public void GuardarPAC(object sender, EventArgs e)
        {

        }

        private ImageButton BotonEditar(string id)
        {
            ImageButton button = new ImageButton();
            button.ImageUrl = "~/img/24_bits/edit.png";
            button.PostBackUrl = "IngresarPac.aspx?id=" + Session["Usuario"].ToString() + "&accion=" + dvPedido.Rows[5].Cells[1].Text;
            return button;
        }

        private ImageButton BotonGuardar(string id)
        {
            ImageButton button = new ImageButton();
            button.ImageUrl = "~/img/24_bits/save.png";
            button.PostBackUrl = "GuardarMoPac.aspx?id=" + Session["Usuario"].ToString() + "&accion=" + dvPedido.Rows[5].Cells[1].Text;
            return button;
        }

        private TableHeaderCell NewCellHeader()
        {
            TableHeaderCell cell = new TableHeaderCell();

            return cell;
        }

        private TableCell NewCell()
        {
            TableCell cell = new TableCell();

            return cell;
        }
        private TableRow NewRow()
        {
            TableRow tr = new TableRow();

            return tr;
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void gvPedido_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
           
        }

        protected void gvPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string monto = gvPedido.SelectedDataKey["monto"].ToString();
            Response.Redirect("IngresarPac.aspx?idUnidad=" + ddlUnidad.SelectedValue + "&accion=" + dvPedido.Rows[5].Cells[1].Text);
        }
    }
}
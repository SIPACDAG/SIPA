using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using CapaEN;
using System.Data;
using System.Globalization;

namespace AplicacionSIPA1.Pedido
{
    public partial class ModificarPedido : System.Web.UI.Page
    {
        PedidoLN pedidoLN;
        PedidoEN pedidoEN;
        double total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                int NoPedido =
                  PreviousPage.NoPedido;
                lblidPedido.Text = Convert.ToString(NoPedido);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                pedidoLN = new PedidoLN();
                pedidoEN = new PedidoEN();

                pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                pedidoLN.dropAccion(dropAccion, pedidoEN);
                pedidoLN.dropEmpleado(dropSolicitante, pedidoEN);
                pedidoLN.dropJefeDireccion(dropJefeDir, pedidoEN);
                pedidoLN.dropTipoPedido(dropTipoPedido);
                pedidoLN.dropGastoTipo(dropTipoGasto);
                pedidoLN.dropFAND(dropFand);
                
                ViewState["idPedido"] = lblidPedido.Text;
                pedidoEN.idPedido= Convert.ToInt32(ViewState["idPedido"]);
                DataTable dtpedido;
                dtpedido = pedidoLN.datosMPedido(pedidoEN);
                dropAccion.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idAccion"]);
                pedidoEN.idAccion = Convert.ToInt32(dropAccion.SelectedValue);
                pedidoLN.dropNoPacAccion(dropNoPac, pedidoEN);
                dropSolicitante.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idSolicitante"]);
                dropJefeDir.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idJefeDireccion"]);

                dropFand.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idFand"]);
                if (dropFand.SelectedValue == "0")
                {
                    dropFand.Enabled = false;
                    dropTipoGasto.SelectedValue = "1";
                }
                else
                {
                    dropFand.Enabled = true;
                    dropTipoGasto.SelectedValue = "2";
                }
                
                txtJustificacion.Text = Convert.ToString(dtpedido.Rows[0]["Justificacion"]);
                dropTipoPedido.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idTipoPedido"]);
                pedidoEN.idTipoPedido = Convert.ToInt16(dropTipoPedido.SelectedValue);
                pedidoLN.dropUnidadMedida(dropUnidadMedida, pedidoEN);

                pedidoEN.idPedido = Convert.ToInt32(ViewState["idPedido"]);
                pedidoLN.griMPedidoD(gridArticulos, pedidoEN);
                ViewState["idDetalleP"] = 0;
         
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            

            try
            {
                
                this.Page.Validate("vaciosD");

                if (this.Page.IsValid)
                {
                    if (Convert.ToInt16(dropUnidadMedida.SelectedValue) > 0 && Convert.ToInt16(dropNoPac.SelectedValue) > 0)
                    {

                        


                            pedidoLN = new PedidoLN();
                            pedidoEN = new PedidoEN();

                            pedidoEN.cantidad = Convert.ToInt32(txtCantidad.Text);
                            pedidoEN.idPac = Convert.ToInt32(dropNoPac.SelectedValue);
                            pedidoEN.idUnidadMedida = Convert.ToInt16(dropUnidadMedida.SelectedValue);
                            pedidoEN.descripcion = txtDescripcion.Text;
                            pedidoEN.costoEstimado = Convert.ToDouble(txtCosto.Text);
                            pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;


                            double saldoPac = 0;
                            saldoPac = pedidoLN.saldoPacPac(pedidoEN) - (Convert.ToDouble(txtCosto.Text));
                            if (Convert.ToInt32(ViewState["idDetalleP"]) > 0)
                            {
                                
                                

                                if (saldoPac >= 0)
                                {
                                pedidoEN.idpedidoDetalle = Convert.ToInt32(ViewState["idDetalleP"]);
                                pedidoLN.modificarPedidoDetalle(pedidoEN);
                                string mensaje = "Modificacion Exitosa";
                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                }
                                else
                                {
                                    string mensaje = "";
                                    mensaje = "Saldo Insufiente en el Pac:" + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldoPac);
                                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                }

                            }
                            else
                            {
                                
                                pedidoEN.idPedido = Convert.ToInt32(ViewState["idPedido"]);
                                int contarPac = pedidoLN.valNoPacPedidoD(pedidoEN);
                                if (saldoPac >= 0)
                                {
                                
                                pedidoLN.insertarPedidoDetalle(pedidoEN);
                                string mensaje = "Ingreso Exitoso";
                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                }
                                else
                                {
                                    string mensaje = "";
                                    if (saldoPac < 0)
                                    {

                                        mensaje = "Saldo Insufiente en el Pac:" + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldoPac);

                                    }
                                    
                                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);

                                }
                            }
                            ViewState["idDetalleP"] = 0;

                            txtCantidad.Text = String.Empty;
                            txtCosto.Text = String.Empty;
                            txtDescripcion.Text = String.Empty;
                            dropNoPac.SelectedValue = "0";
                            lblSaldoPac.Text = "0";
                            dropAccion.Enabled = false;
                            pedidoEN.idPedido = Convert.ToInt32(ViewState["idPedido"]);
                            pedidoLN.griMPedidoD(gridArticulos, pedidoEN);
                            btnAgregar.Text = "Agregar";

                        
                        
                    }
                    else
                    {
                        string mensaje = "";
                        if (Convert.ToInt16(dropUnidadMedida.SelectedValue) <= 0)
                        {
                            mensaje = "Seleccione la Unidad de Medida (Previamente seleccionado el Tipo Pedido)";
                        }
                        if (Convert.ToInt16(dropNoPac.SelectedValue) <= 0)
                        {
                            mensaje = "Seleccione El No de Pac";
                        }
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    }
                }
            }
            catch
            {

            }
            
        }

        protected void dropTipoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Page.Validate("vacios");

                if (this.Page.IsValid)
                {
                    if (Convert.ToInt32(dropAccion.SelectedValue) > 0)
                    {
                        if (Convert.ToInt32(dropSolicitante.SelectedValue) > 0)
                        {
                            if (Convert.ToInt32(dropJefeDir.SelectedValue) > 0)
                            {
                                if (Convert.ToInt32(dropTipoPedido.SelectedValue) > 0)
                                {
                                    if (Convert.ToInt32(dropTipoGasto.SelectedValue) > 0)
                                    {
                                      if ((Convert.ToInt32(dropTipoGasto.SelectedValue) == 2 && Convert.ToInt32(dropFand.SelectedValue) > 0) || Convert.ToInt32(dropTipoGasto.SelectedValue) == 1)
                                       {
                                    if (gridArticulos.Rows.Count > 0)
                                    {
         
                                        pedidoLN = new PedidoLN();
                                        pedidoEN = new PedidoEN();

                                        pedidoEN.idPedido = Convert.ToInt32(ViewState["idPedido"]);
                                        //pedidoEN.idAccion = Convert.ToInt32(dropAccion.SelectedValue);
                                        //pedidoEN.idTipoPedido = Convert.ToInt32(dropTipoPedido.SelectedValue);
                                        pedidoEN.idSolicitante = Convert.ToInt32(dropSolicitante.SelectedValue);
                                        pedidoEN.idJefeDireccion = Convert.ToInt32(dropJefeDir.SelectedValue);
                                        pedidoEN.Justificacion = txtJustificacion.Text;
                                        pedidoEN.idFand = Convert.ToInt32(dropFand.SelectedValue);
                                        pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                                        
                                        pedidoLN.modificarPedido(pedidoEN);

                                        if (pedidoLN.modificarPedido(pedidoEN) == 0)
                                        {
                                            Response.Redirect("NoPedido.aspx?No=" + pedidoEN.idPedido + "&msg=PEDIDO");

                                        }
                                        else
                                        {
                                            string mensaje;
                                            mensaje = "<< El Pedido No se ha Podido Modificar >>";
                                            mostrarMsg(1, mensaje);
                                            ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                        }
                                    }
                                    else
                                    {
                                        string mensaje;
                                        mensaje = "Debe de Ingresar Articulos para realizar el Pedido.";
                                        mostrarMsg(1, mensaje);
                                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                    }
                                    }
                                   else
                                   {
                                       string mensaje;
                                       mensaje = "Selecciona  la federacion";
                                       mostrarMsg(1, mensaje);
                                       ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                   }

                               }
                                else
                                {
                                    string mensaje;
                                    mensaje = "Selecciona  si el gasto es para el COG o una FADN.";
                                    mostrarMsg(1, mensaje);
                                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                }

                                }
                                else
                                {
                                    string mensaje;
                                    mensaje = "Selecciona el Tipo de Pedido.";
                                    mostrarMsg(1, mensaje);
                                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                }

                            }
                            else
                            {
                                string mensaje;
                                mensaje = "Selecciona el Jefe de Direccion.";
                                mostrarMsg(1, mensaje);
                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                            }

                        }
                        else
                        {
                            string mensaje;
                            mensaje = "Selecciona el Solicitante.";
                            mostrarMsg(1, mensaje);
                            ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                        }

                    }
                    else
                    {
                        string mensaje;
                        mensaje = "Selecciona el No. de Accion.";
                        mostrarMsg(1, mensaje);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    }
                }
            }
            catch
            {

            }
        }
        protected void gridArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idPD = 0;
            idPD = Convert.ToInt32(gridArticulos.Rows[e.RowIndex].Cells[2].Text);
            if (idPD > 0 && gridArticulos.Rows.Count > 1)
            {
                pedidoLN = new PedidoLN();
                pedidoEN = new PedidoEN();

                pedidoEN.idpedidoDetalle = idPD;
                pedidoLN.EliminarPedidoDetalle(pedidoEN);
                pedidoEN.idPedido = Convert.ToInt32(ViewState["idPedido"]);
                pedidoLN.griMPedidoD(gridArticulos, pedidoEN);

                ViewState["idDetalleP"] = 0;

                txtCantidad.Text = String.Empty;
                txtCosto.Text = String.Empty;
                dropNoPac.SelectedValue = "0";
                lblSaldoPac.Text = "0";
                dropAccion.Enabled = false;
                btnAgregar.Text = "Agregar";
            }
            else
            { 
            string    mensaje = "No es Posible Dejar el Pedido Sin Articulos, ingrese uno antes o Modifique el Actual";
            ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);

            }

        }

        protected void gridArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pedidoLN = new PedidoLN();
            pedidoEN = new PedidoEN();
            DataTable dtpedido;
            ViewState["idDetalleP"] = Convert.ToInt32(gridArticulos.SelectedValue);
            pedidoEN.idPedido = Convert.ToInt32(ViewState["idDetalleP"]);
            dtpedido = pedidoLN.datosMPedidoD(pedidoEN);
            dropNoPac.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idPac"]);
            txtCantidad.Text = Convert.ToString(dtpedido.Rows[0]["cantidad"]);
            dropUnidadMedida.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idUnidadMedida"]);
            txtDescripcion.Text = Convert.ToString(dtpedido.Rows[0]["Descripcion"]);
            txtCosto.Text = Convert.ToString(dtpedido.Rows[0]["Costo"]);
            pedidoEN.idPac = Convert.ToInt32(dropNoPac.SelectedValue);
            lblSaldoPac.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pedidoLN.saldoPacPac(pedidoEN));
            btnAgregar.Text = "Modificar";
             
        }

        protected void gridArticulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double suma = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                suma = (Convert.ToDouble(e.Row.Cells[7].Text));
                e.Row.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma);
                total += suma;
                suma = 0;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[6].Text = "Total";
                e.Row.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total);
            }

        }

        protected void dropNoPac_SelectedIndexChanged(object sender, EventArgs e)
        {
            pedidoLN = new PedidoLN();
            pedidoEN = new PedidoEN();

            pedidoEN.idPac = Convert.ToInt32(dropNoPac.SelectedValue);
            lblSaldoPac.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pedidoLN.saldoPacPac(pedidoEN)); 
        }

        protected void dropTipoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(dropTipoGasto.SelectedValue) == 2)
            { dropFand.Enabled = true; }
            else
            { dropFand.Enabled = false; dropFand.SelectedValue = "0"; }        
        }



    }
}
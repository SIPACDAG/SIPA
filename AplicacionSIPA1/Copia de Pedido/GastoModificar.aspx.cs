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
    public partial class GastoModificar : System.Web.UI.Page
    {
        PedidoLN pedidoLN;
        PedidoEN pedidoEN;
        double total = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                int NoGasto =
                  PreviousPage.NoGasto;
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
                pedidoLN.dropAccion(dropAccion, pedidoEN);
                pedidoLN.dropEmpleado(dropSolicitante, pedidoEN);
                pedidoLN.dropJefeDireccion(dropJefeDir, pedidoEN);
                pedidoLN.dropGastoTipo(dropTipoGasto);
                pedidoLN.dropFAND(dropFand);

                ViewState["idGasto"] = lblidGasto.Text;
                pedidoEN.idGasto = Convert.ToInt32(ViewState["idGasto"]);
                DataTable dtpedido;
                dtpedido = pedidoLN.DatosMGasto(pedidoEN);
                dropAccion.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idAccion"]);
                pedidoEN.idAccion = Convert.ToInt32(dropAccion.SelectedValue);

                dropSolicitante.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idSolicitante"]);
                dropJefeDir.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idJefeDireccion"]);
                dropTipoGasto.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idTipoGasto"]);

                if (Convert.ToInt16(dropTipoGasto.SelectedValue) == 2)
                {
                    dropFand.Enabled = true;
                    dropFand.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idFAND"]);
                }
                txtJustificacion.Text = Convert.ToString(dtpedido.Rows[0]["Justificacion"]);


                pedidoEN.idGasto = Convert.ToInt32(ViewState["idGasto"]);
                pedidoLN.gridMGastoD(gridArticulos, pedidoEN);
                ViewState["idDetalleG"] = 0;
                ViewState["costoAnterior"] = 0;



            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.Page.Validate("vaciosD");

                if (this.Page.IsValid)
                {


                    pedidoLN = new PedidoLN();
                    pedidoEN = new PedidoEN();
                    if (Convert.ToInt32(ViewState["idDetalleG"]) > 0)
                    {
                        
                        pedidoEN.idGasto = Convert.ToInt32(ViewState["idGasto"]);
                        pedidoEN.idGastoDetalle = Convert.ToInt32(ViewState["idDetalleG"]);
                        pedidoEN.cantidad = Convert.ToInt32(txtCantidad.Text);
                        pedidoEN.descripcion = txtDescripcion.Text;
                        pedidoEN.costoEstimado = Convert.ToDouble(txtCosto.Text);

                            if (pedidoLN.Modificar_GastoDetalle(pedidoEN) == 0)
                            {
                                string mensaje = "Modificacion Exitosa";
                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                            }
                            else
                            {
                                string mensaje = "XXXXX Error en la Modificarion XXXXXX";
                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                            }
                        
                    }
                    if (Convert.ToInt32(ViewState["idDetalleG"]) == 0)
                    {
                        
                        pedidoEN.idGasto= Convert.ToInt32(ViewState["idGasto"]);
                        pedidoEN.cantidad = Convert.ToInt32(txtCantidad.Text);
                        pedidoEN.descripcion = txtDescripcion.Text;
                        pedidoEN.costoEstimado = Convert.ToDouble(txtCosto.Text);

                            if (pedidoLN.Insertar_GastoDetalle(pedidoEN) == 0)
                            {
                                string mensaje = "Insercion Exitosa";
                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                            }
                            else
                            {
                                string mensaje = "XXXXX Error en la Insercion XXXXXX";
                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                            }
                        
                    }
                    ViewState["idDetalleG"] = 0;
                    ViewState["costoAnterior"] = 0;
                    txtCantidad.Text = String.Empty;
                    txtCosto.Text = String.Empty;
                    txtDescripcion.Text = String.Empty;
                    dropAccion.Enabled = false;
                    pedidoEN.idGasto = Convert.ToInt32(ViewState["idGasto"]);
                    pedidoLN.gridMGastoD(gridArticulos, pedidoEN);
                    btnAgregar.Text = "Agregar";

               }
            }
            catch
            {

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Page.Validate("vacios");

                if (this.Page.IsValid)
                {
                    mostrarMsg(2, "");
                    if (Convert.ToInt32(dropAccion.SelectedValue) > 0)
                    {
                        if (Convert.ToInt32(dropSolicitante.SelectedValue) > 0)
                        {
                            if (Convert.ToInt32(dropJefeDir.SelectedValue) > 0)
                            {
                                if (Convert.ToInt32(dropTipoGasto.SelectedValue ) > 0)
                               {
                                   if ((Convert.ToInt32(dropTipoGasto.SelectedValue) == 2 && Convert.ToInt32(dropFand.SelectedValue) > 0) || Convert.ToInt32(dropTipoGasto.SelectedValue)==1)
                                 {
                               
                                if (gridArticulos.Rows.Count > 0)
                                {

                                    pedidoLN = new PedidoLN();
                                    pedidoEN = new PedidoEN();

                                    pedidoEN.idGasto = Convert.ToInt32(ViewState["idGasto"]);
                                    pedidoEN.idAccion = Convert.ToInt32(dropAccion.SelectedValue);
                                    pedidoEN.idGastoTipo = Convert.ToInt32(dropTipoGasto.SelectedValue);
                                    pedidoEN.idSolicitante = Convert.ToInt32(dropSolicitante.SelectedValue);
                                    pedidoEN.idJefeDireccion = Convert.ToInt32(dropJefeDir.SelectedValue);
                                    pedidoEN.Justificacion = txtJustificacion.Text;
                                    pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                                    pedidoEN.idFand = Convert.ToInt32(dropFand.SelectedValue);
                                    
                                    if (pedidoLN.Modificar_Gasto(pedidoEN) == 0)
                                    {
                                        Response.Redirect("NoPedido.aspx?No=" + pedidoEN.idGasto + "&msg=GASTO");

                                    }
                                    else
                                    {
                                        string mensaje;
                                        mensaje = "XXX El GASTO No se ha Generado XXX";
                                        mostrarMsg(1, mensaje);
                                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                    }


                                }
                                else
                                {
                                    string mensaje;
                                    mensaje = "Debe de Ingresar Articulos para realizar el Gasto.";
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
                                mensaje = "Selecciona el Jefe Inmediato.";
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
            catch (Exception ex)
            {
                
                mostrarMsg(1, ex.Message);

            }


        }

        protected void gridArticulos_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gridArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idGD = 0;
            idGD = Convert.ToInt32(gridArticulos.Rows[e.RowIndex].Cells[2].Text);
            if (idGD > 0 && gridArticulos.Rows.Count > 1)
            {
                pedidoLN = new PedidoLN();
                pedidoEN = new PedidoEN();

                pedidoEN.idGastoDetalle = idGD;
                pedidoLN.Eliminar_GastoDetalle(pedidoEN);
                pedidoEN.idGasto = Convert.ToInt32(ViewState["idGasto"]);
                pedidoLN.gridMGastoD(gridArticulos, pedidoEN);
                ViewState["idDetalleG"] = 0;
                txtCantidad.Text = String.Empty;
                txtCosto.Text = String.Empty;
                dropAccion.Enabled = false;
                btnAgregar.Text = "Agregar";
            }
            else
            {
                string mensaje = "No es Posible Dejar el Pedido Sin Articulos, ingrese uno antes o Modifique el Actual";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);

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

        protected void gridArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pedidoLN = new PedidoLN();
            pedidoEN = new PedidoEN();
            DataTable dtpedido;
            ViewState["idDetalleG"] = Convert.ToInt32(gridArticulos.SelectedValue);
            pedidoEN.idGasto = Convert.ToInt32(ViewState["idDetalleG"]);
            dtpedido = pedidoLN.datosMGastoDetalle(pedidoEN);

            txtCantidad.Text = Convert.ToString(dtpedido.Rows[0]["cantidad"]);
            txtCosto.Text = Convert.ToString(dtpedido.Rows[0]["Costo"]);
            txtDescripcion.Text = Convert.ToString(dtpedido.Rows[0]["Descripcion"]);
            ViewState["costoAnterior"] = txtCosto.Text;
            btnAgregar.Text = "Modificar";
 
        }

        protected void dropTipoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(dropTipoGasto.SelectedValue) == 2  )
            { dropFand.Enabled = true; }        
            else
            { dropFand.Enabled = false; dropFand.SelectedValue = "0"; }        
                
        }

    }

    }

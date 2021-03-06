﻿using System;
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
    public partial class ccModificarVale : System.Web.UI.Page
    {
        PedidoLNBorrar pedidoLN;
        PedidoENBorrar pedidoEN;
        double total = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                int NoVale =
                  PreviousPage.NoVale;
                lblidVale.Text = Convert.ToString(NoVale);
            }
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                pedidoLN = new PedidoLNBorrar();
                pedidoEN = new PedidoENBorrar();

                pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                pedidoLN.dropAccion(dropAccion, pedidoEN);
                pedidoLN.dropEmpleado(dropSolicitante, pedidoEN, 0);
                pedidoLN.dropJefeDireccion(dropJefeDir,pedidoEN);

                ViewState["idVale"] = lblidVale.Text;
                pedidoEN.ccidVale = Convert.ToInt32(ViewState["idVale"]);
                DataTable dtpedido;
                dtpedido = pedidoLN.datosMVale(pedidoEN);
                dropAccion.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idAccion"]);
                pedidoEN.idAccion = Convert.ToInt32(dropAccion.SelectedValue);
                
                dropSolicitante.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idSolicitante"]);
                dropJefeDir.SelectedValue = Convert.ToString(dtpedido.Rows[0]["idJefeDireccion"]);

                txtJustificacion.Text = Convert.ToString(dtpedido.Rows[0]["Justificacion"]);


                pedidoEN.ccidVale = Convert.ToInt32(ViewState["idVale"]);
                pedidoLN.gridMValeD(gridArticulos, pedidoEN);
                ViewState["idDetalleV"] = 0;
                ViewState["costoAnterior"] = 0;


        
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                mostrarMsg(2, "");
                this.Page.Validate("vaciosD");

                if (this.Page.IsValid)
                {
                    if (Convert.ToDecimal(txtCosto.Text) <= 1000)
                    {
                        pedidoLN = new PedidoLNBorrar();
                        pedidoEN = new PedidoENBorrar();
                        if (Convert.ToInt32(ViewState["idDetalleV"]) > 0)
                        {
                            double saldo = 0;
                            pedidoEN.ccidVale = Convert.ToInt32(ViewState["idVale"]);

                            pedidoEN.ccidValeDetalle = Convert.ToInt32(ViewState["idDetalleV"]);
                            pedidoEN.cantidad= Convert.ToInt32(txtCantidad.Text); 
                            pedidoEN.descripcion = txtDescripcion.Text ;
                            pedidoEN.costoEstimado = Convert.ToDouble(txtCosto.Text);

                            saldo = ((pedidoLN.sumaValeDetalle(pedidoEN) - Convert.ToDouble(ViewState["costoAnterior"])) + pedidoEN.costoEstimado);

                            if (saldo <= 1000)
                            { 

                                if (pedidoLN.Modificar_ccValeDetalle(pedidoEN) == 0)
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
                            else
                            {
                                string mensaje = "El Vale no puede ser mayor a 1,000 el y este es de:" + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);
                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                            }
                        }
                        if (Convert.ToInt32(ViewState["idDetalleV"]) == 0)
                        {
                            double saldo=0;
                            pedidoEN.ccidVale = Convert.ToInt32(ViewState["idVale"]);
                            pedidoEN.cantidad = Convert.ToInt32(txtCantidad.Text);
                            pedidoEN.descripcion = txtDescripcion.Text;
                            pedidoEN.costoEstimado = Convert.ToDouble(txtCosto.Text);

                            saldo = (pedidoLN.sumaValeDetalle(pedidoEN) + pedidoEN.costoEstimado);

                            if (saldo <= 1000)
                            {

                                if (pedidoLN.Insertar_ccValeDetalle(pedidoEN) == 0)
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
                            else
                            {
                                string mensaje = "El Vale no puede ser mayor a 1,000 el y este es de:" + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);
                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                            }
                            
                        }
                        ViewState["idDetalleV"] = 0;
                        ViewState["costoAnterior"] = 0;
                        txtCantidad.Text = String.Empty;
                        txtCosto.Text = String.Empty;
                        txtDescripcion.Text = String.Empty;
                        dropAccion.Enabled = false;
                        pedidoEN.ccidVale  = Convert.ToInt32(ViewState["idVale"]);
                        pedidoLN.gridMValeD(gridArticulos, pedidoEN);
                        btnAgregar.Text = "Agregar";


                    }
                    else
                    {
                        string mensaje;
                        mensaje = "El valor Maximo del Vale es de Q1,000, este vale sobrepasa el limite";
                        mostrarMsg(1, mensaje);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    }
                }
            }
            catch
            {

            }

        }

        protected void gridArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pedidoLN = new PedidoLNBorrar();
            pedidoEN = new PedidoENBorrar();
            DataTable dtpedido;
            ViewState["idDetalleV"] = Convert.ToInt32(gridArticulos.SelectedValue);
            pedidoEN.ccidVale = Convert.ToInt32(ViewState["idDetalleV"]);
            dtpedido = pedidoLN.datosMValeDetalle(pedidoEN);
 
            txtCantidad.Text = Convert.ToString(dtpedido.Rows[0]["cantidad"]);
            txtCosto.Text = Convert.ToString(dtpedido.Rows[0]["Costo"]);
            txtDescripcion.Text = Convert.ToString(dtpedido.Rows[0]["Descripcion"]);
            ViewState["costoAnterior"] =  txtCosto.Text;
            btnAgregar.Text = "Modificar";
 
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
                                if (gridArticulos.Rows.Count > 0)
                                {
                                    
                                    pedidoLN = new PedidoLNBorrar();
                                    pedidoEN = new PedidoENBorrar();

                                    pedidoEN.ccidVale = Convert.ToInt32(ViewState["idVale"]);
                                    pedidoEN.idAccion = Convert.ToInt32(dropAccion.SelectedValue);
                                    pedidoEN.idSolicitante = Convert.ToInt32(dropSolicitante.SelectedValue);
                                    pedidoEN.idJefeDireccion = Convert.ToInt32(dropJefeDir.SelectedValue);
                                    pedidoEN.Justificacion = txtJustificacion.Text;
                                    pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                                    

                                    
                                        
                                            if (pedidoLN.Modificar_ccVale(pedidoEN) == 0)
                                            {
                                                Response.Redirect("NoPedido.aspx?No=" + pedidoEN.ccidVale + "&msg=VALE");

                                            }
                                            else
                                            {
                                                string mensaje;
                                                mensaje = "XXX El Vale No se ha Generado XXX";
                                                mostrarMsg(1, mensaje);
                                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                            }
                                        
                                    
                                }
                                else
                                {
                                    string mensaje;
                                    mensaje = "Debe de Ingresar Articulos para realizar el Vale.";
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
            catch
            {

            }


        }

        protected void gridArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            mostrarMsg(2, "");

            int idVD = 0;
            idVD = Convert.ToInt32(gridArticulos.Rows[e.RowIndex].Cells[2].Text);
            if (idVD > 0 && gridArticulos.Rows.Count > 1)
            {
                pedidoLN = new PedidoLNBorrar();
                pedidoEN = new PedidoENBorrar();

                pedidoEN.ccidValeDetalle= idVD;
                pedidoLN.Eliminar_ccValeDetalle(pedidoEN);
                pedidoEN.ccidVale = Convert.ToInt32(ViewState["idVale"]);
                pedidoLN.gridMValeD(gridArticulos, pedidoEN);

                ViewState["idDetalleV"] = 0;
                ViewState["costoAnterior"] = 0;
                txtCantidad.Text = String.Empty;
                txtCosto.Text = String.Empty;
                txtDescripcion.Text = String.Empty;
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



    }
}
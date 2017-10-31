using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Pedido
{
    public partial class VoBo1Almacen : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private UsuariosLN uUsuariosLN;
        private PedidosLN pInsumoLN;
        private PlanOperativoLN planOperativoLN;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    NuevoEncabezadoPoa();
                    NuevaAprobacion();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        public void NuevaAprobacion()
        {
            try
            {
                limpiarControlesError();
                filtrarDvPedidos();
                filtrarGridDetalles();
                txtObser.Text = string.Empty;                
            }
            catch (Exception ex)
            {
                throw new Exception("NuevaAprobacion()" + ex.Message);
            }
        }

        public void NuevoEncabezadoPoa()
        {
            try
            {
                upIngreso.Visible = true;
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pAccionLN = new PlanAccionLN();
                pAnualLN = new PlanAnualLN();
                uUsuariosLN = new UsuariosLN();

                pEstrategicoLN.DdlPlanes(ddlPlanes);

                int idPlan = 0;
                int anioIni = 0;
                int anioFin = 0;
                if (ddlPlanes.Items.Count == 2)
                {
                    ddlPlanes.SelectedIndex = 1;
                    idPlan = int.Parse(ddlPlanes.SelectedValue);
                    anioIni = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[0].Trim());
                    anioFin = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[1].Trim());
                    lblPlanE.Visible = false;
                    ddlPlanes.Visible = false;
                }
                pEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                ddlAnios.Items.RemoveAt(0);

                int anioActual = DateTime.Now.Year;

                ListItem item = ddlAnios.Items.FindByValue(anioActual.ToString());
                if (item != null)
                    ddlAnios.SelectedValue = anioActual.ToString();

                uUsuariosLN.dropUnidad(ddlUnidades);

                if (ddlUnidades.Items.Count == 1)
                {
                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoaAprobacionPedido(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                    }
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Todas las acciones >>";
                ddlAnios.Enabled = ddlUnidades.Enabled = ddlAcciones.Enabled = true;

                pInsumoLN = new PedidosLN();
                pInsumoLN.RblEstadosPedido(rblEstadosPedido);
                rblEstadosPedido.SelectedValue = "2";
                rblEstadosPedido_SelectedIndexChanged(new Object(), new EventArgs());

            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoPoa(). " + ex.Message);
            }
        }

        protected void filtrarDvPedidos()
        {
            try
            {
                dvPedido.DataSource = null;
                dvPedido.DataBind();
                //dvPedido.SelectedValue = -1;

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = new DataSet();
                int idPoa, anio, idUnidad, noSolicitud; 
                idPoa = anio = idUnidad = noSolicitud = 0;
                
                int.TryParse(lblIdPoa.Text, out idPoa);
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);
                int.TryParse(txtNo.Text, out noSolicitud);

                if (false)//!lblErrorPoa.Text.Equals(string.Empty))
                {
                    dvPedido.DataSource = null;
                    dvPedido.DataBind();
                }
                else
                {
                    //if (idPoa > 0)
                    {
                        /*if (idPoa == 0)
                            dsResultado = pInsumoLN.InformacionPedido(int.Parse(ddlAnios.SelectedValue), 1, "", 5);
                        else
                            dsResultado = pInsumoLN.InformacionPedido(idPoa, 2, "", 5);
                         * */

                        dsResultado = pInsumoLN.InformacionPedido(anio, noSolicitud, idUnidad, "", 5);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                        {
                            dvPedido.DataSource = dsResultado.Tables["BUSQUEDA"];
                            dvPedido.DataBind();

                            //txtObser.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES"].ToString();

                            string filtro = string.Empty;

                            object obj = dvPedido.DataSource;
                            System.Data.DataTable tbl = dvPedido.DataSource as System.Data.DataTable;
                            System.Data.DataView dv = tbl.DefaultView;

                            filtro = "0 = 0";

                            if (!ddlAnios.SelectedValue.Equals("0"))
                                filtro += " AND anio_solicitud = " + ddlAnios.SelectedValue;

                            if (!ddlUnidades.SelectedValue.Equals("0"))
                                filtro += " AND id_unidad = " + ddlUnidades.SelectedValue;

                            if (!rblTipoDocto.SelectedValue.Equals("0"))
                                filtro += " AND id_tipo_documento = " + rblTipoDocto.SelectedValue;

                            if (!rblEstadosPedido.SelectedValue.Equals("0"))
                                filtro += " AND id_estado_pedido = " + rblEstadosPedido.SelectedValue;

                            if (txtNo.Text.Equals("") == false || txtNo.Text.Equals(string.Empty) == false)
                                filtro += " AND no_solicitud = " + txtNo.Text;

                            if (!ddlAcciones.SelectedValue.Equals("0"))
                                filtro += " AND id_accion = " + ddlAcciones.SelectedValue;

                            dv.RowFilter = filtro;
                            dvPedido.DataSource = dv;
                            dvPedido.DataBind();

                            int idPedido = 0;

                            if (dvPedido.SelectedValue != null)
                            {
                                int.TryParse(dvPedido.SelectedValue.ToString(), out idPedido);
                                lblIdTipoDocto.Text = dvPedido.Rows[3].Cells[1].Text.Split('-')[0].ToString().Trim();

                                validarEstadoPedido(idPedido);

                                string tipoDocumento = "";
                                
                                if(lblIdTipoDocto.Text.Equals("1"))
                                    tipoDocumento = "R";
                                else if(lblIdTipoDocto.Text.Equals("2"))
                                    tipoDocumento = "V";

                                string jScript = "javascript:window.open('EspecificacionesIngreso.aspx?No=" + dvPedido.SelectedValue.ToString() + "&OptB=false&TipoD=" + tipoDocumento + "', '_blank');";
                                LinkButton lbAnexo = (LinkButton)(dvPedido.Rows[8].FindControl("LinkButton1"));

                                if (lbAnexo.Text.Equals("Especificaciones"))
                                    lbAnexo.Attributes.Add("onclick", jScript);
                                else
                                    lbAnexo.Attributes.Clear();
                            }                            
                        }
                        else
                        {
                            dvPedido.DataSource = null;
                            dvPedido.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarDvPedidos()" + ex.Message);
            }
        }

        protected void filtrarGridDetalles()
        {
            try
            {
                gridDetalle.DataSource = null;
                gridDetalle.DataBind();
                gridDetalle.SelectedIndex = -1;

                int idPedido = 0;
                if (dvPedido.SelectedValue != null)
                {
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idPedido);

                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = new DataSet();

                    int idTipoDocto = 0;
                    int.TryParse(lblIdTipoDocto.Text, out idTipoDocto);

                    if (idTipoDocto == 1)
                        dsResultado = pInsumoLN.InformacionPedido(idPedido, 0, 0, "", 3);
                    else if (idTipoDocto == 2)
                        dsResultado = pInsumoLN.InformacionVale(idPedido, 0, 3);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                    {
                        gridDetalle.DataSource = dsResultado.Tables["BUSQUEDA"];
                        gridDetalle.DataBind();

                        decimal cantidadArticulos = 0;
                        decimal totalPedido = 0;

                        if (idTipoDocto == 1)
                            dsResultado = pInsumoLN.InformacionPedido(idPedido, 0, 0, "", 2);
                        else if (idTipoDocto == 2)
                            dsResultado = pInsumoLN.InformacionVale(idPedido, 0, 2);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["CANTIDAD"].ToString(), out cantidadArticulos);
                        decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["TOTAL"].ToString(), out totalPedido);

                        gridDetalle.FooterRow.Cells[3].Text = "Totales";
                        gridDetalle.FooterRow.Cells[5].Text = cantidadArticulos.ToString();
                        gridDetalle.FooterRow.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalPedido);

                        decimal totalPedidoAnual = 0;
                        decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["TOTAL_COSTO_PEDIDO_MULTIANUAL"].ToString(), out totalPedidoAnual);
                        gridDetalle.FooterRow.Cells[8].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalPedidoAnual);

                    }
                    else
                    {
                        gridDetalle.DataSource = null;
                        gridDetalle.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridDetalles(). " + ex.Message);
            }
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                lblErrorPoa.Text = string.Empty;
                if (anio > 0 && idUnidad > 0)
                    validarPoaAprobacionPedido(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Todas las acciones >>";
                NuevaAprobacion();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                lblErrorPoa.Text = string.Empty;
                string id_unidad = ddlUnidades.SelectedItem.Value;

                if (anio > 0 && idUnidad > 0)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlDependencias(ddlDependencia, id_unidad);
                    validarPoaAprobacionPedido(idUnidad, anio);
                }
                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Todas las acciones >>";
                NuevaAprobacion();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idAccion = 0;
                int.TryParse(ddlAcciones.SelectedValue, out idAccion);
                filtrarDvPedidos();
                filtrarGridDetalles();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones(). " + ex.Message;
            }
        }

        protected void limpiarControlesError()
        {
            //lblErrorPoa.Text = string.Empty;
            lblErrorObser.Text = string.Empty;
            lblError.Text = lblSuccess.Text = string.Empty;
        }

        protected bool validarPoaAprobacionPedido(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                btnAprobar.Visible = btnRechazar.Visible = false;
                lblIdPoa.Text = "0";

                pOperativoLN = new PlanOperativoLN();                
                DataSet dsPoa = pOperativoLN.DatosPoaUnidad(idUnidad, anio);
                
                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                int idPoa = 0;
                int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
                lblIdPoa.Text = idPoa.ToString();

                string estadoPoa = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString() + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString();
                if (!estadoPoa.Split('-')[0].Trim().Equals("9"))
                {
                    btnAprobar.Visible = btnRechazar.Visible = false;
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa;
                }
                else
                {
                    string estadoPac = dsPoa.Tables[0].Rows[0]["ESTADO_PAC"].ToString();
                    if (false)//!estadoPac.Split('-')[0].Trim().Equals("6"))
                    {
                        btnAprobar.Visible = btnRechazar.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El PLAN ANUAL DE COMPRAS seleccionado se encuenta en estado: " + estadoPac;
                    }
                    else
                    {
                        btnAprobar.Visible = btnRechazar.Visible = true;
                        poaValido = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            return poaValido;            
        }

        protected bool validarEstadoPedido(int idPedido)
        {
            bool pedidoValido = false;
            try
            {
                if (idPedido == 0)
                {
                    btnAprobar.Visible = btnRechazar.Visible = true;
                    lblErrorPoa.Text = lblError.Text = "";
                    pedidoValido = true;
                }
                else
                {
                    btnAprobar.Visible = btnRechazar.Visible = false;

                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = new DataSet();

                    int idTipoDocto = 0;
                    int.TryParse(lblIdTipoDocto.Text, out idTipoDocto);

                    if(idTipoDocto == 1)
                        dsResultado = pInsumoLN.InformacionPedido(idPedido, 0, 0, "", 2);
                    else if (idTipoDocto == 2)
                        dsResultado = pInsumoLN.InformacionVale(idPedido, 0, 2);
                    
                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del pedido/vale.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al pedido");

                    string estadoPedido = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_PEDIDO"].ToString();

                    int idEstado = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString(), out idEstado);

                    //EL PEDIDO ESTÁ EN ESTADO APROBACIÓN DE ALMACEN
                    if (idEstado == 2)
                    {
                        btnAprobar.Visible = btnRechazar.Visible = true;
                        lblErrorPoa.Text = lblError.Text = string.Empty;
                        pedidoValido = true;
                    }
                    else
                    {
                        btnAprobar.Visible = btnRechazar.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "La REQUISICIÓN/VALE seleccionado se encuentra en estado: " + estadoPedido + ".";
                        pedidoValido = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            return pedidoValido;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void dvPedido_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            try
            {
                limpiarControlesError();
                dvPedido.PageIndex = e.NewPageIndex;
                filtrarDvPedidos();
                filtrarGridDetalles();
            }
            catch (Exception ex)
            {
                lblError.Text = "Page_LoadComplete(). " + ex.Message;
            }

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                planOperativoLN = new PlanOperativoLN();
                int idPedido = 0;
                if(dvPedido.SelectedValue != null)
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idPedido);

                if (idPedido == 0)
                    throw new Exception("Seleccione un PEDIDO!");

                if (validarEstadoPedido(idPedido))
                {
                    txtObser.Text = string.Empty;

                    pInsumoLN = new PedidosLN();
                    string usuario = Session["usuario"].ToString();
                    string observaciones = txtObser.Text;

                    int idTipoDocumento = 0;
                    int.TryParse(lblIdTipoDocto.Text, out idTipoDocumento);
                    FuncionesVarias fv = new FuncionesVarias();
                    string[] ip = fv.DatosUsuarios();
                    string solicitandte = dvPedido.Rows[7].Cells[1].Text;
                    string jefe = dvPedido.Rows[8].Cells[1].Text;
                    string[] solicitanteTemp = solicitandte.Split('-');
                    string[] jefeTemp = jefe.Split('-');
                    
                    DataSet dsResultado = pInsumoLN.AprobacionBodega(idPedido, idTipoDocumento, observaciones, usuario,ip[0],ip[1],ip[2]);
                    
                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se ACTUALIZÓ el pedido/vale: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    string noSolicitud = dvPedido.Rows[1].Cells[1].Text;
                    
                    //filtrarDvPedidos();
                    //filtrarGridDetalles();

                    lblSuccess.Text = "REQUISICIÓN/VALE NO. " + noSolicitud + " APROBADO con éxito!";
                    EnvioDeCorreos objEC = new EnvioDeCorreos();
                    objEC.EnvioCorreo(planOperativoLN.ObtenerCorreoxUsuario(jefeTemp[1].Trim()), "Nueva Requiscion Aprobada por Almacen", " Requisicion No.  " + idPedido + ", " + lblSuccess.Text  , usuario);
                    objEC.EnvioCorreo(planOperativoLN.ObtenerCorreoxUsuario(solicitanteTemp[1].Trim()), "Nueva Requiscion Aprobada por Almacen", " Requisicion No.  " + idPedido + ", " + lblSuccess.Text, usuario);

                    btnAprobar.Visible = btnRechazar.Visible = false;
                    //Response.Redirect("NoPedido.aspx?No=" + Convert.ToString(idPedido) + "&msg=PEDIDO" + "&acc=APROBADO");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnAprobar(). " + ex.Message;
            }
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                planOperativoLN = new PlanOperativoLN();
                int idPedido = 0;
                if (dvPedido.SelectedValue != null)
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idPedido);

                if (idPedido == 0)
                    throw new Exception("Seleccione una REQUISICIÓN/PEDIDO!");

                string s = txtObser.Text;
                s = s.Replace('\'', ' ');
                s = s.Trim();
                txtObser.Text = s;

                if (txtObser.Text.Equals(string.Empty))
                    lblError.Text = "Llene el campo de observaciones.";
                else
                {
                    pInsumoLN = new PedidosLN();
                    string usuario = Session["usuario"].ToString();
                    string observaciones = txtObser.Text;

                    int idTipoDocumento = 0;
                    int.TryParse(lblIdTipoDocto.Text, out idTipoDocumento);
                    FuncionesVarias fv = new FuncionesVarias();
                    string[] ip = fv.DatosUsuarios();
                    string solicitandte = dvPedido.Rows[7].Cells[1].Text;
                    string jefe = dvPedido.Rows[8].Cells[1].Text;
                    string[] solicitanteTemp = solicitandte.Split('-');
                    string[] jefeTemp = jefe.Split('-');
                    DataSet dsResultado = pInsumoLN.RechazoBodega(idPedido, idTipoDocumento, observaciones, usuario,ip[0],ip[1],ip[2]);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se No se ACTUALIZÓ el pedido/vale: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    string noSolicitud = dvPedido.Rows[1].Cells[1].Text;

                    filtrarDvPedidos();
                    filtrarGridDetalles();
                    txtObser.Text = string.Empty;
                    lblSuccess.Text = "REQUISICIÓN/VALE NO. " + noSolicitud + " RECHAZADO con éxito!";
                    EnvioDeCorreos objEC = new EnvioDeCorreos();
                    objEC.EnvioCorreo(planOperativoLN.ObtenerCorreoxUsuario(jefeTemp[1].Trim()), "Nueva REQUISICIÓN/VALE RECHAZADA por Almacen", " Requisicion No.  " + idPedido + ", " + lblSuccess.Text, usuario);
                    objEC.EnvioCorreo(planOperativoLN.ObtenerCorreoxUsuario(solicitanteTemp[1].Trim()), "Nueva REQUISICIÓN/VALE RECHAZADA por Almacen", " Requisicion No.  " + idPedido + ", " + lblSuccess.Text, usuario);

                    //Response.Redirect("NoPedido.aspx?No=" + Convert.ToString(idPedido) + "&msg=PEDIDO" + "&acc=RECHAZADO");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnRechazar(). " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                NuevaAprobacion();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnBuscar(). " + ex.Message;
            }
        }

        protected void rblEstadosPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                NuevaAprobacion();

                pInsumoLN = new PedidosLN();

                int idEstadoPedido = 0;
                int.TryParse(rblEstadosPedido.SelectedValue, out idEstadoPedido);

                if (idEstadoPedido > 0)
                {
                    DataSet dsResultado = pInsumoLN.InformacionEstadosPedido(idEstadoPedido, 0, 0, "", 2);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("Error al consultar información del estado de la requisición/vale: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    try
                    {
                        lblInformacionEstadoPedido.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DESCRIPCION_ESTADO"].ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se encontró información del estado de la requisición/vale: " + ex.Message);
                    }
                }
                else
                    lblInformacionEstadoPedido.Text = "Todos los estados de las requisiciones/vales";
            }
            catch (Exception ex)
            {
                lblError.Text = "rblEstadosPedido(). " + ex.Message;
            }
        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlDependencia.SelectedValue, out idUnidad);

                lblErrorPoa.Text = string.Empty;
                string id_unidad = ddlDependencia.SelectedItem.Value;

                if (anio > 0 && idUnidad > 0)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlDependencias(ddlJefaturaUnidad, id_unidad);
                    validarPoaAprobacionPedido(idUnidad, anio);
                }
                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Todas las acciones >>";
                NuevaAprobacion();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlJefaturaUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlJefaturaUnidad.SelectedValue, out idUnidad);

                lblErrorPoa.Text = string.Empty;
                string id_unidad = ddlJefaturaUnidad.SelectedItem.Value;

                if (anio > 0 && idUnidad > 0)
                {
                    
                    validarPoaAprobacionPedido(idUnidad, anio);
                }
                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Todas las acciones >>";
                NuevaAprobacion();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }
    }
}
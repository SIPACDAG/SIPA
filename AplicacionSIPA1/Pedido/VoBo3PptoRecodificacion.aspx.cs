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

using Microsoft.Reporting.WebForms;
using System.IO;

namespace AplicacionSIPA1.Pedido
{
    public partial class VoBo3PptoRecodificacion : System.Web.UI.Page
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
                filtrarGridPpto();
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
                
                lblAnio.Text = anioActual.ToString();
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

                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("1"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("2"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("3"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("4"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("5"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("6"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("7"));
                //rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("8"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("9"));
                //rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("10"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("11"));
                //rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("12"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("13"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("14"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("15"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("16"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("17"));
                rblEstadosPedido.Items.Remove(rblEstadosPedido.Items.FindByValue("18"));

                rblEstadosPedido.SelectedValue = "0";
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

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = new DataSet();
                int anio, idTipoDocumento, noSolicitud; 
                anio = idTipoDocumento = noSolicitud = 0;
                
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(rblTipoDocto.SelectedValue, out idTipoDocumento);
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
                        dsResultado = pInsumoLN.InformacionPedido(anio, 0, 0, "", 7);

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

                            filtro += (" AND id_estado_pedido IN (8, 10, 12) ");

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

                                validarEstadoPedido(idPedido);

                                string tipoDocumento = "";

                                if (tipoDoc() == 1)
                                    tipoDocumento = "R";
                                else if (tipoDoc() == 2)
                                    tipoDocumento = "V";

                                if (tipoDocumento.Equals("R") || tipoDocumento.Equals("V"))
                                {
                                    string jScript = "javascript:window.open('EspecificacionesIngreso.aspx?No=" + dvPedido.SelectedValue.ToString() + "&OptB=false&TipoD=" + tipoDocumento + "', '_blank');";
                                    LinkButton lbAnexo = (LinkButton)(dvPedido.Rows[13].FindControl("LinkButton1"));

                                    if (lbAnexo.Text.Equals("Especificaciones"))
                                        lbAnexo.Attributes.Add("onclick", jScript);
                                    else
                                        lbAnexo.Attributes.Clear();
                                }

                                generarReporte(idPedido, idTipoDocumento);
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
                throw new Exception("filtrarDvPedidos(). " + ex.Message);
            }
        }

        protected void filtrarGridDetalles()
        {
            try
            {
                gridDetalle.DataSource = null;
                gridDetalle.DataBind();
                gridDetalle.SelectedIndex = -1;

                int idSalida, idTipoSalida;
                idSalida = idTipoSalida = 0;
                if (dvPedido.SelectedValue != null)
                {
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idSalida);

                    idTipoSalida = tipoDoc();
                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.DetallesPedidoAprobacion(idSalida, idTipoSalida, "", 1);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                    {

                        gridDetalle.DataSource = dsResultado.Tables["BUSQUEDA"];
                        gridDetalle.DataBind();

                        decimal cantidadArticulos = 0;
                        decimal totalPedido = 0;

                        string sCantidad = dsResultado.Tables["BUSQUEDA"].Compute("SUM(CANTIDAD)", "").ToString();
                        string sSubtotal = dsResultado.Tables["BUSQUEDA"].Compute("SUM(SUBTOTAL)", "").ToString();

                        decimal.TryParse(sCantidad, out cantidadArticulos);
                        decimal.TryParse(sSubtotal, out totalPedido);

                        gridDetalle.FooterRow.Cells[3].Text = "Totales";
                        gridDetalle.FooterRow.Cells[5].Text = cantidadArticulos.ToString();
                        gridDetalle.FooterRow.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalPedido);

                        decimal totalPedidoAnual = 0;
                        decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Compute("SUM(TOTAL_PEDIDO_MULTIANUAL)", "").ToString(), out totalPedidoAnual);
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

        protected void filtrarGridPpto()
        {
            try
            {
                gridSaldos.DataSource = null;
                gridSaldos.DataBind();
                gridSaldos.SelectedIndex = -1;

                int idSalida, tipoSalida;
                idSalida = tipoSalida = 0;

                if (dvPedido.SelectedValue != null)
                    int.TryParse(dvPedido.DataKey[1].ToString(), out idSalida);

                //SALDOS EN BASE A LA ACCIÓN
                tipoSalida = 4;
                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.PptoAprobacionSubgerente(idSalida, 0, "", tipoSalida);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridSaldos.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridSaldos.DataBind();
                }
                else
                {
                    gridSaldos.DataSource = null;
                    gridSaldos.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridPpto(). " + ex.Message);
            }
        }

        private int tipoDoc()
        {
            int tipo = 0;
            if (dvPedido.Rows.Count > 0)
            {

                switch (dvPedido.Rows[3].Cells[1].Text)
                {
                    case "REQUISICION": tipo = 1;
                        break;
                    case "VALE": tipo = 2;
                        break;
                    case "TRANSFERENCIA, APOYO U OTRO GASTO": tipo = 3;
                        break;
                }
            }
            return tipo;
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
                lblAnio.Text = anio.ToString();
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
                NuevaAprobacion();
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

            limpiarLblErrorGrid(gridDetalle);
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
                        btnAprobar.Visible = /*btnRechazar.Visible =*/ true;
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
                    btnAprobar.Visible = /*btnRechazar.Visible =*/ true;
                    lblErrorPoa.Text = lblError.Text = "";
                    pedidoValido = true;
                }
                else
                {
                    btnAprobar.Visible = btnRechazar.Visible = false;

                    int anio, idTipoDocumento;
                    anio = idTipoDocumento = 0;

                    int.TryParse(ddlAnios.SelectedValue, out anio);
                    int.TryParse(rblTipoDocto.SelectedValue, out idTipoDocumento);
                    
                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.InformacionPedido(anio, idPedido, idTipoDocumento, "ESTADO", 7);
                    
                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del pedido.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al pedido");

                    string estadoPedido = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_PEDIDO"].ToString();

                    int idEstado = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString(), out idEstado);

                    //EL PEDIDO ESTÁ EN ESTADO APROBACIÓN DE PPTO
                    if (idEstado == 6)
                    {
                        btnAprobar.Visible = /*btnRechazar.Visible =*/ true;
                        lblErrorPoa.Text = lblError.Text = string.Empty;
                        pedidoValido = true;
                    }
                    else
                    {
                        btnAprobar.Visible = btnRechazar.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "La REQUISICIÓN/VALE/GASTO seleccionado se encuentra en estado: " + estadoPedido + ".";
                        pedidoValido = false;
                    }


                    //LA PERSONA CON ROL DE ADMINISTRACIÓN PODRÁ ASIGNAR PARTIDA PRESUPUESTARIA NO IMPORTANDO EL ESTADO DE LA REQUISICIÓN
                    if (btnAprobar.Visible == false && btnRechazar.Visible == false)
                    {
                        pInsumoLN = new PedidosLN();
                        dsResultado = pInsumoLN.InformacionPermisos(0, 0, Session["usuario"].ToString(), 9);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                            btnAprobar.Visible = /*btnRechazar.Visible =*/ true;
                        else
                            btnAprobar.Visible = btnRechazar.Visible = false;
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
                NuevaAprobacion();
            }
            catch (Exception ex)
            {
                lblError.Text = "Page_LoadComplete(). " + ex.Message;
            }

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {

            limpiarControlesError();
            planOperativoLN = new PlanOperativoLN();
            int idSalida, idTipoSalida;
            idSalida = idTipoSalida = 0;

            try
            {
                if (validarControlesABC())
                {
                    if (dvPedido.SelectedValue != null)
                        int.TryParse(dvPedido.SelectedValue.ToString(), out idSalida);

                    idTipoSalida = tipoDoc();

                    if (idSalida == 0)
                        throw new Exception("Seleccione un PEDIDO!");

                    codificarSalida(gridDetalle);

                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.DetallesPedidoAprobacion(idSalida, idTipoSalida, "", 2);

                    //VALIDACIÓN DE TODOS LOS DETALLES CODIFICADOS
                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                        throw new Exception("Codifique todos los detalles!");

                    string errorSaldo = string.Empty;

                    if (idTipoSalida == 1)
                    {
                        //VALIDACIÓN DE LOS RENGLONES CODIFICADOS PARA CADA DETALLE DE UN PEDIDO, SÓLO APLICA CUANDO SE ESTÁ APROBANDO UN PEDIDO
                        
                        
                        /*dsResultado = pInsumoLN.PptoCodificarSalida(idSalida, 0, "", 4);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                        {
                            errorSaldo = dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_RENGLON"].ToString();
                            //if (dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_SALDO"].ToString().Equals(string.Empty))
                            //    errorSaldo = dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_RENGLON"].ToString();
                        }*/
                        //throw new Exception("Codifique todos los detalles con Renglón, Programa, Subprograma y Actividad!");

                        //VALIDACIÓN DEL SALDO DEL PAC AL QUE PERTENECE CADA DETALLE DEL PEDIDO
                        dsResultado = pInsumoLN.PptoCodificarSalida(idSalida, 0, "", 5);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                        {
                            errorSaldo += dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_SALDO"].ToString();
                            //if(dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_SALDO"].ToString().Equals(string.Empty))

                        }
                        //throw new Exception("Codifique todos los detalles con Renglón, Programa, Subprograma y Actividad!");
                    }

                    dsResultado = pInsumoLN.PptoCodificarSalida(idSalida, 0, "", idTipoSalida);

                    //VALIDACIÓN DEL SALDO DE LOS RENGLONES AL QUE PERTENECE LA ACCIÓN DE LA SALIDA (PEDIDO, VALE, GASTO)
                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                    {
                        errorSaldo += dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_SALDO"].ToString();
                        //if (dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_SALDO"].ToString().Trim().Equals(string.Empty))
                        //    errorSaldo += dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_SALDO"].ToString();
                    }

                    if (!errorSaldo.Trim().Equals(string.Empty))
                        throw new Exception(errorSaldo);
                    else
                    {
                        //if (validarEstadoPedido(idSalida))
                        if (true)
                        {
                            txtObser.Text = string.Empty;
                            FuncionesVarias fv = new FuncionesVarias();
                            string[] ip = fv.DatosUsuarios();
                            string usuario = Session["usuario"].ToString();
                            string observaciones = txtObser.Text;
                            dsResultado = pInsumoLN.RecodificacionPpto(idSalida, idTipoSalida, observaciones, usuario,ip[0],ip[1],ip[2]);

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            {
                                ddlPRG.ClearSelection();
                                ddlSPRG.ClearSelection();
                                ddlPROY.ClearSelection();
                                ddlACT.ClearSelection();
                                ddlOBR.ClearSelection();
                                ddlRenglonesC.ClearSelection();

                                throw new Exception("No se RECODIFICÓ la solicitud: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());
                            }
                            string solicitandte = dvPedido.Rows[7].Cells[1].Text;
                            string jefe = dvPedido.Rows[8].Cells[1].Text;
                            string[] solicitanteTemp = solicitandte.Split('-');
                            string[] jefeTemp = jefe.Split('-');
                            string noSolicitud = dvPedido.Rows[1].Cells[1].Text;
                            string tipoSolicitud = dvPedido.Rows[3].Cells[1].Text;

                            NuevaAprobacion();
                            lblSuccess.Text = tipoSolicitud + " No. " + noSolicitud + " RECODIFICÓ con éxito!";
                            EnvioDeCorreos objEC = new EnvioDeCorreos();
                            objEC.EnvioCorreo(planOperativoLN.ObtenerCorreoxUsuario(jefeTemp[1].Trim()), "Nueva REQUISICIÓN/VALE APROBADA por Presupuesto",  lblSuccess.Text, usuario);
                            objEC.EnvioCorreo(planOperativoLN.ObtenerCorreoxUsuario(solicitanteTemp[1].Trim()), "Nueva REQUISICIÓN/VALE APROBADA por Presupuesto",   lblSuccess.Text, usuario);

                            ddlPRG.ClearSelection();
                            ddlSPRG.ClearSelection();
                            ddlPROY.ClearSelection();
                            ddlACT.ClearSelection();
                            ddlOBR.ClearSelection();

                            btnAprobar.Visible = btnRechazar.Visible = false;
                            generarReporte(idSalida, idTipoSalida);
                        }
                        else
                            throw new Exception(lblError.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnAprobar(). " + ex.Message;

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.CodificarSalida(idSalida, idTipoSalida, 0, "", "", "", "", "", 2);
                filtrarGridDetalles();
                ddlPRG.ClearSelection();
                ddlSPRG.ClearSelection();
                ddlPROY.ClearSelection();
                ddlACT.ClearSelection();
                ddlOBR.ClearSelection();
                ddlRenglonesC.ClearSelection();
            }
        }

        protected void generarReporte(int idEncabezado, int idTipoSalida)
        {

            //using Microsoft.Reporting.WebForms;
            //using System.IO;
            try
            {
                if (idEncabezado > 0)
                {

                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    ReportViewer rViewer = new ReportViewer();

                    DataTable dt = new DataTable();
                    GridView gridPlan = new GridView();

                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.InformacionPedido(idEncabezado, idTipoSalida, 0, "ENCABEZADO", 12);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se CONSULTÓ la información del encabezado: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                    ReportDataSource RD = new ReportDataSource();
                    RD.Value = dsResultado.Tables[1];
                    RD.Name = "DataSet1";

                    if(idTipoSalida == 1)
                        dsResultado = pInsumoLN.InformacionPedido(idEncabezado, 0, 0, "", 3);
                    else if(idTipoSalida == 2)
                        dsResultado = pInsumoLN.InformacionVale(idEncabezado, 0, 3);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se CONSULTÓ la información de los detalles: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    ReportDataSource RD2 = new ReportDataSource();
                    RD2.Value = dsResultado.Tables[1];
                    RD2.Name = "DataSet2";

                    rViewer.LocalReport.DataSources.Clear();
                    rViewer.LocalReport.DataSources.Add(RD);
                    rViewer.LocalReport.DataSources.Add(RD2);
                    rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes/rptFINFOR23.rdlc";
                    rViewer.LocalReport.ReportPath = @"Reportes\\rptFINFOR23.rdlc";
                    rViewer.LocalReport.Refresh();


                    byte[] bytes = rViewer.LocalReport.Render(
                       "PDF", null, out mimeType, out encoding,
                        out extension,
                       out streamids, out warnings);

                    string nombreReporte = "FIN-FOR-23 ";

                    string direccion = Server.MapPath("ArchivoPdf");
                    direccion = (direccion + ("\\\\" + (""
                                + (nombreReporte + ".pdf"))));

                    FileStream fs = new FileStream(direccion,
                       FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();

                    String reDireccion = "\\ArchivoPDF/";
                    reDireccion += "\\" + "" + nombreReporte + ".pdf";


                    string jScript = "javascript:window.open('" + reDireccion + "','REQUISICIONES'," + "'directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=750, height=400');";
                    btnImprimir.Attributes.Add("onclick", jScript);

                    btnImprimir_Click(new Object(), new EventArgs());
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnVerReporte(). " + ex.Message;
            }
        }

        private void limpiarLblErrorGrid(GridView gv)
        {
            try
            {
                Label lblObs;

                for (int i = 0; i < gridDetalle.Rows.Count; i++)
                {
                    lblObs = (Label)(gridDetalle.Rows[i].FindControl("lblObs"));
                    lblObs.Text = "";
                }            
            }
            catch (Exception ex)
            {
                throw new Exception("limpiarLblErrorGrid(). " + ex.Message);
            }
        }


        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                int anio = 0;
                int.TryParse(lblAnio.Text, out anio);
                if (anio < 0)
                {
                    lblError.Text += "Seleccione un año. ";
                }

                TextBox txtPRG, txtSPRG, txtPROY, txtACT, txtOBR;
                DropDownList ddlRenglon;
                Label lblObs;

                for (int i = 0; i < gridDetalle.Rows.Count; i++)
                {
                    txtPRG = (TextBox)(gridDetalle.Rows[i].FindControl("txtPRG"));
                    txtSPRG = (TextBox)(gridDetalle.Rows[i].FindControl("txtSPRG"));
                    txtPROY = (TextBox)(gridDetalle.Rows[i].FindControl("txtPROY"));
                    txtACT = (TextBox)(gridDetalle.Rows[i].FindControl("txtACT"));
                    txtOBR = (TextBox)(gridDetalle.Rows[i].FindControl("txtOBR"));
                    ddlRenglon = (DropDownList)(gridDetalle.Rows[i].FindControl("ddlRenglon"));
                    lblObs = (Label)(gridDetalle.Rows[i].FindControl("lblObs"));

                    if (ddlPRG.Items.FindByValue(txtPRG.Text) != null && txtPRG.Text.Equals("--") == false && txtPRG.Text.Equals("---") == false)
                        lblError.Text = lblObs.Text = lblObs.Text.Replace("Programa no válido. ", "");
                    else
                    {
                        if(lblObs.Text.Contains("Programa no válido. ") == false)
                            lblObs.Text += "Programa no válido. ";
                        
                        lblError.Text = "Existen errores, por favor revise";
                    }

                    if (ddlSPRG.Items.FindByValue(txtSPRG.Text) != null && txtSPRG.Text.Equals("--") == false && txtSPRG.Text.Equals("---") == false)
                        lblObs.Text = lblObs.Text.Replace("Subprograma no válido. ", "");
                    else
                    {
                        if (lblObs.Text.Contains("Subprograma no válido. ") == false)
                            lblObs.Text += "Subprograma no válido. ";
                        lblError.Text = "Existen errores, por favor revise";
                    }

                    if (ddlPROY.Items.FindByValue(txtPROY.Text) != null && txtPROY.Text.Equals("--") == false && txtPROY.Text.Equals("---") == false)
                        lblObs.Text = lblObs.Text.Replace("Proyecto no válido. ", "");
                    else
                    {
                        if (lblObs.Text.Contains("Proyecto no válido. ") == false)
                            lblObs.Text += "Proyecto no válido. ";
                        lblError.Text = "Existen errores, por favor revise";
                    }

                    if (ddlACT.Items.FindByValue(txtACT.Text) != null && txtACT.Text.Equals("--") == false && txtACT.Text.Equals("---") == false)
                        lblObs.Text = lblObs.Text.Replace("Actividad no válida. ", "");
                    else
                    {
                        if (lblObs.Text.Contains("Actividad no válida. ") == false)
                            lblObs.Text += "Actividad no válida. ";
                        lblError.Text = "Existen errores, por favor revise";
                    }

                    if (ddlOBR.Items.FindByValue(txtOBR.Text) != null && txtOBR.Text.Equals("--") == false && txtOBR.Text.Equals("---") == false)
                        lblObs.Text = lblObs.Text.Replace("Obra no válida. ", "");
                    else
                    {
                        if (lblObs.Text.Contains("Obra no válida. ") == false)
                            lblObs.Text += "Obra no válida. ";

                        lblError.Text = "Existen errores, por favor revise";
                    }

                    if (ddlRenglon.SelectedValue.Equals("0") == false)
                        lblObs.Text = lblObs.Text.Replace("Seleccione renglón. ", "");
                    else
                    {
                        if (lblObs.Text.Contains("Seleccione renglón. ") == false)
                            lblObs.Text += "Seleccione renglón. ";

                        lblError.Text = "Existen errores, por favor revise";
                    }
                    
                }

                if (lblError.Text.Trim().Equals(string.Empty) || lblError.Text.Trim().Equals(""))
                    controlesValidos = true;

                if (controlesValidos && Page.IsValid)
                    controlesValidos = true;
                else
                    controlesValidos = false;
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }
            return controlesValidos;
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            try
            {
                planOperativoLN = new PlanOperativoLN();
                limpiarControlesError();
                FuncionesVarias fv = new FuncionesVarias();
                string[] ip = fv.DatosUsuarios();
                int idSalida, idTipoSalida;
                idSalida = idTipoSalida = 0;
                if (dvPedido.SelectedValue != null)
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idSalida);

                idTipoSalida = tipoDoc();

                if (idSalida == 0)
                    throw new Exception("Seleccione un PEDIDO!");

                string s = txtObser.Text;
                s = s.Replace('\'', ' ');
                s = s.Trim();
                txtObser.Text = s;

                if (txtObser.Text.Equals(string.Empty))
                    lblError.Text = "Llene el campo de observaciones.";
                else
                {
                    pInsumoLN = new PedidosLN();
                    string solicitandte = dvPedido.Rows[7].Cells[1].Text;
                    string jefe = dvPedido.Rows[8].Cells[1].Text;
                    string[] solicitanteTemp = solicitandte.Split('-');
                    string[] jefeTemp = jefe.Split('-');
                    string usuario = Session["usuario"].ToString();
                    string observaciones = txtObser.Text;
                    DataSet dsResultado = pInsumoLN.RechazoPresupuesto(idSalida, idTipoSalida, observaciones, usuario,ip[0],ip[1],ip[2]);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se RECHAZÓ la solicitud: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    string noSolicitud = dvPedido.Rows[1].Cells[1].Text;
                    string tipoSolicitud = dvPedido.Rows[3].Cells[1].Text;

                    NuevaAprobacion();
                    lblSuccess.Text = tipoSolicitud + " No. " + noSolicitud + " RECHAZADA con éxito!";
                    EnvioDeCorreos objEC = new EnvioDeCorreos();
                    objEC.EnvioCorreo(planOperativoLN.ObtenerCorreoxUsuario(jefeTemp[1].Trim()), "Nueva REQUISICIÓN/VALE RECHAZADA por Presupuesto", lblSuccess.Text + ", " + observaciones, usuario);
                    objEC.EnvioCorreo(planOperativoLN.ObtenerCorreoxUsuario(solicitanteTemp[1].Trim()), "Nueva REQUISICIÓN/VALE RECHAZADA por Presupuesto", lblSuccess.Text + ", " + observaciones, usuario);

                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnRechazar(). " + ex.Message;
            }
        }

        protected void codificarSalida(GridView gv)
        {
            pInsumoLN = new PedidosLN();

            int idSalida, idTipoSalida;
            idSalida = idTipoSalida = 0;
            if (dvPedido.SelectedValue != null)
                int.TryParse(dvPedido.SelectedValue.ToString(), out idSalida);

            idTipoSalida = tipoDoc();

            try
            {
                for (int i = 0; i < gv.Rows.Count; i++)
                {
                    string renglon, pro, spro, proy, act, obr = "";

                    renglon = ((DropDownList)gridDetalle.Rows[i].FindControl("ddlRenglon")).SelectedValue;
                    pro = ((TextBox)gridDetalle.Rows[i].FindControl("txtPRG")).Text;
                    spro = ((TextBox)gridDetalle.Rows[i].FindControl("txtSPRG")).Text;
                    proy = ((TextBox)gridDetalle.Rows[i].FindControl("txtPROY")).Text;
                    act = ((TextBox)gridDetalle.Rows[i].FindControl("txtACT")).Text;
                    obr = ((TextBox)gridDetalle.Rows[i].FindControl("txtOBR")).Text;

                    int idDetalleSalida, idDetalleAccion;
                    idDetalleSalida = idDetalleAccion = 0;

                    int.TryParse(gridDetalle.DataKeys[i].Values["ID"].ToString(), out idDetalleSalida);
                    int.TryParse(renglon, out idDetalleAccion);

                    DataSet dsResultado = pInsumoLN.CodificarSalida(idDetalleSalida, idTipoSalida, idDetalleAccion, pro, spro, proy, act, obr, 1);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se CODIFICÓ el detalle seleccionado: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());
                }
            }
            catch (Exception ex)
            {
                DataSet dsResultado = pInsumoLN.CodificarSalida(idSalida, idTipoSalida, 0, "", "", "", "", "", 2);
                throw new Exception("codificarSalida(). " + ex.Message);
            }
        }

        protected void ddlRenglon_SelectedIndexChanged(object sender, EventArgs e)
        {        
        }

        protected void gridDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                pInsumoLN = new PedidosLN();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int idSalida = 0;
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idSalida);

                    
                    DropDownList ddlRenglon = (DropDownList)e.Row.FindControl("ddlRenglon");
                    pInsumoLN.DdlRenglonesCodificarPedido(ddlRenglon, idSalida, 0, "", tipoDoc());

                    DataRow row = ((DataRowView)e.Row.DataItem).Row;

                    int id = 0;
                    int.TryParse(row["ID_DETALLE_ACCION"].ToString(), out id);

                    if (id > 0)
                    {
                        ListItem item = ddlRenglon.Items.FindByValue(id.ToString());

                        if (item != null)
                            ddlRenglon.SelectedValue = id.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "gridDetalle(). " + ex.Message;
            }            
        }

        protected void ddlPRG_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                string valor = ddlPRG.SelectedValue;

                ddlACT.ClearSelection();
                ddlACT.Items.Clear();

                ddlACT.Items.Add(new ListItem("---", "---"));

                if (valor.Equals("11"))
                {
                    ddlACT.Items.Add(new ListItem("000", "000"));
                    ddlACT.Items.Add(new ListItem("001", "001"));
                    ddlACT.Items.Add(new ListItem("002", "002"));
                    ddlACT.Items.Add(new ListItem("003", "003"));
                    ddlACT.Items.Add(new ListItem("004", "004"));
                    ddlACT.Items.Add(new ListItem("005", "005"));
                    ddlACT.Items.Add(new ListItem("006", "006"));
                    ddlACT.Items.Add(new ListItem("007", "007"));
                    ddlACT.Items.Add(new ListItem("008", "008"));
                    ddlACT.Items.Add(new ListItem("009", "009"));
                    ddlACT.Items.Add(new ListItem("010", "010"));
                    ddlACT.Items.Add(new ListItem("011", "011"));
                    ddlACT.Items.Add(new ListItem("012", "012"));
                    ddlACT.Items.Add(new ListItem("014", "014"));
                    ddlACT.Items.Add(new ListItem("015", "015"));
                }
                else if (valor.Equals("99"))
                {
                    ddlACT.Items.Add(new ListItem("001", "001"));
                    ddlACT.Items.Add(new ListItem("002", "002"));
                }

                ddlOBR.ClearSelection();
                ddlOBR.Items.Clear();

                ddlOBR.Items.Add(new ListItem("---", "---"));

                if (valor.Equals("11"))
                {
                    ddlOBR.Items.Add(new ListItem("N/A", "N/A"));
                    ddlOBR.Items.Add(new ListItem("001", "001"));
                    ddlOBR.Items.Add(new ListItem("002", "002"));
                    ddlOBR.Items.Add(new ListItem("003", "003"));
                    ddlOBR.Items.Add(new ListItem("004", "004"));
                    ddlOBR.Items.Add(new ListItem("005", "005"));
                    ddlOBR.Items.Add(new ListItem("006", "006"));
                    ddlOBR.Items.Add(new ListItem("007", "007"));
                    ddlOBR.Items.Add(new ListItem("008", "008"));
                    ddlOBR.Items.Add(new ListItem("009", "009"));
                    ddlOBR.Items.Add(new ListItem("010", "010"));
                    ddlOBR.Items.Add(new ListItem("011", "011"));
                    ddlOBR.Items.Add(new ListItem("012", "012"));
                    ddlOBR.Items.Add(new ListItem("014", "014"));
                    ddlOBR.Items.Add(new ListItem("015", "015"));
                    ddlOBR.Items.Add(new ListItem("016", "016"));
                    ddlOBR.Items.Add(new ListItem("017", "017"));
                    ddlOBR.Items.Add(new ListItem("018", "018"));
                    ddlOBR.Items.Add(new ListItem("019", "019"));
                    ddlOBR.Items.Add(new ListItem("020", "020"));
                }
                else if (valor.Equals("99"))
                {
                    ddlOBR.Items.Add(new ListItem("000", "000"));
                }

                for (int i = 0; i < gridDetalle.Rows.Count; i++)
                {
                    TextBox txtPRG = (TextBox)(gridDetalle.Rows[i].FindControl("txtPRG"));

                    if (valor.Equals("--") == false && valor.Equals("---") == false)
                        txtPRG.Text = valor;
                    else
                        txtPRG.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlPRG(). " + ex.Message;
            }
             
        }

        protected void ddlSPRG_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                string valor = ddlSPRG.SelectedValue;

                for (int i = 0; i < gridDetalle.Rows.Count; i++)
                {
                    TextBox txtTemp = (TextBox)(gridDetalle.Rows[i].FindControl("txtSPRG"));

                    if (valor.Equals("--") == false && valor.Equals("---") == false)
                        txtTemp.Text = valor;
                    else
                        txtTemp.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlSPRG(). " + ex.Message;
            }
        }

        protected void ddlPROY_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                string valor = ddlPROY.SelectedValue;

                for (int i = 0; i < gridDetalle.Rows.Count; i++)
                {
                    TextBox txtTemp = (TextBox)(gridDetalle.Rows[i].FindControl("txtPROY"));

                    if (valor.Equals("--") == false && valor.Equals("---") == false)
                        txtTemp.Text = valor;
                    else
                        txtTemp.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlPROY(). " + ex.Message;
            }
        }

        protected void ddlACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                string valor = ddlACT.SelectedValue;

                for (int i = 0; i < gridDetalle.Rows.Count; i++)
                {
                    TextBox txtTemp = (TextBox)(gridDetalle.Rows[i].FindControl("txtACT"));

                    if (valor.Equals("--") == false && valor.Equals("---") == false)
                        txtTemp.Text = valor;
                    else
                        txtTemp.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlACT(). " + ex.Message;
            }
        }

        protected void ddlOBR_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                string valor = ddlOBR.SelectedValue;

                for (int i = 0; i < gridDetalle.Rows.Count; i++)
                {
                    TextBox txtTemp = (TextBox)(gridDetalle.Rows[i].FindControl("txtOBR"));

                    if (valor.Equals("--") == false && valor.Equals("---") == false)
                        txtTemp.Text = valor;
                    else
                        txtTemp.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlOBR(). " + ex.Message;
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {

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
    }
}
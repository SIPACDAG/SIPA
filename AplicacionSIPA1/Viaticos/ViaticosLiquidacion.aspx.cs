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

namespace AplicacionSIPA1.Viaticos
{
    public partial class ViaticosLiquidacion : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private UsuariosLN uUsuariosLN;
        private ViaticosLN pViaticosLN;

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
                txtKilometraje.Text = "0";
                txtPasajes.Text = "0";
                txtViaticos.Text = "0";
                txtPasajePlanificado.Text = "0";
                txtKilometrajePlan.Text = "0";
                filtrarDvPedidos();
                filtrarGridDetalles();
                filtrarGridPpto();
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

                //uUsuariosLN.dropUnidad(ddlUnidades);
                pOperativoLN = new PlanOperativoLN();
                pOperativoLN.DdlUnidades(ddlUnidades, Session["Usuario"].ToString().ToLower());

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

                lblAnio.Text = anioActual.ToString();
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

                pViaticosLN = new ViaticosLN();
                DataSet dsResultado = new DataSet();
                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                if (false)//(!lblErrorPoa.Text.Equals(string.Empty))
                {
                    dvPedido.DataSource = null;
                    dvPedido.DataBind();
                }
                else
                {
                    //if (idPoa > 0)
                    if (true)
                    {
                        dsResultado = pViaticosLN.InformacionViatico(int.Parse(ddlAnios.SelectedValue), 0, 6);

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
                                filtro += " AND id_tipo_viatico = " + rblTipoDocto.SelectedValue;

                            if (txtNo.Text.Equals("") == false || txtNo.Text.Equals(string.Empty) == false)
                                filtro += " AND no_solicitud = " + txtNo.Text;

                            if (!ddlAcciones.SelectedValue.Equals("0"))
                                filtro += " AND id_accion = " + ddlAcciones.SelectedValue;

                            filtro += " AND id_estado_viatico IN (3, 5, 7, 8, 9, 10, 11, 12)";

                            dv.RowFilter = filtro;
                            dvPedido.DataSource = dv;
                            dvPedido.DataBind();

                            int idSalida = 0;

                            if (dvPedido.SelectedValue != null)
                            {
                                int.TryParse(dvPedido.SelectedValue.ToString(), out idSalida);

                                dsResultado = pViaticosLN.InformacionViatico(idSalida, 0, 2);

                                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                                lblPasajes.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PASAJES"].ToString()));
                                txtPasajePlanificado.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PASAJES"].ToString()));
                                lblKilometraje.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["KILOMETRAJE"].ToString()));
                                txtKilometrajePlan.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["KILOMETRAJE"].ToString()));
                                lblViaticos.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["COSTO_VIATICO"].ToString()));

                                txtPasajes.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PASAJES_REAL"].ToString()));
                                txtKilometraje.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["KILOMETRAJE_REAL"].ToString()));
                                txtViaticos.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["COSTO_REAL"].ToString()));
                                if (txtViaticos.Text == "Q.00.00")
                                {
                                    txtViaticos.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["COSTO_VIATICO"].ToString()));
                                }
                                lblViaticosEstimado.Text = (decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PASAJES_ESTIMADO"].ToString()) + decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["KILOMETRAJE_ESTIMADO"].ToString()) + decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["COSTO_ESTIMADO"].ToString())).ToString();

                                ddlPRG.ClearSelection();
                                ddlSPRG.ClearSelection();
                                ddlPROY.ClearSelection();
                                ddlACT.ClearSelection();
                                ddlOBR.ClearSelection();
                                ddlRenglones.ClearSelection();

                                ListItem item = new ListItem();

                                //PROGRAMA
                                string prg = "";
                                if (dsResultado.Tables["BUSQUEDA"].Rows[0]["PRO"].ToString().Equals("null") == false && dsResultado.Tables["BUSQUEDA"].Rows[0]["PRO"].ToString().Equals("") == false && dsResultado.Tables["BUSQUEDA"].Rows[0]["PRO"].ToString().Equals("N/A") == false)
                                {
                                    prg = dsResultado.Tables["BUSQUEDA"].Rows[0]["PRO"].ToString();

                                    item = ddlPRG.Items.FindByValue(prg.ToString());
                                    if (item != null)
                                    {
                                        ddlPRG.SelectedValue = prg.ToString();
                                        ddlPRG_SelectedIndexChanged(new Object(), new EventArgs());
                                    }
                                }

                                //SUBPROGRAMA
                                string sprg = "";
                                if (dsResultado.Tables["BUSQUEDA"].Rows[0]["SPRO"].ToString().Equals("null") == false && dsResultado.Tables["BUSQUEDA"].Rows[0]["SPRO"].ToString().Equals("") == false && dsResultado.Tables["BUSQUEDA"].Rows[0]["SPRO"].ToString().Equals("N/A") == false)
                                {
                                    sprg = dsResultado.Tables["BUSQUEDA"].Rows[0]["SPRO"].ToString();

                                    item = ddlSPRG.Items.FindByValue(sprg.ToString());
                                    if (item != null)
                                    {
                                        ddlSPRG.SelectedValue = sprg.ToString();
                                        ddlSPRG_SelectedIndexChanged(new Object(), new EventArgs());
                                    }
                                }

                                //PROYECTO
                                string proy = "";
                                if (dsResultado.Tables["BUSQUEDA"].Rows[0]["PROY"].ToString().Equals("null") == false && dsResultado.Tables["BUSQUEDA"].Rows[0]["PROY"].ToString().Equals("") == false && dsResultado.Tables["BUSQUEDA"].Rows[0]["PROY"].ToString().Equals("N/A") == false)
                                {
                                    proy = dsResultado.Tables["BUSQUEDA"].Rows[0]["PROY"].ToString();

                                    item = ddlPROY.Items.FindByValue(proy.ToString());
                                    if (item != null)
                                    {
                                        ddlPROY.SelectedValue = proy.ToString();
                                        ddlPROY_SelectedIndexChanged(new Object(), new EventArgs());
                                    }
                                }

                                //ACTIVIDAD
                                string act = "";
                                if (dsResultado.Tables["BUSQUEDA"].Rows[0]["ACT"].ToString().Equals("null") == false && dsResultado.Tables["BUSQUEDA"].Rows[0]["ACT"].ToString().Equals("") == false && dsResultado.Tables["BUSQUEDA"].Rows[0]["ACT"].ToString().Equals("N/A") == false)
                                {
                                    act = dsResultado.Tables["BUSQUEDA"].Rows[0]["ACT"].ToString();

                                    item = ddlACT.Items.FindByValue(act.ToString());
                                    if (item != null)
                                        ddlACT.SelectedValue = act.ToString();
                                }

                                //OBRA
                                string obr = "";
                                if (dsResultado.Tables["BUSQUEDA"].Rows[0]["OBR"].ToString().Equals("null") == false && dsResultado.Tables["BUSQUEDA"].Rows[0]["OBR"].ToString().Equals("") == false)
                                {
                                    obr = dsResultado.Tables["BUSQUEDA"].Rows[0]["OBR"].ToString();

                                    item = ddlOBR.Items.FindByValue(obr.ToString());
                                    if (item != null)
                                        ddlOBR.SelectedValue = obr.ToString();
                                }

                                int idTipoViatico = int.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_TIPO_VIATICO"].ToString());

                                PedidosLN pInsumoLN = new PedidosLN();

                                if (idTipoViatico == 1)
                                    pInsumoLN.DdlRenglonesCodificarPedido(ddlRenglones, idSalida, 0, "", 4);
                                else
                                    pInsumoLN.DdlRenglonesCodificarPedido(ddlRenglones, idSalida, 0, "", 5);

                                //RENGLÓN
                                int idDetalle = 0;
                                if (dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_DETALLE_ACCION"].ToString().Equals("null") == false && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_DETALLE_ACCION"].ToString().Equals("") == false)
                                {
                                    idDetalle = int.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_DETALLE_ACCION"].ToString());

                                    item = ddlRenglones.Items.FindByValue(idDetalle.ToString());
                                    if (item != null)
                                        ddlRenglones.SelectedValue = idDetalle.ToString();
                                }

                                txtObser.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES_RECHAZO"].ToString();
                                validarEstadoViatico(idSalida);
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
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idPedido);

                pViaticosLN = new ViaticosLN();
                DataSet dsResultado = pViaticosLN.InformacionViatico(idPedido, 0, 3);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridDetalle.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridDetalle.DataBind();

                    dsResultado = pViaticosLN.InformacionViatico(idPedido, 0, 2);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());
                }
                else
                {
                    gridDetalle.DataSource = null;
                    gridDetalle.DataBind();
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

                if (dvPedido.Rows.Count > 0)
                    int.TryParse(dvPedido.DataKey[1].ToString(), out idSalida);

                //SALDOS EN BASE A LA ACCIÓN
                tipoSalida = 4;

                PedidosLN pInsumoLN;
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
                filtrarDvPedidos();
                filtrarGridDetalles();
                filtrarGridPpto();
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
                btnLiquidar.Visible = btnRechazar.Visible = false;
                btnAnular.Visible = false;

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
                    btnLiquidar.Visible = btnRechazar.Visible = false;
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa;
                }
                else
                {
                    string estadoPac = dsPoa.Tables[0].Rows[0]["ESTADO_PAC"].ToString();
                    estadoPac = "6 - Aprobado";
                    if (!estadoPac.Split('-')[0].Trim().Equals("6"))
                    {
                        btnLiquidar.Visible = btnRechazar.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El PLAN ANUAL DE COMPRAS seleccionado se encuenta en estado: " + estadoPac;
                    }
                    else
                    {
                        btnLiquidar.Visible = btnRechazar.Visible = true;
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

        protected void validarEstadoViatico(int idViatico)
        {
            try
            {
                if (idViatico == 0)
                {
                    btnLiquidar.Visible = btnRechazar.Visible = btnAnular.Visible = true;
                    lblErrorPoa.Text = lblError.Text = "";
                }
                else
                {
                    btnLiquidar.Visible = btnRechazar.Visible = btnAnular.Visible = false;

                    pViaticosLN = new ViaticosLN();
                    DataSet dsResultado = pViaticosLN.InformacionViatico(idViatico, 0, 2);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del pedido.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al pedido");

                    string estadoViatico = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_VIATICO"].ToString();

                    int idEstadoViatico = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_VIATICO"].ToString(), out idEstadoViatico);

                    //8 - IMPRIMIR, 12 - LIQUIDADO: SE PERMITIRÁ LIQUIDAR
                    if (idEstadoViatico == 8 || idEstadoViatico == 12)
                    {
                        lblErrorPoa.Text = lblError.Text = "";
                    }//3 - RECHAZADO NIVEL I, 5 - RECHAZADO NIVEL II, 7 - RECHAZADO NIVEL III, 9 - RECHAZADO MESA DE ENTRADA, 11 - ANULADO
                    else if (idEstadoViatico == 3 || idEstadoViatico == 5 || idEstadoViatico == 7 || idEstadoViatico == 9 || idEstadoViatico == 11)
                    {
                        lblErrorPoa.Text = lblError.Text = "El VIÁTICO seleccionado se encuenta en estado: " + estadoViatico + ", por: " + dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES_RECHAZO"].ToString();
                    }
                    else if (idEstadoViatico == 2 || idEstadoViatico == 4 || idEstadoViatico == 6 || idEstadoViatico == 10)
                    {
                        lblErrorPoa.Text = lblError.Text = "El VIÁTICO seleccionado se encuenta en estado: " + estadoViatico + " y no se puede modificar ";
                    }

                    //8 - IMPRIMIR, 12 - LIQUIDADO. EN ESTOS CASOS SE PODRÁN LIQUIDAR, RECHAZAR O ANULAR EL VIÁTICO
                    if (idEstadoViatico == 8 || idEstadoViatico == 12)
                        btnLiquidar.Visible = btnRechazar.Visible = btnAnular.Visible = true;

                    //11 - ANULADO. EN ESTE CASO SÓLO SE PÓDRÁ RECHAZAR EL VIÁTICO
                    else if (idEstadoViatico == 11)
                    {
                        btnLiquidar.Visible = false;
                        btnRechazar.Visible = true;
                        btnAnular.Visible = false;
                    }
                    //RECHAZOS: 3 - RECHAZADO NIVEL I, 5 - RECHAZADO NIVEL II, 7 - RECHAZADO NIVEL III, 9 - RECHAZADO MESA DE ENTRADA. EN ESTE CASO SÓLO SE PODRÁ ANULAR EL VIÁTICO
                    else if (idEstadoViatico == 3 || idEstadoViatico == 5 || idEstadoViatico == 7 || idEstadoViatico == 9)
                    {
                        btnLiquidar.Visible = false;
                        btnRechazar.Visible = false;
                        btnAnular.Visible = true;
                    }
                    //INGRESADO Y APROBACIONES: 1 - INGRESADO, 2 - APROBACION NIVEL I,  4 - APROBACION NIVEL II, 6 - APROBACION NIVEL III
                    else if (idEstadoViatico == 1 || idEstadoViatico == 2 || idEstadoViatico == 4 || idEstadoViatico == 6 || idEstadoViatico == 10)
                    {
                        btnLiquidar.Visible = false;
                        btnRechazar.Visible = false;
                        btnAnular.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
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
                filtrarGridPpto();

                PedidosLN pInsumoLN = new PedidosLN();
                pInsumoLN.DdlRenglonesCodificarPedido(ddlRenglones, int.Parse(dvPedido.SelectedValue.ToString()), 0, "", 4);
            }
            catch (Exception ex)
            {
                lblError.Text = "Page_LoadComplete(). " + ex.Message;
            }

        }

        protected void btnLiquidar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                DataSet dsResultado = new DataSet();
                int idPedido = 0;
                decimal pasajesPlanificado = 0;
                decimal kilometrajePlanificado = 0;
                decimal viaticosPlanificado = 0;
                decimal pasajes_plan = 0;

                if (dvPedido.SelectedValue != null)
                {
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idPedido);

                    pViaticosLN = new ViaticosLN();
                    dsResultado = pViaticosLN.InformacionViatico(idPedido, 0, 2);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    lblPasajes.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PASAJES"].ToString()));
                    lblKilometraje.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["KILOMETRAJE"].ToString()));
                    lblViaticos.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["COSTO_VIATICO"].ToString()));

                    pasajesPlanificado = decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PASAJES"].ToString());
                    kilometrajePlanificado = decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["KILOMETRAJE"].ToString());
                    viaticosPlanificado = decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["COSTO_VIATICO"].ToString());
                }

                if (idPedido == 0)
                    throw new Exception("Seleccione un VIÁTICO!");

                string errores = "";
                decimal viaticos, kilometraje, pasajes;
                kilometraje = pasajes = 0;

                FuncionesVarias funciones = new FuncionesVarias();

                string s = txtObser.Text;
                s = s.Replace('\'', ' ');
                s = s.Trim();
                txtObser.Text = s;

                

                viaticos = funciones.StringToDecimal(txtViaticos.Text);

                if (viaticos >= 0 && viaticos <= viaticosPlanificado)
                    txtViaticos.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", viaticos);
                else
                    errores += "Ingrese monto válido. Si el viático a liquidar es mayor al planificado, realice un nuevo nombramiento como complemento. ";

                pasajes = funciones.StringToDecimal(txtPasajes.Text);
                pasajes_plan = funciones.StringToDecimal(txtPasajePlanificado.Text);

                //if (pasajes >= 0 && pasajes <= pasajesPlanificado)
                //    txtPasajes.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pasajes);                    
                //else
                //    errores += "Ingrese pasaje válido. Si el pasaje a liquidar es mayor al planificado, realice un nuevo nombramiento como complemento. ";


                kilometraje = int.Parse(funciones.StringToDecimal(txtKilometraje.Text).ToString().Split('.')[0]);
                kilometrajePlanificado = int.Parse(funciones.StringToDecimal(txtKilometrajePlan.Text).ToString().Split('.')[0]);
                //if (kilometraje >= 0 && kilometraje <= kilometrajePlanificado)
                //    txtKilometraje.Text = kilometraje.ToString();
                //else
                //    errores += "Ingrese kilometraje válido. Si el kilometraje a liquidar es mayor al planificado, realice un nuevo nombramiento como complemento. ";

                dsResultado = new DataSet();
                decimal sumaTotal = viaticos + pasajes + decimal.Parse(kilometraje.ToString());

                if (sumaTotal <= 0)
                    errores += "No se puede liquidar un viático con valor 0. ";
                else
                {

                    //VALIDANDO EL PRESUPUESTO
                    int idAccion = int.Parse(ddlAcciones.SelectedValue);
                    dsResultado = new DataSet();

                    PlanAccionLN planAccionLN = new PlanAccionLN();
                    dsResultado = planAccionLN.InformacionAccionDetalles(int.Parse(ddlRenglones.SelectedValue), 0, "", 6);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        errores += "No se CONSULTÓ el Renglón: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString();

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                    {
                        decimal totalViaticosEstimado = 0;
                        decimal.TryParse(lblViaticosEstimado.Text, out totalViaticosEstimado);

                        decimal montoActual, codificado, saldo = 0;
                        decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["MONTO"].ToString(), out montoActual);
                        decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["CODIFICADO"].ToString(), out codificado);
                        decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["SALDO"].ToString(), out saldo);

                        /*decimal saldoPostAprobacion = codificado - totalViaticosEstimado + sumaTotal;

                        if (saldoPostAprobacion > (saldo + totalViaticosEstimado))
                            errores += "El monto de la liquidación excede por " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (saldo - saldoPostAprobacion)) + " al presupuesto disponible para esta operación: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (saldo + totalViaticosEstimado));
                         * */
                        decimal codificadoPostAprobacion = codificado - totalViaticosEstimado + sumaTotal;

                        if (codificadoPostAprobacion > montoActual)
                            errores += "El monto de la liquidación excede por " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (montoActual - codificadoPostAprobacion)) + " al presupuesto disponible para esta operación: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (saldo));
                    }
                    else
                        errores += "Renglón presupuestario no encontrado: " + ddlRenglones.SelectedItem.Text;
                }

                if (errores.Equals("") == false)
                    throw new Exception(errores);


                validarEstadoViatico(idPedido);

                if (btnLiquidar.Visible == true)
                {
                    if (pasajes <= pasajes_plan)
                    {

                        FuncionesVarias fv = new FuncionesVarias();
                        string[] ip = fv.DatosUsuarios();
                        pViaticosLN = new ViaticosLN();
                        string usuario = Session["usuario"].ToString();
                        string observaciones = txtObser.Text;
                        dsResultado = pViaticosLN.Liquidar(idPedido, observaciones, usuario, viaticos, pasajes_plan, pasajes, kilometrajePlanificado,kilometraje, ip[0], ip[1], ip[2]);

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se ACTUALIZÓ el pedido: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        filtrarDvPedidos();
                        filtrarGridDetalles();
                        filtrarGridPpto();
                        //txtObser.Text = string.Empty;

                        string noAnioSolicitud = dsResultado.Tables[0].Rows[0]["CODIGO"].ToString();
                        lblSuccess.Text = "Viático NO. " + idPedido + noAnioSolicitud + " LIQUIDADO con éxito!";

                        lblSuccess.Focus();
                        validarEstadoViatico(idPedido);
                        //Response.Redirect("NoPedido.aspx?No=" + Convert.ToString(idPedido) + "&msg=PEDIDO" + "&acc=APROBADO");
                    }
                    else
                    {
                        lblError.Text += "El Monto del pasaje liquidado tiene que ser menor o igual al planificado";
                    }

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
                int idPedido = 0;
                if (dvPedido.SelectedValue != null)
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idPedido);

                if (idPedido == 0)
                    throw new Exception("Seleccione un VIÁTICO!");

                string s = txtObser.Text;
                s = s.Replace('\'', ' ');
                s = s.Trim();
                txtObser.Text = s;

                if (txtObser.Text.Equals(string.Empty))
                    lblError.Text = "Llene el campo de observaciones.";
                else
                {
                    validarEstadoViatico(idPedido);

                    if (btnRechazar.Visible == true)
                    {
                        FuncionesVarias fv = new FuncionesVarias();
                        string[] ip = fv.DatosUsuarios();
                        pViaticosLN = new ViaticosLN();
                        string usuario = Session["usuario"].ToString();
                        string observaciones = txtObser.Text;
                        DataSet dsResultado = pViaticosLN.RechazoMesaEntrada(idPedido, observaciones, usuario, ip[0], ip[1], ip[2]);

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se No se ACTUALIZÓ el pedido: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        filtrarDvPedidos();
                        filtrarGridDetalles();
                        filtrarGridPpto();
                        txtObser.Text = string.Empty;

                        string noAnioSolicitud = dsResultado.Tables[0].Rows[0]["CODIGO"].ToString();
                        lblSuccess.Text = "Viático NO. " + noAnioSolicitud + " RECHAZADO con éxito!";

                        lblSuccess.Focus();
                        validarEstadoViatico(idPedido);
                        //Response.Redirect("NoPedido.aspx?No=" + Convert.ToString(idPedido) + "&msg=PEDIDO" + "&acc=RECHAZADO");
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnRechazar(). " + ex.Message;
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
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlOBR(). " + ex.Message;
            }
        }

        protected void ddlRenglonesC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rblTipoDocto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                dvPedido.DataSource = gridDetalle.DataSource = gridSaldos.DataSource = null;
                dvPedido.DataBind();
                gridDetalle.DataBind();
                gridSaldos.DataBind();

                NuevaAprobacion();
            }
            catch (Exception ex)
            {
                lblError.Text = "rblTipoDocto(). " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorPoa.Text = string.Empty;
                NuevaAprobacion();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnBuscar(). " + ex.Message;
            }
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPedido = 0;
                if (dvPedido.SelectedValue != null)
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idPedido);

                if (idPedido == 0)
                    throw new Exception("Seleccione un VIÁTICO!");

                string s = txtObser.Text;
                s = s.Replace('\'', ' ');
                s = s.Trim();
                txtObser.Text = s;

                if (txtObser.Text.Equals(string.Empty))
                    lblError.Text = "Llene el campo de observaciones.";
                else
                {
                    validarEstadoViatico(idPedido);

                    if (btnAnular.Visible == true)
                    {
                        FuncionesVarias fv = new FuncionesVarias();
                        string[] ip = fv.DatosUsuarios();
                        pViaticosLN = new ViaticosLN();
                        string usuario = Session["usuario"].ToString();
                        string observaciones = txtObser.Text;
                        DataSet dsResultado = pViaticosLN.Anular(idPedido, observaciones, usuario, ip[0], ip[1], ip[2]);

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se No se ACTUALIZÓ el pedido: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        filtrarDvPedidos();
                        filtrarGridDetalles();
                        filtrarGridPpto();
                        txtObser.Text = string.Empty;

                        string noAnioSolicitud = dsResultado.Tables[0].Rows[0]["CODIGO"].ToString();
                        lblSuccess.Text = "Viático NO. " + noAnioSolicitud + " ANULADO con éxito!";

                        lblSuccess.Focus();
                        validarEstadoViatico(idPedido);
                        //Response.Redirect("NoPedido.aspx?No=" + Convert.ToString(idPedido) + "&msg=PEDIDO" + "&acc=RECHAZADO");
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnAnular(). " + ex.Message;
            }
        }
    }
}
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

namespace AplicacionSIPA1.Operativa.Seguimiento
{
    public partial class VoBoN2 : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        
        private SeguimientoLN sSeguimientoLN;
        private SEGUIMIENTOS_CMI sSeguimientoEN;
        private SEGUIMIENTOS_CMI_DET sSeguimientoEN_DET;

        private FuncionesVarias funciones;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    limpiarControlesError();
                    NuevoEncabezadoPoa();
                    NuevoSeguimientoEnc();
                    NuevoSeguimientoDet();
                    filtrarGridPpto();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
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

                string usuario = Session["Usuario"].ToString().ToLower();
                //pOperativoLN.DdlUnidadesxAnalista(ddlUnidades, usuario, int.Parse(ddlAnios.SelectedValue));
                pOperativoLN.DdlUnidades(ddlUnidades, usuario);

                if (ddlUnidades.Items.Count == 1)
                {
                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoaIngresoSeguimiento(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                    }
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pOperativoLN = new PlanOperativoLN();
                pOperativoLN.DdlMeses(ddlMeses);
                pAccionLN = new PlanAccionLN();
                ddlMeses.Items[0].Text = "<< Elija un valor >>";
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoPoa(). " + ex.Message);
            }
        }

        public void NuevoSeguimientoEnc()
        {
            try
            {
                lblIdSeguimientoCmi.Text = "0";
                lblNoSeguimientoCmi.Text = "0";
                validarEstadoSeguimiento(0);
                lblEstadoSeguimiento.Text = string.Empty;
                txtObser.Text = string.Empty;
                string usuario = Session["usuario"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoPedidoEnc(). " + ex.Message);
            }
        }

        public void NuevoSeguimientoDet()
        {
            try
            {
                int mes = 0;
                int.TryParse(ddlMeses.SelectedValue, out mes);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                filtrarGridDetalles(idPoa, mes);

            }
            catch (Exception ex)
            {
                throw new Exception("NuevoPedidoDet()(). " + ex.Message);
            }
        }

        protected void filtrarGridDetalles(int idPoa, int mes)
        {
            try
            {
                gridDet.DataSource = null;
                gridDet.DataBind();
                gridDet.SelectedIndex = -1;

                sSeguimientoLN = new SeguimientoLN();
                DataSet dsResultado = sSeguimientoLN.InformacionSeguimientos(idPoa, mes, "", 1);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && mes > 0)
                {
                    gridDet.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridDet.DataBind();
                }
                else
                {
                    gridDet.DataSource = null;
                    gridDet.DataBind();
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
                NuevoSeguimientoEnc();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaIngresoSeguimiento(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pOperativoLN = new PlanOperativoLN();
                pOperativoLN.DdlMeses(ddlMeses);
                ddlMeses.Items[0].Text = "<< Elija un valor >>";

                NuevoSeguimientoDet();
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
                NuevoSeguimientoEnc();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaIngresoSeguimiento(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pOperativoLN = new PlanOperativoLN();
                pOperativoLN.DdlMeses(ddlMeses);
                pAccionLN = new PlanAccionLN();
                ddlMeses.Items[0].Text = "<< Elija un valor >>";

                NuevoSeguimientoDet();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idPoa, mes;
                idPoa = mes = 0;

                int.TryParse(lblIdPoa.Text, out idPoa);
                int.TryParse(ddlMeses.SelectedValue, out mes);

                string criterio = " AND a.id_poa = " + idPoa.ToString() + " AND a.mes = " + mes;

                sSeguimientoLN = new SeguimientoLN();
                DataSet dsResultado = sSeguimientoLN.InformacionSeguimientos(0, 0, criterio, 2);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables.Count == 0)
                    throw new Exception("Error al consultar la información del pedido.");

                if (dsResultado.Tables[1].Rows.Count > 0)
                {

                    lblIdSeguimientoCmi.Text = lblNoSeguimientoCmi.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_SEGUIMIENTO_CMI"].ToString();
                    lblEstadoSeguimiento.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO"].ToString();
                    validarEstadoSeguimiento(int.Parse(lblIdSeguimientoCmi.Text));
                    NuevoSeguimientoDet();
                    
                }
                else
                {
                    NuevoSeguimientoEnc();
                    gridDet.DataSource = null;
                    gridDet.DataBind();
                }
                
                filtrarGridPpto();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlMeses(). " + ex.Message;
            }
        }

        protected DataSet armarDsDet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("id", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Mes", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Cantidad", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Monto", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Subtotal", Type.GetType("System.String"));

            return ds;
        }


        protected void limpiarControlesError()
        {
            lblErrorPoa.Text = string.Empty;
            lblErrorPlan.Text = string.Empty;
            lblErrorAnio.Text = lblErrorUnidad.Text = string.Empty;
            lblErrorAccion.Text = string.Empty;
            lblErrorObservaciones.Text = string.Empty;
            lblError.Text = lblSuccess.Text = string.Empty;

        }

        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                

                string observaciones = "";
                observaciones = txtObser.Text;
                observaciones = observaciones.Replace('\'', ' ').Replace(';', ' ');
                observaciones = observaciones.Trim();
                txtObser.Text = observaciones;

                if (observaciones.Equals(""))
                    lblErrorObservaciones.Text = lblError.Text = "Llene el campo observaciones ";

                if (lblError.Text.Equals(string.Empty))
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


        private bool validarControlesABCDetalle(int indexGrid)
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                Label lblErrorAvanceKpi = (gridDet.Rows[gridDet.SelectedIndex].FindControl("lblErrorAvanceKpi") as Label);
                string sAvanceKpi = (gridDet.Rows[gridDet.SelectedIndex].FindControl("txtAvanceKpi") as Label).Text;
                sAvanceKpi = sAvanceKpi.Replace('\'', ' ').Replace(';', ' ');
                sAvanceKpi = sAvanceKpi.Trim();
                (gridDet.Rows[gridDet.SelectedIndex].FindControl("txtAvanceKpi") as Label).Text = sAvanceKpi;

                if (sAvanceKpi.Equals(""))
                    lblErrorAvanceKpi.Text = "Ingrese un valor";
                else
                {
                    decimal valor = 0;
                    decimal.TryParse(sAvanceKpi, out valor);

                    if (valor < 0)
                        lblErrorAvanceKpi.Text = "Ingrese un valor > a cero (0)";
                    else
                        lblErrorAvanceKpi.Text = string.Empty;

                }

                Label lblErrorDescripcionAvanceKpi = (gridDet.Rows[gridDet.SelectedIndex].FindControl("lblErrorDescripcionAvanceKpi") as Label);
                string sDescripcionAvanceKpi = (gridDet.Rows[gridDet.SelectedIndex].FindControl("txtDescripcionAvanceKpi") as Label).Text;
                sDescripcionAvanceKpi = sDescripcionAvanceKpi.Replace('\'', ' ').Replace(';', ' ');
                sDescripcionAvanceKpi = sDescripcionAvanceKpi.Trim();
                (gridDet.Rows[gridDet.SelectedIndex].FindControl("txtDescripcionAvanceKpi") as Label).Text = sDescripcionAvanceKpi;

                if (sDescripcionAvanceKpi.Equals(""))
                    lblErrorDescripcionAvanceKpi.Text = "Ingrese un valor";
                else
                    lblErrorDescripcionAvanceKpi.Text = string.Empty;

                Label lblErrorObservacionesDge = (gridDet.Rows[gridDet.SelectedIndex].FindControl("lblErrorObservacionesDge") as Label);
                string sObservacionesDge = (gridDet.Rows[gridDet.SelectedIndex].FindControl("txtObservacionesDge") as TextBox).Text;
                sObservacionesDge = sObservacionesDge.Replace('\'', ' ').Replace(';', ' ');
                sObservacionesDge = sObservacionesDge.Trim();
                (gridDet.Rows[gridDet.SelectedIndex].FindControl("txtObservacionesDge") as TextBox).Text = sObservacionesDge;

                if (sObservacionesDge.Equals(""))
                    lblErrorObservacionesDge.Text = "Ingrese un valor";
                else
                    lblErrorObservacionesDge.Text = string.Empty;


                if (lblErrorAvanceKpi.Text.Equals(string.Empty) && lblErrorDescripcionAvanceKpi.Text.Equals(string.Empty) && lblErrorObservacionesDge.Text.Equals(string.Empty))
                    controlesValidos = true;

                Page.Validate();
                if (controlesValidos && Page.IsValid)
                    controlesValidos = true;
                else
                    controlesValidos = false;
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABCDetalle(). " + ex.Message);
            }
            return controlesValidos;
        }

        protected bool validarPoaIngresoSeguimiento(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                btnAprobar.Visible = btnRechazar.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
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
                    btnAprobar.Visible = btnRechazar.Visible = true;
                    poaValido = true;
                    lblErrorPoa.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            return poaValido;            
        }

        protected bool validarEstadoSeguimiento(int idSeguimiento)
        {
            bool seguimientoValido = false;
            try
            {
                btnAprobar.Visible = btnRechazar.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;

                DataSet dsResultado = new DataSet();
                int idEstadoSeguimiento = 0;

                if (idSeguimiento == 0)
                {
                    if (lblErrorPoa.Text.Equals("") || lblErrorPoa.Equals(string.Empty))
                    {
                        lblEstadoSeguimiento.Text = "";
                        btnAprobar.Visible = btnRechazar.Visible = /*gridDet.Columns[0].Visible = gridDet.Columns[1].Visible =*/ true;
                        lblErrorPoa.Text = lblError.Text = "";
                        seguimientoValido = true;
                    }
                    else
                        seguimientoValido = false;
                }
                else
                {
                    btnAprobar.Visible = btnRechazar.Visible = /*gridDet.Columns[0].Visible = gridDet.Columns[1].Visible =*/ false;

                    int idPoa, mes;
                    idPoa = mes = 0;

                    int.TryParse(lblIdPoa.Text, out idPoa);
                    int.TryParse(ddlMeses.SelectedValue, out mes);

                    string criterio = " AND a.id_poa = " + idPoa.ToString() + " AND a.mes = " + mes;

                    sSeguimientoLN = new SeguimientoLN();
                    dsResultado = sSeguimientoLN.InformacionSeguimientos(0, 0, criterio, 2);
                    
                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del pedido.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al pedido");

                    lblEstadoSeguimiento.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO"].ToString();
                    txtFechaRecepcion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["FECHA_RECEPCION_TEXT_BOX"].ToString();

                    idEstadoSeguimiento = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO"].ToString(), out idEstadoSeguimiento);

                    //EL SEGUIMIENTO ESTÁ EN ESTADO 4	Revisión Analista POA
                    if (idEstadoSeguimiento == 4)
                    {
                        btnAprobar.Visible = btnRechazar.Visible = /*gridDet.Columns[0].Visible = gridDet.Columns[1].Visible =*/ true;
                        lblErrorPoa.Text = lblError.Text = "";
                        seguimientoValido = true;
                    }//EL SEGUIMIENTO ESTÁ EN ESTADO 3	Rechazado Subgerencia, 6	Rechazado Analista POA, 8	Rechazado Dirección SE PUEDE MODIFICAR
                    else if (idEstadoSeguimiento == 3 || idEstadoSeguimiento == 6 || idEstadoSeguimiento == 8)
                    {
                        btnAprobar.Visible = btnRechazar.Visible = /*gridDet.Columns[0].Visible = gridDet.Columns[1].Visible =*/ false;
                        lblErrorPoa.Text = lblError.Text = "El SEGUIMIENTO seleccionado se encuenta en estado: " + lblEstadoSeguimiento.Text + ", por: " + dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES_RECHAZO"].ToString();
                        seguimientoValido = true;

                    }//EL SEGUIMIENTO ESTÁ EN ESTADO 1 - Ingresado, 2	Revisión Subgerencia, 7, Revisión Dirección, 9	Aprobado Dirección Y NO SE PUEDE MODIFICAR
                    else if (idEstadoSeguimiento == 1 || idEstadoSeguimiento == 2 || idEstadoSeguimiento == 7 || idEstadoSeguimiento == 9)
                    {
                        btnAprobar.Visible = btnRechazar.Visible = /*gridDet.Columns[0].Visible = gridDet.Columns[1].Visible =*/ false;
                        lblErrorPoa.Text = lblError.Text = "El SEGUIMIENTO seleccionado se encuenta en estado: " + lblEstadoSeguimiento.Text + " y no se puede modificar ";
                        seguimientoValido = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            return seguimientoValido;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idSeguimiento = 0;
                int.TryParse(lblIdSeguimientoCmi.Text, out idSeguimiento);

                //if (validarControlesABC())
                {
                    if (validarEstadoSeguimiento(idSeguimiento))
                    {
                        if (idSeguimiento == 0)
                            throw new Exception("No existe Informe para APROBAR");

                        sSeguimientoLN = new SeguimientoLN();
                        DataSet dsResultado = new DataSet();

                        dsResultado = sSeguimientoLN.AprobadoN2(idSeguimiento, "", Session["usuario"].ToString());

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        dsResultado = sSeguimientoLN.InformacionSeguimientos(0, 0, " AND a.id_seguimiento_cmi = " + idSeguimiento.ToString(), 2);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        lblEstadoSeguimiento.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO"].ToString();

                        lblSuccess.Text = "Informe APROBADO con éxito!. El informe fue enviado al estado: " + lblEstadoSeguimiento.Text + ". ";
                        btnAprobar.Visible = btnRechazar.Visible = false;
                        //Para enviar correos.
                        //EnvioDeCorreos envio = new EnvioDeCorreos();
                        //envio.EnvioCorreo("alfredo.ochoa@cdag.com.gt", "Nueva Requisicion: " + lblNoPedido.Text, mensaje);

                        Response.Redirect("~/Operativa/Seguimiento/NoSeguimiento.aspx?No=" + lblNoSeguimientoCmi.Text + "&msg=ANALISTA" + "&acc=" + lblSuccess.Text);
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
                int idSeguimiento = 0;
                int.TryParse(lblIdSeguimientoCmi.Text, out idSeguimiento);

                if (validarControlesABC())
                {
                    if (validarEstadoSeguimiento(idSeguimiento))
                    {
                        if (idSeguimiento == 0)
                            throw new Exception("No existe Informe para RECHAZAR");

                        sSeguimientoLN = new SeguimientoLN();
                        DataSet dsResultado = new DataSet();

                        dsResultado = sSeguimientoLN.RechazadoN2(idSeguimiento, txtObser.Text, Session["usuario"].ToString());

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        dsResultado = sSeguimientoLN.InformacionSeguimientos(0, 0, " AND a.id_seguimiento_cmi = " + idSeguimiento.ToString(), 2);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        lblEstadoSeguimiento.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO"].ToString();

                        lblSuccess.Text = "Informe RECHAZADO con éxito!. El informe fue enviado al estado: " + lblEstadoSeguimiento.Text + ". ";
                        btnAprobar.Visible = btnRechazar.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnRechazar(). " + ex.Message;
            }
        }

        protected void ddlFADN_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void rblAnexos_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            /*try
            {
                limpiarControlesError();
                int idPedido = 0;
                int.TryParse(lblIdSeguimientoCmi.Text, out idPedido);

                if (idPedido  == 0)
                    throw new Exception("No existe Bien/Servicio para eliminar");

                sSeguimientoLN = new PedidosLN();
                DataSet dsResultado = sSeguimientoLN.EliminarEncabezado(idPedido);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                NuevoEncabezadoPoa();
                NuevoPedidoEnc();
                NuevoPedidoDet();

                lblSuccess.Text = "Pedido eliminado correctamente!";

                Response.Redirect("NoPedido.aspx?No=" + lblNoSeguimientoCmi.Text + "&msg=PEDIDO" + "&acc=ELIMINADO");
            }
            catch (Exception ex)
            {
                lblError.Text = "btnAnular(). " + ex.Message;
            }*/
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

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

                int.TryParse(ddlMeses.SelectedValue, out idSalida);

                //SALDOS EN BASE A LA ACCIÓN
                tipoSalida = 4;

                PedidosLN pInsumosLN = new PedidosLN();
                DataSet dsResultado = pInsumosLN.PptoAprobacionSubgerente(idSalida, 0, "", tipoSalida);

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

        protected void gridDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (validarControlesABCDetalle(gridDet.SelectedIndex))
                {
                    int idSeguimientoCmi, idPoa, idUnidad, anio, noCuatrimestre, mes = 0;

                    int.TryParse(lblIdSeguimientoCmi.Text, out idSeguimientoCmi);
                    int.TryParse(lblIdPoa.Text, out idPoa);
                    int.TryParse(ddlUnidades.SelectedValue.ToString(), out idUnidad);
                    int.TryParse(ddlAnios.SelectedValue.ToString(), out anio);
                    int.TryParse(ddlMeses.SelectedValue.ToString(), out mes);

                    noCuatrimestre = 0;
                    if (mes >= 1 && mes <= 4)
                        noCuatrimestre = 1;
                    else if (mes >= 5 && mes <= 8)
                        noCuatrimestre = 2;
                    else if (mes >= 9 && mes <= 12)
                        noCuatrimestre = 3;

                    sSeguimientoEN = new SEGUIMIENTOS_CMI();

                    sSeguimientoEN.ID_SEGUIMIENTO_CMI = idSeguimientoCmi.ToString();
                    sSeguimientoEN.ID_POA = idPoa.ToString();
                    sSeguimientoEN.ID_UNIDAD = idUnidad.ToString();
                    sSeguimientoEN.ANIO = anio.ToString();
                    sSeguimientoEN.NO_CUATRIMESTRE = noCuatrimestre.ToString();
                    sSeguimientoEN.MES = mes.ToString();
                    sSeguimientoEN.ID_ESTADO = "1";
                    sSeguimientoEN.ANEXO = "";
                    sSeguimientoEN.ID_SEGUIMIENTO_CALENDARIO = "0";
                    sSeguimientoEN.OBSERVACIONES_RECHAZO = "";
                    sSeguimientoEN.OBSERVACIONES_DGE = "";
                    sSeguimientoEN.FECHA_RECEPCION = "";
                    sSeguimientoEN.ACTIVO = "1";
                    sSeguimientoEN.USUARIO = Session["usuario"].ToString();

                    int idSeguimientoCmiDet, idAccion = 0;

                    sSeguimientoEN_DET = new SEGUIMIENTOS_CMI_DET();
                    DataSet dsDetalles = sSeguimientoEN_DET.armarDsSeguimientoDetalles();

                    funciones = new FuncionesVarias();

                    int.TryParse(gridDet.SelectedDataKey["ID_SEGUIMIENTO_CMI_DET"].ToString(), out idSeguimientoCmiDet);
                    int.TryParse(gridDet.SelectedDataKey["ID_ACCION"].ToString(), out idAccion);

                    string sPptoAnual = gridDet.SelectedDataKey["PPTO_ANUAL"].ToString();
                    string sAvancePptoCuatrimestral = gridDet.SelectedDataKey["AVANCE_PPTO_CUATRIMESTRAL"].ToString();
                    string sAvancePptoAcumulado = gridDet.SelectedDataKey["AVANCE_PPTO_ACUMULADO"].ToString();
                    string sSaldo = gridDet.SelectedDataKey["SALDO"].ToString();

                    string sDescripcion = gridDet.SelectedDataKey["DESCRIPCION"].ToString();
                    string sMediosVerificacion = gridDet.SelectedDataKey["MEDIOS_VERIFICACION"].ToString();

                    string sAvanceKpi = (gridDet.Rows[gridDet.SelectedIndex].FindControl("txtAvanceKpi") as Label).Text;
                    string sDescripcionAvanceKpi = (gridDet.Rows[gridDet.SelectedIndex].FindControl("txtDescripcionAvanceKpi") as Label).Text;
                    string sObservacionesDge = (gridDet.Rows[gridDet.SelectedIndex].FindControl("txtObservacionesDge") as TextBox).Text;
                    

                    decimal dPptoAnual = funciones.StringToDecimal(sPptoAnual);
                    decimal dAvancePptoCuatrimestral = funciones.StringToDecimal(sAvancePptoCuatrimestral);
                    decimal dAvancePptoAcumulado = funciones.StringToDecimal(sAvancePptoAcumulado);
                    decimal dSaldo = funciones.StringToDecimal(sSaldo);

                    decimal dAvanceKpi = funciones.StringToDecimal(sAvanceKpi);
                    
                    DataRow dr = dsDetalles.Tables[0].NewRow();

                    dr["ID_SEGUIMIENTO_CMI_DET"] = idSeguimientoCmiDet.ToString();
                    dr["ID_SEGUIMIENTO_CMI"] = idSeguimientoCmi.ToString();
                    dr["ID_ACCION"] = idAccion.ToString();
                    dr["DESCRIPCION"] = sDescripcion;
                    dr["PPTO_ANUAL"] = dPptoAnual.ToString();
                    dr["AVANCE_PPTO_CUATRIMESTRAL"] = dAvancePptoCuatrimestral.ToString();
                    dr["AVANCE_PPTO_ACUMULADO"] = dAvancePptoAcumulado.ToString();
                    dr["SALDO"] = dSaldo.ToString();
                    dr["MEDIOS_VERIFICACION"] = sMediosVerificacion;
                    dr["AVANCE_KPI"] = dAvanceKpi.ToString();
                    dr["DESCRIPCION_AVANCE_KPI"] = sDescripcionAvanceKpi; 
                    dr["ANEXO"] = "";
                    dr["OBSERVACIONES_DGE"] = sObservacionesDge;
                    dr["Plan_accion"] = "0";
                    dr["ACTIVO"] = "1";
                    dr["USUARIO"] = Session["usuario"].ToString();

                    dsDetalles.Tables[0].Rows.Add(dr);
                    if (validarEstadoSeguimiento(idSeguimientoCmi))
                    {
                        sSeguimientoLN = new SeguimientoLN();
                        DataSet dsResultado = sSeguimientoLN.AlmacenarSeguimiento(sSeguimientoEN,Session["usuario"].ToString());
                        dsResultado = sSeguimientoLN.AlmacenarSeguimientoDet(dsDetalles, 3);
                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ el informe de seguimiento al CMI: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        //int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idSeguimientoCmi);
                        //lblIdSeguimientoCmi.Text = lblNoSeguimientoCmi.Text = idSeguimientoCmi.ToString();

                        //NuevoSeguimientoDet();
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('ALMACENADO/MODIFICADO exitosamente!');", true);
                        lblSuccess.Text = "ALMACENADO/MODIFICADO exitosamente!";
                        filtrarGridDetalles(int.Parse(lblIdPoa.Text), int.Parse(ddlMeses.SelectedValue));
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "gridDet(). " + ex.Message;
            }
        }

        protected void btnGuardarFecha_Click(object sender, EventArgs e)
        {
            try
            {
                int idSeguimientoCmi, idPoa, idUnidad, anio, noCuatrimestre, mes = 0;

                int.TryParse(lblIdSeguimientoCmi.Text, out idSeguimientoCmi);
                int.TryParse(lblIdPoa.Text, out idPoa);
                int.TryParse(ddlUnidades.SelectedValue.ToString(), out idUnidad);
                int.TryParse(ddlAnios.SelectedValue.ToString(), out anio);
                int.TryParse(ddlMeses.SelectedValue.ToString(), out mes);

                funciones = new FuncionesVarias();
                DataSet dsFecha = funciones.StringToFechaMySql(txtFechaRecepcion.Text);

                if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                    throw new Exception(dsFecha.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                string fechaTemp = txtFechaRecepcion.Text;
                string fechaRecepcion = dsFecha.Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                if (validarEstadoSeguimiento(idSeguimientoCmi))
                {
                    noCuatrimestre = 0;
                    if (mes >= 1 && mes <= 4)
                        noCuatrimestre = 1;
                    else if (mes >= 5 && mes <= 8)
                        noCuatrimestre = 2;
                    else if (mes >= 9 && mes <= 12)
                        noCuatrimestre = 3;

                    sSeguimientoEN = new SEGUIMIENTOS_CMI();

                    sSeguimientoEN.ID_SEGUIMIENTO_CMI = idSeguimientoCmi.ToString();
                    sSeguimientoEN.ID_POA = idPoa.ToString();
                    sSeguimientoEN.ID_UNIDAD = idUnidad.ToString();
                    sSeguimientoEN.ANIO = anio.ToString();
                    sSeguimientoEN.NO_CUATRIMESTRE = noCuatrimestre.ToString();
                    sSeguimientoEN.MES = mes.ToString();
                    sSeguimientoEN.ID_ESTADO = "1";
                    sSeguimientoEN.ANEXO = "";
                    sSeguimientoEN.ID_SEGUIMIENTO_CALENDARIO = "0";
                    sSeguimientoEN.OBSERVACIONES_RECHAZO = "";
                    sSeguimientoEN.OBSERVACIONES_DGE = "";
                    sSeguimientoEN.FECHA_RECEPCION = fechaRecepcion;
                    sSeguimientoEN.ACTIVO = "1";
                    sSeguimientoEN.USUARIO = Session["usuario"].ToString();

                    sSeguimientoLN = new SeguimientoLN();
                    DataSet dsResultado = sSeguimientoLN.AlmacenarFechaRecepcion(sSeguimientoEN,Session["usuario"].ToString());

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ la fecha de recepción de seguimiento al CMI: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    txtFechaRecepcion.Text = fechaTemp;
                    lblSuccess.Text = "Fecha de recepción de informe de seguimiento al CMI No. " + idSeguimientoCmi.ToString() + " ALMACENADO/MODIFICADO exitosamente: ";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardarFecha(). " + ex.Message;
            }
        }

        protected void chkFiltroColumnas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridDet.Columns.Count > 0)
                {
                    for (int i = 0; i < chkFiltroColumnas.Items.Count; i++)
                    {
                        if (chkFiltroColumnas.Items[i].Selected == true)
                            gridDet.Columns[int.Parse(chkFiltroColumnas.Items[i].Value)].Visible = true;
                        else
                            gridDet.Columns[int.Parse(chkFiltroColumnas.Items[i].Value)].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "chkFiltroColumnas(). " + ex.Message;
            }
        }
    }
}
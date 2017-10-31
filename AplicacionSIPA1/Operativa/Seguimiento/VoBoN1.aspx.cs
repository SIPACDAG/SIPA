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
    public partial class VoBoN1 : System.Web.UI.Page
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
                pOperativoLN.DdlDependencias(ddlDependencia, idUnidad.ToString());
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

                    idEstadoSeguimiento = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO"].ToString(), out idEstadoSeguimiento);

                    //EL SEGUIMIENTO ESTÁ EN ESTADO 2	Revisión Subgerencia
                    if (idEstadoSeguimiento == 2)
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

                    }//EL SEGUIMIENTO ESTÁ EN ESTADO 1 - Ingresado, 4	Revisión Analista POA, 7, Revisión Dirección, 9	Aprobado Dirección Y NO SE PUEDE MODIFICAR
                    else if (idEstadoSeguimiento == 1 || idEstadoSeguimiento == 4 || idEstadoSeguimiento == 7 || idEstadoSeguimiento == 9)
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

                        dsResultado = sSeguimientoLN.AprobadoN1(idSeguimiento, "", Session["usuario"].ToString());

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

                        Response.Redirect("~/Operativa/Seguimiento/NoSeguimiento.aspx?No=" + lblNoSeguimientoCmi.Text + "&msg=SUBGERENCIA" + "&acc=" + lblSuccess.Text);
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

                        dsResultado = sSeguimientoLN.RechazadoN1(idSeguimiento, txtObser.Text, Session["usuario"].ToString());

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

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoSeguimientoEnc();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlDependencia.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaIngresoSeguimiento(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pOperativoLN = new PlanOperativoLN();
                pOperativoLN.DdlMeses(ddlMeses);
                pOperativoLN.DdlDependencias(ddlJefaturaUnidad, idUnidad.ToString());
                pAccionLN = new PlanAccionLN();
                ddlMeses.Items[0].Text = "<< Elija un valor >>";

                NuevoSeguimientoDet();
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
                NuevoSeguimientoEnc();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlJefaturaUnidad.SelectedValue, out idUnidad);

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
    }
}
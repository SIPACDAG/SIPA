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
using AplicacionSIPA1.WsTipoCambio;

namespace AplicacionSIPA1.Viaticos
{
    public partial class ViaticosIngresoExt : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;

        private ViaticosLN pViaticosLN;
        private ViaticosEN pViaticosEN;

        private EmpleadosLN eEmpleadosLN;

        public DateTime fechaNombramiento
        {
            get
            {
                object o = ViewState["fechaNombramiento"];
                return (DateTime)o;
            }
            set { ViewState["fechaNombramiento"] = value; }
        }

        public DateTime fechaIniComision
        {
            get
            {
                object o = ViewState["fechaIniComision"];
                return (DateTime)o;
            }
            set { ViewState["fechaIniComision"] = value; }
        }

        public DateTime fechaFinComision
        {
            get
            {
                object o = ViewState["fechaFinComision"];
                return (DateTime)o;
            }
            set { ViewState["fechaFinComision"] = value; }
        }

        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    try
                    {
                        TipoCambioSoapClient tCambioSoap = new TipoCambioSoapClient();
                        string tipoCambio = tCambioSoap.TipoCambioDiaString();
                        lblTipoCambio.Text = lblTipoCambioDS.Text = tipoCambio;
                    }
                    catch (Exception ex)
                    {
                        if (Convert.ToString(Request.QueryString["No"]) != null)
                        {
                        }
                        else
                            throw new Exception(ex.Message);
                    }
                    btnNuevo_Click(sender, e);

                    string s = Convert.ToString(Request.QueryString["No"]);

                    if (s != null && lblError.Text.Equals(string.Empty))
                    {
                        int idEncabezado = 0;
                        int.TryParse(s, out idEncabezado);

                        pViaticosLN = new ViaticosLN();
                        DataSet dsResultado = pViaticosLN.InformacionViatico(idEncabezado, 0, 2);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables.Count == 0)
                            throw new Exception("Error al consultar la información del viático.");

                        if (dsResultado.Tables[0].Rows.Count == 0)
                            throw new Exception("No existe información del viático");

                        //lblTipoCambio.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["FECHA_ING"].ToString() + " - " + dsResultado.Tables["BUSQUEDA"].Rows[0]["TASA_DE_CAMBIO"].ToString();
                        lblTipoCambio.Text = lblTipoCambioDS.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["TASA_DE_CAMBIO_DS"].ToString();

                        int idPlan, anio, idUnidad, idAccion, idJefeDirector, idSubgerente, idTipoPersona, idSolicitante, idPuesto, vehiculoCDAG, idCategoria = 0;
                        string idGrupoPaises = "";

                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_PLAN"].ToString(), out idPlan);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO_POA"].ToString(), out anio);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_UNIDAD_POA"].ToString(), out idUnidad);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ACCION"].ToString(), out idAccion);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_JEFE_DIRECTOR"].ToString(), out idJefeDirector);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_SUBGERENTE"].ToString(), out idSubgerente);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_TIPO_PERSONA"].ToString(), out idTipoPersona);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_SOLICITANTE"].ToString(), out idSolicitante);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_PUESTO"].ToString(), out idPuesto);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["UTILIZA_VEHICULO"].ToString(), out vehiculoCDAG);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_CATEGORIA"].ToString(), out idCategoria);
                        idGrupoPaises = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_GRUPO_PAISES"].ToString();


                        ListItem item = ddlPlanes.Items.FindByValue(idPlan.ToString());
                        if (item != null)
                        {
                            ddlPlanes.SelectedValue = idPlan.ToString();
                            ddlPlanes_SelectedIndexChanged(sender, e);
                        }

                        item = ddlAnios.Items.FindByValue(anio.ToString());
                        if (item != null)
                        {
                            ddlAnios.SelectedValue = anio.ToString();
                            ddlAnios_SelectedIndexChanged(sender, e);
                        }

                        item = ddlUnidades.Items.FindByValue(idUnidad.ToString());
                        if (item != null)
                        {
                            ddlUnidades.SelectedValue = idUnidad.ToString();
                            ddlUnidades_SelectedIndexChanged(sender, e);
                        }

                        item = ddlAcciones.Items.FindByValue(idAccion.ToString());
                        if (item != null)
                        {
                            ddlAcciones.SelectedValue = idAccion.ToString();
                            ddlAcciones_SelectedIndexChanged(sender, e);
                        }

                        item = ddlJefeDirector.Items.FindByValue(idJefeDirector.ToString());
                        if (item != null)
                        {
                            ddlJefeDirector.SelectedValue = idJefeDirector.ToString();
                            ddlJefeDirector_SelectedIndexChanged(sender, e);
                        }

                        item = ddlSubgerente.Items.FindByValue(idSubgerente.ToString());
                        if (item != null)
                        {
                            ddlSubgerente.SelectedValue = idSubgerente.ToString();
                            ddlSubgerente_SelectedIndexChanged(sender, e);
                        }

                        item = rblTipoPersonal.Items.FindByValue(idTipoPersona.ToString());
                        if (item != null)
                        {
                            rblTipoPersonal.SelectedValue = idTipoPersona.ToString();
                            rblTipoPersonal_SelectedIndexChanged(sender, e);
                        }

                        if (rblTipoPersonal.SelectedValue.Equals("1"))
                        {
                            item = ddlEmpleados.Items.FindByValue(idSolicitante.ToString());
                            if (item != null)
                            {
                                ddlEmpleados.SelectedValue = idSolicitante.ToString();
                                ddlEmpleados_SelectedIndexChanged(sender, e);
                            }

                            item = ddlPuestos.Items.FindByValue(idPuesto.ToString());
                            if (item != null)
                            {
                                ddlPuestos.SelectedValue = idPuesto.ToString();
                                ddlPuestos_SelectedIndexChanged(sender, e);
                            }
                        }
                        
                        item = ddlCategorias.Items.FindByValue(idCategoria.ToString());
                        if (item != null)
                        {
                            ddlCategorias.SelectedValue = idCategoria.ToString();
                        }
                        
                        item = ddlGrupos.Items.FindByValue(idGrupoPaises.ToString());
                        if (item != null)
                        {
                            ddlGrupos.SelectedValue = idGrupoPaises.ToString();                            
                        }
                        ddlCategorias_SelectedIndexChanged(sender, e);

                        int retornoExterior = int.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["RETORNO_AL_EXTERIOR"].ToString());

                        chkSalida.Checked = false;

                        if (retornoExterior == 1)
                            chkSalida.Checked = true;

                        txtFecha.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["FECHA_STRING_FORMAT"].ToString();
                        txtDependencia.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE_DEPENDENCIA"].ToString();
                        txtNombre.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE_SOLICITANTE"].ToString();
                        txtEmail.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["EMAIL"].ToString();
                        txtNit.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NIT"].ToString();
                        txtTelefono.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["TELEFONO"].ToString();
                        txtSueldoBase.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["SUELDO_BASE"].ToString();
                        txtJustificacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["JUSTIFICACION"].ToString();
                        txtDestino.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DESTINO"].ToString();

                        txtFechaIni.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["FECHA_INI_STRING_FORMAT"].ToString();
                        txtFechaFin.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["FECHA_FIN_STRING_FORMAT"].ToString();                        

                        txtObservaciones.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES_VIATICOS"].ToString();

                        txtCuotaDiaria.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["CUOTA_DIARIA"].ToString();

                        lblIdEncabezado.Text = idEncabezado.ToString();

                        lblNoEncabezado.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_SOLICITUD"].ToString();
                        lblAnio.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO_SOLICITUD"].ToString();
                        filtrarGridDetalles(idEncabezado);
                        validarEstadoSolicitud(idEncabezado);
                        ddlPlanes.Enabled = ddlAnios.Enabled = ddlUnidades.Enabled = /*ddlAcciones.Enabled =*/ false;
                    }
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
                        validarPoaIngreso(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                    }
                    inicialesUnidad();
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 5);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";
                ddlPlanes.Enabled = ddlAnios.Enabled = ddlAcciones.Enabled = true;

                ddlAnios.Enabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoPoa(). " + ex.Message);
            }
        }

        public void inicialesUnidad()
        {

            int codigoUnidad = 0;
            int.TryParse(ddlUnidades.SelectedItem.Text.Split('-')[0].Trim(), out codigoUnidad);
            
            string iniciales = "";

            switch (codigoUnidad)
            {
                case 1:
                    iniciales =  "DS";
                    break;
                case 2:
                    iniciales = "SGF";
                    break;
                case 3:
                    iniciales = "SGA";
                    break;
                case 4:
                    iniciales = "AJ";
                    break;
                case 5:
                    iniciales = "AI";
                    break;
                case 6:
                    iniciales = "DC";
                    break;
                case 7:
                    iniciales = "SGN";
                    break;
                case 8:
                    iniciales = "ATF";
                    break;
                case 9:
                    iniciales = "SDI";
                    break;
                case 10:
                    iniciales = "SDH";
                    break;
                case 11:
                    iniciales = "SGT";
                    break;
                case 12:
                    iniciales = "CCAA";
                    break;
                case 13:
                    iniciales = "S/N";
                    break;
                case 14:
                    iniciales = "SGI";
                    break;
                default:
                    iniciales = "S/A";
                    break;
            }
            
            lblUnidadAbr.Text = iniciales;
            lblAnio.Text = ddlAnios.SelectedValue;
        }

        public void NuevoEnc()
        {
            try
            {

                lblIdEncabezado.Text = lblNoEncabezado.Text = lblUnidadAbr.Text = lblAnio.Text = "0";
                lblTotalQ.Text = lblTotalD.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
                validarEstadoSolicitud(0);
                inicialesUnidad();
                lblEstado.Text = string.Empty;
                string usuario = Session["usuario"].ToString();
                int idUnidad = 0;
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                /*System.IO.StringReader srDatos = new System.IO.StringReader(lblTipoCambio.Text);
                DataSet dsTipoCambio = new DataSet();
                dsTipoCambio.ReadXml(srDatos);*/

                //lblTipoCambio.Text = dsTipoCambio.Tables["VarDolar"].Rows[0]["fecha"].ToString() + " - " + dsTipoCambio.Tables["VarDolar"].Rows[0]["referencia"].ToString();

                pViaticosLN = new ViaticosLN();
                pViaticosLN.DdlJefes(ddlJefeDirector, usuario, idUnidad);
                pViaticosLN.DdlSubgerentes(ddlSubgerente, usuario, idUnidad);
                pViaticosLN.DdlDetCategorias(ddlCategorias, 2, 0, "", 8);
                pViaticosLN.DdlDetGrupos(ddlGrupos, 0, 0, "", 9);

                txtFecha.Text = DateTime.Today.ToString();
                txtDependencia.Text = string.Empty;

                ListItem item = rblTipoPersonal.Items.FindByValue("1");
                if (item != null)
                {
                    rblTipoPersonal.SelectedValue = "1";
                    rblTipoPersonal_SelectedIndexChanged(new Object(), new EventArgs());
                }

                item = rblCategoria.Items.FindByValue("1");
                if (item != null)
                {
                    rblCategoria.SelectedValue = "1";
                    rblCategoria_SelectedIndexChanged(new Object(), new EventArgs());
                }

                item = rblGrupo.Items.FindByValue("A");
                if (item != null)
                {
                    rblGrupo.SelectedValue = "A";
                    rblGrupo_SelectedIndexChanged(new Object(), new EventArgs());
                }

                txtEmail.Text = txtNit.Text = txtTelefono.Text = string.Empty;
                txtSueldoBase.Text = "0";
                txtJustificacion.Text = txtDestino.Text = string.Empty;

                txtFechaIni.Text = txtFechaFin.Text = DateTime.Today.ToString();
                txtCuotaDiaria.Text = "0";


                /*txtFecha.Text = "2016-10-21";
                txtDependencia.Text = "Direccion de Contabilidad";
                txtEmail.Text = "johny_073@hotmail.com";
                txtNit.Text = "5124085-8";
                txtTelefono.Text = "56262627";
                txtSueldoBase.Text = "1500";
                txtJustificacion.Text = "Actualización de Tarjetas de Responsabilidad y verificación de bienes en mal estado.";
                txtDestino.Text = "Casa del Deportista de Puerto Barrios y Complejo Deportivo de Puerto Barrios y Complejo Deportivo de Livingston.";
                txtFechaIni.Text = txtFechaFin.Text = "";
                */

                txtObservaciones.Text = "Ninguna";
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEnc(). " + ex.Message);
            }
        }

        public void NuevoDet()
        {
            try
            {
                int idEncabezado = 0;
                int.TryParse(lblIdEncabezado.Text, out idEncabezado);

                filtrarGridDetalles(idEncabezado);

            }
            catch (Exception ex)
            {
                throw new Exception("NuevoDet(). " + ex.Message);
            }
        }

        protected void filtrarGridDetalles(int id)
        {
            try
            {
                gridDet.DataSource = null;
                gridDet.DataBind();
                gridDet.SelectedIndex = -1;

                pViaticosLN = new ViaticosLN();
                DataSet dsResultado = pViaticosLN.InformacionViatico(id, 0, 3);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridDet.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridDet.DataBind();

                    dsResultado = pViaticosLN.InformacionViatico(id, 0, 2);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    decimal totalQ, totalD = 0;
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["COSTO_VIATICO"].ToString(), out totalQ);
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["TOTAL_DOLARES"].ToString(), out totalD);

                    lblTotalQ.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalQ);
                    lblTotalD.Text = String.Format(CultureInfo.InvariantCulture, "$.{0:0,0.00}", totalD);
                    
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
                NuevoEnc();
                NuevoDet();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaIngreso(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                inicialesUnidad();

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 5);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";
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
                NuevoEnc();
                NuevoDet();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaIngreso(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                inicialesUnidad();

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 5);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

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
                //NuevoPedidoEnc();
                //NuevoPedidoDet();

                int idAccion = 0;
                int.TryParse(ddlAcciones.SelectedValue, out idAccion);               
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones(). " + ex.Message;
            }
        }

        protected DataSet armarDsDet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("ID", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("DIA", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("FECHA", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("CUOTA", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("CUOTA_DOLARES", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("MONTO_DESAYUNO", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("MONTO_ALMUERZO", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("MONTO_CENA", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("MONTO_HOSPEDAJE", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("SUBTOTAL", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("USUARIO", Type.GetType("System.String"));

            return ds;
        }


        protected void limpiarControlesError()
        {
            //lblErrorPoa.Text = string.Empty;
            lblErrorAccion.Text = lblErrorAnio.Text = lblErrorUnidad.Text = string.Empty;
            lblErrorFechaNombramiento.Text = lblErrorDependencia.Text = lblErrorTipoPersona.Text = string.Empty;
            lblErrorJefeDirector.Text = lblErrorSubgerente.Text = string.Empty;
            lblErrorEmpleado.Text = lblErrorPuesto.Text = lblErrorEmail.Text = lblErrorNit.Text = lblErrorTelefono.Text = lblErrorSueldo.Text = string.Empty;
            lblErrorJustificacion.Text = lblErrorDestino.Text = string.Empty;
            lblErrorFechas.Text = lblErrorObservaciones.Text = string.Empty;
            lblErrorCuota.Text = string.Empty; 
            lblError.Text = lblSuccess.Text = string.Empty;
            lblErrorCategoria.Text = lblErrorPaises.Text = string.Empty;

        }

        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                if (ddlAnios.SelectedValue.Equals("0") || ddlAnios.Items.Count == 0)
                {
                    lblErrorAnio.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un año. ";
                }

                if (ddlPlanes.SelectedValue.Equals("0") || ddlPlanes.Items.Count == 0)
                {
                    lblErrorPlan.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un plan. ";
                }

                if (ddlUnidades.SelectedValue.Equals("0") || ddlUnidades.Items.Count == 0)
                {
                    lblErrorUnidad.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione una unidad. ";
                }

                if (ddlAcciones.SelectedValue.Equals("0") || ddlAcciones.Items.Count == 0)
                {
                    lblErrorAccion.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione una acción. ";
                }

                if (ddlJefeDirector.SelectedValue.Equals("0") || ddlJefeDirector.Items.Count == 0)
                {
                    lblErrorJefeDirector.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un solicitante. ";
                }

                if (ddlSubgerente.SelectedValue.Equals("0") || ddlSubgerente.Items.Count == 0)
                {
                    lblErrorSubgerente.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un Subgerente/Director. ";
                }

                if (ddlCategorias.SelectedValue.Equals("0") || ddlCategorias.Items.Count == 0)
                {
                    lblErrorCategoria.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione una categoría. ";
                }

                if (ddlGrupos.SelectedValue.Equals("0") || ddlGrupos.Items.Count == 0)
                {
                    lblErrorPaises.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un país. ";
                }

                /*if (ddlPuestos.SelectedValue.Equals("0") || ddlPuestos.Items.Count == 0)
                {
                    lblErrorPuesto.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un Subgerente/Director. ";
                }*/

                if (rblTipoPersonal.SelectedValue.Equals("1"))
                {
                    if (ddlEmpleados.SelectedValue.Equals("0") || ddlEmpleados.Items.Count == 0)
                    {
                        lblErrorEmpleado.Text = "Seleccione un valor. ";
                        lblError.Text += "Seleccione un tipo de persona. ";
                    }
                }
                else
                {
                    string nombre = txtNombre.Text;
                    nombre = nombre.Replace('\'', ' ').Replace(';', ' ');
                    nombre = nombre.Trim();
                    txtNombre.Text = nombre;

                    if (txtNombre.Text.Equals(""))
                    {
                        lblErrorEmpleado.Text = "Ingrese el nombre. ";
                        lblError.Text += "Ingrese el nombre. ";
                    }

                    string puesto = txtPuesto.Text;
                    puesto = puesto.Replace('\'', ' ').Replace(';', ' ');
                    puesto = puesto.Trim();
                    txtPuesto.Text = puesto;

                    if (txtPuesto.Text.Equals(""))
                    {
                        lblErrorPuesto.Text = "Ingrese el puesto. ";
                        lblError.Text += "Ingrese el puesto. ";
                    }
                }

                string s = txtDependencia.Text;
                s = s.Replace('\'', ' ').Replace(';', ' ');
                s = s.Trim();
                txtDependencia.Text = s;

                if (txtDependencia.Text.Equals(""))
                {
                    lblErrorDependencia.Text = "Ingrese Dependencia. ";
                    lblError.Text += "Ingrese Dependencia. ";
                }

                s = txtEmail.Text;
                s = s.Replace('\'', ' ').Replace(';', ' ');
                s = s.Trim();
                txtEmail.Text = s;

                if (txtEmail.Text.Equals(""))
                {
                    lblErrorEmail.Text = "Ingrese E-mail. ";
                    lblError.Text += "Ingrese E-mail. ";
                }

                s = txtNit.Text;
                s = s.Replace('\'', ' ').Replace(';', ' ');
                s = s.Trim();
                txtNit.Text = s;

                if (txtNit.Text.Equals(""))
                {
                    lblErrorNit.Text = "Ingrese NIT. ";
                    lblError.Text += "Ingrese NIT. ";
                }

                s = txtTelefono.Text;
                s = s.Replace('\'', ' ').Replace(';', ' ');
                s = s.Trim();
                txtTelefono.Text = s;
                
                if (txtTelefono.Text.Equals(""))
                {
                    lblErrorTelefono.Text = "Ingrese Teléfono. ";
                    lblError.Text += "Ingrese Teléfono. ";
                }

                s = txtJustificacion.Text;
                s = s.Replace('\'', ' ').Replace(';', ' ');
                s = s.Trim();
                txtJustificacion.Text = s;

                if (txtJustificacion.Text.Equals(""))
                {
                    lblErrorJustificacion.Text = "Ingrese Justificación. ";
                    lblError.Text += "Ingrese Justificación. ";
                }

                s = txtDestino.Text;
                s = s.Replace('\'', ' ').Replace(';', ' ');
                s = s.Trim();
                txtDestino.Text = s;

                if (txtDestino.Text.Equals(""))
                {
                    lblErrorDestino.Text = "Ingrese Destino. ";
                    lblError.Text += "Ingrese Destino. ";
                }

                s = txtObservaciones.Text;
                s = s.Replace('\'', ' ').Replace(';', ' ');
                s = s.Trim();
                txtObservaciones.Text = s;
                
                if (txtObservaciones.Text.Equals(""))
                {
                    lblErrorObservaciones.Text = "Ingrese Observaciones. ";
                    lblError.Text += "Ingrese Observaciones. ";
                }

                string[] sValor = " ".Split(' ');
                if (rblTipoPersonal.SelectedValue.Equals("1"))
                {
                    string temp = txtSueldoBase.Text;
                    sValor = temp.Split('.');
                    if (sValor.Length == 1 || sValor.Length == 2)
                    {
                        if (sValor.Length == 1)
                            temp = sValor[0] + ".00";
                        else
                        {
                            if (sValor[1].Length == 1)
                                temp = sValor[0] + "." + sValor[1].Substring(0, 1) + "0";
                            else
                                temp = sValor[0] + "." + sValor[1].Substring(0, 2);
                        }

                        decimal dvalor = 0;
                        decimal.TryParse(temp, out dvalor);
                        txtSueldoBase.Text = dvalor.ToString();

                        if (dvalor <= 0)
                        {
                            lblErrorSueldo.Text = "Ingrese un sueldo válido. ";
                            lblError.Text += "Ingrese un sueldo válido. ";
                        }
                    }
                    else
                    {
                        lblErrorSueldo.Text = "Ingrese un sueldo válido. ";
                        lblError.Text += "Ingrese un sueldo válido. ";
                    }
                }

                /*temp = txtCuotaDiaria.Text;
                sValor = temp.Split('.');
                if (sValor.Length == 1 || sValor.Length == 2)
                {
                    if (sValor.Length == 1)
                        temp = sValor[0] + ".00";
                    else
                    {
                        if (sValor[1].Length == 1)
                            temp = sValor[0] + "." + sValor[1].Substring(0, 1) + "0";
                        else
                            temp = sValor[0] + "." + sValor[1].Substring(0, 2);
                    }

                    decimal dvalor = 0;
                    decimal.TryParse(temp, out dvalor);
                    txtCuotaDiaria.Text = dvalor.ToString();

                    if (dvalor < 0)
                    {
                        lblErrorKms.Text = "Ingrese una cuota válida. ";
                        lblError.Text += "Ingrese una cuota válida. ";
                    }
                }
                else
                {
                    lblErrorKms.Text = "Ingrese un kilometraje válido. ";
                    lblError.Text += "Ingrese un pasaje válido. ";
                }*/


                try
                {
                    if(txtFecha.Text.Contains("/"))
                        sValor = txtFecha.Text.Split('/');
                    else if(txtFecha.Text.Contains("-"))
                        sValor = txtFecha.Text.Split('-');

                    int dia, mes, anio;
                    dia = mes = anio = 0;
                    DateTime fecha = new DateTime();

                    if (sValor.Length != 3)
                        throw new Exception();

                    if (txtFecha.Text.Contains("/"))
                    {
                        int.TryParse(sValor[0], out dia);
                        int.TryParse(sValor[1], out mes);
                        int.TryParse(sValor[2], out anio);
                    }
                    else if (txtFecha.Text.Contains("-"))
                    {
                        int.TryParse(sValor[0], out anio);
                        int.TryParse(sValor[1], out mes);
                        int.TryParse(sValor[2], out dia);
                    }
                    
                    fecha = new DateTime(anio, mes, dia);
                    fechaNombramiento = new DateTime(anio, mes, dia); 
                }
                catch (Exception)
                {
                    lblErrorFechaNombramiento.Text = "Ingrese una fecha válida. ";
                    lblError.Text += "Ingrese una fecha válida. ";
                }

                DateTime fechaIni = new DateTime();
                try
                {
                    if (txtFechaIni.Text.Contains("/"))
                        sValor = txtFechaIni.Text.Split('/');
                    else if (txtFechaIni.Text.Contains("-"))
                        sValor = txtFechaIni.Text.Split('-');

                    int dia, mes, anio, horas, minutos;
                    dia = mes = anio = 0;

                    if (sValor.Length != 3)
                        throw new Exception();

                    if (txtFecha.Text.Contains("/"))
                    {
                        int.TryParse(sValor[0], out dia);
                        int.TryParse(sValor[1], out mes);
                        int.TryParse(sValor[2], out anio);
                    }
                    else if (txtFecha.Text.Contains("-"))
                    {
                        int.TryParse(sValor[0], out anio);
                        int.TryParse(sValor[1], out mes);
                        int.TryParse(sValor[2], out dia);
                    }

                    fechaIni = new DateTime(anio, mes, dia);
                    fechaIniComision = new DateTime(anio, mes, dia);
                }
                catch (Exception)
                {
                    lblErrorFechas.Text = "Ingrese una fecha válida. ";
                    lblError.Text += "Ingrese una fecha válida. ";
                }

                if (lblErrorFechas.Text.Equals(""))
                {
                    try
                    {
                        if (txtFechaFin.Text.Contains("/"))
                            sValor = txtFechaFin.Text.Split('/');
                        else if (txtFechaFin.Text.Contains("-"))
                            sValor = txtFechaFin.Text.Split('-');

                        DateTime fecha = new DateTime();
                        int dia, mes, anio, horas, minutos;
                        dia = mes = anio = 0;

                        if (sValor.Length != 3)
                            throw new Exception("Ingrese una fecha válida");

                        if (txtFecha.Text.Contains("/"))
                        {
                            int.TryParse(sValor[0], out dia);
                            int.TryParse(sValor[1], out mes);
                            int.TryParse(sValor[2], out anio);
                        }
                        else if (txtFecha.Text.Contains("-"))
                        {
                            int.TryParse(sValor[0], out anio);
                            int.TryParse(sValor[1], out mes);
                            int.TryParse(sValor[2], out dia);
                        }

                        fecha = new DateTime(anio, mes, dia);
                        fechaFinComision = new DateTime(anio, mes, dia);

                        TimeSpan rangoTiempo = fecha - fechaIni;
                        int diasComision = int.Parse((Math.Ceiling(rangoTiempo.TotalDays)).ToString());

                        if (fechaIni > fecha || diasComision == 0)
                            throw new Exception("Rango no válido");
                    }
                    catch (Exception ex)
                    {
                        lblErrorFechas.Text = ex.Message;
                        lblError.Text += ex.Message;
                    }
                }

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


        protected bool validarPoaIngreso(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
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
                    btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa;
                }
                else
                {
                    poaValido = true;
                    btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = /*gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = */true;
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            btnAnular.Visible = false;
            //btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = true;
            //poaValido = true;
            return poaValido;            
        }

        protected bool validarEstadoSolicitud(int idSolicitud)
        {
            bool viaticoValido = false;

            DataSet dsResultado = new DataSet();
            int idEstado = 0;

            try
            {
                if (idSolicitud == 0)
                {
                    lblEstado.Text = "";
                    btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = /*gridDet.Columns[0].Visible = gridDet.Columns[1].Visible =*/ true;
                    lblErrorPoa.Text = lblError.Text = "";
                    viaticoValido = true;
                }
                else
                {
                    btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;

                    pViaticosLN = new ViaticosLN();
                    dsResultado = pViaticosLN.InformacionViatico(idSolicitud, 0, 2);
                    
                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del viático.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al viático");

                    lblEstado.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_VIATICO"].ToString();

                    idEstado = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_VIATICO"].ToString(), out idEstado);

                    //EL PEDIDO ESTÁ EN ESTADO INGRESADO, AL NO SER ENVIADO A REVISIÓN SE PUEDE MODIFICAR
                    if (idEstado == 1)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = /*gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = */true;
                        lblErrorPoa.Text = lblError.Text = "";
                        viaticoValido = true;
                    }//EL PEDIDO ESTÁ EN ESTADO RECHAZADO BODEGA, RECHAZADO SUB/DIR, RECHAZADO FINANCIERO, SE PUEDE MODIFICAR
                    else if(idEstado == 3 || idEstado == 5 || idEstado == 7)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = /*gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = */true;
                        lblErrorPoa.Text = lblError.Text = "El VIÁTICO seleccionado se encuenta en estado: " + lblEstado.Text + ", por: " + dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES_RECHAZO"].ToString();
                        viaticoValido = true;

                    }//EL PEDIDO ESTÁ EN ESTADO APROBACIÓN BODEGA, APROBACIÓN SUB/DIR, APROBACIÓN FINANCIERO, CODIFICADO FINANCIERO, ANULADO Y NO SE PUEDE MODIFICAR
                    else if (idEstado == 2 || idEstado == 4 || idEstado == 6 || idEstado == 8 || idEstado == 9)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El VIÁTICO seleccionado se encuenta en estado: " + lblEstado.Text + " y no se puede modificar ";
                        viaticoValido = false;
                    }
                }

                //EL PEDIDO ESTÁ EN ESTADO INGRESADO, RECHAZADO BODEGA, RECHAZADO SUB/DIR, RECHAZADO FINANCIERO, SE PUEDE MODIFICAR
                if (idEstado == 0 || idEstado == 1 || idEstado == 3 || idEstado == 5 || idEstado == 7 || idEstado == 9)
                {
                    PedidosLN pInsumoLN = new PedidosLN();
                    dsResultado = pInsumoLN.InformacionPermisos(0, 0, Session["usuario"].ToString(), 7);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                        btnEnviar.Visible = true;
                    else
                        btnEnviar.Visible = false;

                    dsResultado = pInsumoLN.InformacionPermisos(0, 0, Session["usuario"].ToString(), 8);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                        btnGuardar.Visible = true;
                    else
                        btnGuardar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            btnAnular.Visible = false;
            return viaticoValido;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                btnNuevo_Click(sender, e);

                if (idPlan > 0)
                {
                    ddlPlanes.SelectedValue = idPlan.ToString();
                    int anioIni = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[0].Trim());
                    int anioFin = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[1].Trim());

                    pEstrategicoLN = new PlanEstrategicoLN();
                    pEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlPlanes(). " + ex.Message;
            }
        }

        protected decimal calculoCuotaDiaria(int idDetCategoria, int idDetGrupo)
        {
            decimal cuotaDiaria = 0;

            pViaticosLN = new ViaticosLN();
            DataSet dsResultado = pViaticosLN.InformacionViatico(idDetCategoria, idDetGrupo, 10);

            if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

            decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["MONTO"].ToString(), out cuotaDiaria);
            return cuotaDiaria;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                if (validarControlesABC())
                {
                    //CALCULO DE LA CUOTA DIARIA CORRESPONDIENTE
                    int idDetCat, idDetGru = 0;
                    int.TryParse(ddlCategorias.SelectedValue, out idDetCat);
                    int.TryParse(ddlGrupos.SelectedValue, out idDetGru);

                    txtCuotaDiaria.Text = calculoCuotaDiaria(idDetCat, idDetGru).ToString();

                    //CALCULO DE LA CUOTA DIARIA CORRESPONDIENTE
                    int idViatico = 0;
                    int.TryParse(lblIdEncabezado.Text, out idViatico);

                    pViaticosEN = new ViaticosEN();

                    pViaticosEN.ID_VIATICO = idViatico;

                    pViaticosEN.FECHA_NOMBRAMIENTO = fechaNombramiento;
                    pViaticosEN.ID_POA = int.Parse(lblIdPoa.Text);
                    pViaticosEN.ID_ACCION = int.Parse(ddlAcciones.SelectedValue);
                    pViaticosEN.ID_TIPO_VIATICO = 2; //1 = VIÁTICO AL INTERIOR 2 = VIÁTICO AL EXTERIOR

                    if (rblTipoPersonal.SelectedValue.Equals("1"))
                    {
                        pViaticosEN.ID_SOLICITANTE = int.Parse(ddlEmpleados.SelectedValue);
                        pViaticosEN.ID_PUESTO = int.Parse(ddlPuestos.SelectedValue);

                        pViaticosEN.NOMBRE_SOLICITANTE = string.Empty;
                        pViaticosEN.NOMBRE_UNIDAD = string.Empty;
                        pViaticosEN.NOMBRE_PUESTO = string.Empty;

                    }
                    else //if (rblTipoPersonal.SelectedValue.Equals("2"))
                    {
                        pViaticosEN.ID_SOLICITANTE = 0;
                        pViaticosEN.ID_PUESTO = 0;

                        pViaticosEN.NOMBRE_SOLICITANTE = txtNombre.Text;
                        pViaticosEN.NOMBRE_UNIDAD = string.Empty;
                        pViaticosEN.NOMBRE_PUESTO = txtPuesto.Text;
                    }

                    pViaticosEN.NOMBRE_DEPENDENCIA = txtDependencia.Text;
                    pViaticosEN.ID_JEFE_DIRECTOR = int.Parse(ddlJefeDirector.SelectedValue);
                    pViaticosEN.ID_SUBGERENTE = int.Parse(ddlSubgerente.SelectedValue);
                    pViaticosEN.ID_TIPO_PERSONA = int.Parse(rblTipoPersonal.SelectedValue);

                    if (chkSalida.Checked)
                        pViaticosEN.RETORNO_AL_EXTERIOR = 1;

                    pViaticosEN.SUELDO_BASE = decimal.Parse(txtSueldoBase.Text);
                    pViaticosEN.EMAIL = txtEmail.Text;
                    pViaticosEN.TELEFONO = txtTelefono.Text;
                    pViaticosEN.NIT = txtNit.Text;
                    pViaticosEN.JUSTIFICACION = txtJustificacion.Text;
                    pViaticosEN.DESTINO = txtDestino.Text;

                    pViaticosEN.FECHA_INI = fechaIniComision;
                    pViaticosEN.FECHA_FIN = fechaFinComision;

                    pViaticosEN.CUOTA_DIARIA = decimal.Parse(txtCuotaDiaria.Text);
                    pViaticosEN.OBSERVACIONES = txtObservaciones.Text;
                    pViaticosEN.USUARIO = Session["usuario"].ToString();

                    System.IO.StringReader srDatos = new System.IO.StringReader(lblTipoCambio.Text);
                    DataSet dsTipoCambio = new DataSet();
                    dsTipoCambio.ReadXml(srDatos);

                    pViaticosEN.FECHA_TASA_CAMBIO = dsTipoCambio.Tables["VarDolar"].Rows[0]["fecha"].ToString();
                    pViaticosEN.TASA_DE_CAMBIO_DS = lblTipoCambio.Text;
                    pViaticosEN.TASA_DE_CAMBIO = Math.Round(decimal.Parse(dsTipoCambio.Tables["VarDolar"].Rows[0]["referencia"].ToString()), 2);
                    

                    TimeSpan rangoTiempo = pViaticosEN.FECHA_FIN - pViaticosEN.FECHA_INI;

                    int diasComision = (pViaticosEN.FECHA_FIN.DayOfYear - pViaticosEN.FECHA_INI.DayOfYear) + 1;
                    decimal cuotaDiaria = decimal.Parse(txtCuotaDiaria.Text);
                    decimal viaticosDia = 0;
                    decimal viaticosDiaDolares = 0;
                    decimal totalViaticos = 0;
                    decimal totalViaticosD = 0;
                    DataSet dsDetalles = armarDsDet();

                    for(int i = 0; i < diasComision; i++)
                    {
                        DataRow dr = dsDetalles.Tables[0].NewRow();

                        viaticosDia = cuotaDiaria * pViaticosEN.TASA_DE_CAMBIO;
                        viaticosDiaDolares = cuotaDiaria;

                        if ((i + 1) == diasComision)
                        {
                            //SERVIRA EN LOS CASOS CUANDO LA PERSONA VIAJARÁ A VARIOS PAÍSES ASÍ EL SISTEMA CALCULA EL 100% del VIÁTICO PARA EL DÍA DE RETORNO
                            if (!chkSalida.Checked)
                            {
                                viaticosDia = (cuotaDiaria * pViaticosEN.TASA_DE_CAMBIO) / 2;
                                viaticosDiaDolares = cuotaDiaria / 2;
                            }
                        }

                        dr["ID"] = "0";
                        dr["DIA"] = (i + 1);
                        dr["FECHA"] = "";
                        dr["CUOTA"] = viaticosDia;
                        dr["CUOTA_DOLARES"] = viaticosDiaDolares;
                        dr["MONTO_DESAYUNO"] = "0";
                        dr["MONTO_ALMUERZO"] = "0";
                        dr["MONTO_CENA"] = "0";
                        dr["MONTO_HOSPEDAJE"] = "0";
                        dr["SUBTOTAL"] = viaticosDia;
                        dr["USUARIO"] = Session["usuario"].ToString();
                        
                        dsDetalles.Tables[0].Rows.Add(dr);

                        totalViaticos += viaticosDia;
                        totalViaticosD += viaticosDiaDolares;
                    }

                    pViaticosEN.COSTO_VIATICOS = totalViaticos;
                    pViaticosEN.TOTAL_DOLARES = totalViaticosD;

                    pViaticosEN.ID_CATEGORIA_DET = int.Parse(ddlCategorias.SelectedValue);
                    pViaticosEN.ID_GRUPO_DET = int.Parse(ddlGrupos.SelectedValue);

                    if (true)
                    {
                        if (validarEstadoSolicitud(idViatico))
                        {
                            FuncionesVarias fv = new FuncionesVarias();
                            string[] ip = fv.DatosUsuarios();
                            pViaticosLN = new ViaticosLN();
                            DataSet dsResultado = pViaticosLN.AlmacenarViaticos(pViaticosEN, dsDetalles.Tables[0],Session["usuario"].ToString(),ip[0],ip[1],ip[2]);

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se INSERTÓ/ACTUALIZÓ la solcitud de viáticos: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idViatico);
                            lblIdEncabezado.Text = idViatico.ToString();

                            dsResultado = pViaticosLN.InformacionViatico(idViatico, 0, 2);

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se CONSULTÓ el viático: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            lblNoEncabezado.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_SOLICITUD"].ToString();
                            lblAnio.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO_SOLICITUD"].ToString();

                            NuevoDet();
                            lblSuccess.Text = "Solicitud de Viáticos No. " + dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_ANIO_SOLICITUD"].ToString() + " ALMACENADO/MODIFICADO exitosamente: ";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar(). " + ex.Message;
            }
        }

        protected bool ValidarPptoUIDetalle(int idPac, int idDetallePedido, decimal subTotal)
        {
            pAccionLN = new PlanAccionLN();
            pAnualLN = new PlanAnualLN();
            bool pptoValido = false;

            decimal saldoPac, saldoRenglon, montoDetPedido = 0;

            if (idPac > 0)
            {
                //INFORMACIÓN DEL PLAN ANUAL DE COMPRAS
                DataSet dsInformacionPac = pAnualLN.InformacionPac(idPac);
                if (dsInformacionPac.Tables.Count == 0)
                    throw new Exception("Error al consultar la información del Plan: " + dsInformacionPac.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (dsInformacionPac.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe información del del Plan: " + dsInformacionPac.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (bool.Parse(dsInformacionPac.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se consultó la información del Plan: " + dsInformacionPac.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                decimal saldo = 0;
                decimal.TryParse(dsInformacionPac.Tables["ENCABEZADO"].Rows[0]["SALDO"].ToString(), out saldo);
                //lblDisponibleP.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);

                int idDetalleAccion = 0;
                int.TryParse(dsInformacionPac.Tables["ENCABEZADO"].Rows[0]["ID_DETALLE_ACCION"].ToString(), out idDetalleAccion);


                //INFORMACIÓN DEL RENGLÓN AL QUE PERTENECE EL PAC
                DataSet dsInformacionRenglon = pAccionLN.PptoRenglonAccion(idDetalleAccion);
                if (dsInformacionRenglon.Tables.Count == 0)
                    throw new Exception("Error al consultar la información del Plan: " + dsInformacionRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (dsInformacionRenglon.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe información del del Plan: " + dsInformacionRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (bool.Parse(dsInformacionRenglon.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se consultó la información del Plan: " + dsInformacionRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                saldo = 0;
                decimal.TryParse(dsInformacionRenglon.Tables["BUSQUEDA"].Rows[0]["SALDO_POA"].ToString(), out saldo);
                //lblDisponibleR.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);

                //INFORMACIÓN DEL DETALLE DEL PEDIDO
                pViaticosLN = new ViaticosLN();
                DataSet dsInformacionDetPedido = pViaticosLN.InformacionViatico(idDetallePedido, 0, 4);
                if (dsInformacionDetPedido.Tables.Count == 0)
                    throw new Exception("Error al consultar la información del Plan: " + dsInformacionDetPedido.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (dsInformacionDetPedido.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe información del Plan: " + dsInformacionDetPedido.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (bool.Parse(dsInformacionDetPedido.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsInformacionDetPedido.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                
                decimal.TryParse(dsInformacionPac.Tables["ENCABEZADO"].Rows[0]["SALDO"].ToString(), out saldoPac);
                decimal.TryParse(dsInformacionRenglon.Tables["BUSQUEDA"].Rows[0]["SALDO_POA"].ToString(), out saldoRenglon);

                if (idDetallePedido > 0)
                    decimal.TryParse(dsInformacionDetPedido.Tables["BUSQUEDA"].Rows[0]["SUBTOTAL"].ToString(), out montoDetPedido);

                decimal diferenciaPacDetPedido = (saldoPac + montoDetPedido) - subTotal;
                decimal diferenciaRenglonDetPedido = (saldoRenglon + montoDetPedido) - subTotal;

                if (diferenciaPacDetPedido < 0)
                    throw new Exception("El monto del pedido supera al PAC en: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", diferenciaPacDetPedido));

                if (diferenciaRenglonDetPedido < 0)
                    throw new Exception("El monto del pedido supera al Renglón en: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", diferenciaRenglonDetPedido));
            }

            pptoValido = true;
            return pptoValido;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoEncabezadoPoa();
                NuevoEnc();
                NuevoDet();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo(). " + ex.Message;
            }
        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            //PostBackUrl="~/Viaticos/ViaticosListado.aspx"
            Response.Redirect("~/Viaticos/ViaticosListado.aspx?Anio=" + ddlAnios.SelectedItem.Value + "&unidad=" + ddlUnidades.SelectedItem.Value);
        }


        protected void gridDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                lblError.Text = "gridDet(). " + ex.Message;
            }
        }

        protected void gridDet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                lblError.Text = "gridDet(). " + ex.Message;
            }
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            /*try
            {
                limpiarControlesError();
                int idPedido = 0;
                int.TryParse(lblNoPedido.Text, out idPedido);

                if (idPedido  == 0)
                    throw new Exception("No existe Bien/Servicio para eliminar");

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.EliminarEncabezado(idPedido);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                int idPac = 0;
                int.TryParse(ddlPac.SelectedValue, out idPac);

                NuevoEncabezadoPoa();
                NuevoEnc();
                NuevoDet();

                lblSuccess.Text = "Pedido eliminado correctamente!";

                Response.Redirect("NoPedido.aspx?No=" + Convert.ToString(idPedido) + "&msg=PEDIDO" + "&acc=ELIMINADO");
            }
            catch (Exception ex)
            {
                lblError.Text = "btnAnular(). " + ex.Message;
            }*/
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                //btnGuardar_Click(sender, e);

                //if (!lblSuccess.Text.Equals(string.Empty) || !lblSuccess.Text.Equals(""))
                {
                    limpiarControlesError();
                    int idViatico = 0;
                    int.TryParse(lblIdEncabezado.Text, out idViatico);

                    if (true)
                    {
                        if (validarEstadoSolicitud(idViatico))
                        {
                            if (idViatico == 0)
                                throw new Exception("No existe Viático para finalizar");

                            FuncionesVarias fv = new FuncionesVarias();
                            string[] ip = fv.DatosUsuarios();
                            pViaticosLN = new ViaticosLN();
                            DataSet dsResultado = pViaticosLN.EnviarViaticoARevision(idViatico, 1, Session["usuario"].ToString(),ip[0],ip[1],ip[2]);

                            if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                            btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
                            lblSuccess.Text = "Viático finalizado correctamente!";

                            Response.Redirect("NoViatico.aspx?No=" + Convert.ToString(idViatico) + "&msg=VIATICO_AL_EXTERIOR" + "&acc=ENVIADO");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnEnviar(). " + ex.Message;
            }
        }

        protected void rblTipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
            if (rblTipoPersonal.SelectedValue.Equals("1"))
            {
                txtNombre.Visible = false;
                ddlEmpleados.Visible = true;

                txtPuesto.ReadOnly = true;

                string usuario = Session["usuario"].ToString();
                int idUnidad = 0;
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                pViaticosLN = new ViaticosLN();
                pViaticosLN.DdlSolicitantes(ddlEmpleados, usuario, idUnidad);
                pViaticosLN.DdlPuestosEmpleado(ddlPuestos, "", 0);
            }
            else //if (rblTipoPersonal.SelectedValue.Equals("2"))
            {
                txtNombre.Visible = true;
                ddlEmpleados.Visible = false;

                txtPuesto.ReadOnly = false;

                ddlPuestos.ClearSelection();
                ddlPuestos.Items.Clear();

                ddlEmpleados.ClearSelection();
                ddlEmpleados.Items.Clear();
            }
        }

        protected void ddlJefeDirector_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void ddlSubgerente_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void ddlEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idEmpleado = 0;
                int.TryParse(ddlEmpleados.SelectedValue, out idEmpleado);

                eEmpleadosLN = new EmpleadosLN();
                DataSet dsResultado = eEmpleadosLN.InformacionEmpleado(idEmpleado, 6);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables.Count == 0)
                    throw new Exception("Error al consultar la información del empleado.");

                if (dsResultado.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe información del empleado");

                txtPuesto.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PUESTO_EMPLEADO"].ToString();
                txtNit.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NIT"].ToString();
                txtTelefono.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["TELEFONO"].ToString();
                txtEmail.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["EMAIL"].ToString();
                txtSueldoBase.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["SUELDO_BASE"].ToString();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlEmpleados(). " + ex.Message;
            }
        }

        protected void ddlPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void rblGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblGrupo.SelectedValue.Equals("A"))
                txtGrupo.Text = "Países de Europa, Asia, África, Oceanía, Canadá, Estados Unidos de América, Venezuela, Argentina, Brasil, Uruguay, Chile, Puerto Rico y Republica Dominicana.";

            if (rblGrupo.SelectedValue.Equals("B"))
                txtGrupo.Text = "Panamá, México, Islas del Caribe y Países de América del Sur no incluídos en el Grupo A.";
            
            if (rblGrupo.SelectedValue.Equals("C"))
                txtGrupo.Text = "Países de Centroamérica y Belice";

            //txtCuotaDiaria.Text = calculoCuotaDiaria(rblCategoria.SelectedValue, rblGrupo.SelectedValue).ToString();
        }

        protected void rblCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblCategoria.SelectedValue.Equals("1"))
                txtCategoria.Text = "Los miembros del Comité Ejecutivo de la Confederación Deportivo Autónoma de Guatemala, Auditor Interno, Miembros del Tribunal de Honor, Miembros Comisión de Fiscalización Administrativo-Contable, de las Miembros de las Comisiones debidamente creadas por el Comité Ejecutivo, Gerente, Secretario General; Subgerentes de CDAG; Comités Ejecutivos, Órganos Disciplinarios y Comisiones Ténico-Deportivas de Federaciones y Asociaciones Deportivas Nacionales y/o funcionarios administrativos de dichas entidades, equivalentes a los funcionarios mencionados de CDAG";

            if (rblCategoria.SelectedValue.Equals("2"))
                txtCategoria.Text = "Los Directores de diferentes Direcciones, Asesores de la Confederación Deportiva Autónoma de Guatemala, Atletas, Entrenadores, Comités Ejecutivos, Órganos Disciplinarios y Comisiones Técnico-Deportivas de Asociaciones Deportivas Departamentales y Delegaciones Deportivas Departamentales y Directores, Subdirectores y Asesores de entidades deportivas federadas.";

            if (rblCategoria.SelectedValue.Equals("3"))
                txtCategoria.Text = "Comités Ejecutivos y Órganos Disciplinarios de Asociaciones Deportivas Municipales; Delegaciones Deportivas Municipales, Personal de cuerpos técnicos y cuerpos auxiliares que integren delegaciones deportivas que participen en eventos fuera del país, Jefes y Subjefes de entidades deportivas Federadas, Empleados administrativos de CDAG y de entidades deportivas federadas y personal ténico y administrativo, personal auxiliar que integran las Delegaciones Deportivas, para particiapes en eventos fuera del territorio nacional";

            if (rblCategoria.SelectedValue.Equals("4"))
                txtCategoria.Text = "Otro personal de entidades deportivas federadas, no comprendidas en las categorías anteriores.";

            //txtCuotaDiaria.Text = calculoCuotaDiaria(rblCategoria.SelectedValue, rblGrupo.SelectedValue).ToString();
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idDetalleCategoria, idDetalleGrupo = 0;

                int.TryParse(ddlCategorias.SelectedValue, out idDetalleCategoria);
                int.TryParse(ddlGrupos.SelectedValue, out idDetalleGrupo);

                if (idDetalleCategoria > 0 && idDetalleGrupo > 0)
                {
                    txtCuotaDiaria.Text = calculoCuotaDiaria(idDetalleCategoria, idDetalleGrupo).ToString();
                }
                else
                    txtCuotaDiaria.Text = "0";
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlCategorias/Grupos(). " + ex.Message;
            }
                
        }

    }
}
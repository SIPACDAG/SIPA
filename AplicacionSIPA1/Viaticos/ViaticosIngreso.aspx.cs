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
    public partial class ViaticosIngreso : System.Web.UI.Page
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
                    btnNuevo_Click(sender, e);

                    string s = Convert.ToString(Request.QueryString["No"]);

                    if (s != null)
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

                        int idPlan, anio, idUnidad, idAccion, idJefeDirector, idSubgerente, idTipoPersona, idSolicitante, idPuesto, vehiculoCDAG, idCategoria = 0;

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
                        else
                        {
                            txtPuesto.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE_PUESTO"].ToString();
                        }

                        item = rblCategoria.Items.FindByValue(idCategoria.ToString());
                        if (item != null)
                        {
                            rblCategoria.SelectedValue = idCategoria.ToString();
                            rblCategoria_SelectedIndexChanged(sender, e);
                        }

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

                        string horaIF = "";                        

                        horaIF = dsResultado.Tables["BUSQUEDA"].Rows[0]["HORA_INI"].ToString();
                        decimal hora = decimal.Parse(horaIF);
                        horaIF = String.Format(CultureInfo.InvariantCulture, "{0:00.00}", hora);
                        
                        ddlHoraIni.SelectedValue = int.Parse(horaIF.Split('.')[0]).ToString();
                        ddlMinIni.SelectedValue = int.Parse(horaIF.Split('.')[1]).ToString();

                        horaIF = dsResultado.Tables["BUSQUEDA"].Rows[0]["HORA_FIN"].ToString();
                        hora = decimal.Parse(horaIF);
                        horaIF = String.Format(CultureInfo.InvariantCulture, "{0:00.00}", hora);

                        ddlHoraFin.SelectedValue = int.Parse(horaIF.Split('.')[0]).ToString();
                        ddlMinFin.SelectedValue = int.Parse(horaIF.Split('.')[1]).ToString();

                        txtObservaciones.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES_VIATICOS"].ToString();

                        item = rblVehiculoInst.Items.FindByValue(vehiculoCDAG.ToString());
                        if (item != null)
                        {
                            rblVehiculoInst.SelectedValue = vehiculoCDAG.ToString();
                            rblVehiculoInst_SelectedIndexChanged(sender, e);
                        }

                        txtPasajes.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PASAJES"].ToString();
                        txtKilometraje.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["KILOMETRAJE"].ToString();
                        txtCuotaDiaria.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["CUOTA_DIARIA"].ToString();

                        lblIdEncabezado.Text = idEncabezado.ToString();
                        lblNoEncabezado.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_SOLICITUD"].ToString();
                        lblAnio.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO_SOLICITUD"].ToString();
                        filtrarGridDetalles(idEncabezado);
                        filtrarGridPpto();

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
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 4);
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
                lblSubtotalP.Text = lblSubtotalK.Text = lblSubtotalV.Text = lblTotal.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
                validarEstadoSolicitud(0);
                inicialesUnidad();
                lblEstado.Text = string.Empty;
                string usuario = Session["usuario"].ToString();
                int idUnidad = 0;
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                pViaticosLN = new ViaticosLN();
                pViaticosLN.DdlJefes(ddlJefeDirector, usuario, idUnidad);
                pViaticosLN.DdlSubgerentes(ddlSubgerente, usuario, idUnidad);
                

                txtFecha.Text = DateTime.Today.ToString();
                txtDependencia.Text = string.Empty;

                ListItem item = rblTipoPersonal.Items.FindByValue("1");
                if (item != null)
                {
                    rblTipoPersonal.SelectedValue = "1";
                    rblTipoPersonal_SelectedIndexChanged(new Object(), new EventArgs());
                }

                /*item = rblCategoria.Items.FindByValue("1");
                if (item != null)
                {
                    rblCategoria.SelectedValue = "1";
                    rblCategoria_SelectedIndexChanged(new Object(), new EventArgs());
                }*/

                txtEmail.Text = txtNit.Text = txtTelefono.Text = string.Empty;
                txtSueldoBase.Text = "0";
                txtJustificacion.Text = txtDestino.Text = string.Empty;

                txtFechaIni.Text = txtFechaFin.Text = DateTime.Today.ToString();
                HorasMinutos(ddlHoraIni, 1);
                HorasMinutos(ddlMinIni, 2);
                HorasMinutos(ddlHoraFin, 1);
                HorasMinutos(ddlMinFin, 2);

                txtPasajes.Text = txtKilometraje.Text = txtCuotaDiaria.Text = "0";


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

                //rblCategoria_SelectedIndexChanged(new object(), new EventArgs());
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

                chkViaticosSalida.ClearSelection();
                chkViaticosRetorno.ClearSelection();
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

                    chkViaticosSalida.Items[0].Selected = chkViaticosSalida.Items[1].Selected = chkViaticosSalida.Items[2].Selected = chkViaticosSalida.Items[3].Selected = false;
                    DataRow dr = dsResultado.Tables["BUSQUEDA"].Rows[0];

                    if (decimal.Parse(dr["MONTO_DESAYUNO"].ToString()) > 0)
                        chkViaticosSalida.Items[0].Selected = true;

                    if (decimal.Parse(dr["MONTO_ALMUERZO"].ToString()) > 0)
                        chkViaticosSalida.Items[1].Selected = true;

                    if (decimal.Parse(dr["MONTO_CENA"].ToString()) > 0)
                        chkViaticosSalida.Items[2].Selected = true;

                    if (decimal.Parse(dr["MONTO_HOSPEDAJE"].ToString()) > 0)
                        chkViaticosSalida.Items[3].Selected = true;

                    chkViaticosRetorno.Items[0].Selected = chkViaticosRetorno.Items[1].Selected = chkViaticosRetorno.Items[2].Selected = chkViaticosRetorno.Items[3].Selected = false;
                    dr = dsResultado.Tables["BUSQUEDA"].Rows[(dsResultado.Tables["BUSQUEDA"].Rows.Count - 1)];

                    if (decimal.Parse(dr["MONTO_DESAYUNO"].ToString()) > 0)
                        chkViaticosRetorno.Items[0].Selected = true;

                    if (decimal.Parse(dr["MONTO_ALMUERZO"].ToString()) > 0)
                        chkViaticosRetorno.Items[1].Selected = true;

                    if (decimal.Parse(dr["MONTO_CENA"].ToString()) > 0)
                        chkViaticosRetorno.Items[2].Selected = true;

                    if (decimal.Parse(dr["MONTO_HOSPEDAJE"].ToString()) > 0)
                        chkViaticosRetorno.Items[3].Selected = true;


                    dsResultado = pViaticosLN.InformacionViatico(id, 0, 2);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    decimal viaticos, pasajes, kilometraje = 0;
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["COSTO_VIATICO"].ToString(), out viaticos);
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PASAJES"].ToString(), out pasajes);
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["KILOMETRAJE"].ToString(), out kilometraje);

                    lblSubtotalP.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (pasajes));
                    lblSubtotalK.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (kilometraje));
                    lblSubtotalV.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (viaticos));
                    lblTotal.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (pasajes + kilometraje + viaticos));
                }
                else
                {
                    gridDet.DataSource = null;
                    gridDet.DataBind();

                    chkViaticosSalida.ClearSelection();
                    chkViaticosRetorno.ClearSelection();
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

                int.TryParse(ddlAcciones.SelectedValue, out idSalida);

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

        protected DataSet HorasMinutos(DropDownList ddlTiempo, int opcion)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("id", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("texto", Type.GetType("System.String"));

            if (opcion == 1)
            {
                for (int i = 0; i < 24; i++)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["id"] = i;
                    dr["texto"] = String.Format(CultureInfo.InvariantCulture, "{0:00}", i);
                    ds.Tables[0].Rows.Add(dr);
                }
            }
            else if (opcion == 2)
            {
                for (int i = 0; i < 60; i++)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["id"] = i;
                    dr["texto"] = String.Format(CultureInfo.InvariantCulture, "{0:00}", i);
                    ds.Tables[0].Rows.Add(dr);
                }
            }

            ddlTiempo.ClearSelection();
            ddlTiempo.Items.Clear();
            ddlTiempo.DataSource = ds.Tables[0];
            ddlTiempo.DataTextField = "texto";
            ddlTiempo.DataValueField = "id";
            ddlTiempo.DataBind();

            return ds;
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
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 4);
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
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 4);
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
            lblErrorFechas.Text = lblErrorHoras.Text = lblErrorObservaciones.Text = string.Empty;
            lblErrorPasajes.Text = lblErrorKms.Text = lblErrorCuota.Text = string.Empty; 
            lblError.Text = lblSuccess.Text = string.Empty;

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
                }

                string s = txtDependencia.Text;
                s = s.Replace('\'', ' ').Replace(';', ' ');
                s = s.Trim();
                txtDependencia.Text = s;

                if (txtDependencia.Text.Equals(""))
                {
                    lblErrorEmail.Text = "Ingrese Dependencia. ";
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


                string temp = txtSueldoBase.Text;
                string[] sValor = temp.Split('.');
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

                    if (rblTipoPersonal.SelectedValue.Equals("1"))
                    {
                        if (dvalor <= 0)
                        {
                            lblErrorSueldo.Text = "Ingrese un sueldo válido. ";
                            lblError.Text += "Ingrese un sueldo válido. ";
                        }
                    }
                }
                else
                {
                    lblErrorSueldo.Text = "Ingrese un sueldo válido. ";
                    lblError.Text += "Ingrese un sueldo válido. ";
                }

                temp = txtPasajes.Text;
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
                    txtPasajes.Text = dvalor.ToString();

                    if (dvalor < 0)
                    {
                        lblErrorPasajes.Text = "Ingrese un pasaje válido. ";
                        lblError.Text += "Ingrese un pasaje válido. ";
                    }
                }
                else
                {
                    lblErrorPasajes.Text = "Ingrese un pasaje válido. ";
                    lblError.Text += "Ingrese un pasaje válido. ";
                }

                temp = txtKilometraje.Text;
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
                    txtKilometraje.Text = dvalor.ToString();

                    if (dvalor < 0)
                    {
                        lblErrorKms.Text = "Ingrese un kilometraje válido. ";
                        lblError.Text += "Ingrese un pasaje válido. ";
                    }
                }
                else
                {
                    lblErrorKms.Text = "Ingrese un kilometraje válido. ";
                    lblError.Text += "Ingrese un pasaje válido. ";
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

                if (lblErrorFechaNombramiento.Text.Equals("") || lblErrorFechaNombramiento.Text.Equals(string.Empty))
                {
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

                    int.TryParse(ddlHoraIni.SelectedValue, out horas);
                    int.TryParse(ddlMinIni.SelectedValue, out minutos);

                    fechaIni = new DateTime(anio, mes, dia, horas, minutos, 0);
                    fechaIniComision = new DateTime(anio, mes, dia, horas, minutos, 0);
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

                        int.TryParse(ddlHoraFin.SelectedValue, out horas);
                        int.TryParse(ddlMinFin.SelectedValue, out minutos);

                        fecha = new DateTime(anio, mes, dia, horas, minutos, 0);
                        fechaFinComision = new DateTime(anio, mes, dia, horas, minutos, 0);

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

                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_VIATICO"].ToString(), out idEstado);

                    //EL PEDIDO ESTÁ EN ESTADO INGRESADO, AL NO SER ENVIADO A REVISIÓN SE PUEDE MODIFICAR
                    if (idEstado == 1)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = /*gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = */true;
                        lblErrorPoa.Text = lblError.Text = "";
                        viaticoValido = true;
                    }//EL PEDIDO ESTÁ EN ESTADO RECHAZADO BODEGA, RECHAZADO SUB/DIR, RECHAZADO FINANCIERO, SE PUEDE MODIFICAR
                    else if (idEstado == 3 || idEstado == 5 || idEstado == 7 || idEstado == 9)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = /*gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = */true;
                        lblErrorPoa.Text = lblError.Text = "El VIÁTICO seleccionado se encuenta en estado: " + lblEstado.Text + ", por: " + dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES_RECHAZO"].ToString();
                        viaticoValido = true;

                    }//EL PEDIDO ESTÁ EN ESTADO APROBACIÓN BODEGA, APROBACIÓN SUB/DIR, APROBACIÓN FINANCIERO, CODIFICADO FINANCIERO, ANULADO Y NO SE PUEDE MODIFICAR
                    else if (idEstado == 2 || idEstado == 4 || idEstado == 6 || idEstado == 8 || idEstado == 11)
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                if (validarControlesABC())
                {
                    txtCuotaDiaria.Text = calculoCuotaDiaria(int.Parse(rblTipoPersonal.SelectedValue), decimal.Parse(txtSueldoBase.Text)).ToString();
                    int idViatico = 0;
                    int.TryParse(lblIdEncabezado.Text, out idViatico);

                    pViaticosEN = new ViaticosEN();

                    pViaticosEN.ID_VIATICO = idViatico;

                    pViaticosEN.FECHA_NOMBRAMIENTO = fechaNombramiento;
                    pViaticosEN.ID_POA = int.Parse(lblIdPoa.Text);
                    pViaticosEN.ID_ACCION = int.Parse(ddlAcciones.SelectedValue);
                    pViaticosEN.ID_TIPO_VIATICO = 1; //1 = VIÁTICO AL INTERIOR 2 = VIÁTICO AL EXTERIOR
                    pViaticosEN.ID_UNIDAD = int.Parse(ddlUnidades.SelectedValue);

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

                    pViaticosEN.SUELDO_BASE = decimal.Parse(txtSueldoBase.Text);
                    pViaticosEN.EMAIL = txtEmail.Text;
                    pViaticosEN.TELEFONO = txtTelefono.Text;
                    pViaticosEN.NIT = txtNit.Text;
                    pViaticosEN.JUSTIFICACION = txtJustificacion.Text;
                    pViaticosEN.DESTINO = txtDestino.Text;

                    pViaticosEN.FECHA_INI = fechaIniComision;
                    pViaticosEN.FECHA_FIN = fechaFinComision;

                    pViaticosEN.VEHICULO_CDAG = int.Parse(rblVehiculoInst.SelectedValue);

                    pViaticosEN.KILOMETRAJE = decimal.Parse(txtKilometraje.Text);
                    pViaticosEN.PASAJES = decimal.Parse(txtPasajes.Text);

                    pViaticosEN.CUOTA_DIARIA = decimal.Parse(txtCuotaDiaria.Text);
                    pViaticosEN.OBSERVACIONES = txtObservaciones.Text;
                    pViaticosEN.USUARIO = Session["usuario"].ToString();
                    pViaticosEN.ID_CATEGORIA_DET = int.Parse(rblCategoria.SelectedValue);

                    //TimeSpan rangoTiempo = pViaticosEN.FECHA_FIN.Day - pViaticosEN.FECHA_INI.Day;

                    int diasComision = (pViaticosEN.FECHA_FIN.DayOfYear - pViaticosEN.FECHA_INI.DayOfYear) + 1;
                    decimal cuotaDiaria = decimal.Parse(txtCuotaDiaria.Text);
                    decimal totalViaticos = 0;
                    DataSet dsDetalles = armarDsDet();

                    chkViaticosSalida.Items[0].Selected = chkViaticosSalida.Items[1].Selected = chkViaticosSalida.Items[2].Selected = chkViaticosSalida.Items[3].Selected = false;
                    chkViaticosRetorno.Items[0].Selected = chkViaticosRetorno.Items[1].Selected = chkViaticosRetorno.Items[2].Selected = chkViaticosRetorno.Items[3].Selected = false;

                    for(int i = 0; i < diasComision; i++)
                    {
                        DataRow dr = dsDetalles.Tables[0].NewRow();

                        decimal montoDesayuno, montoAlmuerzo, montoCena, montoHospedaje = 0;
                        montoDesayuno = cuotaDiaria / 100 * 15;
                        montoAlmuerzo = cuotaDiaria / 100 * 20;
                        montoCena = cuotaDiaria / 100 * 15;
                        montoHospedaje = cuotaDiaria / 100 * 50;

                        if (diasComision == 1)
                        {
                            decimal dHoraSalida = 0;
                            decimal dHoraRetorno = 0;
                            decimal.TryParse(ddlHoraIni.SelectedValue + "." + ddlMinIni.SelectedValue, out dHoraSalida);
                            decimal.TryParse(ddlHoraFin.SelectedValue + "." + ddlMinFin.SelectedValue, out dHoraRetorno);

                            //SALIDA
                            if (dHoraSalida <= 7)
                            {
                                chkViaticosSalida.Items[0].Selected = true;

                                if (dHoraRetorno > 12)
                                    chkViaticosSalida.Items[1].Selected = true;

                                if (dHoraRetorno > 19)
                                    chkViaticosSalida.Items[2].Selected = true;
                            }

                            if (dHoraSalida > 7 && dHoraSalida < 14)
                            {
                                chkViaticosSalida.Items[1].Selected = true;

                                if (dHoraRetorno > 19)
                                    chkViaticosSalida.Items[2].Selected = true;
                            }


                            if (!chkViaticosSalida.Items[0].Selected)
                                montoDesayuno = 0;

                            if (!chkViaticosSalida.Items[1].Selected)
                                montoAlmuerzo = 0;

                            if (!chkViaticosSalida.Items[2].Selected)
                                montoCena = 0;

                            if (!chkViaticosSalida.Items[3].Selected)
                                montoHospedaje = 0;

                            if (montoDesayuno == 0 && montoAlmuerzo == 0 && montoCena == 0 && montoHospedaje == 0)
                                throw new Exception("Marque al menos al menos un viático para el día de salida");
                        }
                        else
                        {

                            if ((i + 1) == 1)
                            {
                                decimal dHora = 0;
                                decimal.TryParse(ddlHoraIni.SelectedValue + "." + ddlMinIni.SelectedValue, out dHora);

                                if (dHora <= 7)
                                    chkViaticosSalida.Items[0].Selected = true;

                                if (dHora < 14)
                                    chkViaticosSalida.Items[1].Selected = true;

                                if (dHora < 20 && diasComision > 1)
                                    chkViaticosSalida.Items[2].Selected = true;

                                if (diasComision > 1)
                                    chkViaticosSalida.Items[3].Selected = true;

                                if (!chkViaticosSalida.Items[0].Selected)
                                    montoDesayuno = 0;

                                if (!chkViaticosSalida.Items[1].Selected)
                                    montoAlmuerzo = 0;

                                if (!chkViaticosSalida.Items[2].Selected)
                                    montoCena = 0;

                                if (!chkViaticosSalida.Items[3].Selected)
                                    montoHospedaje = 0;

                                if (montoDesayuno == 0 && montoAlmuerzo == 0 && montoCena == 0 && montoHospedaje == 0)
                                    throw new Exception("Marque al menos al menos un viático para el día de salida");
                            }

                            if ((i + 1) == diasComision && diasComision > 1)
                            {
                                decimal dHora = 0;
                                decimal.TryParse(ddlHoraFin.SelectedValue + "." + ddlMinFin.SelectedValue, out dHora);

                                if (dHora > 7)
                                    chkViaticosRetorno.Items[0].Selected = true;

                                if (dHora > 12)
                                    chkViaticosRetorno.Items[1].Selected = true;

                                if (dHora > 19)
                                    chkViaticosRetorno.Items[2].Selected = true;

                                //if (diasComision > 1)
                                chkViaticosRetorno.Items[3].Selected = false;


                                if (!chkViaticosRetorno.Items[0].Selected)
                                    montoDesayuno = 0;

                                if (!chkViaticosRetorno.Items[1].Selected)
                                    montoAlmuerzo = 0;

                                if (!chkViaticosRetorno.Items[2].Selected)
                                    montoCena = 0;

                                if (!chkViaticosRetorno.Items[3].Selected)
                                    montoHospedaje = 0;

                                //if (montoDesayuno == 0 && montoAlmuerzo == 0 && montoCena == 0 && montoHospedaje == 0)
                                //    throw new Exception("La hora mínima para el día de retorno es 07:01 hrs");
                            }
                        }
                        dr["ID"] = "0";
                        dr["DIA"] = (i + 1);
                        dr["FECHA"] = "";
                        dr["CUOTA"] = montoDesayuno + montoAlmuerzo + montoCena + montoHospedaje;
                        dr["CUOTA_DOLARES"] = "0";
                        dr["MONTO_DESAYUNO"] = montoDesayuno;
                        dr["MONTO_ALMUERZO"] = montoAlmuerzo;
                        dr["MONTO_CENA"] = montoCena;
                        dr["MONTO_HOSPEDAJE"] = montoHospedaje;
                        dr["SUBTOTAL"] = montoDesayuno + montoAlmuerzo + montoCena + montoHospedaje;
                        dr["USUARIO"] = Session["usuario"].ToString();
                        
                        dsDetalles.Tables[0].Rows.Add(dr);

                        totalViaticos += montoDesayuno + montoAlmuerzo + montoCena + montoHospedaje;
                    }

                    pViaticosEN.COSTO_VIATICOS = totalViaticos;

                    if (true)
                    {
                        if (validarEstadoSolicitud(idViatico))
                        {
                            pViaticosLN = new ViaticosLN();
                            DataSet dsResultado = pViaticosLN.AlmacenarViaticos(pViaticosEN, dsDetalles.Tables[0],Session["usuario"].ToString());

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
                            btnGuardar.Enabled = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar(). " + ex.Message;
            }
        }

        protected bool ValidarPptoUIDetalle(int idEncabezado, decimal subTotal)
        {
            pAccionLN = new PlanAccionLN();
            pAnualLN = new PlanAnualLN();
            bool pptoValido = false;

            decimal saldoPac, saldoRenglon, montoDetPedido = 0;

            /*if (idPac > 0)
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
            }*/

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

                    if (ValidarPptoUIDetalle(0, 0))
                    {
                        if (validarEstadoSolicitud(idViatico))
                        {
                            if (idViatico == 0)
                                throw new Exception("No existe Viático para finalizar");

                            pViaticosLN = new ViaticosLN();
                            DataSet dsResultado = pViaticosLN.EnviarViaticoARevision(idViatico, 1, Session["usuario"].ToString());

                            if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                            btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
                            lblSuccess.Text = "Viático finalizado correctamente!";
                            ///Falta correo
                            Response.Redirect("NoViatico.aspx?No=" + Convert.ToString(idViatico) + "&msg=VIATICO_AL_INTERIOR" + "&acc=ENVIADO");
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

            rblCategoria.Visible = true;
            limpiarControlesError();
            if (rblTipoPersonal.SelectedValue.Equals("1"))
            {
                txtNombre.Visible = false;
                ddlEmpleados.Visible = true;

                txtPuesto.ReadOnly = true;
                txtPuesto.Visible = true;

                string usuario = Session["usuario"].ToString();
                int idUnidad = 0;
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                pViaticosLN = new ViaticosLN();
                pViaticosLN.DdlSolicitantes(ddlEmpleados, usuario, idUnidad);
                pViaticosLN.DdlPuestosEmpleado(ddlPuestos, "", 0);

                rblCategoria.Enabled = false;
            }
            else //if (rblTipoPersonal.SelectedValue.Equals("2"))
            {
                txtNombre.Visible = true;
                ddlEmpleados.Visible = false;

                txtPuesto.ReadOnly = false;
                txtPuesto.Text = string.Empty;
                //txtPuesto.Visible = false;

                txtSueldoBase.Text = "0";

                pViaticosLN = new ViaticosLN();
                pViaticosLN.DdlPuestosEmpleado(ddlPuestos, "", 0);

                ddlEmpleados.ClearSelection();
                ddlEmpleados.Items.Clear();
                ddlEmpleados.DataBind();

                if (rblTipoPersonal.SelectedValue.Equals("2"))
                {
                    rblCategoria.SelectedValue = "38";
                    rblCategoria_SelectedIndexChanged(new object(), new EventArgs());

                    rblCategoria.Enabled = false;
                }

                if (rblTipoPersonal.SelectedValue.Equals("3"))
                {
                    rblCategoria.SelectedValue = "40";
                    rblCategoria_SelectedIndexChanged(new object(), new EventArgs());

                    rblCategoria.Enabled = true;
                }

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

                rblCategoria_SelectedIndexChanged(new object(), new EventArgs());
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

        protected void rblVehiculoInst_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void chkViaticosSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idEncabezado = 0;
                int.TryParse(lblIdEncabezado.Text, out idEncabezado);

                if (idEncabezado > 0)
                {
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "chkViaticosSalida(). " + ex.Message;
            }
        }

        protected void chkViaticosRetorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idEncabezado = 0;
                int.TryParse(lblIdEncabezado.Text, out idEncabezado);

                if (idEncabezado > 0)
                {
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "chkViaticosRetorno(). " + ex.Message;
            }
        }

        protected decimal calculoCuotaDiaria(int tipoPersona, decimal sueldoBase)
        {
            decimal cuotaDiaria = 0;

            if (tipoPersona == 2)
            {
                cuotaDiaria = 330;
                rblCategoria.SelectedValue = "38";
            }

            if (tipoPersona == 3)
            {
                /*cuotaDiaria = 260;
                rblCategoria.SelectedValue = "40";*/

                if (rblCategoria.SelectedValue == "39")
                    cuotaDiaria = 260;

                if (rblCategoria.SelectedValue == "38")
                    cuotaDiaria = 330;

                if (rblCategoria.SelectedValue == "37")
                    cuotaDiaria = 400;

                if (rblCategoria.SelectedValue == "36")
                    cuotaDiaria = 480;
            }

            if (tipoPersona == 1)
            {
                if (sueldoBase >= 0 && sueldoBase <= 6000)
                {
                    cuotaDiaria = 260;
                    rblCategoria.SelectedValue = "39";
                }

                if (sueldoBase > 6000 && sueldoBase <= 8000)
                {
                    cuotaDiaria = 330;
                    rblCategoria.SelectedValue = "38";
                }

                if (sueldoBase > 8000 && sueldoBase <= 10000)
                {
                    cuotaDiaria = 400;
                    rblCategoria.SelectedValue = "37";
                }

                if (sueldoBase > 10000)
                {
                    cuotaDiaria = 480;
                    rblCategoria.SelectedValue = "36";
                }
            }           

            return cuotaDiaria;
        }



        protected void rblCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblCategoria.SelectedValue.Equals("36"))
                txtCategoria.Text = "Comités Ejecutivos, Tribunal de Honor, Comisón de Fisalización Administrativo-Contable, Órganos Disciplinarios, Comisiones Técnico-Deportiva. Y Mayores de Q 10,000.00";

            if (rblCategoria.SelectedValue.Equals("37"))
                txtCategoria.Text = "Desde Q 8,000.01 Hasta Q 10,000.00";

            if (rblCategoria.SelectedValue.Equals("38"))
                txtCategoria.Text = "Deportistas y desde Q 6,000.01 Hasta Q 8,000.00";

            if (rblCategoria.SelectedValue.Equals("39"))
                txtCategoria.Text = "Menos de Q 4,000.00 Hasta Q 6,000.00";

            if (rblCategoria.SelectedValue.Equals("40"))
                txtCategoria.Text = "Personal externo Autorizado por Comités Ejecutivos";            
        }

        protected void lbDesayuno_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                GridViewRow grid = (GridViewRow)((Control)sender).Parent.Parent;
                int indice = grid.RowIndex;

                gridDet.SelectedIndex = grid.RowIndex;

                int idEncabezado, idDetalle = 0;
                int.TryParse(lblIdEncabezado.Text, out idEncabezado);
                int.TryParse(gridDet.SelectedValue.ToString(), out idDetalle);

                if (idDetalle == 0)
                    throw new Exception("Detalle no válido, idDetalle: " + idDetalle);

                pViaticosLN = new ViaticosLN();
                DataSet dsResultado = pViaticosLN.EliminarDetalle(idDetalle, idEncabezado, "DESAYUNO");

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                NuevoDet();
                lblSuccess.Text = "Desayuno eliminado exitosamente!";
            }
            catch (Exception ex)
            {
                lblError.Text = "lbDesayuno(). " + ex.Message;
            }

        }

        protected void lbAlmuerzo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                GridViewRow grid = (GridViewRow)((Control)sender).Parent.Parent;
                int indice = grid.RowIndex;

                gridDet.SelectedIndex = grid.RowIndex;

                int idEncabezado, idDetalle = 0;
                int.TryParse(lblIdEncabezado.Text, out idEncabezado);
                int.TryParse(gridDet.SelectedValue.ToString(), out idDetalle);

                if (idDetalle == 0)
                    throw new Exception("Detalle no válido, idDetalle: " + idDetalle);

                pViaticosLN = new ViaticosLN();
                DataSet dsResultado = pViaticosLN.EliminarDetalle(idDetalle, idEncabezado, "ALMUERZO");

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                NuevoDet();
                lblSuccess.Text = "Almuerzo eliminado exitosamente!";

            }
            catch (Exception ex)
            {
                lblError.Text = "lbAlmuerzo(). " + ex.Message;
            }
        }

        protected void lbCena_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                GridViewRow grid = (GridViewRow)((Control)sender).Parent.Parent;
                int indice = grid.RowIndex;

                gridDet.SelectedIndex = grid.RowIndex;

                int idEncabezado, idDetalle = 0;
                int.TryParse(lblIdEncabezado.Text, out idEncabezado);
                int.TryParse(gridDet.SelectedValue.ToString(), out idDetalle);

                if (idDetalle == 0)
                    throw new Exception("Detalle no válido, idDetalle: " + idDetalle);

                pViaticosLN = new ViaticosLN();
                DataSet dsResultado = pViaticosLN.EliminarDetalle(idDetalle, idEncabezado, "CENA");

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                NuevoDet();
                lblSuccess.Text = "Cena eliminada exitosamente!";
            }
            catch (Exception ex)
            {
                lblError.Text = "lbCena(). " + ex.Message;
            }
        }

        protected void lbHospedaje_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                GridViewRow grid = (GridViewRow)((Control)sender).Parent.Parent;
                int indice = grid.RowIndex;

                gridDet.SelectedIndex = grid.RowIndex;

                int idEncabezado, idDetalle = 0;
                int.TryParse(lblIdEncabezado.Text, out idEncabezado);
                int.TryParse(gridDet.SelectedValue.ToString(), out idDetalle);

                if (idDetalle == 0)
                    throw new Exception("Detalle no válido, idDetalle: " + idDetalle);

                pViaticosLN = new ViaticosLN();
                DataSet dsResultado = pViaticosLN.EliminarDetalle(idDetalle, idEncabezado, "HOSPEDAJE");

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                NuevoDet();
                lblSuccess.Text = "Hospedaje eliminado exitosamente!";
            }
            catch (Exception ex)
            {
                lblError.Text = "lbHospedaje(). " + ex.Message;
            }
        }

    }
}
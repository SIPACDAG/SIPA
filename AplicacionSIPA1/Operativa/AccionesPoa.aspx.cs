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

namespace AplicacionSIPA1.Operativa
{
    public partial class AccionesPoa : System.Web.UI.Page
    {
        private PlanEstrategicoLN planEstrategicoLN;
        private PlanOperativoLN planOperativoLN;

        private PlanAccionLN planAccionLN;
        private AccionesEN accionesEN;
        private MetasAccionEN metasEN;
        private AccionesDetEN accionDetEN;

        decimal totalP, totalC, totalS = 0;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    btnNuevo_Click(sender, e);
                }
                catch (Exception ex)
                {
                    lblErrorBusqueda.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void rblCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorBusqueda.Text = string.Empty;
            txtBValor.Focus();
        }

        protected void txtBValor_TextChanged(object sender, EventArgs e)
        {
            lblErrorBusqueda.Text = string.Empty;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                upBuscar.Visible = false;
                upModificar.Visible = true;
                upModRenglon.Visible = false;

                lblIdPoa.Text = "0";
                lblEncabezado.Text = string.Empty;
                lblEstadoPoa.Text = string.Empty;
                planEstrategicoLN = new PlanEstrategicoLN();
                planEstrategicoLN.DdlPlanes(ddlPlanes);

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
                planEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);

                int anioActual = (DateTime.Now.Year + 1);

                ListItem item = ddlAnios.Items.FindByValue(anioActual.ToString());
                if (item != null)
                    ddlAnios.SelectedValue = anioActual.ToString();

                planOperativoLN = new PlanOperativoLN();
                planOperativoLN.DdlUnidades(ddlUnidades, Session["Usuario"].ToString().ToLower());

                obtenerPresupuesto(0, 0);
                planAccionLN = new PlanAccionLN();
                planAccionLN.DdlDependenciasUsuario(ddlDependencias, "", 0);
                limpiarCNuevaAccion();
                limpiarCNuevaMeta();
                limpiarCPlanOperativo();

                txtPonderacion.Enabled = false;
                //txtPpto.Enabled = false;

                if (ddlUnidades.Items.Count == 1)
                {
                    planAccionLN.DdlDependenciasUsuario(ddlDependencias, Session["usuario"].ToString(), int.Parse(ddlUnidades.SelectedValue));

                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                        
                        planOperativoLN.DdlObjetivosB(ddlObjetivos, int.Parse(ddlAnios.SelectedValue), int.Parse(ddlUnidades.SelectedValue));
                        ddlObjetivos.Items[0].Text = "<< Elija un valor >>";
                    }
                }

                chkAccion.Visible = false;
                chkAccion.Enabled = false;
                chkAccion.Checked = true;
                chkAccion_CheckedChanged(sender, e);

                limpiarNListado();
                ddlAcciones.Focus();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo_Click()" + ex.Message;
            }
        }

        protected void limpiarCNuevaAccion()
        {
            planAccionLN = new PlanAccionLN();
            planAccionLN.DdlAcciones(ddlAcciones, 0);
            txtCodigo.Text = txtAccion.Text = string.Empty;
            txtCodigo.Enabled = false;
            rfvCodigo.Enabled = rfvAccion.Enabled = false; 
        }

        protected void limpiarCPlanOperativo()
        {
            planOperativoLN = new PlanOperativoLN();

            int anio, idUnidad = 0;
            int.TryParse(ddlAnios.SelectedValue, out anio);
            int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

            planOperativoLN.DdlObjetivosB(ddlObjetivos, anio, idUnidad);
            planOperativoLN.DdlIndicadores(ddlIndicadores, 0);
            planOperativoLN.DdlMetas(ddlMetasO, 0);
            ddlObjetivos.Items[0].Text = "<< Elija un valor >>";
            ddlIndicadores.Items[0].Text = "<< Elija un valor >>";
            ddlMetasO.Items[0].Text = "<< Elija un valor >>";

            ddlObjetivos.Enabled = ddlIndicadores.Enabled = ddlMetasO.Enabled = true;
            gridPlanO.DataSource = null;
            gridPlanO.DataBind();
        }

        protected void limpiarCNuevaMeta()
        {
            planAccionLN = new PlanAccionLN();
            planAccionLN.DdlMetas(ddlMetas, 0);
            ddlMetas.Enabled = false;
            txtMeta.Text = txtMeta1.Text = txtMeta2.Text = txtMeta3.Text = string.Empty;
            txtPonderacion1.Text = txtPonderacion2.Text = txtPonderacion3.Text = txtPonderacion.Text = "0";
            lblPpto.Text = /*txtPpto.Text =*/ String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
            txtResponsable.Text = string.Empty;
            txtM1.Text = txtM2.Text = txtM3.Text = txtM4.Text = string.Empty;
            txtM5.Text = txtM6.Text = txtM7.Text = txtM8.Text = string.Empty;
            txtM9.Text = txtM10.Text = txtM11.Text = txtM12.Text = string.Empty;

            rfvMeta.Enabled = rfvMetaC1.Enabled = rfvMetaC2.Enabled = rfvMetaC3.Enabled = false;
            rfvPond1.Enabled = rfvPond2.Enabled = rfvPond3.Enabled = rfvPonderacion.Enabled = false;
            rvPond.Enabled = false;
            /*rfvPresupuesto.Enabled = */rfvResponsable.Enabled = false;
        }

        protected void limpiarNListado()
        {
            ListItem item = new ListItem("N/A", "null");

            ddlInsumos.ClearSelection();
            ddlInsumos.Items.Clear();
            ddlInsumos.Items.Add(item);
            ddlInsumos.SelectedIndex = 0;

            planAccionLN = new PlanAccionLN();
            planAccionLN.DdlRenglones(ddlRenglones);
            planAccionLN.DdlFinanciamiento(ddlFuentes);
            txtMonto.Text = "0";

            int idAccion = 0;
            int.TryParse(ddlAcciones.SelectedValue, out idAccion);

            decimal pptoAccion = 0;

            planAccionLN.GridDetallesAccion(gridRenglon, idAccion, 1);
            DataTable dt = (DataTable)(gridRenglon.DataSource);

            if (dt.Rows.Count > 0 && !dt.Rows[0]["NO_RENGLON"].ToString().Equals(""))
            {
                if (dt.Rows.Count > 0)
                {
                    decimal monto, codificado, saldo;

                    decimal.TryParse(dt.Compute("SUM(MONTO)", "").ToString(), out monto);
                    decimal.TryParse(dt.Compute("SUM(CODIFICADO)", "").ToString(), out codificado);
                    decimal.TryParse(dt.Compute("SUM(SALDO)", "").ToString(), out saldo);

                    gridRenglon.FooterRow.Cells[4].Text = "TOTALES";
                    gridRenglon.FooterRow.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", monto);
                    gridRenglon.FooterRow.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", codificado);
                    gridRenglon.FooterRow.Cells[8].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);

                    gridRenglon.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                    gridRenglon.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                    gridRenglon.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;

                    decimal.TryParse(dt.Compute("SUM(MONTO)", "").ToString(), out pptoAccion);
                }
                
                lblPpto.Text = /*txtPpto.Text =*/ String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoAccion); 
            }
            else
            {
                gridRenglon.DataSource = null;
                gridRenglon.DataBind();

                lblPpto.Text = /*txtPpto.Text =*/ String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0); 
            }
        }


        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                int anio = int.Parse(ddlAnios.SelectedValue);
                int idUnidad = int.Parse(ddlUnidades.SelectedValue);

                //btnNuevo_Click(sender, e);
                ddlPlanes.SelectedValue = idPlan.ToString();
                ddlPlanes_SelectedIndexChanged(sender, e);

                ddlAnios.SelectedValue = anio.ToString();
                btnGuardar.Visible = false;


                planOperativoLN = new PlanOperativoLN();
                planOperativoLN.DdlObjetivosB(ddlObjetivos, anio, idUnidad);
                ddlObjetivos.Items[0].Text = "<< Elija un valor >>";

                planAccionLN = new PlanAccionLN();
                planAccionLN.DdlDependenciasUsuario(ddlDependencias, Session["usuario"].ToString(), idUnidad);
                
                if (idUnidad > 0)
                {
                    ddlUnidades.SelectedValue = idUnidad.ToString();
                    
                    if (anio > 0 && idUnidad > 0)
                        validarPoa(idUnidad, anio);

                    if (ddlDependencias.Items.Count == 1)
                        ddlDependencias_SelectedIndexChanged(sender, e);
                }

                planOperativoLN = new PlanOperativoLN();
                planOperativoLN.DdlObjetivosB(ddlObjetivos, int.Parse(ddlAnios.SelectedValue), int.Parse(ddlUnidades.SelectedValue));
                ddlObjetivos.Items[0].Text = "<< Elija un valor >>";

                chkAccion.Checked = true;
                chkAccion_CheckedChanged(sender, e);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                int anio = int.Parse(ddlAnios.SelectedValue);
                int idUnidad = int.Parse(ddlUnidades.SelectedValue);

                //btnNuevo_Click(sender, e);
                ddlPlanes.SelectedValue = idPlan.ToString();
                ddlPlanes_SelectedIndexChanged(sender, e);

                ddlUnidades.SelectedValue = idUnidad.ToString();
                btnGuardar.Visible = false;

                if (anio > 0)
                {
                    ddlAnios.SelectedValue = anio.ToString();                    
                    if (anio > 0 && idUnidad > 0)
                        validarPoa(idUnidad, anio);
                }

                planOperativoLN = new PlanOperativoLN();
                planOperativoLN.DdlObjetivosB(ddlObjetivos, int.Parse(ddlAnios.SelectedValue), int.Parse(ddlUnidades.SelectedValue));
                ddlObjetivos.Items[0].Text = "<< Elija un valor >>";

                chkAccion.Checked = true;
                chkAccion_CheckedChanged(sender, e);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                txtCodigo.Text = txtAccion.Text = lblPpto.Text = /*txtPpto.Text =*/ string.Empty;
                txtCodigo.Enabled = false;
                rfvCodigo.Enabled = rfvAccion.Enabled = false;

                limpiarCPlanOperativo();
                limpiarCNuevaMeta(); 

                obtenerPresupuesto(int.Parse(lblIdPoa.Text), int.Parse(ddlDependencias.SelectedValue));
                ddlDependencias.ClearSelection();

                int vValue = int.Parse(ddlAcciones.SelectedValue);
                if (vValue > 0)
                {
                    planAccionLN = new PlanAccionLN();
                    DataSet dsResultado = planAccionLN.InformacionAccion(vValue);

                    ddlDependencias.SelectedValue = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_DEPENDENCIA"].ToString();
                    txtCodigo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["CODIGO"].ToString();
                    txtAccion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ACCION"].ToString();

                    decimal pptoAccion = 0;
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["MONTO_ACCION"].ToString(), out pptoAccion);
                    lblPpto.Text = /*txtPpto.Text =*/ String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoAccion);

                    txtCodigo.Enabled = true;

                    planAccionLN.DdlMetas(ddlMetas, vValue);
                    if (ddlMetas.Items.Count == 1)
                    {
                        ddlMetas.SelectedIndex = 0;
                        ddlMetas_SelectedIndexChanged(sender, e);
                    }

                    if (chkAccion.Checked)
                    {
                        int idOO, idIO, idMO = 0;

                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_OBJETIVO_OPERATIVO"].ToString(), out idOO);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_KPI_OPERATIVO"].ToString(), out idIO);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_META_OPERATIVA"].ToString(), out idMO);

                        ddlObjetivos.ClearSelection();
                        ddlIndicadores.ClearSelection();
                        ddlMetasO.ClearSelection();

                        ListItem item;
                        item = ddlObjetivos.Items.FindByValue(idOO.ToString());

                        if (item != null)
                            ddlObjetivos.SelectedValue = idOO.ToString();

                        vValue = int.Parse(ddlObjetivos.SelectedValue);

                        planOperativoLN = new PlanOperativoLN();
                        planOperativoLN.DdlIndicadores(ddlIndicadores, idOO);
                        ddlIndicadores.Items[0].Text = "<< Elija un valor >>";

                        item = ddlIndicadores.Items.FindByValue(idIO.ToString());

                        if (item != null)
                            ddlIndicadores.SelectedValue = idIO.ToString();

                        planOperativoLN.DdlMetas(ddlMetasO, idIO);
                        ddlMetasO.Items[0].Text = "<< Elija un valor >>";

                        item = ddlMetasO.Items.FindByValue(idMO.ToString());

                        if (item != null)
                            ddlMetasO.SelectedValue = idMO.ToString();

                        filtrarGridPlanO(string.Empty);

                        int idDependencia = 0;
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_DEPENDENCIA"].ToString(), out idDependencia);
                        item = ddlDependencias.Items.FindByValue(idDependencia.ToString());
                        if (item != null)
                        {
                            ddlDependencias.ClearSelection();
                            ddlDependencias.SelectedValue = idDependencia.ToString();
                            ddlDependencias_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                limpiarNListado();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlObjetivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                if (chkAccion.Checked == false)
                {
                    limpiarCNuevaAccion();
                    limpiarCNuevaMeta();
                }

                int vValue = int.Parse(ddlObjetivos.SelectedValue);

                if (vValue > 0)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlIndicadores(ddlIndicadores, vValue);
                    ddlIndicadores.Items[0].Text = "<< Elija un valor >>";

                    if (ddlIndicadores.Items.Count == 2)
                    {
                        ddlIndicadores.SelectedIndex = 1;
                        ddlIndicadores_SelectedIndexChanged(sender, e);
                        ddlIndicadores.Enabled = false;
                    }
                    else
                    {
                        ddlIndicadores.SelectedIndex = 0;
                        ddlIndicadores_SelectedIndexChanged(sender, e);
                        ddlIndicadores.Enabled = true;

                        filtrarGridPlanO(string.Empty);
                    }
                }
                else
                    limpiarCPlanOperativo();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlObjetivos_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void filtrarGridPlanO(string id)
        {
            gridPlanO.DataSource = null;
            gridPlanO.DataBind();
            gridPlanO.SelectedIndex = -1;

            planOperativoLN = new PlanOperativoLN();
            planOperativoLN.GridBusqueda(gridPlanO, Session["usuario"].ToString());

            string filtro = string.Empty;

            object obj = gridPlanO.DataSource;
            System.Data.DataTable tbl = gridPlanO.DataSource as System.Data.DataTable;
            System.Data.DataView dv = tbl.DefaultView;

            filtro = " anio = " + ddlAnios.SelectedValue;

            if (!ddlObjetivos.SelectedValue.Equals("0"))
                filtro += " AND id_objetivo_operativo = " + ddlObjetivos.SelectedValue;

            if (!ddlIndicadores.SelectedValue.Equals("0"))
                filtro += " AND id_kpi_operativo = " + ddlIndicadores.SelectedValue;

            if (!ddlMetasO.SelectedValue.Equals("0"))
                filtro += " AND id = " + ddlMetasO.SelectedValue;

            if (!id.Equals(string.Empty))
                filtro += " AND id = " + id;

            dv.RowFilter = filtro;

            gridPlanO.DataSource = dv;
            gridPlanO.DataBind() ;

            if (gridPlanO.Rows.Count == 1)
                gridPlanO.SelectedIndex = 0;

            if (chkAccion.Checked == false)
            {
                planOperativoLN = new PlanOperativoLN();
                DataSet ds = planOperativoLN.BuscarId(gridPlanO.SelectedValue.ToString());
                string idkpiO = ds.Tables["BUSQUEDA"].Rows[0]["ID_KPI_O"].ToString();

                ListItem item = ddlIndicadores.Items.FindByValue(idkpiO);
                if (item != null)
                    ddlIndicadores.SelectedValue = idkpiO;

                planAccionLN = new PlanAccionLN();
                planAccionLN.DdlAcciones(ddlAcciones, int.Parse(gridPlanO.SelectedValue.ToString()));
                //txtAccion.Focus();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                planAccionLN = new PlanAccionLN();
                accionesEN = new AccionesEN();
                metasEN = new MetasAccionEN();

                string mensaje = "";
                DataSet dsResultado = new DataSet();
                int idAccion = int.Parse(ddlAcciones.SelectedValue);
                int idMeta = 0;
                int idMetaOperativa = 0;

                if (ddlMetas.Items.Count > 0)
                    idMeta = int.Parse(ddlMetas.SelectedValue);
                //INSERTAR/ACTUALIZAR
                if (validarControlesABC())
                {
                    rfvCodigo.Enabled = false;
                    rfvAccion.Enabled = rfvMeta.Enabled = rfvMetaC1.Enabled = rfvMetaC2.Enabled = rfvMetaC3.Enabled = true;
                    rfvPonderacion.Enabled = /*rfvPresupuesto.Enabled = */rfvResponsable.Enabled = true;

                    int idPoa = int.Parse(lblIdPoa.Text);
                    int idDependencia = int.Parse(ddlDependencias.SelectedValue);
                    obtenerPresupuesto(idPoa, idDependencia);

                    idMetaOperativa = int.Parse(gridPlanO.SelectedValue.ToString());
                    accionesEN.Id_Accion = idAccion;
                    accionesEN.Id_Dependencia = idDependencia;
                    accionesEN.Id_Objetivo_Operativo = int.Parse(ddlObjetivos.SelectedValue);
                    accionesEN.Id_Meta_Operativa = idMetaOperativa;
                    accionesEN.Id_Poa = idPoa;
                    accionesEN.Accion = txtAccion.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                    txtAccion.Text = accionesEN.Accion;

                    if (!txtCodigo.Text.Equals(string.Empty))
                        accionesEN.Codigo = int.Parse(txtCodigo.Text);

                    accionesEN.Id_Unidad = int.Parse(ddlUnidades.SelectedValue);
                    accionesEN.Usuario = Session["usuario"].ToString();

                    dsResultado = planAccionLN.AlmacenarAccion(accionesEN, Session["usuario"].ToString());

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ la acción: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    txtCodigo.Text = dsResultado.Tables[0].Rows[0]["CODIGO"].ToString();
                    txtCodigo.Enabled = true;

                    if (idAccion == 0)
                    {
                        mensaje += "Acción INSERTADA correctamente. \n";
                    }
                    else
                        mensaje += "Acción ACTUALIZADA correctamente. \n";

                    idAccion = int.Parse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString());
                    metasEN.Id_Accion = idAccion;
                    metasEN.Id_Meta_Accion = idMeta;
                    metasEN.Id_Meta_Operativa = idMetaOperativa;

                    metasEN.Meta_1 = txtMeta1.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                    txtMeta1.Text = metasEN.Meta_1;
                    metasEN.Meta_2 = txtMeta2.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                    txtMeta2.Text = metasEN.Meta_2;
                    metasEN.Meta_3 = txtMeta3.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                    txtMeta3.Text = metasEN.Meta_3;
                    metasEN.Meta_General = txtMeta.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                    metasEN.No_Actividades = 0;
                    //metasEN.Ponderacion = int.Parse(txtPonderacion.Text);
                    metasEN.Ponderacion1 = decimal.Parse(txtPonderacion1.Text);
                    metasEN.Ponderacion2 = decimal.Parse(txtPonderacion2.Text);
                    metasEN.Ponderacion3 = decimal.Parse(txtPonderacion3.Text);

                    txtPonderacion1.Text = metasEN.Ponderacion1.ToString();
                    txtPonderacion2.Text = metasEN.Ponderacion2.ToString();
                    txtPonderacion3.Text = metasEN.Ponderacion3.ToString();

                    //metasEN.Presupuesto = decimal.Parse(txtPpto.Text);
                    metasEN.Responsable = txtResponsable.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                    txtResponsable.Text = metasEN.Responsable;
                    metasEN.Enero = txtM1.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Febrero = txtM2.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Marzo = txtM3.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Abril = txtM4.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Mayo = txtM5.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Junio = txtM6.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Julio = txtM7.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Agosto = txtM8.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Septiembre = txtM9.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Octubre = txtM10.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Noviembre = txtM11.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Diciembre = txtM12.Text.Equals(string.Empty) ? 0 : 1;
                    metasEN.Anio = int.Parse(ddlAnios.SelectedValue);
                    metasEN.Usuario = Session["usuario"].ToString();                    

                    dsResultado = planAccionLN.AlmacenarMeta(metasEN);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ la meta: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    if (idMeta == 0)
                        mensaje += "Meta INSERTADA correctamente. \n";
                    else
                        mensaje += "Meta ACTUALIZADA correctamente. \n";

                    idMeta = int.Parse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString());

                    chkAccion_CheckedChanged(sender, e);

                    ddlAcciones.ClearSelection();
                    ddlAcciones.SelectedValue = idAccion.ToString();
                    mensaje = "Acción almacenada exitosamente!, para almacenar una nueva acción presione NUEVO, para agregar renglones a la acción actual, ingrese renglón monto y presione + ";


                    lblSuccess.Text = mensaje;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);


                    //mensaje = "Operación exitosa! ;-). " + mensaje + " Si desea agregar renglones, seleccione la acción en el listado de acciones. ";                    
                }
            }
            catch (Exception ex)
            {
                string mensaje = "Error al operar el registro. " + ex.Message;
                lblError.Text = mensaje;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
            }
        }
        
        protected DataSet guardarDetalleAccion(int idPoa, int idDependencia, int idDetalle, int idAccion, string noRenglon, int idTipoFinanciamiento, decimal monto, string idInsumo, string usuario)
        {
            DataSet dsResultado = new DataSet();
            try
            {

                string mensaje = string.Empty;
                planAccionLN = new PlanAccionLN();
                DataSet dsPpto = planAccionLN.PptoPoa(idPoa, idDependencia);

                decimal disponible = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE_DEPENDENCIA"].ToString());


                DataSet dsPptoRenglon = planAccionLN.PptoRenglonAccion(idDetalle);
                decimal saldoDetalleAccion = 0;
                
                if(idDetalle > 0)
                    decimal.TryParse(dsPptoRenglon.Tables["BUSQUEDA"].Rows[0]["SALDO_POA"].ToString(), out saldoDetalleAccion);

                decimal diferenciaNuevoMontoDetAccion = (disponible + saldoDetalleAccion) - monto;
                
                //AQUÍ FALTA
                DataSet dsAccion = new DataSet();
                if (diferenciaNuevoMontoDetAccion < 0)
                    throw new Exception("El presupuesto ingresado supera al disponible por " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", disponible - monto));

                int idTipoDetalle = 0;

                //2 = RENGLÓN , 1 = INSUMO
                if (idInsumo.Equals("null"))
                    idTipoDetalle = 2;
                else
                    idTipoDetalle = 1;

                accionDetEN = new AccionesDetEN();
                accionDetEN.Id_Detalle = idDetalle;
                accionDetEN.Id_Accion = idAccion;
                accionDetEN.No_Renglon = noRenglon;
                accionDetEN.Id_Tipo_Financiamiento = idTipoFinanciamiento;
                accionDetEN.Monto = monto;
                accionDetEN.Id_Insumo = idInsumo;
                accionDetEN.Id_Tipo_Detalle = idTipoDetalle;
                accionDetEN.Usuario = Session["usuario"].ToString();

                planAccionLN = new PlanAccionLN();
                dsResultado = planAccionLN.AlmacenarDetalle(accionDetEN, Session["usuario"].ToString());

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se INSERTÓ/ACTUALIZÓ el detalle: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                mensaje += "Detalle INSERTADO/ACTUALIZADO exitosamente!. ";
                limpiarNListado();
            }
            catch (Exception ex)
            {
                planAccionLN = new PlanAccionLN();
                dsResultado = planAccionLN.armarDsResultado();
                dsResultado.Tables[0].Rows[0]["ERRORES"] = true;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = ex.Message;
            }
            return dsResultado;
        }

        protected void limpiarControlesError()
        {
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;

            lblEAnio.Text = string.Empty;
            lblEUnidad.Text = string.Empty;
            lblEObjetivo.Text = string.Empty;
            lblEIndicador.Text = string.Empty;
            lblEMetasO.Text = string.Empty;
            lblEPlan.Text = string.Empty;
            lblEDependencia.Text = string.Empty;
            lblEMeses.Text = string.Empty;

            lblErrorModMonto.Text = string.Empty;
            lblSuccessMonto.Text = string.Empty;
        }

        private bool validarControlesABC()
        {
            limpiarControlesError();
            bool controlesValidos = false;

            try
            {
                if (ddlAnios.SelectedValue.Equals("0") || ddlAnios.Items.Count == 0)
                {
                    lblEAnio.Text = "*";
                    lblError.Text += "Seleccione un Año!. ";
                }

                if (ddlUnidades.SelectedValue.Equals("0") || ddlUnidades.Items.Count == 0)
                {
                    lblEUnidad.Text = "*";
                    lblError.Text += "Seleccione una Unidad!. ";
                }

                if (ddlObjetivos.SelectedValue.Equals("0") || ddlObjetivos.Items.Count == 0)
                {
                    lblEObjetivo.Text = "*";
                    lblError.Text += "Seleccione un Objetivo Operativo!. ";
                }

                if (ddlIndicadores.SelectedValue.Equals("0") || ddlIndicadores.Items.Count == 0)
                {
                    lblEIndicador.Text = "*";
                    lblError.Text += "Seleccione un Indicador!. ";
                }

                if (ddlMetasO.SelectedValue.Equals("0") || ddlMetasO.Items.Count == 0)
                {
                    lblEMetasO.Text = "*";
                    lblError.Text += "Seleccione una Meta Operativa!. ";
                }

                if (ddlDependencias.SelectedValue.Equals("0") || ddlDependencias.Items.Count == 0)
                {
                    lblEDependencia.Text = "*";
                    lblError.Text += "Seleccione una Dependencia!. ";
                }

                if (gridPlanO.SelectedValue == null)
                {
                    lblEPlan.Text = "*";
                    lblError.Text += "Seleccione una Meta!. ";
                }

                if (txtM1.Text.Equals(string.Empty) && txtM2.Text.Equals(string.Empty) && txtM3.Text.Equals(string.Empty) && txtM4.Text.Equals(string.Empty) && txtM5.Text.Equals(string.Empty) && txtM6.Text.Equals(string.Empty) && txtM7.Text.Equals(string.Empty) && txtM8.Text.Equals(string.Empty) && txtM9.Text.Equals(string.Empty) && txtM10.Text.Equals(string.Empty) && txtM11.Text.Equals(string.Empty) && txtM12.Text.Equals(string.Empty))
                {
                    lblEMeses.Text = "*";
                    lblError.Text += "Ingrese un Mes!. ";
                }

                if (lblEAnio.Text.Equals(string.Empty) && lblEUnidad.Text.Equals(string.Empty) && lblEObjetivo.Text.Equals(string.Empty) && lblEIndicador.Text.Equals(string.Empty) && lblEMetasO.Text.Equals(string.Empty) && lblEDependencia.Text.Equals(string.Empty) && lblEPlan.Text.Equals(string.Empty) && lblEMeses.Text.Equals(string.Empty))
                    controlesValidos = true;

                rfvCodigo.Enabled = false;
                if (txtCodigo.Enabled)
                    rfvCodigo.Enabled = true;
                rfvAccion.Enabled = rfvMeta.Enabled = rfvMetaC1.Enabled = rfvMetaC2.Enabled = rfvMetaC3.Enabled = true;
                rfvResponsable.Enabled = true;
                
                rfvPond1.Enabled = rfvPond2.Enabled = rfvPond3.Enabled = rfvPonderacion.Enabled = /*rfvPresupuesto.Enabled = */true;

                try
                {
                    int valor = int.Parse(txtPonderacion1.Text);
                }
                catch
                {
                    lblErrorPond1.Text = "Entre 1 y 100";
                    lblError.Text += "Ingrese una ponderación cuatrimestre 1 válida. ";
                }

                try
                {
                    int valor = int.Parse(txtPonderacion2.Text);
                }
                catch
                {
                    lblErrorPond2.Text = "Entre 1 y 100";
                    lblError.Text += "Ingrese una ponderación cuatrimestre 2 válida. ";
                }

                try
                {
                    int valor = int.Parse(txtPonderacion3.Text);
                }
                catch
                {
                    lblErrorPond3.Text = "Entre 1 y 100";
                    lblError.Text += "Ingrese una ponderación cuatrimestre 3 válida. ";
                }

                int pond1, pond2, pond3;
                pond1 = pond2 = pond3 = 0;
                int.TryParse(txtPonderacion1.Text, out pond1);
                int.TryParse(txtPonderacion2.Text, out pond2);
                int.TryParse(txtPonderacion3.Text, out pond3);
                txtPonderacion.Text = int.Parse((pond1 + pond2 + pond3).ToString()).ToString();

                rvPond.Enabled = false;

                this.Page.Validate("grpDatos");

                if (!rfvAccion.IsValid)
                    lblError.Text += "Ingrese la descripción de la acción!. ";

                if (!rfvMeta.IsValid)
                    lblError.Text += "Ingrese la meta anual de la acción!. ";

                if (!rfvMetaC1.IsValid)
                    lblError.Text += "Ingrese la meta del primer cuatrimestre!. ";

                if (!rfvMetaC2.IsValid)
                    lblError.Text += "Ingrese la meta del segundo cuatrimestre!. ";

                if (!rfvMetaC3.IsValid)
                    lblError.Text += "Ingrese la meta del tercer cuatrimestre!. ";

                if (!rfvResponsable.IsValid)
                    lblError.Text += "Ingrese el responsable de la acción!. ";

                if (!rfvPond1.IsValid)
                    lblError.Text += "Ingrese la ponderación del primer cuatrimestre!. ";

                if (!rfvPond2.IsValid)
                    lblError.Text += "Ingrese la ponderación del segundo cuatrimestre!. ";

                if (!rfvPond3.IsValid)
                    lblError.Text += "Ingrese la ponderación del tercer cuatrimestre!. ";

                /*if(!rvPond.IsValid)
                    lblError.Text += "La ponderación de acciones debe ser entre 1 y 100!. ";*/

                if (!rfvPonderacion.IsValid)
                    lblError.Text += "Ingrese la ponderación anual!. ";

                /*if (!rfvPresupuesto.IsValid)
                    lblError.Text += "Ingrese el presupuesto de la acción!. ";*/

                if (controlesValidos && Page.IsValid)
                    controlesValidos = true;
                else
                    controlesValidos = false;

                rvPond.Enabled = rfvPond1.Enabled = rfvPond2.Enabled = rfvPond3.Enabled = rfvPonderacion.Enabled = /*rfvPresupuesto.Enabled = */false;
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }

            return controlesValidos;
        }

        private bool validarControlesABCDetalle()
        {
            limpiarControlesError();
            bool controlesValidos = false;

            try
            {
                int idRenglon, idFuente, idAccion;
                decimal monto = 0;
                idRenglon = idFuente = 0;
                monto = 0;
                
                int.TryParse(ddlRenglones.SelectedValue, out idRenglon);
                int.TryParse(ddlFuentes.SelectedValue, out idFuente);

                txtMonto.Text = stringToDecimalString(txtMonto.Text);
                decimal.TryParse(txtMonto.Text, out monto);
                int.TryParse(ddlAcciones.SelectedValue, out idAccion);

                lblError.Text = string.Empty;

                if (idRenglon <= 0)
                    lblError.Text = " Seleccione una acción!. ";

                if (idRenglon <= 0)
                    lblError.Text += " Seleccione un renglón!. ";

                if(idFuente < 0)
                    lblError.Text += " Seleccione una fuente de financiamiento!. ";

                if (monto <= 0)
                    lblError.Text += " Ingrese un monto";

                if (lblError.Text.Equals(string.Empty))
                    controlesValidos = true;
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }

            return controlesValidos;
        }

        protected bool validarPoa(int idUnidad, int anio)
        {
            lblError.Text = string.Empty;
            lblErrorPoa.Text = string.Empty;
            bool poaValido = false;
            btnGuardar.Visible = btnEliminarAccion.Visible = gridRenglon.Columns[0].Visible = gridRenglon.Columns[1].Visible = false;
            lblIdPoa.Text = "0";
            lblEstadoPoa.Text = string.Empty;
            try
            {
                lblTechoD.Text = lblTechoU.Text = lblAsignado.Text = lblDisponibleD.Text = lblDisponibleU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
                
                planOperativoLN = new PlanOperativoLN();
                DataSet dsPoa = planOperativoLN.DatosPoaUnidad(idUnidad, anio);
                
                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                string estadoPoa = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString();
                lblEstadoPoa.Text = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString() + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString();

                int idPoa = int.Parse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString());
                lblIdPoa.Text = idPoa.ToString();

                //1	Sin Enviar a Revision
                if (estadoPoa.Equals("1"))
                {
                    lblErrorPoa.Text = lblError.Text = string.Empty;
                    
                    //btnGuardar.Visible = /*btnEliminarAccion.Visible = gridRenglon.Columns[0].Visible =*/ gridRenglon.Columns[1].Visible = true;
                    btnGuardar.Visible = btnEliminarAccion.Visible = gridRenglon.Columns[0].Visible = gridRenglon.Columns[1].Visible = btnAgregarDetalle.Visible = true;
                }
                //2	Revisión Subgerencia, 4	Revisión Analista POA, 7	Revisión Dirección
                else if (estadoPoa.Equals("2") || estadoPoa.Equals("4") || estadoPoa.Equals("7"))
                {
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + lblEstadoPoa.Text + " y no se puede modificar";

                    btnGuardar.Visible = btnEliminarAccion.Visible = gridRenglon.Columns[0].Visible = gridRenglon.Columns[1].Visible = btnAgregarDetalle.Visible = false;
                }
                //3	Rechazado Subgerencia, 6	Rechazado Analista POA, 8	Rechazado Dirección, 
                else if (estadoPoa.Equals("3") || estadoPoa.Equals("6") || estadoPoa.Equals("8"))
                {
                    string motivoRechazo = dsPoa.Tables[0].Rows[0]["OBSERVACIONES"].ToString();
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + lblEstadoPoa.Text + ", por: " + motivoRechazo;

                    //btnGuardar.Visible = /*btnEliminarAccion.Visible = gridRenglon.Columns[0].Visible =*/ gridRenglon.Columns[1].Visible = true;
                    btnGuardar.Visible = btnEliminarAccion.Visible = gridRenglon.Columns[0].Visible = gridRenglon.Columns[1].Visible = btnAgregarDetalle.Visible = true;
                }
                //9	Aprobado Dirección
                else if (estadoPoa.Equals("9"))
                {
                    lblErrorPoa.Text = lblError.Text = string.Empty;

                    btnGuardar.Visible = btnEliminarAccion.Visible = gridRenglon.Columns[0].Visible = gridRenglon.Columns[1].Visible = btnAgregarDetalle.Visible = false;
                }
                else
                {
                    lblErrorPoa.Text = lblError.Text = "Estado desconocido: " + estadoPoa + ", por favor consulte con el administrador del sistema";

                    btnGuardar.Visible = btnEliminarAccion.Visible = gridRenglon.Columns[0].Visible = gridRenglon.Columns[1].Visible = btnAgregarDetalle.Visible = false;
                }

                /*if (!estadoPoa.Equals("1") && !estadoPoa.Equals("3") && !estadoPoa.Equals("6") && !estadoPoa.Equals("8"))
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + lblEstadoPoa.Text + " y no se puede modificar";
                else
                    btnGuardar.Visible = btnEliminarAccion.Visible = /*gridRenglon.Columns[0].Visible = gridRenglon.Columns[1].Visible = true;
                */
                //btnGuardar.Visible = btnEliminarAccion.Visible = gridRenglon.Columns[0].Visible = gridRenglon.Columns[1].Visible = true;

                //if (!ddlDependencias.SelectedValue.Equals("0"))
                int idDep = 0;
                int.TryParse(ddlDependencias.Items[0].Value, out idDep);
                obtenerPresupuesto(idPoa, idDep);

                lblEncabezado.Text = string.Empty;
                if (!ddlAnios.SelectedValue.Equals("0") && !ddlUnidades.SelectedValue.Equals("0"))
                    lblEncabezado.Text = "Plan Estratégico " + ddlPlanes.SelectedItem.Text + " " + ddlUnidades.SelectedItem.Text.Split('-')[1] + " (KPI 3er. Nivel)";

                poaValido = true;
            }
            catch (Exception ex)
            {
                lblError.Text = lblErrorPoa.Text = "Error: " + ex.Message;
            }
            return poaValido;
        }

        protected void obtenerPresupuesto(int idPoa, int idDependencia)
        {
            try
            {
                planAccionLN = new PlanAccionLN();
                DataSet dsPpto = planAccionLN.PptoPoa(idPoa, idDependencia);

                decimal pptoPoaUnidad = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["PPTO_POA_UNIDAD"].ToString());
                decimal pptoDisponibleUnidad = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE_UNIDAD"].ToString());
                decimal pptoPoaDependencia = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["PPTO_POA_DEPENDENCIA"].ToString());
                decimal pptoDisponibleDep = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE_DEPENDENCIA"].ToString());


                lblTechoU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoPoaUnidad);
                lblDisponibleU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoDisponibleUnidad);
                lblTechoD.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoPoaDependencia);
                lblDisponibleD.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoDisponibleDep);
            }
            catch (Exception ex)
            {
                throw new Exception("obtenerPresupuesto(). " + ex.Message);
            }
        }

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPoa = 0;

                if (!int.TryParse(lblIdPoa.Text, out idPoa))
                    throw new Exception("No existe POA seleccionado");

                obtenerPresupuesto(idPoa, int.Parse(ddlDependencias.SelectedValue));

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlDependencias_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlIndicadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                if (chkAccion.Checked == false)
                {
                    limpiarCNuevaAccion();
                    limpiarCNuevaMeta();
                }

                int vValue = int.Parse(ddlIndicadores.SelectedValue);

                planOperativoLN = new PlanOperativoLN();
                planOperativoLN.DdlMetas(ddlMetasO, vValue);
                ddlMetasO.Items[0].Text = "<< Elija un valor >>";

                if (ddlMetasO.Items.Count == 2)
                {
                    ddlMetasO.SelectedIndex = 1;
                    ddlMetasO_SelectedIndexChanged(sender, e);
                    ddlMetasO.Enabled = false;
                }
                else
                {
                    ddlMetasO.Enabled = true;
                    filtrarGridPlanO(string.Empty);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlIndicadores_SelectedIndexChanged. " + ex.Message;
            }
        }

        protected void gridPlanO_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridPlanO.PageIndex = e.NewPageIndex;
                filtrarGridPlanO(string.Empty);
            }
            catch (Exception ex)
            {
                lblErrorBusqueda.Text = "gridPlanO_PageIndexChanging(). " + ex.Message;
            }
        }

        protected void gridPlanO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int selectedIndex = gridPlanO.SelectedIndex;
                int idMeta = int.Parse(gridPlanO.DataKeys[selectedIndex].Value.ToString());

                planOperativoLN = new PlanOperativoLN();

                DataSet dsDatos = planOperativoLN.BuscarId(idMeta.ToString());
                
                int idKpi = int.Parse(dsDatos.Tables["BUSQUEDA"].Rows[0]["ID_KPI_O"].ToString());
                ListItem item = ddlIndicadores.Items.FindByValue(idKpi.ToString());
                if (item != null)
                {
                    ddlIndicadores.SelectedValue = idKpi.ToString();
                    ddlIndicadores_SelectedIndexChanged(sender, e);

                    int idMetaOperativa = int.Parse(dsDatos.Tables["BUSQUEDA"].Rows[0]["ID_MO"].ToString());
                    item = ddlMetasO.Items.FindByValue(idMetaOperativa.ToString());

                    if (item != null)
                    {
                        ddlMetasO.SelectedValue = idMetaOperativa.ToString();
                        ddlMetasO_SelectedIndexChanged(sender, e);
                    }
                }

                if (chkAccion.Checked == false)
                {
                    planAccionLN = new PlanAccionLN();
                    planAccionLN.DdlAcciones(ddlAcciones, idMeta);
                }                
                //filtrarGridPlanO(idMeta.ToString());
                
            }
            catch (Exception ex)
            {
                lblError.Text = "gridPlanO_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlMetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                txtMeta.Text = txtMeta1.Text = txtMeta2.Text = txtMeta3.Text = string.Empty;

                //txtPonderacion.Text = txtPpto.Text = txtResponsable.Text = string.Empty;
                txtPonderacion.Text = txtResponsable.Text = string.Empty;
                txtM1.Text = txtM2.Text = txtM3.Text = txtM4.Text = string.Empty;
                txtM5.Text = txtM6.Text = txtM7.Text = txtM8.Text = string.Empty;
                txtM9.Text = txtM10.Text = txtM11.Text = txtM12.Text = string.Empty;

                rfvMeta.Enabled = rfvMetaC1.Enabled = rfvMetaC2.Enabled = rfvMetaC3.Enabled = false;
                rfvPonderacion.Enabled = /*rfvPresupuesto.Enabled = */rfvResponsable.Enabled = false;
                //txtMeta.Focus();

                int vValue = int.Parse(ddlMetas.SelectedValue);
                if (vValue > 0)
                {
                    planAccionLN = new PlanAccionLN();
                    DataSet dsResultado = planAccionLN.InformacionMeta(vValue);

                    txtMeta.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_GENERAL"].ToString();
                    txtMeta1.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_1"].ToString();
                    txtMeta2.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_2"].ToString();
                    txtMeta3.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_3"].ToString();
                    txtPonderacion1.Text = int.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PONDERACION1"].ToString().Split('.')[0]).ToString();
                    txtPonderacion2.Text = int.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PONDERACION2"].ToString().Split('.')[0]).ToString();
                    txtPonderacion3.Text = int.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PONDERACION3"].ToString().Split('.')[0]).ToString();
                    txtPonderacion.Text = int.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PONDERACION_ACCION"].ToString().Split('.')[0]).ToString();
                    //txtPpto.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PRESUPUESTO"].ToString();
                    txtResponsable.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["RESPONSABLE"].ToString();
                    
                    string v = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENE"].ToString();
                    txtM1.Text = v.Equals("0") ? string.Empty : "X";

                    v = dsResultado.Tables["BUSQUEDA"].Rows[0]["FEB"].ToString();
                    txtM2.Text = v.Equals("0") ? string.Empty : "X";

                    v = dsResultado.Tables["BUSQUEDA"].Rows[0]["MAR"].ToString();
                    txtM3.Text = v.Equals("0") ? string.Empty : "X";

                    v = dsResultado.Tables["BUSQUEDA"].Rows[0]["ABR"].ToString();
                    txtM4.Text = v.Equals("0") ? string.Empty : "X";

                    v = dsResultado.Tables["BUSQUEDA"].Rows[0]["MAY"].ToString();
                    txtM5.Text = v.Equals("0") ? string.Empty : "X";

                    v = dsResultado.Tables["BUSQUEDA"].Rows[0]["JUN"].ToString();
                    txtM6.Text = v.Equals("0") ? string.Empty : "X";

                    v = dsResultado.Tables["BUSQUEDA"].Rows[0]["JUL"].ToString();
                    txtM7.Text = v.Equals("0") ? string.Empty : "X";

                    v = dsResultado.Tables["BUSQUEDA"].Rows[0]["AGO"].ToString();
                    txtM8.Text = v.Equals("0") ? string.Empty : "X";

                    v = dsResultado.Tables["BUSQUEDA"].Rows[0]["SEP"].ToString();
                    txtM9.Text = v.Equals("0") ? string.Empty : "X";

                    v = dsResultado.Tables["BUSQUEDA"].Rows[0]["OCT"].ToString();
                    txtM10.Text = v.Equals("0") ? string.Empty : "X";

                    v = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOV"].ToString();
                    txtM11.Text = v.Equals("0") ? string.Empty : "X";

                    v = dsResultado.Tables["BUSQUEDA"].Rows[0]["DIC"].ToString();
                    txtM12.Text = v.Equals("0") ? string.Empty : "X";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlMetas_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void btnEliminarAccion_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            try
            {
                int id = int.Parse(ddlAcciones.SelectedValue);

                if (id > 0)
                    if (eliminarAccion(id))
                    {
                        ddlUnidades_SelectedIndexChanged(sender, e);
                        //limpiarCNuevaAccion();
                        //limpiarCNuevaMeta();
                        //planAccionLN = new PlanAccionLN();
                        //planAccionLN.DdlAcciones(ddlAcciones, int.Parse(gridPlanO.SelectedValue.ToString()));
                        //obtenerPresupuesto(int.Parse(lblIdPoa.Text), int.Parse(ddlDependencias.SelectedValue));
                        string mensaje = "Acción ELIMINADA correctamente. \n";
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                        lblSuccess.Text = mensaje;
                        lblError.Text = string.Empty;
                    }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnEliminarMeta_Click(). " + ex.Message;
                lblSuccess.Text = string.Empty;
            }
        }

        protected bool eliminarAccion(int id)
        {
            try
            {
                planAccionLN = new PlanAccionLN();
                DataSet dsResultado = planAccionLN.EliminarAccion(id);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnNuevaB_Click(object sender, EventArgs e)
        {
            string _open = "window.open('VerPlan.aspx', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void chkCronograma_CheckedChanged(object sender, EventArgs e)
        {
            if(chkCronograma.Checked)
                txtM1.Text = txtM2.Text = txtM3.Text = txtM4.Text = txtM5.Text = txtM6.Text = txtM7.Text = txtM8.Text = txtM9.Text = txtM10.Text = txtM11.Text = txtM12.Text = "X";
            else
                txtM1.Text = txtM2.Text = txtM3.Text = txtM4.Text = txtM5.Text = txtM6.Text = txtM7.Text = txtM8.Text = txtM9.Text = txtM10.Text = txtM11.Text = txtM12.Text = string.Empty;
        }

        protected void ddlMetasO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                if (chkAccion.Checked == false)
                {
                    limpiarCNuevaAccion();
                    limpiarCNuevaMeta();
                }

                filtrarGridPlanO(string.Empty);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlMetasO_SelectedIndexChanged. " + ex.Message;
            }
        }

        protected void gridRenglon_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           /* decimal sumaP, sumaC, sumaS = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                sumaP = decimal.Parse(e.Row.Cells[6].Text);
                e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumaP);
                totalP += sumaP;
                sumaP = 0;

                sumaC = decimal.Parse(e.Row.Cells[7].Text);
                e.Row.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumaC);
                totalC += sumaC;
                sumaC = 0;

                sumaS = decimal.Parse(e.Row.Cells[8].Text);
                e.Row.Cells[8].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumaS);
                totalS += sumaS;
                sumaS = 0;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = "Total";
                e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalP);
                e.Row.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalC);
                e.Row.Cells[8].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalS);
            }*/
        }

        protected void gridRenglon_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idDetalle = Convert.ToInt32(e.Keys["ID"].ToString());

                planAccionLN = new PlanAccionLN();
                DataSet dsResultado = planAccionLN.EliminarDetalleAccion(idDetalle);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se ELIMINÓ el Renglón: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                limpiarNListado();

                int idPoa = int.Parse(lblIdPoa.Text);
                int idDep = int.Parse(ddlDependencias.SelectedValue);
                obtenerPresupuesto(idPoa, idDep);

                lblSuccess.Text = "Renglón ELIMINADO correctamente";
                lblError.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblError.Text = "gridRenglon(). " + ex.Message;
            } 
        }

        protected void gridRenglon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                upModRenglon.Visible = true;
                upModificar.Visible = false;

                lblErrorModMonto.Text = string.Empty;

                int idDetalle = 0;
                int.TryParse(gridRenglon.SelectedValue.ToString(), out idDetalle);

                planAccionLN = new PlanAccionLN();
                DataSet dsResultado = planAccionLN.InformacionAccionRenglon(idDetalle);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se CONSULTÓ el Renglón: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                lblIdPoaModMonto.Text = lblIdPoa.Text;
                lblIdDependenciaModMonto.Text = ddlDependencias.SelectedValue;
                lblIdDetalleAccionModMonto.Text = idDetalle.ToString();
                
                /*
                planAccionLN.DdlAccionesPoa(ddlAccionModRenglon, int.Parse(lblIdPoa.Text));
                item = ddlAccionModRenglon.Items.FindByValue(dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_RENGLON"].ToString());

                if (item == null)
                    throw new Exception("Error al localizar la acción!");
                */

                ddlAccionModMonto.ClearSelection();
                ddlAccionModMonto.Items.Clear();
                ddlAccionModMonto.Items.Add(ddlAcciones.SelectedItem);


                ListItem item;
                planAccionLN.DdlRenglones(ddlRenglonModMonto);
                item = ddlRenglonModMonto.Items.FindByValue(dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_RENGLON"].ToString());

                if (item == null)
                    throw new Exception("Error al localizar el renglón!");

                ddlRenglonModMonto.ClearSelection();
                ddlRenglonModMonto.Items.Clear();
                ddlRenglonModMonto.Items.Add(item);


                planAccionLN.DdlFinanciamiento(dropFuenteFModMonto);
                string idFinanciamiento = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_TIPO_FINANCIAMIENTO"].ToString();
                
                item = dropFuenteFModMonto.Items.FindByValue(idFinanciamiento);
                if (item != null)
                    dropFuenteFModMonto.SelectedValue = idFinanciamiento;

                decimal montoActual = 0;
                decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["MONTO"].ToString(), out montoActual);

                txtMontoActual.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", montoActual);
                txtMontoOperar.Text = txtNuevoMonto.Text = string.Empty;

            }
            catch (Exception ex)
            {
                lblErrorModMonto.Text = "gridRenglon(). " + ex.Message;
            } 
        }

        protected void chkAccion_CheckedChanged(object sender, EventArgs e)
        {
            limpiarControlesError();

            //ddlAcciones.SelectedValue = "0";
            //ddlAcciones_SelectedIndexChanged(sender, e);

            planAccionLN = new PlanAccionLN();
            if (chkAccion.Checked)
            {
                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                planAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
            }
            else
            {
                planAccionLN.DdlAcciones(ddlAcciones, 0);
            }
        }

        protected void ddlRenglones_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void ddlFuentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        /*protected void btnModalModificarR_Click(object sender, EventArgs e)
        {
            try
            {
                int idDetalleAccion = 0;
                int.TryParse(gridRenglon.SelectedValue.ToString(), out idDetalleAccion);

                if(idDetalleAccion == 0)
                    throw new Exception("Seleccione un renglón presupuestario");

                if (dropFuenteFMod.SelectedValue.Equals("0"))
                    throw new Exception("Seleccione una fuente de financiamiento");

                decimal nuevoMonto = 0;
                if (!decimal.TryParse(txtMontoMod.Text, out nuevoMonto))
                    throw new Exception("Ingrese un monto válido");

                planAccionLN = new PlanAccionLN();
                accionDetEN = new AccionesDetEN();

                string mensaje = "";
                DataSet dsResultado = new DataSet();
                
                int idAccion = 0;
                int idPoa = 0;
                int idDep = 0;
                int idDetAccion = 0;

                int.TryParse(ddlAcciones.SelectedValue, out idAccion);
                int.TryParse(lblIdPoa.Text, out idPoa);
                int.TryParse(ddlDependencias.SelectedValue, out idDep);
                int.TryParse(gridRenglon.SelectedValue.ToString(), out idDetAccion);

                obtenerPresupuesto(idPoa, idDep);
                DataSet dsPptoPoa = planAccionLN.PptoPoa(idPoa, idDep);

                decimal pptoPoaUnidad = decimal.Parse(dsPptoPoa.Tables["BUSQUEDA"].Rows[0]["PPTO_POA_UNIDAD"].ToString());
                decimal pptoDisponibleUnidad = decimal.Parse(dsPptoPoa.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE_UNIDAD"].ToString());
                decimal pptoPoaDependencia = decimal.Parse(dsPptoPoa.Tables["BUSQUEDA"].Rows[0]["PPTO_POA_DEPENDENCIA"].ToString());
                decimal pptoDisponibleDep = decimal.Parse(dsPptoPoa.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE_DEPENDENCIA"].ToString());

                DataSet dsPptoRenglon = planAccionLN.PptoRenglonAccion(idDetalleAccion);

                decimal codificadoDetalleAccion = 0;
                decimal.TryParse(dsPptoRenglon.Tables["BUSQUEDA"].Rows[0]["CODIFICADO"].ToString(), out codificadoDetalleAccion);
                decimal diferenciaNuevoMontoCodAccion = nuevoMonto - codificadoDetalleAccion;

                if (diferenciaNuevoMontoCodAccion < 0)
                    throw new Exception("El monto mínimo debe ser igual o mayor al monto codificado/comprometido: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", codificadoDetalleAccion));

                decimal montoActual = 0;
                decimal.TryParse(dsPptoRenglon.Tables["BUSQUEDA"].Rows[0]["COSTO_POA"].ToString(), out montoActual);
                decimal diferenciaNuevoMontoPptoDispoDep = (pptoDisponibleDep + montoActual) - nuevoMonto;

                if(diferenciaNuevoMontoPptoDispoDep < 0)
                    throw new Exception("El monto máximo debe ser igual o menor al monto disponible: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (pptoDisponibleDep + montoActual)));

                accionDetEN.Id_Detalle = idDetAccion;
                accionDetEN.Id_Accion = idAccion;
                //accionDetEN.No_Renglon = ddlRenglones.SelectedValue;
                accionDetEN.Id_Tipo_Financiamiento = int.Parse(dropFuenteFMod.SelectedValue);
                accionDetEN.Monto = nuevoMonto;
                accionDetEN.Usuario = Session["usuario"].ToString();

                planAccionLN = new PlanAccionLN();
                dsResultado = planAccionLN.AlmacenarDetalle(accionDetEN);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se ACTUALIZÓ el detalle: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                mensaje += "Detalle ACTUALIZADO exitosamente!. ";

                limpiarNListado();

                DataSet dsAccion = planAccionLN.InformacionAccion(idAccion);

                decimal pptoAccion = 0;
                decimal.TryParse(dsAccion.Tables["BUSQUEDA"].Rows[0]["MONTO_ACCION"].ToString(), out pptoAccion);
                lblPpto.Text = /*txtPpto.Text =*/ /*String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoAccion);

                mensaje += "Operación exitosa! ;-). " + mensaje;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                lblErrorModRenglon.Text = string.Empty;

                obtenerPresupuesto(idPoa, idDep);
            }
            catch (Exception ex)
            {
                string mensaje = "Error al operar el registro. " + ex.Message;
                lblErrorModRenglon.Text = mensaje;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
            }
        }*/


        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            //btnGuardar_Click(sender, e);

            try
            {

                if(ddlAcciones.Items.Count == 0)
                    throw new Exception("Seleccione una acción");

                int idAccion = 0;
                int.TryParse(ddlAcciones.SelectedItem.Value, out idAccion);

                if(idAccion <= 0)
                    throw new Exception("Seleccione una acción");

                upBuscar.Visible = true;
                upModificar.Visible = false;
                nuevaBusqueda();
            }
            catch (Exception ex)
            {
                lblError.Text = lblErrorBusqueda.Text = "btnDetalles_Click(). " + ex.Message;
            }
        }

        protected void nuevaBusqueda()
        {
            try
            {
                ddlBAcciones.ClearSelection();
                ddlBAcciones.Items.Clear();
                ListItem item = ddlAcciones.SelectedItem;

                ddlBAcciones.Items.Add(item);
                ddlBAcciones.SelectedIndex = 0;

                rblBTipoDetalle.SelectedValue = "1";
                txtBValor.Text = string.Empty;
                txtBValor.Focus();
                lblErrorBusqueda.Text = string.Empty;
                gridBusqueda.DataSource = null;
                gridBusqueda.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("nuevaBusqueda(). " + ex.Message);
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                gridBusqueda.DataSource = null;
                gridBusqueda.DataBind();

                int tipoBusqueda = 0;
                int.TryParse(rblBTipoDetalle.SelectedValue, out tipoBusqueda);
                string vValor = txtBValor.Text;
                vValor = vValor.Replace("'", "");
                vValor = vValor.Trim();

                if (txtBValor.Text.Length > 1)
                {
                    //INSUMOS
                    if (tipoBusqueda == 1)
                    {
                        gridBusqueda.Columns[0].Visible = true;
                        gridBusqueda.Columns[1].Visible = false;
                        gridBusqueda.Columns[2].Visible = true;
                        gridBusqueda.Columns[3].Visible = true;
                        gridBusqueda.Columns[4].Visible = true;
                        gridBusqueda.Columns[5].Visible = true;
                        gridBusqueda.Columns[6].Visible = true;
                        gridBusqueda.Columns[7].Visible = true;
                        gridBusqueda.Columns[8].Visible = true;
                        gridBusqueda.Columns[9].Visible = true;
                    }

                    //RENGLONES
                    if (tipoBusqueda == 2)
                    {
                        gridBusqueda.Columns[0].Visible = true;
                        gridBusqueda.Columns[1].Visible = false;
                        gridBusqueda.Columns[2].Visible = true;
                        gridBusqueda.Columns[3].Visible = true;
                        gridBusqueda.Columns[4].Visible = false;
                        gridBusqueda.Columns[5].Visible = false;
                        gridBusqueda.Columns[6].Visible = false;
                        gridBusqueda.Columns[7].Visible = false;
                        gridBusqueda.Columns[8].Visible = false;
                        gridBusqueda.Columns[9].Visible = false;
                    }

                    filtrarGridBusqueda(tipoBusqueda, vValor);
                }
            }
            catch (Exception ex)
            {
                lblErrorBusqueda.Text = "btnBuscar_Click(). " + ex.Message;
            }
        }

        protected void filtrarGridBusqueda(int tipoBusqueda, string criterio)
        {
            try
            {

                gridBusqueda.SelectedIndex = -1;
                gridBusqueda.DataSource = null;
                gridBusqueda.DataBind();

                planAccionLN = new PlanAccionLN();
                //planAccionLN.GridInsumosRenglon(gridBusqueda, tipoBusqueda, criterio);             
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridBusquedas(). " + ex.Message);
            }
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            limpiarNListado();
            obtenerPresupuesto(int.Parse(lblIdPoaModMonto.Text), int.Parse(lblIdDependenciaModMonto.Text));
            upModRenglon.Visible = false;
            upModificar.Visible = true;
        }

        protected void rblTipoDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = rblBTipoDetalle.SelectedValue;
            nuevaBusqueda();

            rblBTipoDetalle.SelectedValue = valor;
        }

        protected void gridBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                lblErrorBusqueda.Text = string.Empty;

                planAccionLN = new PlanAccionLN();

                upBuscar.Visible = false;
                upModificar.Visible = true;

                int tipoDetalle = 0;
                int.TryParse(rblBTipoDetalle.SelectedValue, out tipoDetalle);

                string vId = gridBusqueda.SelectedValue.ToString();
                GridViewRow gvrInsumo = gridBusqueda.SelectedRow;

                //INSUMO
                if (tipoDetalle == 1)
                {
                    planAccionLN.DdlInsumos(ddlInsumos, int.Parse(vId));

                    string noRenglon = gvrInsumo.Cells[2].Text;
                    planAccionLN.DdlRenglones(ddlRenglones);

                    ListItem item = ddlRenglones.Items.FindByValue(noRenglon);
                    
                    ddlRenglones.ClearSelection();
                    ddlRenglones.Items.Clear();
                    ddlRenglones.Items.Add(item);
                    ddlRenglones.SelectedIndex = 0;
                }

                //RENGLON
                if (tipoDetalle == 2)
                {
                    string descripcionInsumo = "N/A";
                    ListItem item = new ListItem(descripcionInsumo, "null");

                    ddlInsumos.ClearSelection();
                    ddlInsumos.Items.Clear();
                    ddlInsumos.Items.Add(item);
                    ddlInsumos.SelectedIndex = 0;

                    string noRenglon = gvrInsumo.Cells[2].Text;

                    planAccionLN.DdlRenglones(ddlRenglones);
                    ddlRenglones.SelectedValue = noRenglon;
                }

                ddlFuentes.ClearSelection();
                ddlFuentes.Focus();
                txtMonto.Text = "0";
            }
            catch (Exception ex)
            {
                lblError.Text = lblErrorBusqueda.Text = ex.Message;
            }

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

                    planEstrategicoLN = new PlanEstrategicoLN();

                    planEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlPlanes(). " + ex.Message;
            }
        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                if (validarControlesABCDetalle())
                {
                    int idPoa, idDependencia, idAccion;
                    decimal montoRenglon = 0;

                    int.TryParse(lblIdPoa.Text, out idPoa);
                    int.TryParse(ddlDependencias.SelectedValue, out idDependencia);
                    int.TryParse(ddlAcciones.SelectedValue, out idAccion);
                    
                    decimal.TryParse(txtMonto.Text, out montoRenglon);

                    DataSet dsAlmacenarDetalle = guardarDetalleAccion(idPoa, idDependencia, 0, idAccion, ddlRenglones.SelectedValue, int.Parse(ddlFuentes.SelectedValue), montoRenglon, ddlInsumos.SelectedValue, Session["usuario"].ToString());


                    

                    if (bool.Parse(dsAlmacenarDetalle.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ el registro: " + dsAlmacenarDetalle.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                    limpiarNListado();

                    txtMonto.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", montoRenglon);
                    obtenerPresupuesto(idPoa, idDependencia);
                    string mensaje = "Detalle INSERTADO/ACTUALIZADO exitosamente!. Para ingresar una nueva acción haga clic en Nuevo. ";
                    mensaje = "Operación exitosa! ;-). " + mensaje;
                }
            }
            catch (Exception ex)
            {
                string mensaje = "Error al operar el detalle. " + ex.Message;
                lblError.Text = mensaje;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
            }

        }

        protected string stringToDecimalString(string s)
        {
            s = s.Replace("Q. ", "");
            s = s.Replace("Q.", "");
            s = s.Replace("Q", "");
            s = s.Replace(" ", "");
            s = s.Replace(",", "");

            if (s.Equals(""))
                return "00.00";
            
            return s;
        }

        protected void btnGuardarMod(object sender, EventArgs e)
        {
            try
            {

                limpiarControlesError();
                int idPoa, idDependencia, idAccion, idDetalle;

                int.TryParse(lblIdPoaModMonto.Text, out idPoa);
                int.TryParse(lblIdDependenciaModMonto.Text, out idDependencia);
                int.TryParse(ddlAccionModMonto.SelectedValue, out idAccion);
                int.TryParse(lblIdDetalleAccionModMonto.Text, out idDetalle);

                txtMontoOperar.Text = stringToDecimalString(txtMontoOperar.Text);

                decimal montoActual, montoMod, nuevoMonto = 0;
                decimal.TryParse(txtMontoActual.Text, out montoActual);

                try
                {
                    
                    decimal.TryParse(txtMontoOperar.Text, out montoMod);
                }
                catch (Exception)
                {
                    throw new Exception("Monto no válido"); ;
                }

                //nuevoMonto = montoActual + montoMod;
                nuevoMonto = montoMod;
                //txtNuevoMonto.Text = nuevoMonto.ToString();

                txtMontoOperar.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", montoMod);

                if (nuevoMonto < 1)
                    throw new Exception("El nuevo monto debe ser mayor a 0!");

                DataSet dsAlmacenarDetalle = guardarDetalleAccion(idPoa, idDependencia, idDetalle, idAccion, ddlRenglonModMonto.SelectedValue, int.Parse(dropFuenteFModMonto.SelectedValue), nuevoMonto, "null", Session["usuario"].ToString());

                if (bool.Parse(dsAlmacenarDetalle.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se INSERTÓ/ACTUALIZÓ el registro: " + dsAlmacenarDetalle.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                lblSuccessMonto.Text = "Monto actualizado con éxito!";
            }
            catch (Exception ex)
            {
                lblErrorModMonto.Text = "btnGuardarMod(). " + ex.Message;
            }
        }

        protected void btnTransferencias_Click(object sender, EventArgs e)
        {

        }

    }
}
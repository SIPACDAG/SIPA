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


namespace AplicacionSIPA1.Operativa.Modificaciones
{
    public partial class GESFOR2 : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;

        private ObjOperativosEN OOperativosEN;
        private IndOperativosEN IOperativosEN;
        private MetasOperativasEN MOperativasEN;

        private AccionesEN accionesEN;
        private MetasAccionEN metasEN;

        private MetasAccionEN accionTransferencia;
        private GESFOR2EN gesforEN;
        public DataSet dsAccionP
        {
            get
            {
                object o = ViewState["dsAccionP"];
                return (DataSet)o;
            }
            set { ViewState["dsAccionP"] = value; }
        }

        public DataSet dsAccionA
        {
            get
            {
                object o = ViewState["dsAccionA"];
                return (DataSet)o;
            }
            set { ViewState["dsAccionA"] = value; }
        }
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    //btnNuevo_Click(sender, e);
                    LimpiarEncabezadoSolicitud(sender, e);
                    NuevaModificacion(sender, e);
                }
                catch (Exception ex)
                {
                    //lblErrorBusqueda.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void LimpiarEncabezadoSolicitud(object sender, EventArgs e)
        {
            limpiarControlesError();
            lblAnioSol.Text = lblAnio.Text = lblAnio1.Text = lblAnio2.Text = lblAnio3.Text = DateTime.Now.Year.ToString();
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlDependencias(ddlDependencias, Session["usuario"].ToString());

            if (ddlDependencias.Items.Count == 1)
            {
                ddlDependencias.SelectedIndex = 0;
                ddlDependencias_SelectedIndexChanged(sender, e);
            }

            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");//DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            lblEstado.Text = "1 - Sin Enviar a Revisión";
        }

        protected void NuevaModificacion(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                upNuevo.Visible = true;
                upConfirmar.Visible = false;

                lblIdSol.Text = string.Empty;
                lblNo.Text = string.Empty;
                
                rblCambio.SelectedValue = "1";

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones_x_Dependencia(ddlAcciones, 0, 0);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";
                
                lblEje.Text = lblIE.Text = lblOE.Text = lblME.Text = string.Empty;
                hfIdEE.Value = hfIdOE.Value = hfIdME.Value = hfIdOO.Value = hfIdIO.Value = hfIdMO.Value = hfIdMA.Value = hfIdAC.Value = "0";
                
                chk1.Checked = false;
                chkMostrarDet.Checked = false;

                chk1_CheckedChanged(sender, e);
                chkMostrarDet_CheckedChanged(sender, e);
                
                txtObjetivo.Text = txtObjetivo0.Text = txtIndicador.Text = txtIndicador0.Text = txtMetaO.Text = txtMetaO0.Text = string.Empty;
                txtAccion.Text = txtAccion0.Text = txtMeta.Text = txtMetaM.Text = txtMeta1.Text = txtMetaM1.Text = txtMeta2.Text = txtMetaM2.Text = txtMeta3.Text = txtMetaM3.Text = string.Empty;

                txtObjetivo.Visible = txtIndicador.Visible = txtMetaO.Visible = true;
                txtAccion.Visible = txtMeta.Visible = txtMeta1.Visible = txtMeta2.Visible = txtMeta3.Visible = true;

                rfvAccion.Enabled = rfvIndicador.Enabled = rfvMeta.Enabled = rfvMetaC1.Enabled = rfvMetaC2.Enabled = rfvMetaC3.Enabled = rfvMetaO.Enabled = rfvObjetivo.Enabled = rfvPond1.Enabled = rfvPond2.Enabled = rfvPond3.Enabled = rfvPonderacion.Enabled = rfvPresupuesto.Enabled = rfvPresupuesto2.Enabled = rfvResponsable.Enabled = rfvJustificacion.Enabled = false;

                lblPorcentaje.Text = lblPond1.Text = lblPond2.Text = lblPond3.Text = "";
                lblResponsable.Text = txtPonderacion.Text = txtPond1.Text = txtPond2.Text = txtPond3.Text = string.Empty;
                txtPonderacion.Enabled = false;
                lblPpto1.Text = lblPptoM1.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
                txtPpto1.Text = "0";
                txtPpto1.Enabled = true;

                /*rvPresupuesto.MinimumValue = "0";
                rvPresupuesto.MaximumValue = "100000000";

                rvPresupuesto0.MinimumValue = "0";
                rvPresupuesto0.MaximumValue = "100000000";*/

                chkCronograma.Checked = false;
                chkCronograma_CheckedChanged(sender, e);
                lblM1.Text = lblM2.Text = lblM3.Text = lblM4.Text = lblM5.Text = lblM6.Text = lblM7.Text = lblM8.Text = lblM9.Text = lblM10.Text = lblM11.Text = lblM12.Text = "";

                rblModPpto.ClearSelection();
                rblModPpto.SelectedValue = "1";
                rblModPpto_SelectedIndexChanged(sender, e);
                rblModPpto.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }

        protected void NuevoIngreso(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                upNuevo.Visible = true;
                upConfirmar.Visible = false;

                lblIdSol.Text = string.Empty;
                lblNo.Text = string.Empty;

                rblCambio.SelectedValue = "2";

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones_x_Dependencia(ddlAcciones, 0, 0);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                lblEje.Text = lblIE.Text = lblOE.Text = lblME.Text = string.Empty;
                hfIdEE.Value = hfIdOE.Value = hfIdME.Value = hfIdOO.Value = hfIdIO.Value = hfIdMO.Value = hfIdMA.Value = hfIdAC.Value = "0";

                chk1.Checked = true;
                chkMostrarDet.Checked = true;

                chk1_CheckedChanged(sender, e);
                chkMostrarDet_CheckedChanged(sender, e);

                txtObjetivo.Text = txtObjetivo0.Text = txtIndicador.Text = txtIndicador0.Text = txtMetaO.Text = txtMetaO0.Text = string.Empty;
                txtAccion.Text = txtAccion0.Text = txtMeta.Text = txtMetaM.Text = txtMeta1.Text = txtMetaM1.Text = txtMeta2.Text = txtMetaM2.Text = txtMeta3.Text = txtMetaM3.Text = string.Empty;

                txtObjetivo.Visible = txtIndicador.Visible = txtMetaO.Visible = false;
                txtAccion.Visible = txtMeta.Visible = txtMeta1.Visible = txtMeta2.Visible = txtMeta3.Visible = false;

                rfvAccion.Enabled = rfvIndicador.Enabled = rfvMeta.Enabled = rfvMetaC1.Enabled = rfvMetaC2.Enabled = rfvMetaC3.Enabled = rfvMetaO.Enabled = rfvObjetivo.Enabled = rfvPond1.Enabled = rfvPond2.Enabled = rfvPond3.Enabled = rfvPonderacion.Enabled = rfvPresupuesto.Enabled = rfvPresupuesto2.Enabled = rfvResponsable.Enabled = rfvJustificacion.Enabled = false;

                lblPorcentaje.Text = lblPond1.Text = lblPond2.Text = lblPond3.Text = "";
                lblResponsable.Text = txtPonderacion.Text = txtPond1.Text = txtPond2.Text = txtPond3.Text = string.Empty;
                txtPonderacion.Enabled = false;
                //lblS1.Text = "(-)";
                lblPpto1.Text = lblPptoM1.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
                txtPpto1.Text = "0";
                txtPpto1.Enabled = true;

                chkCronograma.Checked = false;
                chkCronograma_CheckedChanged(sender, e);
                lblM1.Text = lblM2.Text = lblM3.Text = lblM4.Text = lblM5.Text = lblM6.Text = lblM7.Text = lblM8.Text = lblM9.Text = lblM10.Text = lblM11.Text = lblM12.Text = "";

                rblModPpto.ClearSelection();
                rblModPpto.SelectedValue = "1";
                rblModPpto_SelectedIndexChanged(sender, e);
                rblModPpto.Enabled = false;
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlBAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblErrorBusqueda.Text = string.Empty;
        }

        protected void rblCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
           // lblErrorBusqueda.Text = string.Empty;
            //txtBValor.Focus();
        }

        protected void txtBValor_TextChanged(object sender, EventArgs e)
        {
            //lblErrorBusqueda.Text = string.Empty;
        }
       

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarEncabezadoSolicitud(sender, e);
                NuevaModificacion(sender, e);
                ddlDependencias.Focus();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo_Click()" + ex.Message;
            }
        }

        protected void limpiarCNuevaAccion()
        {
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, 0);
            txtCodigo.Text = txtAccion.Text = string.Empty;
            txtCodigo.Enabled = false;
            rfvCodigo.Enabled = rfvAccion.Enabled = false; 
        }

        protected void limpiarCNuevaMeta()
        {
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlMetas(ddlMetas, 0);
            ddlMetas.Enabled = false;
            txtMeta.Text = txtMeta1.Text = txtMeta2.Text = txtMeta3.Text = string.Empty;
            txtPpto1.Text = "0";
            txtPonderacion.Text = txtResponsable.Text = string.Empty;
            txtM1.Text = txtM2.Text = txtM3.Text = txtM4.Text = string.Empty;
            txtM5.Text = txtM6.Text = txtM7.Text = txtM8.Text = string.Empty;
            txtM9.Text = txtM10.Text = txtM11.Text = txtM12.Text = string.Empty;

            rfvMeta.Enabled = rfvMetaC1.Enabled = rfvMetaC2.Enabled = rfvMetaC3.Enabled = false;
            rfvPonderacion.Enabled = rfvPresupuesto.Enabled = rfvResponsable.Enabled = false;
        }

        protected void gridBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            /*try
            {
                lblErrorBusqueda.Text = string.Empty;
                
                int idUnidad = int.Parse(ddlBUnidades.SelectedValue);
                int anio = int.Parse(ddlBAnio.SelectedValue);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.GridBusqueda(gridBusqueda, Session["Usuario"].ToString().ToLower(), idUnidad, anio);
                
                gridBusqueda.PageIndex = e.NewPageIndex;
            }
            catch (Exception ex)
            {
                lblErrorBusqueda.Text = "gridBusqueda_PageIndexChanging(). " + ex.Message; 
            }*/
        }

        protected void gridBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*limpiarControlesError();
            upBuscar.Visible = false;
            upModificar.Visible = true;

            string idBuscar = gridBusqueda.SelectedValue.ToString();
            transicion_Modificar_o_Eliminar(idBuscar);*/
        }




        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int vValue = int.Parse(ddlAcciones.SelectedValue);
                if (vValue > 0)
                {
                    pAccionLN = new PlanAccionLN();
                    DataSet dsResultado = pAccionLN.InformacionGESFOR2(vValue, 0, "", 1);

                    lblEje.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["COD_EE"].ToString() + " - " + dsResultado.Tables["BUSQUEDA"].Rows[0]["EJE"].ToString();
                    lblOE.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["COD_OE"].ToString() + " - " + dsResultado.Tables["BUSQUEDA"].Rows[0]["OBJETIVO_ESTRATEGICO"].ToString();
                    lblIE.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["INDICADOR_E"].ToString();
                    lblME.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_E"].ToString();

                    
                    hfIdEE.Value = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_EJE_ESTRATEGICO"].ToString();
                    hfIdOE.Value = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_OBJETIVO_ESTRATEGICO"].ToString();
                    hfIdME.Value = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_META"].ToString();
                    hfIdOO.Value = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_OBJETIVO_OPERATIVO"].ToString();
                    hfIdIO.Value = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_KPI_OPERATIVO"].ToString();
                    hfIdMO.Value = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString();
                    hfIdMA.Value = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_META_ACCION"].ToString();
                    hfIdAC.Value = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ACCION"].ToString();                    
                            
                    txtObjetivo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["OBJETIVO_OPERATIVO"].ToString();
                    txtIndicador.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["INDICADOR_O"].ToString();
                    txtMetaO.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_O"].ToString();
                    txtAccion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ACCION"].ToString();
                    txtMeta.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_GENERAL"].ToString();
                    txtMeta1.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_1"].ToString();
                    txtMeta2.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_2"].ToString();
                    txtMeta3.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_3"].ToString();
                    lblPond1.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PONDERACION1"].ToString();
                    lblPond2.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PONDERACION2"].ToString();
                    lblPond3.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PONDERACION3"].ToString();
                    lblPorcentaje.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PONDERACION"].ToString();
                    //txtPonderacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PONDERACION"].ToString();
                    lblResponsable.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["RESPONSABLE_ACCION"].ToString();
                    decimal vPpto = decimal.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["PRESUPUESTO"].ToString());
                    lblPpto1.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", vPpto);
                    txtPpto1.Text = "0";
                    lblPptoM1.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", vPpto);

                    rvPresupuesto.MaximumValue = vPpto.ToString();
                    rvPresupuesto0.MaximumValue = "100000000";

                    //rvPresupuesto.MaximumValue = vPpto.ToString();
                    //rvPresupuesto.ErrorMessage = "Entre 0 y " + vPpto.ToString();

                    string s = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENE"].ToString();
                    lblM1.Text = s.Equals("X") ? "*" : string.Empty;

                    s = dsResultado.Tables["BUSQUEDA"].Rows[0]["FEB"].ToString();
                    lblM2.Text = s.Equals("X") ? "*" : string.Empty;

                    s = dsResultado.Tables["BUSQUEDA"].Rows[0]["MAR"].ToString();
                    lblM3.Text = s.Equals("X") ? "*" : string.Empty;

                    s = dsResultado.Tables["BUSQUEDA"].Rows[0]["ABR"].ToString();
                    lblM4.Text = s.Equals("X") ? "*" : string.Empty;

                    s = dsResultado.Tables["BUSQUEDA"].Rows[0]["MAY"].ToString();
                    lblM5.Text = s.Equals("X") ? "*" : string.Empty;

                    s = dsResultado.Tables["BUSQUEDA"].Rows[0]["JUN"].ToString();
                    lblM6.Text = s.Equals("X") ? "*" : string.Empty;

                    s = dsResultado.Tables["BUSQUEDA"].Rows[0]["JUL"].ToString();
                    lblM7.Text = s.Equals("X") ? "*" : string.Empty;

                    s = dsResultado.Tables["BUSQUEDA"].Rows[0]["AGO"].ToString();
                    lblM8.Text = s.Equals("X") ? "*" : string.Empty;

                    s = dsResultado.Tables["BUSQUEDA"].Rows[0]["SEP"].ToString();
                    lblM9.Text = s.Equals("X") ? "*" : string.Empty;

                    s = dsResultado.Tables["BUSQUEDA"].Rows[0]["OCT"].ToString();
                    lblM10.Text = s.Equals("X") ? "*" : string.Empty;

                    s = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOV"].ToString();
                    lblM11.Text = s.Equals("X") ? "*" : string.Empty;

                    s = dsResultado.Tables["BUSQUEDA"].Rows[0]["DIC"].ToString();
                    lblM12.Text = s.Equals("X") ? "*" : string.Empty;

                    chk1.Checked = true;
                    chk1_CheckedChanged(sender, e);

                    rblModPpto.SelectedValue = "1";
                    rblModPpto_SelectedIndexChanged(sender, e);

                    dsAccionP = dsResultado.Copy();
                }
                else
                {
                    NuevaModificacion(sender, e);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlObjetivos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void filtrarGridPlanO(string id)
        {
            gridPlanO.DataSource = null;
            gridPlanO.DataBind();

            pOperativoLN = new PlanOperativoLN();
            pOperativoLN.GridBusqueda(gridPlanO, Session["usuario"].ToString());

            string filtro = string.Empty;

            object obj = gridPlanO.DataSource;
            System.Data.DataTable tbl = gridPlanO.DataSource as System.Data.DataTable;
            System.Data.DataView dv = tbl.DefaultView;

            filtro = " anio = " + ddlAnios.SelectedValue;

            if (!ddlObjetivos.SelectedValue.Equals("0"))
                filtro += " AND id_objetivo_operativo = " + ddlObjetivos.SelectedValue;

            if (!ddlIndicadores.SelectedValue.Equals("0"))
                filtro += " AND id_kpi_operativo = " + ddlIndicadores.SelectedValue;

            if (!id.Equals(string.Empty))
                filtro += " AND id = " + id;

            dv.RowFilter = filtro;

            gridPlanO.DataSource = dv;
            gridPlanO.DataBind();

            if (gridPlanO.Rows.Count == 1)
            {
                gridPlanO.SelectedIndex = 0;

                pOperativoLN = new PlanOperativoLN();
                DataSet ds = pOperativoLN.BuscarId(gridPlanO.SelectedValue.ToString());
                string idkpiO = ds.Tables["BUSQUEDA"].Rows[0]["ID_KPI_O"].ToString();

                ListItem item = ddlIndicadores.Items.FindByValue(idkpiO);
                if (item != null)
                    ddlIndicadores.SelectedValue = idkpiO;
                               
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, int.Parse(gridPlanO.SelectedValue.ToString()));
                txtAccion.Focus();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarControlesABC())
            {
                pOperativoLN = new PlanOperativoLN();
                pAccionLN = new PlanAccionLN();

                OOperativosEN = new ObjOperativosEN();
                IOperativosEN = new IndOperativosEN();
                MOperativasEN = new MetasOperativasEN();
                accionesEN = new AccionesEN();
                metasEN = new MetasAccionEN();
                gesforEN = new GESFOR2EN();

                accionTransferencia = new MetasAccionEN();
                DataSet dsResultado = new DataSet();

                DataSet dsGESFOR = gesforEN.armarDsGESFOR2();
                int idSolicitud = int.Parse(lblIdSol.Text == "" ? "0" : lblIdSol.Text);
                int noSolicitud = int.Parse(lblNo.Text == "" ? "0" : lblNo.Text);
                //1ER NIVEL
                int idEE = int.Parse(hfIdEE.Value);
                int idOE = int.Parse(hfIdOE.Value);
                int idME = int.Parse(hfIdME.Value);
                //2DO NIVEL
                int idOO = int.Parse(hfIdOO.Value);
                int idIO = int.Parse(hfIdIO.Value);
                int idMO = int.Parse(hfIdMO.Value);
                //3ER NIVEL
                int idAC = int.Parse(hfIdAC.Value);
                int idMA = int.Parse(hfIdMA.Value);

                int idPoa = int.Parse(lblIdPoa.Text);
                int anio = int.Parse(lblAnioSol.Text);
                int idDep = int.Parse(ddlDependencias.SelectedValue.Split('-')[0].Trim());
                int idUni = int.Parse(ddlDependencias.SelectedValue.Split('-')[1].Trim());

                int idAccionT = int.Parse(ddlAcciones2.SelectedValue);
                string usuario = Session["usuario"].ToString();
                
                DateTime dtFechaSol = DateTime.Parse(txtFecha.Text);
                string fechaSol = dtFechaSol.Year + "-" + dtFechaSol.Month + "-" + dtFechaSol.Day;
 
                //ENCABEZADO DEL FORMULARIO
                DataRow dr = dsGESFOR.Tables["ENC"].NewRow();
                dr["ID_SOLICITUD"] = idSolicitud;
                dr["ID_FORMULARIO"] = 1;
                dr["ID_POA"] = idPoa;
                dr["ANIO"] = anio;
                dr["ID_UNIDAD"] = idUni;
                dr["ID_DEPENDENCIA"] = idDep;
                dr["FECHA"] = fechaSol;
                dr["ID_ACCION"] = idAC;
                dr["ID_ESTADO"] = 1;
                dr["SOLICITUD_PRINCIPAL"] = DBNull.Value;
                dr["MONTO"] = "0";
                dr["JUSTIFICACION"] = txtJustificacion.Text;
                dr["USUARIO"] = usuario;
                
                if (rblCambio.SelectedValue.Equals("1"))
                {
                    try
                    {
                        if (validarPpto())
                        {
                            dr["TIPO_SOLICITUD"] = "MOD";
                            dr["TRANSFERENCIA"] = idAccionT == 0 ? 0 : 1;
                            dr["DEBITO"] = decimal.Parse(txtPpto1.Text);
                            dr["CREDITO"] = "0"; ;
                            dr["DESTINO_DEBITO"] = rblModPpto.SelectedValue.Equals("1") ? "INT" : "EXT";
                            dr["ORIGEN_CREDITO"] = "N/A";
                            dsGESFOR.Tables["ENC"].Rows.Add(dr);

                            if (idAccionT > 0)
                            {
                                dr = dsGESFOR.Tables["ENC"].NewRow();
                                dr["ID_SOLICITUD"] = "0";
                                dr["ID_FORMULARIO"] = 1;
                                dr["ANIO"] = anio;
                                dr["ID_UNIDAD"] = "";
                                dr["ID_DEPENDENCIA"] = "";
                                dr["FECHA"] = fechaSol;
                                dr["ID_ACCION"] = idAccionT;
                                dr["ID_ESTADO"] = 1;
                                dr["SOLICITUD_PRINCIPAL"] = idSolicitud;
                                dr["MONTO"] = "0";
                                dr["JUSTIFICACION"] = "";
                                dr["USUARIO"] = usuario;

                                dr["TIPO_SOLICITUD"] = "MOD";
                                dr["TRANSFERENCIA"] = 1;
                                dr["DEBITO"] = "0";
                                dr["CREDITO"] = decimal.Parse(txtPpto2.Text);
                                dr["DESTINO_DEBITO"] = "N/A";
                                dr["ORIGEN_CREDITO"] = rblModPpto.SelectedValue.Equals("1") ? "INT" : "EXT";
                                dsGESFOR.Tables["ENC"].Rows.Add(dr);
                            }

                            //dr = dsGESFOR.Tables["DET"].NewRow();
                            if (txtObjetivo0.Text != "")
                            {
                                OOperativosEN.Id_Objetivo_Operativo = idOO;
                                OOperativosEN.Id_Objetivo_Estrategico = idOE;
                                OOperativosEN.Id_Meta = idME;
                                OOperativosEN.Id_Unidad = idUni;
                                OOperativosEN.Nombre = txtObjetivo0.Text;
                                OOperativosEN.Anio = anio;
                                OOperativosEN.Usuario = usuario;

                                dsGESFOR.Tables["DET"].Rows.Add("1", "1", "SIPA_OBJETIVOS_OPERATIVOS", "ID_OBJETIVO_OPERATIVO", "INT", "1", idOO, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("2", "1", "SIPA_OBJETIVOS_OPERATIVOS", "ID_OBJETIVO_ESTRATEGICO", "INT", "1", idOE, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("3", "1", "SIPA_OBJETIVOS_OPERATIVOS", "ID_META_ESTRATEGICA", "INT", "1", idME, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("4", "1", "SIPA_OBJETIVOS_OPERATIVOS", "CODIGO", "INT", "1", "0", "N");
                                dsGESFOR.Tables["DET"].Rows.Add("5", "1", "SIPA_OBJETIVOS_OPERATIVOS", "NOMBRE", "VARCHAR", "1", txtObjetivo0.Text, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("6", "1", "SIPA_OBJETIVOS_OPERATIVOS", "ANIO", "INT", "1", anio, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("7", "1", "SIPA_OBJETIVOS_OPERATIVOS", "ID_UNIDAD", "INT", "1", idUni, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("8", "1", "SIPA_OBJETIVOS_OPERATIVOS", "USUARIO", "VARCHAR", "1", usuario, "N");
                            }

                            if (txtIndicador0.Text != "")
                            {
                                IOperativosEN.Id_Kpi_Operativo = idIO;
                                IOperativosEN.Id_Objetivo_Operativo = idOO;
                                IOperativosEN.Id_Meta_Estrategica = idME;
                                IOperativosEN.Nombre = txtIndicador0.Text;
                                IOperativosEN.Anio = anio;
                                IOperativosEN.Usuario = usuario;

                                dsGESFOR.Tables["DET"].Rows.Add("9", "1", "SIPA_KPI_OPERATIVOS", "ID_KPI_OPERATIVO", "INT", "1", idIO, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("10", "1", "SIPA_KPI_OPERATIVOS", "ID_OBJETIVO_OPERATIVO", "INT", "1", idOO, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("11", "1", "SIPA_KPI_OPERATIVOS", "ID_META_ESTRATEGICA", "INT", "1", idME, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("12", "1", "SIPA_KPI_OPERATIVOS", "NOMBRE", "VARCHAR", "1", txtIndicador0.Text, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("13", "1", "SIPA_KPI_OPERATIVOS", "ANIO", "INT", "1", anio, "N");
                                //dsGESFOR.Tables["DET"].Rows.Add("14", "1", "SIPA_KPI_OPERATIVOS", "FORMULA", "VARCHAR", "1", "", "S");
                                dsGESFOR.Tables["DET"].Rows.Add("15", "1", "SIPA_KPI_OPERATIVOS", "USUARIO", "VARCHAR", "1", usuario, "N");
                            }

                            if (txtMetaO0.Text != "")
                            {
                                MOperativasEN.Id_Meta_Operativa = idMO;
                                MOperativasEN.Id_Kpi_Operativo = idIO;
                                MOperativasEN.Id_Respondable = idUni;
                                MOperativasEN.Nombre = txtMetaO0.Text;
                                MOperativasEN.Anio = anio;
                                MOperativasEN.Usuario = usuario;

                                dsGESFOR.Tables["DET"].Rows.Add("16", "1", "SIPA_METAS_OPERATIVAS", "ID_META_OPERATIVA", "INT", "1", idMO, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("17", "1", "SIPA_METAS_OPERATIVAS", "ID_KPI_OPERATIVO", "INT", "1", idIO, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("18", "1", "SIPA_METAS_OPERATIVAS", "ANIO", "INT", "1", anio, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("19", "1", "SIPA_METAS_OPERATIVAS", "NOMBRE", "VARCHAR", "1", txtMetaO0.Text, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("20", "1", "SIPA_METAS_OPERATIVAS", "USUARIO", "VARCHAR", "1", usuario, "N");
                            }

                            if (txtAccion0.Text != "")
                            {
                                //ACCIONES
                                accionesEN.Id_Objetivo_Operativo = idOO;
                                accionesEN.Id_Meta_Operativa = idMO;

                                accionesEN.Id_Accion = idAC;
                                accionesEN.Id_Dependencia = idDep;
                                accionesEN.Id_Poa = idPoa;

                                accionesEN.Accion = txtAccion0.Text;

                                accionesEN.Id_Unidad = idUni;
                                accionesEN.Anio = anio;
                                accionesEN.Usuario = usuario;

                                dsGESFOR.Tables["DET"].Rows.Add("21", "1", "SIPA_ACCIONES", "ID_ACCION", "INT", "1", idAC, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("22", "1", "SIPA_ACCIONES", "ID_POA", "INT", "1", idPoa, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("23", "1", "SIPA_ACCIONES", "ID_DEPENDENCIA", "INT", "1", idDep, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("24", "1", "SIPA_ACCIONES", "ID_OBJETIVO_OPERATIVO", "INT", "1", idOO, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("25", "1", "SIPA_ACCIONES", "ID_META_OPERATIVA", "INT", "1", idMO, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("26", "1", "SIPA_ACCIONES", "CODIGO", "INT", "1", "0", "N");
                                dsGESFOR.Tables["DET"].Rows.Add("27", "1", "SIPA_ACCIONES", "ACCION", "VARCHAR", "1", txtAccion0.Text, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("47", "1", "SIPA_ACCIONES", "ANIO", "INT", "1", anio, "N");
                                dsGESFOR.Tables["DET"].Rows.Add("48", "1", "SIPA_ACCIONES", "USUARIO", "VARCHAR", "1", usuario, "N");
            
                            }

                            bool campos1 = txtMetaM.Text != "" || txtMetaM1.Text != "" || txtMetaM2.Text != "" || txtMetaM3.Text != "";
                            bool campos2 = txtResponsable.Text != "" || txtPond1.Text != "" || txtPond2.Text != "" || txtPond3.Text != "";
                            bool campos3 = txtM1.Text != "" || txtM2.Text != "" || txtM3.Text != "" || txtM4.Text != "" || txtM5.Text != "" || txtM6.Text != "" || txtM7.Text != "" || txtM8.Text != "" || txtM9.Text != "" || txtM10.Text != "" || txtM11.Text != "" || txtM12.Text != "";

                            if (campos1 || campos2 || campos3)
                            {
                                //METAS/ACCION
                                if (campos1 || campos2)
                                {
                                    metasEN.Id_Accion = idAC;
                                    metasEN.Id_Meta_Accion = idMA;
                                    metasEN.Id_Meta_Operativa = idMO;

                                    metasEN.Meta_General = txtMetaM.Text;
                                    metasEN.Meta_1 = txtMetaM1.Text;
                                    metasEN.Meta_2 = txtMetaM2.Text;
                                    metasEN.Meta_3 = txtMetaM3.Text;
                                    metasEN.Ponderacion1 = decimal.Parse(txtPond1.Text == "" ? "-1" : txtPond1.Text);
                                    metasEN.Ponderacion2 = decimal.Parse(txtPond2.Text == "" ? "-1" : txtPond2.Text);
                                    metasEN.Ponderacion3 = decimal.Parse(txtPond3.Text == "" ? "-1" : txtPond3.Text);

                                    decimal p1 = decimal.Parse(txtPond1.Text == "" ? lblPond1.Text : txtPond1.Text);
                                    decimal p2 = decimal.Parse(txtPond2.Text == "" ? lblPond2.Text : txtPond2.Text);
                                    decimal p3 = decimal.Parse(txtPond3.Text == "" ? lblPond3.Text : txtPond3.Text);

                                    metasEN.Responsable = txtResponsable.Text;

                                    dsGESFOR.Tables["DET"].Rows.Add("50", "1", "SIPA_METAS_ACCION", "ID_META_ACCION", "INT", "1", metasEN.Id_Meta_Accion, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("51", "1", "SIPA_METAS_ACCION", "ID_ACCION", "INT", "1", metasEN.Id_Accion, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("52", "1", "SIPA_METAS_ACCION", "ID_META_OPERATIVA", "INT", "1", metasEN.Id_Meta_Operativa, "S");
                                    
                                    if (metasEN.Meta_General != "") 
                                        dsGESFOR.Tables["DET"].Rows.Add("53", "1", "SIPA_METAS_ACCION", "META_GENERAL", "VARCHAR", "1", metasEN.Meta_General, "S");

                                    if (metasEN.Meta_1 != "") 
                                        dsGESFOR.Tables["DET"].Rows.Add("54", "1", "SIPA_METAS_ACCION", "META_1", "VARCHAR", "1", metasEN.Meta_1, "S");

                                    if (metasEN.Meta_2 != "") 
                                        dsGESFOR.Tables["DET"].Rows.Add("55", "1", "SIPA_METAS_ACCION", "META_2", "VARCHAR", "1", metasEN.Meta_2, "S");

                                    if (metasEN.Meta_3 != "") 
                                        dsGESFOR.Tables["DET"].Rows.Add("56", "1", "SIPA_METAS_ACCION", "META_3", "VARCHAR", "1", metasEN.Meta_3, "S");

                                    if (metasEN.Ponderacion1 > -1) 
                                        dsGESFOR.Tables["DET"].Rows.Add("57", "1", "SIPA_METAS_ACCION", "PONDERACION1", "DECIMAL", "1", metasEN.Ponderacion1, "S");

                                    if (metasEN.Ponderacion2 > -1) 
                                        dsGESFOR.Tables["DET"].Rows.Add("58", "1", "SIPA_METAS_ACCION", "PONDERACION2", "DECIMAL", "1", metasEN.Ponderacion2, "S");

                                    if (metasEN.Ponderacion3 > -1) 
                                        dsGESFOR.Tables["DET"].Rows.Add("59", "1", "SIPA_METAS_ACCION", "PONDERACION3", "DECIMAL", "1", metasEN.Ponderacion3, "S");

                                    if (metasEN.Responsable != "") 
                                        dsGESFOR.Tables["DET"].Rows.Add("63", "1", "SIPA_METAS_ACCION", "RESPONSABLE", "VARCHAR", "1", metasEN.Responsable, "S");
                                }
                                if (campos3)
                                {
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

                                    dsGESFOR.Tables["DET"].Rows.Add("64", "1", "SIPA_METAS_ACCION", "ENE", "BIT", "1", metasEN.Enero, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("65", "1", "SIPA_METAS_ACCION", "FEB", "BIT", "1", metasEN.Febrero, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("66", "1", "SIPA_METAS_ACCION", "MAR", "BIT", "1", metasEN.Marzo, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("67", "1", "SIPA_METAS_ACCION", "ABR", "BIT", "1", metasEN.Abril, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("68", "1", "SIPA_METAS_ACCION", "MAY", "BIT", "1", metasEN.Mayo, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("69", "1", "SIPA_METAS_ACCION", "JUN", "BIT", "1", metasEN.Junio, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("70", "1", "SIPA_METAS_ACCION", "JUL", "BIT", "1", metasEN.Julio, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("71", "1", "SIPA_METAS_ACCION", "AGO", "BIT", "1", metasEN.Agosto, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("72", "1", "SIPA_METAS_ACCION", "SEP", "BIT", "1", metasEN.Septiembre, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("73", "1", "SIPA_METAS_ACCION", "OCT", "BIT", "1", metasEN.Octubre, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("74", "1", "SIPA_METAS_ACCION", "NOV", "BIT", "1", metasEN.Noviembre, "S");
                                    dsGESFOR.Tables["DET"].Rows.Add("75", "1", "SIPA_METAS_ACCION", "DIC", "BIT", "1", metasEN.Diciembre, "S");
                                }
                                else
                                    metasEN.Enero = metasEN.Febrero = metasEN.Marzo = metasEN.Abril = metasEN.Mayo = metasEN.Junio = metasEN.Julio = metasEN.Agosto = metasEN.Septiembre = metasEN.Octubre = metasEN.Noviembre = metasEN.Diciembre = -1;

                                metasEN.Anio = anio;
                                metasEN.Usuario = usuario;

                                dsGESFOR.Tables["DET"].Rows.Add("76", "1", "SIPA_METAS_ACCION", "ANIO", "INT", "1", anio, "S");
                                dsGESFOR.Tables["DET"].Rows.Add("77", "1", "SIPA_METAS_ACCION", "USUARIO", "VARCHAR", "1", usuario, "S");
                            }

                            dsResultado = pAccionLN.AlmacenarGESFOR2(dsGESFOR);

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se INSERTÓ/ACTUALIZÓ la acción: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            lblIdSol.Text = dsResultado.Tables[0].Rows[0]["VALOR"].ToString();
                            lblNo.Text = dsResultado.Tables[0].Rows[0]["CODIGO"].ToString();
                            lblSuccess.Text = "Solicitud de actualización generada con éxito!: " + lblNo.Text;
                            lblError.Text = string.Empty;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Error al generar la Solicitud: " + ex.Message;
                    }
                }
                else if (rblCambio.SelectedValue.Equals("2"))
                {
                    try
                    {
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Error al generar la Solicitud: " + ex.Message;
                    }
                }
            }
        }


        protected void limpiarControlesError()
        {
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;

            lblEUnidad.Text = string.Empty;
            lblEFecha.Text = string.Empty;
            lblEAccion.Text = string.Empty;
            lblEAccion2.Text = string.Empty;
        }

        private bool validarControlesABC()
        {
            limpiarControlesError();
            bool controlesValidos = false;

            try
            {
                rfvAccion.Enabled = rfvIndicador.Enabled = rfvMeta.Enabled = rfvMetaC1.Enabled = rfvMetaC2.Enabled = rfvMetaC3.Enabled = rfvMetaO.Enabled = rfvObjetivo.Enabled = rfvPond1.Enabled = rfvPond2.Enabled = rfvPond3.Enabled = rfvPonderacion.Enabled = rfvPresupuesto.Enabled = rfvPresupuesto2.Enabled = rfvResponsable.Enabled = rfvJustificacion.Enabled = false;
                if (ddlDependencias.SelectedValue.Equals("0 - 0") || ddlDependencias.Items.Count == 0)
                {
                    lblEUnidad.Text = "*";
                    lblError.Text += "Seleccione una Unidad!. ";
                }

                FuncionesVarias funciones = new FuncionesVarias();
                DataSet dsResultado = funciones.StringToFechaMySql(txtFecha.Text);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblEFecha.Text = "*";
                    lblError.Text += "Ingrese una fecha válida!. ";
                }

                //if(!lblError.Text.Equals(string.Empty))
                //    return false;
                
                txtObjetivo.Text = txtObjetivo.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtObjetivo0.Text = txtObjetivo0.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtIndicador.Text = txtIndicador.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtIndicador0.Text = txtIndicador0.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtMetaO.Text = txtMetaO.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtMetaO0.Text = txtMetaO0.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtAccion.Text = txtAccion.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtAccion0.Text = txtAccion0.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtMeta.Text = txtMeta.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtMetaM.Text = txtMetaM.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtMeta1.Text = txtMeta1.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtMetaM1.Text = txtMetaM1.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtMeta2.Text = txtMeta2.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtMetaM2.Text = txtMetaM2.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtMeta3.Text = txtMeta3.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtMetaM3.Text = txtMetaM3.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                txtResponsable.Text = txtResponsable.Text.Replace('\'', ' ').Replace('"', ' ').Trim();

                if (rblCambio.SelectedValue.Equals("1"))
                {
                    if (ddlAcciones.SelectedValue.Equals("0") || ddlAcciones.Items.Count == 0)
                    {
                        lblEAccion.Text = "*";
                        lblError.Text += "Seleccione una Acción!. ";
                    }

                    //MODIFICACIÓN
                    bool campos1 = txtObjetivo0.Text.Equals("") & txtIndicador0.Text.Equals("") & txtMetaO0.Text.Equals("") & txtAccion0.Text.Equals("");
                    bool campos2 = txtMetaM.Text.Equals("") & txtMetaM1.Text.Equals("") & txtMetaM2.Text.Equals("") & txtMetaM3.Text.Equals("");
                    bool campos3 = txtResponsable.Text.Equals("") & txtPond1.Text.Equals("") & txtPond2.Text.Equals("") & txtPond3.Text.Equals("");// &txtPonderacion.Text.Equals("");
                    bool campos4 = txtM1.Text.Equals("") & txtM2.Text.Equals("") & txtM3.Text.Equals("") & txtM4.Text.Equals("") & txtM5.Text.Equals("") & txtM6.Text.Equals("") & txtM7.Text.Equals("") & txtM8.Text.Equals("") & txtM9.Text.Equals("") & txtM10.Text.Equals("") & txtM11.Text.Equals("") & txtM12.Text.Equals("");
                    bool campos5 = txtPpto1.Text == "" || txtPpto1.Text == "0";

                    if (campos1 && campos2 && campos3 && campos4 && campos5)
                    {
                        lblError.Text += "Ingrese un valor para actualizar!. ";
                    }
                    else
                    {
                        decimal montoDebito = 0;
                        if (decimal.TryParse(txtPpto1.Text, out montoDebito) && montoDebito > 0)
                        {
                            if (ddlAcciones2.SelectedValue.Equals("0") || ddlAcciones2.Items.Count == 0)
                            {
                                lblEAccion2.Text = "*";
                                lblError.Text += "Seleccione una Acción para acreditar la transferencia!. ";
                            }
                        }
                    }

                    if (txtJustificacion.Text == "")
                        lblError.Text += "Ingrese una justificación!. ";

                    if (lblError.Text.Equals(string.Empty))
                        controlesValidos = true;

                    rfvPresupuesto.Enabled = true;
                    rfvJustificacion.Enabled = true;

                    this.Page.Validate("grpDatos");

                    if (controlesValidos && Page.IsValid)
                        controlesValidos = true;
                    else
                        controlesValidos = false;
                }
                else
                {
                    if (txtM1.Text.Equals(string.Empty) && txtM2.Text.Equals(string.Empty) && txtM3.Text.Equals(string.Empty) && txtM4.Text.Equals(string.Empty) && txtM5.Text.Equals(string.Empty) && txtM6.Text.Equals(string.Empty) && txtM7.Text.Equals(string.Empty) && txtM8.Text.Equals(string.Empty) && txtM9.Text.Equals(string.Empty) && txtM10.Text.Equals(string.Empty) && txtM11.Text.Equals(string.Empty) && txtM12.Text.Equals(string.Empty))
                    {
                        lblEMeses.Text = "*";
                        lblError.Text += "Ingrese un Mes!. ";
                    }

                    if (txtJustificacion.Text == "")
                        lblError.Text += "Ingrese una justificación!. ";

                    if (lblError.Text == "")
                        controlesValidos = true;

                    rfvIndicador.Enabled = rfvMeta.Enabled = rfvMetaC1.Enabled = rfvMetaC2.Enabled = rfvMetaC3.Enabled = rfvMetaO.Enabled = rfvObjetivo.Enabled = rfvPond1.Enabled = rfvPond2.Enabled = rfvPond3.Enabled = rfvPonderacion.Enabled = rfvPresupuesto.Enabled = rfvPresupuesto2.Enabled = rfvResponsable.Enabled = rfvJustificacion.Enabled = true;
                    this.Page.Validate("grpDatos");

                    if (controlesValidos && Page.IsValid)
                        controlesValidos = true;
                    else
                        controlesValidos = false;                    
                }

                /*if (lblEAnio.Text.Equals(string.Empty) && lblEUnidad.Text.Equals(string.Empty) && lblEObjetivo.Text.Equals(string.Empty) && lblEPlan.Text.Equals(string.Empty) && lblEMeses.Text.Equals(string.Empty))
                    controlesValidos = true;

                rfvCodigo.Enabled = false;
                if (txtCodigo.Enabled)
                    rfvCodigo.Enabled = true;
                rfvAccion.Enabled = rfvMeta.Enabled = rfvMetaC1.Enabled = rfvMetaC2.Enabled = rfvMetaC3.Enabled = true;
                rfvPonderacion.Enabled = rfvPresupuesto.Enabled = rfvResponsable.Enabled = true;

                this.Page.Validate("grpDatos");

                if (controlesValidos && Page.IsValid)
                    controlesValidos = true;
                else
                    controlesValidos = false;*/
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }
            return controlesValidos;
        }

        protected bool validarPoa(int idUnidad, int anio)
        {
            bool poaValido = false;
            btnGuardar.Visible = false;
            lblIdPoa.Text = "0";
            try
            {              
                pOperativoLN = new PlanOperativoLN();
                DataSet dsPoa = pOperativoLN.DatosPoaUnidad(idUnidad, anio);
                
                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                int idPoa = int.Parse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString());
                lblIdPoa.Text = idPoa.ToString();

                string estadoPoa = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString();
                string nombreEstado = dsPoa.Tables[0].Rows[0]["ESTADO"].ToString();
                if (!estadoPoa.Equals("9"))
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa + " - " + nombreEstado;
                else
                    btnGuardar.Visible = true;
                ///////////////////////////////////
                btnGuardar.Visible = true;
                //////////////////////////////////
                poaValido = true;
            }
            catch (Exception ex)
            {
                lblError.Text = lblErrorPoa.Text = "Error: " + ex.Message;
            }
            return poaValido;
        }

        protected bool validarPpto()
        {
            bool pptoValido = false;
            try
            {
                /*pAccionLN = new PlanAccionLN();
                DataSet dsPpto = pAccionLN.PptoDep(idPoa, idDependencia);

                decimal techo = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["TECHO"].ToString());
                decimal asignado = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["ASIGNADO"].ToString());
                decimal disponible = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE"].ToString());
                
                lblTecho.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", techo);
                lblAsignado.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", asignado);
                lblDisponible.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", disponible);*/
                pptoValido = true;
            }
            catch (Exception ex)
            {
                throw new Exception("obtenerPresupuesto(). " + ex.Message);
            }
            return pptoValido;
        }

        protected void obtenerPresupuesto(int idPoa, int idDependencia)
        {
            try
            {
                /*pAccionLN = new PlanAccionLN();
                DataSet dsPpto = pAccionLN.PptoDep(idPoa, idDependencia);

                decimal techo = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["TECHO"].ToString());
                decimal asignado = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["ASIGNADO"].ToString());
                decimal disponible = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE"].ToString());
                
                lblTecho.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", techo);
                lblAsignado.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", asignado);
                lblDisponible.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", disponible);*/
                
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
                NuevaModificacion(sender, e);
                string selectedV = ddlDependencias.SelectedValue;
                int idDependencia = int.Parse(selectedV.Split('-')[0].Trim());
                int idUnidad = int.Parse(selectedV.Split('-')[1].Trim());
                int anio = int.Parse(lblAnioSol.Text);
                
                btnGuardar.Visible = false;
                if (idUnidad > 0)
                {
                    validarPoa(idUnidad, anio);
                    pAccionLN = new PlanAccionLN();
                    pAccionLN.DdlAcciones_x_Dependencia(ddlAcciones, anio, idDependencia);
                    ddlAcciones.Items[0].Text = "<< Elija un valor >>";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlDependencias_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlIndicadores_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                //lblErrorBusqueda.Text = "gridPlanO_PageIndexChanging(). " + ex.Message;
            }
        }

        protected void gridPlanO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idMeta = int.Parse(gridPlanO.SelectedValue.ToString());

                pOperativoLN = new PlanOperativoLN();
                DataSet dsDatos = pOperativoLN.BuscarId(idMeta.ToString());
                int idKpi = int.Parse(dsDatos.Tables["BUSQUEDA"].Rows[0]["ID_KPI_O"].ToString());
                ddlIndicadores.SelectedValue = idKpi.ToString();

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idMeta);

                filtrarGridPlanO(idMeta.ToString());
                limpiarCNuevaAccion();
                limpiarCNuevaMeta();
                txtAccion.Focus();
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

                txtPonderacion.Text = txtPpto1.Text = txtResponsable.Text = string.Empty;
                txtM1.Text = txtM2.Text = txtM3.Text = txtM4.Text = string.Empty;
                txtM5.Text = txtM6.Text = txtM7.Text = txtM8.Text = string.Empty;
                txtM9.Text = txtM10.Text = txtM11.Text = txtM12.Text = string.Empty;

                rfvMeta.Enabled = rfvMetaC1.Enabled = rfvMetaC2.Enabled = rfvMetaC3.Enabled = false;
                rfvPonderacion.Enabled = rfvPresupuesto.Enabled = rfvResponsable.Enabled = false;
                txtMeta.Focus();

                int vValue = int.Parse(ddlMetas.SelectedValue);
                if (vValue > 0)
                {
                    pAccionLN = new PlanAccionLN();
                    DataSet dsResultado = pAccionLN.InformacionMeta(vValue);

                    txtMeta.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_GENERAL"].ToString();
                    txtMeta1.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_1"].ToString();
                    txtMeta2.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_2"].ToString();
                    txtMeta3.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_3"].ToString();
                    txtPonderacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PONDERACION"].ToString();
                    txtPpto1.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PRESUPUESTO"].ToString();
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
        }

        protected void btnNuevaB_Click(object sender, EventArgs e)
        {
            string _open = "window.open('VerPlan.aspx', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void chkCronograma_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCronograma.Checked)
                txtM1.Text = txtM2.Text = txtM3.Text = txtM4.Text = txtM5.Text = txtM6.Text = txtM7.Text = txtM8.Text = txtM9.Text = txtM10.Text = txtM11.Text = txtM12.Text = "X";
            else
                txtM1.Text = txtM2.Text = txtM3.Text = txtM4.Text = txtM5.Text = txtM6.Text = txtM7.Text = txtM8.Text = txtM9.Text = txtM10.Text = txtM11.Text = txtM12.Text = string.Empty;
        }

        protected void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked)
                txtAccion0.Visible = txtObjetivo0.Visible = txtIndicador0.Visible = txtMetaO0.Visible = true;
            else
                txtAccion0.Visible = txtObjetivo0.Visible = txtIndicador0.Visible = txtMetaO0.Visible = false;
        }

        protected void chkMostrarDet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarDet.Checked)
                pnlDetAccion.Visible = true;
            else
                pnlDetAccion.Visible = false;
        }

        protected void rblCambio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedV = ddlDependencias.SelectedValue;
            int idDependencia = int.Parse(selectedV.Split('-')[0].Trim());
            int idUnidad = int.Parse(selectedV.Split('-')[1].Trim());
            int anio = int.Parse(lblAnioSol.Text);

            if (rblCambio.SelectedValue.Equals("1"))
            {

                NuevaModificacion(sender, e);

                btnGuardar.Visible = false;
                if (idUnidad > 0)
                {
                    validarPoa(idUnidad, anio);
                    pAccionLN = new PlanAccionLN();
                    pAccionLN.DdlAcciones_x_Dependencia(ddlAcciones, anio, idDependencia);
                    ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                }
            }
            else
            {
                NuevoIngreso(sender, e);

                if (idUnidad > 0)
                    validarPoa(idUnidad, anio);
            }

        }

        protected void rblModPpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPpto2.Text = lblPptoM2.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
            txtPpto2.Text = "0";

            if (rblCambio.SelectedValue.Equals("1"))
            {
                lblS1.Text = "(-)";
                lblS2.Text = "(+)";
                txtPpto1.Enabled = true;
                txtPpto2.Enabled = false;

                int idUnidad = int.Parse(ddlDependencias.SelectedValue.Split('-')[1]);
                string idAccion = ddlAcciones.SelectedValue.Equals(string.Empty) ? "0" : ddlAcciones.SelectedValue;
                pAccionLN = new PlanAccionLN();

                if (!ddlAcciones.SelectedValue.Equals("0"))
                {
                    if (rblModPpto.SelectedValue.Equals("1"))
                    {
                        pAccionLN.DdlAccionesGESFOR2T(ddlAcciones2, "true", idUnidad);
                        ListItem item = ddlAcciones2.Items.FindByValue(idAccion);
                        if (item != null && int.Parse(idAccion) > 0)
                            ddlAcciones2.Items.Remove(item);
                        
                    }
                    else
                    {
                        pAccionLN.DdlAccionesGESFOR2T(ddlAcciones2, "false", idUnidad);
                    }
                }
                else
                {
                    ddlAcciones2.ClearSelection();
                    ddlAcciones2.Items.Clear();
                }
            }
            else
            {
                rblModPpto.SelectedValue = "1";
                lblS1.Text = "(+)";
                lblS2.Text = "(-)";
                txtPpto1.Enabled = false;
                txtPpto2.Enabled = true;

                int idUnidad = int.Parse(ddlDependencias.SelectedValue.Split('-')[1]);
                pAccionLN = new PlanAccionLN();

                pAccionLN.DdlAccionesGESFOR2T(ddlAcciones2, "true", idUnidad);
            }
        }

        protected void ddlAcciones2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int vValue = int.Parse(ddlAcciones2.SelectedValue);
                decimal vPpto = 0;
                decimal vPptoO = 0;

                //MODIFICACIÓN DE ACCIÓN
                if (rblCambio.SelectedValue.Equals("1"))
                {
                    decimal temp = 0;

                    if (decimal.TryParse(txtPpto1.Text, out temp) && temp > 0)
                    {
                        if (vValue > 0)
                        {
                            vPpto = decimal.Parse(dsAccionP.Tables["BUSQUEDA"].Rows[0]["PRESUPUESTO"].ToString());
                            vPptoO = decimal.Parse(txtPpto1.Text);
                            lblPptoM1.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", vPpto - vPptoO);
                            txtPpto1.Enabled = false;

                            //SECCIÓN DE TRANSFERENCIA DEL PRESUPUESTO
                            txtPpto2.Text = txtPpto1.Text;
                            pAccionLN = new PlanAccionLN();
                            dsAccionA = pAccionLN.InformacionGESFOR2(vValue, 0, "", 1);

                            vPpto = decimal.Parse(dsAccionA.Tables["BUSQUEDA"].Rows[0]["PRESUPUESTO"].ToString());
                            vPptoO = decimal.Parse(txtPpto2.Text);

                            lblPpto2.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", vPpto);
                            lblPptoM2.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", vPpto + vPptoO);

                        }
                        else
                        {
                            lblPpto2.Text = lblPptoM2.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
                            txtPpto2.Text = "0";
                        }
                    }
                    else
                    {
                        ddlAcciones2.ClearSelection();
                        lblPpto2.Text = lblPptoM2.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
                        txtPpto1.Text = txtPpto2.Text = "0";
                    }
                }
                else
                {
                    if (vValue > 0)
                    {
                        pAccionLN = new PlanAccionLN();
                        dsAccionA = pAccionLN.InformacionGESFOR2(vValue, 0, "", 1);

                        vPpto = decimal.Parse(dsAccionA.Tables["BUSQUEDA"].Rows[0]["PRESUPUESTO"].ToString());
                        //vPptoO = decimal.Parse(txtPpto2.Text);

                        txtPpto2.Text = "0";
                        lblPpto2.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", vPpto);
                        lblPptoM2.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", vPpto);

                        rvPresupuesto.MaximumValue = "100000000";
                        rvPresupuesto0.MaximumValue = vPpto.ToString();
                    }
                    else
                    {
                        ddlAcciones2.ClearSelection();
                        lblPpto2.Text = lblPptoM2.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
                        txtPpto1.Text = txtPpto2.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones2_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {

        }



    }
}
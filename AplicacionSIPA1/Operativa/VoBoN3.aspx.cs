﻿using System;
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

namespace AplicacionSIPA1.Operativa
{
    public partial class VoBoN3 : System.Web.UI.Page
    {
        private PlanEstrategicoLN planEstrategicoLN;
        private PlanOperativoLN planOperativoLN;
        private PlanAccionLN planAccionLN;
        private UsuariosLN uUsuariosLN;

        string Last = string.Empty;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    planEstrategicoLN = new PlanEstrategicoLN();
                    planEstrategicoLN.DdlPlanes(ddlPlanes);

                    string usuario = Session["Usuario"].ToString().ToLower();
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
                    int anioActual = (DateTime.Now.Year + 1);

                    planEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                    ListItem item = ddlAnios.Items.FindByValue(anioActual.ToString());
                    if (item != null)
                        ddlAnios.SelectedValue = anioActual.ToString();

                    uUsuariosLN = new UsuariosLN();
                    uUsuariosLN.dropUnidad(ddlUnidades);

                    planAccionLN = new PlanAccionLN();
                    planAccionLN.DdlAccionesPoa(ddlAcciones, 0);
                    ddlAcciones.Items[0].Text = "<< Mostrar todo >>";
                        
                    planAccionLN.DdlDependenciasUsuario(ddlDependencias, Session["usuario"].ToString(), int.Parse(ddlUnidades.SelectedValue));;
                    ddlDependencias.Items[0].Text = "<< Elija un valor >>";

                    if (ddlUnidades.Items.Count == 1)
                    {
                        planAccionLN.DdlDependenciasUsuario(ddlDependencias, Session["usuario"].ToString(), int.Parse(ddlUnidades.SelectedValue));

                        if (!ddlAnios.SelectedValue.Equals("0"))
                        {
                            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                        }
                    }

                    int idPoa = 0;
                    int.TryParse(lblIdPoa.Text, out idPoa);
                    planAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                    ddlAcciones.Items[0].Text = "<< Mostrar todo >>";

                    rblMostrar.SelectedValue = "1";
                    rblMostrar_SelectedIndexChanged(sender, e);

                    txtObser.Enabled = true;
                    filtrarGridPlan();
                    generarReporte();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void filtrarGridPlan()
        {
            try
            {
                gridPlan.DataSource = null;
                gridPlan.DataBind();

                int idUnidad = 0;
                int idPoa = 0;

                int.TryParse(lblIdPoa.Text, out idPoa);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                planAccionLN = new PlanAccionLN();
                planAccionLN.GridPlan(gridPlan, idUnidad, idPoa);

                string filtro = string.Empty;

                object obj = gridPlan.DataSource;
                System.Data.DataTable tbl = gridPlan.DataSource as System.Data.DataTable;
                System.Data.DataView dv = tbl.DefaultView;

                filtro = " anio = " + ddlAnios.SelectedValue;

                if (!ddlAcciones.SelectedValue.Equals("0"))
                    filtro += " AND id_accion = " + ddlAcciones.SelectedValue;

                //AGREGAR GROUP BY 
                dv.RowFilter = filtro;

                gridPlan.DataSource = dv;
                gridPlan.DataBind();

                filtrarGridRenglonesUnidad();

            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridPlan(). "  + ex.Message);
            }

        }

        protected void filtrarGridRenglonesUnidad()
        {
            try
            {
                gridRenglonesUnidad.DataSource = null;
                gridRenglonesUnidad.DataBind();

                int idUnidad = 0;
                int idPoa = 0;

                int.TryParse(lblIdPoa.Text, out idPoa);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                planAccionLN = new PlanAccionLN();
                DataSet dsResultado = planAccionLN.InformacionAccionDetalles(idPoa, 0, "", 2);

                gridRenglonesUnidad.DataSource = dsResultado.Tables["BUSQUEDA"];
                gridRenglonesUnidad.DataBind();

                if (gridRenglonesUnidad.Rows.Count > 0)
                {
                    decimal monto, codificado, saldo;
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Compute("SUM(MONTO)", "").ToString(), out monto);
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Compute("SUM(CODIFICADO)", "").ToString(), out codificado);
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Compute("SUM(SALDO)", "").ToString(), out saldo);

                    gridRenglonesUnidad.FooterRow.Cells[1].Text = "TOTALES";
                    gridRenglonesUnidad.FooterRow.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", monto);
                    gridRenglonesUnidad.FooterRow.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", codificado);
                    gridRenglonesUnidad.FooterRow.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);

                    gridRenglonesUnidad.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    gridRenglonesUnidad.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    gridRenglonesUnidad.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridRenglonesUnidad(). " + ex.Message);
            }

        }
        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                filtrarGridPlan();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                int anio = int.Parse(ddlAnios.SelectedValue);
                int idUnidad = int.Parse(ddlUnidades.SelectedValue);

                lblTechoD.Text = lblTechoU.Text = lblDisponibleD.Text = lblDisponibleU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);

                if (idUnidad > 0)
                {
                    planAccionLN = new PlanAccionLN();
                    planAccionLN.DdlDependenciasUsuario(ddlDependencias, Session["usuario"].ToString(), int.Parse(ddlUnidades.SelectedValue));
                }

                if (anio > 0 && idUnidad > 0)
                    validarPoa(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);
                planAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Mostrar todo >>";

                filtrarGridPlan();
                generarReporte();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void limpiarControlesError()
        {
            lblError.Text = lblSuccess.Text = string.Empty;
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                //filtrarGridPlan();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                int anio = int.Parse(ddlAnios.SelectedValue);
                int idUnidad = int.Parse(ddlUnidades.SelectedValue);

                lblTechoD.Text = lblTechoU.Text = lblDisponibleD.Text = lblDisponibleU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);

                if (anio > 0 && idUnidad > 0)
                    validarPoa(idUnidad, anio);

                planAccionLN = new PlanAccionLN();
                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);
                planAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Mostrar todo >>";

                filtrarGridPlan();
                generarReporte();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios_SelectedIndexChanged(). " + ex.Message;
            }
        }


        protected bool validarPoa(int idUnidad, int anio)
        {
            lblErrorPoa.Text = lblError.Text = string.Empty;
            bool poaValido = false;
            btnAprobar.Visible = btnRechazar.Visible = false;
            lblIdPoa.Text = "0";
            try
            {
                lblTechoD.Text = lblTechoU.Text = lblDisponibleD.Text = lblDisponibleU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);

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

                string observaciones = dsPoa.Tables[0].Rows[0]["OBSERVACIONES"].ToString();
                //1	Sin Enviar a Revision
                if (estadoPoa.Equals("1"))
                {
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + lblEstadoPoa.Text + ". No se puede Aprobar o Rechazar";

                    btnAprobar.Visible = false;
                    btnRechazar.Visible = false;
                    btnVerReporte.Visible = true;
                    lblObservaciones.Visible = txtObser.Visible = false;
                }
                //7	Revisión Dirección
                else if (estadoPoa.Equals("7"))
                {
                    lblErrorPoa.Text = lblError.Text = string.Empty;

                    btnAprobar.Visible = true;
                    btnRechazar.Visible = true;
                    btnVerReporte.Visible = true;

                    txtObser.Text = observaciones;
                    lblObservaciones.Visible = txtObser.Visible = true;
                }
                //2	Revisión Subgerencia, 4	Revisión Analista POA
                else if (estadoPoa.Equals("2") || estadoPoa.Equals("4"))
                {
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + lblEstadoPoa.Text + ". No se puede Aprobar o Rechazar";

                    btnAprobar.Visible = false;
                    btnRechazar.Visible = false;
                    btnVerReporte.Visible = true;
                    lblObservaciones.Visible = txtObser.Visible = false;
                }
                //3	Rechazado Subgerencia, 6	Rechazado Analista POA, 8	Rechazado Dirección, 
                else if (estadoPoa.Equals("3") || estadoPoa.Equals("6") || estadoPoa.Equals("8"))
                {
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + lblEstadoPoa.Text + ", por: " + observaciones + ". No se puede Aprobar o Rechazar";

                    btnAprobar.Visible = false;
                    btnRechazar.Visible = false;
                    btnVerReporte.Visible = true;

                    txtObser.Text = observaciones;
                    lblObservaciones.Visible = txtObser.Visible = true;
                }
                //9	Aprobado Dirección
                else if (estadoPoa.Equals("9"))
                {
                    lblErrorPoa.Text = lblError.Text = string.Empty;

                    btnAprobar.Visible = false;
                    btnRechazar.Visible = false;
                    btnVerReporte.Visible = true;

                    txtObser.Text = string.Empty;
                    lblObservaciones.Visible = txtObser.Visible = false;
                }
                else
                {
                    lblErrorPoa.Text = lblError.Text = "Estado desconocido: " + estadoPoa + ", por favor consulte con el administrador del sistema";

                    btnAprobar.Visible = false;
                    btnRechazar.Visible = false;
                    btnVerReporte.Visible = true;

                    txtObser.Text = string.Empty;
                    lblObservaciones.Visible = txtObser.Visible = false;
                }

                //btnEnviar.Visible = txtObser.Visible = lblObservaciones.Visible = true;

                int idDep = 0;
                int.TryParse(ddlDependencias.Items[0].Value, out idDep);
                obtenerPresupuesto(idPoa, idDep);

                generarReporte();

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

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                filtrarGridPlan();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones_SelectedIndexChanged(). " + ex.Message;
            }
        }
        


        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
            int idPoa = 0;

            lblTechoD.Text = lblTechoU.Text = lblDisponibleD.Text = lblDisponibleU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);

            if (!int.TryParse(lblIdPoa.Text, out idPoa))
                throw new Exception("No existe POA seleccionado");

            obtenerPresupuesto(idPoa, int.Parse(ddlDependencias.SelectedValue));

            filtrarGridPlan();
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);

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

        protected void generarReporte()
        {
            try
            {
                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                int idUnidad = 0;
                int.TryParse(ddlUnidades.SelectedItem.Value, out idUnidad);

                if (idPoa > 0)
                {

                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    ReportViewer rViewer = new ReportViewer();

                    DataTable dt = new DataTable();
                    GridView gridPlan = new GridView();
                    PlanAccionLN pAccionLN = new PlanAccionLN();
                    pAccionLN.GridPlan(gridPlan, 0, idPoa);

                    dt = gridPlan.DataSource as System.Data.DataTable;
                    ReportDataSource RD = new ReportDataSource();
                    RD.Value = dt;
                    RD.Name = "DataSet1";

                    rViewer.LocalReport.DataSources.Clear();
                    rViewer.LocalReport.DataSources.Add(RD);
                    rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes/rptPlanEstrategico.rdlc";
                    rViewer.LocalReport.ReportPath = @"Reportes\\rptPlanEstrategico.rdlc";
                    rViewer.LocalReport.Refresh();


                    byte[] bytes = rViewer.LocalReport.Render(
                       "Excel", null, out mimeType, out encoding,
                        out extension,
                       out streamids, out warnings);

                    string nombreReporte = "CMI - " + ddlAnios.SelectedItem.Text + " - " + ddlUnidades.SelectedItem.Text;

                    string direccion = Server.MapPath("ArchivoPdf");
                    direccion = (direccion + ("\\\\" + (""
                                + (nombreReporte + ".xls"))));

                    FileStream fs = new FileStream(direccion,
                       FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();

                    String reDireccion = "\\ArchivoPDF/";
                    reDireccion += "\\" + "" + nombreReporte + ".xls";


                    string jScript = "javascript:window.open('" + reDireccion + "','CUADRO DE MANDO INTEGRAL'," + "'directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=750, height=400');";

                    btnVerReporte.Attributes.Add("onclick", jScript);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnVerReporte(). " + ex.Message;
            }
        }
		
        protected void btnVerReporte_Click(object sender, EventArgs e)
        {
            
        }
        
        protected void rblMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblMostrar.SelectedValue.Equals("1"))
            {

                gridPlan.Columns[1].Visible = true;
                gridPlan.Columns[2].Visible = true;
                gridPlan.Columns[3].Visible = true;
                gridPlan.Columns[4].Visible = true;
                gridPlan.Columns[5].Visible = true;
                gridPlan.Columns[6].Visible = true;
                gridPlan.Columns[7].Visible = true;
                gridPlan.Columns[8].Visible = true;
                gridPlan.Columns[9].Visible = true;
                gridPlan.Columns[10].Visible = true;

                gridPlan.Columns[11].Visible = true;
                gridPlan.Columns[12].Visible = true;
                gridPlan.Columns[13].Visible = true;
                gridPlan.Columns[14].Visible = true;
                gridPlan.Columns[15].Visible = true;
                gridPlan.Columns[16].Visible = true;
                gridPlan.Columns[17].Visible = true;
                gridPlan.Columns[18].Visible = true;
                gridPlan.Columns[19].Visible = true;
                gridPlan.Columns[20].Visible = true;

                gridPlan.Columns[21].Visible = true;
                gridPlan.Columns[22].Visible = true;
                gridPlan.Columns[23].Visible = true;
                gridPlan.Columns[24].Visible = true;
                gridPlan.Columns[25].Visible = true;
                gridPlan.Columns[26].Visible = true;
                gridPlan.Columns[27].Visible = true;
                gridPlan.Columns[28].Visible = true;
                gridPlan.Columns[29].Visible = true;
                gridPlan.Columns[30].Visible = true;

                gridPlan.Columns[31].Visible = true;
                gridPlan.Columns[32].Visible = true;
                gridPlan.Columns[33].Visible = true;
            }

            if (rblMostrar.SelectedValue.Equals("2"))
            {

                /*gridPlan.Columns[1].Visible = true;
                gridPlan.Columns[2].Visible = true;
                gridPlan.Columns[3].Visible = true;
                gridPlan.Columns[4].Visible = true;
                gridPlan.Columns[5].Visible = true;
                gridPlan.Columns[6].Visible = true;
                gridPlan.Columns[7].Visible = false;
                gridPlan.Columns[8].Visible = false;
                gridPlan.Columns[9].Visible = false;
                gridPlan.Columns[10].Visible = false;

                gridPlan.Columns[11].Visible = false;
                gridPlan.Columns[12].Visible = false;
                gridPlan.Columns[13].Visible = false;
                gridPlan.Columns[14].Visible = false;
                gridPlan.Columns[15].Visible = false;
                gridPlan.Columns[16].Visible = false;
                gridPlan.Columns[17].Visible = false;
                gridPlan.Columns[18].Visible = false;
                gridPlan.Columns[19].Visible = false;
                gridPlan.Columns[20].Visible = false;

                gridPlan.Columns[21].Visible = false;
                gridPlan.Columns[22].Visible = false;
                gridPlan.Columns[23].Visible = false;
                gridPlan.Columns[24].Visible = false;
                gridPlan.Columns[25].Visible = false;
                gridPlan.Columns[26].Visible = false;
                gridPlan.Columns[27].Visible = false;
                gridPlan.Columns[28].Visible = false;
                gridPlan.Columns[29].Visible = false;
                gridPlan.Columns[30].Visible = false;

                gridPlan.Columns[31].Visible = false;
                gridPlan.Columns[32].Visible = false;
                gridPlan.Columns[33].Visible = false;*/

                gridPlan.Columns[1].Visible = true;
                gridPlan.Columns[2].Visible = true;
                gridPlan.Columns[3].Visible = true;
                gridPlan.Columns[4].Visible = true;
                gridPlan.Columns[5].Visible = true;
                gridPlan.Columns[6].Visible = true;
                gridPlan.Columns[7].Visible = true;
                gridPlan.Columns[8].Visible = true;
                gridPlan.Columns[9].Visible = true;
                gridPlan.Columns[10].Visible = true;

                gridPlan.Columns[11].Visible = true;
                gridPlan.Columns[12].Visible = true;
                gridPlan.Columns[13].Visible = false;
                gridPlan.Columns[14].Visible = false;
                gridPlan.Columns[15].Visible = false;
                gridPlan.Columns[16].Visible = false;
                gridPlan.Columns[17].Visible = false;
                gridPlan.Columns[18].Visible = false;
                gridPlan.Columns[19].Visible = false;
                gridPlan.Columns[20].Visible = false;

                gridPlan.Columns[21].Visible = false;
                gridPlan.Columns[22].Visible = false;
                gridPlan.Columns[23].Visible = false;
                gridPlan.Columns[24].Visible = false;
                gridPlan.Columns[25].Visible = false;
                gridPlan.Columns[26].Visible = false;
                gridPlan.Columns[27].Visible = false;
                gridPlan.Columns[28].Visible = false;
                gridPlan.Columns[29].Visible = false;
                gridPlan.Columns[30].Visible = false;

                gridPlan.Columns[31].Visible = false;
                gridPlan.Columns[32].Visible = false;
                gridPlan.Columns[33].Visible = false;
            }

            if (rblMostrar.SelectedValue.Equals("3"))
            {

                /*gridPlan.Columns[1].Visible = false;
                gridPlan.Columns[2].Visible = false;
                gridPlan.Columns[3].Visible = false;
                gridPlan.Columns[4].Visible = false;
                gridPlan.Columns[5].Visible = false;
                gridPlan.Columns[6].Visible = false;

                gridPlan.Columns[7].Visible = true;
                gridPlan.Columns[8].Visible = true;
                gridPlan.Columns[9].Visible = true;
                gridPlan.Columns[10].Visible = true;

                gridPlan.Columns[11].Visible = true;
                gridPlan.Columns[12].Visible = true;
                gridPlan.Columns[13].Visible = false;
                gridPlan.Columns[14].Visible = false;
                gridPlan.Columns[15].Visible = false;
                gridPlan.Columns[16].Visible = false;
                gridPlan.Columns[17].Visible = false;
                gridPlan.Columns[18].Visible = false;
                gridPlan.Columns[19].Visible = false;
                gridPlan.Columns[20].Visible = false;

                gridPlan.Columns[21].Visible = false;
                gridPlan.Columns[22].Visible = false;
                gridPlan.Columns[23].Visible = false;
                gridPlan.Columns[24].Visible = false;
                gridPlan.Columns[25].Visible = false;
                gridPlan.Columns[26].Visible = false;
                gridPlan.Columns[27].Visible = false;
                gridPlan.Columns[28].Visible = false;
                gridPlan.Columns[29].Visible = false;
                gridPlan.Columns[30].Visible = false;

                gridPlan.Columns[31].Visible = false;
                gridPlan.Columns[32].Visible = false;
                gridPlan.Columns[33].Visible = false;*/

                gridPlan.Columns[1].Visible = false;
                gridPlan.Columns[2].Visible = false;
                gridPlan.Columns[3].Visible = false;
                gridPlan.Columns[4].Visible = false;
                gridPlan.Columns[5].Visible = false;
                gridPlan.Columns[6].Visible = false;

                gridPlan.Columns[7].Visible = true;
                gridPlan.Columns[8].Visible = true;
                gridPlan.Columns[9].Visible = true;
                gridPlan.Columns[10].Visible = true;

                gridPlan.Columns[11].Visible = true;
                gridPlan.Columns[12].Visible = true;
                gridPlan.Columns[13].Visible = true;
                gridPlan.Columns[14].Visible = true;
                gridPlan.Columns[15].Visible = true;
                gridPlan.Columns[16].Visible = true;
                gridPlan.Columns[17].Visible = true;
                gridPlan.Columns[18].Visible = true;
                gridPlan.Columns[19].Visible = true;
                gridPlan.Columns[20].Visible = true;

                gridPlan.Columns[21].Visible = true;
                gridPlan.Columns[22].Visible = true;
                gridPlan.Columns[23].Visible = true;
                gridPlan.Columns[24].Visible = true;
                gridPlan.Columns[25].Visible = true;
                gridPlan.Columns[26].Visible = true;
                gridPlan.Columns[27].Visible = true;
                gridPlan.Columns[28].Visible = true;
                gridPlan.Columns[29].Visible = true;
                gridPlan.Columns[30].Visible = true;

                gridPlan.Columns[31].Visible = true;
                gridPlan.Columns[32].Visible = true;
                gridPlan.Columns[33].Visible = true;
            }

            if (rblMostrar.SelectedValue.Equals("4"))
            {

                gridPlan.Columns[1].Visible = false;
                gridPlan.Columns[2].Visible = false;
                gridPlan.Columns[3].Visible = false;
                gridPlan.Columns[4].Visible = false;
                gridPlan.Columns[5].Visible = false;
                gridPlan.Columns[6].Visible = false;

                gridPlan.Columns[7].Visible = false;
                gridPlan.Columns[8].Visible = false;
                gridPlan.Columns[9].Visible = false;
                gridPlan.Columns[10].Visible = false;
                gridPlan.Columns[11].Visible = false;
                gridPlan.Columns[12].Visible = false;

                gridPlan.Columns[13].Visible = true;
                gridPlan.Columns[14].Visible = true;
                gridPlan.Columns[15].Visible = true;
                gridPlan.Columns[16].Visible = true;
                gridPlan.Columns[17].Visible = true;
                gridPlan.Columns[18].Visible = true;
                gridPlan.Columns[19].Visible = true;
                gridPlan.Columns[20].Visible = true;

                gridPlan.Columns[21].Visible = true;
                gridPlan.Columns[22].Visible = true;
                gridPlan.Columns[23].Visible = true;
                gridPlan.Columns[24].Visible = true;
                gridPlan.Columns[25].Visible = true;
                gridPlan.Columns[26].Visible = true;
                gridPlan.Columns[27].Visible = true;
                gridPlan.Columns[28].Visible = true;
                gridPlan.Columns[29].Visible = true;
                gridPlan.Columns[30].Visible = true;

                gridPlan.Columns[31].Visible = true;
                gridPlan.Columns[32].Visible = true;
                gridPlan.Columns[33].Visible = true;
            }
            filtrarGridPlan();
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int anio, idUnidad, idPoa = 0;
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);
                int.TryParse(lblIdPoa.Text, out idPoa);

                if (anio == 0)
                    throw new Exception("Seleccione un año!");

                if (idUnidad == 0)
                    throw new Exception("Seleccione una unidad!");

                if (idPoa == 0)
                    throw new Exception("Seleccione un CMI!");

                txtObser.Text = string.Empty;
                cambiarEstado(9, "APROBADA");
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
                int anio, idUnidad, idPoa = 0;
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);
                int.TryParse(lblIdPoa.Text, out idPoa);

                if (anio == 0)
                    throw new Exception("Seleccione un año!");

                if (idUnidad == 0)
                    throw new Exception("Seleccione una unidad!");

                if (idPoa == 0)
                    throw new Exception("Seleccione un CMI!");

                string s = txtObser.Text;
                s = s.Replace('\'', ' ');
                s = s.Trim();
                txtObser.Text = s;

                if (txtObser.Text.Equals(string.Empty))
                    lblError.Text = "Llene el campo de observaciones.";
                else
                    cambiarEstado(8, "RECHAZADA");
            }
            catch (Exception ex)
            {
                lblError.Text = "btnRechazar(). " + ex.Message;
            }
        }

        protected void cambiarEstado(int idEstado, string nombreEstado)
        {
            try
            {
                if (ddlAnios.SelectedValue == "0")
                    throw new Exception("Seleccione año!");

                if (ddlUnidades.SelectedValue == "0")
                    throw new Exception("Seleccione unidad!");

                int idPoa = int.Parse(lblIdPoa.Text);

                planOperativoLN = new PlanOperativoLN();
                int anio = int.Parse(ddlAnios.SelectedValue);
                string usuario = Session["usuario"].ToString();
                string observaciones = txtObser.Text;
                DataSet dsResultado = planOperativoLN.ActualizarEstadoPoa(int.Parse(lblIdPoa.Text), idEstado, anio, null, "", usuario, observaciones);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se INSERTÓ/ACTUALIZÓ la planificación: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                lblSuccess.Text = "Planificación " + nombreEstado + " exitosamente!";
                lblError.Text = string.Empty;

                btnAprobar.Visible = btnRechazar.Visible = false;

            }
            catch (Exception ex)
            {
                lblError.Text = "cambiarEstado(). " + ex.Message;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                filtrarGridPlan();
                generarReporte();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnActualizar_Click(). " + ex.Message;
            }
        }

		
		protected void gridPlan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    int idAccion = 0;

                    int.TryParse(gridPlan.DataKeys[e.Row.RowIndex].Values[1].ToString(), out idAccion);
                    GridView gridDetalles = (GridView)(e.Row.FindControl("gridRenglon"));

                    planAccionLN = new PlanAccionLN();
                    planAccionLN.GridDetallesAccion(gridDetalles, idAccion, 1);

                    if (gridDetalles.Rows.Count > 0)
                    {
                        DataSet dsResultado = planAccionLN.InformacionAccionDetalles(idAccion, 0, "", 1);

                        decimal monto, codificado, saldo;
                        decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Compute("SUM(MONTO)", "").ToString(), out monto);
                        decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Compute("SUM(CODIFICADO)", "").ToString(), out codificado);
                        decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Compute("SUM(SALDO)", "").ToString(), out saldo);

                        gridDetalles.FooterRow.Cells[1].Text = "TOTALES";
                        gridDetalles.FooterRow.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", monto);
                        gridDetalles.FooterRow.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", codificado);
                        gridDetalles.FooterRow.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);

                        gridDetalles.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                        gridDetalles.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                        gridDetalles.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("gridPlan_RowDataBound1(). " + ex.Message);
            }
        }
    }
}
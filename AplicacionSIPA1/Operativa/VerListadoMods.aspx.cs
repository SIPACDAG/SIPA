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

namespace AplicacionSIPA1.Operativa
{
    public partial class VerListadoMods : System.Web.UI.Page
    {
        private PlanEstrategicoLN planEstrategicoLN;
        private PlanOperativoLN planOperativoLN;
        private PlanAccionLN planAccionLN;
        private ReportesLN reporte;
        string Last = string.Empty;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
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
                    int anioActual = (DateTime.Now.Year + 1);

                    planEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                    ListItem item = ddlAnios.Items.FindByValue(anioActual.ToString());
                    if (item != null)
                        ddlAnios.SelectedValue = anioActual.ToString();

                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlUnidades(ddlUnidades, Session["Usuario"].ToString().ToLower());

                    planAccionLN = new PlanAccionLN();
                    planAccionLN.DdlAccionesPoa(ddlAcciones, 0);
                    ddlAcciones.Items[0].Text = "<< Mostrar todo >>";
                       
                    if (ddlUnidades.Items.Count == 1)
                    {
                        if (!ddlAnios.SelectedValue.Equals("0"))
                        {
                            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                        }
                    }

                    int idPoa = 0;
                    int.TryParse(lblIdPoa.Text, out idPoa);
                    planAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                    ddlAcciones.Items[0].Text = "<< Mostrar todo >>";

                    filtrarGrid();
                    generarReporte();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void filtrarGrid()
        {
            try
            {
                gridReportes.DataSource = null;
                gridReportes.DataBind();
                gridReportes.SelectedIndex = -1;
                DataSet dsResultado = new DataSet();

                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();


                if (ddlAnios.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND t.anio = " + ddlAnios.SelectedValue);

                if (ddlUnidades.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND t.id_unidad = " + ddlUnidades.SelectedValue);
                else
                {
                    stringBuilder.Append(" AND t.id_unidad IN(");

                    int cantidad = (ddlUnidades.Items.Count - 1);

                    for (int i = 1; i <= cantidad; i++)
                    {
                        stringBuilder.Append(ddlUnidades.Items[i].Value.ToString());

                        if (i < cantidad)
                            stringBuilder.Append(", ");
                    }

                    stringBuilder.Append(")");
                }

                if (ddlAcciones.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND t.id_accion = " + ddlAcciones.SelectedValue);

                planAccionLN = new PlanAccionLN();
                dsResultado = planAccionLN.InformacionAccionDetalles(0, 0, stringBuilder.ToString(), 8);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                {
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id_detalle");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("anio");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id_unidad");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id_accion");

                    gridReportes.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridReportes.DataBind();

                    //lblStringBuilder.Text = stringBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGrid(). " + ex.Message);
            }
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                filtrarGrid();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                int anio = int.Parse(ddlAnios.SelectedValue);
                int idUnidad = int.Parse(ddlUnidades.SelectedValue);

                lblTechoD.Text = lblTechoU.Text = lblDisponibleD.Text = lblDisponibleU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);

                if (anio > 0 && idUnidad > 0)
                    validarPoa(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);
                planAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Mostrar todo >>";

                filtrarGrid();
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

                filtrarGrid();
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
                    lblErrorPoa.Text = lblError.Text = string.Empty;

                    btnActualizar.Visible = true;

                    poaValido = true;
                }
                //2	Revisión Subgerencia, 4	Revisión Analista POA, 7	Revisión Dirección
                else if (estadoPoa.Equals("2") || estadoPoa.Equals("4") || estadoPoa.Equals("7"))
                {
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + lblEstadoPoa.Text + " y no se puede modificar";
                    
                    btnActualizar.Visible = false;
                }
                //3	Rechazado Subgerencia, 6	Rechazado Analista POA, 8	Rechazado Dirección, 
                else if (estadoPoa.Equals("3") || estadoPoa.Equals("6") || estadoPoa.Equals("8"))
                {
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + lblEstadoPoa.Text + ", por: " + observaciones + " y no se puede modificar";

                    btnActualizar.Visible = true;

                    poaValido = true;
                }
                //9	Aprobado Dirección
                else if (estadoPoa.Equals("9"))
                {
                    lblErrorPoa.Text = lblError.Text = string.Empty;

                    btnActualizar.Visible = true;
                }
                else
                {
                    lblErrorPoa.Text = lblError.Text = "Estado desconocido: " + estadoPoa + ", por favor consulte con el administrador del sistema";

                    btnActualizar.Visible = true;
                }

                //btnEnviar.Visible = txtObser.Visible = lblObservaciones.Visible = true;
                obtenerPresupuesto(idPoa, 0);              
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
                DataSet dsPpto = planAccionLN.PptoPoa(idPoa);

                decimal pptoPoaUnidad = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["TECHO"].ToString());
                decimal pptoDisponibleUnidad = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE"].ToString());
                decimal pptoPoaDependencia = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["TECHO"].ToString());
                decimal pptoDisponibleDep = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE"].ToString());


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
                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                
                validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                filtrarGrid();
                generarReporte();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnActualizar_Click(). " + ex.Message;
            }
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

                idPoa = 0;
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
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnVerReporte(). " + ex.Message;
            }
        }
    }
}
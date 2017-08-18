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
using ExportToExcel;


namespace AplicacionSIPA1.ReporteriaSistema
{
    public partial class SaldosRenglones : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        
        private PedidosLN pInsumoLN;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {

                    NuevoEncabezadoPoa();                    
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


                string criterio = "AND c.id_tipo IN(48) AND a.usuario = ''" + usuario + "''";
                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPermisos(0, 0, criterio, 12);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                    pOperativoLN.DdlUnidades(ddlUnidades);
                else
                    pOperativoLN.DdlUnidades(ddlUnidades, usuario);               

                if (ddlUnidades.Items.Count == 1)
                {
                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                        
                    }
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                obtenerPresupuesto(idPoa, 0);
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, 0, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< TODAS >>";

                filtrarGrid();
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoPoa(). " + ex.Message);
            }
        }


        protected bool validarPoa(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                pOperativoLN = new PlanOperativoLN();
                DataSet dsPoa = pOperativoLN.DatosPoaUnidad(idUnidad, anio);

                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                int idPoa = 0;
                int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
                lblIdPoa.Text = idPoa.ToString();
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            return poaValido;
        }

        protected void filtrarGrid()
        {
            try
            {
                gridReportes.DataSource = null;
                gridReportes.DataBind();
                gridReportes.SelectedIndex = -1;

                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();


                if (ddlAnios.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND a.anio = " + ddlAnios.SelectedValue);

                if (ddlUnidades.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND a.id_unidad = " + ddlUnidades.SelectedValue);
                else
                {
                    stringBuilder.Append(" AND a.id_unidad IN(");

                    int cantidad = (ddlUnidades.Items.Count - 1);

                    for (int i = 1; i <= cantidad; i++)
                    {
                        stringBuilder.Append(ddlUnidades.Items[i].Value.ToString());

                        if(i < cantidad)
                            stringBuilder.Append(", ");
                    }

                    stringBuilder.Append(")");
                }

                if (ddlAcciones.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND b.id_accion = " + ddlAcciones.SelectedValue);

                int idUnidad = 0;
                int idPoa = 0;

                int.TryParse(lblIdPoa.Text, out idPoa);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                pAccionLN = new PlanAccionLN();
                DataSet dsResultado = pAccionLN.InformacionAccionDetalles(0, 0, stringBuilder.ToString(), 3);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                lblStringBuilder.Text = stringBuilder.ToString();

                gridReportes.DataSource = dsResultado.Tables["BUSQUEDA"];
                gridReportes.DataBind();

                if (gridReportes.Rows.Count > 0)
                {
                    decimal monto, codificado, saldo;
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Compute("SUM(MONTOPOA)", "").ToString(), out monto);
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Compute("SUM(CODIFICADO)", "").ToString(), out codificado);
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Compute("SUM(SALDO)", "").ToString(), out saldo);

                    gridReportes.FooterRow.Cells[1].Text = "TOTALES";
                    gridReportes.FooterRow.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", monto);
                    gridReportes.FooterRow.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", codificado);
                    gridReportes.FooterRow.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);

                    gridReportes.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    gridReportes.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    gridReportes.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGrid(). " + ex.Message);
            }
        }

        protected void busqueda(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = lblErrorPoa.Text = string.Empty;           
                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "busqueda(). " + ex.Message;
            }
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridReportes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;

                    decimal valor = decimal.Parse(e.Row.Cells[2].Text);
                    e.Row.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);

                    valor = decimal.Parse(e.Row.Cells[3].Text);
                    e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);

                    valor = decimal.Parse(e.Row.Cells[4].Text);
                    e.Row.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);
                }                
            }
            catch (Exception ex)
            {
                lblError.Text = "gridReportes_RowDataBound(). " + ex.Message;
            }

        }

        protected void gridReportes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                obtenerPresupuesto(idPoa, 0);
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< TODAS >>";

                busqueda(sender, e);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios(). " + ex.Message;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {

                pAccionLN = new PlanAccionLN();
                DataSet dsResultado = pAccionLN.InformacionAccionDetalles(0, 0, lblStringBuilder.Text, 3);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                string nombreArchivo = "SaldosReglones" + DateTime.Now.ToShortDateString() + ".xlsx";
                bool b = CreateExcelFile.CreateExcelDocument(dsResultado.Tables["BUSQUEDA"].Copy(), nombreArchivo, Response);                

            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo(). " + ex.Message;
            }

        }

        protected void obtenerPresupuesto(int idPoa, int idDependencia)
        {
            try
            {
                pAccionLN = new PlanAccionLN();
                DataSet dsPpto = pAccionLN.PptoPoa(idPoa, 0);

                decimal pptoPoaUnidad = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["PPTO_POA_UNIDAD"].ToString());
                decimal pptoDisponibleUnidad = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE_UNIDAD"].ToString());
                decimal pptoPoaDependencia = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["PPTO_POA_DEPENDENCIA"].ToString());
                decimal pptoDisponibleDep = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE_DEPENDENCIA"].ToString());


                lblTechoU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoPoaUnidad);
                lblDisponibleU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoDisponibleUnidad);
            }
            catch (Exception ex)
            {
                throw new Exception("obtenerPresupuesto(). " + ex.Message);
            }
        }
    }
}
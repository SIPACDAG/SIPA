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

namespace AplicacionSIPA1.Presupuesto
{
    public partial class ListadoModTechos : System.Web.UI.Page
    {
        private PlanEstrategicoLN planEstrategicoLN;
        private PlanOperativoLN planOperativoLN;

        private PlanAccionLN planAccionLN;

        private PresupuestoEN pptoEN;
        private PresupuestoLN pptoLN;
        private FuncionesVarias funcionesVarias;

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
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                upBuscar.Visible = false;
                upModificar.Visible = true;

                lblIdPoa.Text = "0";
                lblIdModificacion.Text = "0";
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

                int anioActual = DateTime.Now.Year;
                ListItem item = ddlAnios.Items.FindByValue(anioActual.ToString());
                if (item != null)
                    ddlAnios.SelectedValue = Convert.ToString(Request.QueryString["Anio"]);

                UsuariosLN userLN = new UsuariosLN();
                userLN.dropUnidad(ddlUnidades);

                ddlUnidades.SelectedValue = Convert.ToString(Request.QueryString["unidad"]);
                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo_Click()" + ex.Message;
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

                btnNuevo_Click(sender, e);
                ddlPlanes.SelectedValue = idPlan.ToString();
                ddlPlanes_SelectedIndexChanged(sender, e);

                ddlAnios.SelectedValue = anio.ToString();
                ddlUnidades.SelectedValue = idUnidad.ToString();

                filtrarGrid();

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

                btnNuevo_Click(sender, e);
                ddlPlanes.SelectedValue = idPlan.ToString();
                ddlPlanes_SelectedIndexChanged(sender, e);

                ddlAnios.SelectedValue = anio.ToString();
                ddlUnidades.SelectedValue = idUnidad.ToString();

                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void limpiarControlesError()
        {
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;
        }

        protected void ddlFuentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
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

        protected void filtrarGrid()
        {
            try
            {
                gridReportes.DataSource = null;
                gridReportes.DataBind();
                gridReportes.SelectedIndex = -1;

                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();


                if (ddlAnios.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND mt.anio = " + ddlAnios.SelectedValue);

                if (ddlUnidades.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND mt.id_unidad = " + ddlUnidades.SelectedValue);
                else
                {
                    stringBuilder.Append(" AND mt.id_unidad IN(");

                    int cantidad = (ddlUnidades.Items.Count - 1);

                    for (int i = 1; i <= cantidad; i++)
                    {
                        stringBuilder.Append(ddlUnidades.Items[i].Value.ToString());

                        if (i < cantidad)
                            stringBuilder.Append(", ");
                    }

                    stringBuilder.Append(")");
                }

                int idUnidad = 0;
                int idPoa = 0;

                int.TryParse(lblIdPoa.Text, out idPoa);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                pptoLN = new PresupuestoLN();
                DataSet dsResultado = pptoLN.InformacionTechosPpto(0, 0, stringBuilder.ToString(), 1);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                lblStringBuilder.Text = stringBuilder.ToString();

                gridReportes.DataSource = dsResultado.Tables["BUSQUEDA"];
                gridReportes.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGrid(). " + ex.Message);
            }
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
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;

                    decimal valor = decimal.Parse(e.Row.Cells[2].Text);
                    e.Row.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);

                    valor = decimal.Parse(e.Row.Cells[3].Text);
                    e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);

                    valor = decimal.Parse(e.Row.Cells[4].Text);
                    e.Row.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);

                    valor = decimal.Parse(e.Row.Cells[5].Text);
                    e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);
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
    }
}
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
    public partial class AsignarAnalista : System.Web.UI.Page
    {
        private PlanEstrategicoLN planEstrategicoLN;
        private PlanOperativoLN planOperativoLN;
        private PlanAccionLN planAccionLN;
        private UsuariosLN usuariosLN;
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
                    planEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                    int anioActual = (DateTime.Now.Year + 1);

                    ListItem item = ddlAnios.Items.FindByValue(anioActual.ToString());
                    if (item != null)
                        ddlAnios.SelectedValue = anioActual.ToString();

                    usuariosLN = new UsuariosLN();
                    usuariosLN.dropAnalistas(ddlAnalistas);
                    usuariosLN.dropUnidad(ddlUnidades);
                    
                    filtrarGridPlanes();
                    //filtrarGridAsignados();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void filtrarGridPlanes()
        {
            string id_unidad = "";
            if (ddlJefaturaUnidad.SelectedValue != "" && int.Parse(ddlJefaturaUnidad.SelectedValue) > 0)
            {
                id_unidad = ddlJefaturaUnidad.SelectedValue;
            }
            else if (ddlDependencia.SelectedValue != "" && int.Parse(ddlDependencia.SelectedValue) > 0)
            {
                id_unidad =ddlDependencia.SelectedValue;
            }
            else
            {
                id_unidad = ddlUnidades.SelectedValue;
            }
            gridPlanes.DataSource = null;
            gridPlanes.DataBind();

            planAccionLN = new PlanAccionLN();
            planAccionLN.GridPlanesResumen(gridPlanes, 1);

            string filtro = string.Empty;

            object obj = gridPlanes.DataSource;
            System.Data.DataTable tbl = gridPlanes.DataSource as System.Data.DataTable;
            System.Data.DataView dv = tbl.DefaultView;

            filtro = " anio = " + ddlAnios.SelectedValue;
            filtro += " AND id_usuario = -1";

            if (!ddlUnidades.SelectedValue.Equals("0"))
                filtro += " AND id_unidad = " +id_unidad;

            dv.RowFilter = filtro;

            gridPlanes.DataSource = dv;
            gridPlanes.DataBind();

        }

        protected void filtrarGridAsignados()
        {
            gridAsignaciones.DataSource = null;
            gridAsignaciones.DataBind();
            planAccionLN = new PlanAccionLN();
            planAccionLN.GridPlanesResumen(gridAsignaciones, 2);

            string filtro = string.Empty;

            object obj = gridAsignaciones.DataSource;
            System.Data.DataTable tbl = gridAsignaciones.DataSource as System.Data.DataTable;
            System.Data.DataView dv = tbl.DefaultView;

            filtro = " anio = " + ddlAnios.SelectedValue;
            filtro = " id_usuario = " + ddlAnalistas.SelectedValue;
            dv.RowFilter = filtro;

            gridAsignaciones.DataSource = dv;
            gridAsignaciones.DataBind();
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idUnidad = int.Parse(ddlUnidades.SelectedValue);
                string id_unidad = ddlUnidades.SelectedItem.Value;
                if (idUnidad > 0)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlDependencias(ddlDependencia, id_unidad);
                }
                limpiarControlesError();
                filtrarGridPlanes();
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
                filtrarGridPlanes();
                filtrarGridAsignados();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected bool cambiarEstado(int idPoa, int idEstado, int anio, string idUsuario, string usuarioAsignado, string usuarioIng, string accion)
        {
            bool resultado = false;
            try
            {
                FuncionesVarias fv = new FuncionesVarias();
                string[] ip = fv.DatosUsuarios();
                planOperativoLN = new PlanOperativoLN();
                DataSet dsResultado = planOperativoLN.ActualizarEstadoPoa(idPoa, idEstado, anio, idUsuario, usuarioAsignado, usuarioIng, "", ip[0], ip[1], ip[2], "Asignar Analista", "Asignar");

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se INSERTÓ/ACTUALIZÓ la planificación: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                resultado = true;
            }
            catch (Exception ex)
            {
                lblError.Text = "cambiarEstado(). " + ex.Message;
            }
            return resultado;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void btnVerReporte_Click(object sender, EventArgs e)
        {

        }

        protected void gridPlanes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                limpiarControlesError();

                gridPlanes.PageIndex = e.NewPageIndex;
                filtrarGridPlanes();
            }
            catch (Exception ex)
            {
                lblError.Text = "gridPlanes_PageIndexChanging(). " + ex.Message;
            }
        }

        protected void gridPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                if (ddlAnalistas.SelectedValue == "0" || ddlAnalistas.Items.Count < 1)
                    throw new Exception("Seleccione un analista");

                bool alMenos1 = false;
                foreach (GridViewRow row in gridPlanes.Rows)
                {
                    CheckBox cb = (CheckBox)row.FindControl("chkPlan");
                    if (cb != null && cb.Checked)
                        alMenos1 = true;
                }

                if (alMenos1)
                    foreach (GridViewRow row in gridPlanes.Rows)
                    {
                        CheckBox cb = (CheckBox)row.FindControl("chkPlan");
                        if (cb != null && cb.Checked)
                        {
                            int idUsuario = int.Parse(ddlAnalistas.SelectedValue);
                            string usuarioAsignado = ddlAnalistas.SelectedItem.Text;
                            int idPoa = int.Parse(gridPlanes.DataKeys[row.RowIndex].Value.ToString());
                            int anio = int.Parse(gridPlanes.DataKeys[row.RowIndex].Values[1].ToString());
                            int idUnidad = int.Parse(gridPlanes.DataKeys[row.RowIndex].Values[2].ToString());

                            cambiarEstado(idPoa, 4, anio, idUsuario.ToString(), usuarioAsignado, Session["usuario"].ToString(), "ASIGNADO");
                            filtrarGridPlanes();
                            filtrarGridAsignados();
                        }
                    }

            }
            catch (Exception ex)
            {
                lblError.Text = "btnAsignar_Click(). " + ex.Message;
                if (ex.Message != "Seleccione un analista")
                {
                    filtrarGridPlanes();
                    filtrarGridAsignados();
                }
            }
        }

        protected void ddlAnalistas_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
            filtrarGridAsignados();
        }

        protected void gridAsignaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                limpiarControlesError();

                gridAsignaciones.PageIndex = e.NewPageIndex;
                filtrarGridAsignados();
            }
            catch (Exception ex)
            {
                lblError.Text = "gridAsignaciones_PageIndexChanging(). " + ex.Message;
            }
        }

        protected void gridAsignaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idPoa = int.Parse(gridAsignaciones.DataKeys[e.RowIndex].Value.ToString());
                int anio = int.Parse(gridAsignaciones.DataKeys[e.RowIndex].Values[1].ToString());
                int idUnidad = int.Parse(gridAsignaciones.DataKeys[e.RowIndex].Values[2].ToString());

                cambiarEstado(idPoa, 4, anio, null, "", Session["usuario"].ToString(), "ASIGNADO");
                filtrarGridPlanes();
                filtrarGridAsignados();
            }
            catch (Exception ex)
            {
                lblError.Text = "gridAsignaciones_RowDeleting(). " + ex.Message;
            }
        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idUnidad = int.Parse(ddlDependencia.SelectedValue);
                string id_unidad = ddlDependencia.SelectedItem.Value;
                if (idUnidad > 0)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlDependencias(ddlJefaturaUnidad, id_unidad);
                }
                limpiarControlesError();
                filtrarGridPlanes();
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
                filtrarGridPlanes();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }
    }
}
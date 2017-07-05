using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Pac
{
    public partial class AdminListadoPlan : System.Web.UI.Page
    {
        private PlanEstrategicoLN planEstrategicoLN;
        private PlanOperativoLN planOperativoLN;

        private PlanAccionLN planAccionLN;
        private PlanAnualLN pAnualLN;

        double totalmp, totalcp, totalsp = 0;
        int contarp;
        public int NoPac
        {
            get
            {
                return Convert.ToInt32(gridPac.SelectedValue);
            }
        }
         protected void Page_LoadComplete(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                Nuevo();
                
            }

        }

         protected void Nuevo()
         {
             try
             {
                 lblError.Text = string.Empty;
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
                     ddlAnios.SelectedValue = anioActual.ToString();

                 planOperativoLN = new PlanOperativoLN();
                 //planOperativoLN.DdlUnidades(ddlUnidades, Session["Usuario"].ToString().ToLower());
                 UsuariosLN userLN = new UsuariosLN();
                 userLN.dropUnidad(ddlUnidades);

                 if (ddlUnidades.Items.Count == 1)
                 {
                     if (!ddlAnios.SelectedValue.Equals("0"))
                     {
                         validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                     }
                 }
                 if (ddlUnidades.Items.Count >= 2)
                 {
                     ddlUnidades.Items[0].Text = "<< TODAS >>";
                 }

                 int idPoa = 0;
                 int.TryParse(lblIdPoa.Text, out idPoa);
                 planAccionLN = new PlanAccionLN();
                 planAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                 planAccionLN.DdlRenglones(ddlRenglones);

                 ddlAcciones.Items[0].Text = "<< TODAS >>";
                 ddlRenglones.Items[0].Text = "<< TODOS >>";

                 gridPac.DataSource = null;
                 gridPac.DataBind();


             }
             catch (Exception ex)
             {
                 lblError.Text = "btnNuevo_Click()" + ex.Message;
             }
         }

         protected bool validarPoa(int idUnidad, int anio)
         {
             bool poaValido = false;
             lblIdPoa.Text = "0";
             try
             {
                 planOperativoLN = new PlanOperativoLN();
                 DataSet dsPoa = planOperativoLN.DatosPoaUnidad(idUnidad, anio);

                 if (dsPoa.Tables.Count == 0)
                     throw new Exception("Error al consultar el presupuesto.");

                 if (dsPoa.Tables[0].Rows.Count == 0)
                     throw new Exception("No existe presupuesto asignado");

                 string estadoPoa = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString();
                 //lblEstadoPoa.Text = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString() + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString();

                 int idPoa = int.Parse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString());
                 lblIdPoa.Text = idPoa.ToString();

                 if (!estadoPoa.Equals("9"))
                     lblErrorPoa.Text = /*lblError.Text =*/ "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString() + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString() + " y no se puede modificar";
                 else
                     btnActualizar.Visible = gridPac.Columns[1].Visible = false;

                 btnActualizar.Visible = gridPac.Columns[1].Visible = true;

                 poaValido = true;
             }
             catch (Exception ex)
             {
                 lblError.Text = lblErrorPoa.Text = "Error: " + ex.Message;
             }
             return poaValido;
         }

         protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
         {
             limpiarControlesError();
         }

         protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
         {
             try
             {
                 limpiarControlesError();
                 filtrarGrid();

                 int idUnidad = 0;
                 int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                 int anio = 0;
                 int.TryParse(ddlAnios.SelectedValue, out anio);

                 validarPoa(idUnidad, anio);

                 int idPoa = 0;
                 int.TryParse(lblIdPoa.Text, out idPoa);

                 planAccionLN = new PlanAccionLN();
                 planAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                 ddlAcciones.Items[0].Text = "<< TODAS >>";
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
                 filtrarGrid();

                 int idUnidad = 0;
                 int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                 int anio = 0;
                 int.TryParse(ddlAnios.SelectedValue, out anio);

                 validarPoa(idUnidad, anio);

                 int idPoa = 0;
                 int.TryParse(lblIdPoa.Text, out idPoa);

                 planAccionLN = new PlanAccionLN();
                 planAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                 ddlAcciones.Items[0].Text = "<< TODAS >>";
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
                 filtrarGrid();
             }
             catch (Exception ex)
             {
                 lblError.Text = "ddlAcciones_SelectedIndexChanged(). " + ex.Message;
             }
             
         }

         protected void ddlRenglones_SelectedIndexChanged(object sender, EventArgs e)
         {
             try
             {
                 filtrarGrid();
             }
             catch (Exception ex)
             {
                 lblError.Text = "ddlAcciones_SelectedIndexChanged(). " + ex.Message;
             }
         }

         protected void gridPac_RowDataBound(object sender, GridViewRowEventArgs e)
         {
             double sumamp = 0, sumacp, sumasp;
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 sumamp = (Convert.ToDouble(e.Row.Cells[6].Text));
                 e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumamp);
                 totalmp += sumamp;
                 sumamp = 0;

                 sumacp = (Convert.ToDouble(e.Row.Cells[7].Text));
                 e.Row.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumacp);
                 totalcp += sumacp;
                 sumacp = 0;

                 sumasp = (Convert.ToDouble(e.Row.Cells[8].Text));
                 e.Row.Cells[8].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumasp);
                 totalsp += sumasp;
                 sumasp = 0;


                 contarp += 1;

             }
             else if (e.Row.RowType == DataControlRowType.Footer)
             {
                 e.Row.Cells[1].Text = "No.";
                 e.Row.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", contarp);
                 e.Row.Cells[5].Text = "Total";
                 e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalmp);
                 e.Row.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalcp);
                 e.Row.Cells[8].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalsp);

             }
         }

         protected void gridPac_SelectedIndexChanged(object sender, EventArgs e)
         {
             btnModificar.Visible = true;
         }

         protected void gridPac_RowDeleting(object sender, GridViewDeleteEventArgs e)
         {
             try
             {
                 int idPac = 0;
                 int.TryParse(gridPac.Rows[e.RowIndex].Cells[2].Text, out idPac);

                 if (idPac != 0)
                 {

                     pAnualLN = new PlanAnualLN();
                     DataSet dsResultado = pAnualLN.EliminarPac(idPac);

                     if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                         throw new Exception("No se ELIMINÓ el PAC: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                     string usuario = Session["usuario"].ToString();
                     pAnualLN.GridListadoPacs(gridPac, usuario);

                     ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + "Eliminacion Exitosa!" + "');", true);
                 }
             }
             catch (Exception ex)
             {
                 ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + ex.Message + "');", true);
             }


         }

         protected void limpiarControlesError()
         {
             lblErrorPoa.Text = lblError.Text = string.Empty;
         }
         protected void filtrarGrid()
         {
             gridPac.DataSource = null;
             gridPac.DataBind();
             gridPac.SelectedIndex = -1;

             string usuario = Session["usuario"].ToString();
             pAnualLN = new PlanAnualLN();
             pAnualLN.GridListadoPacs(gridPac, usuario);

             string filtro = string.Empty;

             object obj = gridPac.DataSource;
             System.Data.DataTable tbl = gridPac.DataSource as System.Data.DataTable;
             System.Data.DataView dv = tbl.DefaultView;

             filtro = " anio = " + ddlAnios.SelectedValue;

             if (!ddlUnidades.SelectedValue.Equals("0"))
                 filtro += " AND id_unidad = " + ddlUnidades.SelectedValue;

             if (!ddlAcciones.SelectedValue.Equals("0"))
                 filtro += " AND noaccion = " + ddlAcciones.SelectedValue;

             if (!ddlRenglones.SelectedValue.Equals("0"))
                 filtro += " AND no_renglon = " + ddlRenglones.SelectedValue;

             dv.RowFilter = filtro;

             totalcp = totalmp = totalsp = 0;
             gridPac.DataSource = dv;
             gridPac.DataBind();
         }


         protected void btnModificar_Click(object sender, EventArgs e)
         {
             Response.Redirect("IngresarPac.aspx?No=" + gridPac.SelectedValue);
         }

         protected void btnActualizar_Click(object sender, EventArgs e)
         {
             limpiarControlesError();
             filtrarGrid();
         }
    }
}
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

namespace AplicacionSIPA1.Reporteria
{
    public partial class SalidasBusqueda : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;

        private PedidosLN pInsumoLN;
        private PedidosEN pInsumoEN;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {

                    NuevoEncabezadoPoa();

                    string s = Convert.ToString(Request.QueryString["No"]);
                    string mostrarBotones = Convert.ToString(Request.QueryString["OptB"]);

                    if (s != null)
                    {
                        int idEncabezado = 0;
                        int.TryParse(s, out idEncabezado);
                        
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


                pOperativoLN.DdlUnidades(ddlUnidades);
                ddlUnidades.Items[0].Text = "<< TODAS >>";

                if (ddlUnidades.Items.Count == 1)
                {
                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                    }
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< TODAS >>";
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
                gridDet.DataSource = null;
                gridDet.DataBind();
                gridDet.SelectedIndex = -1;

                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                
                
                if (ddlAnios.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);

                if (ddlUnidades.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND id_unidad = " + ddlUnidades.SelectedValue);

                if(rblTipoDocto.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND id_tipo_documento = " + rblTipoDocto.SelectedValue);

                if (rblEstados.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND id_estado_pedido = " + rblEstados.SelectedValue);

                if(txtNo.Text.Equals("") == false)
                    stringBuilder.Append(" AND no_solicitud = " + txtNo.Text);

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPedido(0, 0, 0, stringBuilder.ToString(), 14);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridDet.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridDet.DataBind();
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

        protected DataTable armarDtDetalles()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_ESPECIFICACION_DETALLE", Type.GetType("System.String"));
            dt.Columns.Add("ID_ESPECIFICACION", Type.GetType("System.String"));
            dt.Columns.Add("ID_PEDIDO_DETALLE", Type.GetType("System.String"));
            dt.Columns.Add("DESCRIPCION_ESPECIFICA", Type.GetType("System.String"));
            dt.Columns.Add("USUARIO", Type.GetType("System.String"));

            return dt;
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
    }
}
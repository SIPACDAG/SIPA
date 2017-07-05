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

namespace AplicacionSIPA1.Estrategia
{
    public partial class PlanesEstrategicosB : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    nuevaBusqueda();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void nuevaBusqueda()
        {
            try
            {
                limpiarControlesError();
                filtrarGridDetalles(0);
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo(). " + ex.Message;
            }
        }

        protected void filtrarGridDetalles(int id)
        {
            try
            {
                gridDet.DataSource = null;
                gridDet.DataBind();
                gridDet.SelectedIndex = -1;

                pEstrategicoLN = new PlanEstrategicoLN();
                DataSet dsResultado = pEstrategicoLN.InformacionPlanEstrategico(id, 0, "", 1);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_PLAN"].ToString() != "")
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



        protected void limpiarControlesError()
        {
            lblError.Text = lblSuccess.Text = string.Empty;
        }

        protected void gridDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idDetalle = 0;
                int.TryParse(gridDet.SelectedValue.ToString(), out idDetalle);

                pEstrategicoLN = new PlanEstrategicoLN();
                DataSet dsResultado = pEstrategicoLN.InformacionPlanEstrategico(idDetalle, 0, "", 1);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());
            }
            catch (Exception ex)
            {
                lblError.Text = "gridDet(). " + ex.Message;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                if (gridDet.SelectedValue == null)
                    throw new Exception("Seleccione un registro!");

                int idEncabezado = 0;
                int.TryParse(gridDet.SelectedValue.ToString(), out idEncabezado);

                if (idEncabezado == 0)
                    throw new Exception("Seleccione un registro!");

                Response.Redirect("PlanesEstrategicos.aspx?No=" + Convert.ToString(idEncabezado));
            }
            catch (Exception ex)
            {
                lblError.Text = "btnConsultar(). " + ex.Message;
            }
        }

    }
}
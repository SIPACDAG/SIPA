using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Estrategia
{
    public partial class EjesEstrategicos : System.Web.UI.Page
    {

        private EjesLN ejeL;
        private EjesEN ejeE;
        private PlanEstrategicoLN pEstrategico;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ejeL = new EjesLN();
                pEstrategico = new PlanEstrategicoLN();
                pEstrategico.DdlPlanes(ddlPlanE);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ejeL = new EjesLN();
            ejeE = new EjesEN();
            
            if (validarControlesInsertar())
            {
                try
                {
                    ejeE.Codigo_Eje = int.Parse(txtCodigo.Text);                   
                    ejeE.Eje_Estrategico = txtEje.Text.Replace('\'', ' ');         
                    ejeE.Id_Eje_Estrategico = 0;
                    ejeE.Id_Plan = int.Parse(ddlPlanE.SelectedValue);

                    System.Data.DataSet dsResultado = ejeL.Insertar(ejeE,Session["usuario"].ToString());

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());
                    else
                    {
                        this.lblSuccess.Visible = true;
                        this.lblSuccess.Text = "El registro fue ingresado correctamente ";
                        //limpiarControlesNuevo();
                        txtCodigo.Text = string.Empty;
                        txtCodigo.Focus();
                        lblError.Text = "";
                        lblError.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error al ingresar el registro. " + ex.Message;
                }
            }
        }


        private bool validarControlesInsertar()
        {
            bool controlesValidos = false;
            lblErrorAnio.Text = string.Empty;

            try
            {
                if (ddlPlanE.SelectedValue.Equals("0") || ddlPlanE.Items.Count == 0)
                    lblErrorAnio.Text = "Seleccione un valor!";

                if (!lblErrorAnio.Text.Equals(string.Empty))
                    return controlesValidos;

                this.Page.Validate("grpDatos");
                controlesValidos = Page.IsValid;
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesInsertar(). " + ex.Message);
            }

            return controlesValidos;
        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControlesNuevo();
        }

        private void limpiarControlesNuevo()
        {
            pEstrategico = new PlanEstrategicoLN();
            pEstrategico.DdlPlanes(ddlPlanE);

            lblID.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtEje.Text = string.Empty;            
            lblError.Text = "";
            lblSuccess.Text = "";

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estrategia/EjesEstrategicosB.aspx");

        }
    }
}
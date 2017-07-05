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
    public partial class CodificarPoa : System.Web.UI.Page
    {
        private PlanEstrategicoLN planEstrategicoLN;
        private PlanOperativoLN planOperativoLN;
        private PlanAccionLN planAccionLN;

        string Last = string.Empty;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    lblIdPoa.Text = Session["idPoa"].ToString();

                    filtrarGridPlan();
                    
                }
                catch (Exception ex)
                {
                    lblError.Text = lblError0.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void filtrarGridPlan()        
        {
            
            gridPlan.DataSource = null;
            gridPlan.DataBind();

            int idPoa = int.Parse(lblIdPoa.Text);
            planOperativoLN = new PlanOperativoLN();
            planOperativoLN.GridCodificacion(gridPlan, idPoa);

            /*System.Data.DataTable tbl = gridPlan.DataSource as System.Data.DataTable;
            System.Data.DataView dv = tbl.DefaultView;
            dv.RowFilter = "codigo_oo < 0";
            gridPlan.DataSource = dv;
            gridPlan.DataBind();

            planOperativoLN.GridCodificacion(gridPlan, idPoa);*/
        }

        protected void limpiarControlesError()
        {
            lblError.Text = lblError0.Text = lblSuccess.Text = lblSuccess0.Text = string.Empty;
        }


        protected bool validarPoa(int idUnidad, int anio)
        {
            bool poaValido = false;
            btnGuardar.Visible = false;
            try
            {
                planOperativoLN = new PlanOperativoLN();
                planOperativoLN.DatosPoaUnidad(idUnidad, anio);

                DataSet dsPoa = planOperativoLN.DatosPoaUnidad(idUnidad, anio);
                
                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                string estadoPoa = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString();

                if (!estadoPoa.Equals("2"))
                    lblErrorPoa.Text = lblError0.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString() + " y no se puede modificar";
                else
                    btnGuardar.Visible = true;

                int idPoa = int.Parse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString());
                lblIdPoa.Text = idPoa.ToString();

                //SE DEJARÁ EN TRUE PREVINIENDO MODIFICACIONES QUE AMERITEN CODIFICAR NUEVAMENTE UN CUADRO DE MANDO INTEGRAL
                btnGuardar.Visible = true;
                poaValido = true;
            }
            catch (Exception ex)
            {
                lblError.Text = lblError0.Text = "Error: " + ex.Message;
                lblIdPoa.Text = "Error: " + ex.Message;
            }
            return poaValido;
        }

        protected void obtenerPresupuesto(int idPoa, int idDependencia)
        {
            try
            {
                planAccionLN = new PlanAccionLN();
                DataSet dsPpto = planAccionLN.PptoDep(idPoa, idDependencia);

                decimal techo = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["TECHO"].ToString());
                decimal asignado = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["ASIGNADO"].ToString());
                decimal disponible = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("obtenerPresupuesto(). " + ex.Message);
            }
        }

        protected void btnVerReporte_Click(object sender, EventArgs e)
        {
            filtrarGridPlan();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                planAccionLN = new PlanAccionLN();
                DataSet dsResultado;
                int filas = gridPlan.Rows.Count;                              

                for (int i = 0; i < gridPlan.Rows.Count; i++)
                {
                    string idOO = gridPlan.DataKeys[i].Values[0].ToString();
                    TextBox codOO = gridPlan.Rows[i].FindControl("txtCodigoOO") as TextBox;
                    
                    string idAc = gridPlan.DataKeys[i].Values[1].ToString();
                    TextBox codAc = gridPlan.Rows[i].FindControl("txtCodigoA") as TextBox;
                    
                    string usuario = Session["usuario"].ToString();

                    Label lblObservaciones = (Label)gridPlan.Rows[i].FindControl("lblObservaciones");
                    Label lblCodigoCompleto = (Label)gridPlan.Rows[i].FindControl("lblCodigoCompleto");

                    if (idAc.Equals(string.Empty) || idAc.Equals(""))
                        idAc = codAc.Text = "-1500";

                    dsResultado = planAccionLN.ActualizarCodigos(idOO, codOO.Text, idAc, codAc.Text, usuario);
                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    {
                        lblObservaciones.Text = "Error: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString();
                    }
                    else
                    {
                        if (!idAc.Equals("-1500"))
                        {
                            lblObservaciones.Text = "Almacenado con éxito";
                            lblCodigoCompleto.Text = ((Label)(gridPlan.Rows[i].FindControl("lblCUnidad"))).Text + ".";
                            lblCodigoCompleto.Text += ((Label)(gridPlan.Rows[i].FindControl("lblCodEE"))).Text + ".";
                            lblCodigoCompleto.Text += ((Label)(gridPlan.Rows[i].FindControl("lblCodOE"))).Text + ".";
                            lblCodigoCompleto.Text += codOO.Text + "." + codAc.Text;
                        }
                        else
                            idAc = codAc.Text = "";
                    }
                }
                lblSuccess.Text = lblSuccess0.Text = "Operación realizada con éxito!";
            }
            catch (Exception ex)
            {
                lblError.Text = lblError0.Text = "btnGuardar_Click(). " + ex.Message;
            }        
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            filtrarGridPlan();
        }


    }
}
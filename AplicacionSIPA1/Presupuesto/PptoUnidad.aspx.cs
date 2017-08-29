using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Presupuesto
{
    public partial class PptoUnidad : System.Web.UI.Page
    {
        private PlanEstrategicoLN planEstrategicoLN = new PlanEstrategicoLN();
        private PlanOperativoLN planOperativoLN;
        PresupuestoLN presupuestoLN;
        PresupuestoEN presupuestoEN;
        double total = 0;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                /*llenarAnio(dropAnio);
                presupuestoLN = new PresupuestoLN();
                presupuestoLN.dropUnidad(dropUnidad);
                presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text));*/
                btnCancelar_Click(sender, e);
            }
        }
        private void llenarAnio(DropDownList drop)
        {
            DateTime hoy;
            int anio, i;
            hoy = DateTime.Now;
            anio = hoy.Year + 1;
            i = 0;
            for (int index = 0; index <= anio - 2016; index++)
            {
                drop.Items.Insert(index, Convert.ToString(anio - index));
                i += 1;
            }
            drop.SelectedIndex = i - 1;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            try
            {
                this.Page.Validate("vacios");
                if (this.Page.IsValid)
                {

                    if (ddlPlanE.SelectedValue.Equals("0") || ddlPlanE.SelectedValue.ToString().Equals(""))
                        throw new Exception("Seleccione plan estratégico institucional. ");
                    
                    if (Convert.ToInt32(ddlUnidad.SelectedValue) > 0)
                    {
                        presupuestoLN = new PresupuestoLN();
                        presupuestoEN = new PresupuestoEN();
                        presupuestoEN.idPlan = int.Parse(ddlPlanE.SelectedValue);
                        if (ddlJefaturasSub.SelectedValue != "" && int.Parse(ddlJefaturasSub.SelectedValue) > 0)
                        {
                            presupuestoEN.idUnidad = Convert.ToInt32(ddlJefaturasSub.SelectedValue);
                        }
                        else if (int.Parse(ddlDependencias.SelectedValue) > 0)
                        {
                            presupuestoEN.idUnidad = Convert.ToInt32(ddlDependencias.SelectedValue);
                        }
                        else
                        {
                            presupuestoEN.idUnidad = Convert.ToInt32(ddlUnidad.SelectedValue);
                        }

                        presupuestoEN.monto = Convert.ToDouble(txtMonto.Text);
                        presupuestoEN.anio = Convert.ToInt32(dropAnio.SelectedItem.Text);
                        presupuestoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                        presupuestoEN.monto_global = txtMontoGlobal.Text;
                        
                        if(presupuestoEN.anio <=2017)
                            throw new Exception(" El año no es correcto. ");

                        if (presupuestoLN.valPresUnidad(presupuestoEN) == 0)
                        {
                            if ((ddlJefaturasSub.SelectedIndex <= 0))
                            {
                                if (ddlDependencias.SelectedIndex <= 0 && txtMontoGlobal.Text!="" && presupuestoEN.monto <= Convert.ToDouble(txtMontoGlobal.Text))
                                {
                                    if (presupuestoLN.InsertarPresUnidad(presupuestoEN, Session["usuario"].ToString()) == 0)
                                    {
                                        txtMonto.Text = String.Empty;
                                        presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text));
                                        txtMontoGlobal.Text = "";
                                        lblError.Text = string.Empty;
                                        lblSuccess.Text = "El registro fue ingresado correctamente ";
                                        //presupuestoLN.InsertarBitacora(Session["usuario"].ToString(),ddlUnidad.SelectedValue,"ip","Asginacion de Presupuesto","N/A",0,Convert.ToDecimal(txtMontoGlobal.Text));
                                    }
                                }
                                else if (ddlDependencias.SelectedIndex > 0)
                                {
                                    if (ddlJefaturasSub.Items.Count <= 1)
                                    {
                                        txtMontoGlobal.Text = txtMonto.Text;
                                        presupuestoEN.monto_global = txtMontoGlobal.Text;
                                    }
                                    if ((presupuestoLN.validarMontoDependecias(presupuestoEN.anio, Convert.ToInt32(ddlUnidad.SelectedValue), 1) + Convert.ToDecimal(presupuestoEN.monto_global)) <=
                                    presupuestoLN.ObtenerMontoGlobal(presupuestoEN.anio, Convert.ToInt32(ddlUnidad.SelectedValue)))
                                    {

                                        if (presupuestoLN.InsertarPresUnidad(presupuestoEN, Session["usuario"].ToString()) == 0)
                                        {
                                            txtMonto.Text = String.Empty;
                                            presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text), Convert.ToInt32(ddlUnidad.SelectedValue));
                                            txtMontoGlobal.Text = "";
                                            lblError.Text = string.Empty;
                                            lblSuccess.Text = "El registro fue ingresado correctamente ";
                                        }
                                    }
                                    else
                                    {
                                        lblError.Text = "El monto supera al presupuesto de la Dependencia";
                                    }
                                }
                                else
                                {
                                    lblError.Text = "El monto supera al presupuesto de la Unidad";
                                }
                            }
                            else if (ddlJefaturasSub.SelectedIndex > 0)
                            {
                                if ((presupuestoLN.validarMontoDependecias(presupuestoEN.anio, Convert.ToInt32(ddlDependencias.SelectedValue), 1) + Convert.ToDecimal(presupuestoEN.monto)) <=
                                presupuestoLN.ObtenerMontoGlobal(presupuestoEN.anio, Convert.ToInt32(ddlDependencias.SelectedValue)))
                                {
                                    presupuestoEN.monto_global = "0";
                                    if (presupuestoLN.InsertarPresUnidad(presupuestoEN, Session["usuario"].ToString()) == 0)
                                    {
                                        txtMonto.Text = String.Empty;
                                        presupuestoLN.gridPresupuestoDep(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text), Convert.ToInt32(ddlDependencias.SelectedValue));
                                        txtMontoGlobal.Text = "";
                                        lblError.Text = string.Empty;
                                        lblSuccess.Text = "El registro fue ingresado correctamente ";
                                    }
                                }
                                else
                                {
                                    lblError.Text = "Monto superior al Monto Global.";
                                }
                            }
                            else
                            {
                                lblError.Text = "Monto superior al Monto Global.";
                            }



                        }
                        else
                        {
                            lblError.Text = "El presupuesto ya fue asignado";
                            lblSuccess.Text = string.Empty;
                        }
                    }
                    else
                    {
                        lblError.Text = "Seleccione una unidad";
                        lblSuccess.Text = string.Empty;
                    }
                }
            }

            catch (Exception ex)
            {
                if (ex.Message== "Input string was not in a correct format.")
                {
                    lblError.Text = "Error al ingresar el registro Monto global no asignado";
                }
                else
                {
                    lblError.Text = "Error al ingresar el registro" + ex.Message;
                    lblSuccess.Text = string.Empty;
                }
               
            }


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            lblMontoGlobal.Visible = false;
            txtMontoGlobal.Visible = false;
            planEstrategicoLN = new PlanEstrategicoLN();
            planEstrategicoLN.DdlPlanes(ddlPlanE);

            int idPlan = 0;
            int anioIni = 0;
            int anioFin = 0;
            if (ddlPlanE.Items.Count == 2)
            {
                ddlPlanE.SelectedIndex = 1;
                idPlan = int.Parse(ddlPlanE.SelectedValue);
                anioIni = int.Parse(ddlPlanE.SelectedItem.Text.Split('-')[0].Trim());
                anioFin = int.Parse(ddlPlanE.SelectedItem.Text.Split('-')[1].Trim());
                ddlPlanE.Visible = false;
            }
            planEstrategicoLN.DdlAniosPlan(dropAnio, anioIni, anioFin);

            txtMonto.Text = String.Empty;
            ddlUnidad.SelectedValue = "0";
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;

            presupuestoLN = new PresupuestoLN();
            presupuestoLN.dropUnidad(ddlUnidad);
            presupuestoLN.dropUnidad(ddlDependencias);
            //presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text));
            //presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text));
        }

        protected void gridPresupuesto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            limpiarControlesError();

            try
            {
                int idPU;
                idPU = Convert.ToInt32(gridPresupuesto.Rows[e.RowIndex].Cells[1].Text);
                if (idPU != 0)
                {
                    presupuestoLN = new PresupuestoLN();
                    presupuestoEN = new PresupuestoEN();
                    presupuestoEN.idPresupuestoUnidad = idPU;
                    if (presupuestoLN.EliminarPresUnidad(presupuestoEN, Session["usuario"].ToString()) == 0)
                    {
                        presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text));
                        lblSuccess.Text = "Registro eliminado correctamente";
                        lblError.Text = string.Empty;
                    }
                    else
                    {
                        lblError.Text = "Error al eliminar el registro";
                        lblSuccess.Text = string.Empty;
                    }
                    btnCancelar_Click(sender, e);
                }
                else
                {
                    lblError.Text = "Seleccione un presupuesto";
                    lblSuccess.Text = string.Empty;
                }
            }

            catch (Exception)
            {
                lblError.Text = "Error al eliminar el registro";
                lblSuccess.Text = string.Empty;
            }

        }

        protected void dropAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
            lblMontoGlobal.Visible = false;
            txtMontoGlobal.Visible = false;
            presupuestoLN = new PresupuestoLN();
            ddlUnidad.SelectedIndex = 0;
            ddlDependencias.SelectedIndex = 0;
            presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text));

        }

        protected void gridPresupuesto_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double suma = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                suma = (Convert.ToDouble(e.Row.Cells[3].Text));
                e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma);
                total += suma;
                suma = 0;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total";
                e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total);
            }
        }



        protected void limpiarControlesError()
        {
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;
        }

        protected void ddlPlanE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPlan = int.Parse(ddlPlanE.SelectedValue);
                btnCancelar_Click(sender, e);

                if (idPlan > 0)
                {
                    ddlPlanE.SelectedValue = idPlan.ToString();
                    int anioIni = int.Parse(ddlPlanE.SelectedItem.Text.Split('-')[0].Trim());
                    int anioFin = int.Parse(ddlPlanE.SelectedItem.Text.Split('-')[1].Trim());

                    planEstrategicoLN = new PlanEstrategicoLN();

                    planEstrategicoLN.DdlAniosPlan(dropAnio, anioIni, anioFin);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlPlanes. " + ex.Message;
            }
        }

        protected void gridPresupuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            planOperativoLN = new PlanOperativoLN();
            limpiarControlesError();
            txtMontoGlobal.Text = "";
            txtMontoGlobal.Visible = true;
            lblMontoGlobal.Visible = true;
            try
            {

                string id_unidad = ddlDependencias.SelectedItem.Value;
                int idUnidad = int.Parse(ddlDependencias.SelectedValue);
                int idunidadTemp = int.Parse(ddlUnidad.SelectedValue);
                if (idUnidad > 0)
                {
                    if (idUnidad != idunidadTemp)
                    {
                        planOperativoLN.DdlDependencias(ddlJefaturasSub, id_unidad);
                        ddlDependencias.SelectedValue = idUnidad.ToString();
                    }

                    presupuestoLN = new PresupuestoLN();
                    presupuestoLN.gridPresupuestoDep(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text), idUnidad);
                    decimal Monto = presupuestoLN.ObtenerMontoGlobal(Convert.ToInt32(dropAnio.SelectedValue), idUnidad);
                    lblMontoGlobalUni.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", Monto);
                    if (ddlJefaturasSub.Items.Count <= 1)
                    {
                        txtMontoGlobal.Visible = false;
                        lblMontoGlobal.Visible = false;
                    }

                }
                else if (idUnidad == 0)
                {
                    presupuestoLN = new PresupuestoLN();
                    presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text), Convert.ToInt32(ddlUnidad.SelectedValue));
                    decimal Monto = presupuestoLN.ObtenerMontoGlobal(Convert.ToInt32(dropAnio.SelectedValue), Convert.ToInt32(ddlUnidad.SelectedValue));
                    lblMontoGlobalUni.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", Monto);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
                throw;
            }

            txtMonto.Focus();
        }

        protected void ddlUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            planOperativoLN = new PlanOperativoLN();
            limpiarControlesError();
            txtMontoGlobal.Text = "";
            lblMontoGlobal.Visible = true;
            txtMontoGlobal.Visible = true;
            decimal Monto = 0;
            try
            {

                string id_unidad = ddlUnidad.SelectedItem.Value;
                int idUnidad = int.Parse(ddlUnidad.SelectedValue);
                if (idUnidad > 0)
                {


                    planOperativoLN.DdlDependencias(ddlDependencias, id_unidad);

                    ddlUnidad.SelectedValue = idUnidad.ToString();
                    presupuestoLN = new PresupuestoLN();
                    presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text), idUnidad);

                    Monto = presupuestoLN.ObtenerMontoGlobal(Convert.ToInt32(dropAnio.SelectedValue), Convert.ToInt32(ddlUnidad.SelectedValue));
                    lblMontoGlobalUni.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", Monto);
                    if (ddlJefaturasSub.SelectedIndex >= 0)
                    {
                        ddlJefaturasSub.SelectedIndex = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
                throw;
            }


        }

        protected void ddlJefaturasSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            planOperativoLN = new PlanOperativoLN();
            limpiarControlesError();
            txtMontoGlobal.Text = "";
            txtMontoGlobal.Visible = false;
            lblMontoGlobal.Visible = false;
            try
            {

                string id_unidad = ddlDependencias.SelectedItem.Value;
                int idUnidad = int.Parse(ddlJefaturasSub.SelectedValue);
                int idunidadTemp = int.Parse(ddlDependencias.SelectedValue);
                if (idUnidad > 0)
                {


                    presupuestoLN = new PresupuestoLN();
                    presupuestoLN.gridPresupuestoDep(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text), idUnidad);
                    decimal Monto = presupuestoLN.ObtenerMontoGlobal(Convert.ToInt32(dropAnio.SelectedValue), idunidadTemp);
                    lblMontoGlobalUni.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", Monto);


                }
                else if (idUnidad == 0)
                {
                    presupuestoLN = new PresupuestoLN();
                    presupuestoLN.gridPresupuestoDep(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text), Convert.ToInt32(ddlDependencias.SelectedValue));
                    decimal Monto = presupuestoLN.ObtenerMontoGlobal(Convert.ToInt32(dropAnio.SelectedValue), Convert.ToInt32(ddlDependencias.SelectedValue));
                    lblMontoGlobalUni.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", Monto);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
                throw;
            }

            txtMonto.Focus();



        }
    }
}
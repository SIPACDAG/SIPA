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
    public partial class AdminTechos : System.Web.UI.Page
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
                lblEncabezado.Text = string.Empty;
                lblEstadoPoa.Text = string.Empty;
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

                UsuariosLN userLN = new UsuariosLN();
                userLN.dropUnidad(ddlUnidades);
                ddlUnidades.Items.RemoveAt(0);

                if (!ddlUnidades.SelectedValue.Equals("0"))
                {

                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue), 2);
                    }
                }

                txtNuevoTecho.Text = "0";
                chkSobreescribir.Checked = false;
                txtJustificacion.Text = string.Empty;
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
                btnGuardar.Visible = false;


                planOperativoLN = new PlanOperativoLN();


                planAccionLN = new PlanAccionLN();

                if (idUnidad > 0)
                {

                    planOperativoLN.DdlDependencias(ddlDependencia, idUnidad.ToString());
                    ddlUnidades.SelectedValue = idUnidad.ToString();

                    if (anio > 0 && idUnidad > 0)
                        validarPoa(idUnidad, anio, 2);
                    if (ddlJefaturaUnidad.SelectedIndex > 0)
                    {
                        ddlJefaturaUnidad.SelectedIndex = 0;
                    }
                }
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

                ddlUnidades.SelectedValue = idUnidad.ToString();
                btnGuardar.Visible = false;

                if (anio > 0)
                {
                    ddlAnios.SelectedValue = anio.ToString();
                    if (anio > 0 && idUnidad > 0)
                        validarPoa(idUnidad, anio, 2);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected decimal obtenerTecho()
        {
            decimal monto = 0;
            return monto;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                pptoEN = new PresupuestoEN();
                pptoLN = new PresupuestoLN();
                funcionesVarias = new FuncionesVarias();

                DataSet dsResultado = new DataSet();

                //INSERTAR/ACTUALIZAR
                if (validarControlesABC())
                {
                    int idModificacion, idPoa, idUnidad, anio = 0;
                    decimal techoAprobado, techoActual, pptoCodificado, pptoPendienteCodificar, nuevoTecho = 0;
                    int sobreescribeTechoAprobado;
                    nuevoTecho = funcionesVarias.StringToDecimal(txtNuevoTecho.Text);



                    int.TryParse(lblIdModificacion.Text, out idModificacion);
                    int.TryParse(lblIdPoa.Text, out idPoa);
                    int.TryParse(ddlUnidades.SelectedValue, out idUnidad);
                    int.TryParse(ddlAnios.SelectedValue, out anio);
                    sobreescribeTechoAprobado = chkSobreescribir.Checked ? 1 : 0;

                    techoAprobado = funcionesVarias.StringToDecimal(lblTechoAprobado.Text);
                    techoActual = funcionesVarias.StringToDecimal(lblTechoActual.Text);
                    pptoCodificado = funcionesVarias.StringToDecimal(lblPptoCodificado.Text);
                    pptoPendienteCodificar = funcionesVarias.StringToDecimal(lblPptoPendiente.Text);


                    pptoEN.id_modificacion = idModificacion.ToString();
                    pptoEN.id_poa = idPoa.ToString();
                    if (ddlJefaturaUnidad.SelectedValue != "" && int.Parse(ddlJefaturaUnidad.SelectedValue) > 0)
                    {
                        pptoEN.id_unidad = ddlJefaturaUnidad.SelectedValue;
                    }
                    else if (ddlJefaturaUnidad.SelectedValue != "" && int.Parse(ddlJefaturaUnidad.SelectedValue) > 0)
                    {
                        pptoEN.id_unidad = ddlDependencia.SelectedValue;
                    }
                    else
                    {
                        pptoEN.id_unidad = ddlUnidades.SelectedValue;
                    }
                    
                    pptoEN.anio_solicitud = anio.ToString();
                    pptoEN.techo_aprobado = techoAprobado.ToString();
                    pptoEN.techo_actual = techoActual.ToString();
                    pptoEN.ppto_codificado = pptoCodificado.ToString();
                    pptoEN.ppto_pendiente_codificar = pptoPendienteCodificar.ToString();
                    pptoEN.nuevo_techo = nuevoTecho.ToString();
                    pptoEN.sobreescribe_techo_aprobado = sobreescribeTechoAprobado.ToString();
                    pptoEN.justificacion = txtJustificacion.Text;
                    pptoEN.usuario = Session["USUARIO"].ToString();

                    if (ddlJefaturaUnidad.SelectedIndex<=0 && ddlDependencia.SelectedIndex <=0 )
                    {
                        if (pptoLN.validarMontoDependecias(anio, idUnidad,2) <= nuevoTecho)
                        {
                            if (anio <= 2017)
                            {
                                dsResultado = pptoLN.AlmacenarModificacionTechoPpto(pptoEN, Session["usuario"].ToString(), 1);
                                dsResultado = pptoLN.AlmacenarModificacionTechoPpto(pptoEN, Session["usuario"].ToString(), 2);
                            }
                            else
                            {
                                dsResultado = pptoLN.AlmacenarModificacionTechoPpto(pptoEN, Session["usuario"].ToString(), 2);
                            }
                            
                        }
                        else
                        {
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ el techo: El nuevo techo es menor a la suma de las dependencias");
                        }

                    }
                    else if (ddlDependencia.SelectedIndex>0)
                    {

                        if (ddlDependencia.SelectedValue ==  ddlUnidades.SelectedValue)
                        {
                            if (pptoLN.validarMontoDependecias(anio,idUnidad,2) + nuevoTecho <= pptoLN.ObtenerMontoGlobal(anio,idUnidad))
                            {
                                dsResultado = pptoLN.AlmacenarModificacionTechoPpto(pptoEN, Session["usuario"].ToString(), 1);
                            }
                            else
                            {
                                throw new Exception("No se INSERTÓ/ACTUALIZÓ el techo: El techo es supera al monto global");
                            }
                        }
                        else
                        {
                            if (((pptoLN.validarMontoDependecias(anio, Int32.Parse(ddlUnidades.SelectedValue),2) + nuevoTecho - techoActual) <= pptoLN.ObtenerMontoGlobal(anio, idUnidad))&&
                                (pptoLN.validarMontoDependecias(anio, Convert.ToInt32(pptoEN.id_unidad), 1)<=nuevoTecho))
                            {

                                dsResultado = pptoLN.AlmacenarModificacionTechoPpto(pptoEN, Session["usuario"].ToString(), 2);
                            }
                            else
                            {
                                throw new Exception("No se INSERTÓ/ACTUALIZÓ el techo: El techo es supera al monto global/Es menor a sus dependencias");
                            }
                        }
                    }
                    else
                    {
                      
                        if ((pptoLN.validarMontoDependecias(anio, idUnidad,2) + nuevoTecho <= pptoLN.ObtenerMontoGlobal(anio, idUnidad)))
                        {
                            dsResultado = pptoLN.AlmacenarModificacionTechoPpto(pptoEN, Session["usuario"].ToString(), 2);
                        }
                        else
                        {
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ el techo: El techo es supera al monto global");
                        }
                    }
                   
                   

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ el pedido: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                    int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idModificacion);
                    lblIdModificacion.Text = "0";

                    obtenerPresupuesto(2);
                    txtNuevoTecho.Text = "";
                    lblSuccess.Text = "Solicitud No. " + idModificacion + " ALMACENADA/MODIFICADA exitosamente: ";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + lblSuccess.Text + "');", true);
                }
            }
            catch (Exception ex)
            {
                string mensaje = "Error al operar el registro. " + ex.Message;
                lblError.Text = mensaje;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
            }
        }

        protected void limpiarControlesError()
        {
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;

            lblEAnio.Text = string.Empty;
            lblEUnidad.Text = string.Empty;
            lblENuevoTecho.Text = string.Empty;
            lblEJustificacion.Text = string.Empty;
        }

        private bool validarControlesABC()
        {
            limpiarControlesError();
            bool controlesValidos = false;

            try
            {
                if (ddlAnios.SelectedValue.Equals("0") || ddlAnios.Items.Count == 0)
                {
                    lblEAnio.Text = "*";
                    lblError.Text += "Seleccione un Año!. ";
                }

                if (ddlUnidades.SelectedValue.Equals("0") || ddlUnidades.Items.Count == 0)
                {
                    lblEUnidad.Text = "*";
                    lblError.Text += "Seleccione una Unidad!. ";
                }

                funcionesVarias = new FuncionesVarias();
                decimal nTecho = funcionesVarias.StringToDecimal(txtNuevoTecho.Text);

                if (nTecho <= 0)
                {
                    lblENuevoTecho.Text = "*";
                    lblError.Text += "Ingrese un Nuevo Techo válido!. ";
                }

                if (txtJustificacion.Text.Equals(string.Empty) || txtJustificacion.Text.Equals(""))
                {
                    lblEJustificacion.Text = "*";
                    lblError.Text += "Ingrese una justificación!. ";
                }

                if (lblError.Text.Equals(string.Empty))
                    controlesValidos = true;

                if (controlesValidos && Page.IsValid)
                    controlesValidos = true;
                else
                    controlesValidos = false;

            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }

            return controlesValidos;
        }

        protected bool validarPoa(int idUnidad, int anio, int op)
        {
            lblErrorPoa.Text = lblError.Text = "";
            bool poaValido = false;
            btnGuardar.Visible = false;
            lblIdPoa.Text = "0";
            try
            {
                lblTechoAprobado.Text = lblTechoActual.Text = lblPptoCodificado.Text = lblPptoPendiente.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
                txtNuevoTecho.Text = "0";

                planOperativoLN = new PlanOperativoLN();
                DataSet dsPoa = planOperativoLN.DatosPoaUnidad(idUnidad, anio, "", 1);

                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                string estadoPoa = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString();
                lblEstadoPoa.Text = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString() + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString();

                int idPoa = int.Parse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString());
                lblIdPoa.Text = idPoa.ToString();

                if (!estadoPoa.Equals("9"))
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + lblEstadoPoa.Text + " y no se puede modificar";
                else
                    btnGuardar.Visible = true;

                int idDep = 0;
                int.TryParse("0", out idDep);

                obtenerPresupuesto(op);

                lblEncabezado.Text = string.Empty;
                if (!ddlAnios.SelectedValue.Equals("0") && !ddlUnidades.SelectedValue.Equals("0"))
                    lblEncabezado.Text = "Plan Estratégico " + ddlPlanes.SelectedItem.Text + " " + ddlUnidades.SelectedItem.Text.Split('-')[1] + " (KPI 3er. Nivel)";

                poaValido = true;
            }
            catch (Exception ex)
            {
                lblError.Text = lblErrorPoa.Text = "Error: " + ex.Message;
            }
            return poaValido;
        }

        protected void obtenerPresupuesto(int op)
        {
            try
            {

                string criterio = " AND a.id_poa = " + lblIdPoa.Text;

                planAccionLN = new PlanAccionLN();
                DataSet dsPpto = new DataSet();

                planOperativoLN = new PlanOperativoLN();
               
                if ((ddlDependencia.SelectedValue == ddlUnidades.SelectedValue) || (ddlDependencia.SelectedValue == ddlJefaturaUnidad.SelectedValue))
                {
                    dsPpto = planOperativoLN.DatosPoaUnidad(0, 0, criterio, 3);
                }
                else
                {
                    dsPpto = planOperativoLN.DatosPoaUnidad(0, 0, criterio, op);
                }
                


                decimal techoAprobado = decimal.Parse(dsPpto.Tables[0].Rows[0]["TECHO_APROBADO"].ToString());
                decimal techoActual = decimal.Parse(dsPpto.Tables[0].Rows[0]["TECHO_ACTUAL"].ToString());
                decimal pptoCodificado = decimal.Parse(dsPpto.Tables[0].Rows[0]["PPTO_CODIFICADO"].ToString());
                decimal pptoPendienteCodificar = decimal.Parse(dsPpto.Tables[0].Rows[0]["PPTO_PENDIENTE_CODIFICAR"].ToString());

                lblTechoAprobado.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", techoAprobado);
                lblTechoActual.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", techoActual);
                lblPptoCodificado.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoCodificado);
                lblPptoPendiente.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoPendienteCodificar);
            }
            catch (Exception ex)
            {
                throw new Exception("obtenerPresupuesto(). " + ex.Message);
            }
        }

        protected void btnNuevaB_Click(object sender, EventArgs e)
        {
            string _open = "window.open('VerPlan.aspx', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
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

        protected void btnListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoModTechos.aspx?Anio=" + ddlAnios.SelectedItem.Value + "&unidad=" + ddlUnidades.SelectedItem.Value);

        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                int anio = int.Parse(ddlAnios.SelectedValue);
                int idUnidad = int.Parse(ddlDependencia.SelectedValue);
                int tempUnidad = int.Parse(ddlUnidades.SelectedValue);
               
                ddlPlanes.SelectedValue = idPlan.ToString();

                var nuevoValor = ddlDependencia.SelectedItem;
                ddlAnios.SelectedValue = anio.ToString();
                btnGuardar.Visible = false;


                planOperativoLN = new PlanOperativoLN();


                planAccionLN = new PlanAccionLN();

                if ((idUnidad > 0) && (idUnidad != tempUnidad))
                {
                    ddlUnidades.SelectedValue = tempUnidad.ToString();
                    ddlDependencia.SelectedValue = idUnidad.ToString();
                    planOperativoLN.DdlDependenciasmUnidad(ddlJefaturaUnidad, idUnidad.ToString());
                    
                    if (anio > 0 && idUnidad > 0)
                        validarPoa(idUnidad, anio, 2);
                }
                else if (ddlDependencia.SelectedIndex == 0)
                {
                    validarPoa(Convert.ToInt32(ddlUnidades.SelectedValue), anio, 2);
                }
              
                else
                {
                    if (anio > 0 && idUnidad > 0)
                        validarPoa(idUnidad, anio, 3);
                }
                
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
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                int anio = int.Parse(ddlAnios.SelectedValue);
                int idUnidad = int.Parse(ddlJefaturaUnidad.SelectedValue);
                int tempUnidad = int.Parse(ddlDependencia.SelectedValue);
                
                ddlPlanes.SelectedValue = idPlan.ToString();
                

                ddlAnios.SelectedValue = anio.ToString();
                btnGuardar.Visible = false;


                planOperativoLN = new PlanOperativoLN();


                planAccionLN = new PlanAccionLN();

                if (idUnidad > 0 && idUnidad != tempUnidad)
                {
                    ddlJefaturaUnidad.SelectedValue = idUnidad.ToString();
                    ddlDependencia.SelectedValue = tempUnidad.ToString();
                    if (anio > 0 && idUnidad > 0)
                        validarPoa(idUnidad, anio, 3);
                }
                else
                {
                    validarPoa(idUnidad, anio, 3);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }
    }
}
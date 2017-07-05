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

namespace AplicacionSIPA1.Operativa.Seguimiento
{
    public partial class CalendarioSeguimiento : System.Web.UI.Page
    {
        private PlanAnualLN pAnualLN;
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private SeguimientoCalendarioEN cCalendario;
        private SeguimientoLN sSeguimientoLN;

        string Last = string.Empty;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    nuevoIngresoCalendario();
                    NuevoEncabezadoPoa();
                    ddlAnios_SelectedIndexChanged(sender, e);
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
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pAnualLN = new PlanAnualLN();

                lblIdCalendario.Text = "0";

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
                {
                    ddlAnios.SelectedValue = anioActual.ToString();
                    ddlAnios_SelectedIndexChanged(new Object(), new EventArgs());
                }

                string usuario = Session["Usuario"].ToString().ToLower();               
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoPoa(). " + ex.Message);
            }
        }

        protected void limpiarControlesError()
        {
            lblErrorEnero.Text = string.Empty;
            lblErrorFebrero.Text = string.Empty;
            lblErrorMarzo.Text = string.Empty;
            lblErrorAbril.Text = string.Empty;
            lblErrorMayo.Text = string.Empty;
            lblErrorJunio.Text = string.Empty;
            lblErrorJulio.Text = string.Empty;
            lblErrorAgosto.Text = string.Empty;
            lblErrorOctubre.Text = string.Empty;
            lblErrorNoviembre.Text = string.Empty;
            lblErrorDiciembre.Text = string.Empty;
            //lblErrorPoa.Text = string.Empty;
            lblError.Text = lblSuccess.Text = string.Empty;
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                nuevoIngresoCalendario();

                int idPlan, anio, idCalendario;
                idPlan = anio = idCalendario = 0;

                int.TryParse(ddlPlanes.SelectedValue, out idPlan);
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(lblIdCalendario.Text, out idCalendario);

                sSeguimientoLN = new SeguimientoLN();
                DataSet dsResultado = sSeguimientoLN.InformacionCalendarios(anio, idPlan, "", 1);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables.Count == 1)
                    throw new Exception("Error al consultar la información del calendario.");

                if (dsResultado.Tables[1].Rows.Count > 0)
                {
                    lblIdCalendario.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_SEGUIMIENTO_CALENDARIO"].ToString();
                    txtEnero.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_ENERO_STRING"].ToString();
                    txtFebrero.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_FEBRERO_STRING"].ToString();
                    txtMarzo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_MARZO_STRING"].ToString();
                    txtAbril.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_ABRIL_STRING"].ToString();
                    txtMayo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_MAYO_STRING"].ToString();
                    txtJunio.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_JUNIO_STRING"].ToString();
                    txtJulio.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_JULIO_STRING"].ToString();
                    txtAgosto.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_AGOSTO_STRING"].ToString();
                    txtSeptiembre.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_SEPTIEMBRE_STRING"].ToString();
                    txtOctubre.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_OCTUBRE_STRING"].ToString();
                    txtNoviembre.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_NOVIEMBRE_STRING"].ToString();
                    txtDiciembre.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ENTREGA_DICIEMBRE_STRING"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios(). " + ex.Message;
            }
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);

                if (idPlan > 0)
                {
                    ddlPlanes.SelectedValue = idPlan.ToString();
                    int anioIni = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[0].Trim());
                    int anioFin = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[1].Trim());

                    pEstrategicoLN = new PlanEstrategicoLN();

                    pEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlPlanes(). " + ex.Message;
            }
        }

        protected void btnVerReporte_Click(object sender, EventArgs e)
        {
            
        }
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                if (validarControlesABC() == true)
                {
                    int idSeguimientoCalendario, idPlan, anio;
                    idSeguimientoCalendario = idPlan = anio = 0;
                    
                    int.TryParse(lblIdCalendario.Text, out idSeguimientoCalendario);
                    int.TryParse(ddlPlanes.SelectedValue, out idPlan);
                    int.TryParse(ddlAnios.SelectedValue, out anio);
                    
                    FuncionesVarias funciones = new FuncionesVarias();
                    cCalendario = new SeguimientoCalendarioEN();
                    cCalendario.ID_SEGUIMIENTO_CALENDARIO = idSeguimientoCalendario.ToString();
                    cCalendario.ID_PLAN = idPlan.ToString();
                    cCalendario.ANIO = anio.ToString();
                    cCalendario.ENTREGA_ENERO = funciones.StringToFechaMySql(txtEnero.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                    cCalendario.ENTREGA_FEBRERO = funciones.StringToFechaMySql(txtFebrero.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                    cCalendario.ENTREGA_MARZO = funciones.StringToFechaMySql(txtMarzo.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                    cCalendario.ENTREGA_ABRIL = funciones.StringToFechaMySql(txtAbril.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                    cCalendario.ENTREGA_MAYO = funciones.StringToFechaMySql(txtMayo.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                    cCalendario.ENTREGA_JUNIO = funciones.StringToFechaMySql(txtJunio.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                    cCalendario.ENTREGA_JULIO = funciones.StringToFechaMySql(txtJulio.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                    cCalendario.ENTREGA_AGOSTO = funciones.StringToFechaMySql(txtAgosto.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                    cCalendario.ENTREGA_SEPTIEMBRE = funciones.StringToFechaMySql(txtSeptiembre.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                    cCalendario.ENTREGA_OCTUBRE = funciones.StringToFechaMySql(txtOctubre.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                    cCalendario.ENTREGA_NOVIEMBRE = funciones.StringToFechaMySql(txtNoviembre.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();
                    cCalendario.ENTREGA_DICIEMBRE = funciones.StringToFechaMySql(txtDiciembre.Text).Tables[0].Rows[0]["FECHA_FORMATO_INSERT_MYSQL"].ToString();

                    cCalendario.ID_ESTADO = "1";
                    cCalendario.ACTIVO = "1";
                    cCalendario.USUARIO = Session["usuario"].ToString();

                    sSeguimientoLN = new SeguimientoLN();
                    DataSet dsResultado = sSeguimientoLN.AlmacenarCalendario(cCalendario,Session["usuario"].ToString());

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ el caso: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idSeguimientoCalendario);
                    lblIdCalendario.Text = idSeguimientoCalendario.ToString();

                    lblSuccess.Text = "Calendario ALMACENADO exitosamente: ";                    
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar(). " + ex.Message;
            }
        }

        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                FuncionesVarias funciones = new FuncionesVarias();

                //ENERO
                DataSet dsFecha = funciones.StringToFechaMySql(txtEnero.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorEnero.Text = "Valor lógico desconocido";
                    lblError.Text += "Ingrese fecha para enero. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorEnero.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para enero. ";
                }
                //FEBRERO
                dsFecha = funciones.StringToFechaMySql(txtFebrero.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorFebrero.Text = "Valor lógico desconocido";
                    lblError.Text += "Ingrese fecha para febrero. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorFebrero.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para febrero. ";
                }
                //MARZO
                dsFecha = funciones.StringToFechaMySql(txtMarzo.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorMarzo.Text = "Valor lógico desconocido";
                    lblError.Text += "Ingrese fecha para marzo. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorMarzo.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para marzo. ";
                }
                //ABRIL
                dsFecha = funciones.StringToFechaMySql(txtAbril.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorAbril.Text = "Valor lógico desconocido";
                    lblError.Text = "Ingrese fecha para abril. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorAbril.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para abril. ";
                }
                //MAYO
                dsFecha = funciones.StringToFechaMySql(txtMayo.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorMayo.Text = "Valor lógico desconocido";
                    lblError.Text += "Ingrese fecha para mayo. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorMayo.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para mayo. ";
                }
                //JUNIO
                dsFecha = funciones.StringToFechaMySql(txtJunio.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorJunio.Text = "Valor lógico desconocido";
                    lblError.Text += "Ingrese fecha para junio. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorJunio.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para junio. ";
                }
                //JULIO
                dsFecha = funciones.StringToFechaMySql(txtJulio.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorJulio.Text = "Valor lógico desconocido";
                    lblError.Text += "Ingrese fecha para julio. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorJulio.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para julio. ";
                }
                //AGOSTO
                dsFecha = funciones.StringToFechaMySql(txtAgosto.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorAgosto.Text = "Valor lógico desconocido";
                    lblError.Text += "Ingrese fecha para agosto. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorAgosto.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para agosto. ";
                }
                //SEPTIEMBRE
                dsFecha = funciones.StringToFechaMySql(txtSeptiembre.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorSeptiembre.Text = "Valor lógico desconocido";
                    lblError.Text += "Ingrese fecha para septiembre. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorSeptiembre.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para septiembre. ";
                }
                //OCTUBRE
                dsFecha = funciones.StringToFechaMySql(txtOctubre.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorOctubre.Text = "Valor lógico desconocido";
                    lblError.Text += "Ingrese fecha para octubre. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorOctubre.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para octubre. ";
                }
                //NOVIEMBRE
                dsFecha = funciones.StringToFechaMySql(txtNoviembre.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorNoviembre.Text = "Valor lógico desconocido";
                    lblError.Text += "Ingrese fecha para noviembre. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorNoviembre.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para noviembre. ";
                }
                //DICIEMBRE
                dsFecha = funciones.StringToFechaMySql(txtDiciembre.Text);
                if (dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("true") == false && dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].Equals("false") == false)
                {
                    lblErrorDiciembre.Text = "Valor lógico desconocido";
                    lblError.Text += "Ingrese fecha para diciembre. ";
                }
                else if (bool.Parse(dsFecha.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                {
                    lblErrorDiciembre.Text = "Fecha no válida";
                    lblError.Text += "Ingrese fecha para diciembre. ";
                }

                if (lblError.Text.Equals(string.Empty))
                    controlesValidos = true;
                
                Page.Validate();
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

        protected void nuevoIngresoCalendario()
        {
            try
            {
                limpiarControlesError();
                lblIdCalendario.Text = "0";
                txtEnero.Text = string.Empty;
                txtFebrero.Text = string.Empty;
                txtMarzo.Text = string.Empty;
                txtAbril.Text = string.Empty;
                txtMayo.Text = string.Empty;
                txtJunio.Text = string.Empty;
                txtJulio.Text = string.Empty;
                txtAgosto.Text = string.Empty;
                txtSeptiembre.Text = string.Empty;
                txtOctubre.Text = string.Empty;
                txtNoviembre.Text = string.Empty;
                txtDiciembre.Text = string.Empty;

                /*txtEnero.Text = "2016-01-01";
                txtFebrero.Text = "2016-02-02";
                txtMarzo.Text = "2016-03-03";
                txtAbril.Text = "2016-04-04";
                txtMayo.Text = "2016-05-05";
                txtJunio.Text = "2016-06-06";
                txtJulio.Text = "2016-07-07";
                txtAgosto.Text = "2016-08-08";
                txtSeptiembre.Text = "2016-09-09";
                txtOctubre.Text = "2016-10-10";
                txtNoviembre.Text = "2016-11-11";
                txtDiciembre.Text = "2016-12-12";*/


            }
            catch (Exception ex)
            {
                throw new Exception("nuevoIngresoCalendario(). " + ex.Message);
            }
        }
    }
}
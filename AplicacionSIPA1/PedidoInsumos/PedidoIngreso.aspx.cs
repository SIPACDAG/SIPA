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

namespace AplicacionSIPA1.PedidoInsumos
{
    public partial class PedidoIngreso : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;

        private PedidosLN pInsumoLN;
        private PedidosEN pInsumoEN;

        double totalmp, totalcp, totalsp = 0;
        int contarp = 0;

        public DataSet dsPac
        {
            get
            {
                object o = ViewState["dsPac"];
                return (DataSet)o;
            }
            set { ViewState["dsPac"] = value; }
        }
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    btnNuevo_Click(sender, e);

                    string mensaje = Convert.ToString(Request.QueryString["msg"]);
                    if (mensaje != null && mensaje.Equals("Listado"))
                    {
                        btnListado_Click(sender, e);
                    }
                    else
                    {
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
                pOperativoLN.DdlUnidades(ddlUnidades, usuario);

                if (ddlUnidades.Items.Count == 1)
                {
                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoaIngresoPedido(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                    }
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoPoa(). " + ex.Message);
            }
        }

        public void NuevoPedidoEnc()
        {
            try
            {
                string usuario = Session["usuario"].ToString();
                int idUnidad = 0;
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlSolicitantes(ddlSolicitantes, usuario, idUnidad);
                pInsumoLN.DdlJefes(ddlJefes, usuario, idUnidad);
                pInsumoLN.DdlTiposPedido(ddlTipoPedido, 1);

                rblTipoDestino.SelectedValue = "1";
                rblTipoDestino_SelectedIndexChanged(new Object(), new EventArgs());
                rblAnexos.SelectedValue = "1";
                txtJustificacion.Text = string.Empty;

                lblDisponibleP.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoPedidoEnc(). " + ex.Message);
            }
        }

        public void NuevoPedidoDet()
        {
            try
            {
                int idAccion = 0;
                //int.TryParse(ddlAcciones.SelectedValue, out idAccion);

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlInsumosxAccion(ddlInsumo, idAccion);
                txtDescripcion.Text = string.Empty;

                txtCantidad.Text = txtCosto.Text = string.Empty;
                gridDet.DataSource = null;
                gridDet.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoPedidoDet()(). " + ex.Message);
            }
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoPedidoEnc();
                NuevoPedidoDet();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaIngresoPedido(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";
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
                NuevoPedidoEnc();
                NuevoPedidoDet();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaIngresoPedido(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlTipoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();   
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlTipoPedido(). " + ex.Message;
            }
        }

        protected void rblTipoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                pInsumoLN = new PedidosLN();
                if (rblTipoDestino.SelectedValue.Equals("1"))
                {
                    pInsumoLN.DdlFand(ddlFADN, 0);
                    ddlFADN.Enabled = false;
                }
                else
                {
                    pInsumoLN.DdlFand(ddlFADN, 1);
                    ddlFADN.Enabled = true;
                }
                    
            }
            catch (Exception ex)
            {
                lblError.Text = "rblTipoDestino(). " + ex.Message;
            }
        }

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                //NuevoPedidoEnc();
                //NuevoPedidoDet();

                int idAccion = 0;
                int.TryParse(ddlAcciones.SelectedValue, out idAccion);

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlInsumosxAccion(ddlInsumo, idAccion);

                int idPac = 0;
                int.TryParse(ddlInsumo.SelectedValue, out idPac);

                if (idPac > 0)
                    ddlInsumo_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones(). " + ex.Message;
            }
        }

        protected void ddlInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idPac = 0;
                int.TryParse(ddlInsumo.SelectedValue, out idPac);

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionInsumoPac(idPac);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se CONSULTÓ la informaciónd el INSUMO/PAC: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                txtDescripcion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DESCRIPCION"].ToString();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlInsumo(). " + ex.Message;
            }
        }

        protected DataSet armarDsDet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("id", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Mes", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Cantidad", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Monto", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Subtotal", Type.GetType("System.String"));

            return ds;
        }


        protected void limpiarControlesError()
        {
            lblErrorPoa.Text = string.Empty;
            lblErrorPlan.Text = string.Empty;
            lblErrorAnio.Text = lblErrorUnidad.Text = string.Empty;
            lblErrorSolicitante.Text = lblErrorJefe.Text = lblErrorTipoPedido.Text = string.Empty;
            lblErrorJustificacion.Text = string.Empty;
            lblErrorTipoDestino.Text = lblErrorFand.Text = lblErrorAnexos.Text = string.Empty;
            lblErrorAccion.Text = lblErrorInsumo.Text = lblErrorCantidad.Text = lblErrorMonto.Text = string.Empty;
            lblError.Text = lblSuccess.Text = string.Empty;

        }

        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                if (ddlAnios.SelectedValue.Equals("0") || ddlAnios.Items.Count == 0)
                {
                    lblErrorAnio.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un año. ";
                }

                if (ddlPlanes.SelectedValue.Equals("0") || ddlPlanes.Items.Count == 0)
                {
                    lblErrorPlan.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un plan. ";
                }

                if (ddlUnidades.SelectedValue.Equals("0") || ddlUnidades.Items.Count == 0)
                {
                    lblErrorUnidad.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione una unidad. ";
                }

                if (ddlAcciones.SelectedValue.Equals("0") || ddlAcciones.Items.Count == 0)
                {
                    lblErrorAccion.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione una acción. ";
                }

                if (ddlSolicitantes.SelectedValue.Equals("0") || ddlSolicitantes.Items.Count == 0)
                {
                    lblErrorSolicitante.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un solicitante. ";
                }
                
                if (ddlJefes.SelectedValue.Equals("0") || ddlJefes.Items.Count == 0)
                {
                    lblErrorJefe.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un Subgerente/Director. ";
                }
                
                if (ddlTipoPedido.SelectedValue.Equals("0") || ddlTipoPedido.Items.Count == 0)
                {
                    lblErrorTipoPedido.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un tipo de pedido. ";
                }
                
                if (rblTipoDestino.SelectedValue.Equals("2"))
                {
                    if (ddlFADN.SelectedValue.Equals("0") || ddlFADN.Items.Count == 0)
                    {
                        lblErrorFand.Text = "Seleccione un valor. ";
                        lblError.Text += "Seleccione una FAND. ";
                    }
                }
                else if (!rblTipoDestino.SelectedValue.Equals("1"))
                {
                    lblErrorTipoDestino.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione CDAG ó FAND. ";
                }

                string justificacion = txtJustificacion.Text;
                justificacion = justificacion.Replace('\'', ' ').Replace(';', ' ');
                justificacion = justificacion.Trim();
                txtJustificacion.Text = justificacion;

                if (txtJustificacion.Equals(""))
                {
                    lblErrorJustificacion.Text = "Ingrese una justificación. ";
                    lblError.Text += "Ingrese una justificación. ";
                }

                if (gridDet.Rows.Count == 0)
                {
                    if (ddlInsumo.SelectedValue.Equals("0") || ddlInsumo.Items.Count == 0)
                    {
                        lblErrorInsumo.Text = "Seleccione un valor. ";
                        lblError.Text += "Seleccione un insumo. ";
                    }

                    int cantidad = 0;
                    int.TryParse(txtCantidad.Text, out cantidad);
                    txtCantidad.Text = cantidad.ToString();

                    if (cantidad == 0)
                    {
                        lblErrorCantidad.Text = "Ingrese un entero. ";
                        lblError.Text += "Ingrese una cantidad entera. ";
                    }

                    string temp = txtCosto.Text;
                    string[] s = temp.Split('.');
                    if (s.Length == 1 || s.Length == 2)
                    {
                        if (s.Length == 1)
                            temp = s[0] + ".00";
                        else
                        {
                            if (s[1].Length == 1)
                                temp = s[0] + "." + s[1].Substring(0, 1) + "0";
                            else
                                temp = s[0] + "." + s[1].Substring(0, 2);
                        }

                        decimal costo = 0;
                        decimal.TryParse(temp, out costo);
                        txtCosto.Text = costo.ToString();
                        
                        if (costo == 0)
                        {
                            lblErrorMonto.Text = "Ingrese un monto válido. ";
                            lblError.Text += "Ingrese un monto válido. ";
                        }
                    }
                    else
                    {
                        lblErrorMonto.Text = "Ingrese un monto válido. ";
                        lblError.Text += "Ingrese un monto válido. ";
                    }                                   
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


        protected bool validarPoaIngresoPedido(int idUnidad, int anio)
        {
            try
            {
                bool poaValido = false;
                btnGuardar.Visible = false;
                lblIdPoa.Text = "0";

                pOperativoLN = new PlanOperativoLN();                
                DataSet dsPoa = pOperativoLN.DatosPoaUnidad(idUnidad, anio);
                
                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                int idPoa = 0;
                int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
                lblIdPoa.Text = idPoa.ToString();

                string estadoPoa = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString() + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString();
                lblEstadoPoa.Text = estadoPoa;

                if (!estadoPoa.Split('-')[0].Trim().Equals("9"))
                {
                    btnGuardar.Visible = false;
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa;
                }
                else
                {
                    btnGuardar.Visible = true;

                    string estadoPac = dsPoa.Tables[0].Rows[0]["ESTADO_PAC"].ToString();
                    lblEstadoPac.Text = estadoPac;

                    if (!estadoPac.Split('-')[0].Trim().Equals("1") && !estadoPac.Split('-')[0].Trim().Equals("3") && !estadoPac.Split('-')[0].Trim().Equals("1"))
                    {
                        btnGuardar.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El PLAN ANUAL DE COMPRAS seleccionado se encuenta en estado: " + estadoPac;
                    }
                    else
                    {
                        btnGuardar.Visible = true;
                        poaValido = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }

            //////////////////////////
            btnGuardar.Visible = true;
            return true;
            //////////////////////////
            //return poaValido;            
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarControlesABC())
                {
                    pInsumoEN = new PedidosEN();

                    pInsumoEN.ID_ACCION = int.Parse(ddlAcciones.SelectedValue);
                    pInsumoEN.ID_TIPO_PEDIDO = int.Parse(ddlTipoPedido.SelectedValue);
                    pInsumoEN.ID_SOLICITANTE = int.Parse(ddlSolicitantes.SelectedValue);
                    pInsumoEN.ID_JEFE_DIRECCION = int.Parse(ddlJefes.SelectedValue);
                    pInsumoEN.JUSTIFICACION = txtJustificacion.Text;
                    pInsumoEN.USUARIO = Session["usuario"].ToString();
                    pInsumoEN.ID_FAND = int.Parse(ddlFADN.SelectedValue);

                    int idDetalleAccion = 0;
                    int idAccion = int.Parse(ddlAcciones.SelectedValue);

                    //if (ValidarPpto(idDetalleAccion, idPac, total))
                    if (ValidarPpto(idDetalleAccion, 0, 0))
                    {
                        pAnualLN = new PlanAnualLN();
                        DataSet dsResultado = pAnualLN.AlmacenarPac(dsPac,Session["usuario"].ToString());

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ el PAC: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        btnNuevo_Click(sender, e);

                        string noPac = dsResultado.Tables[0].Rows[0]["VALOR"].ToString();
                        //lblSuccess.Text = "Plan Anual de Compras ALMACENADO exitosamente, número de Pac: " + noPac;

                        Response.Redirect("NoPlan.aspx?No=" + Convert.ToString(noPac) + "&monto=" + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0) + "&msg=CREADO/ACTUALIZADO");
                    }               

                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar(). " + ex.Message;
            }
        }

        /*protected DataSet guardarDetallePedido(int idPoa, int idDependencia, int idDetalle, int idAccion, string noRenglon, int idTipoFinanciamiento, decimal monto, string idInsumo, string usuario)
        {
            DataSet dsResultado = new DataSet();
            try
            {
                string mensaje = string.Empty;
                planAccionLN = new PlanAccionLN();
                DataSet dsPpto = planAccionLN.PptoPoa(idPoa, idDependencia);

                decimal disponible = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE_DEPENDENCIA"].ToString());
                if (monto > disponible)
                    throw new Exception("El presupuesto ingresado supera al disponible por " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", disponible - monto));

                int idTipoDetalle = 0;

                //2 = RENGLÓN , 1 = INSUMO
                if (idInsumo.Equals("null"))
                    idTipoDetalle = 2;
                else
                    idTipoDetalle = 1;

                accionDetEN = new AccionesDetEN();
                accionDetEN.Id_Detalle = idDetalle;
                accionDetEN.Id_Accion = idAccion;
                accionDetEN.No_Renglon = noRenglon;
                accionDetEN.Id_Tipo_Financiamiento = idTipoFinanciamiento;
                accionDetEN.Monto = monto;
                accionDetEN.Id_Insumo = idInsumo;
                accionDetEN.Id_Tipo_Detalle = idTipoDetalle;
                accionDetEN.Usuario = Session["usuario"].ToString();

                planAccionLN = new PlanAccionLN();
                dsResultado = planAccionLN.AlmacenarDetalle(accionDetEN);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se INSERTÓ/ACTUALIZÓ el detalle: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                mensaje += "Detalle INSERTADO/ACTUALIZADO exitosamente!. ";
                limpiarNListado();
            }
            catch (Exception ex)
            {
                planAccionLN = new PlanAccionLN();
                dsResultado = planAccionLN.armarDsResultado();
                dsResultado.Tables[0].Rows[0]["ERRORES"] = true;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = ex.Message;
            }
            return dsResultado;
        }*/

        protected bool ValidarPpto(int idDetalleAccion, int idPac, decimal totalPac)
        {
            pAccionLN = new PlanAccionLN();
            pAnualLN = new PlanAnualLN();
            bool pptoValido = false;

            //DataSet dsPptoAccion = pAccionLN.PptoAccion(idAccion);
            DataSet dsPptoRenglon = pAnualLN.InformacionRenglonAccion(idDetalleAccion);
            DataSet dsPptoPac = pAnualLN.InformacionPac(idPac);

            if (bool.Parse(dsPptoRenglon.Tables[0].Rows[0]["ERRORES"].ToString()))
                throw new Exception("No se consultó el presupuesto del Renglón: " + dsPptoRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

            if (bool.Parse(dsPptoPac.Tables[0].Rows[0]["ERRORES"].ToString()))
                throw new Exception("No se consultó el presupuesto del Plan: " + dsPptoRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

            decimal saldoRenglon = 0;
            decimal codificadoPac = 0;
            decimal montoActualPac = 0;

            decimal.TryParse(dsPptoRenglon.Tables["BUSQUEDA"].Rows[0]["SALDO_PAC"].ToString(), out saldoRenglon);
            decimal.TryParse(dsPptoPac.Tables["ENCABEZADO"].Rows[0]["MONTO"].ToString(), out montoActualPac);

            decimal diferenciaRenglonMontoN = (saldoRenglon + montoActualPac) - totalPac;
            if(diferenciaRenglonMontoN < 0)
                throw new Exception("El monto máximo debe ser igual o menor al monto disponible: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (saldoRenglon + montoActualPac)));


            decimal.TryParse(dsPptoPac.Tables["ENCABEZADO"].Rows[0]["CODIFICADO"].ToString(), out codificadoPac);
            decimal diferenciaCodificadoMontoN = totalPac - codificadoPac; 
            if (diferenciaCodificadoMontoN < 0)
                throw new Exception("El monto mínimo debe ser igual o mayor al monto codificado/comprometido: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", codificadoPac));
                
            pptoValido = true;
            return pptoValido;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoEncabezadoPoa();
                NuevoPedidoEnc();
                NuevoPedidoDet();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo. " + ex.Message;
            }
        }

        protected void btnListado_Click(object sender, EventArgs e)
        {

        }

        protected void ddlSolicitantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void ddlJefes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void ddlFADN_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void rblAnexos_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

    }
}
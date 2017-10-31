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

namespace AplicacionSIPA1.Pedido
{
    public partial class GastoIngreso : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;

        private PedidosLN pInsumoLN;
        private PedidosEN pInsumoEN;

        private FuncionesVarias funciones;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    btnNuevo_Click(sender, e);

                    string s = Convert.ToString(Request.QueryString["No"]);

                    if (s != null)
                    {
                        int idEncabezado = 0;
                        int.TryParse(s, out idEncabezado);
                        lblId.Text = idEncabezado.ToString();
                        string noSolicitud = "";

                        pInsumoLN = new PedidosLN();
                        DataSet dsResultado = pInsumoLN.InformacionGasto(idEncabezado, 0, 2);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables.Count == 0)
                            throw new Exception("Error al consultar la información del registro.");

                        if (dsResultado.Tables[0].Rows.Count == 0)
                            throw new Exception("No existe información del registro");

                        noSolicitud = dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_ANIO_SOLICITUD"].ToString();

                        int anio, idUnidad, idAccion, idSolicitante, idJefe, idFand = 0;

                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO"].ToString(), out anio);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_UNIDAD"].ToString(), out idUnidad);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ACCION"].ToString(), out idAccion);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_SOLICITANTE"].ToString(), out idSolicitante);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_JEFE_DIRECCION"].ToString(), out idJefe);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_FAND"].ToString(), out idFand);

                        ListItem item = ddlAnios.Items.FindByValue(anio.ToString());
                        if (item != null)
                        {
                            ddlAnios.SelectedValue = anio.ToString();
                            ddlAnios_SelectedIndexChanged(sender, e);
                        }

                        item = ddlUnidades.Items.FindByValue(idUnidad.ToString());
                        if (item != null)
                        {
                            ddlUnidades.SelectedValue = idUnidad.ToString();
                            ddlUnidades_SelectedIndexChanged(sender, e);
                        }

                        item = ddlAcciones.Items.FindByValue(idAccion.ToString());
                        if (item != null)
                        {
                            ddlAcciones.SelectedValue = idAccion.ToString();
                            ddlAcciones_SelectedIndexChanged(sender, e);
                        }

                        item = ddlSolicitantes.Items.FindByValue(idSolicitante.ToString());
                        if (item != null)
                            ddlSolicitantes.SelectedValue = idSolicitante.ToString();

                        item = ddlJefes.Items.FindByValue(idJefe.ToString());
                        if (item != null)
                            ddlJefes.SelectedValue = idJefe.ToString();

                        rblTipoDestino.SelectedValue = "1";
                        if (idFand > 0)
                            rblTipoDestino.SelectedValue = "2";

                        rblTipoDestino_SelectedIndexChanged(sender, e);

                        item = ddlFADN.Items.FindByValue(idFand.ToString());
                        if (item != null)
                            ddlFADN.SelectedValue = idFand.ToString();

                        txtJustificacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["JUSTIFICACION"].ToString();

                        filtrarGridDetalles(idEncabezado);
                        validarEstado(idEncabezado);
                        ddlAnios.Enabled = ddlUnidades.Enabled = /*ddlAcciones.Enabled =*/ false;

                        lblId.Text = idEncabezado.ToString();
                        lblNo.Text = noSolicitud;
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
                        validarPoaIngresoVale(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                    }
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";
                ddlAnios.Enabled = ddlUnidades.Enabled = ddlAcciones.Enabled = true;

                ddlAnios.Enabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoPoa(). " + ex.Message);
            }
        }

        public void NuevoEnc()
        {
            try
            {
                lblId.Text = "0";
                lblNo.Text = "0-0";
                validarEstado(0);
                lblEstado.Text = string.Empty;
                string usuario = Session["usuario"].ToString();
                int idUnidad = 0;
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlSolicitantes(ddlSolicitantes, usuario, idUnidad);
                pInsumoLN.DdlJefes(ddlJefes, usuario, idUnidad);

                rblTipoDestino.SelectedValue = "1";
                rblTipoDestino_SelectedIndexChanged(new Object(), new EventArgs());
                
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEnc(). " + ex.Message);
            }
        }

        public void NuevoDet()
        {
            try
            {
                int idAccion = 0;
                int.TryParse(ddlAcciones.SelectedValue, out idAccion);

                txtDescripcion.Text = txtCantidad.Text = txtCosto.Text = string.Empty;

                int idVale = 0;
                int.TryParse(lblId.Text, out idVale);

                filtrarGridDetalles(idVale);

            }
            catch (Exception ex)
            {
                throw new Exception("NuevoDet(). " + ex.Message);
            }
        }

        protected void filtrarGridDetalles(int id)
        {
            try
            {
                gridDet.DataSource = null;
                gridDet.DataBind();
                gridDet.SelectedIndex = -1;

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionGasto(id, 0, 3);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridDet.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridDet.DataBind();

                    decimal cantidadArticulos = 0;
                    decimal totalSalida = 0;

                    dsResultado = pInsumoLN.InformacionGasto(id, 0, 2);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["CANTIDAD"].ToString(), out cantidadArticulos);
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["TOTAL"].ToString(), out totalSalida);

                    gridDet.FooterRow.Cells[4].Text = "Totales";
                    gridDet.FooterRow.Cells[6].Text = cantidadArticulos.ToString();
                    gridDet.FooterRow.Cells[8].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalSalida);
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

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoEnc();
                NuevoDet();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaIngresoVale(idUnidad, anio);
                else
                    lblIdPoa.Text = "0";

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
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
                NuevoEnc();
                NuevoDet();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaIngresoVale(idUnidad, anio);
                else
                    lblIdPoa.Text = "0";

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

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
                //NuevoPedidoEnc();
                //NuevoPedidoDet();
                filtrarGridPpto();

                int idAccion = 0;
                int.TryParse(ddlAcciones.SelectedValue, out idAccion);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones(). " + ex.Message;
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
            //lblErrorPoa.Text = string.Empty;
            lblErrorPlan.Text = string.Empty;
            lblErrorAnio.Text = lblErrorUnidad.Text = string.Empty;
            lblErrorSolicitante.Text = lblErrorJefe.Text = string.Empty;
            lblErrorJustificacion.Text = string.Empty;
            lblErrorTipoDestino.Text = lblErrorFand.Text = string.Empty;
            lblErrorAccion.Text = lblErrorDescripcion.Text = string.Empty;
            lblErrorCantidad.Text = lblErrorMonto.Text = string.Empty;
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

                if (txtJustificacion.Text.Equals(""))
                {
                    lblErrorJustificacion.Text = "Ingrese una justificación. ";
                    lblError.Text += "Ingrese una justificación. ";
                }

                if (gridDet.Rows.Count == 0 || gridDet.SelectedRow != null)
                {
                    string s1 = txtDescripcion.Text;
                    s1 = s1.Replace('\'', ' ').Replace(';', ' ');
                    s1 = s1.Trim();
                    txtDescripcion.Text = s1;

                    if (txtDescripcion.Text.Equals(""))
                    {
                        lblErrorDescripcion.Text = "Ingrese una descripción. ";
                        lblError.Text += "Ingrese una descripción del Bien/Servicio. ";
                    }

                    funciones = new FuncionesVarias();
                    decimal cantidad = 0;
                    decimal costo = 0;

                    try
                    {
                        cantidad = funciones.StringToDecimal(txtCantidad.Text);
                        txtCantidad.Text = cantidad.ToString();

                        if (cantidad <= 0)
                            throw new Exception();
                    }
                    catch (Exception)
                    {
                        lblErrorCantidad.Text = "Ingrese una cantidad válida. ";
                        lblError.Text += "Ingrese una cantidad válida. ";
                    }

                    try
                    {
                        costo = funciones.StringToDecimal(txtCosto.Text);
                        txtCosto.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", costo);

                        if (costo <= 0)
                            throw new Exception();
                    }
                    catch (Exception)
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


        protected bool validarPoaIngresoVale(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
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

                if (false)//(!estadoPoa.Split('-')[0].Trim().Equals("9"))
                {
                    btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa;
                }
                else
                {
                    string estadoPac = dsPoa.Tables[0].Rows[0]["ESTADO_PAC"].ToString();
                    if (false)// (!estadoPac.Split('-')[0].Trim().Equals("6"))
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El PLAN ANUAL DE COMPRAS seleccionado se encuenta en estado: " + estadoPac;
                    }
                    else
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = true;
                        poaValido = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            btnAnular.Visible = false;
            return poaValido;            
        }

        protected bool validarEstado(int id)
        {
            bool estadoValido = false;
            try
            {
                DataSet dsResultado = new DataSet();
                int idEstado = 0;

                if (id == 0)
                {
                    if (lblErrorPoa.Text.Equals("") || lblErrorPoa.Equals(string.Empty))
                    {
                        lblEstado.Text = "";
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = true;
                        lblErrorPoa.Text = lblError.Text = "";
                        estadoValido = true;
                    }
                    else
                        estadoValido = false;
                }
                else
                {
                    btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;

                    pInsumoLN = new PedidosLN();
                    dsResultado = pInsumoLN.InformacionGasto(id, 0, 2);
                    
                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del registro.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al gasto");

                    lblEstado.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_GASTO"].ToString();

                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_GASTO"].ToString(), out idEstado);

                    //EL PEDIDO ESTÁ EN ESTADO INGRESADO, AL NO SER ENVIADO A REVISIÓN SE PUEDE MODIFICAR
                    if (idEstado == 1)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = true;
                        lblErrorPoa.Text = lblError.Text = "";
                        estadoValido = true;
                    }//EL PEDIDO ESTÁ EN ESTADO RECHAZADO BODEGA, RECHAZADO SUB/DIR, RECHAZADO FINANCIERO, SE PUEDE MODIFICAR
                    else if (idEstado == 3 || idEstado == 5 || idEstado == 7 || idEstado == 9 || idEstado == 18)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = true;
                        lblErrorPoa.Text = lblError.Text = "El registro seleccionado se encuenta en estado: " + lblEstado.Text + ", por: " + dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES"].ToString();
                        estadoValido = true;

                    }//EL PEDIDO ESTÁ EN ESTADO APROBACIÓN BODEGA, APROBACIÓN SUB/DIR, APROBACIÓN FINANCIERO, CODIFICADO FINANCIERO, ANULADO Y NO SE PUEDE MODIFICAR
                    else if (idEstado == 2 || idEstado == 4 || idEstado == 6 || idEstado == 8 || idEstado == 10)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El registro seleccionado se encuenta en estado: " + lblEstado.Text + " y no se puede modificar ";
                        estadoValido = false;
                    }
                }

                //EL PEDIDO ESTÁ EN ESTADO INGRESADO, RECHAZADO BODEGA, RECHAZADO SUB/DIR, RECHAZADO FINANCIERO, SE PUEDE MODIFICAR
                if (idEstado == 0 || idEstado == 1 || idEstado == 3 || idEstado == 5 || idEstado == 7 || idEstado == 9)
                {
                    pInsumoLN = new PedidosLN();
                    dsResultado = pInsumoLN.InformacionPermisos(0, 0, Session["usuario"].ToString(), 5);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                        btnEnviar.Visible = true;
                    else
                        btnEnviar.Visible = false;

                    dsResultado = pInsumoLN.InformacionPermisos(0, 0, Session["usuario"].ToString(), 6);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                        btnGuardar.Visible = true;
                    else
                        btnGuardar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            btnAnular.Visible = false;
            return estadoValido;
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
                    int id = 0;
                    int.TryParse(lblId.Text, out id);

                    pInsumoEN = new PedidosEN();

                    pInsumoEN.ID_PEDIDO = id;
                    pInsumoEN.ID_POA = int.Parse(lblIdPoa.Text);
                    
                    pInsumoEN.ID_ACCION = int.Parse(ddlAcciones.SelectedValue);
                    pInsumoEN.ID_SOLICITANTE = int.Parse(ddlSolicitantes.SelectedValue);
                    pInsumoEN.ID_JEFE_DIRECCION = int.Parse(ddlJefes.SelectedValue);
                    pInsumoEN.JUSTIFICACION = txtJustificacion.Text;
                    pInsumoEN.ID_TIPO_PEDIDO = int.Parse(rblTipoDestino.SelectedValue);
                    pInsumoEN.ID_FAND = int.Parse(ddlFADN.SelectedValue);
                    pInsumoEN.USUARIO = Session["usuario"].ToString();

                    funciones = new FuncionesVarias();
                    decimal cantidad = funciones.StringToDecimal(txtCantidad.Text);
                    decimal costo = funciones.StringToDecimal(txtCosto.Text);

                    pInsumoEN.ID_PEDIDO_DETALLE = -1;

                    int idDetalle = 0;
                    if (!txtDescripcion.Text.Equals("") && cantidad > 0 && costo > 0)
                    {
                        if (gridDet.SelectedValue != null)
                            int.TryParse(gridDet.SelectedValue.ToString(), out idDetalle);

                        pInsumoEN.ID_PEDIDO_DETALLE = idDetalle;
                        pInsumoEN.ID_DETALLE_ACCION = 0;
                        pInsumoEN.CANTIDAD_ESTIMADA = cantidad;
                        pInsumoEN.COSTO_ESTIMADO = costo;
                        pInsumoEN.DESCRIPCION = txtDescripcion.Text;
                    }

                    if (ValidarPptoUIDetalle(id, idDetalle, (cantidad * costo)))
                    {
                        if (validarEstado(id))
                        {
                            pInsumoLN = new PedidosLN();
                            DataSet dsResultado = pInsumoLN.AlmacenarGasto(pInsumoEN,Session["usuario"].ToString());

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se INSERTÓ/ACTUALIZÓ el registro: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            
                            int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out id);
                            lblId.Text = id.ToString();

                            dsResultado = pInsumoLN.InformacionPedido(id, 0, 0, "", 2);

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se INSERTÓ/ACTUALIZÓ el pedido: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            lblNo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_ANIO_SOLICITUD"].ToString();

                            NuevoDet();
                            filtrarGridPpto();
                            lblSuccess.Text = "Gasto No. " + lblNo.Text + " INGRESADO/MODIFICADO exitosamente: ";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar(). " + ex.Message;
            }
        }


        protected bool ValidarPptoUIDetalle(int id, int idDetalle, decimal subTotal)
        {
            pInsumoLN = new PedidosLN();
            bool pptoValido = false;

           /* decimal montoGasto, montoGastoDetalle;
            montoGasto = montoGastoDetalle = 0;

            if (id > 0)
            {
                //INFORMACIÓN DEL ENCABEZADO DEL VALE
                DataSet dsInformacionGastoEnc = pInsumoLN.InformacionGasto(id, 0, 2);
                if (dsInformacionGastoEnc.Tables.Count == 0)
                    throw new Exception("Error al consultar la información del gasto: " + dsInformacionGastoEnc.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (dsInformacionGastoEnc.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe información del gasto: " + dsInformacionGastoEnc.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (bool.Parse(dsInformacionGastoEnc.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se consultó la información del gasto: " + dsInformacionGastoEnc.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                decimal.TryParse(dsInformacionGastoEnc.Tables["BUSQUEDA"].Rows[0]["TOTAL"].ToString(), out montoGasto);
            }

            if (idDetalle > 0)
            {
                //INFORMACIÓN DEL DETALLE DEL VALE
                DataSet dsInformacionGastoDetalle = pInsumoLN.InformacionGasto(idDetalle, 0, 4);
                if (dsInformacionGastoDetalle.Tables.Count == 0)
                    throw new Exception("Error al consultar la información del detalle del gasto: " + dsInformacionGastoDetalle.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (dsInformacionGastoDetalle.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe información del detalle del gasto: " + dsInformacionGastoDetalle.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (bool.Parse(dsInformacionGastoDetalle.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsInformacionGastoDetalle.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());


                if (idDetalle > 0)
                    decimal.TryParse(dsInformacionGastoDetalle.Tables["BUSQUEDA"].Rows[0]["SUBTOTAL"].ToString(), out montoGastoDetalle);
            }

            decimal nuevoTotalVale = (montoGasto - montoGastoDetalle) + subTotal;

            if (nuevoTotalVale > 1000)
                throw new Exception("El valor Maximo del Vale es de Q 1,000.00, este vale sobrepasa el limite ");
            */

            pptoValido = true;
            return pptoValido;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoEncabezadoPoa();
                NuevoEnc();
                NuevoDet();
                filtrarGridPpto();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo(). " + ex.Message;
            }
        }

        protected void filtrarGridPpto()
        {
            try
            {
                gridSaldos.DataSource = null;
                gridSaldos.DataBind();
                gridSaldos.SelectedIndex = -1;

                int idSalida, tipoSalida;
                idSalida = tipoSalida = 0;

                int.TryParse(ddlAcciones.SelectedValue, out idSalida);

                //SALDOS EN BASE A LA ACCIÓN
                tipoSalida = 4;
                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.PptoAprobacionSubgerente(idSalida, 0, "", tipoSalida);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridSaldos.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridSaldos.DataBind();
                }
                else
                {
                    gridSaldos.DataSource = null;
                    gridSaldos.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridPpto(). " + ex.Message);
            }
        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pedido/GastoListado.aspx?Anio=" + ddlAnios.SelectedItem.Value + "&unidad=" + ddlUnidades.SelectedItem.Value);
        }

        protected void ddlSolicitantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void ddlJefes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void ddlUnidadesMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void gridDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                //NuevoPedidoDet();

                int idDetalle = 0;
                int.TryParse(gridDet.SelectedValue.ToString(), out idDetalle);

                pInsumoLN = new PedidosLN();

                DataSet dsResultado = pInsumoLN.InformacionGasto(idDetalle, 0, 4);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                txtDescripcion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DESCRIPCION"].ToString();

                txtCantidad.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["CANTIDAD"].ToString();

                decimal costo = 0;
                decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["COSTO_ESTIMADO"].ToString(), out costo);
                txtCosto.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", costo);

            }
            catch (Exception ex)
            {
                lblError.Text = "gridDet(). " + ex.Message;
            }
        }

        protected void gridDet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idDetalle = int.Parse(e.Keys["ID"].ToString());
                //int.TryParse(idDetalle, out idDetalle);

                if (idDetalle == 0)
                    throw new Exception("No existe Bien/Servicio para eliminar");

                //EL PEDIDO TIENE POR LO MENOS UN DETALLE, DE LO CONTRARIO SE ELIMINARE EL ENCABEZADO Y EL DETALLE
                if (gridDet.Rows.Count > 1)
                {
                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.EliminarDetalleGasto(idDetalle);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    lblSuccess.Text = "Bien/Servicio eliminado correctamente!";
                }
                else
                    throw new Exception("Se necesita al menos un detalle");
                    //btnAnular_Click(new Object(), new EventArgs());
            }
            catch (Exception ex)
            {
                lblError.Text = "gridDet(). " + ex.Message;
            }
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int id = 0;
                int.TryParse(lblId.Text, out id);

                if (id  == 0)
                    throw new Exception("No existe Bien/Servicio para eliminar");

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.EliminarEncabezado(id);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                NuevoEncabezadoPoa();
                NuevoEnc();
                NuevoDet();

                lblSuccess.Text = "Gasto eliminado correctamente!";

                Response.Redirect("NoPedido.aspx?No=" + Convert.ToString(id) + "&msg=GASTO" + "&acc=ELIMINADO");
            }
            catch (Exception ex)
            {
                lblError.Text = "btnAnular(). " + ex.Message;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                btnGuardar_Click(sender, e);

                if (!lblSuccess.Text.Equals(string.Empty) || !lblSuccess.Text.Equals(""))
                {
                    limpiarControlesError();
                    int id;
                    int.TryParse(lblId.Text, out id);

                    if (ValidarPptoUIDetalle(id, 0, 0))
                    {
                        if (validarEstado(id))
                        {
                            if (id == 0)
                                throw new Exception("No existe Bien/Servicio para finalizar");
                            FuncionesVarias fv = new FuncionesVarias();
                            string[] ip = fv.DatosUsuarios();
                            pInsumoLN = new PedidosLN();
                            DataSet dsResultado = pInsumoLN.EnviarPedidoARevision(id, 3, Session["usuario"].ToString(),ip[0],ip[1],ip[2]);

                            if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                            btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
                            lblSuccess.Text = "Gasto finalizado correctamente!";

                            ///Falta lo del correo.
                            Response.Redirect("PedidoGuardado.aspx?No=" + lblNo.Text + "&msg=GASTO" + "&acc=ENVIADO");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnEnviar(). " + ex.Message;
            }
        }

        protected void rblTipoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //limpiarControlesError();

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

        protected void ddlFADN_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

    }
}
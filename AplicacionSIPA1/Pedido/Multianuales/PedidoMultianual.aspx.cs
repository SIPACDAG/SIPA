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
using System.Web.Security;
using System.Net.Mail;

namespace AplicacionSIPA1.Pedido.Multianuales
{
    public partial class PedidoMultianual : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private PlanOperativoLN planOperativoLN;
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
                        lblIdPedido.Text = idEncabezado.ToString();
                        string noSolicitud = "";

                        pInsumoLN = new PedidosLN();
                        DataSet dsResultado = pInsumoLN.InformacionPedido(idEncabezado, 0, 0, "", 2);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables.Count == 0)
                            throw new Exception("Error al consultar la información del pedido.");

                        if (dsResultado.Tables[0].Rows.Count == 0)
                            throw new Exception("No existe información del pedido");

                        noSolicitud = dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_ANIO_SOLICITUD"].ToString();

                        int anio, idUnidad, idAccion, idTipoPedido, idSolicitante, idJefe, idFand, idTipoAnexo = 0;

                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO"].ToString(), out anio);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_UNIDAD"].ToString(), out idUnidad);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ACCION"].ToString(), out idAccion);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_TIPO_PEDIDO"].ToString(), out idTipoPedido);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_SOLICITANTE"].ToString(), out idSolicitante);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_JEFE_DIRECCION"].ToString(), out idJefe);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_FAND"].ToString(), out idFand);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_TIPO_ANEXO"].ToString(), out idTipoAnexo);

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

                        item = ddlTipoPedido.Items.FindByValue(idTipoPedido.ToString());
                        if (item != null)
                            ddlTipoPedido.SelectedValue = idTipoPedido.ToString();

                        ddlTipoPedido_SelectedIndexChanged(sender, e);

                        rblTipoDestino.SelectedValue = "1";
                        if (idFand > 0)
                            rblTipoDestino.SelectedValue = "2";

                        rblTipoDestino_SelectedIndexChanged(sender, e);

                        item = ddlFADN.Items.FindByValue(idFand.ToString());
                        if (item != null)
                            ddlFADN.SelectedValue = idFand.ToString();

                        item = rblAnexos.Items.FindByValue(idTipoAnexo.ToString());
                        if (item != null)
                            rblAnexos.SelectedValue = idTipoAnexo.ToString();

                        txtJustificacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["JUSTIFICACION"].ToString();

                        filtrarGridDetalles(idEncabezado);
                        validarEstadoPedido(idEncabezado);
                        ddlAnios.Enabled = ddlUnidades.Enabled = /*ddlTipoPedido.Enabled = ddlAcciones.Enabled = */false;

                        lblIdPedido.Text = idEncabezado.ToString();
                        lblNoPedido.Text = noSolicitud;
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
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";
                //ddlAnios.Enabled = ddlUnidades.Enabled = ddlTipoPedido.Enabled = ddlAcciones.Enabled = true;

                InformacionPublica_TribunalHonor();

                ddlAnios.Enabled = false;
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
                lblIdPedido.Text = "0";
                lblNoPedido.Text = "0-0";
                validarEstadoPedido(0);
                lblEstadoPedido.Text = string.Empty;
                string usuario = Session["usuario"].ToString();
                int idUnidad = 0;
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlSolicitantes(ddlSolicitantes, usuario, idUnidad);
                pInsumoLN.DdlJefes(ddlJefes, usuario, idUnidad);
                pInsumoLN.DdlTiposPedido(ddlTipoPedido, 1);

                ListItem item = ddlTipoPedido.Items.FindByValue("2");
                if (item != null)
                {
                    ddlTipoPedido.SelectedValue = "2";
                    ddlTipoPedido_SelectedIndexChanged(new Object(), new EventArgs());
                }

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
                int.TryParse(ddlAcciones.SelectedValue, out idAccion);

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlPacsxAccion(ddlPac, idAccion);
                ddlUnidadesMedida.ClearSelection();
                lblNoDet.Text = "0";
                lblRenglonPpto.Text = txtDescripcion.Text = txtCantidad.Text = txtCosto.Text = string.Empty;
                txtCantidadMultianual.Text = string.Empty;
                txtCostoMultianual.Text = string.Empty;

                int idPedido = 0;
                int.TryParse(lblIdPedido.Text, out idPedido);

                filtrarGridDetalles(idPedido);

            }
            catch (Exception ex)
            {
                throw new Exception("NuevoPedidoDet()(). " + ex.Message);
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
                DataSet dsResultado = pInsumoLN.InformacionPedido(id, 0, 0, "", 3);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridDet.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridDet.DataBind();

                    decimal cantidadArticulos = 0;
                    decimal totalPedido = 0;
                    decimal totalPedidoAnual = 0;

                    dsResultado = pInsumoLN.InformacionPedido(id, 0, 0, "", 2);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["CANTIDAD"].ToString(), out cantidadArticulos);
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["TOTAL"].ToString(), out totalPedido);
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["SUM_TOTAL_PEDIDO_MULTIANUAL"].ToString(), out totalPedidoAnual);

                    gridDet.FooterRow.Cells[4].Text = "Totales";
                    gridDet.FooterRow.Cells[6].Text = cantidadArticulos.ToString();
                    gridDet.FooterRow.Cells[8].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalPedido);
                    gridDet.FooterRow.Cells[9].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalPedidoAnual);
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
                NuevoPedidoEnc();
                NuevoPedidoDet();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaIngresoPedido(idUnidad, anio);
                else
                    lblIdPoa.Text = "0";

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                InformacionPublica_TribunalHonor();
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
                string id_unidad = ddlUnidades.SelectedItem.Value;
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlDependencias(ddlDependencia, id_unidad);
                    validarPoaIngresoPedido(idUnidad, anio);
                }
                else
                    lblIdPoa.Text = "0";

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                InformacionPublica_TribunalHonor();

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

                int idTipoPedido = 0;
                int.TryParse(ddlTipoPedido.SelectedValue, out idTipoPedido);

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlUnidadesMedida(ddlUnidadesMedida, idTipoPedido);
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

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlPacsxAccion(ddlPac, idAccion);

                int idPac = 0;
                int.TryParse(ddlPac.SelectedValue, out idPac);

                if (idPac > 0)
                    ddlPac_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones(). " + ex.Message;
            }
        }

        protected void ddlPac_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idPac = 0;
                int.TryParse(ddlPac.SelectedValue, out idPac);

                pAnualLN = new PlanAnualLN();
                DataSet dsResultado = pAnualLN.InformacionPac(idPac);
                
                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se CONSULTÓ la informaciónd el PAC: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                lblRenglonPpto.Text = dsResultado.Tables["ENCABEZADO"].Rows[0]["RENGLON_PPTO"].ToString();

                ValidarPptoUIDetalle(idPac, 0, 0);
                //decimal saldo = 0;
                //decimal.TryParse(dsResultado.Tables["ENCABEZADO"].Rows[0]["SALDO"].ToString(), out saldo);
                //lblDisponibleP.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlPac(). " + ex.Message;
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
            lblErrorSolicitante.Text = lblErrorJefe.Text = lblErrorTipoPedido.Text = string.Empty;
            lblErrorJustificacion.Text = string.Empty;
            lblErrorTipoDestino.Text = lblErrorFand.Text = lblErrorAnexos.Text = string.Empty;
            lblErrorAccion.Text = lblErrorPac.Text = lblErrorDescripcion.Text = lblErrorUnidadMedida.Text = string.Empty;
            lblErrorCantidad.Text = lblErrorMonto.Text = string.Empty;
            lblErrorCantidadMultianual.Text = string.Empty;
            lblErrorMontoMultianual.Text = string.Empty;
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

                if (txtJustificacion.Text.Equals(""))
                {
                    lblErrorJustificacion.Text = "Ingrese una justificación. ";
                    lblError.Text += "Ingrese una justificación. ";
                }

                if (gridDet.Rows.Count == 0 || gridDet.SelectedRow != null)
                {
                    if (ddlPac.SelectedValue.Equals("0") || ddlPac.Items.Count == 0)
                    {
                        lblErrorPac.Text = "Seleccione un valor. ";
                        lblError.Text += "Seleccione un plan de compras. ";
                    }

                    string s1 = txtDescripcion.Text;
                    s1 = s1.Replace('\'', ' ').Replace(';', ' ');
                    s1 = s1.Trim();
                    txtDescripcion.Text = s1;

                    if (txtDescripcion.Text.Equals(""))
                    {
                        lblErrorDescripcion.Text = "Ingrese una descripción. ";
                        lblError.Text += "Ingrese una descripción del Bien/Servicio. ";
                    }

                    if (ddlUnidadesMedida.SelectedValue.Equals("0") || ddlUnidadesMedida.Items.Count == 0)
                    {
                        lblErrorUnidadMedida.Text = "Seleccione un valor. ";
                        lblError.Text += "Seleccione una unidad de medida. ";
                    }

                    funciones = new FuncionesVarias();
                    decimal cantidad = 0;
                    decimal costo = 0;

                    decimal cantidadMultianual = 0;
                    decimal costoMultianual = 0;

                    //ANUAL
                    try
                    {
                        cantidad = funciones.StringToDecimal(txtCantidad.Text);
                        txtCantidad.Text = cantidad.ToString();

                        if (cantidad < 0)
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

                        if (costo < 0)
                            throw new Exception();
                    }
                    catch (Exception)
                    {
                        lblErrorMonto.Text = "Ingrese un monto válido. ";
                        lblError.Text += "Ingrese un monto válido. ";
                    }

                    //MULTIANUAL
                    try
                    {
                        costoMultianual = funciones.StringToDecimal(txtCostoMultianual.Text);
                        txtCostoMultianual.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", costoMultianual);

                        if (costoMultianual <= 0)
                            throw new Exception();
                    }
                    catch (Exception)
                    {
                        lblErrorMontoMultianual.Text = "Ingrese un monto multianual válido. ";
                        lblError.Text += "Ingrese un monto multianual válido. ";
                    }

                    try
                    {
                        cantidadMultianual = funciones.StringToDecimal(txtCantidadMultianual.Text);
                        txtCantidadMultianual.Text = cantidadMultianual.ToString();

                        if (cantidadMultianual <= 0)
                            throw new Exception();
                    }
                    catch (Exception)
                    {
                        lblErrorCantidadMultianual.Text = "Ingrese una cantidad multianual válida. ";
                        lblError.Text += "Ingrese una cantidad multianual válida. ";
                    }

                    decimal subTotal = cantidad * costo;
                    decimal subTotalMultianual = cantidadMultianual * costoMultianual;

                    if (subTotalMultianual <= subTotal)
                        lblError.Text += "El Valor MULTIANUAL " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", subTotalMultianual) + " (" + cantidadMultianual + " * " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", costoMultianual) + ")" + " no puede ser menor que el subtotal " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", subTotal) + " (" + cantidad + " * " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", costo) + ")";
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
            bool poaValido = false;
            try
            {
                btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
                //btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = true;
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

                //return true;
                if (false)//(!estadoPoa.Split('-')[0].Trim().Equals("9"))
                {
                    btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa;
                }
                else
                {
                    string estadoPac = dsPoa.Tables[0].Rows[0]["ESTADO_PAC"].ToString();
                    if (false)//(!estadoPac.Split('-')[0].Trim().Equals("6"))
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

        protected bool validarEstadoPedido(int idPedido)
        {
            bool pedidoValido = false;
            try
            {
                DataSet dsResultado = new DataSet();
                int idEstadoPedido = 0;

                if (idPedido == 0)
                {
                    if (lblErrorPoa.Text.Equals("") || lblErrorPoa.Equals(string.Empty))
                    {
                        lblEstadoPedido.Text = "";
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = true;
                        lblErrorPoa.Text = lblError.Text = "";
                        pedidoValido = true;
                    }
                    else
                        pedidoValido = false;
                }
                else
                {
                    btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;

                    pInsumoLN = new PedidosLN();
                    dsResultado = pInsumoLN.InformacionPedido(idPedido, 0, 0, "", 2);
                    
                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del pedido.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al pedido");

                    lblEstadoPedido.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_PEDIDO"].ToString();

                    idEstadoPedido = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString(), out idEstadoPedido);

                    //EL PEDIDO ESTÁ EN ESTADO INGRESADO, AL NO SER ENVIADO A REVISIÓN SE PUEDE MODIFICAR
                    if (idEstadoPedido == 1)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = true;
                        lblErrorPoa.Text = lblError.Text = "";
                        pedidoValido = true;
                    }//EL PEDIDO ESTÁ EN ESTADO RECHAZADO BODEGA, RECHAZADO SUB/DIR, RECHAZADO PPTO, RECHAZADO TECNICO COMPRAS/PPTO SE PUEDE MODIFICAR
                    else if (idEstadoPedido == 3 || idEstadoPedido == 5 || idEstadoPedido == 7 || idEstadoPedido == 9 || idEstadoPedido == 18)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = true;
                        lblErrorPoa.Text = lblError.Text = "El PEDIDO seleccionado se encuenta en estado: " + lblEstadoPedido.Text + ", por: " + dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES"].ToString();
                        pedidoValido = true;

                    }//EL PEDIDO ESTÁ EN ESTADO APROBACIÓN BODEGA, APROBACIÓN SUB/DIR, APROBACIÓN FINANCIERO, CODIFICADO FINANCIERO, ANULADO Y NO SE PUEDE MODIFICAR
                    else if (idEstadoPedido == 2 || idEstadoPedido == 4 || idEstadoPedido == 6 || idEstadoPedido == 8 || idEstadoPedido == 10)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = gridDet.Columns[0].Visible = gridDet.Columns[1].Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El PEDIDO seleccionado se encuenta en estado: " + lblEstadoPedido.Text + " y no se puede modificar ";
                        pedidoValido = false;
                    }
                }

                //EL PEDIDO ESTÁ EN ESTADO INGRESADO, RECHAZADO BODEGA, RECHAZADO SUB/DIR, RECHAZADO FINANCIERO, SE PUEDE MODIFICAR
                if (idEstadoPedido == 0 || idEstadoPedido == 1 || idEstadoPedido == 3 || idEstadoPedido == 5 || idEstadoPedido == 7 || idEstadoPedido == 9)
                {
                    pInsumoLN = new PedidosLN();
                    dsResultado = pInsumoLN.InformacionPermisos(0, 0, Session["usuario"].ToString(), 1);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                        btnEnviar.Visible = true;
                    else
                        btnEnviar.Visible = false;

                    dsResultado = pInsumoLN.InformacionPermisos(0, 0, Session["usuario"].ToString(), 2);

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
            return pedidoValido;
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
                    int idPedido = 0;
                    int.TryParse(lblIdPedido.Text, out idPedido);

                    pInsumoEN = new PedidosEN();

                    pInsumoEN.ID_PEDIDO = idPedido;
                    pInsumoEN.ID_POA = int.Parse(lblIdPoa.Text);
                    
                    pInsumoEN.ID_ACCION = int.Parse(ddlAcciones.SelectedValue);
                    pInsumoEN.ID_SOLICITANTE = int.Parse(ddlSolicitantes.SelectedValue);
                    pInsumoEN.ID_JEFE_DIRECCION = int.Parse(ddlJefes.SelectedValue);
                    pInsumoEN.ID_TIPO_PEDIDO = int.Parse(ddlTipoPedido.SelectedValue);
                    pInsumoEN.JUSTIFICACION = txtJustificacion.Text;
                    pInsumoEN.DESTINO = int.Parse(rblTipoDestino.SelectedValue);
                    pInsumoEN.ID_FAND = int.Parse(ddlFADN.SelectedValue);
                    pInsumoEN.ID_TIPO_ANEXO = int.Parse(rblAnexos.SelectedValue);
                    pInsumoEN.MULTIANUAL = "1";
                    pInsumoEN.USUARIO = Session["usuario"].ToString();

                    int idPac, idUnidadMedida = 0;

                    int.TryParse(ddlPac.SelectedValue, out idPac);
                    int.TryParse(ddlUnidadesMedida.SelectedValue, out idUnidadMedida);

                    funciones = new FuncionesVarias();
                    decimal cantidad = funciones.StringToDecimal(txtCantidad.Text);
                    decimal costo = funciones.StringToDecimal(txtCosto.Text);

                    decimal cantidadMultianual = funciones.StringToDecimal(txtCantidadMultianual.Text);
                    decimal costoMultianual = funciones.StringToDecimal(txtCostoMultianual.Text);

                    pInsumoEN.ID_PEDIDO_DETALLE = -1;

                    int idPedidoDetalle = 0;
                    if (idPac > 0 && !txtDescripcion.Text.Equals("") && idUnidadMedida > 0 && cantidad >= 0 && costo >= 0)
                    {
                        if (gridDet.SelectedValue != null)
                            int.TryParse(gridDet.SelectedValue.ToString(), out idPedidoDetalle);

                        pInsumoEN.ID_PEDIDO_DETALLE = idPedidoDetalle;
                        pInsumoEN.ID_PAC = idPac;
                        pInsumoEN.ID_DETALLE_ACCION = 0;
                        pInsumoEN.CANTIDAD_ESTIMADA = cantidad;
                        pInsumoEN.COSTO_ESTIMADO = costo;

                        pInsumoEN.VCANTIDAD_PEDIDO_MULTIANUAL = cantidadMultianual.ToString();
                        pInsumoEN.VCOSTO_PEDIDO_MULTIANUAL = costoMultianual.ToString();

                        pInsumoEN.ID_UNIDAD_MEDIDA = idUnidadMedida;
                        pInsumoEN.DESCRIPCION = txtDescripcion.Text;
                    }

                    if (ValidarPptoUIDetalle(idPac, idPedidoDetalle, (cantidad * costo)))
                    //if(true)
                    {
                        if (validarEstadoPedido(idPedido))
                        {
                            pInsumoLN = new PedidosLN();
                            DataSet dsResultado = pInsumoLN.AlmacenarPedidoMultianual(pInsumoEN,Session["usuario"].ToString());

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se INSERTÓ/ACTUALIZÓ el pedido: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            
                            int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idPedido);
                            lblIdPedido.Text = idPedido.ToString();

                            dsResultado = pInsumoLN.InformacionPedido(idPedido, 0, 0, "", 2);

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se CONSULTÓ el pedido: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            lblNoPedido.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_ANIO_SOLICITUD"].ToString();

                            NuevoPedidoDet();
                            filtrarGridPpto();
                            lblSuccess.Text = "Pedido No. " + lblNoPedido.Text + " ALMACENADO/MODIFICADO exitosamente: ";
                            //FormsAuthentication.RedirectFromLoginPage(this.lblSuccess.Text,false);
                            //Response.Redirect("~/Pedido/PedidoGuardado.aspx?lblsucces="+lblSuccess.Text);
                            btnGuardar.Visible = true;   

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar(). " + ex.Message;
            }
        }

        protected bool ValidarPptoUIDetalle(int idPac, int idDetallePedido, decimal subTotal)
        {
            pAccionLN = new PlanAccionLN();
            pAnualLN = new PlanAnualLN();
            bool pptoValido = false;

            decimal saldoPac, saldoRenglon, montoDetPedido = 0;

            if (idPac > 0)
            {
                //INFORMACIÓN DEL PLAN ANUAL DE COMPRAS
                DataSet dsInformacionPac = pAnualLN.InformacionPac(idPac);
                if (dsInformacionPac.Tables.Count == 0)
                    throw new Exception("Error al consultar la información del Plan: " + dsInformacionPac.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (dsInformacionPac.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe información del del Plan: " + dsInformacionPac.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (bool.Parse(dsInformacionPac.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se consultó la información del Plan: " + dsInformacionPac.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                decimal saldo = 0;
                decimal.TryParse(dsInformacionPac.Tables["ENCABEZADO"].Rows[0]["SALDO"].ToString(), out saldo);
                lblDisponibleP.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);

                int idDetalleAccion = 0;
                int.TryParse(dsInformacionPac.Tables["ENCABEZADO"].Rows[0]["ID_DETALLE_ACCION"].ToString(), out idDetalleAccion);


                //INFORMACIÓN DEL RENGLÓN AL QUE PERTENECE EL PAC
                DataSet dsInformacionRenglon = pAccionLN.PptoRenglonAccion(idDetalleAccion);
                if (dsInformacionRenglon.Tables.Count == 0)
                    throw new Exception("Error al consultar la información del Plan: " + dsInformacionRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (dsInformacionRenglon.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe información del del Plan: " + dsInformacionRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (bool.Parse(dsInformacionRenglon.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se consultó la información del Plan: " + dsInformacionRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                saldo = 0;
                decimal.TryParse(dsInformacionRenglon.Tables["BUSQUEDA"].Rows[0]["SALDO_POA"].ToString(), out saldo);
                lblDisponibleR.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);

                //INFORMACIÓN DEL DETALLE DEL PEDIDO
                pInsumoLN = new PedidosLN();
                DataSet dsInformacionDetPedido = pInsumoLN.InformacionPedido(idDetallePedido, 0, 0, "", 4);
                if (dsInformacionDetPedido.Tables.Count == 0)
                    throw new Exception("Error al consultar la información del Plan: " + dsInformacionDetPedido.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (dsInformacionDetPedido.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe información del Plan: " + dsInformacionDetPedido.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                if (bool.Parse(dsInformacionDetPedido.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsInformacionDetPedido.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                
                decimal.TryParse(dsInformacionPac.Tables["ENCABEZADO"].Rows[0]["SALDO"].ToString(), out saldoPac);
                decimal.TryParse(dsInformacionRenglon.Tables["BUSQUEDA"].Rows[0]["SALDO_POA"].ToString(), out saldoRenglon);

                if (idDetallePedido > 0)
                    decimal.TryParse(dsInformacionDetPedido.Tables["BUSQUEDA"].Rows[0]["SUBTOTAL"].ToString(), out montoDetPedido);

                decimal diferenciaPacDetPedido = (saldoPac + montoDetPedido) - subTotal;
                decimal diferenciaRenglonDetPedido = (saldoRenglon + montoDetPedido) - subTotal;

                if (diferenciaPacDetPedido < 0)
                    throw new Exception("El monto del pedido supera al PAC en: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", diferenciaPacDetPedido));

                //if (diferenciaRenglonDetPedido < 0)
                //    throw new Exception("El monto del pedido supera al Renglón en: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", diferenciaRenglonDetPedido));
            }

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
                filtrarGridPpto();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo(). " + ex.Message;
            }
        }

        protected void InformacionPublica_TribunalHonor()
        {
            try
            {
                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPermisos(0, 0, Session["usuario"].ToString(), 10);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                //ELABORADOR O ENVIA REQUISICIONES DE UNIDAD DE ACCESO LA INFORMACIÓN PÚBLICA
                DataRow[] drPermisos = dsResultado.Tables["BUSQUEDA"].Select(" ID_TIPO = 42 OR ID_TIPO = 43");
                ListItem item = new ListItem();

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                {
                    if (drPermisos != null)
                        item = ddlAcciones.Items.FindByValue("366");

                    if (item != null)
                    {
                        ddlAcciones.SelectedValue = item.Value;
                        ddlAcciones.Enabled = false;
                        ddlAcciones_SelectedIndexChanged(new Object(), new EventArgs());
                    }

                    gridSaldos.Visible = false;
                    lblDisponibleP.Visible = false;
                    lblDisponibleR.Visible = false;
                }
                else
                {
                    dsResultado = pInsumoLN.InformacionPermisos(0, 0, Session["usuario"].ToString(), 11);
                    drPermisos = dsResultado.Tables["BUSQUEDA"].Select(" ID_TIPO = 45 OR ID_TIPO = 46");

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                    {
                        if (drPermisos != null)
                            item = ddlAcciones.Items.FindByValue("366");

                        if (item != null)
                        {
                            ddlAcciones.SelectedValue = item.Value;
                            ddlAcciones.Enabled = false;
                            ddlAcciones_SelectedIndexChanged(new Object(), new EventArgs());
                        }

                        gridSaldos.Visible = false;
                        lblDisponibleP.Visible = false;
                        lblDisponibleR.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("InformacionPublica_TribunalHonor(). " + ex.Message);
            }
        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Pedido/PedidoListado.aspx?Anio=" + ddlAnios.SelectedItem.Value + "&unidad=" + ddlUnidades.SelectedItem.Value);
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

                DataSet dsResultado = pInsumoLN.InformacionPedido(idDetalle, 0, 0, "", 4);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                int idPac = 0;
                int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_PAC"].ToString(), out idPac);
                ListItem item = ddlPac.Items.FindByValue(idPac.ToString());

                ddlPac.ClearSelection();
                if (item != null)
                    ddlPac.SelectedValue = idPac.ToString();

                int correlativo = 0;
                int.TryParse(gridDet.DataKeys[gridDet.SelectedIndex].Values["NUMERO"].ToString(), out correlativo);

                lblNoDet.Text = correlativo.ToString();
                txtDescripcion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DESCRIPCION"].ToString();

                int idUnidadMedida = 0;
                int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_UNIDAD_MEDIDA"].ToString(), out idUnidadMedida);
                item = ddlUnidadesMedida.Items.FindByValue(idUnidadMedida.ToString());

                ddlUnidadesMedida.ClearSelection();
                if (item != null)
                    ddlUnidadesMedida.SelectedValue = idUnidadMedida.ToString();

                txtCantidad.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["CANTIDAD"].ToString();
                
                decimal costo = 0;
                decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["COSTO_ESTIMADO"].ToString(), out costo);
                txtCosto.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", costo);

                decimal cantidadAnual = 0;
                decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["CANTIDAD_PEDIDO_MULTIANUAL"].ToString(), out cantidadAnual);
                txtCantidadMultianual.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", cantidadAnual);

                decimal costoAnual = 0;
                decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["COSTO_PEDIDO_MULTIANUAL"].ToString(), out costoAnual);
                txtCostoMultianual.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", costoAnual);
                
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

                if (idDetalle == 0)
                    throw new Exception("No existe Bien/Servicio para eliminar");

                //EL PEDIDO TIENE POR LO MENOS UN DETALLE, DE LO CONTRARIO SE ELIMINARE EL ENCABEZADO Y EL DETALLE
                if (gridDet.Rows.Count > 1)
                {
                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.EliminarDetalle(idDetalle);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    int idPac = 0;
                    int.TryParse(ddlPac.SelectedValue, out idPac);

                    NuevoPedidoDet();
                    ListItem item = ddlPac.Items.FindByValue(idPac.ToString());
                    if (item != null)
                    {
                        ddlPac.SelectedValue = idPac.ToString();
                        ddlPac_SelectedIndexChanged(new Object(), new EventArgs());
                    }

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
                int idPedido = 0;
                int.TryParse(lblIdPedido.Text, out idPedido);

                if (idPedido  == 0)
                    throw new Exception("No existe Bien/Servicio para eliminar");

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.EliminarEncabezado(idPedido);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                int idPac = 0;
                int.TryParse(ddlPac.SelectedValue, out idPac);

                NuevoEncabezadoPoa();
                NuevoPedidoEnc();
                NuevoPedidoDet();
                ListItem item = ddlPac.Items.FindByValue(idPac.ToString());
                if (item != null)
                {
                    ddlPac.SelectedValue = idPac.ToString();
                    ddlPac_SelectedIndexChanged(new Object(), new EventArgs());
                }

                lblSuccess.Text = "Pedido eliminado correctamente!";

                Response.Redirect("NoPedido.aspx?No=" + lblNoPedido.Text + "&msg=PEDIDO" + "&acc=ELIMINADO");
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
                //btnGuardar_Click(sender, e);

                //if (!lblSuccess.Text.Equals(string.Empty) || !lblSuccess.Text.Equals(""))
                {
                    limpiarControlesError();
                    int idPedido, idPac = 0;
                    int.TryParse(lblIdPedido.Text, out idPedido);
                    int.TryParse(ddlPac.SelectedValue, out idPac);

                    if (ValidarPptoUIDetalle(idPac, 0, 0))
                    {
                        if (validarEstadoPedido(idPedido))
                        {
                            if (idPedido == 0)
                                throw new Exception("No existe Bien/Servicio para finalizar");

                            pInsumoLN = new PedidosLN();
                            planOperativoLN = new PlanOperativoLN();
                            DataSet dsResultado = new DataSet();

                            if (rblAnexos.SelectedValue.Equals("1"))
                            {
                                dsResultado = pInsumoLN.InformacionPedido(idPedido, 0, 0, "", 2);
                                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                                if (dsResultado.Tables.Count == 0)
                                    throw new Exception("Error al consultar la información de las especificaciones técnicas. ");

                                if (dsResultado.Tables[0].Rows.Count == 0)
                                    throw new Exception("No existe información de las especificaciones técnicas. ");

                                int idAnexo = 0;
                                int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ANEXO"].ToString(), out idAnexo);

                                if (idAnexo == 0)
                                    throw new Exception("No existe información de las especificaciones técnicas. ");

                                /*int cantidadDetallesEspecificacion = 0;
                                int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["CANTIDAD_ESPECIFICACIONES_DETALLE"].ToString(), out cantidadDetallesEspecificacion);

                                if (cantidadDetallesEspecificacion == 0)
                                    throw new Exception("No existe información de los detalles de las especificaciones técnicas. ");

                                if(cantidadDetallesEspecificacion != gridDet.Rows.Count)
                                    throw new Exception("La información de las especificaciones técnicas está incompleta. ");*/
                            }

                            pInsumoLN = new PedidosLN();
                            dsResultado = pInsumoLN.InformacionPedido(int.Parse(lblIdPedido.Text), int.Parse(ddlTipoPedido.SelectedValue), 1, "", 13);
                            FuncionesVarias fv = new FuncionesVarias();
                            string[] ip = fv.DatosUsuarios();
                            if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                            int registros = 0;
                            int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["REGISTROS"].ToString(), out registros);

                            if (registros > 0)
                                throw new Exception("Las unidades me medida de los artículos de la requisición deben coincidir con el tipo de pedido (BIENES/SERVICIOS)");

                            //AGREGADO ENVIAR EL PEDIDO A CODIFICACIÓN DE PRESUPUESTO CUANDO SEA RECHAZADO POR PPTO, COMPRAS Y EVITAR QUE VUELVA A RECORRER EL CICLO COMPLETO
                            pInsumoLN = new PedidosLN();
                            dsResultado = pInsumoLN.InformacionPedido(idPedido, 0, 0, "", 2);

                            if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                            if (dsResultado.Tables.Count == 0)
                                throw new Exception("Error al consultar el estado del pedido.");

                            if (dsResultado.Tables[0].Rows.Count == 0)
                                throw new Exception("No existe estado asignado al pedido");

                            int idEstadoPedido = 0;
                            int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString(), out idEstadoPedido);

                            //7 - RECHAZADO POR PRESUPUESTO, 9 - RECHAZADO MESA DE ENTRADA DE COMPRAS/PPTO, 18 - RECHAZADO TÉCNICO DE COMPRAS/PPTO
                            if (idEstadoPedido == 7 || idEstadoPedido == 9 || idEstadoPedido == 18)
                                dsResultado = pInsumoLN.AprobacionEncargado(idPedido, 1, "Realizada por el sistema", Session["usuario"].ToString(),ip[0],ip[1],ip[2]);
                            
                            //RECHAZADO POR MESA DE ENTRADA
                            /*else if (idEstadoPedido == 9)
                            {
                                string vCriterio = "";
                                vCriterio += " AND t.anio_solcitud = " + lblNoPedido.Text.Split('-')[1].Trim();
                                vCriterio += " AND t.noSolicitud = " + lblNoPedido.Text.Split('-')[0].Trim();
                                vCriterio += " AND t.id_tipo_documento = 1";
                                vCriterio += " AND t.renglon_ppto = ''S/A''";

                                pAccionLN = new PlanAccionLN();
                                dsResultado = pAccionLN.InformacionAccionDetalles(0, 0, vCriterio, 4);
                                
                                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());
                                
                                //SI EXISTEN DETALLES PENDIENTES DE CODIFICAR, SE ENVÍA A CODIFICACIÓN DE PRESUPUESTO
                                if(dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                                    dsResultado = pInsumoLN.AprobacionEncargado(idPedido, 1, "Realizada por el sistema", Session["usuario"].ToString());
                                else// SI NO EXISTEN DETALLES PENDIENTES DE CODIFICAR SE ENVÍA A APROBACIÓN POR LA MESA DE ENTRADA DE COMPRAS
                                    dsResultado = pInsumoLN.AprobacionPresupuesto(idPedido, 1, "Realizada por el sistema", Session["usuario"].ToString());
                            }*/

                            //CUALQUIER OTRO ESTADO
                            else
                                dsResultado = pInsumoLN.EnviarPedidoARevision(idPedido, 1, Session["usuario"].ToString(),ip[0],ip[1],ip[2]);

                            //AGREGADO ENVIAR EL PEDIDO A CODIFICACIÓN DE PRESUPUESTO CUANDO SEA RECHAZADO POR PPTO, COMPRAS Y EVITAR QUE VUELVA A RECORRER EL CICLO COMPLETO

                            if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                            string estadoActual, mensaje = "";
                            dsResultado = pInsumoLN.InformacionPedido(idPedido, 0, 0, "", 2);
                           
                            if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                            idEstadoPedido = int.Parse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString());
                            estadoActual = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_PEDIDO"].ToString();
                            string tempo = ddlJefes.SelectedItem.Text.ToString();
                            string[] datostecnico = tempo.Split('-');

                            mensaje = " finalizada correctamente!. El pedido fue enviado al estado: " + estadoActual + ". ";
                            EnvioDeCorreos objEC = new EnvioDeCorreos();
                            objEC.EnvioCorreo(planOperativoLN.ObtenerCorreoxUsuario(datostecnico[1].ToString().Trim()), "Nueva Requiscion Ingresada", " Requisicion No.  " + idPedido + ", " + mensaje, ddlSolicitantes.SelectedItem.ToString());
                            


                            if (idEstadoPedido == 6)
                                mensaje += " Comuníquese a la unidad de presupuesto para la codificación de la requisición, extensión: 2409";

                            lblSuccess.Text = "Pedido finalizado correctamente!. El pedido fue enviado al estado: " + estadoActual + " ";
                            //EnvioDeCorreos envio = new EnvioDeCorreos();
                            //envio.EnvioCorreo("alfredo.ochoa@cdag.com.gt", "Nueva Requisicion: "+lblNoPedido.Text,mensaje," ");

                            Response.Redirect("~/Pedido/PedidoGuardado.aspx?No=" + lblNoPedido.Text + "&msg=REQUISICION" + "&acc=" + mensaje);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnEnviar(). " + ex.Message;
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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPrueba_Click(object sender, EventArgs e)
        {
         
        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoPedidoEnc();
                NuevoPedidoDet();

                int anio = 0;
                int idUnidad = 0;
                string id_unidad = ddlDependencia.SelectedItem.Value;
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlDependencia.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlDependencias(ddlJefaturaUnidad, id_unidad);
                    validarPoaIngresoPedido(idUnidad, anio);
                }


                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                InformacionPublica_TribunalHonor();

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
                NuevoPedidoEnc();
                NuevoPedidoDet();

                int anio = 0;
                int idUnidad = 0;
                string id_unidad = ddlJefaturaUnidad.SelectedItem.Value;
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlJefaturaUnidad.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                {
                   
                    validarPoaIngresoPedido(idUnidad, anio);
                }


                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                InformacionPublica_TribunalHonor();

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }
    }
}
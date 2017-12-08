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

namespace AplicacionSIPA1.Pedido.Ajustes
{
    public partial class AjusteIngreso : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private PlanOperativoLN planOperativoLN;
        private PedidosLN pInsumoLN;
        private AJUSTE_PEDIDO aAjusteEN;
        private AJUSTE_PEDIDO_DET aAjusteEN_DET;

        private FuncionesVarias funciones;

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
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                string criterio = " AND t.id_tipo_documento = 0 AND t.id_estado_pedido IN (0) AND t.id_accion = 0";
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlDocumentosAjuste(ddlNoDocumento, criterio);
                ddlNoDocumento_SelectedIndexChanged(new object(), new EventArgs());

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlAjustes(ddlAjustes, 0);

                InformacionPublica_TribunalHonor();

                ddlAnios.Enabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoPoa(). " + ex.Message);
            }
        }

        public void NuevoAjusteEnc()
        {
            try
            {
                lblIdAjuste.Text = "0";
                lblNoAjuste.Text = "0";
                validarEstadoPedido(0);
                lblEstadoAjuste.Text = string.Empty;
                string usuario = Session["usuario"].ToString();
                int idUnidad = 0;
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlAjustes(ddlAjustes, 0);
                pInsumoLN.DdlSolicitantes(ddlSolicitantes, usuario, idUnidad);
                pInsumoLN.DdlJefes(ddlJefes, usuario, idUnidad);               
                txtJustificacion.Text = string.Empty;
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

                int idPedido = 0;
                int.TryParse(lblIdAjuste.Text, out idPedido);

                //filtrarGridDetalles(idPedido);

            }
            catch (Exception ex)
            {
                throw new Exception("NuevoPedidoDet()(). " + ex.Message);
            }
        }

        protected void filtrarGridDetalles()
        {
            try
            {
                gridDet.DataSource = null;
                gridDet.DataBind();
                gridDet.SelectedIndex = -1;

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionAjustesPedido(int.Parse(lblIdAjuste.Text), 0, "", 3);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_PEDIDO_DETALLE"].ToString() != "")
                {
                    gridDet.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridDet.DataBind();

                    int idPedido = 0;
                    int.TryParse(ddlNoDocumento.SelectedValue, out idPedido);
                    decimal cantidadArticulos = 0;
                    decimal totalPedido = 0;

                    dsResultado = pInsumoLN.InformacionPedido(idPedido, 0, 0, "", 2);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["CANTIDAD"].ToString(), out cantidadArticulos);
                    decimal.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["TOTAL"].ToString(), out totalPedido);

                    gridDet.FooterRow.Cells[4].Text = "Totales";
                    gridDet.FooterRow.Cells[6].Text = cantidadArticulos.ToString();
                    gridDet.FooterRow.Cells[8].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalPedido);
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
                NuevoAjusteEnc();
                NuevoPedidoDet();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaIngresoPedido(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                string criterio = " AND t.id_tipo_documento = 0 AND t.id_estado_pedido IN (0) AND t.id_accion = 0";
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlDocumentosAjuste(ddlNoDocumento, criterio);
                ddlNoDocumento_SelectedIndexChanged(new object(), new EventArgs());

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
                NuevoAjusteEnc();
                NuevoPedidoDet();

                int anio = 0;
                int idUnidad = 0;
                string id_unidad = ddlUnidades.SelectedItem.Value;
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlDependencias(ddlDependencias, id_unidad);
                    validarPoaIngresoPedido(idUnidad, anio);
                }
                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                string criterio = " AND t.id_tipo_documento = 0 AND t.id_estado_pedido IN (0) AND t.id_accion = 0";
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlDocumentosAjuste(ddlNoDocumento, criterio);
                ddlNoDocumento_SelectedIndexChanged(new object(), new EventArgs());

                InformacionPublica_TribunalHonor();

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

                string criterio = " AND t.id_tipo_documento = " + rblTipoDocto.SelectedValue + " AND t.id_estado_pedido IN (10) AND t.id_accion = " + ddlAcciones.SelectedValue;
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlDocumentosAjuste(ddlNoDocumento, criterio);
                ddlNoDocumento_SelectedIndexChanged(sender, e);
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
            lblErrorSolicitante.Text = string.Empty;
            lblErrorJefe.Text = string.Empty;
            lblErrorJustificacion.Text = string.Empty;
            lblErrorAccion.Text = string.Empty;
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

                /*if (ddlAjustes.SelectedValue.Equals("0") || ddlAjustes.Items.Count == 0)
                {
                    lblErrorSolicitante.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un solicitante. ";
                }*/

                if (ddlSolicitantes.SelectedValue.Equals("0"))
                {
                    lblErrorSolicitante.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un Solicitante. ";
                } 
                
                if (ddlJefes.SelectedValue.Equals("0"))
                {
                    lblErrorJefe.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un Subgerente/Director. ";
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

                funciones = new FuncionesVarias();
                decimal montoAjuste = 0;
                bool alMenos1Ajuste = false;
                bool errorMontos = false;
                bool errorRenglones = false;

                bool errorValidarDetalle = false;

                for (int i = 0; i < gridDet.Rows.Count; i++)
                {
                    try
                    {
                        montoAjuste = funciones.StringToDecimal((gridDet.Rows[i].FindControl("txtMontoAjuste") as TextBox).Text);
                        (gridDet.Rows[i].FindControl("txtMontoAjuste") as TextBox).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", montoAjuste);

                        if (montoAjuste < 0)
                            throw new Exception();

                        if (montoAjuste > 0 && alMenos1Ajuste == false)
                            alMenos1Ajuste = true;
                    }
                    catch (Exception)
                    {
                        (gridDet.Rows[i].FindControl("lblErrorMontoAjuste") as Label).Text = "¡Ingrese un monto válido!";

                        if (errorMontos == false)
                        {
                            lblError.Text += "Ingrese montos válidos. ";
                            errorMontos = true;
                        }
                    }

                    int idDetalleAccion = 0;
                    int.TryParse(gridDet.DataKeys[i].Values["ID_DETALLE_ACCION"].ToString(), out idDetalleAccion);

                    if (idDetalleAccion <= 0)
                    {
                        (gridDet.Rows[i].FindControl("lblErrorMontoAjuste") as Label).Text = "¡El artículo perdió la codificación de presupuesto!";

                        if (errorRenglones == false)
                        {
                            lblError.Text += "El pedido contiene artículos que perdieron la codificación de presupuesto. ";
                            errorRenglones = true;
                        }
                    }
                }

                if (alMenos1Ajuste == false)
                    lblError.Text += "Ingrese por lo menos un ajuste mayor a Q. 00.00";                

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
                btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = false;
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
                    btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = false;
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa;
                }
                else
                {
                    string estadoPac = dsPoa.Tables[0].Rows[0]["ESTADO_PAC"].ToString();
                    if (false)//(!estadoPac.Split('-')[0].Trim().Equals("6"))
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El PLAN ANUAL DE COMPRAS seleccionado se encuenta en estado: " + estadoPac;
                    }
                    else
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = true;
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
                        lblEstadoAjuste.Text = "";
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = true;
                        lblErrorPoa.Text = lblError.Text = "";
                        pedidoValido = true;
                    }
                    else
                        pedidoValido = false;
                }
                else
                {
                    btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = false;

                    pInsumoLN = new PedidosLN();
                    dsResultado = pInsumoLN.InformacionPedido(idPedido, 0, 0, "", 2);
                    
                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del pedido.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al pedido");

                    string estadoPedido = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_PEDIDO"].ToString();

                    idEstadoPedido = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString(), out idEstadoPedido);

                    //EL PEDIDO ESTÁ EN ESTADO INGRESADO, AL NO SER ENVIADO A REVISIÓN SE PUEDE MODIFICAR
                    if (idEstadoPedido == 10)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = true;
                        lblErrorPoa.Text = lblError.Text = "";
                        pedidoValido = true;
                    }//EL PEDIDO ESTÁ EN ESTADO RECHAZADO BODEGA, RECHAZADO SUB/DIR, RECHAZADO PPTO, RECHAZADO TECNICO COMPRAS/PPTO SE PUEDE MODIFICAR
                    /*else if (idEstadoPedido == 3 || idEstadoPedido == 5 || idEstadoPedido == 7 || idEstadoPedido == 9 || idEstadoPedido == 18)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = true;
                        lblErrorPoa.Text = lblError.Text = "El PEDIDO seleccionado se encuenta en estado: " + lblEstadoAjuste.Text + ", por: " + dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES"].ToString();
                        pedidoValido = true;

                    }*///EL PEDIDO ESTÁ EN ESTADO APROBACIÓN BODEGA, APROBACIÓN SUB/DIR, APROBACIÓN FINANCIERO, CODIFICADO FINANCIERO, ANULADO Y NO SE PUEDE MODIFICAR
                    else //if (idEstadoPedido == 2 || idEstadoPedido == 4 || idEstadoPedido == 6 || idEstadoPedido == 8 || idEstadoPedido == 1)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El PEDIDO seleccionado se encuenta en estado: " + estadoPedido + " y no se puede realizar un ajuste ";
                        pedidoValido = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            btnAnular.Visible = false;
            return pedidoValido;
        }

        protected bool validarEstadoAjuste(int idAjuste)
        {
            bool estadoAjusteValido = false;
            try
            {
                DataSet dsResultado = new DataSet();
                int idEstadoAjuste = 0;

                if (idAjuste == 0)
                {
                    if (lblErrorPoa.Text.Equals("") || lblErrorPoa.Equals(string.Empty))
                    {
                        lblEstadoAjuste.Text = "";
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = true;
                        lblErrorPoa.Text = lblError.Text = "";
                        estadoAjusteValido = true;
                    }
                    else
                        estadoAjusteValido = false;
                }
                else
                {
                    btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = false;

                    pInsumoLN = new PedidosLN();
                    dsResultado = pInsumoLN.InformacionAjustesPedido(0, 0, " AND t.id_ajuste_pedido = " + idAjuste.ToString(), 1);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del ajuste.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al ajuste");

                    lblEstadoAjuste.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_AJUSTE"].ToString();

                    idEstadoAjuste = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_AJUSTE"].ToString(), out idEstadoAjuste);

                    //EL AJUSTE ESTÁ EN ESTADO INGRESADO, AL NO SER ENVIADO A REVISIÓN SE PUEDE MODIFICAR
                    if (idEstadoAjuste == 1)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = true;
                        lblErrorPoa.Text = lblError.Text = "";
                        estadoAjusteValido = true;
                    }//EL AJUSTE ESTÁ EN ESTADO RECHAZADO SUB/DIR, RECHAZADO PPTO
                    else if (idEstadoAjuste == 5 || idEstadoAjuste == 7 )
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = true;
                        lblErrorPoa.Text = lblError.Text = "El AJUSTE seleccionado se encuenta en estado: " + lblEstadoAjuste.Text + ", por: " + dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES"].ToString();
                        estadoAjusteValido = true;

                    }//EL PEDIDO ESTÁ EN ESTADO APROBACIÓN SUB/DIR, APROBACIÓN FINANCIERO, CODIFICADO FINANCIERO Y NO SE PUEDE MODIFICAR
                    else //if (idEstadoPedido == 4 || idEstadoPedido == 6 || idEstadoPedido == 8)
                    {
                        btnAnular.Visible = btnEnviar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El AJUSTE seleccionado se encuenta en estado: " + lblEstadoAjuste.Text + " y no se puede modificar ";
                        estadoAjusteValido = false;
                    }
                }

                //EL AJUSTE ESTÁ EN ESTADO INGRESADO, RECHAZADO BODEGA, RECHAZADO SUB/DIR, RECHAZADO FINANCIERO, SE PUEDE MODIFICAR
                if (idEstadoAjuste == 0 || idEstadoAjuste == 1 || idEstadoAjuste == 3 || idEstadoAjuste == 5 || idEstadoAjuste == 7 || idEstadoAjuste == 9)
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

                //Imprimir
                if (idEstadoAjuste == 8)
                    generarReporte(idAjuste);
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            btnAnular.Visible = false;
            return estadoAjusteValido;
        }

        protected void generarReporte(int idEncabezado)
        {
            try
            {
                if (idEncabezado > 0)
                {

                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    ReportViewer rViewer = new ReportViewer();

                    DataTable dt = new DataTable();
                    GridView gridPlan = new GridView();

                    int idAjustePedido = 0;
                    int.TryParse(ddlAjustes.SelectedValue, out idAjustePedido);

                    string criterio = " AND t.id_ajuste_pedido = " + idAjustePedido;
                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.InformacionAjustesPedido(0, 0, criterio, 1);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se CONSULTÓ la información del ajuste (encabezado): " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                    ReportDataSource RD = new ReportDataSource();
                    RD.Value = dsResultado.Tables[1];
                    RD.Name = "DataSet1";

                    rViewer.LocalReport.DataSources.Clear();
                    rViewer.LocalReport.DataSources.Add(RD);
                    rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes/rptCOM_FOR_64.rdlc";
                    rViewer.LocalReport.ReportPath = @"Reportes\\rptCOM_FOR_64.rdlc";
                    rViewer.LocalReport.Refresh();


                    byte[] bytes = rViewer.LocalReport.Render(
                       "PDF", null, out mimeType, out encoding,
                        out extension,
                       out streamids, out warnings);

                    string nombreReporte = "Ajuste";

                    string direccion = Server.MapPath("ArchivoPdf");
                    direccion = (direccion + ("\\\\" + (""
                                + (nombreReporte + ".pdf"))));

                    FileStream fs = new FileStream(direccion,
                       FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();

                    String reDireccion = "\\ArchivoPDF/";
                    reDireccion += "\\" + "" + nombreReporte + ".pdf";


                    string jScript = "javascript:window.open('" + reDireccion + "','AJUSTES'," + "'directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=750, height=400');";
                    btnImprimir.Attributes.Add("onclick", jScript);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnVerReporte(). " + ex.Message;
            }
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idAjustePedido, idPoa, idUnidad, anio, idTipoDocumento, idPedido, noSolicitud, anioSolicitud, idSolicitante, idSubgerenteDirector = 0;
                int.TryParse(lblIdAjuste.Text, out idAjustePedido);
                int.TryParse(lblIdPoa.Text, out idPoa);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(rblTipoDocto.SelectedValue, out idTipoDocumento);
                int.TryParse(ddlNoDocumento.SelectedValue, out idPedido);
                int.TryParse(ddlNoDocumento.SelectedItem.Text.Split('-')[1].Trim(), out noSolicitud);
                int.TryParse(ddlNoDocumento.SelectedItem.Text.Split('-')[0].Trim(), out anioSolicitud);
                int.TryParse(ddlSolicitantes.SelectedValue, out idSolicitante);
                int.TryParse(ddlJefes.SelectedValue, out idSubgerenteDirector);

                if (validarControlesABC())
                {
                    if (validarEstadoPedido(idPedido))
                    {
                        if (validarEstadoAjuste(idAjustePedido))
                        {
                            aAjusteEN = new AJUSTE_PEDIDO();
                            aAjusteEN.VID_AJUSTE_PEDIDO = idAjustePedido.ToString();
                            aAjusteEN.VID_POA = idPoa.ToString();
                            aAjusteEN.VID_UNIDAD = idUnidad.ToString();
                            aAjusteEN.VANIO = anio.ToString();
                            aAjusteEN.VID_TIPO_DOCUMENTO = idTipoDocumento.ToString();
                            aAjusteEN.VID_PEDIDO = idPedido.ToString();
                            aAjusteEN.VNO_SOLICITUD = noSolicitud.ToString();
                            aAjusteEN.VANIO_SOLICITUD = anioSolicitud.ToString();
                            aAjusteEN.VFECHA_AJUSTE = "";
                            aAjusteEN.VJUSTIFICACION = txtJustificacion.Text;
                            aAjusteEN.VOBSERVACIONES = "";
                            aAjusteEN.VID_ESTADO_AJUSTE = "1";
                            aAjusteEN.VANULADO = "0";
                            aAjusteEN.VID_SOLICITANTE = idSolicitante.ToString();
                            aAjusteEN.VID_SUBGERENTE_DIRECTOR = idSubgerenteDirector.ToString();
                            aAjusteEN.VID_ANALISTA_PPTO = "0";
                            aAjusteEN.VUSUARIO = Session["usuario"].ToString();
                            aAjusteEN.VOPCION = "1";

                            int idAjustePedidoDet, idPedidoDetalle, idPac = 0;

                            aAjusteEN_DET = new AJUSTE_PEDIDO_DET();
                            DataSet dsDetalles = aAjusteEN_DET.ArmarDsAjustePedidoDetalles();

                            funciones = new FuncionesVarias();
                            int idDetalleAccion = 0;
                            decimal montoAjuste = 0;

                            for (int i = 0; i < gridDet.Rows.Count; i++)
                            {
                                int.TryParse(gridDet.DataKeys[i].Values["ID_AJUSTE_PEDIDO_DET"].ToString(), out idAjustePedidoDet);
                                int.TryParse(gridDet.DataKeys[i].Values["ID_PEDIDO_DETALLE"].ToString(), out idPedidoDetalle);
                                int.TryParse(gridDet.DataKeys[i].Values["ID_PAC"].ToString(), out idPac);
                                int.TryParse(gridDet.DataKeys[i].Values["ID_DETALLE_ACCION"].ToString(), out idDetalleAccion);
                                montoAjuste = funciones.StringToDecimal((gridDet.Rows[i].FindControl("txtMontoAjuste") as TextBox).Text);

                                DataRow dr = dsDetalles.Tables[0].NewRow();

                                dr["VID_AJUSTE_PEDIDO_DET"] = idAjustePedidoDet;
                                dr["VID_AJUSTE_PEDIDO"] = idAjustePedido;
                                dr["VID_PEDIDO_DETALLE"] = idPedidoDetalle;
                                dr["VMONTO_AJUSTE"] = montoAjuste;
                                dr["VOBSERVACIONES"] = "";
                                dr["VID_DETALLE_ACCION"] = idDetalleAccion;
                                dr["VUSUARIO"] = Session["usuario"];
                                dr["VOPCION"] = "1";

                                dsDetalles.Tables[0].Rows.Add(dr);
                            }
                            FuncionesVarias fv = new FuncionesVarias();
                            string[] ip = fv.DatosUsuarios();
                            pInsumoLN = new PedidosLN();
                            DataSet dsResultado = pInsumoLN.AlmacenarAjustePedido(aAjusteEN, dsDetalles,Session["usuario"].ToString(),ip[0],ip[1],ip[2]);

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se INSERTÓ/ACTUALIZÓ el ajuste: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idAjustePedido);
                            lblIdAjuste.Text = lblNoAjuste.Text = idAjustePedido.ToString();

                            pInsumoLN.DdlAjustes(ddlAjustes, idPedido);
                            ListItem item = ddlAjustes.Items.FindByValue(lblIdAjuste.Text);

                            if (item != null)
                            {
                                ddlAjustes.SelectedValue = lblIdAjuste.Text;
                                ddlAjustes_SelectedIndexChanged(sender, e);
                            }
                            filtrarGridPpto();
                            lblSuccess.Text = "Solicitud de ajuste No. " + lblNoAjuste.Text + " ALMACENADA/MODIFICADA exitosamente: ";

                            dsResultado = pInsumoLN.InformacionAjustesPedido(idAjustePedido, 0, "", 4);

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se VALIDARON los techos del PAC: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                                lblError.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_SALDO"].ToString();

                            dsResultado = pInsumoLN.InformacionAjustesPedido(idAjustePedido, 0, "", 5);

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se VALIDARON los techos de los renglones presupuestarios: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                                lblError.Text += dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_SALDO"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar(). " + ex.Message;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoEncabezadoPoa();
                NuevoAjusteEnc();
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
            //PostBackUrl="~/Pedido/PedidoListado.aspx"
            Response.Redirect("~/Pedido/PedidoListado.aspx?Anio=" + ddlAnios.SelectedItem.Value + "&unidad=" + ddlUnidades.SelectedItem.Value);
        }

        protected void ddlAjustes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idPedido, anioSolicitud, noSolicitud, idTipoDocumento = 0;
                int.TryParse(ddlNoDocumento.SelectedValue, out idPedido);

                if (idPedido == 0)
                {
                    gridDet.DataSource = null;
                    gridDet.DataBind();
                }
                else
                {
                    int idAjustePedido = 0;
                    int.TryParse(ddlAjustes.SelectedItem.Text.Split('-')[0].Trim(), out idAjustePedido);

                    if (idAjustePedido == 0)
                    {
                        NuevoAjusteEnc();
                        pInsumoLN = new PedidosLN();
                        DataSet dsResultado = pInsumoLN.InformacionAjustesPedido(idPedido, 0, "", 2);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables.Count == 0)
                            throw new Exception("Error al consultar la información de los detalles del ajuste.");

                        if (dsResultado.Tables[0].Rows.Count == 0)
                            throw new Exception("No existe información de los detalles del ajuste");

                        gridDet.DataSource = dsResultado.Tables["BUSQUEDA"];
                        gridDet.DataBind();
                    }
                    else
                    {
                        lblIdAjuste.Text = lblNoAjuste.Text = idAjustePedido.ToString();
                        string criterio = " AND t.id_ajuste_pedido = " + idAjustePedido;
                        pInsumoLN = new PedidosLN();
                        DataSet dsResultado = pInsumoLN.InformacionAjustesPedido(0, 0, criterio, 1);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables.Count == 0)
                            throw new Exception("Error al consultar la información del ajuste.");

                        if (dsResultado.Tables[0].Rows.Count == 0)
                            throw new Exception("No existe información del ajuste");

                        lblEstadoAjuste.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_AJUSTE"].ToString();
                        int idSolicitante, idJefe = 0;

                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_SOLICITANTE"].ToString(), out idSolicitante);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_SUBGERENTE_DIRECTOR"].ToString(), out idJefe);

                        ListItem item = ddlSolicitantes.Items.FindByValue(idSolicitante.ToString());
                        if (item != null)
                            ddlSolicitantes.SelectedValue = idSolicitante.ToString();

                        item = ddlJefes.Items.FindByValue(idJefe.ToString());
                        if (item != null)
                            ddlJefes.SelectedValue = idJefe.ToString();

                        txtJustificacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["JUSTIFICACION"].ToString();

                        int.TryParse(ddlNoDocumento.SelectedItem.Text.Split('-')[0].Trim(), out anioSolicitud);
                        int.TryParse(ddlNoDocumento.SelectedItem.Text.Split('-')[1].Trim(), out noSolicitud);
                        int.TryParse(rblTipoDocto.SelectedValue, out idTipoDocumento);

                        filtrarGridDetalles();

                        validarEstadoPedido(idPedido);
                        validarEstadoAjuste(idAjustePedido);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ddlAjustes(). " + ex.Message);
            }
        }

        protected void ddlJefes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPedido = 0;
                int.TryParse(lblIdAjuste.Text, out idPedido);

                if (idPedido  == 0)
                    throw new Exception("No existe Bien/Servicio para eliminar");

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.EliminarEncabezado(idPedido);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                lblSuccess.Text = "Pedido eliminado correctamente!";

                Response.Redirect("NoPedido.aspx?No=" + lblNoAjuste.Text + "&msg=PEDIDO" + "&acc=ELIMINADO");
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

                int idAjustePedido, idPoa, idUnidad, anio, idTipoDocumento, idPedido, noSolicitud, anioSolicitud, idSolicitante, idSubgerenteDirector = 0;
                int.TryParse(lblIdAjuste.Text, out idAjustePedido);

                if (idAjustePedido == 0)
                    throw new Exception("No existe ajuste para finalizar");

                FuncionesVarias fv = new FuncionesVarias();
                string[] ip = fv.DatosUsuarios();

                int.TryParse(lblIdPoa.Text, out idPoa);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(rblTipoDocto.SelectedValue, out idTipoDocumento);
                int.TryParse(ddlNoDocumento.SelectedValue, out idPedido);
                int.TryParse(ddlNoDocumento.SelectedItem.Text.Split('-')[1].Trim(), out noSolicitud);
                int.TryParse(ddlNoDocumento.SelectedItem.Text.Split('-')[0].Trim(), out anioSolicitud);
                int.TryParse(ddlSolicitantes.SelectedValue, out idSolicitante);
                int.TryParse(ddlJefes.SelectedValue, out idSubgerenteDirector);

                if (validarControlesABC())
                {
                    if (validarEstadoPedido(idPedido))
                    {
                        if (validarEstadoAjuste(idAjustePedido))
                        {
                            if (idAjustePedido == 0)
                                throw new Exception("No existe ajuste para finalizar");

                            pInsumoLN = new PedidosLN();
                            DataSet dsResultado = new DataSet();

                            dsResultado = pInsumoLN.InformacionAjustesPedido(idAjustePedido, 0, "", 4);

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se VALIDARON los techos del PAC: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                                lblError.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_SALDO"].ToString();

                            dsResultado = pInsumoLN.InformacionAjustesPedido(idAjustePedido, 0, "", 5);

                            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                                throw new Exception("No se VALIDARON los techos de los renglones presupuestarios: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                            if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                                lblError.Text += dsResultado.Tables["BUSQUEDA"].Rows[0]["MENSAJE_SALDO"].ToString();

                            if (lblError.Text.Equals("") || lblError.Text.Equals(string.Empty))
                            {
                                dsResultado = pInsumoLN.EnviarAjustePedidoARevision(idAjustePedido, 0, Session["usuario"].ToString(),ip[0],ip[1],ip[2]);

                            if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                            string estadoActual, mensaje = "";
                            dsResultado = pInsumoLN.InformacionAjustesPedido(idAjustePedido, 0, " AND t.id_ajuste_pedido = " + int.Parse(lblIdAjuste.Text), 1);

                            if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                                estadoActual = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_AJUSTE"].ToString();
                                lblEstadoAjuste.Text = estadoActual;

                            mensaje = " Ajuste finalizado correctamente!. El ajuste fue enviado al estado: " + estadoActual + ". Comuníquese con su subgerente o director para aprobación del ajuste";

                                lblSuccess.Text = "Ajuste finalizado correctamente!. El ajuste fue enviado al estado: " + estadoActual + ". ";

                                Response.Redirect("NoAjuste.aspx?No=" + lblNoAjuste.Text + "&msg=" + mensaje + "&acc=" + "ENVIADO");
                            }
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

        protected void rblTipoDocto_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void ddlSolicitantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void ddlNoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idPedido = 0;
                int.TryParse(ddlNoDocumento.SelectedValue, out idPedido);

                pInsumoLN = new PedidosLN();
                if (idPedido == 0)
                {
                    pInsumoLN.DdlAjustes(ddlAjustes, 0);
                    ddlAjustes.Enabled = true;
                }
                else
                {
                  //  ddlAjustes.Enabled = false;
                    //Ajustes ya existentes en función del documento seleccionado
                    pInsumoLN.DdlAjustes(ddlAjustes, idPedido);
                    validarEstadoPedido(idPedido);
                }

                ddlAjustes_SelectedIndexChanged(sender, e);

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlNoDocumento(). " + ex.Message;
            }
        }

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoAjusteEnc();
                NuevoPedidoDet();

                int anio = 0;
                int idUnidad = 0;
                string id_unidad = ddlDependencias.SelectedItem.Value;
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlDependencias.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlDependencias(ddlJefaturaUnidades, id_unidad);
                    validarPoaIngresoPedido(idUnidad, anio);
                }
                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                string criterio = " AND t.id_tipo_documento = 0 AND t.id_estado_pedido IN (0) AND t.id_accion = 0";
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlDocumentosAjuste(ddlNoDocumento, criterio);
                ddlNoDocumento_SelectedIndexChanged(new object(), new EventArgs());

                InformacionPublica_TribunalHonor();

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlJefaturaUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoAjusteEnc();
                NuevoPedidoDet();

                int anio = 0;
                int idUnidad = 0;
                string id_unidad = ddlJefaturaUnidades.SelectedItem.Value;
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlJefaturaUnidades.SelectedValue, out idUnidad);

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

                string criterio = " AND t.id_tipo_documento = 0 AND t.id_estado_pedido IN (0) AND t.id_accion = 0";
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlDocumentosAjuste(ddlNoDocumento, criterio);
                ddlNoDocumento_SelectedIndexChanged(new object(), new EventArgs());

                InformacionPublica_TribunalHonor();

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }
    }
}
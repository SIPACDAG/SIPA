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
    public partial class PedidoAnulacion : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private UsuariosLN uUsuariosLN;
        private PedidosLN pInsumoLN;
        private PedidosEN pInsumoEN;

        private FuncionesVarias funciones;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    NuevoEncabezadoPoa();
                    NuevaAprobacion();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        public void NuevaAprobacion()
        {
            try
            {
                limpiarControlesError();

                btnReactivar.Visible = false;

                filtrarDvPedidos();
                filtrarGridDetalles();
                filtrarGridPpto();
                txtObser.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("NuevaAprobacion()" + ex.Message);
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
                uUsuariosLN = new UsuariosLN();

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

                uUsuariosLN.dropUnidad(ddlUnidades);

                if (ddlUnidades.Items.Count == 1)
                {
                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoaAprobacionPedido(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                    }
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Todas las acciones >>";
                ddlAnios.Enabled = ddlUnidades.Enabled = ddlAcciones.Enabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoPoa(). " + ex.Message);
            }
        }

        protected void filtrarDvPedidos()
        {
            try
            {
                dvPedido.DataSource = null;
                dvPedido.DataBind();

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = new DataSet();

                int idEncabezado, idtipoDocto, anio = 0;

                int.TryParse(txtNo.Text, out idEncabezado);
                int.TryParse(rblTipoDocto.SelectedValue, out idtipoDocto);
                int.TryParse(ddlAnios.SelectedValue, out anio);

                if (false)//(!lblErrorPoa.Text.Equals(string.Empty))
                {
                    dvPedido.DataSource = null;
                    dvPedido.DataBind();
                }
                else
                {
                    dsResultado = pInsumoLN.InformacionPedido(anio, 0, 0, "", 7);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                    {
                        dvPedido.DataSource = dsResultado.Tables["BUSQUEDA"];
                        dvPedido.DataBind();

                        string filtro = string.Empty;

                        object obj = dvPedido.DataSource;
                        System.Data.DataTable tbl = dvPedido.DataSource as System.Data.DataTable;
                        System.Data.DataView dv = tbl.DefaultView;

                        filtro = "0 = 0";

                        if (!ddlAnios.SelectedValue.Equals("0"))
                            filtro += " AND anio_solicitud = " + ddlAnios.SelectedValue;

                        if (!ddlUnidades.SelectedValue.Equals("0"))
                            filtro += " AND id_unidad = " + ddlUnidades.SelectedValue;

                        if (!rblTipoDocto.SelectedValue.Equals("0"))
                            filtro += " AND id_tipo_documento = " + rblTipoDocto.SelectedValue;

                        if (txtNo.Text.Equals("") == false || txtNo.Text.Equals(string.Empty) == false)
                            filtro += " AND no_solicitud = " + txtNo.Text;

                        if (!ddlAcciones.SelectedValue.Equals("0"))
                            filtro += " AND id_accion = " + ddlAcciones.SelectedValue;

                        filtro += " AND id_estado_pedido IN (3, 5, 7, 9)";

                        dv.RowFilter = filtro;
                        dvPedido.DataSource = dv;
                        dvPedido.DataBind();

                        int idPedido = 0;

                        if (dvPedido.SelectedValue != null)
                        {
                            int.TryParse(dvPedido.SelectedValue.ToString(), out idPedido);

                            validarEstadoPedido(idPedido);

                            string tipoDocumento = "";

                            if (tipoDoc() == 1)
                                tipoDocumento = "R";
                            else if (tipoDoc() == 2)
                                tipoDocumento = "V";

                            if (tipoDocumento.Equals("R") || tipoDocumento.Equals("V"))
                            {
                                string jScript = "javascript:window.open('ETVoBoN2.aspx?No=" + dvPedido.SelectedValue.ToString() + "&OptB=true&TipoD=" + tipoDocumento + "', '_blank');";
                                LinkButton lbAnexo = (LinkButton)(dvPedido.Rows[13].FindControl("LinkButton1"));

                                if (lbAnexo.Text.Equals("Especificaciones"))
                                    lbAnexo.Attributes.Add("onclick", jScript);
                                else
                                    lbAnexo.Attributes.Clear();
                            }
                        }
                    }
                    else
                    {
                        dvPedido.DataSource = null;
                        dvPedido.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarDvPedidos()" + ex.Message);
            }
        }

        protected void filtrarGridDetalles()
        {
            try
            {
                gridDetalle.DataSource = null;
                gridDetalle.DataBind();
                gridDetalle.SelectedIndex = -1;

                int idSalida, idTipoSalida;
                idSalida = idTipoSalida = 0;

                if (dvPedido.SelectedValue != null)
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idSalida);

                int.TryParse(rblTipoDocto.SelectedValue, out idTipoSalida);

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.DetallesPedidoAprobacion(idSalida, idTipoSalida, "", 1);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridDetalle.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridDetalle.DataBind();

                    decimal cantidadArticulos, cantidadCompras, costoUPedido, costoUCompras, costoPedido, costoCompras, iva = 0;

                    string sCantidadArticulos = dsResultado.Tables["BUSQUEDA"].Compute("SUM(CANTIDAD)", "").ToString();
                    string sCantidadCompras = dsResultado.Tables["BUSQUEDA"].Compute("SUM(CANTIDAD_COMPRAS)", "").ToString();

                    string sCostoUpedido = dsResultado.Tables["BUSQUEDA"].Compute("SUM(COSTO_ESTIMADO)", "").ToString();
                    string sCostoUCompras = dsResultado.Tables["BUSQUEDA"].Compute("SUM(COSTO_U_COMPRAS)", "").ToString();

                    string sSubtotalPedido = dsResultado.Tables["BUSQUEDA"].Compute("SUM(SUBTOTAL)", "").ToString();
                    string sSubtotalCompras = dsResultado.Tables["BUSQUEDA"].Compute("SUM(SUBTOTAL_COMPRAS)", "").ToString();

                    string sIva = dsResultado.Tables["BUSQUEDA"].Compute("SUM(IVA)", "").ToString();

                    decimal.TryParse(sCantidadArticulos, out cantidadArticulos);
                    decimal.TryParse(sCantidadCompras, out cantidadCompras);

                    decimal.TryParse(sCostoUpedido, out costoUPedido);
                    decimal.TryParse(sCostoUCompras, out costoUCompras);

                    decimal.TryParse(sSubtotalPedido, out costoPedido);
                    decimal.TryParse(sSubtotalCompras, out costoCompras);

                    decimal.TryParse(sIva, out iva);

                    gridDetalle.FooterRow.Cells[3].Text = "Totales";

                    gridDetalle.FooterRow.Cells[5].Text = cantidadArticulos.ToString();
                    gridDetalle.FooterRow.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", costoPedido);
                }
                else
                {
                    gridDetalle.DataSource = null;
                    gridDetalle.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridDetalles(). " + ex.Message);
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

                if (dvPedido.Rows.Count > 0)
                    int.TryParse(dvPedido.DataKey[1].ToString(), out idSalida);

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

        private int tipoDoc()
        {
            int tipo = 0;
            if (dvPedido.Rows.Count > 0)
            {

                switch (dvPedido.Rows[3].Cells[1].Text)
                {
                    case "REQUISICION":
                        tipo = 1;
                        break;
                    case "VALE":
                        tipo = 2;
                        break;
                    case "TRANSFERENCIA, APOYO U OTRO GASTO":
                        tipo = 3;
                        break;
                }
            }
            return tipo;
        }

        /*private int tipoDoc()
        {
            int tipo = 0;
            if (dvPedido.Rows.Count > 0)
            {

                switch (dvPedido.Rows[1].Cells[1].Text)
                {
                    case "PEDIDO": tipo = 1;
                        break;
                    case "VALE": tipo = 2;
                        break;
                    case "GASTO": tipo = 3;
                        break;
                }
            }
            return tipo;
        }*/

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                lblErrorPoa.Text = string.Empty;
                if (anio > 0 && idUnidad > 0)
                    validarPoaAprobacionPedido(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Todas las acciones >>";
                NuevaAprobacion();
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
                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                lblErrorPoa.Text = string.Empty;
                if (anio > 0 && idUnidad > 0)
                    validarPoaAprobacionPedido(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Todas las acciones >>";
                NuevaAprobacion();
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
                int idAccion = 0;
                int.TryParse(ddlAcciones.SelectedValue, out idAccion);
                NuevaAprobacion();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones(). " + ex.Message;
            }
        }

        protected void limpiarControlesError()
        {
            lblErrorObser.Text = string.Empty;
            lblError.Text = lblSuccess.Text = string.Empty;
        }

        protected bool validarPoaAprobacionPedido(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                btnReactivar.Visible = false;
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
                if (!estadoPoa.Split('-')[0].Trim().Equals("9"))
                {
                    btnReactivar.Visible = false;
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa;
                }
                else
                {
                    string estadoPac = dsPoa.Tables[0].Rows[0]["ESTADO_PAC"].ToString();
                    if (!estadoPac.Split('-')[0].Trim().Equals("6"))
                    {
                        btnReactivar.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El PLAN ANUAL DE COMPRAS seleccionado se encuenta en estado: " + estadoPac;
                    }
                    else
                    {
                        btnReactivar.Visible = true;
                        poaValido = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            return poaValido;
        }

        protected bool validarEstadoPedido(int idPedido)
        {
            bool pedidoValido = false;
            btnReactivar.Visible = false;
            btnAnular.Visible = false;

            try
            {
                if (idPedido == 0)
                {
                    btnReactivar.Visible = true;
                    lblErrorPoa.Text = lblError.Text = "";
                    pedidoValido = true;
                }
                else
                {

                    int anio, idTipoDocumento;
                    anio = idTipoDocumento = 0;

                    int.TryParse(ddlAnios.SelectedValue, out anio);
                    int.TryParse(rblTipoDocto.SelectedValue, out idTipoDocumento);

                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.InformacionPedido(anio, idPedido, idTipoDocumento, "ESTADO", 7);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del pedido.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al pedido");

                    string estadoPedido = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_PEDIDO"].ToString();

                    int idEstado = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString(), out idEstado);

                    //EL PEDIDO ESTÁ EN ESTADO APROBACIÓN DE PPTO
                    if (idEstado != 3 && idEstado != 5 && idEstado != 7 && idEstado != 9)
                    {
                        btnAnular.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "La REQUISICIÓN/VALE/GASTO seleccionado se encuentra en estado: " + estadoPedido + " y no se puede ANULAR!";
                        pedidoValido = false;
                    }
                    else
                    {
                        btnAnular.Visible = true;
                        lblErrorPoa.Text = lblError.Text = string.Empty;
                        pedidoValido = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            return pedidoValido;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void dvPedido_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            try
            {
                limpiarControlesError();
                dvPedido.PageIndex = e.NewPageIndex;
                NuevaAprobacion();
            }
            catch (Exception ex)
            {
                lblError.Text = "Page_LoadComplete(). " + ex.Message;
            }

        }

        protected DataSet armarDsDet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable("DETALLES"));
            ds.Tables[0].Columns.Add("ID_PEDIDO", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VID_TIPO_DOCUMENTO", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VID_PEDIDO_DETALLE", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VID_PROVEEDOR", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VID_TIPO_DOCUMENTO_COMPRA", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VNO_ORDEN_COMPRA", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VCANTIDAD_COMPRA", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VCOSTO_U_COMPRAS", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VCOSTO_REAL", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VIVA", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VFECHA_ORDEN_COMPRA", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("VLIQUIDACIONES_PARCIALES", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("USUARIO", Type.GetType("System.String"));

            return ds;
        }


        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idSalida, idTipoSalida;
                idSalida = idTipoSalida = 0;
                if (dvPedido.SelectedValue != null)
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idSalida);

                int.TryParse(rblTipoDocto.SelectedValue, out idTipoSalida);

                if (idSalida == 0)
                    throw new Exception("Seleccione un PEDIDO!");

                string s = txtObser.Text;
                s = s.Replace('\'', ' ');
                s = s.Trim();
                txtObser.Text = s;

                if (txtObser.Text.Equals(string.Empty))
                    lblError.Text = "Llene el campo de observaciones.";
                else
                {
                    pInsumoLN = new PedidosLN();
                    string usuario = Session["usuario"].ToString();
                    string observaciones = txtObser.Text;
                    DataSet dsResultado = pInsumoLN.RechazoTecnico(idSalida, idTipoSalida, txtObser.Text, Session["usuario"].ToString());

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se RECHAZÓ la solicitud: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    string noSolicitud = dvPedido.Rows[1].Cells[1].Text;
                    txtNo.Text = string.Empty;

                    NuevaAprobacion();
                    lblSuccess.Text = "Solicitud No. " + noSolicitud + " RECHAZADA con éxito!";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnRechazar(). " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            NuevaAprobacion();
        }

        protected void rblTipoDocto_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
            dvPedido.DataSource = gridDetalle.DataSource = gridSaldos.DataSource = null;
            dvPedido.DataBind();
            gridDetalle.DataBind();
            gridSaldos.DataBind();

            NuevaAprobacion();
        }

        protected bool esEntero(string valor)
        {
            try
            {
                int.Parse(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected bool esDecimal(string valor)
        {
            try
            {
                decimal.Parse(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected bool validarEstadoAnexo()
        {
            bool estadoValido = false;
            try
            {
                int tipoDocumento = tipoDoc();
                if ((tipoDocumento == 1) == false && (tipoDocumento == 2) == false)
                    return true;

                LinkButton lbAnexo = (LinkButton)(dvPedido.Rows[13].FindControl("LinkButton1"));

                if (lbAnexo.Text.Equals("Especificaciones") == false)
                    return true;

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPedido(int.Parse(dvPedido.SelectedValue.ToString()), tipoDocumento, 0, "ENCABEZADO", 8);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                string idEstado = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO"].ToString();

                if (idEstado.Equals("5"))
                    estadoValido = true;
                else
                    lblError.Text = "validarEstadoAnexo(). Las especificaciones deben ser aprobadas!";//throw new Exception("Las especificaciones deben ser aprobadas!");

                return estadoValido;
            }
            catch (Exception ex)
            {
                throw new Exception("validarEstadoAnexo(). " + ex.Message);
            }
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idSalida, idTipoSalida;
                idSalida = idTipoSalida = 0;
                if (dvPedido.SelectedValue != null)
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idSalida);

                int.TryParse(rblTipoDocto.SelectedValue, out idTipoSalida);

                if (idSalida == 0)
                    throw new Exception("Seleccione un PEDIDO!");

                string s = txtObser.Text;
                s = s.Replace('\'', ' ');
                s = s.Trim();
                txtObser.Text = s;

                if (txtObser.Text.Equals(string.Empty))
                    lblErrorObser.Text = lblError.Text = "Llene el campo de observaciones.";
                else
                {
                    pInsumoLN = new PedidosLN();
                    string usuario = Session["usuario"].ToString();
                    string observaciones = txtObser.Text;
                    DataSet dsResultado = pInsumoLN.AnulacionTecnico(idSalida, idTipoSalida, txtObser.Text, Session["usuario"].ToString());

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se RECHAZÓ la solicitud: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    string noSolicitud = dvPedido.Rows[1].Cells[1].Text;
                    txtNo.Text = string.Empty;

                    NuevaAprobacion();
                    lblSuccess.Text = "Solicitud No. " + noSolicitud + " ANULADA con éxito!";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnAnular(). " + ex.Message;
            }
        }
    }
}
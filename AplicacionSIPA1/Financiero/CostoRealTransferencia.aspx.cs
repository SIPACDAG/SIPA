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

namespace AplicacionSIPA1.Financiero
{
    public partial class CostoRealTransferencia : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private UsuariosLN uUsuariosLN;
        private PedidosLN pInsumoLN;
        private PedidosEN pInsumoEN;


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

                chkConstantes.Checked = false;
                chkConstantes_CheckedChanged(new Object(), new EventArgs());

                btnAprobar.Visible = btnRechazar.Visible = false;

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
                        dsResultado = pInsumoLN.InformacionPedido(idEncabezado, idtipoDocto, anio, Session["usuario"].ToString(), 11);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                    {
                        dvPedido.DataSource = dsResultado.Tables["BUSQUEDA"];
                        dvPedido.DataBind();

                        btnAprobar.Visible = btnRechazar.Visible = true;

                        int idEstadoPedido = 0;
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString(), out idEstadoPedido);

                        btnAprobar.Visible = btnRechazar.Visible = true;
                        if (idEstadoPedido == 12)
                        {
                            lblError.Text = "El documento seleccionado ya tiene asignado valor real.";
                            btnAprobar.Visible = btnRechazar.Visible = false;
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

                if(dvPedido.SelectedValue != null)
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

                    gridDetalle.FooterRow.Cells[10].Text = cantidadCompras.ToString();
                    gridDetalle.FooterRow.Cells[12].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", costoCompras);

                    gridDetalle.FooterRow.Cells[13].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", iva);
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

                if(dvPedido.Rows.Count > 0)
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
            lblErrorFechaC.Text = lblErrorOrdenC.Text = lblErrorProveedorC.Text = string.Empty;
            lblErrorLiquidacionesC.Text = string.Empty;
            lblErrorObser.Text = string.Empty;
            lblError.Text = lblSuccess.Text = string.Empty;
            lblErrorCalculo.Text = string.Empty;
        }

        protected bool validarPoaAprobacionPedido(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                btnAprobar.Visible = btnRechazar.Visible = false;
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
                    btnAprobar.Visible = btnRechazar.Visible = false;
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa;
                }
                else
                {
                    string estadoPac = dsPoa.Tables[0].Rows[0]["ESTADO_PAC"].ToString();
                    if (!estadoPac.Split('-')[0].Trim().Equals("6"))
                    {
                        btnAprobar.Visible = btnRechazar.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El PLAN ANUAL DE COMPRAS seleccionado se encuenta en estado: " + estadoPac;
                    }
                    else
                    {
                        btnAprobar.Visible = btnRechazar.Visible = true;
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
            try
            {
                if (idPedido == 0)
                {
                    btnAprobar.Visible = btnRechazar.Visible = true;
                    lblErrorPoa.Text = lblError.Text = "";
                    pedidoValido = true;
                }
                else
                {
                    btnAprobar.Visible = btnRechazar.Visible = false;

                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.InformacionPedido(idPedido, 0, 0, "", 2);
                    
                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del pedido.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al pedido");

                    string estadoPedido = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO_PEDIDO"].ToString();

                    int idEstadoPedido = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString(), out idEstadoPedido);

                    //EL PEDIDO NO ESTÁ EN ESTADO APROBACIÓN DE SUBGERENTE/DIRECTOR DE UNIDAD
                    if (idEstadoPedido != 4)
                    {
                        btnAprobar.Visible = btnRechazar.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El PEDIDO seleccionado se encuenta en estado: " + estadoPedido + " y no se puede modificar ";
                        pedidoValido = false;
                    }
                    else
                    {
                        btnAprobar.Visible = btnRechazar.Visible = true;
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

        protected void btnAprobar_Click(object sender, EventArgs e)
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

                if (validarControlesABC() == true)
                {

                    DataSet dsDetalles = armarDsDet();
                    int filas = gridDetalle.Rows.Count;

                    for (int i = 0; i < gridDetalle.Rows.Count; i++)
                    {
                        string vid_pedido, vid_tipo_documento, vid_pedido_detalle, vid_proveedor, vno_orden_compra, vcantidad_compra, vcosto_unitario_compra, vcosto_real, viva, vfecha_orden_compra, vliquidaciones_parciales = "";
                        vid_pedido = dvPedido.SelectedValue.ToString();
                        vid_tipo_documento = rblTipoDocto.SelectedValue;
                        vid_pedido_detalle = gridDetalle.DataKeys[i].Value.ToString();
                        vid_proveedor = (gridDetalle.Rows[i].FindControl("dropProveedor") as DropDownList).SelectedValue;
                        vno_orden_compra = (gridDetalle.Rows[i].FindControl("txtNoOrdenDetalle") as TextBox).Text;
                        vcantidad_compra = (gridDetalle.Rows[i].FindControl("txtCantidadReal") as TextBox).Text;
                        vcosto_unitario_compra = (gridDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox).Text;
                        vcosto_real = (gridDetalle.Rows[i].FindControl("txtCostoReal") as TextBox).Text;
                        viva = (gridDetalle.Rows[i].FindControl("txtIva") as TextBox).Text;

                        vcosto_unitario_compra = stringToDecimalString(vcosto_unitario_compra);
                        vcosto_real = stringToDecimalString(vcosto_real);
                        viva = stringToDecimalString(viva);

                        DataSet dsFecha = stringToFechaMySql((gridDetalle.Rows[i].FindControl("txtFechaOrdenDetalle") as TextBox).Text);
                        DataRow dr = dsFecha.Tables[0].Rows[0];

                        vfecha_orden_compra = dr["ANIO"] + "-" + dr["MES"] + "-" + dr["DIA"];
                        vliquidaciones_parciales = (gridDetalle.Rows[i].FindControl("chkLiquidacionParcial") as CheckBox).Checked ? "1" : "0";

                        dsDetalles.Tables[0].Rows.Add(vid_pedido, vid_tipo_documento, vid_pedido_detalle, vid_proveedor, vno_orden_compra, vcantidad_compra, vcosto_unitario_compra, vcosto_real, viva, vfecha_orden_compra, vliquidaciones_parciales, Session["usuario"].ToString());

                    }
                    txtObser.Text = string.Empty;

                    pInsumoLN = new PedidosLN();
                    string usuario = Session["usuario"].ToString();
                    string observaciones = txtObser.Text;
                    DataSet dsResultado = pInsumoLN.AprobacionTecnico(dsDetalles);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se APROBÓ la solicitud: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                    string noSolicitud = dvPedido.Rows[1].Cells[1].Text;
                    txtNo.Text = string.Empty;

                    NuevaAprobacion();
                    lblSuccess.Text = "Solicitud No. " + noSolicitud + " INGRESADA con éxito!";

                }

            }
            catch (Exception ex)
            {
                lblError.Text = "btnAprobar(). " + ex.Message;
            }
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
                    DataSet dsResultado = pInsumoLN.AnulacionTecnico(idSalida, idTipoSalida, txtObser.Text, Session["usuario"].ToString());

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

            if (rblTipoDocto.Equals("1"))
            {
                chkConstantes.Enabled = true;
            }
            else
            {
                chkConstantes.Enabled = false;
                chkConstantes.Checked = false;

                chkConstantes_CheckedChanged(sender, e);

                ddlProveedoresC.ClearSelection();
                txtNoOrdenC.Text = "";
                txtFechaOrdenC.Text = "";
                rblLiquidacionesC.SelectedValue = "0";

            }
        }

        protected void gridDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList dropProveedor = (DropDownList)e.Row.FindControl("dropProveedor");

                    pInsumoLN = new PedidosLN();
                    pInsumoLN.DdlProveedores(dropProveedor, 1);
                }
            }
        }

        protected void chkConstantes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConstantes.Checked)
            {
                ddlProveedoresC.Enabled = txtNoOrdenC.Enabled = txtFechaOrdenC.Enabled = rblLiquidacionesC.Enabled = true;

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlProveedores(ddlProveedoresC, 1);

                txtNoOrdenC.Text = txtFechaOrdenC.Text = string.Empty;
                rblLiquidacionesC.SelectedValue = "0";

            }
            else
            {
                ddlProveedoresC.Enabled = txtNoOrdenC.Enabled = txtFechaOrdenC.Enabled = rblLiquidacionesC.Enabled = false;

                pInsumoLN = new PedidosLN();
                pInsumoLN.DdlProveedores(ddlProveedoresC, 0);

                txtNoOrdenC.Text = txtFechaOrdenC.Text = string.Empty;
                rblLiquidacionesC.SelectedValue = "0";
            }
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

        protected DataSet stringToFechaMySql(string stringFecha)
        {
            DataSet dsResultado = new DataSet();
            dsResultado.Tables.Add();
            dsResultado.Tables[0].Columns.Add("FECHA_VALIDA", typeof(System.String));
            dsResultado.Tables[0].Columns.Add("MSG_ERROR", typeof(System.String));
            dsResultado.Tables[0].Columns.Add("DIA", typeof(System.String));
            dsResultado.Tables[0].Columns.Add("MES", typeof(System.String));
            dsResultado.Tables[0].Columns.Add("ANIO", typeof(System.String));

            DataRow dr = dsResultado.Tables[0].NewRow();
            dr["FECHA_VALIDA"] = "false";

            try
            {
                string[] sValor = {""};

                if (stringFecha.Contains("/"))
                    sValor = stringFecha.Split('/');
                else if (stringFecha.Contains("-"))
                    sValor = stringFecha.Split('-');

                int dia, mes, anio;
                dia = mes = anio = 0;
                DateTime fecha = new DateTime();

                if (sValor.Length != 3)
                    throw new Exception();

                if (stringFecha.Contains("/"))
                {
                    int.TryParse(sValor[0], out dia);
                    int.TryParse(sValor[1], out mes);
                    int.TryParse(sValor[2], out anio);
                }
                else if (stringFecha.Contains("-"))
                {
                    int.TryParse(sValor[0], out anio);
                    int.TryParse(sValor[1], out mes);
                    int.TryParse(sValor[2], out dia);
                }

                dr["FECHA_VALIDA"] = "true";
                dr["MSG_ERROR"] = "";
                dr["DIA"] = dia;
                dr["MES"] = mes;
                dr["ANIO"] = anio;

                    
            }
            catch (Exception ex)
            {
                dr["FECHA_VALIDA"] = "false";
                dr["MSG_ERROR"] = ex.Message;
                dr["DIA"] = "";
                dr["MES"] = "";
                dr["ANIO"] = "";
            }
            dsResultado.Tables[0].Rows.Add(dr);
            return dsResultado;
        }

        protected decimal stringToDecimal2Posiciones(string valor)
        {
            string[] sValor = valor.Split('.');
            decimal d = 0;

            if (sValor.Length == 1)
                d = decimal.Parse(sValor[0] + ".00");

            else
            {
                if (sValor[1].Length == 1)
                    sValor[1] += "0";

                d = decimal.Parse(sValor[0] + "." + sValor[1].Substring(0, 2));
            }

            return d;
        }

        protected bool validarControlesABC()
        {
            bool controlesValidos = false;
            try
            {
                int filas = gridDetalle.Rows.Count;

                if (chkConstantes.Checked)
                {
                    if (ddlProveedoresC.SelectedValue.Equals("0") || ddlProveedoresC.Items.Count == 0)
                    {
                        lblErrorProveedorC.Text = "Seleccione un proveedor. ";
                        lblError.Text += "Seleccione un proveedor. ";
                    }

                    if (esEntero(txtNoOrdenC.Text) == false || int.Parse(txtNoOrdenC.Text) < 1)
                    {
                        lblErrorOrdenC.Text = "Número no válido";
                        lblError.Text += "Número no válido";
                    }

                    DataSet dsResultado = stringToFechaMySql(txtFechaOrdenC.Text);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["FECHA_VALIDA"].ToString()) == false)
                    {
                        lblErrorFechaC.Text = "Fecha no válida";
                        lblError.Text += "Fecha no válida. ";
                    }

                    if (!rblLiquidacionesC.SelectedValue.Equals("0") && !rblLiquidacionesC.SelectedValue.Equals("1"))
                    {
                        lblErrorLiquidacionesC.Text = "Selección no válida";
                        lblError.Text += "Selección no válida. ";
                    }

                    if (lblError.Text.Equals(string.Empty))
                        controlesValidos = true;

                    if (controlesValidos && Page.IsValid)
                        controlesValidos = true;
                    else
                        controlesValidos = false;
                }
                else
                    controlesValidos = true;

                if(controlesValidos)
                {
                    decimal cantidad, costoUnitario, sumCantidad, sumCosto, sumSubtotal;
                    sumCantidad = 0;
                    sumCosto = 0;
                    sumSubtotal = 0;

                    controlesValidos = false;
                    for (int i = 0; i < gridDetalle.Rows.Count; i++)
                    {
                        DropDownList ddlProveedor;
                        CheckBox chkLiquidaciones;
                        TextBox txtCantidad, txtCosto, txtNoOrden, txtFechaOrden;
                            
                        cantidad = 0;
                        costoUnitario = 0;

                        txtCantidad = new TextBox();
                        txtCosto = new TextBox();
                        ddlProveedor = new DropDownList();
                        chkLiquidaciones = new CheckBox();
                        txtNoOrden = txtFechaOrden = new TextBox();

                        if (chkConstantes.Checked)
                        {
                            txtCantidad = (gridDetalle.Rows[i].FindControl("txtCantidadReal") as TextBox);
                            txtCosto = (gridDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox);
                            ddlProveedor = ddlProveedoresC;
                            txtNoOrden = txtNoOrdenC;
                            txtFechaOrden = txtFechaOrdenC;
                        }
                        else
                        {
                            txtCantidad = (gridDetalle.Rows[i].FindControl("txtCantidadReal") as TextBox);
                            txtCosto = (gridDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox);
                            ddlProveedor = (gridDetalle.Rows[i].FindControl("dropProveedor") as DropDownList);
                            txtNoOrden = (gridDetalle.Rows[i].FindControl("txtNoOrdenDetalle") as TextBox);
                            txtFechaOrden = (gridDetalle.Rows[i].FindControl("txtFechaOrdenDetalle") as TextBox);
                            chkLiquidaciones = (gridDetalle.Rows[i].FindControl("chkLiquidacionParcial") as CheckBox);
                        }

                        if (ddlProveedor.SelectedValue.Equals("0") || ddlProveedor.Items.Count == 0)
                        {
                            (gridDetalle.Rows[i].FindControl("lblErrorProveedor") as Label).Text = "Seleccione un proveedor";
                            lblErrorCalculo.Text = lblError.Text = "Se detectaron errores. ";
                        }
                        else
                        {
                            if(chkConstantes.Checked)
                                (gridDetalle.Rows[i].FindControl("dropProveedor") as DropDownList).SelectedValue = ddlProveedor.SelectedValue;

                            (gridDetalle.Rows[i].FindControl("lblErrorProveedor") as Label).Text = string.Empty;
                        }

                        string sCantidad = stringToDecimalString(txtCantidad.Text);
                        if (esDecimal(sCantidad) == false)
                        {
                            (gridDetalle.Rows[i].FindControl("lblErrorCantidadReal") as Label).Text = "Número no válida";
                            lblErrorCalculo.Text = lblError.Text = "Se detectaron errores. ";
                        }
                        else
                        {
                            (gridDetalle.Rows[i].FindControl("txtCantidadReal") as TextBox).Text = stringToDecimal2Posiciones(sCantidad).ToString();
                            (gridDetalle.Rows[i].FindControl("lblErrorCantidadReal") as Label).Text = string.Empty;
                            cantidad = stringToDecimal2Posiciones(sCantidad);
                            sumCantidad += cantidad;
                        }

                        string sCostoUnitario = stringToDecimalString(txtCosto.Text);
                        if (esDecimal(sCostoUnitario) == false)
                        {
                            (gridDetalle.Rows[i].FindControl("lblErrorCostoUReal") as Label).Text = "Número no válido";
                            lblErrorCalculo.Text = lblError.Text = "Se detectaron errores. ";
                        }
                        else
                        {
                            (gridDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", stringToDecimal2Posiciones(sCostoUnitario));
                            (gridDetalle.Rows[i].FindControl("lblErrorCostoUReal") as Label).Text = string.Empty;
                            costoUnitario = stringToDecimal2Posiciones(sCostoUnitario);
                            sumCosto += costoUnitario;
                        }

                        decimal costoReal = cantidad * costoUnitario;

                        if (esDecimal(costoReal.ToString()) == false)
                        {
                            (gridDetalle.Rows[i].FindControl("lblErrorCostoReal") as Label).Text = "Costo no válido";
                            lblErrorCalculo.Text = lblError.Text = "Se detectaron errores. ";
                        }
                        else
                        {
                            (gridDetalle.Rows[i].FindControl("txtCostoReal") as TextBox).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", costoReal);
                            string subTEstimado = (gridDetalle.Rows[i].FindControl("lblSubtotalEstimado") as Label).Text;

                            subTEstimado = stringToDecimalString(subTEstimado);
                            decimal subTEstimadoDec = stringToDecimal2Posiciones(subTEstimado);

                            if (costoReal <= subTEstimadoDec)
                                (gridDetalle.Rows[i].FindControl("lblErrorCostoReal") as Label).Text = string.Empty;
                            else
                                (gridDetalle.Rows[i].FindControl("lblErrorCostoReal") as Label).Text = lblErrorCalculo.Text = lblError.Text = "Supera al estimado!";

                            sumSubtotal += costoReal;
                        }

                        //EL PROVEEDOR FUE SELECCIONADO ADECUADAMENTE
                        string eProveedor = (gridDetalle.Rows[i].FindControl("lblErrorProveedor") as Label).Text;
                        if (eProveedor.Equals("") || eProveedor.Equals(string.Empty))
                        {
                            (gridDetalle.Rows[i].FindControl("txtIva") as TextBox).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (costoReal * decimal.Parse("1.12") - costoReal));
                        }

                        if (rblTipoDocto.SelectedValue != "1")
                        {
                            txtNoOrden.Text = "1";
                            txtFechaOrden.Text = "01/01/2016";
                        }
                        if (esEntero(txtNoOrden.Text) == false || int.Parse(txtNoOrden.Text) < 1)
                        {
                            (gridDetalle.Rows[i].FindControl("lblErrorNoOrden") as Label).Text = "Número no válido";
                            lblErrorCalculo.Text = lblError.Text = "Se detectaron errores. ";
                        }
                        else
                        {
                            if (chkConstantes.Checked)
                                (gridDetalle.Rows[i].FindControl("txtNoOrdenDetalle") as TextBox).Text = txtNoOrden.Text;

                            (gridDetalle.Rows[i].FindControl("lblErrorNoOrden") as Label).Text = string.Empty;
                        }

                        DataSet dsResultado = stringToFechaMySql(txtFechaOrden.Text);
                            
                        if (dsResultado.Tables[0].Rows[0]["FECHA_VALIDA"].ToString().Equals("false"))
                        {
                            (gridDetalle.Rows[i].FindControl("lblErrorFechaNoOrden") as Label).Text = "Fecha no válida";
                            lblErrorCalculo.Text = lblError.Text = "Se detectaron errores. ";
                        }
                        else
                        {
                            if (chkConstantes.Checked)
                                (gridDetalle.Rows[i].FindControl("txtFechaOrdenDetalle") as TextBox).Text = txtFechaOrden.Text;

                            (gridDetalle.Rows[i].FindControl("lblErrorFechaNoOrden") as Label).Text = string.Empty;
                        }

                        if (chkConstantes.Checked)
                        {
                            if (rblLiquidacionesC.SelectedValue.Equals("1"))
                                (gridDetalle.Rows[i].FindControl("chkLiquidacionParcial") as CheckBox).Checked = true;
                            else
                                (gridDetalle.Rows[i].FindControl("chkLiquidacionParcial") as CheckBox).Checked = false;
                        }

                        if (rblTipoDocto.SelectedValue != "1")
                        {
                            txtNoOrden.Text = "";
                            txtFechaOrden.Text = "";
                        }

                        if (lblError.Text.Equals(string.Empty))
                            controlesValidos = true;
                        else
                            controlesValidos = false;

                        if (controlesValidos && Page.IsValid)
                            controlesValidos = true;
                        else
                            controlesValidos = false;

                        if (controlesValidos == true)
                        {
                            gridDetalle.FooterRow.Cells[10].Text = sumCantidad.ToString();//String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumCantidad);
                            gridDetalle.FooterRow.Cells[11].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumCosto);
                            gridDetalle.FooterRow.Cells[12].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumSubtotal);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }
            return controlesValidos;
        }

        protected string stringToDecimalString(string s)
        {
            s = s.Replace("Q. ", "");
            s = s.Replace("Q.", "");
            s = s.Replace("Q", "");
            s = s.Replace(" ", "");
            s = s.Replace(",", "");

            if (s.Equals(""))
                return "00.00";

            return s;
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                validarControlesABC();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnCalcular(). " + ex.Message;
            }
            
        }
    }
}
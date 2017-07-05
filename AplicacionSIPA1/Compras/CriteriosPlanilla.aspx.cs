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

namespace AplicacionSIPA1.Compras
{
    public partial class CriteriosPlanilla : System.Web.UI.Page
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

                lblIdCriterioPedido.Text = "0";
                ddlCriterios.ClearSelection();
                txtPuntuacion.Text = "";

                filtrarDvPedidos();
                filtrarGridDetalles();
                filtrarGridCriterios();
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

                pInsumoLN.DdlCriterios(ddlCriterios, 3);
                
                int idEncabezado, idtipoDocto, anio = 0;
                
                int.TryParse(txtNo.Text, out idEncabezado);
                int.TryParse(rblTipoDocto.SelectedValue, out idtipoDocto);
                int.TryParse(ddlAnios.SelectedValue, out anio);

                if(false)//if (!lblErrorPoa.Text.Equals(string.Empty))
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

                        btnGuardar.Visible = true;

                        int idEstadoPedido = 0;
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString(), out idEstadoPedido);

                        btnGuardar.Visible = true;
                        if (idEstadoPedido == 12)
                        {
                            lblError.Text = "El documento seleccionado ya tiene asignado valor real.";
                            btnGuardar.Visible = false;
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

        protected void filtrarGridCriterios()
        {
            try
            {
                gridCriterios.DataSource = null;
                gridCriterios.DataBind();
                gridCriterios.SelectedIndex = -1;

                int idSalida, tipoSalida;
                idSalida = tipoSalida = 0;

                if(dvPedido.Rows.Count > 0)
                    int.TryParse(dvPedido.DataKey[0].ToString(), out idSalida);

                //SALDOS EN BASE A LA ACCIÓN
                tipoSalida = 4;
                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionCriteriosCompra(idSalida, 0, "", 4);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridCriterios.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridCriterios.DataBind();
                }
                else
                {
                    gridCriterios.DataSource = null;
                    gridCriterios.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridCriterios(). " + ex.Message);
            }
        }

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
            lblError.Text = lblSuccess.Text = string.Empty;
        }

        protected bool validarPoaAprobacionPedido(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
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
                if (!estadoPoa.Split('-')[0].Trim().Equals("9"))
                {
                    btnGuardar.Visible = false;
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa;
                }
                else
                {
                    string estadoPac = dsPoa.Tables[0].Rows[0]["ESTADO_PAC"].ToString();
                    if (!estadoPac.Split('-')[0].Trim().Equals("6"))
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
            return poaValido;            
        }

        protected bool validarEstadoPedido(int idPedido)
        {
            bool pedidoValido = false;
            try
            {
                if (idPedido == 0)
                {
                    btnGuardar.Visible = true;
                    lblErrorPoa.Text = lblError.Text = "";
                    pedidoValido = true;
                }
                else
                {
                    btnGuardar.Visible = false;

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
                        btnGuardar.Visible = false;
                        lblErrorPoa.Text = lblError.Text = "El PEDIDO seleccionado se encuenta en estado: " + estadoPedido + " y no se puede modificar ";
                        pedidoValido = false;
                    }
                    else
                    {
                        btnGuardar.Visible = true;
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idCriterioPedido, idCriterio, idSalida, idTipoSalida;
                idSalida = idTipoSalida = idCriterioPedido = idCriterio = 0;

                if (dvPedido.SelectedValue != null) 
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idSalida);

                if (idSalida == 0)
                    throw new Exception("Seleccione un PEDIDO!");

                if (validarControlesABC() == true)
                {
                    int.TryParse(lblIdCriterioPedido.Text, out idCriterioPedido);
                    int.TryParse(ddlCriterios.SelectedValue, out idCriterio);
                    int.TryParse(rblTipoDocto.SelectedValue, out idTipoSalida);
                    string usuario = Session["usuario"].ToString();

                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.AlmacenarCriterio(idCriterioPedido, idCriterio, idSalida, "", decimal.Parse(txtPuntuacion.Text), 0, usuario, 3);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ el criterio: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                    NuevaAprobacion();
                    filtrarGridCriterios();
                    lblSuccess.Text = "Criterio almacenado con éxito!";

                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar(). " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            NuevaAprobacion();
        }

        protected void rblTipoDocto_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
            dvPedido.DataSource = gridDetalle.DataSource = gridCriterios.DataSource = null;
            dvPedido.DataBind();
            gridDetalle.DataBind();
            gridCriterios.DataBind();
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

                if (ddlCriterios.SelectedValue.Equals("") || ddlCriterios.SelectedValue.Equals(string.Empty))
                    throw new Exception("Seleccione un criterio");
                
                if (esDecimal(txtPuntuacion.Text) == false)
                    throw new Exception("Ingrese una puntuación válida");

                controlesValidos = true;
                
                if (lblError.Text.Equals(string.Empty))
                    controlesValidos = true;
                else
                    controlesValidos = false;

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

        protected void ddlCriterios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idCriterio = 0;
                int.TryParse(ddlCriterios.SelectedValue, out idCriterio);

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionCriteriosCompra(idCriterio, 0, "", 2);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                txtPuntuacion.Text = "";

                if(dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                    txtPuntuacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PUNTUACION_DEFAULT"].ToString();

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlCriterios(). " + ex.Message;
            }
        }

        protected void gridCriterios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idDetalle = 0;
                int.TryParse(gridCriterios.DataKeys[gridCriterios.SelectedIndex].Value.ToString(), out idDetalle);

                lblIdCriterioPedido.Text = idDetalle.ToString();

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionCriteriosCompra(idDetalle, 0, "", 5);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                ddlCriterios.SelectedValue = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_CRITERIO"].ToString();
                txtPuntuacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PUNTUACION"].ToString();
            }
            catch (Exception ex)
            {
                lblError.Text = "gridCriterios(). " + ex.Message;
            }
        }

        protected void gridCriterios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idDetalle = int.Parse(e.Keys["ID_CRITERIO_PEDIDO"].ToString());

                if (idDetalle == 0)
                    throw new Exception("No existe criterio para eliminar");

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.AlmacenarCriterio(idDetalle, 0, 0, "", 0, 0, "", 4);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                NuevaAprobacion();
                lblSuccess.Text = "Criterio eliminado correctamente!";
                filtrarGridCriterios();

            }
            catch (Exception ex)
            {
                lblError.Text = "gridCriterios(). " + ex.Message;
            }
        }
    }
}
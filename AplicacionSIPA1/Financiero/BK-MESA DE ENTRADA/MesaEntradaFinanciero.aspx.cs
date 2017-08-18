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
    public partial class MesaEntradaFinanciero : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private UsuariosLN uUsuariosLN;
        private PedidosLN pInsumoLN;

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
                    dsResultado = pInsumoLN.InformacionPedido(idEncabezado, idtipoDocto, 0, anio.ToString(), 9);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                    {
                        dvPedido.DataSource = dsResultado.Tables["BUSQUEDA"];
                        dvPedido.DataBind();

                        int idEstadoPedido = 0;
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString(), out idEstadoPedido);

                        btnAprobar.Visible = btnRechazar.Visible = true;
                        if (idEstadoPedido >= 10)
                        {
                            lblError.Text = "El documento seleccionado ya fue aprobado por la mesa de entrada.";
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

                    decimal cantidadArticulos = 0;
                    decimal totalPedido = 0;

                    string sCantidad = dsResultado.Tables["BUSQUEDA"].Compute("SUM(CANTIDAD)", "").ToString();
                    string sSubtotal = dsResultado.Tables["BUSQUEDA"].Compute("SUM(SUBTOTAL)", "").ToString();

                    decimal.TryParse(sCantidad, out cantidadArticulos);
                    decimal.TryParse(sSubtotal, out totalPedido);

                    gridDetalle.FooterRow.Cells[3].Text = "Totales";
                    gridDetalle.FooterRow.Cells[5].Text = cantidadArticulos.ToString();
                    gridDetalle.FooterRow.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalPedido);
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
            /*try
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
            }*/
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
            //lblErrorPoa.Text = string.Empty;
            lblErrorObser.Text = string.Empty;
            lblError.Text = lblSuccess.Text = string.Empty;
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

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idSalida, idTipoSalida;
                idSalida = idTipoSalida = 0;
                if(dvPedido.SelectedValue != null)
                    int.TryParse(dvPedido.SelectedValue.ToString(), out idSalida);

                int.TryParse(rblTipoDocto.SelectedValue, out idTipoSalida);

                if (idSalida == 0)
                    throw new Exception("Seleccione un PEDIDO!");

                txtObser.Text = string.Empty;

                pInsumoLN = new PedidosLN();
                string usuario = Session["usuario"].ToString();
                string observaciones = txtObser.Text;
                DataSet dsResultado = pInsumoLN.AprobacionMesaEntrada(idSalida, idTipoSalida, observaciones, usuario);
                
                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se APROBÓ la solicitud: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                //string s = txtNo.Text;
                //txtNo.Text = s;

                string noSolicitud = dvPedido.Rows[1].Cells[1].Text;
                txtNo.Text = string.Empty;

                NuevaAprobacion();
                lblSuccess.Text = "Solicitud No. " + noSolicitud + " INGRESADA con éxito!";
                //Response.Redirect("NoPedido.aspx?No=" + Convert.ToString(idPedido) + "&msg=PEDIDO" + "&acc=APROBADO");
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
                    DataSet dsResultado = pInsumoLN.RechazoMesaEntrada(idSalida, idTipoSalida, observaciones, usuario);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se RECHAZÓ la solicitud: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    string noSolicitud = dvPedido.Rows[1].Cells[1].Text;
                    txtNo.Text = string.Empty;

                    NuevaAprobacion();
                    lblSuccess.Text = "Solicitud No. " + noSolicitud + " RECHAZADA con éxito!";
                    //Response.Redirect("NoPedido.aspx?No=" + Convert.ToString(idPedido) + "&msg=PEDIDO" + "&acc=RECHAZADO");
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
        }

    }
}
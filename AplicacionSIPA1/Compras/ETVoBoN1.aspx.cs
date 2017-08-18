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
    public partial class ETVoBoN1 : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;

        private PedidosLN pInsumoLN;
        private PedidosEN pInsumoEN;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    string s = Convert.ToString(Request.QueryString["No"]);
                    string mostrarBotones = Convert.ToString(Request.QueryString["OptB"]);
                    string tipoDocumento = Convert.ToString(Request.QueryString["TipoD"]);


                    if (s != null)
                    {
                        int idEncabezado = 0;
                        int.TryParse(s, out idEncabezado);
                        lblNo.Text = idEncabezado.ToString();

                        if (tipoDocumento != null)
                            lblTipoDocumento.Text = tipoDocumento;

                        pInsumoLN = new PedidosLN();
                        DataSet dsResultado = new DataSet();
                        
                        if(lblTipoDocumento.Text.Equals("R"))
                            dsResultado = pInsumoLN.InformacionPedido(idEncabezado, 0, 0, "", 2);
                        else if (lblTipoDocumento.Text.Equals("V"))
                            dsResultado = pInsumoLN.InformacionVale(idEncabezado, 0, 2);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables.Count == 0)
                            throw new Exception("Error al consultar la información del pedido.");

                        if (dsResultado.Tables[0].Rows.Count == 0)
                            throw new Exception("No existe información del pedido");

                        lblIdPedido.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_PEDIDO"].ToString();
                        lblNo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_SOLICITUD"].ToString() + "-" + dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO_SOLICITUD"].ToString();
                        lblNoAnexo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ANEXO"].ToString();
                        lblFecha.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["FECHA_PEDIDO"].ToString();
                        lblUnidad.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["UNIDAD_ADMINISTRATIVA"].ToString();

                        filtrarGridDetalles(idEncabezado);

                        btnAprobar.Visible = btnRechazar.Visible = false;
                        lblError.Text = string.Empty;
                        if(int.Parse(lblNoAnexo.Text) > 0)
                            validarEstadoAnexo();

                        if (mostrarBotones != null)
                            if (bool.Parse(mostrarBotones) == false)
                                btnAprobar.Visible = btnRechazar.Visible = false;


                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void validarEstadoAnexo()
        {
            try
            {
                int idTipoDocumento = 0;
                if (lblTipoDocumento.Text.Equals("R"))
                    idTipoDocumento = 1;
                else if (lblTipoDocumento.Text.Equals("V"))
                    idTipoDocumento = 2;

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPedido(int.Parse(lblIdPedido.Text), idTipoDocumento, 0, "ENCABEZADO", 8);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                string idEstado = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO"].ToString();
                string estado = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO"].ToString();


                btnAprobar.Visible = btnRechazar.Visible = false;
                lblError.Text = string.Empty;

                if (idEstado.Equals("1")  || idEstado.Equals("2") || idEstado.Equals("3"))
                {
                    btnAprobar.Visible = btnRechazar.Visible = true;
                    lblError.Text = string.Empty;
                }

                else if (idEstado.Equals("1") || idEstado.Equals("4") || idEstado.Equals("5") || idEstado.Equals("6"))
                {
                    btnAprobar.Visible = btnRechazar.Visible = false;
                    lblError.Text = "La especificación se encuentra en estado " + estado + ", y no se puede modificar";
                }

                lblErrorPoa.Text = "La especificación se encuentra en estado " + estado;
                lblError.Text = string.Empty;

                btnAprobar.Visible = btnRechazar.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception("validarEstadoAnexo(). " + ex.Message);
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
                DataSet dsResultado = new DataSet();

                int idTipoDocumento = 0;

                if (lblTipoDocumento.Text.Equals("R"))
                    idTipoDocumento = 1;
                else if (lblTipoDocumento.Text.Equals("V"))
                    idTipoDocumento = 2;

                dsResultado = pInsumoLN.InformacionPedido(id, idTipoDocumento, 0, "DETALLE", 8);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridDet.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridDet.DataBind();
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

        protected DataTable armarDtDetalles()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_ESPECIFICACION_DETALLE", Type.GetType("System.String"));
            dt.Columns.Add("ID_ESPECIFICACION", Type.GetType("System.String"));
            dt.Columns.Add("ID_PEDIDO_DETALLE", Type.GetType("System.String"));
            dt.Columns.Add("DESCRIPCION_ESPECIFICA", Type.GetType("System.String"));
            dt.Columns.Add("USUARIO", Type.GetType("System.String"));

            return dt;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPedido, idEspecificacion = 0;
                int.TryParse(lblIdPedido.Text, out idPedido);
                int.TryParse(lblNoAnexo.Text, out idEspecificacion);

                pInsumoEN = new PedidosEN();

                pInsumoEN.ID_ESPECIFICACION = idEspecificacion;
                pInsumoEN.ID_PEDIDO = idPedido;
                pInsumoEN.USUARIO = Session["usuario"].ToString();

                int idTipoDocumento = 0;

                if (lblTipoDocumento.Text.Equals("R"))
                    idTipoDocumento = 1;
                else if (lblTipoDocumento.Text.Equals("V"))
                    idTipoDocumento = 2;

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.AprobarEspecificacion(idEspecificacion, idTipoDocumento, "", 1);
                
                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se APROBARON las especificaciones: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                lblError.Text = string.Empty;
                lblSuccess.Text = "Especificaciones APROBADAS exitosamente: ";
                validarEstadoAnexo();
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
                int idPedido, idEspecificacion = 0;
                int.TryParse(lblNo.Text.Split('-')[0].Trim(), out idPedido);
                int.TryParse(lblNoAnexo.Text, out idEspecificacion);

                pInsumoEN = new PedidosEN();

                pInsumoEN.ID_ESPECIFICACION = idEspecificacion;
                pInsumoEN.ID_PEDIDO = idPedido;
                pInsumoEN.USUARIO = Session["usuario"].ToString();

                int idTipoDocumento = 0;

                if (lblTipoDocumento.Text.Equals("R"))
                    idTipoDocumento = 1;
                else if (lblTipoDocumento.Text.Equals("V"))
                    idTipoDocumento = 2;

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.RechazarEspecificacion(idEspecificacion, idTipoDocumento, "", 2);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se RECHAZARON las especificaciones: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                lblError.Text = string.Empty;
                lblSuccess.Text = "Especificaciones RECHAZADAS exitosamente: ";
                validarEstadoAnexo();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnRechazar(). " + ex.Message;
            }
        }
    }
}
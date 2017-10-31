using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using CapaEN;
using System.Web.UI.WebControls;
using System.Web;
using System.Data;


namespace CapaLN
{
    public class PedidosLN
    {
        PedidosAD ObjAD;

        public void DdlSolicitantes(DropDownList drop, string usuario, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idUnidad > 0)
            {
                ObjAD = new PedidosAD();
                drop.DataSource = ObjAD.DdlSolicitantes(usuario, idUnidad);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }


        public void DdlJefes(DropDownList drop, string usuario, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idUnidad > 0)
            {
                ObjAD = new PedidosAD();
                drop.DataSource = ObjAD.DdlJefes(usuario, idUnidad);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }

        public void DdlTecnicosCompras(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            //if (idUnidad > 0)
            {
                ObjAD = new PedidosAD();
                drop.DataSource = ObjAD.DdlTecnicosCompras();
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }

        public void DdlSubgerentes(DropDownList drop, string usuario, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idUnidad > 0)
            {
                ObjAD = new PedidosAD();
                drop.DataSource = ObjAD.DdlJefes(usuario, idUnidad);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }

        public void DdlPuestosEmpleado(DropDownList drop, string usuario, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idUnidad > 0)
            {
                ObjAD = new PedidosAD();
                drop.DataSource = ObjAD.DdlJefes(usuario, idUnidad);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }

        public void DdlTiposPedido(DropDownList drop, int opcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            /*drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";*/

            if (opcion > 0)
            {
                ObjAD = new PedidosAD();
                drop.DataSource = ObjAD.DdlTiposPedido();
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            /*if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }*/
        }

        public void DdlUnidadesMedida(DropDownList drop, int idTipoPedido)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idTipoPedido > 0)
            {
                ObjAD = new PedidosAD();
                drop.DataSource = ObjAD.DdlUnidadesMedida(idTipoPedido);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }

        public void DdlFand(DropDownList drop, int opcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (opcion > 0)
            {
                ObjAD = new PedidosAD();
                drop.DataSource = ObjAD.DdlFand();
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }


        public void DdlPacsxAccion(DropDownList drop, int idAccion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idAccion > 0)
            {
                ObjAD = new PedidosAD();
                drop.DataSource = ObjAD.DdlPacsxAccion(idAccion);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
            /*
            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }*/
        }

        public void DdlRenglonesCodificarPedido(DropDownList drop, int idSalida, int id2, string criterio, int opcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idSalida > 0)
            {
                ObjAD = new PedidosAD();
                drop.DataSource = ObjAD.DdlRenglonesCodificarPedido(idSalida, id2, criterio, opcion);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlInsumosxAccion(DropDownList drop, int idAccion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idAccion > 0)
            {
                ObjAD = new PedidosAD();
                drop.DataSource = ObjAD.DdlInsumosxAccion(idAccion);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }

        public void DdlProveedores(DropDownList drop, int vOpcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (vOpcion > 0)
            {
                DataSet dsResultado = InformacionProveedores(0, 0, 3);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                ObjAD = new PedidosAD();
                drop.DataSource = dsResultado.Tables["BUSQUEDA"];
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }

        public void DdlCriterios(DropDownList drop, int vOpcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (vOpcion > 0)
            {
                DataSet dsResultado = InformacionCriteriosCompra(0, 0, "", vOpcion);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                ObjAD = new PedidosAD();
                drop.DataSource = dsResultado.Tables["BUSQUEDA"];
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }

        public void DdlTiposDocumentoCompra(DropDownList drop, int vOpcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (vOpcion > 0)
            {
                DataSet dsResultado = InformacionTiposDocumentoCompra(0, 0, "", vOpcion);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                ObjAD = new PedidosAD();
                drop.DataSource = dsResultado.Tables["BUSQUEDA"];
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }

        public void DdlAjustes(DropDownList drop, int vOpcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (vOpcion > 0)
            {
                DataSet dsResultado = InformacionAjustesPedido(0, 0, " AND t.anulado = 0 AND t.id_pedido = " + vOpcion, 1);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                ObjAD = new PedidosAD();
                drop.DataSource = dsResultado.Tables["BUSQUEDA"];
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }
        }

        public void DdlAjustesVoBo(DropDownList drop, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idUnidad > 0)
            {
                DataSet dsResultado = InformacionAjustesPedido(0, 0, " AND t.anulado = 0 AND t.id_unidad = " + idUnidad, 1);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                ObjAD = new PedidosAD();
                drop.DataSource = dsResultado.Tables["BUSQUEDA"];
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            /*if (drop.Items.Count == 2)
            {
                drop.Items.RemoveAt(0);
                drop.SelectedIndex = 0;
            }*/
        }


        public void RblEstadosPedido(RadioButtonList rbl)
        {
            try
            {
                rbl.ClearSelection();
                rbl.Items.Clear();

                rbl.AppendDataBoundItems = true;
                rbl.Items.Add("TODOS");
                rbl.Items[0].Value = "0";

                DataSet dsResultado = InformacionEstadosPedido(0, 0, 0, "", 1);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("Error al consultar los estados de las requisiciones/vales: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                try
                {
                    rbl.DataSource = dsResultado.Tables["BUSQUEDA"];
                    rbl.DataTextField = "texto";
                    rbl.DataValueField = "id";
                    rbl.DataBind();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se encontró información de los estados de las requisiciones/vales: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("CapaLN.RblEstadoPedido(), " + ex.Message);
            }
        }

        public void ChkEstadosPedido(CheckBoxList chk)
        {
            try
            {
                chk.ClearSelection();
                chk.Items.Clear();

                chk.AppendDataBoundItems = true;
                chk.Items.Add("TODOS");
                chk.Items[0].Value = "0";

                DataSet dsResultado = InformacionEstadosPedido(0, 0, 0, "", 1);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("Error al consultar los estados de las requisiciones/vales: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                try
                {
                    chk.DataSource = dsResultado.Tables["BUSQUEDA"];
                    chk.DataTextField = "texto";
                    chk.DataValueField = "id";
                    chk.DataBind();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se encontró información de los estados de las requisiciones/vales: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("CapaLN.RblEstadoPedido(), " + ex.Message);
            }
        }

        public DataSet AlmacenarPedido(PedidosEN pInsumoEN, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarPedido(pInsumoEN, usuario);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarPedido(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarPedidoMultianual(PedidosEN pInsumoEN, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarPedidoMultianual(pInsumoEN, usuario);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarPedidoMultianual(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarVale(PedidosEN pInsumoEN, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarVale(pInsumoEN, usuario);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarVale(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet ActualizarTotalEnLetras(int id, int id2, string totalEnLetras, int opcion)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataSet ds = ObjAD.ActualizarTotalEnLetras(id, id2, totalEnLetras, opcion);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.ActualizarTotalEnLetras(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarGasto(PedidosEN pInsumoEN, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarGasto(pInsumoEN, usuario);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarGasto(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarEspecificacion(PedidosEN pInsumoEN, DataTable dtDetalles)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarEspecificacion(pInsumoEN, dtDetalles);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarGasto(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarProveedor(ProveedoresEN ObjEN, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarProveedor(ObjEN, usuario);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "AlmacenarProveedor(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarCriterio(int idCriterioPedido, int idCriterio, int idPedido, string nombre, decimal puntuacion, int criterioPrecio, string usuario, int opcion)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarCriterio(idCriterioPedido, idCriterio, idPedido, nombre, puntuacion, criterioPrecio, usuario, opcion);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "AlmacenarCriterio(). " + ex.Message;
            }

            return dsResultado;
        }

        //ALMACENAR UNA SOLICITUD DE AJUSTE DE PEDIDO
        public DataSet AlmacenarAjustePedido(AJUSTE_PEDIDO ObjEN, DataSet dsDetalles, string usuario,string ip,string mac,string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarAjustePedido(ObjEN, dsDetalles, usuario);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarAjustePedido(). " + ex.Message;
            }
            return dsResultado;
        }

        //ENVIAR EL PEDIDO A EXISTENCIAS EN BODEGA(BIENES) O APROBACIÓN DE SUB/DIR(SERVICIO)
        public DataSet EnviarPedidoARevision(int idPedido, int idTipoSalida, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.EnviarPedidoARevision(idPedido, idTipoSalida, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EnviarPedidoARevision(). " + ex.Message;
            }

            return dsResultado;
        }

        //ENVIAR EL PEDIDO A EXISTENCIAS EN BODEGA(BIENES) O APROBACIÓN DE SUB/DIR(SERVICIO)
        public DataSet EnviarAjustePedidoARevision(int idAjustePedido, int idTipoSalida, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.EnviarAjustePedidoARevision(idAjustePedido, idTipoSalida, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idAjustePedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EnviarAjustePedidoARevision(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AprobacionBodega(int idPedido, int idTipoDocumento, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.AprobacionBodega(idPedido, idTipoDocumento, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobacionBodega(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazoBodega(int idPedido, int idTipoDocumento, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.RechazoBodega(idPedido, idTipoDocumento, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazoBodega(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AprobacionEncargado(int idSalida, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.AprobacionEncargado(idSalida, idTipoSalida, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idSalida;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobacionEncargado(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AprobacionEncargadoAjuste(int idSalida, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.AprobacionEncargadoAjuste(idSalida, idTipoSalida, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idSalida;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobacionEncargadoAjuste(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazoEncargado(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.RechazoEncargado(idPedido, idTipoSalida, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazoEncargado(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazoEncargadoAjuste(int idSalida, int idTipoSalida, string observaciones, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.RechazoEncargadoAjuste(idSalida, idTipoSalida, observaciones, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idSalida;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazoEncargadoAjuste(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AprobacionPresupuesto(int idSalida, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.AprobacionPresupuesto(idSalida, idTipoSalida, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idSalida;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobacionPresupuesto(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RecodificacionPpto(int idSalida, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.RecodificacionPpto(idSalida, idTipoSalida, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idSalida;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RecodificacionPpto(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AprobacionPresupuestoAjuste(int idSalida, int idTipoSalida, string observaciones, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.AprobacionPresupuestoAjuste(idSalida, idTipoSalida, observaciones, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idSalida;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobacionPresupuestoAjuste(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazoPresupuesto(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.RechazoPresupuesto(idPedido, idTipoSalida, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazoPresupuesto(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazoPresupuestoAjuste(int idAjuste, int idTipoSalida, string observaciones, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.RechazoPresupuestoAjuste(idAjuste, idTipoSalida, observaciones, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idAjuste;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazoPresupuestoAjuste(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AprobacionMesaEntrada(int idSalida, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.AprobacionMesaEntrada(idSalida, idTipoSalida, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idSalida;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobacionMesaEntrada(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazoMesaEntrada(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.RechazoMesaEntrada(idPedido, idTipoSalida, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazoMesaEntrada(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AsignacionTecnicoCompras(int idSalida, int idTipoSalida, int idTecnico, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.AsignacionTecnicoCompras(idSalida, idTipoSalida, idTecnico, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idSalida;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AsignacionTecnicoCompras(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AsignarValorReal(DataSet dsDetalles,string ip,string mac,string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataSet ds = ObjAD.AsignarValorReal(dsDetalles,ip,mac,pc);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AsignarValorReal(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AprobacionTecnico(DataSet dsDetalles, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataSet ds = ObjAD.AprobacionTecnico(dsDetalles, ip, mac, pc);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobacionTecnico(). " + ex.Message;
            }

            return dsResultado;
        }

        //CUANDO EL TÉCNICO DE COMPRAS INTENTE LIQUIDAR POR UN MONTO MAYOR AL PRESUPUESTO PLANIFICADO EN EL PAC O EN EL RENGLÓN DE PRESUPUESTO
        public DataSet RevertirValorReal(int idPedido, int idTipoSalida, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.RevertirValorReal(idPedido, idTipoSalida, criterio, opcion);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RevertirValorReal(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AprobarEspecificacion(int idEspecificacion, int idTipoSalida, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.AprobarEspecificacion(idEspecificacion, idTipoSalida, criterio, opcion);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idEspecificacion;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobarEspecificacion(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazarEspecificacion(int idPedido, int idTipoSalida, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.RechazarEspecificacion(idPedido, idTipoSalida, criterio, opcion);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazarEspecificacion(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AnulacionTecnico(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.AnulacionTecnico(idPedido, idTipoSalida, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AnulacionTecnico(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazoTecnico(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.RechazoTecnico(idPedido, idTipoSalida, observaciones, usuario, ip, mac, pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AnulacionTecnico(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet Reactivacion(int idPedido, int idTipoSalida, string observaciones, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.Reactivacion(idPedido, idTipoSalida, observaciones, usuario, "null", "null", "null");

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Reactivacion(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarEncabezado(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.EliminarEncabezado(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarEncabezado(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarDetalle(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.EliminarDetalle(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarDetalle(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarDetalleVale(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.EliminarDetalleVale(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarDetalleVale(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarDetalleGasto(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.EliminarDetalleGasto(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarDetalleGasto(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarProveedor(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.EliminarProveedor(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarDetalle(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet CodificarSalida(int idDetalleSalida, int idTipoSalida, int idDetalleAccion, string programa, string subprograma, string proyecto, string actividad, string obra, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.CodificarSalida(idDetalleSalida, idTipoSalida, idDetalleAccion, programa, subprograma, proyecto, actividad, obra, opcion);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idDetalleSalida;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.CodificarSalida(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionPedido(int id, int id2, int id3, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.InformacionPedido(id, id2, id3, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionPedido(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionVale(int id, int id2, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.InformacionVale(id, id2, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionVale(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionPermisos(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.InformacionPermisos(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionPermisos(). " + ex.Message;
            }

            return dsResultado;
        }


        public DataSet InformacionGasto(int id, int id2, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.InformacionGasto(id, id2, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionGasto(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionProveedores(int id, int id2, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.InformacionProveedores(id, id2, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "InformacionProveedores(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionCriteriosCompra(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.InformacionCriteriosCompra(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "InformacionCriteriosCompra(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionTiposDocumentoCompra(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.InformacionTiposDocumentoCompra(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "InformacionTiposDocumentoCompra(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionEstadosPedido(int id, int id2, int id3, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.InformacionEstadosPedido(id, id2, id3, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "InformacionEstadosPedido(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionAjustesPedido(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.InformacionAjustesPedido(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "InformacionAjustesPedido(). " + ex.Message;
            }

            return dsResultado;
        }

        /*public DataSet InformacionCriteriosCuadroAdj(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.InformacionCriteriosCompra(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "InformacionCuadroAdj(). " + ex.Message;
            }
            return dsResultado;
        }*/

        public DataSet DetallesPedidoAprobacion(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.DetallesPedidoAprobacion(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.DetallesPedidoAprobacion(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet PptoAprobacionSubgerente(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.PptoAprobacionSubgerente(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.PptoAprobacionSubgerente(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet PptoCodificarSalida(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();

            try
            {
                DataTable dt = ObjAD.PptoCodificarSalida(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.PptoCodificarSalida(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionInsumoPac(int idPac)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PedidosAD();
            try
            {
                DataTable dt = ObjAD.InformacionInsumoPac(idPac);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionInsumoPac(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet armarDsResultado()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("RESULTADO");

            dt.Columns.Add("ERRORES", typeof(String));
            dt.Columns.Add("MSG_ERROR", typeof(String));
            dt.Columns.Add("VALOR", typeof(String));
            dt.Columns.Add("CODIGO", typeof(String));
            ds.Tables.Add(dt);

            DataRow dr = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(dr);
            ds.Tables[0].Rows[0]["ERRORES"] = true;
            ds.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
            return ds;
        }
    }
}
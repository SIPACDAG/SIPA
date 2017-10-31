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
    public class ViaticosLN
    {
        ViaticosAD ObjAD;

        public void DdlSolicitantes(DropDownList drop, string usuario, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idUnidad > 0)
            {
                ObjAD = new ViaticosAD();
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
                ObjAD = new ViaticosAD();
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

        public void DdlSubgerentes(DropDownList drop, string usuario, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idUnidad > 0)
            {
                ObjAD = new ViaticosAD();
                drop.DataSource = ObjAD.DdlSubGerentes(usuario, idUnidad);
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
                ObjAD = new ViaticosAD();
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

        public void DdlDetCategorias(DropDownList drop, int id, int id2, string criterio, int vOpcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (id > 0)
            {
                ObjAD = new ViaticosAD();
                drop.DataSource = ObjAD.DdlDetCategorias(id, id2, criterio, vOpcion);
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

        public void DdlDetGrupos(DropDownList drop, int id, int id2, string criterio, int vOpcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            //if (id > 0)
            {
                ObjAD = new ViaticosAD();
                drop.DataSource = ObjAD.DdlDetGrupos(id, id2, criterio, vOpcion);
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

        public DataSet AlmacenarViaticos(ViaticosEN pViaticosEN, DataTable dtDetalles, string usuario,string ip,string mac,string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ViaticosAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarViaticos(pViaticosEN, dtDetalles,ip,mac,pc);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarViaticos(). " + ex.Message;
            }

            return dsResultado;
        }

        //ENVIAR EL PEDIDO A EXISTENCIAS EN BODEGA(BIENES) O APROBACIÓN DE SUB/DIR(SERVICIO)
        public DataSet EnviarViaticoARevision(int idPedido, int idTipoViatico, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.EnviarViaticoARevision(idPedido, idTipoViatico, usuario,ip,mac,pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EnviarViaticoARevision(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AprobacionJefeDirector(int idPedido, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.AprobacionJefeDirector(idPedido, observaciones, usuario,ip,mac,pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                dsResultado.Tables[0].Rows[0]["CODIGO"] = dt.Rows[0]["CODIGO"].ToString();
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobacionJefeDirector(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazoJefeDirector(int idPedido, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.RechazoJefeDirector(idPedido, observaciones, usuario,ip,mac,pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                dsResultado.Tables[0].Rows[0]["CODIGO"] = dt.Rows[0]["CODIGO"].ToString();
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazoJefeDirector(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AprobacionSubgerente(int idSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.AprobacionSubgerente(idSalida, observaciones, usuario,ip,mac,pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idSalida;
                dsResultado.Tables[0].Rows[0]["CODIGO"] = dt.Rows[0]["CODIGO"].ToString();
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobacionSubgerente(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazoSubgerente(int idPedido, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.RechazoSubgerente(idPedido, observaciones, usuario,ip,mac,pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                dsResultado.Tables[0].Rows[0]["CODIGO"] = dt.Rows[0]["CODIGO"].ToString();
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazoSubgerente(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AprobacionFinanciera(int idSalida, string observaciones, string usuario, string PRG, string SPRG, string PROY, string ACT, string OBR, int idDetalleAccion, decimal pasajes, decimal kilometraje, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.AprobacionFinanciera(idSalida, observaciones, usuario, PRG, SPRG, PROY, ACT, OBR, idDetalleAccion, pasajes, kilometraje,ip,mac,pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idSalida;
                dsResultado.Tables[0].Rows[0]["CODIGO"] = dt.Rows[0]["CODIGO"].ToString();
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobacionFinanciera(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazoFinanciera(int idPedido, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.RechazoFinanciera(idPedido, observaciones, usuario,ip,mac,pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                dsResultado.Tables[0].Rows[0]["CODIGO"] = dt.Rows[0]["CODIGO"].ToString();
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazoFinanciera(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet Liquidar(int idSalida, string observaciones, string usuario, decimal costoReal, decimal pasajes_plan ,decimal pasajes, decimal kilometraje_plan ,decimal kilometraje, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.Liquidar(idSalida, observaciones, usuario, costoReal, pasajes_plan ,pasajes,kilometraje_plan, kilometraje,ip,mac,pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idSalida;
                dsResultado.Tables[0].Rows[0]["CODIGO"] = dt.Rows[0]["CODIGO"].ToString();
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobacionFinanciera(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet RechazoMesaEntrada(int idPedido, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.RechazoFinanciera(idPedido, observaciones, usuario,ip,mac,pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                dsResultado.Tables[0].Rows[0]["CODIGO"] = dt.Rows[0]["CODIGO"].ToString();
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazoMesaEntrada(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet Anular(int idPedido, string observaciones, string usuario,string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.Anular(idPedido, observaciones, usuario,ip,mac,pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                dsResultado.Tables[0].Rows[0]["CODIGO"] = dt.Rows[0]["CODIGO"].ToString();
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Anular(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarEncabezado(int id, string ip, string mac, string pc)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.EliminarEncabezado(id,ip,mac,pc);

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

        public DataSet EliminarDetalle(int idDetalle, int idEncabezado, string criterio)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.EliminarDetalle(idDetalle, idEncabezado, criterio);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idDetalle;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarDetalle(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet CodificarSalida(int idDetalleSalida, int idTipoSalida, int idDetalleAccion, int programa, int subprograma, int actividad, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new ViaticosAD();
            try
            {
                DataTable dt = ObjAD.CodificarSalida(idDetalleSalida, idTipoSalida, idDetalleAccion, programa, subprograma, actividad, opcion);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idDetalleSalida;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarDetalle(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionViatico(int id, int id2, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new ViaticosAD();

            try
            {
                DataTable dt = ObjAD.InformacionViatico(id, id2, opcion);
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

        public DataSet PptoAprobacionSubgerente(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new ViaticosAD();

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
            ObjAD = new ViaticosAD();

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

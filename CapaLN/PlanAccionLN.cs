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
    public class PlanAccionLN
    {
        PlanAccionAD ObjAD;

        public void DdlDependenciasUsuario(DropDownList drop, string usuario, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idUnidad > 0)
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlDependencias(usuario, idUnidad);
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

        public void DdlDependenciasUnidad(DropDownList drop, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idUnidad > 0)
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlDependenciasUnidad(idUnidad);
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

        public void DdlAcciones(DropDownList drop, int idMeta)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idMeta > 0)
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlAcciones(idMeta);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlAccionesPoa(DropDownList drop, int idPoa)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idPoa > 0)
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlAccionesPoa(idPoa);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlAcciones_x_ObjOperativo(DropDownList drop, int idObjetivoO)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idObjetivoO > 0)
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlAcciones_x_ObjOperativo(idObjetivoO);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlAcciones_x_Dependencia(DropDownList drop, int anio, int idDependencia)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idDependencia > 0)
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlAcciones_x_Dependencia(anio, idDependencia);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlAcciones(DropDownList drop, int id, int id2, string criterio, int opcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (id > 0)
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlAcciones(id, id2, criterio, opcion);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlMetas(DropDownList drop, int idAccion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            //drop.AppendDataBoundItems = true;
            //drop.Items.Add("<< Nuevo Ingreso >>");
            //drop.Items[0].Value = "0";

            /*if (idAccion > 0)
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlMetasAccion(idAccion);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }*/
            ObjAD = new PlanAccionAD();
            drop.DataSource = ObjAD.DdlMetasAccion(idAccion);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlRenglones(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            ObjAD = new PlanAccionAD();
            drop.DataSource = ObjAD.DdlRenglones();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }

        public void DdlRenglonesAccion(DropDownList drop, int idAccion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idAccion > 0)
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlRenglonesAccion(idAccion);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
                drop.DataBind();
            }

            /*if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);*/
        }

        public void DdlRenglonesAccion(DropDownList drop, int idAccion, int opcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idAccion > 0)
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlRenglonesAccion(idAccion, opcion);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
                drop.DataBind();
            }

            /*if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);*/
        }

        public void DdlRenglonesPoa(DropDownList drop, int idPoa)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idPoa > 0)
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlRenglonesPoa(idPoa);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
                drop.DataBind();
            }

            /*if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);*/
        }

        public void DdlInsumos(DropDownList drop, int idInsumo)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            /*drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";
            */
            ObjAD = new PlanAccionAD();
            drop.DataSource = ObjAD.DdlInsumos(idInsumo);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

            drop.SelectedIndex = 0;
            /*if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);*/
        }

        public void DdlFinanciamiento(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            ObjAD = new PlanAccionAD();
            drop.DataSource = ObjAD.DdlFinanciamiento();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }

        public void DdlDocumentos(DropDownList drop, string criterio)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< TODOS >>");
            drop.Items[0].Value = "0";

            ObjAD = new PlanAccionAD();
            drop.DataSource = InformacionAccionDetalles(0, 0, criterio, 5).Tables[1];
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlDocumentosAjuste(DropDownList drop, string criterio)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< TOD@S >>");
            drop.Items[0].Value = "0";

            ObjAD = new PlanAccionAD();
            drop.DataSource = InformacionAccionDetalles(0, 0, criterio, 5).Tables[1];
            drop.DataTextField = "texto2";
            drop.DataValueField = "id2";
            drop.DataBind();
        }

        public void GridPlan(GridView grid, int idUnidad, int idPoa)
        {
            ObjAD = new PlanAccionAD();
            grid.DataSource = ObjAD.GridPlan(idUnidad, idPoa);
            grid.DataBind();
        }
        public void GridPlanCompleto(GridView grid, int idUnidad, int idPoa,int anio)
        {
            ObjAD = new PlanAccionAD();
            grid.DataSource = ObjAD.GridPlanCompleto(idUnidad, idPoa,anio);
            grid.DataBind();
        }
        public void GridInsumosRenglon(GridView grid, string noRenglon, string criterio, int opcion)
        {
            ObjAD = new PlanAccionAD();
            grid.DataSource = ObjAD.GridInsumoRenglon(noRenglon, criterio, opcion);
            grid.DataBind();
        }

        public void GridPlanesResumen(GridView grid, int idEstado)
        {
            ObjAD = new PlanAccionAD();
            grid.DataSource = ObjAD.GridPlanesResumen(idEstado);
            grid.DataBind();
        }

        public void GridDetallesAccion(GridView grid, int idAccion, int opcion)
        {
            ObjAD = new PlanAccionAD();

            DataTable dt = ObjAD.InformacionAccionDetalles(idAccion, 0, "", opcion);
            grid.DataSource = dt;
            grid.DataBind();
        }

        public DataSet AlmacenarAccion(AccionesEN ObjEN,string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarAccion(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                dsResultado.Tables[0].Rows[0]["CODIGO"] = dt.Rows[0]["CODIGO"].ToString();
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarAccion(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarMeta(MetasAccionEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarMeta(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarMeta(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarDetalle(AccionesDetEN ObjEN,string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarDetalle(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarDetalle(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarDetalleTransferencias(AccionesDetTransferenciasEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarDetalleTransferencias(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarDetalleTransferencias(). " + ex.Message;
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

        public DataSet BuscarId(string id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();

            try
            {
                DataTable dt = ObjAD.BuscarId(id);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.BuscarId(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionAccion(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.InformacionAccion(id);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionAccion(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionAccionDetalles(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.InformacionAccionDetalles(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionAccionDetalles(). " + ex.Message;
            }

            return dsResultado;
        }
        public DataSet InformacionAccionDetallesCompleto(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.InformacionAccionDetallesCompleto(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionAccionDetalles(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionAccionRenglon(int idDetalleAccion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.InformacionAccionRenglon(idDetalleAccion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionAccion(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionMeta(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.InformacionMeta(id);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionMeta(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarAccion(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.EliminarAccion(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarAccion(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarDetalleAccion(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.EliminarDetalleAccion(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarAccion(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarMeta(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.EliminarMeta(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarMeta(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet DatosPoaDependencia(int idDependencia, int anio)
        {
            try
            {
                ObjAD = new PlanAccionAD();
                DataTable dt = ObjAD.DatosPoaDependencia(idDependencia, anio);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("DatosPoaDependencia(). " + ex.Message);
            }
        }

        public DataSet PptoPoa(int idPoa)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();

            try
            {
                DataTable dt = ObjAD.PptoPoa(idPoa);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.PptoPoa(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet PptoPoa(int idPoa, int idDependencia)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();

            try
            {
                DataTable dt = ObjAD.PptoPoa(idPoa,idDependencia);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.PptoPoa(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet PptoDep(int idPoa, int idDependencia)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();

            try
            {
                DataTable dt = ObjAD.PptoDep(idPoa, idDependencia);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.PptoDep(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet PptoRenglonAccion(int idDetalleAccion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();

            try
            {
                DataTable dt = ObjAD.PptoRenglonAccion(idDetalleAccion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.PptoRenglonAccion(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet ActualizarCodigos(string idOO, string codOO, string idAc, string codAc, string usuario)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.ActualizarCodigos(idOO, codOO, idAc, codAc, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = "";
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarMeta(). " + ex.Message;
            }

            return dsResultado;
        }

        //REGION GESFOR2

        public void DdlDependencias(DropDownList drop, string usuario)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0 - 0";

            if (usuario != "")
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlDependenciasGESFOR2(usuario);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }

        public void DdlAccionesGESFOR2T(DropDownList drop, string interno, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (interno != "")
            {
                ObjAD = new PlanAccionAD();
                drop.DataSource = ObjAD.DdlAccionesGESFOR2T(interno, idUnidad);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();

            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }

        public DataSet InformacionGESFOR2(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAccionAD();
            try
            {
                DataTable dt = ObjAD.InformacionGESFOR2(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionGESFOR2(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarGESFOR2(DataSet dsGESFOR2)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanAccionAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarGESFOR2(dsGESFOR2);

                if (bool.Parse(ds.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = ds.Tables[0].Rows[0]["VALOR"].ToString();
                dsResultado.Tables[0].Rows[0]["CODIGO"] = ds.Tables[0].Rows[0]["CODIGO"].ToString();
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarGESFOR2(). " + ex.Message;
            }

            return dsResultado;
        }

        //REGION GESFOR2 FINAL
    }
}

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
    public class PlanOperativoLN
    {
        PlanOperativoAD ObjAD;
       
        public void DdlAnio(DropDownList drop)
        {
            
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Año >>");
            drop.Items[0].Value = "0";
            ObjAD = new PlanOperativoAD();
            drop.DataSource = ObjAD.DdlAnios();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlMeses(DropDownList drop)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Mes >>");
            drop.Items[0].Value = "0";
            ObjAD = new PlanOperativoAD();
            drop.DataSource = ObjAD.DdlMeses();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlUnidades(DropDownList drop, string usuario)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";
            ObjAD = new PlanOperativoAD();
            drop.DataSource = ObjAD.DdlUnidades(usuario);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }

        public void DdlDependencias(DropDownList drop, string id)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";
            ObjAD = new PlanOperativoAD();
            drop.DataSource = ObjAD.DdlDependencias(id);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

          
        }
        public void DdlDependenciasmUnidad(DropDownList drop, string id)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";
            ObjAD = new PlanOperativoAD();
            drop.DataSource = ObjAD.DdlDependenciasmUnidad(id);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();


        }
        public void DdlDependenciasxAnalista(DropDownList drop, string usuario,int anio,int id)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";
            ObjAD = new PlanOperativoAD();
            drop.DataSource = ObjAD.DdlDependenciasxAnalista(usuario,anio,id);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();


        }

        public void DdlUnidades(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";
            ObjAD = new PlanOperativoAD();
            drop.DataSource = ObjAD.DdlUnidades();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }

        public void DdlUnidadesxAnalista(DropDownList drop, string usuario, int anio)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";
            ObjAD = new PlanOperativoAD();
            drop.DataSource = ObjAD.DdlUnidadesxAnalista(usuario, anio);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }

        public void DdlProcesos(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";
            ObjAD = new PlanOperativoAD();
            drop.DataSource = ObjAD.DdlProcesos(); ;
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }

        public void DdlObjetivos(DropDownList drop, int idObjEstrategico)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idObjEstrategico > 0)
            {
                ObjAD = new PlanOperativoAD();
                drop.DataSource = ObjAD.DdlObjetivos(idObjEstrategico);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlObjetivosxMeta(DropDownList drop, int idMeta, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idMeta > 0)
            {
                ObjAD = new PlanOperativoAD();
                drop.DataSource = ObjAD.DdlObjetivosxMeta(idMeta, idUnidad);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlObjetivosB(DropDownList drop, int anio, int idUnidad)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (anio > 0)
            {
                ObjAD = new PlanOperativoAD();
                drop.DataSource = ObjAD.DdlObjetivosB(anio, idUnidad);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlObjetivos(DropDownList drop, int idObjEstrategico, int idUnidad, int anio)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idObjEstrategico > 0)
            {
                ObjAD = new PlanOperativoAD();
                drop.DataSource = ObjAD.DdlObjetivos(anio, idUnidad, idObjEstrategico);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlIndicadores(DropDownList drop, int idOOperativo, int idMetaEstrategica)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idOOperativo > 0)
            {
                ObjAD = new PlanOperativoAD();
                drop.DataSource = ObjAD.DdlIndicadores(idOOperativo, idMetaEstrategica);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlIndicadores(DropDownList drop, int idOOperativo)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idOOperativo > 0)
            {
                ObjAD = new PlanOperativoAD();
                drop.DataSource = ObjAD.DdlIndicadores(idOOperativo);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void DdlMetas(DropDownList drop, int idIndicador)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idIndicador > 0)
            {
                ObjAD = new PlanOperativoAD();
                drop.DataSource = ObjAD.DdlMetas(idIndicador);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            drop.DataBind();
        }

        public void GridBusqueda(GridView grid, string Usuario)
        {
            ObjAD = new PlanOperativoAD();
            grid.DataSource = ObjAD.GridBusqueda(Usuario);
            grid.DataBind();
        }

        public void GridCodificacion(GridView grid, int idPoa)
        {
            ObjAD = new PlanOperativoAD();
            grid.DataSource = ObjAD.GridCodificacion(idPoa);
            grid.DataBind();
        }

        public DataSet AlmacenarObjetivo(ObjOperativosEN ObjEN, string usuario,string ip,string mac,string pc)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanOperativoAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarObjetivo(ObjEN, usuario,ip,mac,pc);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                dsResultado.Tables[0].Rows[0]["CODIGO"] = dt.Rows[0]["CODIGO"].ToString();
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InsertarObjetivo(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarIndicador(IndOperativosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanOperativoAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarIndicador(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarIndicador(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarMeta(MetasOperativasEN ObjEN, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanOperativoAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarMeta(ObjEN,usuario);

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

        public DataSet Insertar(ObjOperativosEN ObjOperativosE)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanOperativoAD();
            try
            {
                DataTable dt = ObjAD.Insertar(ObjOperativosE);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Insertar(). " + ex.Message;
            }

            return dsResultado;
        }

        private DataSet armarDsResultado()
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
            ObjAD = new PlanOperativoAD();

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

        public DataSet InformacionObjetivo(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanOperativoAD();
            try
            {
                DataTable dt = ObjAD.InformacionObjetivo(id);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionObjetivo(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionIndicador(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanOperativoAD();
            try
            {
                DataTable dt = ObjAD.InformacionIndicador(id);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionIndicador(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionMeta(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanOperativoAD();
            try
            {
                DataTable dt = ObjAD.InformacionMeta(id);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionIndicador(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarObjetivo(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanOperativoAD();
            try
            {
                DataTable dt = ObjAD.EliminarObjetivo(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarIndicador(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarIndicador(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanOperativoAD();
            try
            {
                DataTable dt = ObjAD.EliminarIndicador(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarIndicador(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarMeta(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanOperativoAD();
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
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarIndicador(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet ActualizarEstadoPoa(int idPoa, int idEstado, int anio, string idUsuario, string usuarioAsignado, string usuario, string observaciones,string ip,string mac,string pc,string tipo,string boton)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanOperativoAD();
            try
            {
                DataTable dt = ObjAD.ActualizarEstadoPoa(idPoa, idEstado, anio, idUsuario, usuarioAsignado, usuario, observaciones,ip,mac,pc,tipo,boton);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPoa;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.ActualizarEstadoPoa(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet DatosPoaUnidad(int idUnidad, int anio)
        {
            try
            {
                ObjAD = new PlanOperativoAD();
                DataTable dt = ObjAD.DatosPoaUnidad(idUnidad, anio, "", 1);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("DatosPoaUnidad(). " + ex.Message);
            }
        }

        public DataSet DatosPoaUnidad(int idUnidad, int anio, string criterio, int opcion)
        {
            try
            {
                ObjAD = new PlanOperativoAD();
                DataTable dt = ObjAD.DatosPoaUnidad(idUnidad, anio, criterio, opcion);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("DatosPoaUnidad(). " + ex.Message);
            }
        }


        public DataSet DependenciasFaltantes(int idUnidad, int anio)
        {
            try
            {
                ObjAD = new PlanOperativoAD();
                DataTable dt = ObjAD.DependenciasFaltantes(anio,idUnidad);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("DatosPoaUnidad(). " + ex.Message);
            }
        }

        public string ObtenerCorreo(int unidad, int menu)
        {
            ObjAD = new PlanOperativoAD();
            return ObjAD.ObtenerCorreo(unidad,menu);
        }

        public bool CantidadDePresupuestos(int anio,int unidad)
        {
            ObjAD = new PlanOperativoAD();
            return ObjAD.CantidadPpto(anio,unidad);
        }
        public string ObtenerCorreoxUsuario(string idempleado)
        {
            ObjAD = new PlanOperativoAD();
            return ObjAD.ObtenerCorreoxUsuario(idempleado);
        }
    }
}

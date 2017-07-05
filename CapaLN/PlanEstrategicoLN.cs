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
   public class PlanEstrategicoLN
    {
       PlanEstrategicoAD ObjAD;
       
        public void DdlAnio(DropDownList drop)
        {
            
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";
            ObjAD = new PlanEstrategicoAD();
            drop.DataSource = ObjAD.DdlAnios();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlPlanes(DropDownList drop)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";
            ObjAD = new PlanEstrategicoAD();
            drop.DataSource = ObjAD.DdlPlanes();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlAniosMeta(DropDownList drop, int anioIni, int anioFin)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            if (anioIni > 0)
            {
                ListItemCollection list = new ListItemCollection();                
                for (int i = anioIni; i <= anioFin; i++)
                    list.Add(new ListItem(i.ToString(), i.ToString()));

                drop.DataSource = list;
                drop.DataBind();
                drop.SelectedValue = anioIni.ToString();
            }
        }

        public void DdlAniosPlan(DropDownList drop, int anioIni, int anioFin)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (anioIni > 0)
            {
                ListItemCollection list = new ListItemCollection();
                for (int i = anioIni; i <= anioFin; i++)
                    list.Add(new ListItem(i.ToString(), i.ToString()));

                drop.DataSource = list;
                drop.DataBind();
            }
        }

        public void DdlEjes(DropDownList drop, int idPlan)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (idPlan > 0)
            {
                ObjAD = new PlanEstrategicoAD();
                drop.DataSource = ObjAD.DdlEjes(idPlan);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }

            drop.DataBind();
        }

        public void DdlObjetivos_X_Eje(DropDownList drop, int idEjeEstratregico)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idEjeEstratregico > 0)
            {
                ObjAD = new PlanEstrategicoAD();
                drop.DataSource = ObjAD.DdlObjEstrategicos_X_Eje(idEjeEstratregico);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }

            drop.DataBind();            
        }

        public void DdlIndicadores_X_Objetivo(DropDownList drop, int idObjetivo)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idObjetivo > 0)
            {
                ObjAD = new PlanEstrategicoAD();
                drop.DataSource = ObjAD.DdlIndicadores_X_Objetivo(idObjetivo);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }

            drop.DataBind();
        }

        public void DdlMetas_X_Indicador(DropDownList drop, int idIndicador)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idIndicador > 0)
            {

                ObjAD = new PlanEstrategicoAD();
                drop.DataSource = ObjAD.DdlMetas_X_Indicador(idIndicador);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            
            drop.DataBind();
        }

        public void DdlMetas_X_Obj_Estr(DropDownList drop, int idObjetivoEstrategico, int anio)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            if (idObjetivoEstrategico > 0)
            {

                ObjAD = new PlanEstrategicoAD();
                drop.DataSource = ObjAD.DdlMetas_X_Obj_Estr(idObjetivoEstrategico, anio);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }

            drop.DataBind();
        }

        public void RblUnidades(RadioButtonList Radio)
        {
            Radio.ClearSelection();
            Radio.Items.Clear();
            ObjAD = new PlanEstrategicoAD();
            Radio.DataSource = ObjAD.RblUnidades();
            Radio.DataTextField = "texto";
            Radio.DataValueField = "id";
            Radio.DataBind();
            Radio.SelectedIndex = 0;
        }

        public void GridBusqueda(GridView grid)
        {
            ObjAD = new PlanEstrategicoAD();
            grid.DataSource = ObjAD.GridBusqueda();
            grid.DataBind();
        }

        public DataSet AlmacenarPlanEstrategico(EjesEN ObjEN,string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanEstrategicoAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarPlanEstrategico(ObjEN,usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
            }
            catch (Exception ex)
            {
                if (ex.Message == "There is no row at position 0. ")
                {
                    dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarPlanEstrategico(). El usuario no tiene los permisos necesariios " ;
                }
               
            }

            return dsResultado;
        }

        public DataSet AlmacenarObjetivo(ObjEstrategicosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanEstrategicoAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarObjetivo(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());                

                dsResultado.Tables[0].Rows[0]["ERRORES"] = false; 
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarObjetivo(). " + ex.Message;
            }

            return dsResultado;   
        }

        public DataSet AlmacenarIndicador(IndEstrategicosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanEstrategicoAD();
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

        public DataSet AlmacenarMeta(MetasEstrategicasEN ObjEN,string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanEstrategicoAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarMeta(ObjEN, usuario);

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

        private DataSet armarDsResultado()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("RESULTADO");

            dt.Columns.Add("ERRORES", typeof(String));
            dt.Columns.Add("MSG_ERROR", typeof(String));
            dt.Columns.Add("VALOR", typeof(String));
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
            ObjAD = new PlanEstrategicoAD();
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

        public DataSet InformacionPlanEstrategico(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanEstrategicoAD();
            try
            {
                DataTable dt = ObjAD.InformacionPlanEstrategico(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionPlanEstrategico(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionObjetivo(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanEstrategicoAD();
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
            ObjAD = new PlanEstrategicoAD();
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
            ObjAD = new PlanEstrategicoAD();
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

        public DataSet EliminarPlanEstrategico(int id, string usuario)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanEstrategicoAD();
            try
            {
                DataTable dt = ObjAD.EliminarPlanEstrategico(id,usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarPlanEstrategico(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarObjetivo(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanEstrategicoAD();
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
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarObjetivo(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarIndicador(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanEstrategicoAD();
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
            ObjAD = new PlanEstrategicoAD();
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
    }
}

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
   public class ObjEstrategicosLN
    {
       ObjEstrategicosAD ObjAD;
       
        public void DdlAnio(DropDownList drop)
        {
            
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Año >>");
            drop.Items[0].Value = "0";
            ObjAD = new ObjEstrategicosAD();
            drop.DataSource = ObjAD.DdlAnios();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlAniosMeta(DropDownList drop, int anio)
        {            
            ListItemCollection list = new ListItemCollection();
            list.Add(new ListItem(anio.ToString(), anio.ToString()));
            for (int i = 1; i <= 4; i++)
                list.Add(new ListItem((anio + i).ToString(), (anio + i).ToString()));

            drop.Items.Clear();
            drop.DataSource = list;
            drop.DataBind();
            drop.SelectedValue = anio.ToString();
        }

        public void DdlEjes(DropDownList drop, int anio)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Eje >>");
            drop.Items[0].Value = "0";

            if (anio > 0)
            {
                ObjAD = new ObjEstrategicosAD();
                drop.DataSource = ObjAD.DdlEjes(anio);
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
                ObjAD = new ObjEstrategicosAD();
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
                ObjAD = new ObjEstrategicosAD();
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
                
                ObjAD = new ObjEstrategicosAD();
                drop.DataSource = ObjAD.DdlMetas_X_Indicador(idIndicador);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
            }
            
            drop.DataBind();
        }

        public void RblUnidades(RadioButtonList Radio)
        {
            Radio.ClearSelection();
            Radio.Items.Clear();
            ObjAD = new ObjEstrategicosAD();
            Radio.DataSource = ObjAD.RblUnidades();
            Radio.DataTextField = "texto";
            Radio.DataValueField = "id";
            Radio.DataBind();
        }

        public void GridBusqueda(GridView grid)
        {
            ObjAD = new ObjEstrategicosAD();
            grid.DataSource = ObjAD.GridBusqueda();
            grid.DataBind();
        }

        public DataSet Insertar(ObjEstrategicosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new ObjEstrategicosAD();
            try
            {
                DataTable dt = ObjAD.Insertar(ObjEN);

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
            ds.Tables.Add(dt);

            DataRow dr = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(dr);
            ds.Tables[0].Rows[0]["ERRORES"] = true;
            ds.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
            return ds;
        }


        public DataSet Existe(ObjEstrategicosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new ObjEstrategicosAD();
            try
            {
                DataTable dt = ObjAD.Existe(ObjEN);

                if (int.Parse(dt.Rows[0][0].ToString()) == 0)
                {
                    dsResultado.Tables[0].Rows[0]["ERRORES"] = false; 
                    dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                }
                else
                    dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "El código, año y eje ingresado ya existen";                
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Existe(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet BuscarId(string id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new ObjEstrategicosAD();
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
            ObjAD = new ObjEstrategicosAD();
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
            ObjAD = new ObjEstrategicosAD();
            try
            {
                DataTable dt = ObjAD.InformacionIndicador(id);
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

        public DataSet InformacionMeta(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new ObjEstrategicosAD();
            try
            {
                DataTable dt = ObjAD.InformacionMeta(id);
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

        public DataSet Actualizar(ObjEstrategicosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new ObjEstrategicosAD();
            try
            {
                DataTable dt = ObjAD.Actualizar(ObjEN);
                if (bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                else
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Actualizar(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet Eliminar(ObjEstrategicosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new ObjEstrategicosAD();
            try
            {
                DataTable dt = ObjAD.Eliminar(ObjEN);
                if (bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                else
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Eliminar(). " + ex.Message;
            }

            return dsResultado;
        }
    }
}

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
    public class MetasEstrategicasLN
    {
        MetasEstrategicasAD ObjAD;
       
        public void DdlAnio(DropDownList drop)
        {
            
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Año >>");
            drop.Items[0].Value = "0";
            ObjAD = new MetasEstrategicasAD();
            drop.DataSource = ObjAD.DdlAnios();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlObjetivos(DropDownList drop, string anio)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Objetivo >>");
            drop.Items[0].Value = "0";
            ObjAD = new MetasEstrategicasAD();
            drop.DataSource = ObjAD.DdlObjEstrategicos(anio);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void CblUnidades(RadioButtonList Radio)
        {
            Radio.ClearSelection();
            Radio.Items.Clear();
            ObjAD = new MetasEstrategicasAD();
            Radio.DataSource = ObjAD.CblUnidades();
            Radio.DataTextField = "texto";
            Radio.DataValueField = "id";
            Radio.DataBind();
        }

        public void GridBusqueda(GridView grid)
        {
            ObjAD = new MetasEstrategicasAD();
            grid.DataSource = ObjAD.GridBusqueda();
            grid.DataBind();
        }

        public DataSet Insertar(MetasEstrategicasEN ObjEN)
        {
            DataSet dsResultado = Existe(ObjEN);

            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                return dsResultado;

            ObjAD = new MetasEstrategicasAD();
            try
            {
                DataSet ds = ObjAD.Insertar(ObjEN);

                if (!bool.Parse(ds.Tables["ENCABEZADO"].Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(ds.Tables["ENCABEZADO"].Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["VALOR"] = ds.Tables["ENCABEZADO"].Rows[0]["MENSAJE"].ToString();
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["ERRORES"] = true;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = ex.Message;
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

        public DataSet Existe(MetasEstrategicasEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new MetasEstrategicasAD();
            try
            {
                DataTable dt = ObjAD.Existe(ObjEN);

                if (int.Parse(dt.Rows[0][0].ToString()) == 0)
                {
                    dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                    dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                }
                else
                    dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "El año, eje, objetivo y meta estratégica ingresado ya existen";
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "Error en Existe(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet BuscarId(string id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new MetasEstrategicasAD();
            try
            {
                DataSet ds = ObjAD.BuscarId(id);
                ds.Tables[0].TableName = "BUSQUEDA";
                dsResultado.Tables.Add(ds.Tables[0].Copy());
                dsResultado.Tables.Add(ds.Tables[1].Copy());
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.BuscarId(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet Actualizar(MetasEstrategicasEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new MetasEstrategicasAD();
            try
            {
                DataSet ds = ObjAD.Actualizar(ObjEN);
                if (bool.Parse(ds.Tables[0].Rows[0]["RESULTADO"].ToString()))
                    dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                else
                    throw new Exception(ds.Tables[0].Rows[0]["MENSAJE"].ToString());
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Actualizar(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet Eliminar(MetasEstrategicasEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new MetasEstrategicasAD();
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

        public DataSet InsertarUnidad(string idMeta, string idUnidad)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new MetasEstrategicasAD();
            try
            {
                DataTable dt = ObjAD.InsertarUnidad(idMeta, idUnidad);
                if (bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                else
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["ERRORES"] = true;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "CapaLN.InsertarUnidad(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarUnidad(string idMeta, string idUnidad)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new MetasEstrategicasAD();
            try
            {
                DataTable dt = ObjAD.EliminarUnidad(idMeta, idUnidad);
                if (bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                else
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["ERRORES"] = true;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "CapaLN.EliminarUnidad(). " + ex.Message;
            }

            return dsResultado;
        }
    }
}

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
    public class CmiLN
    {
        CmiAD ObjAD;
       
        public void DdlAnio(DropDownList drop)
        {
            
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Año >>");
            drop.Items[0].Value = "0";
            ObjAD = new CmiAD();
            drop.DataSource = ObjAD.DdlAnios();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlMetas(DropDownList drop, string anio)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Meta >>");
            drop.Items[0].Value = "0";
            ObjAD = new CmiAD();
            drop.DataSource = ObjAD.DdlMetas(anio);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlUnidades(DropDownList drop, string usuario)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Unidad >>");
            drop.Items[0].Value = "0";
            ObjAD = new CmiAD();
            drop.DataSource = ObjAD.DdlUnidades(usuario);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void GridBusqueda(GridView grid, string Usuario)
        {
            ObjAD = new CmiAD();
            grid.DataSource = ObjAD.GridBusqueda(Usuario);
            grid.DataBind();
        }

        public DataSet Insertar(CmiEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new CmiAD();
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

        public DataSet BuscarId(string id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new CmiAD();

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

        public DataSet Actualizar(CmiEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new CmiAD();
            try
            {
                DataTable dt = ObjAD.Actualizar(ObjEN);

                if(!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Actualizar(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet Eliminar(CmiEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new CmiAD();
            try
            {
                DataTable dt = ObjAD.Eliminar(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Eliminar(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet ActualizarCodigoPoa(CmiEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new CmiAD();
            try
            {
                DataTable dt = ObjAD.ActualizarCodigoPoa(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Actualizar(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet DatosPoaUnidad(int idUnidad, int anio)
        {
            try{
                ObjAD = new CmiAD();
                DataTable dt = ObjAD.DatosPoaUnidad(idUnidad, anio);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("DatosPoaUnidad(). " + ex.Message);
            }
        }

        public DataSet DatosPoaDependencia(int idDependencia, int anio)
        {
            try
            {
                ObjAD = new CmiAD();
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

        public DataSet PresupuestoPoa(int idPoa)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new CmiAD();

            try
            {
                DataTable dt = ObjAD.PresupuestoPoa(idPoa);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.PresupuestoPoa(). " + ex.Message;
            }

            return dsResultado;
        }
    }
}

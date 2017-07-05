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
   public class EjesLN
    {
       EjesAD ObjAD; 
       
        public void DdlAnio(DropDownList drop)
        {
            
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Año >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            ObjAD = new EjesAD();
            drop.DataSource = ObjAD.DdlAnios();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void GridBusqueda(GridView grid)
        {
            ObjAD = new EjesAD();
            grid.DataSource = ObjAD.GridBusqueda();
            grid.DataBind();
        }

        public DataSet Insertar(EjesEN ObjEN,string usuario)
        {
            DataSet dsResultado = Existe(ObjEN);

            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                return dsResultado;

            ObjAD = new EjesAD();
            try
            {
                DataTable dt = ObjAD.Insertar(ObjEN,usuario);                

                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["id"].ToString();
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Insertar(). " + ex.Message;
            }

            return dsResultado;            
        }

        private DataSet ObtenerDsResultado()
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

        public DataSet Existe(EjesEN ObjEN)
        {
            DataSet dsResultado = ObtenerDsResultado();
            ObjAD = new EjesAD();
            try
            {
                DataTable dt = ObjAD.Existe(ObjEN);

                if (int.Parse(dt.Rows[0][0].ToString()) == 0)
                {
                    dsResultado.Tables[0].Rows[0]["ERRORES"] = false; 
                    dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                }
                else
                    dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = "El código y año ingresado ya existen";                
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Insertar(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet BuscarId(string id)
        {
            DataSet dsResultado = ObtenerDsResultado();
            ObjAD = new EjesAD();
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

        public DataSet Actualizar(EjesEN ObjEN,string usuario)
        {
            DataSet dsResultado = ObtenerDsResultado();
            ObjAD = new EjesAD();
            try
            {
                DataTable dt = ObjAD.Actualizar(ObjEN,usuario);
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

        public DataSet Eliminar(EjesEN ObjEN,string usuario)
        {
            DataSet dsResultado = ObtenerDsResultado();
            ObjAD = new EjesAD();
            try
            {
                DataTable dt = ObjAD.Eliminar(ObjEN,usuario);
                if(bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
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

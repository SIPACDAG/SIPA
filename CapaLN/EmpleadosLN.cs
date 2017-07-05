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
    public class EmpleadosLN
    {
        EmpleadosAD ObjAD;

        public void DdlUnidades(DropDownList drop)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Unidad >>");
            drop.Items[0].Value = "0";
            ObjAD = new EmpleadosAD();
            drop.DataSource = ObjAD.DdlUnidades();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlPuestos(DropDownList drop)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Puesto >>");
            drop.Items[0].Value = "0";
            ObjAD = new EmpleadosAD();
            drop.DataSource = ObjAD.DdlPuestos();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public DataSet AlmacenarEmpleado(EmpleadosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new EmpleadosAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarEmpleado(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString(); ;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarEmpleado(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarEmpleado(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new EmpleadosAD();
            try
            {
                DataTable dt = ObjAD.EliminarEmpleado(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarEmpleado(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionEmpleado(int id, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new EmpleadosAD();

            try
            {
                DataTable dt = ObjAD.InformacionEmpleados(id, opcion);

                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionEmpleado(). " + ex.Message;
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

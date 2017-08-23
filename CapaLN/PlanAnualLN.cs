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
    public class PlanAnualLN
    {
        PlanAnualAD ObjAD;

        public void DdlModalidades(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            ObjAD = new PlanAnualAD();
            drop.DataSource = ObjAD.DdlModalidades();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }

        public void DdlExcepciones(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            ObjAD = new PlanAnualAD();
            drop.DataSource = ObjAD.DdlExcepciones();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }

        public void DdlRenglones(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            ObjAD = new PlanAnualAD();
            drop.DataSource = ObjAD.DdlRenglones();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }

        public void DdlPac(DropDownList drop, int idDetalleAccion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            ObjAD = new PlanAnualAD();
            drop.DataSource = ObjAD.DdlPac(idDetalleAccion);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

            //if (drop.Items.Count == 2)
            //    drop.Items.RemoveAt(0);
        }

        public void DdlCategorias(DropDownList drop, string noRenglon)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija un valor >>");
            drop.Items[0].Value = "0";

            if (!noRenglon.Equals("0"))
            {
                ObjAD = new PlanAnualAD();
                drop.DataSource = ObjAD.DdlCategorias(noRenglon);
                drop.DataTextField = "texto";
                drop.DataValueField = "id";
                drop.DataBind();

                if (drop.Items.Count == 1)
                {
                    drop.Items[0].Text = "<< Sin categoría >>";
                    drop.Items[0].Value = "null";
                }

                if (drop.Items.Count == 2)
                    drop.Items.RemoveAt(0);

                if (drop.Items.Count > 2)
                {
                    drop.Items[0].Text = "<< Elija un valor >>";
                    drop.Items[0].Value = "0";
                }
            }
        }

        public void GridDetallesAccion(GridView grid, int idAccion)
        {
            ObjAD = new PlanAnualAD();
            DataTable dt = ObjAD.GridDetallesAccion(idAccion);
            if (dt.Rows.Count == 1 && dt.Rows[0]["id"].ToString().Equals(string.Empty))
                dt = null;
            grid.DataSource = dt; 
            grid.DataBind();
        }

        public void GridListadoPacs(GridView grid, string usuario, string idPoa)
        {
            ObjAD = new PlanAnualAD();
            DataTable dt = ObjAD.GridListadoPacs(usuario, idPoa);
            if (dt.Rows.Count == 1 && dt.Rows[0]["id"].ToString().Equals(string.Empty))
                dt = null;
            grid.DataSource = dt;
            grid.DataBind();
        }

        public void GridListadoPacs(GridView grid, int idPoa)
        {
            ObjAD = new PlanAnualAD();
            DataTable dt = ObjAD.GridListadoPacs(idPoa);
            if (dt.Rows.Count == 1 && dt.Rows[0]["id"].ToString().Equals(string.Empty))
                dt = null;
            grid.DataSource = dt;
            grid.DataBind();
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


        public DataSet AlmacenarPac(DataSet dsPac,string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new PlanAnualAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarPac(dsPac,usuario);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MENSAJE"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarPac(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarPac(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAnualAD();
            try
            {
                DataTable dt = ObjAD.EliminarPac(id);

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

        public DataSet InformacionPac(int idPac)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAnualAD();

            try
            {
                DataSet ds = ObjAD.InformacionPac(idPac);
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

        public DataSet InformacionRenglonAccion(int idDetalleAccion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAnualAD();

            try
            {
                DataTable dt = ObjAD.InformacionRenglonAccion(idDetalleAccion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.SaldoPac(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet ActualizarEstadoPac(int idPoa, int idEstado, int anio, string idUsuario, string usuarioAsignado, string usuario, string observaciones)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new PlanAnualAD();
            try
            {
                DataTable dt = ObjAD.ActualizarEstadoPac(idPoa, idEstado, anio, idUsuario, usuarioAsignado, usuario, observaciones);

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

    }
}

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
    public class PresupuestoLN
    {
        PresupuestoAD presupuestoAD;
        public void dropUnidad(DropDownList drop)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Unidad >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            presupuestoAD = new PresupuestoAD();
            drop.DataSource = presupuestoAD.dropUnidad();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropDependencia(DropDownList drop,int idUnidad)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Dependencia >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            presupuestoAD = new PresupuestoAD();
            drop.DataSource = presupuestoAD.dropDependencia(idUnidad);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropUsuarioUnidad(DropDownList drop,string usuario)
        {
            presupuestoAD = new PresupuestoAD();
            drop.DataSource = presupuestoAD.dropUnidadesUsuario(usuario);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public int valPresUnidad(PresupuestoEN presupuestoEN)
        {
            presupuestoAD = new PresupuestoAD();
            return presupuestoAD.valPresUnidad(presupuestoEN);
        }
        public int valPresDep(PresupuestoEN presupuestoEN)
        {
            presupuestoAD = new PresupuestoAD();
            return presupuestoAD.valPresDep(presupuestoEN);
        }
        public double saldoPresUnidad(PresupuestoEN presupuestoEN)
        {
            presupuestoAD = new PresupuestoAD();
            return presupuestoAD.SaldoPresUnidad(presupuestoEN);
        }

        public void gridPresupuesto(GridView grid, int anio)
        { 
            presupuestoAD = new PresupuestoAD();
            grid.DataSource = presupuestoAD.datosPresupuesto(anio);
            grid.DataBind();
        }
        public void gridPresupuesto(GridView grid, int anio, int unidad)
        {
            presupuestoAD = new PresupuestoAD();
            grid.DataSource = presupuestoAD.datosPresupuesto(anio,unidad);
            
            grid.DataBind();
        }
        public void gridPresupuestoDep(GridView grid,int anio,int idUnidad)
        {
            presupuestoAD = new PresupuestoAD();
            grid.DataSource = presupuestoAD.datosPresupuestoDep(anio, idUnidad);
            grid.DataBind();
        }
        public int InsertarPresUnidad(PresupuestoEN presupuestoEN, string usuario)
        {
            presupuestoAD = new PresupuestoAD();
            return presupuestoAD.InsertarPresUnidad(presupuestoEN, usuario);
        }
        public DataSet AlmacenarModificacionTechoPpto(PresupuestoEN presupuestoEN, string usuario,int op)
        {
            DataSet dsResultado = armarDsResultado();

            presupuestoAD = new PresupuestoAD();
            try
            {
                DataSet ds = presupuestoAD.AlmacenarModificacionTechoPpto(presupuestoEN, usuario, op);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarModificacionTechoPpto(). " + ex.Message;
            }

            return dsResultado;
        }

        public int InsertarPresDep(PresupuestoEN presupuestoEN)
        {
            presupuestoAD = new PresupuestoAD();
            return presupuestoAD.InsertarPresDep(presupuestoEN);
        }
        public int EliminarPresUnidad(PresupuestoEN presupuestoEN, string usuario)
        {
            presupuestoAD = new PresupuestoAD();
            return presupuestoAD.EliminarPresUnidad(presupuestoEN, usuario);
        }

        public DataSet InformacionTechosPpto(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            presupuestoAD = new PresupuestoAD();
            try
            {
                DataTable dt = presupuestoAD.InformacionTechosPpto(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionTechosPpto(). " + ex.Message;
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
        public decimal validarMonto(int anio, int unidad)
        {
            presupuestoAD = new PresupuestoAD();
            return presupuestoAD.validarMonoto(anio, unidad);
        }

        public decimal ObtenerMontoGlobal(int anio, int unidad)
        {
            presupuestoAD = new PresupuestoAD();
            return presupuestoAD.ObtenerMontoGlobal(anio, unidad);
        }

        public decimal validarMontoDependecias(int anio, int unidad,int op)
        {
            presupuestoAD = new PresupuestoAD();
            return presupuestoAD.validarMontoDependencias(anio, unidad,op);
        }

        public void InsertarBitacora(string usuario,string unidad,string ip, string acc, string decs, decimal mInicial, decimal mFinal)
        {
            presupuestoAD = new PresupuestoAD();
            presupuestoAD.InsertarBitacora(usuario,unidad,ip,acc,decs,mInicial,mFinal);
        }
    }
}

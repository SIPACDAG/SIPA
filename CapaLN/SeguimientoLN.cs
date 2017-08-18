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
    public class SeguimientoLN
    {
        SeguimientoAD ObjAD;

        public DataSet AlmacenarCalendario(SeguimientoCalendarioEN ObjEN, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new SeguimientoAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarCalendario(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString(); ;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarCalendario(). " + ex.Message;
            }
            return dsResultado;
        }

        public DataSet AlmacenarSeguimiento(SEGUIMIENTOS_CMI ObjEN,string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new SeguimientoAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarSeguimiento(ObjEN);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarSeguimiento(). " + ex.Message;
            }
            return dsResultado;
        }

        public DataSet AlmacenarSeguimientoDet(DataSet dsDetalles, int opcion)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new SeguimientoAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarSeguimientoDet(dsDetalles, opcion);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarSeguimientoDet(). " + ex.Message;
            }
            return dsResultado;
        }

        public DataSet AlmacenarFechaRecepcion(SEGUIMIENTOS_CMI ObjEN,string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new SeguimientoAD();
            try
            {
                DataSet ds = ObjAD.AlmacenarFechaRecepcion(ObjEN);

                if (bool.Parse(ds.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return ds;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarSeguimiento(). " + ex.Message;
            }
            return dsResultado;
        }

        //ENVIAR EL SEGUIMIENTO A REVISIÓN DE SUBGERENTE/DIRECTOR
        public DataSet EnviarSeguimientoARevision(int idPedido, string observaciones, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new SeguimientoAD();
            try
            {
                DataTable dt = ObjAD.EnviarSeguimientoARevision(idPedido, observaciones, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EnviarPedidoARevision(). " + ex.Message;
            }

            return dsResultado;
        }

        //APROBADO NIVEL 1 - SUBGERENTE/DIRECTOR
        public DataSet AprobadoN1(int idPedido, string observaciones, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new SeguimientoAD();
            try
            {
                DataTable dt = ObjAD.AprobadoN1(idPedido, observaciones, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobadoN1(). " + ex.Message;
            }

            return dsResultado;
        }

        //RECHAZADO NIVEL 1 - SUBGERENTE/DIRECTOR
        public DataSet RechazadoN1(int idPedido, string observaciones, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new SeguimientoAD();
            try
            {
                DataTable dt = ObjAD.RechazadoN1(idPedido, observaciones, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazadoN1(). " + ex.Message;
            }

            return dsResultado;
        }

        //APROBADO NIVEL 2 - ANALISTA DGE
        public DataSet AprobadoN2(int idPedido, string observaciones, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new SeguimientoAD();
            try
            {
                DataTable dt = ObjAD.AprobadoN2(idPedido, observaciones, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobadoN2(). " + ex.Message;
            }

            return dsResultado;
        }

        //RECHAZADO NIVEL 2 - ANALISTA DGE
        public DataSet RechazadoN2(int idPedido, string observaciones, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new SeguimientoAD();
            try
            {
                DataTable dt = ObjAD.RechazadoN2(idPedido, observaciones, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazadoN2(). " + ex.Message;
            }

            return dsResultado;
        }

        //APROBADO NIVEL 2 - ANALISTA DGE
        public DataSet AprobadoN3(int idPedido, string observaciones, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new SeguimientoAD();
            try
            {
                DataTable dt = ObjAD.AprobadoN3(idPedido, observaciones, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AprobadoN3(). " + ex.Message;
            }

            return dsResultado;
        }

        //RECHAZADO NIVEL 3 - DIRECTOR DGE
        public DataSet RechazadoN3(int idPedido, string observaciones, string usuario)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new SeguimientoAD();
            try
            {
                DataTable dt = ObjAD.RechazadoN3(idPedido, observaciones, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = idPedido;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.RechazadoN3(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionCalendarios(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new SeguimientoAD();

            try
            {
                DataTable dt = ObjAD.InformacionCalendarios(id, id2, criterio, opcion);

                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionCalendarios(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionSeguimientos(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new SeguimientoAD();

            try
            {
                DataTable dt = ObjAD.InformacionSeguimientos(id, id2, criterio, opcion);

                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionSeguimientos(). " + ex.Message;
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

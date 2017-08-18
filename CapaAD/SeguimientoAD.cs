using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using CapaEN;

namespace CapaAD
{
    public class SeguimientoAD
    {
        ConexionBD conectar;

        public DataTable AlmacenarCalendario(SeguimientoCalendarioEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable dt = new DataTable();

           ObjEN.ENTREGA_ENERO = "'" + ObjEN.ENTREGA_ENERO + "'";
           ObjEN.ENTREGA_FEBRERO = "'" + ObjEN.ENTREGA_FEBRERO + "'";
           ObjEN.ENTREGA_MARZO = "'" + ObjEN.ENTREGA_MARZO + "'";
           ObjEN.ENTREGA_ABRIL = "'" + ObjEN.ENTREGA_ABRIL + "'";
           ObjEN.ENTREGA_MAYO = "'" + ObjEN.ENTREGA_MAYO + "'";
           ObjEN.ENTREGA_JUNIO = "'" + ObjEN.ENTREGA_JUNIO + "'";
           ObjEN.ENTREGA_JULIO = "'" + ObjEN.ENTREGA_JULIO + "'";
           ObjEN.ENTREGA_AGOSTO = "'" + ObjEN.ENTREGA_AGOSTO + "'";
           ObjEN.ENTREGA_SEPTIEMBRE = "'" + ObjEN.ENTREGA_SEPTIEMBRE + "'";
           ObjEN.ENTREGA_OCTUBRE = "'" + ObjEN.ENTREGA_OCTUBRE + "'";
           ObjEN.ENTREGA_NOVIEMBRE = "'" + ObjEN.ENTREGA_NOVIEMBRE + "'";
           ObjEN.ENTREGA_DICIEMBRE = "'" + ObjEN.ENTREGA_DICIEMBRE + "'";

           ObjEN.ENTREGA_ENERO = ObjEN.ENTREGA_ENERO.Replace("''", "null");
           ObjEN.ENTREGA_FEBRERO = ObjEN.ENTREGA_FEBRERO.Replace("''", "null");
           ObjEN.ENTREGA_MARZO = ObjEN.ENTREGA_MARZO.Replace("''", "null");
           ObjEN.ENTREGA_ABRIL = ObjEN.ENTREGA_ABRIL.Replace("''", "null");
           ObjEN.ENTREGA_MAYO = ObjEN.ENTREGA_MAYO.Replace("''", "null");
           ObjEN.ENTREGA_JUNIO = ObjEN.ENTREGA_JUNIO.Replace("''", "null");
           ObjEN.ENTREGA_JULIO = ObjEN.ENTREGA_JULIO.Replace("''", "null");
           ObjEN.ENTREGA_AGOSTO = ObjEN.ENTREGA_AGOSTO.Replace("''", "null");
           ObjEN.ENTREGA_SEPTIEMBRE = ObjEN.ENTREGA_SEPTIEMBRE.Replace("''", "null");
           ObjEN.ENTREGA_OCTUBRE = ObjEN.ENTREGA_OCTUBRE.Replace("''", "null");
           ObjEN.ENTREGA_NOVIEMBRE = ObjEN.ENTREGA_NOVIEMBRE.Replace("''", "null");
           ObjEN.ENTREGA_DICIEMBRE = ObjEN.ENTREGA_DICIEMBRE.Replace("''", "null");

           //ObjEN.ID_ESTADO = ObjEN.ID_ESTADO.Replace("", "null");
           //ObjEN.ACTIVO = ObjEN.ACTIVO.Replace("", "null");
           ObjEN.USUARIO = ObjEN.USUARIO.Replace("''", "null");
           
           ObjEN.USUARIO = "'" + ObjEN.USUARIO + "'";
           string query = "CALL sp_iue_seguimiento_calendario(" + ObjEN.ID_SEGUIMIENTO_CALENDARIO + ", " + ObjEN.ID_PLAN + ", " + ObjEN.ANIO + ", " + ObjEN.ENTREGA_ENERO + ", " + ObjEN.ENTREGA_FEBRERO + ", " + ObjEN.ENTREGA_MARZO + ", " + ObjEN.ENTREGA_ABRIL + ", " + ObjEN.ENTREGA_MAYO + ", " + ObjEN.ENTREGA_JUNIO + ", " + ObjEN.ENTREGA_JULIO + ", " + ObjEN.ENTREGA_AGOSTO + ", " + ObjEN.ENTREGA_SEPTIEMBRE + ", " + ObjEN.ENTREGA_OCTUBRE + ", " + ObjEN.ENTREGA_NOVIEMBRE + ", " + ObjEN.ENTREGA_DICIEMBRE + ", " + ObjEN.ID_ESTADO + ", " + ObjEN.ACTIVO + ", " + ObjEN.USUARIO + ", 1);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(dt);
           conectar.CerrarConexion();
           return dt;
       }

        public DataSet AlmacenarSeguimiento(SEGUIMIENTOS_CMI ObjEN)
        {
            string query = "";
            DataSet dsResultado;
            DataTable dt;
            DataTable dtEnc;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            ObjEN.ID_SEGUIMIENTO_CMI = ConstruirCampoInsertMySQL(ObjEN.ID_SEGUIMIENTO_CMI, 1, ',');
            ObjEN.ID_POA = ConstruirCampoInsertMySQL(ObjEN.ID_POA, 1, ',');
            ObjEN.ID_UNIDAD = ConstruirCampoInsertMySQL(ObjEN.ID_UNIDAD, 1, ',');
            ObjEN.ANIO = ConstruirCampoInsertMySQL(ObjEN.ANIO, 1, ',');
            ObjEN.NO_CUATRIMESTRE = ConstruirCampoInsertMySQL(ObjEN.NO_CUATRIMESTRE, 1, ',');
            ObjEN.MES = ConstruirCampoInsertMySQL(ObjEN.MES, 1, ',');
            ObjEN.ID_ESTADO = ConstruirCampoInsertMySQL(ObjEN.ID_ESTADO, 1, ',');
            ObjEN.ANEXO = ConstruirCampoInsertMySQL(ObjEN.ANEXO, 2, ',');
            ObjEN.ID_SEGUIMIENTO_CALENDARIO = ConstruirCampoInsertMySQL(ObjEN.ID_SEGUIMIENTO_CALENDARIO, 1, ',');
            ObjEN.OBSERVACIONES_RECHAZO = ConstruirCampoInsertMySQL(ObjEN.OBSERVACIONES_RECHAZO, 2, ',');
            ObjEN.OBSERVACIONES_DGE = ConstruirCampoInsertMySQL(ObjEN.OBSERVACIONES_DGE, 2, ',');
            ObjEN.FECHA_RECEPCION = ConstruirCampoInsertMySQL(ObjEN.FECHA_RECEPCION, 2, ',');
            ObjEN.ACTIVO = ConstruirCampoInsertMySQL(ObjEN.ACTIVO, 1, ',');
            ObjEN.USUARIO = ConstruirCampoInsertMySQL(ObjEN.USUARIO, 2, ',');
            
            StringBuilder stringB = new StringBuilder();
            stringB.Append("CALL sp_iue_seguimientos_cmi(");
            stringB.Append(ObjEN.ID_SEGUIMIENTO_CMI);
            stringB.Append(ObjEN.ID_POA);
            stringB.Append(ObjEN.ID_UNIDAD);
            stringB.Append(ObjEN.ANIO);
            stringB.Append(ObjEN.NO_CUATRIMESTRE);
            stringB.Append(ObjEN.MES);
            stringB.Append(ObjEN.ID_ESTADO);
            stringB.Append(ObjEN.ANEXO);
            stringB.Append(ObjEN.ID_SEGUIMIENTO_CALENDARIO);
            stringB.Append(ObjEN.OBSERVACIONES_RECHAZO);
            stringB.Append(ObjEN.OBSERVACIONES_DGE);
            stringB.Append(ObjEN.FECHA_RECEPCION);
            stringB.Append(ObjEN.ACTIVO);
            stringB.Append(ObjEN.USUARIO);
            stringB.Append("1);");

            query =  stringB.ToString();

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);
                
                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            /*dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
            {
                int idEncabezado = int.Parse(dtEnc.Rows[0]["VALOR"].ToString());

                try
                {
                    
                    foreach (DataRow drDetalles in dsDetalles.Tables[0].Rows)
                    {
                        SEGUIMIENTOS_CMI_DET ObjEN_DET = new SEGUIMIENTOS_CMI_DET();

                        ObjEN_DET.ID_SEGUIMIENTO_CMI_DET = ConstruirCampoInsertMySQL(drDetalles["ID_SEGUIMIENTO_CMI_DET"].ToString(), 1, ',');
                        ObjEN_DET.ID_SEGUIMIENTO_CMI = ConstruirCampoInsertMySQL(idEncabezado.ToString(), 1, ',');
                        ObjEN_DET.ID_ACCION = ConstruirCampoInsertMySQL(drDetalles["ID_ACCION"].ToString(), 1, ',');
                        ObjEN_DET.DESCRIPCION = ConstruirCampoInsertMySQL(drDetalles["DESCRIPCION"].ToString(), 2, ',');
                        ObjEN_DET.PPTO_ANUAL = ConstruirCampoInsertMySQL(drDetalles["PPTO_ANUAL"].ToString(), 1, ',');
                        ObjEN_DET.AVANCE_PPTO_CUATRIMESTRAL = ConstruirCampoInsertMySQL(drDetalles["AVANCE_PPTO_CUATRIMESTRAL"].ToString(), 1, ',');
                        ObjEN_DET.AVANCE_PPTO_ACUMULADO = ConstruirCampoInsertMySQL(drDetalles["AVANCE_PPTO_ACUMULADO"].ToString(), 1, ',');
                        ObjEN_DET.SALDO = ConstruirCampoInsertMySQL(drDetalles["SALDO"].ToString(), 1, ',');
                        ObjEN_DET.MEDIOS_VERIFICACION = ConstruirCampoInsertMySQL(drDetalles["MEDIOS_VERIFICACION"].ToString(), 2, ',');
                        ObjEN_DET.AVANCE_KPI = ConstruirCampoInsertMySQL(drDetalles["AVANCE_KPI"].ToString(), 1, ',');
                        ObjEN_DET.DESCRIPCION_AVANCE_KPI = ConstruirCampoInsertMySQL(drDetalles["DESCRIPCION_AVANCE_KPI"].ToString(), 2, ',');
                        ObjEN_DET.ANEXO = ConstruirCampoInsertMySQL(drDetalles["ANEXO"].ToString(), 2, ',');
                        ObjEN_DET.OBSERVACIONES_DGE = ConstruirCampoInsertMySQL(drDetalles["OBSERVACIONES_DGE"].ToString(), 2, ',');
                        ObjEN_DET.PLAN_ACCION = ConstruirCampoInsertMySQL(drDetalles["PLAN_ACCION"].ToString(), 1, ',');
                        ObjEN_DET.ACTIVO = ConstruirCampoInsertMySQL(drDetalles["ACTIVO"].ToString(), 1, ',');
                        ObjEN_DET.USUARIO = ConstruirCampoInsertMySQL(drDetalles["USUARIO"].ToString(), 2, ',');

                        stringB = new StringBuilder();
                        stringB.Append("CALL sp_iue_seguimientos_cmi_det(");
                        stringB.Append(ObjEN_DET.ID_SEGUIMIENTO_CMI_DET);
                        stringB.Append(ObjEN_DET.ID_SEGUIMIENTO_CMI);
                        stringB.Append(ObjEN_DET.ID_ACCION);
                        stringB.Append(ObjEN_DET.DESCRIPCION);
                        stringB.Append(ObjEN_DET.PPTO_ANUAL);
                        stringB.Append(ObjEN_DET.AVANCE_PPTO_CUATRIMESTRAL);
                        stringB.Append(ObjEN_DET.AVANCE_PPTO_ACUMULADO);
                        stringB.Append(ObjEN_DET.SALDO);
                        stringB.Append(ObjEN_DET.MEDIOS_VERIFICACION);
                        stringB.Append(ObjEN_DET.AVANCE_KPI);
                        stringB.Append(ObjEN_DET.DESCRIPCION_AVANCE_KPI);
                        stringB.Append(ObjEN_DET.ANEXO);
                        stringB.Append(ObjEN_DET.OBSERVACIONES_DGE);
                        stringB.Append(ObjEN_DET.PLAN_ACCION);
                        stringB.Append(ObjEN_DET.ACTIVO);
                        stringB.Append(ObjEN_DET.USUARIO);
                        stringB.Append("1);");
                        
                        query =  stringB.ToString();

                        dt = new DataTable();
                        sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                        sqlAdapter.Fill(dt);


                        DataRow drDet = dtDet.NewRow();
                        drDet["ERRORES"] = dt.Rows[0]["RESULTADO"].ToString();
                        drDet["MSG_ERROR"] = "";
                        drDet["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                        dtDet.Rows.Add(drDet);
                    }
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }*/

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            //dsResultado.Tables.Add(dtDet);

            return dsResultado;
        }

        public DataSet AlmacenarSeguimientoDet(DataSet dsDetalles, int opcion)
        {
            string query = "";
            DataSet dsResultado;
            DataTable dt;
            DataTable dtEnc;
            DataTable dtDet;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            dt = new DataTable();
            dtEnc = armarDsResultado().Tables[0].Copy();
            dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);
            
            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();

            foreach (DataRow drDetalles in dsDetalles.Tables[0].Rows)
            {
                SEGUIMIENTOS_CMI_DET ObjEN_DET = new SEGUIMIENTOS_CMI_DET();

                ObjEN_DET.ID_SEGUIMIENTO_CMI_DET = ConstruirCampoInsertMySQL(drDetalles["ID_SEGUIMIENTO_CMI_DET"].ToString(), 1, ',');
                ObjEN_DET.ID_SEGUIMIENTO_CMI = ConstruirCampoInsertMySQL(drDetalles["ID_SEGUIMIENTO_CMI"].ToString(), 1, ',');
                ObjEN_DET.ID_ACCION = ConstruirCampoInsertMySQL(drDetalles["ID_ACCION"].ToString(), 1, ',');
                ObjEN_DET.DESCRIPCION = ConstruirCampoInsertMySQL(drDetalles["DESCRIPCION"].ToString(), 2, ',');
                ObjEN_DET.PPTO_ANUAL = ConstruirCampoInsertMySQL(drDetalles["PPTO_ANUAL"].ToString(), 1, ',');
                ObjEN_DET.AVANCE_PPTO_CUATRIMESTRAL = ConstruirCampoInsertMySQL(drDetalles["AVANCE_PPTO_CUATRIMESTRAL"].ToString(), 1, ',');
                ObjEN_DET.AVANCE_PPTO_ACUMULADO = ConstruirCampoInsertMySQL(drDetalles["AVANCE_PPTO_ACUMULADO"].ToString(), 1, ',');
                ObjEN_DET.SALDO = ConstruirCampoInsertMySQL(drDetalles["SALDO"].ToString(), 1, ',');
                ObjEN_DET.MEDIOS_VERIFICACION = ConstruirCampoInsertMySQL(drDetalles["MEDIOS_VERIFICACION"].ToString(), 2, ',');
                ObjEN_DET.AVANCE_KPI = ConstruirCampoInsertMySQL(drDetalles["AVANCE_KPI"].ToString(), 1, ',');
                ObjEN_DET.DESCRIPCION_AVANCE_KPI = ConstruirCampoInsertMySQL(drDetalles["DESCRIPCION_AVANCE_KPI"].ToString(), 2, ',');
                ObjEN_DET.ANEXO = ConstruirCampoInsertMySQL(drDetalles["ANEXO"].ToString(), 2, ',');
                ObjEN_DET.OBSERVACIONES_DGE = ConstruirCampoInsertMySQL(drDetalles["OBSERVACIONES_DGE"].ToString(), 2, ',');
                ObjEN_DET.PLAN_ACCION = ConstruirCampoInsertMySQL(drDetalles["PLAN_ACCION"].ToString(), 1, ',');
                ObjEN_DET.ACTIVO = ConstruirCampoInsertMySQL(drDetalles["ACTIVO"].ToString(), 1, ',');
                ObjEN_DET.USUARIO = ConstruirCampoInsertMySQL(drDetalles["USUARIO"].ToString(), 2, ',');

                StringBuilder stringB = new StringBuilder();
                stringB.Append("CALL sp_iue_seguimientos_cmi_det(");
                stringB.Append(ObjEN_DET.ID_SEGUIMIENTO_CMI_DET);
                stringB.Append(ObjEN_DET.ID_SEGUIMIENTO_CMI);
                stringB.Append(ObjEN_DET.ID_ACCION);
                stringB.Append(ObjEN_DET.DESCRIPCION);
                stringB.Append(ObjEN_DET.PPTO_ANUAL);
                stringB.Append(ObjEN_DET.AVANCE_PPTO_CUATRIMESTRAL);
                stringB.Append(ObjEN_DET.AVANCE_PPTO_ACUMULADO);
                stringB.Append(ObjEN_DET.SALDO);
                stringB.Append(ObjEN_DET.MEDIOS_VERIFICACION);
                stringB.Append(ObjEN_DET.AVANCE_KPI);
                stringB.Append(ObjEN_DET.DESCRIPCION_AVANCE_KPI);
                stringB.Append(ObjEN_DET.ANEXO);
                stringB.Append(ObjEN_DET.OBSERVACIONES_DGE);
                stringB.Append(ObjEN_DET.PLAN_ACCION);
                stringB.Append(ObjEN_DET.ACTIVO);
                stringB.Append(ObjEN_DET.USUARIO);
                stringB.Append(opcion + ");");

                DataRow drDet = dtDet.NewRow();

                try
                {
                    query = stringB.ToString();

                    dt = new DataTable();
                    sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                    sqlAdapter.Fill(dt);

                    if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                        throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                    dtEnc.Rows[0]["ERRORES"] = false;
                    dtEnc.Rows[0]["MSG_ERROR"] = "";
                    dtEnc.Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            dsResultado.Tables.Add(dtDet.Copy());

            return dsResultado;
        }


        public DataSet AlmacenarFechaRecepcion(SEGUIMIENTOS_CMI ObjEN)
        {
            string query = "";
            DataSet dsResultado = new DataSet();
            DataTable dt;
            DataTable dtEnc;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            ObjEN.ID_SEGUIMIENTO_CMI = ConstruirCampoInsertMySQL(ObjEN.ID_SEGUIMIENTO_CMI, 1, ',');
            ObjEN.ID_POA = ConstruirCampoInsertMySQL(ObjEN.ID_POA, 1, ',');
            ObjEN.ID_UNIDAD = ConstruirCampoInsertMySQL(ObjEN.ID_UNIDAD, 1, ',');
            ObjEN.ANIO = ConstruirCampoInsertMySQL(ObjEN.ANIO, 1, ',');
            ObjEN.NO_CUATRIMESTRE = ConstruirCampoInsertMySQL(ObjEN.NO_CUATRIMESTRE, 1, ',');
            ObjEN.MES = ConstruirCampoInsertMySQL(ObjEN.MES, 1, ',');
            ObjEN.ID_ESTADO = ConstruirCampoInsertMySQL(ObjEN.ID_ESTADO, 1, ',');
            ObjEN.ANEXO = ConstruirCampoInsertMySQL(ObjEN.ANEXO, 2, ',');
            ObjEN.ID_SEGUIMIENTO_CALENDARIO = ConstruirCampoInsertMySQL(ObjEN.ID_SEGUIMIENTO_CALENDARIO, 1, ',');
            ObjEN.OBSERVACIONES_RECHAZO = ConstruirCampoInsertMySQL(ObjEN.OBSERVACIONES_RECHAZO, 2, ',');
            ObjEN.OBSERVACIONES_DGE = ConstruirCampoInsertMySQL(ObjEN.OBSERVACIONES_DGE, 2, ',');
            ObjEN.FECHA_RECEPCION = ConstruirCampoInsertMySQL(ObjEN.FECHA_RECEPCION, 2, ',');
            ObjEN.ACTIVO = ConstruirCampoInsertMySQL(ObjEN.ACTIVO, 1, ',');
            ObjEN.USUARIO = ConstruirCampoInsertMySQL(ObjEN.USUARIO, 2, ',');

            StringBuilder stringB = new StringBuilder();
            stringB.Append("CALL sp_iue_seguimientos_cmi(");
            stringB.Append(ObjEN.ID_SEGUIMIENTO_CMI);
            stringB.Append(ObjEN.ID_POA);
            stringB.Append(ObjEN.ID_UNIDAD);
            stringB.Append(ObjEN.ANIO);
            stringB.Append(ObjEN.NO_CUATRIMESTRE);
            stringB.Append(ObjEN.MES);
            stringB.Append(ObjEN.ID_ESTADO);
            stringB.Append(ObjEN.ANEXO);
            stringB.Append(ObjEN.ID_SEGUIMIENTO_CALENDARIO);
            stringB.Append(ObjEN.OBSERVACIONES_RECHAZO);
            stringB.Append(ObjEN.OBSERVACIONES_DGE);
            stringB.Append(ObjEN.FECHA_RECEPCION);
            stringB.Append(ObjEN.ACTIVO);
            stringB.Append(ObjEN.USUARIO);
            stringB.Append("10);");

            query = stringB.ToString();

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

                sqlTransaction.Commit();
                conectar.CerrarConexion();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            dsResultado = new DataSet();            
            dsResultado.Tables.Add(dtEnc.Copy());

            return dsResultado;
        }

        //ENVIAR EL SEGUIMIENTO A APROBACIÓN DE SUB/DIR(SERVICIO)
        public DataTable EnviarSeguimientoARevision(int idSeguimiento, string observaciones, string usuario)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_seguimientos_cmi(" + idSeguimiento + ", null, null, null, null, null, null, null, null, null, null, null, null, '" + usuario + "', 3);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //APROBADO NIVEL 1 - SUBGERENTE/DIRECTOR
        public DataTable AprobadoN1(int idSeguimiento, string observaciones, string usuario)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_seguimientos_cmi(" + idSeguimiento + ", null, null, null, null, null, null, null, null, null, null, null, null, '" + usuario + "', 4);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //RECHAZADO NIVEL 1 - SUBGERENTE/DIRECTOR
        public DataTable RechazadoN1(int idSeguimiento, string observaciones, string usuario)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_seguimientos_cmi(" + idSeguimiento + ", null, null, null, null, null, null, null, null, '" + observaciones +"', null, null, null, '" + usuario + "', 5);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //APROBADO NIVEL 2 - ANALISTA DGE
        public DataTable AprobadoN2(int idSeguimiento, string observaciones, string usuario)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_seguimientos_cmi(" + idSeguimiento + ", null, null, null, null, null, null, null, null, null, null, null, null, '" + usuario + "', 6);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //RECHAZADO NIVEL 2 - ANALISTA DGE
        public DataTable RechazadoN2(int idSeguimiento, string observaciones, string usuario)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_seguimientos_cmi(" + idSeguimiento + ", null, null, null, null, null, null, null, null, '" + observaciones + "', null, null, null, '" + usuario + "', 7);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //APROBADO NIVEL 3 - DIRECTOR DGE
        public DataTable AprobadoN3(int idSeguimiento, string observaciones, string usuario)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_seguimientos_cmi(" + idSeguimiento + ", null, null, null, null, null, null, null, null, null, null, null, null, '" + usuario + "', 8);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //RECHAZADO NIVEL 3 - DIRECTOR DGE
        public DataTable RechazadoN3(int idSeguimiento, string observaciones, string usuario)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_seguimientos_cmi(" + idSeguimiento + ", null, null, null, null, null, null, null, null, '" + observaciones + "', null, null, null, '" + usuario + "', 9);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }


       /*public DataTable AlmacenarTipoCaso(TiposCasosEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable dt = new DataTable();

           ObjEN.NOMBRE = "'" + ObjEN.NOMBRE + "'";
           ObjEN.DESCRIPCION = "'" + ObjEN.DESCRIPCION + "'";
           ObjEN.ESTADO = "'" + ObjEN.ESTADO + "'";
           ObjEN.USUARIO = "'" + ObjEN.USUARIO + "'";

           ObjEN.NOMBRE = ObjEN.NOMBRE.Replace("''", "null");
           ObjEN.DESCRIPCION = ObjEN.DESCRIPCION.Replace("''", "null");
           ObjEN.ESTADO = ObjEN.ESTADO.Replace("''", "null");
           ObjEN.USUARIO = ObjEN.USUARIO.Replace("''", "null");

           string query = "CALL sp_iue_tipos_casos(" + ObjEN.ID_TIPO_CASO + ", " + ObjEN.NOMBRE + ", " + ObjEN.DESCRIPCION + ", " + ObjEN.ESTADO + ", " + ObjEN.USUARIO + ", 1);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(dt);
           conectar.CerrarConexion();
           return dt;
       }

       public DataTable AlmacenarAsignacionCaso(AsignacionCasosEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable dt = new DataTable();

           ObjEN.OBSERVACIONES = "'" + ObjEN.OBSERVACIONES + "'";
           ObjEN.ESTADO = "'" + ObjEN.ESTADO + "'";
           ObjEN.USUARIO = "'" + ObjEN.USUARIO + "'";

           ObjEN.OBSERVACIONES = ObjEN.OBSERVACIONES.Replace("''", "null");
           ObjEN.ESTADO = ObjEN.ESTADO.Replace("''", "null");
           ObjEN.USUARIO = ObjEN.USUARIO.Replace("''", "null");

           string query = "CALL sp_iue_asignaciones(" + ObjEN.ID_ASIGNACION + ", " + ObjEN.ID_CONTACTO + ", " + ObjEN.ID_CASO + ", " + ObjEN.OBSERVACIONES + ", " + ObjEN.ESTADO + ", " + ObjEN.USUARIO + ", 1);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(dt);
           conectar.CerrarConexion();
           return dt;
       }
       public DataTable EliminarAsignacion(int id, string usuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = "CALL sp_iue_asignaciones(" + id + ", 0, 0, null, null, '" + usuario + "', 2);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InformacionContactos(int id, int id2, string criterio, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctContactos({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }*/

       public DataTable InformacionCalendarios(int id, int id2, string criterio, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctSeguimientoCalendario({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InformacionSeguimientos(int id, int id2, string criterio, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctSeguimientos({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       /*public DataTable InformacionTiposCasos(int id, int id2, string criterio, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctTiposCasos({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InformacionAsignaciones(int id, int id2, string criterio, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctAsignaciones({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }*/
       
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


       public String ConstruirCampoInsertMySQL(string valor, int tipoDato, char separador)
       {
           System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
           string campoMySQL = "";

           //Numérico
           if (tipoDato == 1)
           {
               stringBuilder.Append("");
               stringBuilder.Append(valor);
               stringBuilder.Append("");

               if (separador != null)
                   stringBuilder.Append(separador + " ");

               campoMySQL = stringBuilder.ToString();
           }
           else if (tipoDato == 2)
           {
               stringBuilder.Append("'");
               stringBuilder.Append(valor);
               stringBuilder.Append("'");

               if (separador != null)
                   stringBuilder.Append(separador + " ");

               campoMySQL = stringBuilder.ToString();
               campoMySQL = campoMySQL.Replace("'', ", "null, ");
           }

           
           return campoMySQL;
       }
    }
}

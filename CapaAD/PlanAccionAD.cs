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
    public class PlanAccionAD
    {
        ConexionBD conectar;

        public DataTable DdlDependencias(string usuario, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL slctDependenciasxUsuario('{0}', {1});", usuario, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlDependenciasUnidad(int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("SELECT a.id_dependencia id, a.dependencia texto FROM ccl_dependencias a WHERE a.id_unidad = {0};", idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable DdlAcciones(int idMetaOperativa)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctAccion_MetaOp('{0}');", idMetaOperativa);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlAccionesPoa(int idPoa)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctAcciones_Poa({0});", idPoa);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlAcciones_x_ObjOperativo(int idObjetivoO)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctAccion_ObjOp('{0}');", idObjetivoO);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlAcciones_x_Dependencia(int anio, int idDependencia)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctAccion_Dependencia({0}, {1});", anio, idDependencia);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlAcciones(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctAcciones({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlMetasAccion(int idAccion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctMeta_Accion('{0}');", idAccion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlRenglones()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctRenglones(0, 0, '', 1);");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlRenglonesAccion(int idAccion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctRenglones({0}, 0, '', 4);", idAccion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable GridPlanCompleto(int idUnidad, int idPoa, int anio)
        {

            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string permiso = string.Format("SELECT 	 pu.id_Poa,u.id_unidad FROM sipa_poa pu right outer JOIN ccl_unidades u ON pu.id_Unidad = u.id_Unidad WHERE pu.anio = {1}" +
                "   and u.codigo_unidad = (select codigo_unidad from ccl_unidades  where id_unidad = {0});", idUnidad, anio);
            MySqlCommand cmd = new MySqlCommand(permiso, conectar.conectar);
            List<string> id_poas = new List<string>();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id_poas.Add(dr.GetString("id_unidad"));
                id_poas.Add(dr.GetString("id_poa"));
            }
            dr.Close();
            cmd.Dispose();
            DataTable tabla = new DataTable();
            for (int i = 0; i < id_poas.Count; i += 2)
            {
                string query = string.Format("CALL sp_slctPlanAccionGB({0}, {1});", id_poas[i], id_poas[i + 1]);
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
            }

            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlRenglonesAccion(int idAccion, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctRenglones({0}, 0, '', {1});", idAccion, opcion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlRenglonesPoa(int idPoa)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctRenglones({0}, 0, '', 3);", idPoa);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlInsumos(int idInsumo)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctInsumos({0}, 1);", idInsumo);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlFinanciamiento()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctTiposFinanciamiento();");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable GridPlan(int idUnidad, int idPoa)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = string.Format("CALL sp_slctPlanAccionGB({0}, {1});", idUnidad, idPoa);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable GridInsumoRenglon(string noRenglon, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = string.Format("CALL sp_slctInsumoRenglon('{0}', '{1}', {2});", noRenglon, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable GridPlanesResumen(int idEstado)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = string.Format("CALL sp_slctPoaxEstado('{0}');", idEstado);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable AlmacenarAccion(AccionesEN ObjEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_iu_accion({0}, {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', '{8}', '{9}', '{10}', {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, '{27}', {28});", +
                ObjEN.Id_Accion, ObjEN.Id_Poa, ObjEN.Id_Dependencia, ObjEN.Id_Objetivo_Operativo, ObjEN.Id_Meta_Operativa, ObjEN.Codigo, ObjEN.Accion, ObjEN.Meta_General, ObjEN.Meta_1, ObjEN.Meta_2, ObjEN.Meta_3, ObjEN.Ponderacion, ObjEN.Presupuesto, ObjEN.No_Actividades, +
                ObjEN.Enero, ObjEN.Febrero, ObjEN.Marzo, ObjEN.Abril, ObjEN.Mayo, ObjEN.Junio, ObjEN.Julio, ObjEN.Agosto, ObjEN.Septiembre, ObjEN.Octubre, ObjEN.Noviembre, ObjEN.Diciembre, ObjEN.Anio, ObjEN.Usuario, ObjEN.Id_Unidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable AlmacenarMeta(MetasAccionEN ObjEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_iu_metas_accion({0}, {1}, {2}, '{3}', '{4}', '{5}', '{6}', {7}, {8}, {9}, {10}, {11}, '{12}',{13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, '{26}');", +
                ObjEN.Id_Meta_Accion, ObjEN.Id_Accion, ObjEN.Id_Meta_Operativa, ObjEN.Meta_General, ObjEN.Meta_1, ObjEN.Meta_2, ObjEN.Meta_3, ObjEN.Ponderacion1, ObjEN.Ponderacion2, ObjEN.Ponderacion3, ObjEN.Presupuesto, ObjEN.No_Actividades, ObjEN.Responsable, +
                ObjEN.Enero, ObjEN.Febrero, ObjEN.Marzo, ObjEN.Abril, ObjEN.Mayo, ObjEN.Junio, ObjEN.Julio, ObjEN.Agosto, ObjEN.Septiembre, ObjEN.Octubre, ObjEN.Noviembre, ObjEN.Diciembre, ObjEN.Anio, ObjEN.Usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable AlmacenarDetalle(AccionesDetEN ObjEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_iu_accion_det({0}, {1}, '{2}', {3}, {4}, '{5}', {6}, {7});", ObjEN.Id_Detalle, ObjEN.Id_Accion, ObjEN.No_Renglon, ObjEN.Monto, ObjEN.Id_Tipo_Financiamiento, ObjEN.Usuario, "null", ObjEN.Id_Tipo_Detalle);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable AlmacenarDetalleTransferencias(AccionesDetTransferenciasEN ObjEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_iu_accion_det_transferencia({0}, {1}, {2}, {3}, {4}, {5}, {6}, '{7}', {8}, {9}, '{10}', {11}, {12}, {13}, {14}, '{15}', '{16}', '{17}');", ObjEN.vid_poa, ObjEN.vid_accion_origen, ObjEN.vid_detalle, ObjEN.vmonto_actual_origen, ObjEN.vmonto_nuevo_origen, ObjEN.vcodificado_origen, ObjEN.vdebito, ObjEN.vdestino_debito, ObjEN.vid_accion_destino, ObjEN.vid_detalle_destino, ObjEN.vno_renglon_ppto, ObjEN.vmonto_actual_destino, ObjEN.vmonto_nuevo_destino, ObjEN.vcodificado_destino, ObjEN.vcredito, ObjEN.vorigen_credito, ObjEN.vjustificacion, ObjEN.vusuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarId(string id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPlanOperativoM({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionAccion(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctAccionesM({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionAccionDetalles(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slct_detalles_accion({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        //DEVUELVE LA INFORMACIÓN, UN DETALLE DE ACCIÓN
        public DataTable InformacionAccionRenglon(int idDetalleAccion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctRenglones({0}, 0, '', 2);", idDetalleAccion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionMeta(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctMetaAccionM({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable EliminarAccion(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_el_accion({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable EliminarDetalleAccion(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_el_renglon({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable EliminarMeta(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = "";// String.Format("CALL sp_el_meta_operativa({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable DatosPoaDependencia(int idDependencia, int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL slctDatosPoaDep({0}, {1});", idDependencia, anio);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable PptoPoa(int idPoa)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPptoPoa({0});", idPoa);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable PptoPoa(int idPoa, int idDependencia)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPptoPoaUD({0}, {1});", idPoa, idDependencia);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable PptoDep(int idPoa, int idDependencia)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPptoDep({0}, {1});", idPoa, idDependencia);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable PptoRenglonAccion(int idDetalleAccion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPptoAccionDetalle({0});", idDetalleAccion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable ActualizarCodigos(string idOO, string codOO, string idAc, string codAc, string usuario)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_actualizar_codigos({0}, {1}, {2}, {3}, '{4}');", idOO, codOO, idAc, codAc, usuario);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        //REGION GESFOR2

        public DataTable DdlDependenciasGESFOR2(string usuario)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slct_Depend_GESFOR2('{0}');", usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlAccionesGESFOR2T(string interno, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctAccionGESFOR2T({0}, {1});", interno, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionGESFOR2(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = string.Format("CALL sp_slctGESFOR2({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
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

        public DataTable InformacionAccionDetallesCompleto(int id, int id2, string criterio, int opcion)
        {

            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string permiso = string.Format("SELECT 	 pu.id_Poa FROM sipa_poa pu right outer JOIN ccl_unidades u ON pu.id_Unidad = u.id_Unidad WHERE pu.anio = 2017" +
                "   and u.codigo_unidad = (select codigo_unidad from ccl_unidades  where id_unidad = (select id_unidad from sipa_poa where id_Poa = {0}));", id);
            MySqlCommand cmd = new MySqlCommand(permiso, conectar.conectar);
            List<string> id_poas = new List<string>();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                id_poas.Add(dr.GetString("id_poa"));
            }
            dr.Close();
            cmd.Dispose();
            DataTable tabla = new DataTable();
            for (int i = 0; i < id_poas.Count; i++)
            {
                string query = string.Format("CALL sp_slct_detalles_accion({0}, {1}, '{2}', {3});", id_poas[i], id2, criterio, opcion);
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
            }

            conectar.CerrarConexion();
            return tabla;
        }
        public DataSet AlmacenarGESFOR2(DataSet dsGESFOR2)
        {

            string query = "";
            DataSet dsResultado;
            DataTable dtTemp;
            DataTable dtEnc;
            DataTable dtDet;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            DataRow drEnc = dsGESFOR2.Tables["ENC"].Rows[0];
            string[] param = {drEnc["ID_SOLICITUD"].ToString(), drEnc["ID_FORMULARIO"].ToString(),  drEnc["ID_POA"].ToString(), drEnc["ANIO"].ToString(), drEnc["FECHA"].ToString(), drEnc["TIPO_SOLICITUD"].ToString(),
               drEnc["ID_ACCION"].ToString(), drEnc["ID_ESTADO"].ToString(), drEnc["TRANSFERENCIA"].ToString(), drEnc["DEBITO"].ToString(), drEnc["CREDITO"].ToString(), drEnc["DESTINO_DEBITO"].ToString(), drEnc["ORIGEN_CREDITO"].ToString(),
               drEnc["MONTO"].ToString(), drEnc["JUSTIFICACION"].ToString(), drEnc["USUARIO"].ToString()};


            query = string.Format("CALL sp_iu_gesfor2({0}, {1}, {2}, {3}, null, null, '{4}', '{5}', {6}, {7}, {8}, {9}, {10}, '{11}', '{12}', null, {13}, '{14}', '{15}')",
                param[0], param[1], param[2], param[3], param[4], param[5], param[6], param[7], param[8], param[9], param[10], param[11], param[12], param[13], param[14], param[15]);

            dtTemp = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dtTemp = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dtTemp);

                if (!bool.Parse(dtTemp.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dtTemp.Rows[0]["MENSAJE"].ToString());

                int idEnc = int.Parse(dtTemp.Rows[0]["MENSAJE"].ToString());
                int noSolicitud = int.Parse(dtTemp.Rows[0]["NO_SOLICITUD"].ToString());

                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idEnc;
                dtEnc.Rows[0]["CODIGO"] = noSolicitud;

                //INSERTANDO LA SOLICITUD RELACIONADA
                if (dsGESFOR2.Tables["ENC"].Rows.Count == 2)
                {
                    drEnc = dsGESFOR2.Tables["ENC"].Rows[1];

                    string[] param2 = {
                                         drEnc["ID_SOLICITUD"].ToString(), drEnc["ID_FORMULARIO"].ToString(), drEnc["ANIO"].ToString(), drEnc["FECHA"].ToString(), drEnc["TIPO_SOLICITUD"].ToString(),
                                         drEnc["ID_ACCION"].ToString(), drEnc["ID_ESTADO"].ToString(), drEnc["TRANSFERENCIA"].ToString(), drEnc["DEBITO"].ToString(), drEnc["CREDITO"].ToString(), drEnc["DESTINO_DEBITO"].ToString(), drEnc["ORIGEN_CREDITO"].ToString(),
                                         idEnc.ToString(),
                                         drEnc["MONTO"].ToString(), drEnc["JUSTIFICACION"].ToString(), drEnc["USUARIO"].ToString()};

                    query = string.Format("CALL sp_iu_gesfor2({0}, {1}, {2}, null, null, '{3}', '{4}', {5}, {6}, {7}, {8}, {9}, '{10}', '{11}', {12}, {13}, '{14}', '{15}')",
                     param2[0], param2[1], param2[2], param2[3], param2[4], param2[5], param2[6], param2[7], param2[8], param2[9], param2[10], param2[11], param2[12], param2[13], param2[14], param2[15]);

                    dtTemp = new DataTable();
                    sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                    sqlAdapter.Fill(dtTemp);

                    if (!bool.Parse(dtTemp.Rows[0]["RESULTADO"].ToString()))
                        throw new Exception(dtTemp.Rows[0]["MENSAJE"].ToString());

                    idEnc = int.Parse(dtTemp.Rows[0]["MENSAJE"].ToString());
                    dtEnc.Rows.Add(false, "", idEnc);
                }
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);
            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))// && !bool.Parse(dtEnc.Rows[1]["ERRORES"].ToString()))
            {
                int idEnc = int.Parse(dtEnc.Rows[0]["VALOR"].ToString());

                try
                {
                    query = string.Format("DELETE FROM sipa_detalles_solicitud_poa WHERE id_solicitud = {0};", idEnc);
                    sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                    sqlAdapter.Fill(dtTemp);

                    foreach (DataRow dr in dsGESFOR2.Tables["DET"].Rows)
                    {
                        dtTemp = new DataTable();
                        query = string.Format("CALL sp_iu_gesfor2_detalles(0, {0}, {1}, '{2}');", idEnc, dr["ID_CAMPO"].ToString(), dr["VALOR"].ToString());

                        sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                        sqlAdapter.Fill(dtTemp);

                        if (!bool.Parse(dtTemp.Rows[0]["RESULTADO"].ToString()))
                            throw new Exception(dtTemp.Rows[0]["MENSAJE"].ToString());

                        dtDet.Rows.Add(dtTemp.Rows[0]["RESULTADO"].ToString(), "", dtTemp.Rows[0]["MENSAJE"].ToString());
                    }
                    sqlTransaction.Commit();
                    conectar.CerrarConexion();

                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            dsResultado.Tables.Add(dtDet);

            return dsResultado;
        }
        //REGION GESFOR2 FINAL
        public DataTable CostoEstimado(int unidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa" +
                                    " ON aa.id_accion = d.id_accion  inner join sipa_poa poa on poa.id_poa = aa.id_poa " +
                                     "WHERE(up.estado_financiero = 1) AND poa.id_unidad = {0} and poa.anio = {1} ", unidad,2017);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
    }
}
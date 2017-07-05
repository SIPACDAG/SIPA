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
    public class PlanOperativoAD
    {
        ConexionBD conectar;

       public DataTable DdlAnios()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("SELECT anio as texto, anio as id FROM ccl_anios; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlMeses()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("SELECT nombre as texto, id_mes as id FROM ccl_meses; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlUnidades(string usuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL slctUnidadesx('{0}');", usuario);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlDependencias(string id_unidad)
        {
            conectar = new ConexionBD();
            DataTable table = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL slctUnidadesxDependencia({0});", id_unidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(table);
            conectar.CerrarConexion();
            return table;
        }


       public DataTable DdlUnidades()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL slctNombreUnidad;");
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }


       public DataTable DdlUnidadesxAnalista(string usuario, int anio)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL slctUnidadesxAnalista('{0}', {1});", usuario, anio);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlProcesos()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_slctProcesos();");
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlObjetivos(int idOOperativo)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_slctObjOpexObjEstr({0});", idOOperativo);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlObjetivosxMeta(int idMeta, int idUnidad)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_slctObjOpexMetaEstr({0}, {1});", idMeta, idUnidad);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlObjetivosB(int anio, int idUnidad)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_SlctObjOpe_x_Anio({0}, {1});", anio, idUnidad);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlObjetivos(int anio, int idUnidad, int idObjEstrategico)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_slctObjOxObjExUnidadxAnio({0}, {1}, {2});", idObjEstrategico, idUnidad, anio);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlIndicadores(int idOOperativo, int idMetaEstrategica)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_slctKpiOp_ObjOp_MetaEstr({0}, {1});", idOOperativo, idMetaEstrategica);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlIndicadores(int idOOperativo)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_slctKpiOp_ObjOp({0});", idOOperativo);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlMetas(int idIndicador)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_slctMetaOp_KpiOp({0});", idIndicador);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable GridBusqueda(string Usuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("CALL sp_slctPlanOperativoGB('{0}');", Usuario);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable GridCodificacion(int idPoa)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("CALL sp_slctPoaCodificacion({0});", idPoa);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable AlmacenarObjetivo(ObjOperativosEN ObjEN,string usuario)
       {
            DataTable tabla = new DataTable();
            if (!validarPermiso(usuario))
            {
                conectar = new ConexionBD();
                
                conectar.AbrirConexion();
                string query = string.Format("CALL sp_iu_obj_operativo({0}, {1}, {2}, {3}, '{4}', {5}, {6}, '{7}');", ObjEN.Id_Objetivo_Operativo, ObjEN.Id_Objetivo_Estrategico, ObjEN.Id_Meta, ObjEN.Codigo, ObjEN.Nombre, ObjEN.Anio, ObjEN.Id_Unidad, ObjEN.Usuario);
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
            }
          
           return tabla;
       }

       public DataTable AlmacenarIndicador(IndOperativosEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format(" CALL sp_iu_kpi_operativo({0}, {1}, {2}, '{3}', {4}, '{5}', '{6}')", ObjEN.Id_Kpi_Operativo, ObjEN.Id_Objetivo_Operativo, ObjEN.Id_Meta_Estrategica, ObjEN.Nombre, ObjEN.Anio, ObjEN.Formula, ObjEN.Usuario);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable AlmacenarMeta(MetasOperativasEN ObjEN,string usuario)
       {
            DataTable tabla = new DataTable();
            if (!validarPermiso(usuario))
            {
                conectar = new ConexionBD();
               
                conectar.AbrirConexion();
                string query = string.Format("CALL sp_iu_meta_operativa({0}, {1}, {2}, '{3}', '{4}');", ObjEN.Id_Meta_Operativa, ObjEN.Id_Kpi_Operativo, ObjEN.Anio, ObjEN.Nombre, ObjEN.Usuario);
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
                return tabla;
            }
            return tabla;
       }

       public DataTable Insertar(ObjOperativosEN ObjOperativosE)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL insertar_obj_operativo({0}, {1}, {2}, '{3}', '{4}', '{5}', {6});", ObjOperativosE.Id_Meta, ObjOperativosE.Id_Unidad, ObjOperativosE.Codigo, ObjOperativosE.Nombre, ObjOperativosE.Meta, ObjOperativosE.Indicador, ObjOperativosE.Anio);
                                                                            
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

       public DataTable InformacionObjetivo(int id)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctObjOperativoM({0});", id);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InformacionIndicador(int id)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctKpiOperativoM({0});", id);
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
           string query = String.Format("CALL sp_slctMetaOperativaM({0});", id);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable EliminarObjetivo(int id)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_el_obj_operativo({0});", id);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable EliminarIndicador(int id)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_el_kpi_operativo({0});", id);
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
           string query = String.Format("CALL sp_el_meta_operativa({0});", id);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable ActualizarEstadoPoa(int idPoa, int idEstado, int anio, string idUsuario, string usuarioAsignado, string usuario, string observaciones)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = "";
           if(idUsuario == null)
               query = String.Format("CALL sp_cambiaEstadoPoaPac({0}, {1}, {2}, null, '{3}', '{4}', '{5}', 1);", idPoa, idEstado, anio, usuarioAsignado, usuario, observaciones);
           else
               query = String.Format("CALL sp_cambiaEstadoPoaPac({0}, {1}, {2}, {3}, '{4}', '{5}', '{6}', 1);", idPoa, idEstado, anio, idUsuario, usuarioAsignado, usuario, observaciones);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DatosPoaUnidad(int idUnidad, int anio, string criterio, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL slctDatosPoa({0}, {1}, '{2}', {3});", idUnidad, anio, criterio, opcion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
        public bool validarPermiso(string Usuario)
        {
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string permiso = string.Format("SELECT id_cargo_usuario from sipa_cargo_usuario where id_usuario="
                 + "(select id_usuario from ccl_usuarios where Usuario = '{0}')  AND id_tipo_usuario=50;", Usuario);
            MySqlCommand cmd = new MySqlCommand(permiso, conectar.conectar);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                conectar.CerrarConexion();
                return true;
            }
            else
            {
                conectar.CerrarConexion();
                return false;
            }
        }
    }
}

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
   public class PlanEstrategicoAD
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

       public DataTable DdlPlanes()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("CALL sp_slctPlanes(); ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlEjes(int idPlan)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL slctEjesEstrategicosxPlan({0});", idPlan);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlObjEstrategicos_X_Eje(int idEjeEstrategico)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL slctObjEstrategicosxEje({0});", idEjeEstrategico);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlIndicadores_X_Objetivo(int idObjetivo)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_SlctIndicadores_Obj_Estr({0});", idObjetivo);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlMetas_X_Indicador(int idIndicador)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_SlctMetas_Indicador({0});", idIndicador);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlMetas_X_Obj_Estr(int idObjetivoEstrategico, int anio)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_SlctMetas_Obj_Estr({0}, {1});", idObjetivoEstrategico, anio);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable RblUnidades()
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

       public DataTable GridBusqueda()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("CALL sp_slctPlanEstrategicoGB;", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable AlmacenarPlanEstrategico(EjesEN ObjEN, string usuario)
       {
            DataTable tabla = new DataTable();
            if (!validarPermiso(usuario))
            {
                conectar = new ConexionBD();
                
                conectar.AbrirConexion();
                string query = string.Format("CALL sp_iue_planes_estrategicos({0}, '{1}', '{2}', {3}, {4}, '{5}', 1);", ObjEN.Id_Plan, ObjEN.NOMBRE_PLAN, ObjEN.DESCRIPCION, ObjEN.ANIO_INI, ObjEN.ANIO_FIN, ObjEN.USUARIO);
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
                return tabla;
            }
            return tabla;
       }

       public DataTable AlmacenarObjetivo(ObjEstrategicosEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_iu_obj_estrategico({0}, {1}, {2}, '{3}', {4}, {5}, {6}, '{7}', '{8}', '{9}');", ObjEN.Id_Objetivo_Estrategico, ObjEN.Id_Eje_Estrategico, ObjEN.Codigo_Objetivo_Estrategico, ObjEN.Objetivo_Estrategico, ObjEN.Anio, ObjEN.Anio_Fin, ObjEN.Id_Responsable, ObjEN.Medios, ObjEN.Normativa, ObjEN.Usuario);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable AlmacenarIndicador(IndEstrategicosEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format(" CALL sp_iu_kpi_estrategico({0}, {1}, '{2}', '{3}', '{4}', '{5}')", ObjEN.Id_Kpi, ObjEN.Id_Objetivo, ObjEN.Nombre, ObjEN.Descripcion, ObjEN.Formula, ObjEN.Usuario);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable AlmacenarMeta(MetasEstrategicasEN ObjEN,string usuario)
       {
            DataTable tabla = new DataTable();
            if (!validarPermiso(usuario))
            {
                conectar = new ConexionBD();
                
                conectar.AbrirConexion();
                string query = string.Format("CALL sp_iu_meta_estrategica({0}, {1}, {2}, '{3}', '{4}', {5}, '{6}');", ObjEN.Id_Meta, ObjEN.Id_Kpi, ObjEN.Anio, ObjEN.Nombre, ObjEN.Meta_Propuesta, ObjEN.Id_Respondable, ObjEN.Usuario);
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
                return tabla;
            }
            return tabla;
       }

       public DataTable BuscarId(string id)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctPlanEstrategicoM({0});", id);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InformacionPlanEstrategico(int id, int id2, string criterio, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctPlanesEstrategicos({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
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
           string query = String.Format("CALL sp_slctObjEstrategicosM({0});", id);
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
           string query = String.Format("CALL sp_slctKpiEstrM({0});", id);
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
           string query = String.Format("CALL sp_slctMetasEstrM({0});", id);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable EliminarPlanEstrategico(int id, string usuario)
       {
            DataTable tabla = new DataTable();
          
                conectar = new ConexionBD();
                
                string query = String.Format("CALL sp_iue_planes_estrategicos({0}, '', '', 0, 0, '', 2);", id);
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
           string query = String.Format("CALL sp_el_obj_estrategico({0});", id);
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
           string query = String.Format("CALL sp_el_ind_estrategico({0});", id);
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
           string query = String.Format("CALL sp_el_meta_estrategica({0});", id);
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

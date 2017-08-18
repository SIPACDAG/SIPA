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
   public class EjesAD
    {
       ConexionBD conectar;

       public DataTable DdlEjes()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("CALL slctEjesEstrategicos;", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

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

       public DataTable DdlUnidades()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("CALL slctNombreUnidad;", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable GridBusqueda()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("CALL slctEjesEstrategicosGB;", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

        public DataTable Insertar(EjesEN ObjEN, string usuario)
        {
            DataTable tabla = new DataTable();
            if (!validarPermiso(usuario))
            {
                conectar = new ConexionBD();

                string query = string.Format("CALL insertar_eje({0}, '{1}', {2});", ObjEN.Codigo_Eje, ObjEN.Eje_Estrategico, ObjEN.Id_Plan);
                conectar.AbrirConexion();
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
                return tabla;
            }
            return tabla;

        }

        public DataTable Existe(EjesEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("SELECT COUNT(id_eje_estrategico) AS ejes FROM sipa_ejes_estrategicos WHERE anio = {0} AND codigo_eje = {1}", ObjEN.Id_Plan, ObjEN.Codigo_Eje);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable BuscarId(string id)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL slctEjesEstrategicosM({0});", id);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

        public DataTable Actualizar(EjesEN ObjEN, string usuario)
        {
            DataTable tabla = new DataTable();
            if (!validarPermiso(usuario))
            {
                conectar = new ConexionBD();

                string query = String.Format("CALL actualizar_eje({0}, {1}, '{2}', {3});", ObjEN.Id_Eje_Estrategico, ObjEN.Codigo_Eje, ObjEN.Eje_Estrategico, ObjEN.Id_Plan);
                conectar.AbrirConexion();
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
                return tabla;
            }
            return tabla;
        }

        public DataTable Eliminar(EjesEN ObjEN, string usuario)
        {
            DataTable tabla = new DataTable();
            if (!validarPermiso(usuario))
            {
                conectar = new ConexionBD();

                string query = String.Format("CALL eliminar_eje({0});", ObjEN.Id_Eje_Estrategico);
                conectar.AbrirConexion();
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
                return tabla;
            }
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

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
    public class CmiAD
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

       public DataTable DdlMetas(string anio)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL slctMetasEstrategicasxAnio({0});", anio);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlUnidades(string usuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL slctUnidadesxUsuario('{0}');", usuario);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable GridBusqueda(string Usuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("CALL slctObjetivosOperativosGB('{0}');", Usuario);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable Insertar(CmiEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = "";// string.Format("CALL insertar_obj_operativo({0}, {1}, {2}, '{3}', '{4}', '{5}', {6});", ObjOperativosE.Id_Meta, ObjOperativosE.Id_Unidad, ObjOperativosE.Codigo, ObjOperativosE.Nombre, ObjOperativosE.Meta, ObjOperativosE.Indicador, ObjOperativosE.Anio);
                                                                            
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable BuscarId(string id)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL slctObjOperativosM({0});", id);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable Actualizar(CmiEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = "";// String.Format("CALL actualizar_obj_operativo({0}, {1}, {2}, {3}, '{4}', '{5}', '{6}', {7});", ObjEN.Id_Objetivo_Operativo, ObjEN.Id_Meta, ObjEN.Id_Unidad, ObjEN.Codigo, ObjEN.Nombre, ObjEN.Meta, ObjEN.Indicador, ObjEN.Anio);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable Eliminar(CmiEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = "";// String.Format("CALL eliminar_obj_operativo({0});", ObjEN.Id_Objetivo_Operativo);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable ActualizarCodigoPoa(CmiEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL actualizar_codigo_poa({0}, '{1}');", ObjEN.Id_Poa, ObjEN.Codigo);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DatosPoaUnidad(int idUnidad, int anio)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL slctDatosPoa({0}, {1});", idUnidad, anio);
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

       public DataTable PresupuestoPoa(int idPoa)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL slctPptoPoa({0});", idPoa);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
    }
}

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
    public class AccionesAD
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

       public DataTable DdlUnidades(string usuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("CALL slctDependenciasxUsuario('{0}');", usuario);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlDependencias(string usuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("CALL slctDependenciasxUsuario('{0}');", usuario);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlAcciones(int idPoa)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("call slctAcciones({0});", idPoa);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlObjetivos(int idUnidad, int anio)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("call slctObjOperativosxAnio({0}, {1});", idUnidad, anio);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlBeneficiarios()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("call slctBeneficiarios();");
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlRenglones()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("call slctRenglones();");
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlFuentes()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("call slctFinanciamientos();");
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable GridBusqueda(string Usuario, int idDependencia, int Anio)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("CALL slctAccionesGB('{0}', {1}, {2});", Usuario, idDependencia, Anio);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable PptoAccion(int idAccion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("CALL slctPptoAccion({0});", idAccion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable Insertar(AccionesEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = "CALL insertar_accion(";
           query += ObjEN.Id_Poa + ", ";
           query += ObjEN.Id_Dependencia + ", ";
           //query += ObjEN.Id_Objetivo + ", ";
           query += ObjEN.Codigo + ", ";
           query += "'" + ObjEN.Accion + "', ";
           query += "'" + ObjEN.Meta_General + "', ";
           query += "'" + ObjEN.Meta_1 + "', ";
           query += "'" + ObjEN.Meta_2 + "', ";
           query += "'" + ObjEN.Meta_3 + "', ";
           query += ObjEN.Ponderacion + ", ";
           query += ObjEN.Presupuesto + ", ";
           query += "'" + ObjEN.Responsable + "', ";
           query += ObjEN.Enero + ", ";
           query += ObjEN.Febrero + ", ";
           query += ObjEN.Marzo + ", ";
           query += ObjEN.Abril + ", ";
           query += ObjEN.Mayo + ", ";
           query += ObjEN.Junio + ", ";
           query += ObjEN.Julio + ", ";
           query += ObjEN.Agosto + ", ";
           query += ObjEN.Septiembre + ", ";
           query += ObjEN.Octubre + ", ";
           query += ObjEN.Noviembre + ", ";
           query += ObjEN.Diciembre + ", " ;
           //query += "'" + ObjEN.Usuario_Ing + "'";
           query += ");";
                                                                            
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

        public DataTable BuscarId(string id)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL slctAccionM({0});", id);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable Actualizar(AccionesEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = "CALL actualizar_accion(";
           query += ObjEN.Id_Accion + ", ";
           query += ObjEN.Id_Poa + ", ";
           query += ObjEN.Id_Dependencia + ", ";
           //query += ObjEN.Id_Objetivo + ", ";
           query += ObjEN.Codigo + ", ";
           query += "'" + ObjEN.Accion + "', ";
           query += "'" + ObjEN.Meta_General + "', ";
           query += "'" + ObjEN.Meta_1 + "', ";
           query += "'" + ObjEN.Meta_2 + "', ";
           query += "'" + ObjEN.Meta_3 + "', ";
           query += ObjEN.Ponderacion + ", ";
           query += ObjEN.Presupuesto + ", ";
           query += "'" + ObjEN.Responsable + "', ";
           query += ObjEN.Enero + ", ";
           query += ObjEN.Febrero + ", ";
           query += ObjEN.Marzo + ", ";
           query += ObjEN.Abril + ", ";
           query += ObjEN.Mayo + ", ";
           query += ObjEN.Junio + ", ";
           query += ObjEN.Julio + ", ";
           query += ObjEN.Agosto + ", ";
           query += ObjEN.Septiembre + ", ";
           query += ObjEN.Octubre + ", ";
           query += ObjEN.Noviembre + ", ";
           query += ObjEN.Diciembre + ", ";
           //query += "'" + ObjEN.Usuario_Act + "'";
           query += ");";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable Eliminar(AccionesEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL eliminar_accion({0});", ObjEN.Id_Accion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
    }
}

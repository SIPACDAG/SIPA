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
   public class UsuarioAD
    {
       ConexionBD conectar;

       public DataTable datosCargoUsuario(int idusr)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctDatosCargoUsuario(" + idusr + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable dropUnidad()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctNombreUnidad; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable dropEmpleados()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("CALL sp_slctDatosEmpleado(0, 0, '', 0, 3);", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable dropAnalistas()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call sp_slctAnalistasPoa; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable dropDependencia(int idDep)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctNombreDependencias(" + idDep + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public  DataTable MenusPadre()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctMenusPadre; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable ObtenerUsuariosMenus(int idUsuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctUsuarioMenu(" + idUsuario + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable ObtenerMenus(int idMenu)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctObtenerMenus(" + idMenu + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       /*public DataTable dropEmpleado()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call clsNombreEmpleado; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }*/
       /*public DataTable dropEmpleadoUsuario()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctNombreEmpleadoUsuario; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }*/

       public DataTable gridUsuario()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctNombreUsuario; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable datosUsuario(int idUsuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctUsuarios(" + idUsuario + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
 
       public DataTable dropTipoUsuario()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctTipoUsuario; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable obtener_Usuarios()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call clsObtenerUsuarios; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable PassAntiguo(UsuariosEN Usuarios)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call clsLogearse('" + Usuarios.Usuario + "','" + Usuarios.Contrasena + "'); ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable VerificarSiExite_Nombre(String usuario,int idusr)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctValNombre('" + usuario + "'," + idusr + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public bool ModificaPass (UsuariosEN Usuarios, string usuario) {
            if (validarPermiso(usuario))
            {
                conectar = new ConexionBD();
                conectar.AbrirConexion();
                MySqlCommand procedimiento = new MySqlCommand("Modificar_Pass");
                procedimiento.CommandType = CommandType.StoredProcedure;

                procedimiento.Parameters.AddWithValue("@usr", Usuarios.Usuario);
                procedimiento.Parameters.AddWithValue("@pass", Usuarios.Contrasena);

                conectar.AbrirConexion();
                procedimiento.Connection = conectar.conectar;
                procedimiento.ExecuteNonQuery();
                return true;
            }
            return false;
        }
       public int IngresarUsuario(UsuariosEN usuarioE,string usuario)
       {
           int NoIngreso;
           conectar = new ConexionBD();
            
                MySqlCommand procedimiento = new MySqlCommand("insertar_usuario");
                procedimiento.CommandType = CommandType.StoredProcedure;
                procedimiento.Parameters.AddWithValue("usr", usuarioE.Usuario);
                procedimiento.Parameters.AddWithValue("contra", usuarioE.Contrasena);

                if (usuarioE.idEmpleado > 0)
                    procedimiento.Parameters.AddWithValue("idEm", usuarioE.idEmpleado);
                else
                    procedimiento.Parameters.AddWithValue("idEm", null);

                procedimiento.Parameters.AddWithValue("v_nombre", usuarioE.Nombre);


                conectar.AbrirConexion();
                procedimiento.Connection = conectar.conectar;
                NoIngreso = procedimiento.ExecuteNonQuery();
                conectar.CerrarConexion();
                return NoIngreso;
           
          

       }
       public bool ModificarUsuario(UsuariosEN usuarioE,string usuario)
       {
            
                conectar = new ConexionBD();
                MySqlCommand procedimiento = new MySqlCommand("Modificar_Usuario");
                procedimiento.CommandType = CommandType.StoredProcedure;
                procedimiento.Parameters.AddWithValue("idusr", usuarioE.IdUsuario);
                procedimiento.Parameters.AddWithValue("usr", usuarioE.Usuario);
                procedimiento.Parameters.AddWithValue("contra", usuarioE.Contrasena);
                procedimiento.Parameters.AddWithValue("idTU", usuarioE.idTipoUsuario);
                procedimiento.Parameters.AddWithValue("est", usuarioE.Habilitado);
                procedimiento.Parameters.AddWithValue("v_nombre", null);
                if (usuarioE.idEmpleado > 0)
                    procedimiento.Parameters.AddWithValue("vid_empleado", usuarioE.idEmpleado);
                else
                    procedimiento.Parameters.AddWithValue("vid_empleado", null);

                conectar.AbrirConexion();
                procedimiento.Connection = conectar.conectar;
                procedimiento.ExecuteNonQuery();

                conectar.CerrarConexion();
                return true;
           
           
       }


       public int EliminarUsuario(UsuariosEN usuarioE)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Eliminar_Usuario");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("idusr", usuarioE.IdUsuario);

           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;

       }

       

       public DataTable IngresarPermiso(int idUsuario, int idMenu,string usuario)
       {

           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
          
                conectar.AbrirConexion();
                string query = string.Format("CALL Insertar_Permisos({0}, {1});", idUsuario, idMenu);
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
                return tabla;
            
         
           /*int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Insertar_Permisos");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("idusr", idUsuario);
           procedimiento.Parameters.AddWithValue("idm", idMenu);

           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();*/
       }
 
       public void  EliminarPermiso(int idUsuario,int idMenu,string usuario)
       {
           int NoIngreso;
            if (!validarPermiso(usuario))
            {
                conectar = new ConexionBD();
                MySqlCommand procedimiento = new MySqlCommand("Eliminar_Permisos");
                procedimiento.CommandType = CommandType.StoredProcedure;
                procedimiento.Parameters.AddWithValue("idusr", idUsuario);
                procedimiento.Parameters.AddWithValue("idm", idMenu);

                conectar.AbrirConexion();
                procedimiento.Connection = conectar.conectar;
                NoIngreso = procedimiento.ExecuteNonQuery();
                conectar.CerrarConexion();
            }
          
       }

       public DataTable IngresarCargoUsuario(int idUsuario, int idU,int idd,int idtu,string Usuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
            string query = string.Format("CALL Insertar_CargoUsuario({0}, {1}, {2}, {3});", idUsuario, idU, idd, idtu);
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

       public bool desactivarCargoUsuario(int idcu,string usuario)
       {
           
                conectar = new ConexionBD();
                MySqlCommand procedimiento = new MySqlCommand("Desactivar_CargoUsuario");
                procedimiento.CommandType = CommandType.StoredProcedure;
                procedimiento.Parameters.AddWithValue("idcu", idcu);

                conectar.AbrirConexion();
                procedimiento.Connection = conectar.conectar;
                procedimiento.ExecuteNonQuery();
                conectar.CerrarConexion();
                return true;
            
       }


       
    }
}

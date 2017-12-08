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
    public class EmpleadosAD
    {
        ConexionBD conectar;
        
       public DataTable DdlUnidades()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = "call slctNombreUnidad();" ;
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlPuestos()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_slctDatosEmpleado(0, 0, '', 0, 4);");
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable AlmacenarEmpleado(EmpleadosEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable dt = new DataTable();

           string idEmpleado, nombres, apellidos, direccion, telefono, email, idGenero, nit, cui, fechaNac, idPuesto, renglon, idUnidad, idEstado, sueldoNominal, usuario = "";
           idEmpleado = ObjEN.ID_EMPLEADO.ToString();
           nombres = "'" + ObjEN.NOMBRES + "'";
           apellidos = "'" + ObjEN.APELLIDOS + "'";
           direccion = "'" + ObjEN.DIRECCION + "'";
           telefono = "'" + ObjEN.TELEFONO + "'";
           email = "'" + ObjEN.EMAIL + "'";
           idGenero = ObjEN.ID_GENERO.ToString();
           nit = "'" + ObjEN.NIT + "'";
           cui = "'" + ObjEN.CUI + "'";

           fechaNac = "null";
           string[] f;
           if (!ObjEN.FECHA_NACIMINETO.Equals(string.Empty))
           {
               f = ObjEN.FECHA_NACIMINETO.Split('/');
               fechaNac = "'" + f[2] + "-" + f[1] + "-" + f[0];
           }           

           idPuesto = ObjEN.ID_PUESTO.ToString();
           renglon = "'" + ObjEN.RENGLON + "'";
           idUnidad = ObjEN.ID_UNIDAD.ToString();
           idEstado = ObjEN.ID_ESTADO.ToString();
           sueldoNominal = ObjEN.SUELDO_NOMINAL.ToString();
           usuario = ObjEN.USUARIO;

           nombres = nombres.Replace("''", "null");
           apellidos = apellidos.Replace("''", "null");
           direccion = direccion.Replace("''", "null");
           telefono = telefono.Replace("''", "null");
           email = email.Replace("''", "null");
           nit = nit.Replace("''", "null");
           cui = cui.Replace("''", "null");
           renglon = renglon.Replace("''", "null");
           //idGenero = idGenero.Replace("0", "null");
           //idPuesto = idPuesto.Replace("0", "null");
           //idUnidad = idUnidad.Replace("0", "null");
           //idEstado = idEstado.Replace("0", "null");
           sueldoNominal = ObjEN.SUELDO_NOMINAL.ToString();

           string query = "CALL sp_iue_empleados(" + idEmpleado + ", " + nombres + ", " + apellidos + ", " + direccion + ", " + telefono + ", " + email + ", " + idGenero + ", " + nit + ", " + cui + ", " + fechaNac + ", " + idPuesto + ", " + renglon + ", " + idUnidad + ", " + idEstado + ", " + sueldoNominal + ", '" + usuario + "', 1);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(dt);
           conectar.CerrarConexion();
           return dt;
       }

       public DataTable EliminarEmpleado(int id)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = "CALL sp_iue_empleados(" + id + ", '', '', '', '', '', 0, '', '', null, 0, '', 0, 0, '', 2);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InformacionEmpleados(int id, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctDatosEmpleado({0}, 0, '', 0, {1});", id, opcion);
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
    }
}

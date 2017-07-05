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
   public class NominaAD
    {
        ConexionBD conectar;
        
       public DataTable datosTipoNomina()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("select distinct (case  when IDTipo in (1,2,4,5) then 1 else IDTipo  end) as id,(case  when IDTipo in (1,2,4,5) then  '1| Mensual' else concat(IDTipo,'| ',Descripcion)  end) as Texto from NominasTipos", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

     

       public DataTable rptNomina(int opcion,int anio, int IDNomina)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call rptNomina (" + opcion + "," + anio + "," + IDNomina + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
        public DataTable datosEmpleadoPlanilla(NominaEN nomina)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call qrDatosPlanilla (" + nomina.Departamento + ",'" + nomina.Renglon + "');", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public int idNomina(int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call qridNomina (" + anio + ");", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return Convert.ToInt32(tabla.Rows[0][0].ToString());
        }

        public DataTable DatosNominaBase(int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call qrDatosNominaBase (" + anio + ");", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
       
        public DataTable buscarDescuentoNomina(NominaEN nomina)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call qrBuscarDescuentoNomina (" + nomina.IDEmpleado + ");", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable buscarNomina(string finicio, string ffin)
        {
            DateTime fi,ff ;

            fi = Convert.ToDateTime(finicio);
            ff = Convert.ToDateTime(ffin);
            
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call BuscarNomina ('" + fi.ToString("yyyy-MM-dd") + "','" + ff.ToString("yyyy-MM-dd") + "')", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable buscarNominaDetalle(int IDNomina,int IDEmpleado,int Anio)
        {
            // Verificar si da los datos que es por que quite el top 1
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call clsNominasDatosDetalle (" + IDNomina + "," + IDEmpleado + "," + Anio + ");", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public int IngresarNomina(NominaEN nomina)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Insertar_Nomina");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idN", nomina.IDNomina);
            procedimiento.Parameters.AddWithValue("Ao", nomina.Anio);
            procedimiento.Parameters.AddWithValue("Fe", nomina.Fecha);
            procedimiento.Parameters.AddWithValue("idT", nomina.IDTIpo);
            procedimiento.Parameters.AddWithValue("rgn", nomina.Renglon);
            procedimiento.Parameters.AddWithValue("IDP", nomina.IDProyecto);
            procedimiento.Parameters.AddWithValue("des", nomina.Descripcion);
            procedimiento.Parameters.AddWithValue("per", nomina.Periodo);
            procedimiento.Parameters.AddWithValue("usr", nomina.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int IngresarNominaDetalle(NominaEN nomina)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Insertar_NominaDetalle");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idN", nomina.IDNomina);
            procedimiento.Parameters.AddWithValue("idE", nomina.IDEmpleado);
            procedimiento.Parameters.AddWithValue("Ao", nomina.Anio);
            procedimiento.Parameters.AddWithValue("Dep", nomina.Departamento);
            procedimiento.Parameters.AddWithValue("sb", nomina.SueldoBase);
            procedimiento.Parameters.AddWithValue("Bon", nomina.Bonificacion);
            procedimiento.Parameters.AddWithValue("od", nomina.OtrasDeducciones);
            procedimiento.Parameters.AddWithValue("ob", nomina.OtrasBonificaciones);
            procedimiento.Parameters.AddWithValue("d", nomina.Dias);
            procedimiento.Parameters.AddWithValue("ig", nomina.IGSS);
            procedimiento.Parameters.AddWithValue("pres", nomina.Prestaciones);
            procedimiento.Parameters.AddWithValue("fia", nomina.Fianza);
            procedimiento.Parameters.AddWithValue("i", nomina.ISR);
            procedimiento.Parameters.AddWithValue("bt", nomina.Bantrab);
            procedimiento.Parameters.AddWithValue("bs", nomina.BanSeguro);
            procedimiento.Parameters.AddWithValue("Rgl", nomina.Renglon);
            procedimiento.Parameters.AddWithValue("usr", nomina.usuario);

            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }

        public int ModificarNomina(NominaEN nomina)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Modificar_Nomina");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("IDNomina", nomina.IDNomina);
            procedimiento.Parameters.AddWithValue("Anio", nomina.Anio);
            procedimiento.Parameters.AddWithValue("fecha", nomina.Fecha);
            procedimiento.Parameters.AddWithValue("IDTipo", nomina.IDTIpo);
            procedimiento.Parameters.AddWithValue("Renglon", nomina.Renglon);
            procedimiento.Parameters.AddWithValue("IDProyectoo", nomina.IDProyecto);
            procedimiento.Parameters.AddWithValue("Descripcion", nomina.Descripcion);
            procedimiento.Parameters.AddWithValue("Periodo", nomina.Periodo);
            procedimiento.Parameters.AddWithValue("usuario", nomina.usuario);
            

            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;

            
        }

        public int EliminarNomina(NominaEN nomina)
        {

            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Eliminar_Nomina");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("IDNomina", nomina.IDNomina);
            procedimiento.Parameters.AddWithValue("Anio", nomina.Anio);
            
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;

            
        }
    }
}

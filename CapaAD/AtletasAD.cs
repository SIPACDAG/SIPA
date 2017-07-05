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
    public class AtletasAD
    {
        ConexionBD conectar;
        public DataTable consultas(string fi, string ff, int per, int tipo)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string nomProcedure;
            switch (tipo)
	         {
               case 1: nomProcedure = "CaClspvFederacion"; break;
               case 2: nomProcedure = "caClspvTipoAtleta"; break;
               case 3: nomProcedure = "caClspvGenero"; break;
               case 4: nomProcedure = "CaclsPVFederacionA"; break;
               case 5: nomProcedure = "caClspvTipoAtletaA"; break;
               case 6: nomProcedure = "caClsAaFederacion"; break;
               case 7: nomProcedure = "caClsaaTipoAtleta"; break;
               case 8: nomProcedure = "caClsDatosAA"; break;
               case 9: nomProcedure = "caClsDatosUAA"; break;
               default: nomProcedure = ""; break;
	         }
            string strConsulta = string.Format("call " + nomProcedure + " ('{0}','{1}',{2});", fi, ff,per);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
		public DataTable consultasPer(string fi, string ff, int op, string usr)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call caClsMedicos ('{0}','{1}',{2},'{3}');", fi, ff, op, usr);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        
        }
        public DataTable gridAtletas(AtletasEN atletasEN,int tipo)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call caclsAtletas ({0},'{1}');", tipo, atletasEN.nombres);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable gridAsignarAtencion(AtletasEN atletasEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call caClsAsignarAtencion ('{0}');",atletasEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable gridAsignarPersonal(AtletasEN atletasEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call caClsAsignarPersonal ('{0}');", atletasEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable gridVerPersonalAsignado(AtletasEN atletasEN, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call caClsverAsignacionPersonal ('{0}',{1});", atletasEN.usuario, opcion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public string verPersonalAsignado(AtletasEN atletasEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call caClsverPersonalAsignado ({0});", atletasEN.idAtencionAtleta);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return Convert.ToString(tabla.Rows[0][0]);
        }
        public DataTable gridAsignarTipoAtencion(AtletasEN atletasEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call caClasAsignartipoAtencion ('{0}');", atletasEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
       public DataTable dropUnidades()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call caClsUnidades; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
       public DataTable dropTipoAtleta()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call caClsAtletaTipo; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
        public DataTable dropPersonal(AtletasEN atletasEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call caClsPersonal ({0});", atletasEN.idAtencionAtleta);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropTratamiento(AtletasEN atletasEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call caClsTipoTratamiento ('{0}');", atletasEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropTipoAtencion(AtletasEN atletasEN, int idCategoria)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call caClsTipoAtencion ({0},'{1}');", idCategoria, atletasEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropEtnia()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call caClsEtnia; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropFederacion()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call clsCaFederacion; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable clsDatosAtleta(AtletasEN atletasEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call caClsDatosAtleta ({0});", atletasEN.idAtleta);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public int valAtletaUnidad(AtletasEN atletasEN)
        {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call caClsValidaUA ({0},{1})", atletasEN.idAtleta, atletasEN.idUnidadMedica);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla.Rows.Count;
         }
        public int Insertar_Atleta(AtletasEN atletasEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("caInsertar_Atleta");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("nom", atletasEN.nombres);
            procedimiento.Parameters.AddWithValue("idta", atletasEN.idTipoAtleta);
            procedimiento.Parameters.AddWithValue("dir", atletasEN.direccion);
            procedimiento.Parameters.AddWithValue("tel", atletasEN.telefono);
            procedimiento.Parameters.AddWithValue("ge", atletasEN.genero);
            procedimiento.Parameters.AddWithValue("idEt", atletasEN.idEtnia);
            procedimiento.Parameters.AddWithValue("fn", atletasEN.fechaNacimiento);
            procedimiento.Parameters.AddWithValue("idf", atletasEN.idFederacion);
            procedimiento.Parameters.AddWithValue("usr", atletasEN.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int Insertar_AsignarAtencion(AtletasEN atletasEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("caInsertar_AsignarAtencion");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("ida", atletasEN.idAtleta);
            procedimiento.Parameters.AddWithValue("idum", atletasEN.idUnidadMedica);
            procedimiento.Parameters.AddWithValue("obs", atletasEN.observacion);
            procedimiento.Parameters.AddWithValue("usr", atletasEN.usuario);
            
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int Insertar_AsignarPersonal(AtletasEN atletasEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("caInsertar_Personal");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idP", atletasEN.idPersonal);
            procedimiento.Parameters.AddWithValue("idaa", atletasEN.idAtencionAtleta);
            procedimiento.Parameters.AddWithValue("usr", atletasEN.usuario);

            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int Insertar_AsignarAtencionDetalle(AtletasEN atletasEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("caInsertar_AtencionDetalle");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idaa", atletasEN.idAtencionAtleta);
            procedimiento.Parameters.AddWithValue("idta", atletasEN.idTipoAtencion);
            procedimiento.Parameters.AddWithValue("obs", atletasEN.observacion);
            procedimiento.Parameters.AddWithValue("usr", atletasEN.usuario);

            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int Modificar_Atleta(AtletasEN atletasEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("caModificar_Atleta");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("ida", atletasEN.idAtleta);
            procedimiento.Parameters.AddWithValue("nom", atletasEN.nombres);
            procedimiento.Parameters.AddWithValue("idta", atletasEN.idTipoAtleta);
            procedimiento.Parameters.AddWithValue("dir", atletasEN.direccion);
            procedimiento.Parameters.AddWithValue("tel", atletasEN.telefono);
            procedimiento.Parameters.AddWithValue("ge", atletasEN.genero);
            procedimiento.Parameters.AddWithValue("idEt", atletasEN.idEtnia);
            procedimiento.Parameters.AddWithValue("fn", atletasEN.fechaNacimiento);
            procedimiento.Parameters.AddWithValue("idf", atletasEN.idFederacion);
            procedimiento.Parameters.AddWithValue("usr", atletasEN.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int Insertar_AtencionTrar(AtletasEN atletasEN, int idcategoria)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("caInsertar_AtencionTrat");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idca", idcategoria);
            procedimiento.Parameters.AddWithValue("nombre", atletasEN.nombres);
            procedimiento.Parameters.AddWithValue("usr", atletasEN.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int Eliminar_Atleta(AtletasEN atletasEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("caEliminar_Atleta");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idA", atletasEN.idAtleta);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }


    }
}

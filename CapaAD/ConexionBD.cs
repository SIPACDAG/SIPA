using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace CapaAD
{
    class ConexionBD
    {

        //private String contenido = "server=localhost; database =dbcogsipa;user=usr_cdag_sipa; password =5sr_cd1g_s3pa";
        //BASE DE DATOS LOCAL
        //private String contenido = "server=localhost; database =dbcdagsipa;user=usr_cdag_sipa; password =5sr_cd1g_s3pa";

        //BASE DE DATOS DE PRODUCCIÓN
        //private String contenido = System.Configuration.ConnectionString["dbcdagsipaConnectionString"].ConnectionString;
        private string contenido = ConfigurationManager.ConnectionStrings["dbcdagsipaConnectionString"].ConnectionString;
        public MySqlConnection conectar = new MySqlConnection();
        public MySqlDataAdapter adaptador = new MySqlDataAdapter();
        public DataTable tabla = new DataTable();

    public void AbrirConexion()
    {
    string sConn;
        sConn = contenido;
        conectar = new MySqlConnection();
        conectar.ConnectionString = sConn;
            
	   try 
	    {	        
		conectar.Open();
                Console.WriteLine("Conexión Exitosa");
	    }
	catch (Exception ex)
	    {
		Console.WriteLine(ex + "Fallo en la Conexión");
		throw;
	    }
      }

     public void CerrarConexion()
        {
            if (conectar.State == System.Data.ConnectionState.Open)
            {
                conectar.Close();
            }
        }

    }
}

    
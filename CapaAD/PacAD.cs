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
    public class PacAD
    {
        ConexionBD conectar;
        public DataTable datosPoa(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsDatosPoa ({0},{1})", pacEN.idUnidad, pacEN.anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropAccionPoa(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsUsuarioDependencia ('{0}');", pacEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropNoPac(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsNoPac ({0});", pacEN.idDetalleAccion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosDetalleAccion(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPac ({0},{1});", pacEN.idAccion, 1);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosIdDetalleAccion (PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPac ({0},{1});", pacEN.idDetalleAccion, 3);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable PacListado(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPacListado ('{0}');", pacEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public int maxidPac()
        {
            int idPac = 0;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsMaxidPac");
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                idPac = Convert.ToInt32(tabla.Rows[0]["idPac"]);
            }
            else
            {
                idPac = 0;
            }
            return idPac;
        }

        public double saldoPac(PacEN pacEN)
        {
            double saldo;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPac ({0},{1});", pacEN.idDetalleAccion, 2);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                saldo = Convert.ToDouble(tabla.Rows[0]["saldoPac"]);
            }
            else
            {
                saldo = 0;
            }
            return saldo;
        
        }
        public double montoActualPac(PacEN pacEN)
        {
            double saldo;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPacMontoActual ({0});", pacEN.idPac);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                saldo = Convert.ToDouble(tabla.Rows[0]["monto"]);
            }
            else
            {
                saldo = 0;
            }
            return saldo;
        }

               
        public double codificadoPacPac(PacEN pacEN)
        {
            double saldo;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPac ({0},{1});", pacEN.idPac, 4);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                saldo = Convert.ToDouble(tabla.Rows[0]["CodificadoPac"]);
            }
            else
            {
                saldo = 0;
            }
            return saldo;
        }

        public double saldoPacPac(PacEN pacEN)
        {
            double saldo;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPac ({0},{1});", pacEN.idPac, 4);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                saldo = Convert.ToDouble(tabla.Rows[0]["saldoPac"]);
            }
            else
            {
                saldo = 0;
            }
            return saldo;
        }
      
        public DataTable dropUnidadesUsuario(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsUnidadesUsuario ('{0}')", pacEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropExcepcion()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = "call clsPacExcepcion";
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropModalidad()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = "call clsPacModalidad";
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosPac(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPacDatos ({0})", pacEN.idPac);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosPacDetalle(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call ClsPacDetalleDatos ({0})", pacEN.idPac);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public int InsertarPac(PacEN pacEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Insertar_Pac");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idDa", pacEN.idDetalleAccion);
            procedimiento.Parameters.AddWithValue("idm", pacEN.idModalidad);
            procedimiento.Parameters.AddWithValue("ide", pacEN.idExcepcion);
            procedimiento.Parameters.AddWithValue("des", pacEN.descripcion);
            procedimiento.Parameters.AddWithValue("usr", pacEN.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int ModificarPac(PacEN pacEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Modifcar_Pac");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idp", pacEN.idPac);
            procedimiento.Parameters.AddWithValue("idm", pacEN.idModalidad);
            procedimiento.Parameters.AddWithValue("ide", pacEN.idExcepcion);
            procedimiento.Parameters.AddWithValue("des", pacEN.descripcion);
            procedimiento.Parameters.AddWithValue("usr", pacEN.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int InsertarPacDetalle(PacEN pacEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Insertar_PacDetalle");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idP", pacEN.idPac);
            procedimiento.Parameters.AddWithValue("me", pacEN.mes);
            procedimiento.Parameters.AddWithValue("ca", pacEN.cantidad);
            procedimiento.Parameters.AddWithValue("mon", pacEN.montomes);
            procedimiento.Parameters.AddWithValue("usr", pacEN.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int ModificarPacDetalle(PacEN pacEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Modificar_PacDetalle");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idPD", pacEN.idPacDetalle);
            procedimiento.Parameters.AddWithValue("ca", pacEN.cantidad);
            procedimiento.Parameters.AddWithValue("mon", pacEN.montomes);
            procedimiento.Parameters.AddWithValue("usr", pacEN.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int EliminarPac(PacEN pacEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Eliminar_Pac");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idP", pacEN.idPac);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }

        
    }
}

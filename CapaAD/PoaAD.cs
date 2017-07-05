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
     public class PoaAD
    {
         ConexionBD conectar;
         public DataTable datosPoa(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsDatosPoa ({0},{1})", poaEN.idUnidad, poaEN.anio);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable rptPoa(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call rptPoa ({0})",poaEN.idPoa);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable datosPoas(PoaEN poaEN,int op)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsPoas ({0},{1},'{2}')", poaEN.anio, op, poaEN.usuario);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable datosAccion(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsDatosAccion ({0})", poaEN.idAccion);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable datosAccionesPoa(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsAccionesPoa ({0})", poaEN.idPoa);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable datosDetalleAccion(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsSaldoAccion ({0})", poaEN.idAccion);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }

         public DataTable gridSaldoAccion(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsSaldoAccion ({0})", poaEN.idAccion);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         
         public int valReglon(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsValReglon ({0},{1},{2})", poaEN.idAccion, poaEN.NoReglon, poaEN.idFinanciamiento);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla.Rows.Count;
         }
         public int valBeneficiario(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsValBeneficiario ({0},{1})", poaEN.idAccion, poaEN.idBeneficiario);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla.Rows.Count;
         }
         public DataTable datosMontoReglon(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsDatosMontoRreglon ({0})", poaEN.idDetalleAccion);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable datosBeneficiariosAccion(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsBeneficiarioAccion ({0})", poaEN.idAccion);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable dropProducto(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsNombreProducto ({0},{1})", poaEN.anio, poaEN.idUnidad);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable dropAccionPoa(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsNombreAcciones ({0})", poaEN.idPoa);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable dropBeneficiario()
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsNombreBeneficiario");
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable reglones()
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsReglones");
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable financiamiento()
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsFinanciamiento");
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable dropUnidadesUsuario(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsUnidadesUsuario ('{0}')", poaEN.usuario); 
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }

         public DataTable dropDependencia(PoaEN poaEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsNombreDependencias ({0})", poaEN.idUnidad);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable dropDependencias()
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsDependecias");
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public double saldoPoa(PoaEN poaEN)
         {
             double saldo;
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsSaldoPoa ({0})", poaEN.idPoa);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             if (tabla.Rows.Count > 0)
             {
                 saldo = Convert.ToDouble(tabla.Rows[0]["saldo"]);
             }
             else
             {
                 saldo = 0;
             }
             return saldo;
       }
         public double saldoPoaDep(PoaEN poaEN)
         {
             double saldo;
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsSaldoPoaDep ({0},{1},{2})",poaEN.idDependencia,poaEN.anio, poaEN.idPoa);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             if (tabla.Rows.Count > 0)
             {
                 saldo = Convert.ToDouble(tabla.Rows[0]["saldo"]);
             }
             else
             {
                 saldo = 0;
             }
             return saldo;
         }
         public double saldoDetalleAccion(PoaEN poaEN)
         {
             double saldo;
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsSaldoDetalleAccion ({0})", poaEN.idDetalleAccion);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             if (tabla.Rows.Count > 0)
             {
                 saldo = Convert.ToDouble(tabla.Rows[0]["saldo"]);
             }
             else
             {
                 saldo = 0;
             }
             return saldo;
         }
         public int InsertarAccion(PoaEN poaEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_Accion");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idPo", poaEN.idPoa);
             procedimiento.Parameters.AddWithValue("Acc", poaEN.accion);
             procedimiento.Parameters.AddWithValue("NoAc", poaEN.noActividades);
             procedimiento.Parameters.AddWithValue("idDep", poaEN.idDependencia);
             procedimiento.Parameters.AddWithValue("idPro", poaEN.idProducto);
             procedimiento.Parameters.AddWithValue("fI", poaEN.fechaInicio);
             procedimiento.Parameters.AddWithValue("fF", poaEN.fechaFin);
             procedimiento.Parameters.AddWithValue("usr", poaEN.usuario);
             procedimiento.Parameters.AddWithValue("nRe", poaEN.NoReglon);
             procedimiento.Parameters.AddWithValue("idFue", poaEN.idFinanciamiento);
             procedimiento.Parameters.AddWithValue("Cos", poaEN.Costo);
             
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;

         }
         public int ModificarAccion(PoaEN poaEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Modificar_Accion");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idAcc", poaEN.idAccion);
             procedimiento.Parameters.AddWithValue("Acc", poaEN.accion);
             procedimiento.Parameters.AddWithValue("NoAc", poaEN.noActividades);
             procedimiento.Parameters.AddWithValue("idPro", poaEN.idProducto);
             procedimiento.Parameters.AddWithValue("fI", poaEN.fechaInicio);
             procedimiento.Parameters.AddWithValue("fF", poaEN.fechaFin);
             procedimiento.Parameters.AddWithValue("usr", poaEN.usuario);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int MaxidAccion()
         {
             int idAccion = 0;
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsMaxidAccion");
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             if (tabla.Rows.Count > 0)
             {
                 idAccion = Convert.ToInt32(tabla.Rows[0]["idAcci"]);
             }
             else
             {
                 idAccion = 0;
             }
             return idAccion;
         }
         public int InsertarBeneficiario(PoaEN poaEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_Beneficiarios");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idAc", poaEN.idAccion);
             procedimiento.Parameters.AddWithValue("idben", poaEN.idBeneficiario);
             procedimiento.Parameters.AddWithValue("canB", poaEN.cantidadBen);
             procedimiento.Parameters.AddWithValue("usr", poaEN.usuario);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;

             
         }
         public int InsertarReglon(PoaEN poaEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_Reglon");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idAc", poaEN.idAccion);
             procedimiento.Parameters.AddWithValue("nRe", poaEN.NoReglon);
             procedimiento.Parameters.AddWithValue("Cos", poaEN.Costo);
             procedimiento.Parameters.AddWithValue("idFue", poaEN.idFinanciamiento);
             procedimiento.Parameters.AddWithValue("usr", poaEN.usuario);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int EliminarBeneficiario(PoaEN poaEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Eliminar_Beneficiario");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idBenAcc", poaEN.idBenAccion);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int ModificarCostoReglon(PoaEN poaEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Modificar_CostoReglon");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idDAcc", poaEN.idDetalleAccion);
             procedimiento.Parameters.AddWithValue("cos", poaEN.Costo);
             procedimiento.Parameters.AddWithValue("idfin", poaEN.idFinanciamiento);
             procedimiento.Parameters.AddWithValue("usr", poaEN.usuario);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int EliminarReglon(PoaEN poaEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Eliminar_Reglon");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idDAcc", poaEN.idDetalleAccion);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int EliminarAccion(PoaEN poaEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Eliminar_Accion");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idAcc", poaEN.idAccion);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int ModificarEstadoPoa(PoaEN poaEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Modificar_EstadoPoa");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idP", poaEN.idPoa);
             procedimiento.Parameters.AddWithValue("est", poaEN.idestado);
             procedimiento.Parameters.AddWithValue("msg", poaEN.mensaje);
             procedimiento.Parameters.AddWithValue("usr", poaEN.usuario);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }

         public int TransferirMonto(PoaEN poaEN, int idDepTras)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("TransferirMonto");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idDepOr", poaEN.idDependencia);
             procedimiento.Parameters.AddWithValue("idDepTras", idDepTras);
             procedimiento.Parameters.AddWithValue("Mnt", poaEN.monto);
             procedimiento.Parameters.AddWithValue("usr", poaEN.usuario);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         

    }
}

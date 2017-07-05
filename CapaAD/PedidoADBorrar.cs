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
    public class PedidoADBorrar
    {
        ConexionBD conectar;

        public DataTable rptPedido(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call rptPedido ({0});", pedidoEN.idPedido);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable rptPedidoDetalle(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call rptPedidoDetalle ({0});", pedidoEN.idPedido);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable rptVale(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call rptVale ({0});", pedidoEN.ccidVale);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable rptValeDetalle(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call rptValeDetalle ({0});", pedidoEN.ccidVale);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable rptGasto(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call rptGasto ({0});", pedidoEN.idGasto);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable rptGastoDetalle(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call rptGastoDetalle ({0});", pedidoEN.idGasto);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable gridclsSaldoAcPedido(PedidoENBorrar pedidoEN,int tipoDoc)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoAcPedido ({0},{1});", pedidoEN.idPedido, tipoDoc);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable clsSaldoCodificacion(PedidoENBorrar pedidoEN, int tipoDoc)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoCodifPedido ({0},{1});", pedidoEN.idPedido, tipoDoc);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable dropAccionesPedido(PedidoENBorrar pedidoEN,int tipoDoc)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsReglonesPedido ({0},{1});", pedidoEN.idPedido, tipoDoc);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable DropAcciones(PedidoENBorrar pedidoEN)
            {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsUsuarioDependencia ('{0}');", pedidoEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
            }

        public DataTable dropEmpleado(PedidoENBorrar pedidoEN, int idUnidad)
            {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsNombreEmpleado ('{0}', {1});", pedidoEN.usuario, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
            }

        public DataTable dropJefeDireccion(PedidoENBorrar pedidoEN)
            {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsJefeDireccion ('{0}');", pedidoEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
            }

        public DataTable dropTipoPedido()
            {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call clsTipoPedido; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
            }
        public DataTable dropUnidadMedida(PedidoENBorrar pedidoEN)
            {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsUnidadMedida ({0});", pedidoEN.idTipoPedido);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar); 
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
            }

        public DataTable gridEstadoPedido(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsEstadoPedido ('{0}');", pedidoEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable gridEstadoVale(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsEstadoVale ('{0}');", pedidoEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable gridEstadoExistencia(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsEstadoExistencia ('{0}');", pedidoEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dvPedidoFinan()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call clsPedidoFinan; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dvPedidoEncargado(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPedidoEncargado ('{0}');", pedidoEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dvPedidoExistencia()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call clsPedidoExistencia; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable gridPedidoDetalleFinan(PedidoENBorrar pedidoEN,int tipoDoc)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPedidoDetalleFinan ({0},{1});", pedidoEN.idPedido,tipoDoc);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosMPedido(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsDatosMPedido ({0});", pedidoEN.idPedido);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable gridMPedidoD(PedidoENBorrar pedidoEN,int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsDatosMPedidoD ({0},{1});", pedidoEN.idPedido, opcion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosMVale(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsValeDatosM ({0});", pedidoEN.ccidVale);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosMValeDetalle(PedidoENBorrar pedidoEN, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsValeDetalleDatosM ({0},{1});", pedidoEN.ccidVale,opcion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable pacNoAccion(PedidoENBorrar pedidoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPacNoAccion ({0});", pedidoEN.idAccion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable PedidoVerSaldos(PedidoENBorrar pedidoEN,int op)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPedidosVerSaldos ({0},{1});", op,pedidoEN.idPedido);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable PedidoDetalleVerSaldos(PedidoENBorrar pedidoEN, int op)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPedidoDetalleVerSaldos ({0},{1});", op, pedidoEN.idPedido);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public double saldoPacPac(PedidoENBorrar pedidoEN)
        {
            double saldo;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPac ({0},{1});", pedidoEN.idPac, 4);
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
        public int pacidDetalleAccion(PedidoENBorrar pedidoEN)
        {
            int id;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPacidDeAc ({0});", pedidoEN.idPac);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                id = Convert.ToInt32(tabla.Rows[0]["id"]);
            }
            else
            {
                id = 0;
            }
            return id;
        }
        public int valNoPacPedidoD(PedidoENBorrar pedidoEN)
        {
            int val;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsvalNoPacPedidoD ({0},{1});", pedidoEN.idPedido,pedidoEN.idPac);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            val = tabla.Rows.Count;
            return val;
        }
        
         public int insertarPedido(PedidoENBorrar pedidoEN)
            {
                int NoIngreso;
                conectar = new ConexionBD();
                MySqlCommand procedimiento = new MySqlCommand("Insertar_Pedido");
                procedimiento.CommandType = CommandType.StoredProcedure;
                procedimiento.Parameters.AddWithValue("idA", pedidoEN.idAccion);
                procedimiento.Parameters.AddWithValue("idTP",pedidoEN.idTipoPedido);
                procedimiento.Parameters.AddWithValue("idS", pedidoEN.idSolicitante);
                procedimiento.Parameters.AddWithValue("idJD", pedidoEN.idJefeDireccion);
                procedimiento.Parameters.AddWithValue("jus", pedidoEN.Justificacion);
                procedimiento.Parameters.AddWithValue("idfa", pedidoEN.idFand);
                procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);

                conectar.AbrirConexion();
                procedimiento.Connection = conectar.conectar;
                NoIngreso = procedimiento.ExecuteNonQuery();
                conectar.CerrarConexion();
                return NoIngreso;
            }
        public int maxidPedido()
            {
             int idPedido = 0;
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsMaxidPedido");
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             if (tabla.Rows.Count > 0)
             {
                 idPedido = Convert.ToInt32(tabla.Rows[0]["idPedido"]);
             }
             else
             {
                 idPedido = 0;
             }
             return idPedido;
         }
         public int insertarPedidoDetalle(PedidoENBorrar pedidoEN)
            {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_PedidoDetalle");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idP", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("idpc", pedidoEN.idPac);
             procedimiento.Parameters.AddWithValue("can", pedidoEN.cantidad);
             procedimiento.Parameters.AddWithValue("des", pedidoEN.descripcion);
             procedimiento.Parameters.AddWithValue("idUM", pedidoEN.idUnidadMedida);
             procedimiento.Parameters.AddWithValue("ce", pedidoEN.costoEstimado);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
           }
         public int modificarPedidoDetalle(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Modificar_PedidoDetalle");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idPD", pedidoEN.idpedidoDetalle);
             procedimiento.Parameters.AddWithValue("idpc", pedidoEN.idPac);
             procedimiento.Parameters.AddWithValue("can", pedidoEN.cantidad);
             procedimiento.Parameters.AddWithValue("idUM", pedidoEN.idUnidadMedida);
             procedimiento.Parameters.AddWithValue("des", pedidoEN.descripcion);
             procedimiento.Parameters.AddWithValue("ce", pedidoEN.costoEstimado);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int modificarPedido(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Modificar_Pedido");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idP", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("idS", pedidoEN.idSolicitante);
             procedimiento.Parameters.AddWithValue("idJD", pedidoEN.idJefeDireccion);
             procedimiento.Parameters.AddWithValue("jus", pedidoEN.Justificacion);
             procedimiento.Parameters.AddWithValue("idfa", pedidoEN.idFand);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
       public int Codificar_Reglon(PedidoENBorrar pedidoEN,int tipoDoc)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Codificar_Reglon");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idDac", pedidoEN.idDetalleAccion);
             procedimiento.Parameters.AddWithValue("idPd", pedidoEN.idpedidoDetalle);
             procedimiento.Parameters.AddWithValue("tipo", tipoDoc);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
       public int Modificar_ProSproAct(string par, PedidoENBorrar pedidoEN, int tipoDoc, int op)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Modificar_ProSProAct");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("par", par);
           procedimiento.Parameters.AddWithValue("idPd", pedidoEN.idpedidoDetalle);
           procedimiento.Parameters.AddWithValue("tipo", tipoDoc);
           procedimiento.Parameters.AddWithValue("op", op);

           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;
       }
         public int Aprobar_Pedido(PedidoENBorrar pedidoEN,int tipoDoc)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Aprobar_Pedido");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idp", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);
             procedimiento.Parameters.AddWithValue("tipo", tipoDoc);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Aprobar_EncargadoP(PedidoENBorrar pedidoEN,int tipoDoc)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Aprobar_EncargadoP");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idp", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);
             procedimiento.Parameters.AddWithValue("tipo", tipoDoc);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Aprobar_ExistenciaP(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Aprobar_ExistenciaP");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idp", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);
             procedimiento.Parameters.AddWithValue("obs", pedidoEN.observacionFinanciero);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Rechazar_Pedido(PedidoENBorrar pedidoEN,int tipoDoc)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Rechazar_Pedido");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idp", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);
             procedimiento.Parameters.AddWithValue("obs", pedidoEN.observacionFinanciero);
             procedimiento.Parameters.AddWithValue("tipo", tipoDoc);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Quitar_Detalle(PedidoENBorrar pedidoEN, int tipoDoc)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Quitar_DetalleP");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idp", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("tipo", tipoDoc);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Rechazar_EncargadoP(PedidoENBorrar pedidoEN, int tipoDoc)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Rechazar_EncargadoP");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idp", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);
             procedimiento.Parameters.AddWithValue("obs", pedidoEN.observacionFinanciero);
             procedimiento.Parameters.AddWithValue("tipo", tipoDoc);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Rechazar_ExistenciaP(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Rechazar_ExistenciaP");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idp", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);
             
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }

         public int Insertar_ccVale(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_ccVale");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idA", pedidoEN.idAccion);
             procedimiento.Parameters.AddWithValue("idS", pedidoEN.idSolicitante);
             procedimiento.Parameters.AddWithValue("idJD", pedidoEN.idJefeDireccion);
             procedimiento.Parameters.AddWithValue("jus", pedidoEN.Justificacion);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Modificar_ccVale(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Modificar_ccVale");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idV", pedidoEN.ccidVale);
             procedimiento.Parameters.AddWithValue("idA", pedidoEN.idAccion);
             procedimiento.Parameters.AddWithValue("idS", pedidoEN.idSolicitante);
             procedimiento.Parameters.AddWithValue("idJD", pedidoEN.idJefeDireccion);
             procedimiento.Parameters.AddWithValue("jus", pedidoEN.Justificacion);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }

         public int maxccidVale()
         {
             int idccvale = 0;
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsmaxccidVale");
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             if (tabla.Rows.Count > 0)
             {
                 idccvale = Convert.ToInt32(tabla.Rows[0]["idccvale"]);
             }
             else
             {
                 idccvale = 0;
             }
             return idccvale;
         }
    

         public int Insertar_ccValeDetalle(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_ccValeDetalle");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idccV", pedidoEN.ccidVale);
             procedimiento.Parameters.AddWithValue("can", pedidoEN.cantidad);
             procedimiento.Parameters.AddWithValue("Des", pedidoEN.descripcion);
             procedimiento.Parameters.AddWithValue("ce", pedidoEN.costoEstimado);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Modificar_ccValeDetalle(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Modificar_ccValeDetalle");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idccVD", pedidoEN.ccidValeDetalle);
             procedimiento.Parameters.AddWithValue("can", pedidoEN.cantidad);
             procedimiento.Parameters.AddWithValue("Des", pedidoEN.descripcion);
             procedimiento.Parameters.AddWithValue("ce", pedidoEN.costoEstimado);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }

         public int EliminarPedidoDetalle(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Eliminar_PedidoDetalle");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idPD", pedidoEN.idpedidoDetalle);
             
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Eliminar_ccValeDetalle(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Eliminar_ccValeDetalle");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idccVD", pedidoEN.ccidValeDetalle);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public double sumaValeDetalle(PedidoENBorrar pedidoEN)
         {
             double saldo;
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsValeDetalleSuma ({0});", pedidoEN.ccidVale);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             if (tabla.Rows.Count > 0)
             {
                 saldo = Convert.ToDouble(tabla.Rows[0]["suma"]);
             }
             else
             {
                 saldo = 0;
             }
             return saldo;
         }

         //  --------- Gastos Varios ------------
         public DataTable dropgastoTipo()
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             MySqlDataAdapter consulta = new MySqlDataAdapter("call clsGastoTipo(); ", conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable dropFAND()
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             MySqlDataAdapter consulta = new MySqlDataAdapter("call clsFand(); ", conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable gridEstadoGasto(PedidoENBorrar pedidoEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsEstadoGasto ('{0}');", pedidoEN.usuario);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public int Insertar_Gasto(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_Gasto");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idA", pedidoEN.idAccion);
             procedimiento.Parameters.AddWithValue("idTg", pedidoEN.idGastoTipo);
             procedimiento.Parameters.AddWithValue("idS", pedidoEN.idSolicitante);
             procedimiento.Parameters.AddWithValue("idJD", pedidoEN.idJefeDireccion);
             procedimiento.Parameters.AddWithValue("jus", pedidoEN.Justificacion);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);
             procedimiento.Parameters.AddWithValue("idFa", pedidoEN.idFand);


             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Insertar_GastoDetalle(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_GastoDetalle");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idG", pedidoEN.idGasto);
             procedimiento.Parameters.AddWithValue("can", pedidoEN.cantidad);
             procedimiento.Parameters.AddWithValue("Des", pedidoEN.descripcion);
             procedimiento.Parameters.AddWithValue("ce", pedidoEN.costoEstimado);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int MaxidGasto()
         {
             int idGasto = 0;
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsmaxidGasto");
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             if (tabla.Rows.Count > 0)
             {
                 idGasto = Convert.ToInt32(tabla.Rows[0]["idGasto"]);
             }
             else
             {
                 idGasto = 0;
             }
             return idGasto;
         }
         public DataTable DatosMGasto(PedidoENBorrar pedidoEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsGastoDatosM ({0});", pedidoEN.idGasto);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public DataTable DatosMGastoDetalle(PedidoENBorrar pedidoEN, int opcion)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsGastoDetalleDatosM ({0},{1});", pedidoEN.idGasto, opcion);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public int Modificar_GastoDetalle(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Modificar_GastoDetalle");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idGD", pedidoEN.idGastoDetalle);
             procedimiento.Parameters.AddWithValue("can", pedidoEN.cantidad);
             procedimiento.Parameters.AddWithValue("Des", pedidoEN.descripcion);
             procedimiento.Parameters.AddWithValue("ce", pedidoEN.costoEstimado);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }

         public int Modificar_Gasto(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Modificar_Gasto");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idG", pedidoEN.idGasto);
             procedimiento.Parameters.AddWithValue("ida", pedidoEN.idAccion);
             procedimiento.Parameters.AddWithValue("idtg", pedidoEN.idGastoTipo);
             procedimiento.Parameters.AddWithValue("idf", pedidoEN.idFand);
             procedimiento.Parameters.AddWithValue("idS", pedidoEN.idSolicitante);
             procedimiento.Parameters.AddWithValue("idJD", pedidoEN.idJefeDireccion);
             procedimiento.Parameters.AddWithValue("jus", pedidoEN.Justificacion);
             procedimiento.Parameters.AddWithValue("idfa", pedidoEN.idFand);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }


         public DataTable dvPedidoReajuste(PedidoENBorrar pedidoEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsPedidoReajuste ({0});", pedidoEN.idPedido);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }

         public DataTable gridPedidoDetalleReajuste(PedidoENBorrar pedidoEN, int tipoDoc)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsPedidoDetalleComp ({0},{1});",pedidoEN.idPedido, tipoDoc);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }
         public int Insertar_Reajuste(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_Reajuste");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idP", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("idPd", pedidoEN.idpedidoDetalle);
             procedimiento.Parameters.AddWithValue("reajuste", pedidoEN.reajuste);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Eliminar_GastoDetalle(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Eliminar_GastoDetalle");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idGD", pedidoEN.idGastoDetalle);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public DataTable dvGastoaPedido(PedidoENBorrar pedidoEN)
         {
             conectar = new ConexionBD();
             DataTable tabla = new DataTable();
             conectar.AbrirConexion();
             string strConsulta = string.Format("call clsGastoaPedido ({0});", pedidoEN.idGasto);
             MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
             consulta.Fill(tabla);
             conectar.CerrarConexion();
             return tabla;
         }

         public int Insertar_GastoaPedido(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_GastoaPedido");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idG", pedidoEN.idGasto);

             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }

         public int Insertar_GastoaPedidoDetalle(PedidoENBorrar pedidoEN)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_GastoaPedidoDetalle");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idGD", pedidoEN.idGastoDetalle);
             procedimiento.Parameters.AddWithValue("idP", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("idPc", pedidoEN.idPac);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }
         public int Insertar_Anulacion(PedidoENBorrar pedidoEN, int tipoDoc)
         {
             int NoIngreso;
             conectar = new ConexionBD();
             MySqlCommand procedimiento = new MySqlCommand("Insertar_Anulacion");
             procedimiento.CommandType = CommandType.StoredProcedure;
             procedimiento.Parameters.AddWithValue("idp", pedidoEN.idPedido);
             procedimiento.Parameters.AddWithValue("usr", pedidoEN.usuario);
             procedimiento.Parameters.AddWithValue("obs", pedidoEN.observacionFinanciero);
             procedimiento.Parameters.AddWithValue("tipo", tipoDoc);
             conectar.AbrirConexion();
             procedimiento.Connection = conectar.conectar;
             NoIngreso = procedimiento.ExecuteNonQuery();
             conectar.CerrarConexion();
             return NoIngreso;
         }

    }

}

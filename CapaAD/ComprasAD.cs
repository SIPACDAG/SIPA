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
   public class ComprasAD
    {
       ConexionBD conectar;

       public DataTable dvPedidoComp(ComprasEN comprasEN,int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string strConsulta = string.Format("call clsPedidoComp ({0},'{1}',{2});", comprasEN.idPedido, comprasEN.Documento,opcion);
           MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public int EstadoIngresoCompras(ComprasEN comprasEN, int tipoDoc)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string strConsulta = string.Format("call clsEstadoIngresoCompras ({0},{1});", comprasEN.idPedido, tipoDoc);
           MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla.Rows.Count;
       }
       public DataTable gridPedidoDetalleComp(ComprasEN comprasEN, int tipoDoc)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string strConsulta = string.Format("call clsPedidoDetalleComp ({0},{1});", comprasEN.idPedido, tipoDoc);
           MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable gridProveedor()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string strConsulta = "call clsProveedoresListado ();";
           MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable dropTecnicoCompras()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call clsTecnicoCompras(); ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable dropProveedor()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call clsProveedor(); ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public int Insertar_IngresoCompras(ComprasEN comprasEN, int tipoDoc)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Insertar_IngresoCompras");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("idp", comprasEN.idPedido);
           procedimiento.Parameters.AddWithValue("usr", comprasEN.usuario);
           procedimiento.Parameters.AddWithValue("tipo", tipoDoc);

           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;
       }
       public int Insertar_RechazarCompras(ComprasEN comprasEN,int tipoDoc)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Insertar_RechazarCompras");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("idp", comprasEN.idPedido);
           procedimiento.Parameters.AddWithValue("usr", comprasEN.usuario);
           procedimiento.Parameters.AddWithValue("obs", comprasEN.observacion);
           procedimiento.Parameters.AddWithValue("tipo", tipoDoc);
           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;
       }
       public int Insertar_Anulacion(ComprasEN comprasEN, int tipoDoc)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Insertar_Anulacion");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("idp", comprasEN.idPedido);
           procedimiento.Parameters.AddWithValue("usr", comprasEN.usuario);
           procedimiento.Parameters.AddWithValue("obs", comprasEN.observacion);
           procedimiento.Parameters.AddWithValue("tipo", tipoDoc);
           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;
       }
       public int Insertar_Tecnico(ComprasEN comprasEN)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Insertar_PedidoTecnico");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("idP", comprasEN.idPedido);
           procedimiento.Parameters.AddWithValue("idT", comprasEN.idTecnico);
           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;
       }
       public int Insertar_CostoRealPedido(ComprasEN comprasEN,int op)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Insertar_PedidoCostoReal");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("Op", op);
           procedimiento.Parameters.AddWithValue("idP", comprasEN.idPedido);
           procedimiento.Parameters.AddWithValue("NOC", comprasEN.noOrdenCompra);
           procedimiento.Parameters.AddWithValue("FOC", comprasEN.fechaOrdenCompra);
           procedimiento.Parameters.AddWithValue("cos", comprasEN.montoReal);
           procedimiento.Parameters.AddWithValue("idProv", comprasEN.idProveedor);

           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;
       }
       public int Insertar_Proveedores(ComprasEN comprasEN)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Insertar_Proveedor");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("prov", comprasEN.proveedor);
           procedimiento.Parameters.AddWithValue("nt", comprasEN.nit);
           procedimiento.Parameters.AddWithValue("tel", comprasEN.telefono);
           procedimiento.Parameters.AddWithValue("dir", comprasEN.direccion);
           procedimiento.Parameters.AddWithValue("usr", comprasEN.usuario);
           
           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;
       }
       public int Insertar_GastoCostoReal(ComprasEN comprasEN, int op)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Insertar_GastoCostoReal");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("Op", op);
           procedimiento.Parameters.AddWithValue("idP", comprasEN.idPedido);
           procedimiento.Parameters.AddWithValue("NOC", comprasEN.noOrdenCompra);
           procedimiento.Parameters.AddWithValue("FOC", comprasEN.fechaOrdenCompra);
           procedimiento.Parameters.AddWithValue("cos", comprasEN.montoReal);
           
           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;
       }

       public int Insertar_CostoRealVale(ComprasEN comprasEN)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Insertar_ValeCostoReal");
           procedimiento.CommandType = CommandType.StoredProcedure;
           
           procedimiento.Parameters.AddWithValue("idVD", comprasEN.idccValeDetalle);
           procedimiento.Parameters.AddWithValue("cos", comprasEN.montoReal);
           procedimiento.Parameters.AddWithValue("idProv", comprasEN.idProveedor);

           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;
       }

       public DataTable dropPedidoTecnico(ComprasEN comprasEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string strConsulta = string.Format("call clsPedidoTecnico ('{0}');", comprasEN.Documento);
           MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       
    }
}

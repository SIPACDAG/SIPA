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
    public class ReportesAD
    {

        ConexionBD conectar;



        public DataTable ReportesSipa(int id, int id2, string criterio, int opcion)
        {

            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("CALL sp_reportes({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            tabla.TableName = "Datos";
            return tabla;
        }




        /// <summary>
        /// ///////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="idUnidad"></param>
        /// <param name="idPoa"></param>
        /// <returns></returns>
        public DataTable ConsultaProcedimiento(Int32 idUnidad, int idPoa)
        {

            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call sp_slctPlanAccionGB ({0}, {1})", idUnidad, idPoa);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            tabla.TableName = "DataReporte";
            return tabla;
        }

        public DataTable unidadUsuario(string usuario)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsUnidadesUsuario ('{0}')", usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable poaUsuario(int anio, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsDatosPoa ({0},{1})", idUnidad, anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable fadnsSaldoRetencion(int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsFADNSaldo ({0});", anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable fadnsSaldosGeneral(int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsFADNGastos ({0});", anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoReglones(int opcion, int par)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldosReglones ({0},{1});", opcion, par);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoReglonesUnidad(string letra, int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPVReglones ('{0}',{1});", letra, anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoResumenes(int opcion, int par)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldosResumen ({0},{1});", opcion, par);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoProveedores(int opcion, int par)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoProveedores ({0},{1});", opcion, par);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable HistorialMovimiento(int opcion, int parametro, int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsHistorialMovimientos ({0},{1},{2});", opcion, parametro, anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataSet SaldosxUnidad(int anio)
        {
            conectar = new ConexionBD();
            DataSet tabla = new DataSet();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select t.id as Unidad, t.MontoPoa, t.Codificado,  ((t.MontoPoa - t.Codificado)) Saldo from " +
                "(select u.unidad id, COALESCE(SUM(da.monto), 0) MontoPoa, COALESCE((SELECT SUM(gasto)  as Gasto FROM unionpedido up, sipa_detalles_accion da, sipa_acciones aa " +
                " WHERE up.estado_financiero = 1 AND up.id_detalle_accion = da.id_detalle AND da.id_accion = aa.id_accion AND da.no_renglon = da.no_renglon AND aa.id_poa = p.id_poa" +
                " ), 0) Codificado from sipa_acciones d inner join sipa_poa p on p.id_poa = d.id_poa inner join sipa_detalles_accion da on da.id_accion = d.id_accion " +
                " inner join ccl_unidades u on u.id_unidad = p.id_unidad and p.anio = {0} Group by p.id_unidad )t;", anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public string[] DashboardConsulta(string idUnidad, string anio)
        {
            string[] query = new string[5];
            query[0] = string.Format("SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_pedidos p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_pedido INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad where u.id_unidad ={0}", idUnidad);
            query[1] = string.Format("SELECT v.no_solicitud, ev.nombre_estado, u.id_unidad, u.Unidad FROM sipa_viaticos v INNER JOIN sipa_estados_viaticos ev ON ev.id_estado_viatico = v.id_estado_viatico INNER JOIN ccl_unidades u ON u.id_unidad = v.id_unidad where u.id_unidad ={0}", idUnidad);
            query[2] = string.Format("SELECT SUM(d.monto) AS monto FROM     sipa_detalles_accion d INNER JOIN sipa_acciones aa ON aa.id_accion = d.id_accion INNER JOIN sipa_renglones r ON d.no_renglon = r.No_Renglon " +
                                     "INNER JOIN sipa_tipos_financiamiento f ON d.id_tipo_financiamiento = f.id_tipo inner join sipa_poa poa on poa.id_poa = aa.id_poa WHERE  poa.id_unidad = {0} and poa.anio = {1} ", idUnidad, anio);
            query[3] = string.Format("SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa"  +
                                    " ON aa.id_accion = d.id_accion  inner join sipa_poa poa on poa.id_poa = aa.id_poa " +
                                     "WHERE(up.estado_financiero = 1) AND poa.id_unidad = {0} and poa.anio = {1} ",idUnidad,anio);
            query[4] = string.Format("SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_ccvale p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_vale INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad where u.id_unidad ={0}", idUnidad);
            return query;
        }
    }
}

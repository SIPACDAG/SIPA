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

    public class PresupuestoAD
    {
        ConexionBD conectar;
        public DataTable dropUnidad()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call slctnombreunidad; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropUnidadesUsuario(string usuario)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call slctUnidadesxUsuario('" + usuario + "') ; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable dropDependencia(int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call slctNombreDependencias(" + idUnidad + ") ; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosPresupuesto(int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call clsPresupuesto("+anio+") ; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosPresupuestoDep(int anio,int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call slctPresupuestoDep(" + anio + "," + idUnidad + ") ; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public int valPresUnidad(PresupuestoEN presupuestoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call clsValPresupuesto(" + presupuestoEN.idUnidad + "," + presupuestoEN.anio + ");", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla.Rows.Count;
        }
        public double SaldoPresUnidad(PresupuestoEN presupuestoEN)
        {   double saldo;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call slctSaldoPresUnidad(" + presupuestoEN.idUnidad + "," + presupuestoEN.anio + ");", conectar.conectar);
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
        public int valPresDep(PresupuestoEN presupuestoEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("call ExistePresupuestoDep(" + presupuestoEN.idDependencia + "," + presupuestoEN.anio + ");", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla.Rows.Count;
        }
 
        public int InsertarPresUnidad(PresupuestoEN presupuestoEN, string usuario)

        {
            if (!validarPermiso(usuario))
            {
                conectar = new ConexionBD();
                DataTable tabla = new DataTable();
                string query = string.Format("call Insertar_PresUnidad({0}, {1}, {2}, '{3}')", presupuestoEN.idUnidad, presupuestoEN.monto, presupuestoEN.anio, presupuestoEN.usuario);
                conectar.AbrirConexion();
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();

                return 0;
            }
            return -1;
        }

        public DataSet AlmacenarModificacionTechoPpto(PresupuestoEN pptoEN, string usuario)
        {
            DataSet dsResultado = null;
            if (!validarPermiso(usuario))
            {
                string query = "";
               
                DataTable dt;
                DataTable dtEnc;
                MySqlTransaction sqlTransaction;
                MySqlDataAdapter sqlAdapter;
                conectar = new ConexionBD();

                query = "CALL sp_iue_techos_ppto(" + pptoEN.id_modificacion + ", " + pptoEN.id_poa + ", " + pptoEN.id_unidad + ", " + pptoEN.anio_solicitud + ", " + pptoEN.techo_aprobado + ", " + pptoEN.techo_actual + ", " + pptoEN.ppto_codificado + ", " + pptoEN.ppto_pendiente_codificar + ", " + pptoEN.nuevo_techo + ", " + pptoEN.sobreescribe_techo_aprobado + ", '" + pptoEN.justificacion + "', 1, '" + pptoEN.observaciones + "', '" + pptoEN.usuario + "', 1);";

                dt = armarDsResultado().Tables[0].Copy();
                dtEnc = armarDsResultado().Tables[0].Copy();

                conectar.AbrirConexion();
                sqlTransaction = conectar.conectar.BeginTransaction();
                try
                {
                    dt = new DataTable();
                    sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                    sqlAdapter.Fill(dt);

                    if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                        throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                    int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                    dtEnc.Rows[0]["ERRORES"] = false;
                    dtEnc.Rows[0]["MSG_ERROR"] = "";
                    dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                    dtEnc.Rows[0]["VALOR"] = "";
                }

                if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                    sqlTransaction.Commit();

                conectar.CerrarConexion();

                dsResultado = new DataSet();
                dsResultado.Tables.Add(dtEnc.Copy());
            }
            

            return dsResultado;
        }


        public int InsertarPresDep(PresupuestoEN presupuestoEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Insertar_PresupuestoDep");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idDep", presupuestoEN.idDependencia);
            procedimiento.Parameters.AddWithValue("Mon", presupuestoEN.monto);
            procedimiento.Parameters.AddWithValue("ao", presupuestoEN.anio);
            procedimiento.Parameters.AddWithValue("usr", presupuestoEN.usuario);

            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;

        }
        public int EliminarPresUnidad(PresupuestoEN presupuestoEN,string usuario)
        {
            if (!validarPermiso(usuario))
            {
                int NoIngreso;
                conectar = new ConexionBD();
                MySqlCommand procedimiento = new MySqlCommand("Eliminar_PresUnidad");
                procedimiento.CommandType = CommandType.StoredProcedure;
                procedimiento.Parameters.AddWithValue("idPres", presupuestoEN.idPresupuestoUnidad);

                conectar.AbrirConexion();
                procedimiento.Connection = conectar.conectar;
                NoIngreso = procedimiento.ExecuteNonQuery();
                conectar.CerrarConexion();
                return NoIngreso;
            }

            return -1;
        }

        public DataTable InformacionTechosPpto(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctTechosPpto({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
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
    }
}

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
    public class PlanAnualAD
    {
        ConexionBD conectar;

        public DataTable DdlModalidades()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctModalidades();");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlExcepciones()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctExcepciones();");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlRenglones()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctRenglones(0, 0, '', 1);");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable DdlPac(int idDetalleAccion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctPac({0}, 1);", idDetalleAccion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable DdlCategorias(string noRenglon)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctCategorias('{0}');", noRenglon);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable GridDetallesAccion(int idAccion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = string.Format("CALL sp_slctPptoPac({0}, {1});", idAccion, 1);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable GridListadoPacs(string usuario, string idPoa)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = string.Format("CALL sp_slctPacListado('{0}', {1}, 1);", usuario, idPoa);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable GridListadoPacs(int idPoa)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = string.Format("CALL sp_slctPacListado('', {0}, 4);", idPoa);
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

        public DataSet AlmacenarPac(DataSet dsPac,string usuariop)
        {
            DataSet dsResultado = new DataSet();
            
                string query = "";
                
                DataTable dt;
                DataTable dtPac;
                DataTable dtPacDet;
                MySqlTransaction sqlTransaction;
                MySqlDataAdapter sqlAdapter;
                conectar = new ConexionBD();

                string idPacS, idPoa, idDet, idIns, noRen, idMod, idCat, idExc, descr, anio, usuario;
                idPacS = dsPac.Tables["ENC"].Rows[0]["ID_PAC"].ToString();
                idPoa = dsPac.Tables["ENC"].Rows[0]["ID_POA"].ToString();
                idDet = dsPac.Tables["ENC"].Rows[0]["ID_DETALLE"].ToString();
                idIns = dsPac.Tables["ENC"].Rows[0]["ID_INSUMO"].ToString();
                //noRen = dsPac.Tables["ENC"].Rows[0]["NO_RENGLON"].ToString();
                idMod = dsPac.Tables["ENC"].Rows[0]["ID_MODALIDAD"].ToString();
                idCat = dsPac.Tables["ENC"].Rows[0]["ID_CATEGORIA"].ToString();
                idExc = dsPac.Tables["ENC"].Rows[0]["ID_EXCEPCION"].ToString();
                descr = dsPac.Tables["ENC"].Rows[0]["DESCRIPCION"].ToString();
                anio = dsPac.Tables["ENC"].Rows[0]["ANIO"].ToString();
                usuario = dsPac.Tables["ENC"].Rows[0]["USUARIO"].ToString();


                if (idCat.Equals("0"))
                    idCat = "null";

                if (idExc.Equals("0"))
                    idExc = "null";

                //query = "CALL sp_iu_pac(" + idPacS + ", " + idDet + ", '" + noRen + "', " + idMod + ", " + idCat + ", " + idExc + ", '" + descr + "', " + anio + ", '" + usuario + "');";
                query = "CALL sp_iu_pac(" + idPacS + ", " + idPoa + ", " + idDet + ", " + idMod + ", " + idCat + ", " + idExc + ", '" + descr + "', " + anio + ", '" + usuario + "'," + idIns + ");";

                dt = armarDsResultado().Tables[0].Copy();
                dtPac = armarDsResultado().Tables[0].Copy();

                conectar.AbrirConexion();
                sqlTransaction = conectar.conectar.BeginTransaction();
                try
                {
                    dt = new DataTable();
                    sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                    sqlAdapter.Fill(dt);

                    if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                        throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                    int idPac = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                    dtPac.Rows[0]["ERRORES"] = false;
                    dtPac.Rows[0]["MSG_ERROR"] = "";
                    dtPac.Rows[0]["VALOR"] = idPac;

                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtPac.Rows[0]["ERRORES"] = true;
                    dtPac.Rows[0]["MSG_ERROR"] = ex.Message;
                    dtPac.Rows[0]["VALOR"] = "";
                }

                dtPacDet = armarDsResultado().Tables[0].Copy();
                dtPacDet.TableName = "DETALLES";
                dtPacDet.Rows.RemoveAt(0);
                if (dtPac.Rows.Count > 0 && !bool.Parse(dtPac.Rows[0]["ERRORES"].ToString()))
                {
                    int idPac = int.Parse(dtPac.Rows[0]["VALOR"].ToString());

                    try
                    {
                        foreach (DataRow dr in dsPac.Tables["DET"].Rows)
                        {
                            dt = new DataTable();
                            query = "CALL sp_iu_pac_detalles(";
                            query += dr["ID_DETALLE"].ToString() + ", ";
                            query += idPac + ", ";//dr["ID_PAC"].ToString() + ", ";
                            query += dr["MES"].ToString() + ", ";
                            query += dr["CANTIDAD"].ToString() + ", ";
                            query += dr["MONTO"].ToString() + ", ";
                            query += "'" + dr["USUARIO"].ToString() + "'";
                            query += "); ";

                            sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                            sqlAdapter.Fill(dt);

                            if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                                throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                            DataRow drDet = dtPacDet.NewRow();
                            drDet["ERRORES"] = dt.Rows[0]["RESULTADO"].ToString();
                            drDet["MSG_ERROR"] = "";
                            drDet["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                            dtPacDet.Rows.Add(drDet);
                        }
                        sqlTransaction.Commit();
                        conectar.CerrarConexion();

                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        conectar.CerrarConexion();

                        dtPac.Rows[0]["ERRORES"] = true;
                        dtPac.Rows[0]["MSG_ERROR"] = ex.Message;
                        //dtPac.Rows[0]["VALOR"] = idPac;
                    }
                }

                dsResultado = new DataSet();
                dsResultado.Tables.Add(dtPac.Copy());
                dsResultado.Tables.Add(dtPacDet);

                return dsResultado;
           
        }

        public DataTable EliminarPac(int idPac)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_el_pac({0});", idPac);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataSet InformacionPac(int idPac)
        {
            conectar = new ConexionBD();
            DataTable tablaEnc = new DataTable("ENCABEZADO");
            DataTable tablaDet = new DataTable("DETALLES");

            string query = String.Format("CALL sp_slctPacListado('', {0}, 2);", idPac);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tablaEnc);

            query = String.Format("CALL sp_slctPacListado('', {0}, 3);", idPac);
            conectar.AbrirConexion();
            consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tablaDet);
            conectar.CerrarConexion();

            DataSet ds = new DataSet();
            ds.Tables.Add(tablaEnc.Copy());
            ds.Tables.Add(tablaDet.Copy());

            return ds;
        }

        public DataTable InformacionRenglonAccion(int idDetalleAccion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPptoPac({0}, {1});", idDetalleAccion, 2);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable ActualizarEstadoPac(int idPoa, int idEstado, int anio, string idUsuario, string usuarioAsignado, string usuario, string observaciones)
        {
            DataTable tabla = new DataTable();
            
                conectar = new ConexionBD();
                
                string query = "";
                if (idUsuario == null)
                    query = String.Format("CALL sp_cambiaEstadoPoaPac({0}, {1}, {2}, null, '{3}', '{4}', '{5}', 2);", idPoa, idEstado, anio, usuarioAsignado, usuario, observaciones);
                else
                    query = String.Format("CALL sp_cambiaEstadoPoaPac({0}, {1}, {2}, {3}, '{4}', '{5}', '{6}', 2);", idPoa, idEstado, anio, idUsuario, usuarioAsignado, usuario, observaciones);
                conectar.AbrirConexion();
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
                return tabla;
           
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

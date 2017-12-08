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
    public class ViaticosAD
    {
        ConexionBD conectar;

        //EMPLEADOS
        public DataTable DdlSolicitantes(string usuario, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctDatosEmpleado(0, 0, '{0}', {1}, 8);", usuario, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        //SUBGERENTES Y DIRECTORES DE ÁREA
        public DataTable DdlJefes(string usuario, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctDatosEmpleado(0, 0, '{0}', {1}, 9);", usuario, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlSubGerentes(string usuario, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctDatosEmpleado(0, 0, '{0}', {1}, 10);", usuario, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlPuestosEmpleado(string usuario, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctDatosEmpleado(0, 0, '{0}', {1}, 4);", usuario, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlDetCategorias(int id, int id2, string criterio, int vOpcion)
        {
            return InformacionViatico(id, id2, vOpcion);
        }

        public DataTable DdlDetGrupos(int id, int id2, string criterio, int vOpcion)
        {
            return InformacionViatico(id, id2, vOpcion);
        }


        public DataSet AlmacenarViaticos(ViaticosEN ObjEN, DataTable dtDetalles, string ip, string mac, string pc)
        {
            string query = "";
            DataSet dsResultado;
            DataTable dt;
            DataTable dtEnc;
            DataTable dtDet;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            string vid_viatico, vfecha_nombramiento, vid_poa, vid_accion, vid_subgerente, vid_tipo_viatico, vid_solicitante, vid_jefe_director, vid_tipo_persona, vid_unidad, vid_puesto, vnombre_solicitante, vnombre_unidad, vnombre_dependencia, vnombre_puesto, vsueldo_base, vtelefono, vemail, vnit, vjustificacion, vdestino, vfecha_ini, vfecha_fin, vhora_ini, vhora_fin, vutiliza_vehiculo, vkilometraje, vpasajes, vcuota_diaria, vobservaciones_viaticos, vtasa_de_cambio, vtasa_de_cambio_ds, vcosto, vobservaciones_rechazo, vid_categoria, vid_grupo_paises, vretorno_al_exterior, vtotal_dolares, vusuario;

            vid_viatico = ObjEN.ID_VIATICO.ToString();
            vfecha_nombramiento = "'" + ObjEN.FECHA_NOMBRAMIENTO.Year + "-" + ObjEN.FECHA_NOMBRAMIENTO.Month + "-" + ObjEN.FECHA_NOMBRAMIENTO.Day + "'";
            vid_poa = ObjEN.ID_POA.ToString();
            vid_accion = ObjEN.ID_ACCION.ToString();
            vid_tipo_viatico = ObjEN.ID_TIPO_VIATICO.ToString();
            vid_solicitante = ObjEN.ID_SOLICITANTE.ToString();
            vid_jefe_director = ObjEN.ID_JEFE_DIRECTOR.ToString();
            vid_subgerente = ObjEN.ID_SUBGERENTE.ToString();
            vid_tipo_persona = ObjEN.ID_TIPO_PERSONA.ToString();
            vid_unidad = ObjEN.ID_UNIDAD.ToString();
            vid_puesto = ObjEN.ID_PUESTO.ToString();
            vnombre_solicitante = "'" + ObjEN.NOMBRE_SOLICITANTE.ToString() + "'";
            vnombre_unidad = "'" + ObjEN.NOMBRE_UNIDAD.ToString() + "'";
            vnombre_dependencia = "'" + ObjEN.NOMBRE_DEPENDENCIA.ToString() + "'";
            vnombre_puesto = "'" + ObjEN.NOMBRE_PUESTO.ToString() + "'";
            vsueldo_base = ObjEN.SUELDO_BASE.ToString();
            vemail = "'" + ObjEN.EMAIL.ToString() + "'";
            vtelefono = "'" + ObjEN.TELEFONO.ToString() + "'";
            vnit = "'" + ObjEN.NIT.ToString() + "'";
            vjustificacion = "'" + ObjEN.JUSTIFICACION.ToString() + "'";
            vdestino = "'" + ObjEN.DESTINO.ToString() + "'";
            vfecha_ini = "'" + ObjEN.FECHA_INI.Year + "-" + ObjEN.FECHA_INI.Month + "-" + ObjEN.FECHA_INI.Day + "'";
            vfecha_fin = "'" + ObjEN.FECHA_FIN.Year + "-" + ObjEN.FECHA_FIN.Month + "-" + ObjEN.FECHA_FIN.Day + "'";

            string sMinutos = "";

            sMinutos = ObjEN.FECHA_INI.Minute.ToString();
            if (ObjEN.FECHA_INI.Minute < 10)
                sMinutos = "0" + ObjEN.FECHA_INI.Minute;

            vhora_ini = ObjEN.FECHA_INI.Hour.ToString() + "." + sMinutos;

            sMinutos = ObjEN.FECHA_FIN.Minute.ToString();
            if (ObjEN.FECHA_FIN.Minute < 10)
                sMinutos = "0" + ObjEN.FECHA_FIN.Minute;

            vhora_fin = ObjEN.FECHA_FIN.Hour.ToString() + "." + sMinutos;
            vutiliza_vehiculo = ObjEN.VEHICULO_CDAG.ToString();
            vkilometraje = ObjEN.KILOMETRAJE.ToString();
            vpasajes = ObjEN.PASAJES.ToString();
            vcuota_diaria = ObjEN.CUOTA_DIARIA.ToString();
            vobservaciones_viaticos = "'" + ObjEN.OBSERVACIONES.ToString() + "'";
            vtasa_de_cambio = ObjEN.TASA_DE_CAMBIO.ToString();
            vtasa_de_cambio_ds = "'" + ObjEN.TASA_DE_CAMBIO_DS + "'";
            vcosto = ObjEN.COSTO_VIATICOS.ToString();
            vobservaciones_rechazo = "''";
            vid_categoria = ObjEN.ID_CATEGORIA_DET.ToString();
            vid_grupo_paises = "'" + ObjEN.ID_GRUPO_DET + "'";
            vretorno_al_exterior = "'" + ObjEN.RETORNO_AL_EXTERIOR + "'";
            vtotal_dolares = ObjEN.TOTAL_DOLARES.ToString();
            vusuario = "'" + ObjEN.USUARIO.ToString() + "'";

            if (ObjEN.ID_TIPO_VIATICO == 1)
            {
                //vid_categoria = "null";
                vid_grupo_paises = "null";
            }

            query = "CALL sp_iue_viaticos(" + vid_viatico + ", " + vfecha_nombramiento + ", " + vid_poa + ", " + vid_accion + ", " + vid_tipo_viatico + ", " + vid_solicitante + ", " + vid_jefe_director + ", " + vid_tipo_persona + ", " + vid_unidad + ", " + vid_puesto + ", " + vnombre_solicitante + ", " + vnombre_unidad + ", " + vnombre_dependencia + ", " + vnombre_puesto + ", " + vsueldo_base + ", " + vtelefono + ", " + vnit + ", " + vjustificacion + ", " + vdestino + ", " + vfecha_ini + ", " + vfecha_fin + ", " + vhora_ini + ", " + vhora_fin + ", " + vutiliza_vehiculo + ", " + vkilometraje + ", " + vpasajes + ", " + vcuota_diaria + ", " + vobservaciones_viaticos + ", " + vtasa_de_cambio + ", " + vcosto + ", " + vobservaciones_rechazo + ", " + vid_subgerente + ", " + vemail + ", " + vid_categoria + ", " + vid_grupo_paises + ", " + vtasa_de_cambio_ds + ", " + vretorno_al_exterior + ", " + vtotal_dolares + ", '', '', '', '', '', 0, " + vusuario + ", 1,'"
                 + ip + "','" + mac + "','" + pc + "')";

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

            dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);
            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
            {
                int idEncabezado = int.Parse(dtEnc.Rows[0]["VALOR"].ToString());

                try
                {
                    string vid_viatico_detalle, vdia, vfecha, vmonto_desayuno, vmonto_almuerzo, vmonto_cena, vmonto_hospedaje, vcuota, vcuota_dolares;
                    foreach (DataRow drDetalles in dtDetalles.Rows)
                    {

                        vid_viatico_detalle = drDetalles["ID"].ToString();
                        vid_viatico = idEncabezado.ToString();
                        vdia = drDetalles["DIA"].ToString();

                        vfecha = "'" + ObjEN.FECHA_INI.Year + "-" + ObjEN.FECHA_INI.Month + "-" + ObjEN.FECHA_INI.Day + "'";
                        vmonto_desayuno = drDetalles["MONTO_DESAYUNO"].ToString();
                        vmonto_almuerzo = drDetalles["MONTO_ALMUERZO"].ToString();
                        vmonto_cena = drDetalles["MONTO_CENA"].ToString();
                        vmonto_hospedaje = drDetalles["MONTO_HOSPEDAJE"].ToString();
                        vcuota = drDetalles["CUOTA"].ToString();
                        vcuota_dolares = drDetalles["CUOTA_DOLARES"].ToString();
                        query = "CALL sp_iue_viaticos_detalles(" + vid_viatico_detalle + ", " + vid_viatico + ", " + vdia + ", " + vfecha + ", " + vcuota + ", " + vmonto_desayuno + ", " + vmonto_almuerzo + ", " + vmonto_cena + ", " + vmonto_hospedaje + ", " + vcuota_dolares + ", '', " + vusuario + ", 1);";

                        dt = new DataTable();
                        sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                        sqlAdapter.Fill(dt);

                        ObjEN.FECHA_INI = ObjEN.FECHA_INI.AddDays(1);

                        if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                            throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                        DataRow drDet = dtDet.NewRow();
                        drDet["ERRORES"] = dt.Rows[0]["RESULTADO"].ToString();
                        drDet["MSG_ERROR"] = "";
                        drDet["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                        dtDet.Rows.Add(drDet);
                    }
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            dsResultado.Tables.Add(dtDet);

            return dsResultado;
        }

        private string QueryParaCambioEstados(int idEncabezado, int idTipoViatico, string usuario, string observacionesRechazo, string PRG, string SPRG, string PROY, string ACT, string OBR, int idDetalleAccion, decimal costo, decimal pasajes_plan, decimal pasajes, decimal kilometraje_plan, decimal kilometraje, string estado, string ip, string mac, string pc)
        {
            string vid_viatico, vfecha_nombramiento, vid_poa, vid_accion, vid_subgerente, vid_tipo_viatico, vid_solicitante, vid_jefe_director, vid_tipo_persona, vid_unidad, vid_puesto, vnombre_solicitante, vnombre_unidad, vnombre_dependencia, vnombre_puesto, vsueldo_base, vtelefono, vemail, vnit, vjustificacion, vdestino, vfecha_ini, vfecha_fin, vhora_ini, vhora_fin, vutiliza_vehiculo,vkilometraje_plan ,vkilometraje, vpasajes_plan, vpasajes, vcuota_diaria, vobservaciones_viaticos, vtasa_de_cambio, vtasa_de_cambio_ds, vcosto, vobservaciones_rechazo, vid_categoria, vid_grupo_paises, vretorno_al_exterior, vtotal_dolares, vusuario;
            string vPRG, vSPRG, vPROY, vACT, vOBR, vidDetalleAccion = "";

            vid_viatico = idEncabezado.ToString();
            vfecha_nombramiento = "null";
            vid_poa = "0";
            vid_accion = "0";
            vid_tipo_viatico = "0";
            vid_solicitante = "0";
            vid_jefe_director = "0";
            vid_subgerente = "0";
            vid_tipo_persona = "0";
            vid_unidad = "0";
            vid_puesto = "0";
            vnombre_solicitante = "''";
            vnombre_unidad = "''";
            vnombre_dependencia = "''";
            vnombre_puesto = "''";
            vsueldo_base = "0";
            vemail = "''";
            vtelefono = "''";
            vnit = "''";
            vjustificacion = "''";
            vdestino = "''";
            vfecha_ini = "null";
            vfecha_fin = "null";
            vhora_ini = "0";
            vhora_fin = "0";
            vutiliza_vehiculo = "0";
            vkilometraje_plan = kilometraje_plan.ToString();
            vkilometraje = kilometraje.ToString();
            vpasajes_plan = pasajes_plan.ToString();
            vpasajes = pasajes.ToString();
            vcuota_diaria = "0";
            vobservaciones_viaticos = "'" + observacionesRechazo + "'";
            vtasa_de_cambio = "0";
            vtasa_de_cambio_ds = "''";
            vcosto = costo.ToString();
            vobservaciones_rechazo = "''";
            vid_categoria = "0";
            vid_grupo_paises = "''";
            vretorno_al_exterior = "0";
            vusuario = "'" + usuario + "'";

            vid_categoria = "0";
            vid_grupo_paises = "0";
            vtotal_dolares = "0";

            vPRG = "'" + PRG + "'";
            vPRG = vPRG.Replace("'null'", "null");

            vSPRG = "'" + SPRG + "'";
            vSPRG = vSPRG.Replace("'null'", "null");

            vPROY = "'" + PROY + "'";
            vPROY = vPROY.Replace("'null'", "null");

            vACT = "'" + ACT + "'";
            vACT = vACT.Replace("'null'", "null");

            vOBR = "'" + OBR + "'";
            vOBR = vOBR.Replace("'null'", "null");

            vidDetalleAccion = idDetalleAccion.ToString();

            string query = "CALL sp_iue_viaticos(" + vid_viatico + ", " + vfecha_nombramiento + ", " + vid_poa + ", " + vid_accion + ", " + vid_tipo_viatico + ", " + vid_solicitante + ", " + vid_jefe_director + ", " + vid_tipo_persona + ", " + vid_unidad + ", " + vid_puesto + ", " + vnombre_solicitante + ", " + vnombre_unidad + ", " + vnombre_dependencia + ", " + vnombre_puesto + ", " + vsueldo_base + ", " + vtelefono + ", " + vnit + ", " + vjustificacion + ", " + vdestino + ", " + vfecha_ini + ", " + vfecha_fin + ", " + vhora_ini + ", " + vhora_fin + ", " + vutiliza_vehiculo   + ", " + vkilometraje + ", " + vpasajes + ", " + vcuota_diaria + ", " + vobservaciones_viaticos + ", " + vtasa_de_cambio + ", " + vcosto + ", " + vobservaciones_rechazo + ", " + vid_subgerente + ", " + vemail + ", " + vid_categoria + ", " + vid_grupo_paises + ", " + vtasa_de_cambio_ds + ", " + vretorno_al_exterior + ", " + vtotal_dolares + ", " + vPRG + ", " + vSPRG + ", " + vPROY + ", " + vACT + ", " + vOBR + ", " + vidDetalleAccion + ", " + vusuario + ", " + estado + ",'"
                 + ip + "','" + mac + "','" + pc + "')";

            return query;
        }
        //ENVIAR EL VIATICO A APROBACIÓN DE SUGBERENTE
        public DataTable EnviarViaticoARevision(int idEncabezado, int idTipoViatico, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();

            string query = QueryParaCambioEstados(idEncabezado, idTipoViatico, usuario, "", "", "", "", "", "", 0, 0, 0, 0, 0,0, "3", ip, mac, pc);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //Vo.Bo. Nivel 1
        public DataTable AprobacionJefeDirector(int idEncabezado, string observaciones, string usuario, string ip, string mac, string pc)
        {
            //QueryParaCambioEstados(int idEncabezado, int idTipoViatico, string usuario, string observacionesRechazo, string PRG, string SPRG, string PROY, string ACT, string OBR, int idDetalleAccion, decimal pasajes, decimal kilometraje, string estado)
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = QueryParaCambioEstados(idEncabezado, 0, usuario, "", "", "", "", "", "", 0, 0, 0,0, 0, 0, "4", ip, mac, pc);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable RechazoJefeDirector(int idEncabezado, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = QueryParaCambioEstados(idEncabezado, 0, usuario, observaciones, "", "", "", "", "", 0, 0, 0, 0,0, 0, "5", ip, mac, pc);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //Vo.Bo. Nivel 2
        public DataTable AprobacionSubgerente(int idEncabezado, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = QueryParaCambioEstados(idEncabezado, 0, usuario, "", "", "", "", "", "", 0, 0, 0, 0,0 ,0, "6", ip, mac, pc);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable RechazoSubgerente(int idEncabezado, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = QueryParaCambioEstados(idEncabezado, 0, usuario, observaciones, "", "", "", "", "", 0, 0, 0, 0,0 ,0, "7", ip, mac, pc);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //Vo.Bo. Nivel 3
        public DataTable AprobacionFinanciera(int idEncabezado, string observaciones, string usuario, string PRG, string SPRG, string PROY, string ACT, string OBR, int idDetalleAccion, decimal pasajes, decimal kilometraje, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = QueryParaCambioEstados(idEncabezado, 0, usuario, observaciones, PRG, SPRG, PROY, ACT, OBR, idDetalleAccion, 0, 0, pasajes,0, kilometraje, "8", ip, mac, pc);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable RechazoFinanciera(int idPedido, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = QueryParaCambioEstados(idPedido, 0, usuario, observaciones, "", "", "", "", "", 0, 0, 0, 0, 0 ,0, "9", ip, mac, pc);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable Liquidar(int idEncabezado, string observaciones, string usuario, decimal costoReal, decimal pasaje_Planificado, decimal pasajes, decimal kilometraje_plan, decimal kilometraje, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = QueryParaCambioEstados(idEncabezado, 0, usuario, observaciones, "", "", "", "", "", 0, costoReal, pasaje_Planificado, pasajes, kilometraje_plan, kilometraje, "10", ip, mac, pc);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable RechazoMesaEntrada(int idPedido, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = QueryParaCambioEstados(idPedido, 0, usuario, observaciones, "", "", "", "", "", 0, 0, 0, 0,0 ,0, "11", ip, mac, pc);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable Anular(int idPedido, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = QueryParaCambioEstados(idPedido, 0, usuario, observaciones, "", "", "", "", "", 0, 0, 0, 0, 0,0, "12", ip, mac, pc);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable EliminarEncabezado(int id, string ip, string mac, string pc)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = "CALL sp_iue_pedido(" + id + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '', 0, 0, 0, 0, 0, 0, 0, '', 2,'" + ip + "','" + mac + "','" + pc + "');";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable EliminarDetalle(int idDetalle, int idEncabezado, string criterio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = "CALL sp_iue_viaticos_detalles(" + idDetalle + ", " + idEncabezado + ", 0, null, 0, 0, 0, 0, 0, 0, '" + criterio + "', '', 2);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable CodificarSalida(int idDetalleSalida, int idTipoSalida, int idDetalleAccion, int programa, int subprograma, int actividad, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_codificarSalida({0}, {1}, {2}, {3}, {4}, {5}, {6});", idDetalleSalida, idTipoSalida, idDetalleAccion, programa, subprograma, actividad, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionViatico(int id, int id2, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctViaticos({0}, {1}, '', {2});", id, id2, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable PptoAprobacionSubgerente(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPptoAprobarPedido({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable PptoCodificarSalida(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPptoCodificarPedido({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
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
    }
}

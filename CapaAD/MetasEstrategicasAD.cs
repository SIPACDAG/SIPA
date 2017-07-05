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
    public class MetasEstrategicasAD
    {
        ConexionBD conectar;

       public DataTable DdlAnios()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("SELECT anio as texto, anio as id FROM ccl_anios; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlObjEstrategicos(string anio)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL slctObjEstrategicosxAnio({0});", anio);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable CblUnidades()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL slctNombreUnidad;");
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable GridBusqueda()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("CALL slctMetasdEstrategicasGB;", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataSet Insertar(MetasEstrategicasEN ObjEN)
       {
           MySqlTransaction transaccion;
           MySqlDataAdapter consulta;
           conectar = new ConexionBD();

           DataTable dtEncabezado = new DataTable("ENCABEZADO");
           DataTable dtDetalle = new DataTable("DETALLE");
           dtDetalle.Columns.Add("RESULTADO", typeof(string));
           dtDetalle.Columns.Add("MENSAJE", typeof(string));

           conectar.AbrirConexion();
           transaccion = conectar.conectar.BeginTransaction();
           try
           {               

               /*string query = string.Format("CALL insertar_meta_estrategica({0}, {1}, '{2}', '{3}', '{4}', {5});", ObjEN.Id_Objetivo_Estrategico, ObjEN.Anio, ObjEN.Nombre, ObjEN.Kpi, ObjEN.Formula, ObjEN.Codigo_Meta_Estrategica);
               consulta = new MySqlDataAdapter(query, conectar.conectar);
               consulta.Fill(dtEncabezado);*/

               if (dtEncabezado.Rows.Count > 0 && bool.Parse(dtEncabezado.Rows[0]["RESULTADO"].ToString()))
               {
                   /*int i = 0;
                   foreach (DataRow dr in ObjEN.Unidades.Rows)
                   {
                       string idMeta = dtEncabezado.Rows[0]["MENSAJE"].ToString();
                       string idUnidad = dr["ID_UNIDAD"].ToString();
                       DataTable dt = new DataTable();

                       query = string.Format("CALL insertar_meta_estr_unidad({0}, {1});", idMeta, idUnidad);
                       consulta = new MySqlDataAdapter(query, conectar.conectar);
                       consulta.Fill(dt);

                       DataRow drDet = dtDetalle.NewRow();
                       drDet["RESULTADO"] = dt.Rows[0]["RESULTADO"].ToString();
                       drDet["MENSAJE"] = dt.Rows[0]["MENSAJE"].ToString();
                       dtDetalle.Rows.Add(drDet);                       
                   }*/
               }
               transaccion.Commit();
               conectar.CerrarConexion();

               DataSet ds = new DataSet();
               //ds.Tables.Add(dtEncabezado);
               //ds.Tables.Add(dtDetalle);
               return ds;
           }
           catch (Exception ex)
           {
               transaccion.Rollback();
               throw new Exception(ex.Message);
           }
       }

       public DataTable Existe(MetasEstrategicasEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           /*conectar.AbrirConexion();
           string s = string.Format("CALL ExisteMetaEstrategica({0},{1} ,{2} );", ObjEN.Anio, ObjEN.Id_Objetivo_Estrategico, ObjEN.Codigo_Meta_Estrategica);
           MySqlDataAdapter consulta = new MySqlDataAdapter(s, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();*/
           return tabla;
       }

       public DataSet BuscarId(string id)
       {
           MySqlDataAdapter consulta;
           conectar = new ConexionBD();
           
           DataTable dtEncabezado = new DataTable();
           DataTable dtDetalles = new DataTable("UNIDADES");

           string query = String.Format("CALL slctMetasEstrategicasM({0});", id);
           conectar.AbrirConexion();
           consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(dtEncabezado);

           query = String.Format("CALL slctMetaEstrUnidad({0});", id);
           consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(dtDetalles);

           conectar.CerrarConexion();
           
           DataSet ds = new DataSet();
           ds.Tables.Add(dtEncabezado);
           ds.Tables.Add(dtDetalles);
           
           return ds;
       }

       public DataSet Actualizar(MetasEstrategicasEN ObjEN)
       {

           MySqlTransaction transaccion;
           MySqlDataAdapter consulta;
           conectar = new ConexionBD();

           DataTable dtEncabezado = new DataTable("ENCABEZADO");
           DataTable dtDetalle = new DataTable("DETALLE");
           dtDetalle.Columns.Add("RESULTADO", typeof(string));
           dtDetalle.Columns.Add("MENSAJE", typeof(string));

           conectar.AbrirConexion();
           transaccion = conectar.conectar.BeginTransaction();
           try
           {

              /* string query = string.Format("CALL actualizar_meta_estrategica({0}, {1}, '{2}', '{3}', '{4}', '{5}', {6});", ObjEN.Id_Meta, ObjEN.Id_Objetivo_Estrategico, ObjEN.Anio, ObjEN.Nombre, ObjEN.Kpi, ObjEN.Formula, ObjEN.Codigo_Meta_Estrategica);
               consulta = new MySqlDataAdapter(query, conectar.conectar);
               consulta.Fill(dtEncabezado);

               if (!bool.Parse(dtEncabezado.Rows[0]["RESULTADO"].ToString()))
                   throw new Exception(dtEncabezado.Rows[0]["MENSAJE"].ToString());

               if (dtEncabezado.Rows.Count > 0 && bool.Parse(dtEncabezado.Rows[0]["RESULTADO"].ToString()))
               {
                   foreach (DataRow dr in ObjEN.Unidades.Rows)
                   {
                       string idMeta = ObjEN.Id_Meta.ToString();
                       string idUnidad = dr["ID_UNIDAD"].ToString();
                       DataTable dt = new DataTable();

                       bool vSeleccionado = bool.Parse(dr["SELECCIONADO"].ToString());

                       if(vSeleccionado)
                           query = string.Format("CALL insertar_meta_estr_unidad({0}, {1});", idMeta, idUnidad);
                       else
                           query = string.Format("CALL eliminar_meta_estr_unidad({0}, {1});", idMeta, idUnidad);

                       consulta = new MySqlDataAdapter(query, conectar.conectar);
                       consulta.Fill(dt);

                       if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                           throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                       DataRow drDet = dtDetalle.NewRow();
                       drDet["RESULTADO"] = dt.Rows[0]["RESULTADO"].ToString();
                       drDet["MENSAJE"] = dt.Rows[0]["MENSAJE"].ToString();
                       dtDetalle.Rows.Add(drDet);
                   }
               }
               transaccion.Commit();
               conectar.CerrarConexion();*/

               DataSet ds = new DataSet();
               ds.Tables.Add(dtEncabezado);
               ds.Tables.Add(dtDetalle);
               return ds;
           }
           catch (Exception ex)
           {
               transaccion.Rollback();
               throw new Exception(ex.Message);
           }
       }

       public DataTable Eliminar(MetasEstrategicasEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL eliminar_meta_estrategica({0});", ObjEN.Id_Meta);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InsertarUnidad(string idMeta, string idUnidad)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("CALL insertar_meta_estr_unidad({0}, {1});", idMeta, idUnidad);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable EliminarUnidad(string idMeta, string idUnidad)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = string.Format("CALL eliminar_meta_estr_unidad({0}, {1});", idMeta, idUnidad);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
    }
}

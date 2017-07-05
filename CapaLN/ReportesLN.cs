using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using CapaEN;
using System.Web.UI.WebControls;
using System.Web;
using System.Data;

namespace CapaLN
{
    public class ReportesLN
    {
        ReportesAD reportesAD;

        public DataSet ReportesSipa(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            reportesAD = new ReportesAD();

            try
            {
                DataTable dt = reportesAD.ReportesSipa(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.ReportesSipa(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet armarDsResultado()
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

        /// <summary>
        /// ////////////////////////
        /// </summary>
        /// <param name="idUnidad"></param>
        /// <param name="idPoa"></param>
        /// <returns></returns>
        
        public DataTable CargarReporte(Int32 idUnidad, int idPoa){
            reportesAD = new ReportesAD();
           
            //'despues de iniciar el modelo de datos, llamamos el metodo para crear el reporte y guardarlo en el dataSet
            return reportesAD.ConsultaProcedimiento(idUnidad, idPoa);
    
        }

        public int idPoa(string usuario,int anio)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();
            int idUnidad = 0;

            idUnidad= Convert.ToInt32(reportesAD.unidadUsuario(usuario).Rows[0]["id"]);

            return Convert.ToInt32(reportesAD.poaUsuario(anio, idUnidad).Rows[0]["idPoa"]);
        }
             
        public DataTable fadnsSaldos(int opcion,int anio)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();
            if (opcion == 1)
            { dt= reportesAD.fadnsSaldosGeneral(anio); }
            if (opcion == 2)
            { dt= reportesAD.fadnsSaldoRetencion(anio); }

            return dt;
        }
        public DataTable SaldoReglones(int opcion,int par)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();

            dt = reportesAD.SaldoReglones(opcion,par); 
            return dt;
        }
        public DataTable SaldoReglonesUnidad(string letra, int anio)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();

            dt = reportesAD.SaldoReglonesUnidad(letra, anio);
            return dt;
        }
        public DataTable SaldoResumenes(int opcion, int par)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();

            dt = reportesAD.SaldoResumenes(opcion, par);
            return dt;
        }
        public DataTable SaldoProveedores(int opcion, int par)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();

            dt = reportesAD.SaldoProveedores(opcion, par);
            return dt;
        }
        public DataTable HistorialMovimiento(int opcion,string parametro,int anio)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();
            int par = 0;
            if (parametro.Length == 0)
            { par = 0; }
            else
            { par = Convert.ToInt32(parametro); }
            
            dt = reportesAD.HistorialMovimiento(opcion,par,anio);
            return dt;
        }    
        
    }
}

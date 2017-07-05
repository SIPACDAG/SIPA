using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using CapaLN;
using System.Data;
namespace Reporte
{
    public partial class frmReporte : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
         
            string noReporte = Convert.ToString(Request.QueryString["Nor"]);

            if (noReporte != null)
            {
                string id = Convert.ToString(Request.QueryString["No"]);

                DS_REPORTE DS_REPORTE = new DS_REPORTE();
                DataTable dt = new DataTable();

                if (noReporte.Equals("1"))
                {
                    GridView gridPlan = new GridView();
                    PlanAccionLN pAccionLN = new PlanAccionLN();
                    pAccionLN.GridPlan(gridPlan, 0, int.Parse(id));

                    object obj = gridPlan.DataSource;

                    //DS_REPORTE.Tables[0] = gridPlan.DataSource as System.Data.DataTable;
                    dt = gridPlan.DataSource as System.Data.DataTable;
                }

                /*DataTable dt = new DataTable();
                GridView gridPlan = new GridView();
                PlanAccionLN pAccionLN = new PlanAccionLN();
                pAccionLN.GridPlan(gridPlan, 0, int.Parse(id));

                dt = gridPlan.DataSource as System.Data.DataTable;
                ReportDataSource RD = new ReportDataSource();
                RD.Value = dt;
                RD.Name = "DataSet1";

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(RD);
                ReportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc";
                ReportViewer1.LocalReport.ReportPath = @"Report1.rdlc";
                ReportViewer1.LocalReport.Refresh();
                */
                
            }
        }

        protected void mostrarReporte()
        {
            /*String CADENA_CONEXION = "server=localhost; database =dbcdagsipa;user=usr_cdag_sipa; password ='5sr_cd1g_s3pa'";
            String consulta = "CALL sp_slctPlanAccionGB(29,9)";
            MySqlConnection MYSQL_CON = new MySqlConnection(CADENA_CONEXION);
            MYSQL_CON.Open();
            MySqlDataAdapter MYSQL_ADP = new MySqlDataAdapter(consulta, MYSQL_CON);
            DS_REPORTE DS_REPORTE = new DS_REPORTE();
            MYSQL_ADP.Fill(DS_REPORTE.Tables[0]);
            MYSQL_CON.Close();

            ReportDataSource RD = new ReportDataSource();
            RD.Value = DS_REPORTE.Tables[0];
            RD.Name = "DataSet1";

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(RD);
            ReportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc";
            ReportViewer1.LocalReport.ReportPath = @"Report1.rdlc";
            ReportViewer1.LocalReport.Refresh();*/
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            mostrarReporte();
        }
        
    }
}
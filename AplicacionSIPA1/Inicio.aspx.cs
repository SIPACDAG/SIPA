using CapaAD;
using CapaLN;
using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1
{
    public partial class Inicio : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private ReportesAD pReportesAD;
        public string thisConnectionString = ConfigurationManager.ConnectionStrings["dbcdagsipaConnectionString1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pEstrategicoLN.DdlAniosPlan(ddlAnios, 2016, 2020);
                ddlAnios.Items.RemoveAt(0);
                string usuario = Session["Usuario"].ToString().ToLower();
                pOperativoLN.DdlUnidades(ddlUnidades, usuario);
                if (ddlUnidades.Items.Count<1)
                {
                    ddlUnidades_SelectedIndexChanged(sender, e);
                }
                else
                {
                    pReportesAD = new ReportesAD();
                    MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
                    System.Data.DataSet thisDataSet = new System.Data.DataSet();
                    System.Data.DataSet thisDataSet2 = new System.Data.DataSet();
                    System.Data.DataSet thisDataSet3 = new System.Data.DataSet();
                    System.Data.DataSet thisDataSet4 = new System.Data.DataSet();
                    System.Data.DataSet thisDataSet5 = new System.Data.DataSet();
                    System.Data.DataSet thisDataSet6 = new System.Data.DataSet();
                    string[] consutlas = pReportesAD.DashboardConsulta( ddlAnios.SelectedValue);
                    /* Put the stored procedure result into a dataset */
                    thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, consutlas[0]);
                    thisDataSet2 = MySqlHelper.ExecuteDataset(thisConnection, consutlas[1]);
                    thisDataSet3 = MySqlHelper.ExecuteDataset(thisConnection, consutlas[2]);
                    thisDataSet4 = MySqlHelper.ExecuteDataset(thisConnection, consutlas[3]);
                    thisDataSet5 = MySqlHelper.ExecuteDataset(thisConnection, consutlas[4]);
                    thisDataSet6 = MySqlHelper.ExecuteDataset(thisConnection, consutlas[5]);
                    ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
                    ReportDataSource datasource1 = new ReportDataSource("DataSet2", thisDataSet2.Tables[0]);
                    ReportDataSource datasource2 = new ReportDataSource("DataSet3", thisDataSet3.Tables[0]);
                    ReportDataSource datasource3 = new ReportDataSource("DataSet4", thisDataSet4.Tables[0]);
                    ReportDataSource datasource4 = new ReportDataSource("DataSet5", thisDataSet5.Tables[0]);
                    ReportDataSource datasource5 = new ReportDataSource("DataSet6", thisDataSet6.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    ReportViewer1.LocalReport.DataSources.Add(datasource1);
                    ReportViewer1.LocalReport.DataSources.Add(datasource2);
                    ReportViewer1.LocalReport.DataSources.Add(datasource3);
                    ReportViewer1.LocalReport.DataSources.Add(datasource4);
                    ReportViewer1.LocalReport.DataSources.Add(datasource5);
                    if (thisDataSet.Tables[0].Rows.Count == 0)
                    {

                    }

                    ReportViewer1.LocalReport.Refresh();
                }
                
            }
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            pReportesAD = new ReportesAD();
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();
            System.Data.DataSet thisDataSet2 = new System.Data.DataSet();
            System.Data.DataSet thisDataSet3 = new System.Data.DataSet();
            System.Data.DataSet thisDataSet4 = new System.Data.DataSet();
            System.Data.DataSet thisDataSet5 = new System.Data.DataSet();
            System.Data.DataSet thisDataSet6 = new System.Data.DataSet();
            string[] consutlas = pReportesAD.DashboardConsulta(ddlUnidades.SelectedValue, ddlAnios.SelectedValue);
            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, consutlas[0] );
            thisDataSet2 = MySqlHelper.ExecuteDataset(thisConnection, consutlas[1]);
            thisDataSet3 = MySqlHelper.ExecuteDataset(thisConnection, consutlas[2]);
            thisDataSet4 = MySqlHelper.ExecuteDataset(thisConnection, consutlas[3]);
            thisDataSet5 = MySqlHelper.ExecuteDataset(thisConnection, consutlas[4]);
            thisDataSet6 = MySqlHelper.ExecuteDataset(thisConnection, consutlas[5]);
            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", thisDataSet2.Tables[0]);
            ReportDataSource datasource2 = new ReportDataSource("DataSet3", thisDataSet3.Tables[0]);
            ReportDataSource datasource3 = new ReportDataSource("DataSet4", thisDataSet4.Tables[0]);
            ReportDataSource datasource4 = new ReportDataSource("DataSet5", thisDataSet5.Tables[0]);
            ReportDataSource datasource5 = new ReportDataSource("DataSet6", thisDataSet6.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportViewer1.LocalReport.DataSources.Add(datasource3);
            ReportViewer1.LocalReport.DataSources.Add(datasource4);
            ReportViewer1.LocalReport.DataSources.Add(datasource5);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using CapaLN;
using ExportToExcel;

namespace AplicacionSIPA1.Reporteria
{
    public partial class HistorialMovimiento : System.Web.UI.Page
    {
        ReportesLN reportesLN;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                llenarAnio(dropAnio);
                reportesLN = new ReportesLN();
                DataTable dt = new DataTable();
                dt = reportesLN.HistorialMovimiento(Convert.ToInt32(rblOpcion.SelectedValue), txtNoDocumento.Text, Convert.ToInt32(dropAnio.SelectedItem.Text));
                gridReportes.DataSource = dt;
                gridReportes.DataBind();
                
            }

        }
             private void llenarAnio(DropDownList drop)
        {
            DateTime hoy;
            int anio, i;
            hoy = DateTime.Now;
            anio = hoy.Year + 1;
            i = 0;
            for (int index = 0; index <= anio - 2016; index++)
            {
                drop.Items.Insert(index, Convert.ToString(anio - index));
                i += 1;
            }
            drop.SelectedIndex = 1 ;
            
        }

        protected void dropAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();
            dt = reportesLN.HistorialMovimiento(Convert.ToInt32(rblOpcion.SelectedValue), txtNoDocumento.Text, Convert.ToInt32(dropAnio.SelectedItem.Text));
            gridReportes.DataSource = dt;
            gridReportes.DataBind();
        }

        protected void gridReportes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gridReportes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lbExportar_Click(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();
            dt = reportesLN.HistorialMovimiento(Convert.ToInt32(rblOpcion.SelectedValue), txtNoDocumento.Text, Convert.ToInt32(dropAnio.SelectedItem.Text));
            string fecha = DateTime.Today.ToShortDateString();
            CreateExcelFile.CreateExcelDocument(dt, "Revisiones_" + fecha + ".xlsx", Response);
        }

        protected void rblOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();
            dt = reportesLN.HistorialMovimiento(Convert.ToInt32(rblOpcion.SelectedValue), txtNoDocumento.Text, Convert.ToInt32(dropAnio.SelectedItem.Text));
            gridReportes.DataSource = dt;
            gridReportes.DataBind();
                
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();
            dt = reportesLN.HistorialMovimiento(Convert.ToInt32(rblOpcion.SelectedValue), txtNoDocumento.Text, Convert.ToInt32(dropAnio.SelectedItem.Text));
            gridReportes.DataSource = dt;
            gridReportes.DataBind();
                
        }
    }
}
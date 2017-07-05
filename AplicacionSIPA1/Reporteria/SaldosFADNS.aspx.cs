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
    public partial class SaldosFADNS : System.Web.UI.Page
    {
        double total = 0, total2 = 0, total3 = 0;
        ReportesLN reportesLN;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                llenarAnio(dropAnio);
                reportesLN = new ReportesLN();
                DataTable dt = new DataTable();
                dt = reportesLN.fadnsSaldos(1, Convert.ToInt32(dropAnio.SelectedItem.Text));
                gridReportes.DataSource = dt;
                gridReportes.DataBind();
                
            }

        }

        protected void rblOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();
            dt = reportesLN.fadnsSaldos(Convert.ToInt16(rblOpcion.SelectedValue), Convert.ToInt32(dropAnio.SelectedItem.Text));
            gridReportes.DataSource = dt;
            gridReportes.DataBind();

        }

        protected void lbExportar_Click(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();
            dt = reportesLN.fadnsSaldos(Convert.ToInt16(rblOpcion.SelectedValue), Convert.ToInt32(dropAnio.SelectedItem.Text));
            string fecha = DateTime.Today.ToShortDateString();
            CreateExcelFile.CreateExcelDocument(dt,"SaldoFADN_"+  rblOpcion.SelectedItem.Text + fecha + ".xlsx", Response);
        }

        protected void gridReportes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Convert.ToInt16(rblOpcion.SelectedValue) == 1 )
            {
                
                    double suma = 0;
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        suma = (Convert.ToDouble(e.Row.Cells[2].Text));
                        e.Row.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma);
                        total += suma;
                        suma = 0;
                    }
                    else if (e.Row.RowType == DataControlRowType.Footer)
                    {
                        e.Row.Cells[0].Text = "Total";
                        e.Row.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total);
                    }                 
            }

            if (Convert.ToInt16(rblOpcion.SelectedValue) == 2)
            {

                double suma = 0, suma2 = 0, suma3 = 0;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    suma = (Convert.ToDouble(e.Row.Cells[2].Text));
                    e.Row.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma);
                    total += suma;
                    suma = 0;

                    suma2 = (Convert.ToDouble(e.Row.Cells[3].Text));
                    e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma2);
                    total2 += suma2;
                    suma2 = 0;

                    suma3 = (Convert.ToDouble(e.Row.Cells[4].Text));
                    e.Row.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma3);
                    total3 += suma3;
                    suma3 = 0;
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Total";
                    e.Row.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total);
                    e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total2);
                    e.Row.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total3);
                }
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
            dt = reportesLN.fadnsSaldos(Convert.ToInt16(rblOpcion.SelectedValue), Convert.ToInt32(dropAnio.SelectedItem.Text));
            gridReportes.DataSource = dt;
            gridReportes.DataBind();
        }
        
    }
}
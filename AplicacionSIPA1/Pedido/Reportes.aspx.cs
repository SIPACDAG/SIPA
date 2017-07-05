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
namespace AplicacionSIPA1.Pedido
{
    public partial class Reportes : System.Web.UI.Page
    {
        ReportesLN reportesLN;
        double total = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                
            llenarAnio(dropAnio);   
            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();
            
            dt = reportesLN.SaldoReglones(Convert.ToInt32(rblOpcion.SelectedValue), reportesLN.idPoa(((Label)Master.FindControl("lblUsuario")).Text,Convert.ToInt32(dropAnio.SelectedItem.Text)));
            gridReportes.DataSource = dt;
            gridReportes.DataBind();

            }

        }

        protected void dropAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();

            dt = reportesLN.SaldoReglones(Convert.ToInt32(rblOpcion.SelectedValue), reportesLN.idPoa(((Label)Master.FindControl("lblUsuario")).Text, Convert.ToInt32(dropAnio.SelectedItem.Text)));
            gridReportes.DataSource = dt;
            gridReportes.DataBind();
            
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
            drop.SelectedIndex = 1;
        }

        protected void rblOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();
            
            dt = reportesLN.SaldoReglones(Convert.ToInt32(rblOpcion.SelectedValue), reportesLN.idPoa(((Label)Master.FindControl("lblUsuario")).Text,Convert.ToInt32(dropAnio.SelectedItem.Text)));
            gridReportes.DataSource = dt;
            gridReportes.DataBind();
            
        }

        protected void gridReportes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double suma = 0, suma2 = 0, suma3 = 0, suma4 = 0, suma5 = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                suma = (Convert.ToDouble(e.Row.Cells[3].Text));
                e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma);
                total += suma;
                suma = 0;

                suma2 = (Convert.ToDouble(e.Row.Cells[4].Text));
                e.Row.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma2);
                total2 += suma2;
                suma2 = 0;

                suma3 = (Convert.ToDouble(e.Row.Cells[5].Text));
                e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma3);
                total3 += suma3;
                suma3 = 0;

                suma4 = (Convert.ToDouble(e.Row.Cells[6].Text));
                e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma4);
                total4 += suma4;
                suma4 = 0;

                suma5 = (Convert.ToDouble(e.Row.Cells[7].Text));
                e.Row.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma5);
                total5 += suma5;
                suma5 = 0;

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total);
                e.Row.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total2);
                e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total3);
                e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total4);
                e.Row.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total5);
            }

        }

        protected void lbExportar_Click(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();

            dt = reportesLN.SaldoReglones(Convert.ToInt32(rblOpcion.SelectedValue), reportesLN.idPoa(((Label)Master.FindControl("lblUsuario")).Text, Convert.ToInt32(dropAnio.SelectedItem.Text)));
            gridReportes.DataSource = dt;
            gridReportes.DataBind();
            

            string fecha = DateTime.Today.ToShortDateString();
            CreateExcelFile.CreateExcelDocument(dt, rblOpcion.SelectedItem.Text + fecha + ".xlsx", Response);
        }
    }
}
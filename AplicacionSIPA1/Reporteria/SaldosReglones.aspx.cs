using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using CapaLN;
using CapaEN;
using ExportToExcel;

namespace AplicacionSIPA1.Reporteria
{
    public partial class SaldosReglones : System.Web.UI.Page
    {
        double total = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0;
        double[] totalpv = new double[25];
        ReportesLN reportesLN;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                PoaLN poaLN = new PoaLN();
                PoaEN poaEN = new PoaEN();
                DateTime hoy;
                int anio;
                hoy = DateTime.Now;
                anio = hoy.Year;
                llenarAnio(dropAnio);

                poaEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                poaEN.anio = Convert.ToInt32(dropAnio.SelectedItem.Text);
                poaLN.dropPoas(dropUnidades, poaEN);



                reportesLN = new ReportesLN();
                DataTable dt = new DataTable();
                int opcion = 0, par = 0;
                if (Convert.ToInt32(dropUnidades.SelectedValue) > 0)
                {
                    opcion = 1;
                    par = Convert.ToInt32(dropUnidades.SelectedValue);
                }
                else
                {
                    opcion = 2;
                    par = Convert.ToInt32(dropAnio.SelectedItem.Text);
                }
                 dt = reportesLN.SaldoReglones(opcion, par);
                 gridReportes.DataSource = dt;
                 gridReportes.DataBind();
                

            }

        }


        protected void gridReportes_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void dropUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();
            int opcion = 0,par=0;
            if (Convert.ToInt32(dropUnidades.SelectedValue) > 0)
            { opcion = 1;
            par = Convert.ToInt32(dropUnidades.SelectedValue);
            }
            else
            { opcion = 2;
            par = Convert.ToInt32(dropAnio.SelectedItem.Text);
            }
            dt = reportesLN.SaldoReglones(opcion, par);
            gridReportes.DataSource = dt;
            gridReportes.DataBind();
            rblOpcion.SelectedValue = "0";
            
        }

        protected void dropAnio_SelectedIndexChanged(object sender, EventArgs e)
        {

            PoaLN poaLN = new PoaLN();
            PoaEN poaEN = new PoaEN();

            poaEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
            poaEN.anio = Convert.ToInt32(dropAnio.SelectedItem.Text);

            poaLN.dropPoas(dropUnidades, poaEN);

            reportesLN = new ReportesLN();
            DataTable dt = new DataTable();
            int opcion = 0, par = 0;
            if (Convert.ToInt32(dropUnidades.SelectedValue) > 0)
            {
                opcion = 1;
                par = Convert.ToInt32(dropUnidades.SelectedValue);
            }
            else
            {
                opcion = 2;
                par = Convert.ToInt32(dropAnio.SelectedItem.Text);
            }
            dt = reportesLN.SaldoReglones(opcion, par);
            gridReportes.DataSource = dt;
            gridReportes.DataBind();
            rblOpcion.SelectedValue = "0";
        }

        protected void gridReportes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (rblOpcion.SelectedValue == "0")
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
            else {
                

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    for (int c = 3; c <= gridReportes.HeaderRow.Cells.Count - 1; c++)
                    {
                        double[] sumapv = new double[gridReportes.HeaderRow.Cells.Count];

                        if (e.Row.Cells[c].Text == "&nbsp;")
                        { sumapv[c] = 0; }
                        else
                        { sumapv[c] = (Convert.ToDouble(e.Row.Cells[c].Text));
                        e.Row.Cells[c].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumapv[c]);
                        }

                        
                        totalpv[c] += sumapv[c];
                        sumapv[c] = 0;
                        
                        
                    }
              
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[1].Text = "Total";
                    for (int c = 3; c <= gridReportes.HeaderRow.Cells.Count - 1; c++)
                    {
                        e.Row.Cells[c].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00|}", totalpv[c]);
                        
                    }

                }
            }
            
            
        }

        protected void lbExportar_Click(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            if (rblOpcion.SelectedValue == "0")
            {
                DataTable dt = new DataTable();
                int opcion, anio = 0;
                anio = Convert.ToInt32(dropAnio.SelectedItem.Text);
                if (Convert.ToInt32(dropUnidades.SelectedValue) > 0)
                { opcion = 1; }
                else
                { opcion = 2; }
                dt = reportesLN.SaldoReglones(opcion, anio);
                string fecha = DateTime.Today.ToShortDateString();
                CreateExcelFile.CreateExcelDocument(dt, "SaldoReglones" + fecha + ".xlsx", Response);
            }
            else 
            {

                DataTable dt = new DataTable();

                dt = reportesLN.SaldoReglonesUnidad(rblOpcion.SelectedValue, Convert.ToInt32(dropAnio.SelectedItem.Text));
                string fecha = DateTime.Today.ToShortDateString();
                CreateExcelFile.CreateExcelDocument(dt, "SaldoReglonesUnidad" + fecha + ".xlsx", Response);
            
            }
        }

        protected void rblOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportesLN = new ReportesLN();
            if (rblOpcion.SelectedValue == "0"){
                DataTable dt = new DataTable();
                int opcion = 0, par = 0;
                if (Convert.ToInt32(dropUnidades.SelectedValue) > 0)
                {
                    opcion = 1;
                    par = Convert.ToInt32(dropUnidades.SelectedValue);
                }
                else
                {
                    opcion = 2;
                    par = Convert.ToInt32(dropAnio.SelectedItem.Text);
                }
                dt = reportesLN.SaldoReglones(opcion, par);
                gridReportes.DataSource = dt;
                gridReportes.DataBind();
                
            }
            else{
                dropUnidades.SelectedValue = "0";
                DataTable dt = new DataTable();
                dt = reportesLN.SaldoReglonesUnidad(rblOpcion.SelectedValue, Convert.ToInt32(dropAnio.SelectedItem.Text));
                gridReportes.DataSource = dt;
                gridReportes.DataBind();
            }
        }
        //private void moneda()
        //{   
                    
        //    for (int c=3;c <= gridReportes.HeaderRow.Cells.Count-1; c++)
        //        {
        //        for (int f=0;f <= gridReportes.Rows.Count-1; f++)
        //        {
                    
        //        if (gridReportes.Rows[f].Cells[c].Text == "&nbsp;")
        //        { gridReportes.Rows[f].Cells[c].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0); }
        //        else
        //        { gridReportes.Rows[f].Cells[c].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", gridReportes.Rows[f].Cells[c].Text); }

                
        //        }

                
        //    }
        
        //}

       

    }
}
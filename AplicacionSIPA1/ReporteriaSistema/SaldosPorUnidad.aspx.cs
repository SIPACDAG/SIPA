using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.ReporteriaSistema
{
    public partial class SaldosPorUnidad : System.Web.UI.Page
    {
        private ReportesLN reportesln;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reportesln = new ReportesLN();
                DataSet dtResultado = new DataSet();
                dtResultado = reportesln.SaldoXUnidad(2017);
                gridReportes.DataSource = dtResultado;
                gridReportes.DataBind();
                if (gridReportes.Rows.Count > 0)
                {
                    decimal monto, codificado, saldo;
                    decimal.TryParse(dtResultado.Tables["TABLE"].Compute("SUM(MONTOPOA)", "").ToString(), out monto);
                    decimal.TryParse(dtResultado.Tables["TABLE"].Compute("SUM(CODIFICADO)", "").ToString(), out codificado);
                    decimal.TryParse(dtResultado.Tables["TABLE"].Compute("SUM(SALDO)", "").ToString(), out saldo);

                    gridReportes.FooterRow.Cells[0].Text = "TOTALES";
                    gridReportes.FooterRow.Cells[1].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", monto);
                    gridReportes.FooterRow.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", codificado);
                    gridReportes.FooterRow.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);

                    gridReportes.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gridReportes.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    gridReportes.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                }
            }
        }

        protected void gridReportes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;

                    decimal valor = decimal.Parse(e.Row.Cells[1].Text);
                    e.Row.Cells[1].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);

                    valor = decimal.Parse(e.Row.Cells[2].Text);
                    e.Row.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);

                    valor = decimal.Parse(e.Row.Cells[3].Text);
                    e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);
                }
            }
            catch (Exception ex)
            {
              
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using CapaLN;
using CapaEN;


namespace AplicacionSIPA1.Pedido
{
    public partial class SaldosPedido : System.Web.UI.Page
    {

        PoaLN poaLN;
        PoaEN poaEN;
        double totalB = 0, total = 0, total2 = 0, total3 = 0;
        double totalPoa = 0, codificadoPoa = 0, saldoPoa = 0;
        public int idop
        {
            get
            {
                int id = 0;
                if (Convert.ToInt32(dropAccion.SelectedValue) > 0)
                {
                    id = 2;
                }
                else
                {
                    id = 1;
                }
                return id;
            }
        }
        public int idP
        {
            get
            {
                int id = 0;
                if (Convert.ToInt32(dropAccion.SelectedValue) > 0)
                {
                    id = Convert.ToInt32(dropAccion.SelectedValue);
                }
                else
                {
                    id = Convert.ToInt32(gridPoa.SelectedValue);
                }
                return id;
            }
        }
         protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                poaLN = new PoaLN();
                poaEN = new PoaEN();
                DateTime hoy;
                int anio;
                hoy = DateTime.Now;
                anio = hoy.Year;
                poaEN.anio = anio;
                poaEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;       
                poaLN.gridPoas(gridPoa, poaEN,2);
                poaEN.idPoa = Convert.ToInt32(gridPoa.SelectedValue);
                poaLN.gridAccionesPoa(gridAccion, poaEN);
                poaEN.idPoa = Convert.ToInt32(gridPoa.SelectedValue);
                poaLN.dropAccionesPoa(dropAccion, poaEN);
                //poaLN.gridDetalleAccion(gridRenglon,poaEN);

            }

        }



         protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
         {
             double suma = 0, suma2 = 0, suma3 = 0;
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 suma = (Convert.ToDouble(e.Row.Cells[4].Text));
                 e.Row.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma);
                 total += suma;
                 suma = 0;

                 suma2 = (Convert.ToDouble(e.Row.Cells[5].Text));
                 e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma2);
                 total2 += suma2;
                 suma2 = 0;

                 suma3 = (Convert.ToDouble(e.Row.Cells[6].Text));
                 e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma3);
                 total3 += suma3;
                 suma3 = 0;



             }
             else if (e.Row.RowType == DataControlRowType.Footer)
             {
                 e.Row.Cells[2].Text = "Total";
                 e.Row.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total);
                 e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total2);
                 e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total3);
                 totalPoa += total;
                 codificadoPoa += total2;
                 saldoPoa += total3;
                 total = 0;
                 total2 = 0;
                 total3 = 0;
             }
         }

         protected void gridBeneficiarios_RowDataBound(object sender, GridViewRowEventArgs e)
         {
             int sumaB = 0;
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 sumaB = (Convert.ToInt32(e.Row.Cells[1].Text));
                 e.Row.Cells[1].Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", sumaB);
                 totalB += sumaB;
                 sumaB = 0;
             }
             else if (e.Row.RowType == DataControlRowType.Footer)
             {
                 e.Row.Cells[0].Text = "Total";
                 e.Row.Cells[1].Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", totalB);
             }
         }


        protected void gridAccion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            poaLN = new PoaLN();
            poaEN = new PoaEN();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int id = Convert.ToInt32(gridAccion.DataKeys[e.Row.RowIndex].Value);

                GridView gridB = (GridView)e.Row.FindControl("gridB");
                GridView grid = (GridView)e.Row.FindControl("grid");
                poaEN.idAccion = id;
                poaLN.gridDatosBeneficiariosAccion(gridB, poaEN);

                poaLN.gridSaldoAccion(grid, poaEN);

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Totales";
                e.Row.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalPoa);
                e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", codificadoPoa);
                e.Row.Cells[4].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldoPoa);
            }
        }

    
        protected void gridPoa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            poaLN = new PoaLN();
            poaEN = new PoaEN();
            DateTime hoy;
            int anio;
            hoy = DateTime.Now;
            anio = hoy.Year;
               
            poaEN.anio = anio;
            gridPoa.PageIndex = e.NewPageIndex;
            poaLN.gridPoas(gridPoa, poaEN,2);
            poaEN.idPoa = Convert.ToInt32(gridPoa.SelectedValue);
            poaLN.gridAccionesPoa(gridAccion, poaEN);

            poaLN.dropAccionesPoa(dropAccion, poaEN);
        }

        
        

        protected void gridPoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridAccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
       

       

        
    }
}
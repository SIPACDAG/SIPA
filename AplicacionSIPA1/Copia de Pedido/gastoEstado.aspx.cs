using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using CapaEN;
using System.Data;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using AplicacionSIPA1.Reportes;

namespace AplicacionSIPA1.Pedido
{
    public partial class gastoEstado : System.Web.UI.Page
    {
        PedidoLN pedidoLN;
        PedidoEN pedidoEN;
        public int NoGasto
        {
            get
            {
                return Convert.ToInt32(gridEstado.SelectedValue);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                pedidoLN = new PedidoLN();
                pedidoEN = new PedidoEN();
                pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                pedidoLN.gridEstadoGasto(gridEstado, pedidoEN);
            }

        }

        protected void gridEstado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            pedidoLN = new PedidoLN();
            pedidoEN = new PedidoEN();
            gridEstado.PageIndex = e.NewPageIndex;
            pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
            pedidoLN.gridEstadoGasto(gridEstado, pedidoEN);

        }

        protected void gridEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnImprimir.Visible = false;
                btnModificar.Visible = false;
                btnGastoaPedido.Visible = false;
                GridViewRow row = gridEstado.SelectedRow;
                if (HttpUtility.HtmlDecode(row.Cells[5].Text) == "Rechazado")
                {
                    btnImprimir.Visible = false;
                    btnGastoaPedido.Visible = false;
                    btnModificar.Visible = true;
                }

                if (HttpUtility.HtmlDecode(row.Cells[5].Text) == "Aprobado")
                {
                    pedidoLN = new PedidoLN();
                    pedidoEN = new PedidoEN();
                    pedidoEN.idGasto = Convert.ToInt32(gridEstado.SelectedValue);

                    DataTable tabla, tabladetalle;
                    tabla = pedidoLN.rptGasto(pedidoEN);
                    pedidoEN.idGasto = Convert.ToInt32(gridEstado.SelectedValue);
                    tabladetalle = pedidoLN.rptGastoDetalle(pedidoEN);

                    DataSet tablas = new DataSet();
                    tablas.Tables.Add(tabla);
                    tablas.Tables[0].TableName = "dtGasto";

                    tablas.Tables.Add(tabladetalle);
                    tablas.Tables[1].TableName = "dtGastoDetalle";

                    if (tabla.Rows.Count > 0)
                    {

                        crDictamenFinan cr = new crDictamenFinan();
                        cr.SetDataSource(tablas);

                        btnImprimir.Attributes.Add("onclick", "javascript:window.open('" + reportePdf("Dictamen", cr) + "','Gasto'," +
                                                      "'directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=750, height=400');");
                        btnImprimir.Visible = true;
                        btnGastoaPedido.Visible = true;
                        btnModificar.Visible = false;

                    }


                }

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                Console.WriteLine(ex.Message);
            }

        }
        private string reportePdf(String nombreReporte, CrystalDecisions.CrystalReports.Engine.ReportDocument modeloRPT)
        {

            String direccion = Server.MapPath("\\COGSIPA/Pedido/ArchivoPDF/");
            direccion += "\\" + "" + nombreReporte + ".pdf";

            CrystalDecisions.Shared.DiskFileDestinationOptions filedest = new CrystalDecisions.Shared.DiskFileDestinationOptions();
            CrystalDecisions.Shared.ExportOptions o;
            o = new CrystalDecisions.Shared.ExportOptions();

            o.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            o.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            filedest.Clone();
            filedest.DiskFileName = direccion;
            filedest.Clone();
            o.ExportDestinationOptions = filedest;
            modeloRPT.Export(o);
            filedest = null;
            o = null;
            String reDireccion = "\\ArchivoPDF/";
            reDireccion += "\\" + "" + nombreReporte + ".pdf";
            return reDireccion;
        }
        //private string reportePdf(String nombreReporte, CrystalDecisions.CrystalReports.Engine.ReportDocument modeloRPT)
        //{

        //    String direccion = Server.MapPath("\\Pedido/ArchivoPDF/");
        //    direccion += "\\" + "" + nombreReporte + ".pdf";

        //    CrystalDecisions.Shared.DiskFileDestinationOptions filedest = new CrystalDecisions.Shared.DiskFileDestinationOptions();
        //    CrystalDecisions.Shared.ExportOptions o;
        //    o = new CrystalDecisions.Shared.ExportOptions();

        //    o.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
        //    o.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
        //    filedest.Clone();
        //    filedest.DiskFileName = direccion;
        //    filedest.Clone();
        //    o.ExportDestinationOptions = filedest;
        //    modeloRPT.Export(o);
        //    filedest = null;
        //    o = null;
        //    String reDireccion = "\\ArchivoPDF/";
        //    reDireccion += "\\" + "" + nombreReporte + ".pdf";
        //    return reDireccion;

        //}

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}

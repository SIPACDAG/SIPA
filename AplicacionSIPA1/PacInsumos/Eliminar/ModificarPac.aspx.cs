using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using AplicacionSIPA1.Reportes;
using CapaLN;
using CapaEN;


namespace AplicacionSIPA1.Pac
{
    public partial class ModificarPac : System.Web.UI.Page
    {
        PacEN pacEN;
        PacLN pacLN;

        public DataSet tblMes
        {
            get
            {
                object o = ViewState["tblMes"];
                return (DataSet)o;
            }
            set { ViewState["tblMes"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                int NoPedido =
                  PreviousPage.NoPac;
                ViewState["idPac"] = NoPedido;
                ViewState["idPacM"] = NoPedido;
                lblPac.Text = Convert.ToString(NoPedido);
                
            }
            else
            {

                ViewState["idPac"] = 0;
            }
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            
            if (IsPostBack == false)
            {

                pacLN = new PacLN();
                pacEN = new PacEN();

                pacEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;

                
                pacLN.dropAccionesPoa(dropAccion, pacEN);
                pacLN.dropExcepcion(dropExcepcion);
                pacLN.dropModalidad(dropModalidad);

                DataTable dtPoa;
                dtPoa = pacLN.datosPoa(pacEN);
                if (dtPoa.Rows.Count > 0)
                {
                    ViewState["idPoa"] = dtPoa.Rows[0]["idPoa"];
                    ViewState["Estado"] = Convert.ToInt16(dtPoa.Rows[0]["idEstado"]);
                    pacEN.idPoa = Convert.ToInt32(ViewState["idPoa"]);
                }
                else
                {
                    ViewState["idPoa"] = 0;
                    ViewState["Estado"] = 0;
                    pacEN.idPoa = 0;

                }

                tblMes = new DataSet();
                tblMes.Tables.Add(new DataTable());
                tblMes.Tables[0].Columns.Add("id", Type.GetType("System.String"));
                tblMes.Tables[0].Columns.Add("Mes", Type.GetType("System.String"));
                tblMes.Tables[0].Columns.Add("Cantidad", Type.GetType("System.String"));
                tblMes.Tables[0].Columns.Add("Monto", Type.GetType("System.String"));

                for (int index = 1; index <= 12; index++)
                {


                    DataRow Agregar = tblMes.Tables[0].NewRow();
                    Agregar["id"] = index;
                    Agregar["Mes"] = nombreMes(index);
                    Agregar["Cantidad"] = string.Empty;
                    Agregar["Monto"] = string.Empty;
                    tblMes.Tables[0].Rows.Add(Agregar);
                }

                gridDetalle.DataSource = tblMes.Tables[0];
                gridDetalle.DataBind();

                pacEN.idPac = Convert.ToInt32(ViewState["idPac"]);
                DataTable dtpac;

                dtpac = pacLN.datosPac(pacEN);
                ViewState["idDAccion"] = Convert.ToString(dtpac.Rows[0]["idDetalleAccion"]);
                dropModalidad.SelectedValue = Convert.ToString( dtpac.Rows[0]["idModalidad"]);
                dropExcepcion.SelectedValue = Convert.ToString(dtpac.Rows[0]["idExcepcion"]);
                txtDescripcion.Text = Convert.ToString(dtpac.Rows[0]["descripcion"]);
                dropAccion.SelectedValue = Convert.ToString(dtpac.Rows[0]["idAccion"]);
              
                pacEN.idDetalleAccion = Convert.ToInt32(ViewState["idDAccion"]);
                pacLN.gridIdDetalleAccion(gridRenglon, pacEN);

                lblMontoPac.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pacLN.montoActualPac(pacEN));
                lblCodificadoPac.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pacLN.codificadoPacPac(pacEN)); 
                lblSaldoPac.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pacLN.saldoPacPac(pacEN)); 
            }
        }
        public string nombreMes(int mes)
        {
            DateTimeFormatInfo conver = new CultureInfo("es-ES", false).DateTimeFormat;
            return conver.GetMonthName(mes);
        }
        
        protected void gridDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            pacEN = new PacEN();
            pacLN = new PacLN();

            DataTable dtPacDetalle;
            pacEN.idPac = Convert.ToInt32(ViewState["idPac"]);

            dtPacDetalle = pacLN.datosPacDetalle(pacEN);
            for (int i = 0; i <= gridDetalle.Rows.Count - 1; i++)
            {
                GridViewRow filaGrid = gridDetalle.Rows[i];

                for (int ii = 0; ii <= dtPacDetalle.Rows.Count - 1; ii++)
                {
                    if (Convert.ToInt16(dtPacDetalle.Rows[ii]["mes"]) == Convert.ToInt16(filaGrid.Cells[0].Text))
                    {
                        ((TextBox)filaGrid.Cells[2].FindControl("txtMonto")).Text = Convert.ToString(dtPacDetalle.Rows[ii]["monto"]);
                        ((TextBox)filaGrid.Cells[3].FindControl("txtCantidad")).Text = Convert.ToString(dtPacDetalle.Rows[ii]["cantidad"]);
                        ((Label)filaGrid.Cells[4].FindControl("lblidPD")).Text = Convert.ToString(dtPacDetalle.Rows[ii]["id"]);
                    }
                }



            }

        }

       
       
        protected void gridDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void mostrarMsg(int op, string msg)
        {
            if (op == 0)
            {
                this.lblSuccess.Visible = true;
                this.lblError.Visible = false;
                this.lblSuccess.ForeColor = System.Drawing.Color.White;
                this.lblSuccess.Text = msg;
            }
            if (op == 1)
            {
                this.lblSuccess.Visible = false;
                this.lblError.Visible = true;
                this.lblError.Text = msg;
            }
            if (op == 2)
            {
                this.lblSuccess.Visible = false;
                this.lblError.Visible = false;
                this.lblError.Text = "";
                this.lblSuccess.Text = "";
            }


        }

       
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

                pacLN = new PacLN();
                pacEN = new PacEN();
                this.Page.Validate("vacios");
             if (this.Page.IsValid)
             {



                 double montoNuevo = 0;
                 for (int i = 0; i <= gridDetalle.Rows.Count - 1; i++)
                 {
                     GridViewRow filaGrid = gridDetalle.Rows[i];
                     string monto = "";
                     monto = Convert.ToString(((TextBox)filaGrid.Cells[2].FindControl("txtMonto")).Text);

                     if (monto.Trim().Length > 0)
                     {
                         montoNuevo += Convert.ToDouble(monto);
                     }
                 }

                 double saldoPac,saldoPacPac = 0;
                 pacEN.idDetalleAccion = Convert.ToInt32(ViewState["idDAccion"]);
                 pacEN.idPac = Convert.ToInt32(ViewState["idPacM"]);
                 saldoPac = pacLN.saldoPac(pacEN) - (montoNuevo - pacLN.montoActualPac(pacEN));
                 saldoPacPac = montoNuevo- pacLN.codificadoPacPac(pacEN);

                 if (saldoPac >= 0 && saldoPacPac>=0)
                 {
                     pacEN.idModalidad = Convert.ToInt16(dropModalidad.SelectedValue);
                     pacEN.idExcepcion = Convert.ToInt16(dropExcepcion.SelectedValue);
                     pacEN.descripcion = txtDescripcion.Text.Trim();
                     pacEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;

                     pacLN.ModificarPac(pacEN);


                     for (int i = 0; i <= gridDetalle.Rows.Count - 1; i++)
                     {
                         GridViewRow filaGrid = gridDetalle.Rows[i];
                         int idpd = 0;
                         idpd = Convert.ToInt32(((Label)filaGrid.Cells[4].FindControl("lblidPD")).Text);
                         if (idpd > 0) // Modifique
                         {

                             string monto = "";
                             monto = Convert.ToString(((TextBox)filaGrid.Cells[2].FindControl("txtMonto")).Text);

                             string cantidad = "";
                             cantidad = Convert.ToString(((TextBox)filaGrid.Cells[3].FindControl("txtCantidad")).Text);

                             pacEN.montomes = Convert.ToDouble(monto);
                             if (cantidad.Trim().Length > 0) { pacEN.cantidad = Convert.ToInt16(cantidad); }
                             else { pacEN.cantidad = 1; }
                             pacEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                             pacEN.idPacDetalle = idpd;
                             pacLN.ModificarPacDetalle(pacEN);

                         }

                         else // Inserte
                         {

                             string monto = "";
                             monto = Convert.ToString(((TextBox)filaGrid.Cells[2].FindControl("txtMonto")).Text);


                             if (monto.Trim().Length > 0)
                             {

                                 string cantidad = "";
                                 cantidad = Convert.ToString(((TextBox)filaGrid.Cells[3].FindControl("txtCantidad")).Text);
                                 pacEN.mes = Convert.ToInt16(filaGrid.Cells[0].Text);
                                 pacEN.montomes = Convert.ToDouble(monto);
                                 if (cantidad.Trim().Length > 0) { pacEN.cantidad = Convert.ToInt16(cantidad); }
                                 else { pacEN.cantidad = 1; }
                                 pacEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                                 pacEN.idPac = Convert.ToInt32(ViewState["idPacM"]);
                                 pacLN.InsertarPacDetalle(pacEN);


                             }

                         }
                     }

                     //pacEN.idDetalleAccion = Convert.ToInt32(ViewState["idDAccion"]);
                     //pacLN.gridIdDetalleAccion(gridRenglon, pacEN);
                     //lblMontoPac.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pacLN.montoActualPac(pacEN));
                     //string mensaje;
                     //mensaje = "Pac Modificado con Exito";
                     //ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                     //mostrarMsg(0, mensaje);
                     double montoMotal = 0;
                     montoMotal = pacLN.montoActualPac(pacEN);

                     Response.Redirect("NoPac.aspx?No=" + Convert.ToString(pacEN.idPac) + "&monto=" + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", montoMotal) + "&msg=Modificado");

                 }
                 else
                 {
                     if (saldoPac < 0)
                     {
                         string mensaje;
                         mensaje = "Saldo Insuficiente por: " + String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", saldoPac);
                         ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                         mostrarMsg(1, mensaje);
                     }

                     if (saldoPacPac < 0)
                     {
                         string mensaje;
                         mensaje = "Saldo Insuficiente por: " + String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", saldoPacPac);
                         ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                         mostrarMsg(1, mensaje);

                     }
                     
                 }
                        
              }
            }
            catch (Exception ex)
            {
                mostrarMsg(1, ex.Message);
                //throw;
            }
           
        }

        protected void dropAccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
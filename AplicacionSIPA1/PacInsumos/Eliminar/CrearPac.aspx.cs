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

namespace AplicacionSIPA1.Pac
{
   
    public partial class CrearPac : System.Web.UI.Page
    {
        PacEN pacEN;
        PacLN pacLN;
        double total, totalc, totals ,totalcp,totalsp= 0;
        public DataSet tblMes
        {
            get
            {
                object o = ViewState["tblMes"];
                return (DataSet)o;
            }
            set { ViewState["tblMes"] = value; }
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

                ViewState["idPac"] = 6;

            }
        }
        public string nombreMes(int mes)
        {
            DateTimeFormatInfo conver = new CultureInfo("es-ES", false).DateTimeFormat;
            return conver.GetMonthName(mes);
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Page.Validate("vacios");
                pacLN = new PacLN();
                pacEN = new PacEN();
            if (this.Page.IsValid)
            {
                double montoMotal = 0;
                for (int i = 0; i <= gridDetalle.Rows.Count - 1; i++)
                {
                    GridViewRow filaGrid = gridDetalle.Rows[i];
                    string monto = "";
                    monto = Convert.ToString(((TextBox)filaGrid.Cells[2].FindControl("txtMonto")).Text);

                    if (monto.Trim().Length > 0)
                    {
                        montoMotal +=Convert.ToDouble(monto);

                    }
                }
                
                double saldoPac = 0;
                pacEN.idDetalleAccion = Convert.ToInt32(ViewState["idDAccion"]);
                saldoPac = pacLN.saldoPac(pacEN) - montoMotal;
                 
                if (montoMotal>0 && Convert.ToInt16(dropModalidad.SelectedValue) > 0 && Convert.ToInt16(dropExcepcion.SelectedValue) > 0   &&  Convert.ToInt32(dropAccion.SelectedValue)>0 && Convert.ToInt32(ViewState["idDAccion"])>0  && saldoPac >=0)
                {
                    
                    pacEN.idDetalleAccion = Convert.ToInt32(ViewState["idDAccion"]);
                    pacEN.idModalidad = Convert.ToInt16(dropModalidad.SelectedValue);
                    pacEN.idExcepcion = Convert.ToInt16(dropExcepcion.SelectedValue);
                    pacEN.descripcion = txtDescripcion.Text.Trim();
                    pacEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                    if (pacLN.InsertarPac(pacEN) == 0)
                    {
                        pacEN.idPac = pacLN.maxidPac();
                        for (int i = 0; i <= gridDetalle.Rows.Count - 1; i++)
                        {
                            GridViewRow filaGrid = gridDetalle.Rows[i];

                            string monto = "";
                            monto = Convert.ToString(((TextBox)filaGrid.Cells[2].FindControl("txtMonto")).Text);


                            if (monto.Trim().Length > 0)
                            {
                                string cantidad = "";
                                cantidad = Convert.ToString(((TextBox)filaGrid.Cells[3].FindControl("txtCantidad")).Text);
                                pacEN.mes = Convert.ToInt16(filaGrid.Cells[0].Text);
                                pacEN.montomes =Convert.ToDouble(monto);
                                if (cantidad.Trim().Length > 0) { pacEN.cantidad = Convert.ToInt16(cantidad); }
                                else { pacEN.cantidad = 1; }
                                pacEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                                pacLN.InsertarPacDetalle(pacEN);
                                
                            }
                        }
                        
                        Response.Redirect("NoPlan.aspx?No=" + Convert.ToString(pacEN.idPac) + "&monto="+ String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", montoMotal) + "&msg=CREADO" );
                        
                    }
                    else { mostrarMsg(1, "No fue Posible Ingresar el Pac"); }
               }
                else
                {   string mensaje="";
                  if (montoMotal == 0)
                    {
                            mensaje = "Debe de Agregar Montos en los Meses";
                    }
                    if (saldoPac < 0)
                    {
                     mensaje = "Saldo Insificiente por: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldoPac);
                    }
                    if (Convert.ToInt16(dropExcepcion.SelectedValue) == 0)
                    {
                        mensaje = "Debe de Seleccionar la Exepcion. Si esta no tiene seleccione la Opcion Ninguno";
                    }
                    if (Convert.ToInt16(dropModalidad.SelectedValue) == 0)
                    {
                        mensaje = "Debe de Seleccionar la Modalidad";
                    }
                    
                    if (Convert.ToInt32(ViewState["idDAccion"]) == 0)
                    {
                        mensaje = "Debe de Seleccionar El Reglon, previamente debio haber seleccionado la Accion";
                    }

                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    mostrarMsg(1, mensaje);
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
            pacEN = new PacEN();
            pacLN = new PacLN();
            ViewState["idDAccion"] = 0;
            pacEN.idAccion = Convert.ToInt32(dropAccion.SelectedValue);
            pacLN.gridDetalleAccion(gridRenglon, pacEN);
            pacEN.idDetalleAccion = 0;
            
        }

        protected void gridRenglon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["idDAccion"] = gridRenglon.SelectedValue;
            pacEN = new PacEN();
            pacLN = new PacLN();
            pacEN.idDetalleAccion = Convert.ToInt32(gridRenglon.SelectedValue);
        }

        protected void gridRenglon_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double suma, sumac, sumas,sumacp,sumasp = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                suma = (Convert.ToDouble(e.Row.Cells[5].Text));
                e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma);
                total += suma;
                suma = 0;

                sumac = (Convert.ToDouble(e.Row.Cells[6].Text));
                e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumac);
                totalc += sumac;
                sumac = 0;

                sumas = (Convert.ToDouble(e.Row.Cells[7].Text));
                e.Row.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumas);
                totals += sumas;
                sumas = 0;

                sumacp = (Convert.ToDouble(e.Row.Cells[8].Text));
                e.Row.Cells[8].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumacp);
                totalcp += sumacp;
                sumacp = 0;

                sumasp = (Convert.ToDouble(e.Row.Cells[9].Text));
                e.Row.Cells[9].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumasp);
                totalsp += sumasp;
                sumasp = 0;

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total";
                e.Row.Cells[5].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total);
                e.Row.Cells[6].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalc);
                e.Row.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totals);
                e.Row.Cells[8].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalcp);
                e.Row.Cells[9].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalsp);
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

       
       
    }
}
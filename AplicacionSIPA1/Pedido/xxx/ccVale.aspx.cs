using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using CapaEN;
using System.Data;
using System.Globalization;


namespace AplicacionSIPA1.Pedido
{
    public partial class ccVale : System.Web.UI.Page
    {
        PedidoLNBorrar pedidoLN;
        PedidoENBorrar pedidoEN;
        double total = 0;
        public DataSet tblDetalle
        {
            get
            {
                object o = ViewState["tblDetalle"];
                return (DataSet)o;
            }
            set { ViewState["tblDetalle"] = value; }
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                pedidoLN = new PedidoLNBorrar();
                pedidoEN = new PedidoENBorrar();

                pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                pedidoLN.dropAccion(dropAccion, pedidoEN);
                pedidoLN.dropEmpleado(dropSolicitante, pedidoEN, 0);
                pedidoLN.dropJefeDireccion(dropJefeDir, pedidoEN);
             

                tblDetalle = new DataSet();
                tblDetalle.Tables.Add(new DataTable());

                tblDetalle.Tables[0].Columns.Add("ID", Type.GetType("System.String"));
                tblDetalle.Tables[0].Columns.Add("Cantidad", Type.GetType("System.String"));
                tblDetalle.Tables[0].Columns.Add("Descripcion", Type.GetType("System.String"));
                tblDetalle.Tables[0].Columns.Add("Costo", Type.GetType("System.String"));

            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                mostrarMsg(2, "");
                this.Page.Validate("vaciosD");

                if (this.Page.IsValid)
                {
                    if (Convert.ToDecimal(txtCosto.Text) <= 1000)
                    {


                        DataRow Agregar = tblDetalle.Tables[0].NewRow();
                        Agregar["ID"] = 0;
                        Agregar["Cantidad"] = txtCantidad.Text;
                        Agregar["Descripcion"] = txtDescripcion.Text;
                        Agregar["Costo"] = txtCosto.Text;
                        tblDetalle.Tables[0].Rows.Add(Agregar);
                        gridArticulos.DataSource = tblDetalle.Tables[0];
                        gridArticulos.DataBind();

                        txtCantidad.Text = String.Empty;
                        txtCosto.Text = String.Empty;
                        txtDescripcion.Text = String.Empty;
                    }
                    else

                    {
                        string mensaje;
                        mensaje = "El valor Maximo del Vale es de Q1,000, este vale sobrepasa el limite";
                        mostrarMsg(1, mensaje);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    }
                }
            }
            catch
            {

            }

        }

        protected void gridArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridArticulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double suma = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                suma = (Convert.ToDouble(e.Row.Cells[3].Text));
                e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", suma);
                total += suma;
                suma = 0;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total";
                e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total);
            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Page.Validate("vacios");

                if (this.Page.IsValid)
                {
                    mostrarMsg(2, "");
                    if (Convert.ToInt32(dropAccion.SelectedValue) > 0)
                    {
                        if (Convert.ToInt32(dropSolicitante.SelectedValue) > 0)
                        {
                            if (Convert.ToInt32(dropJefeDir.SelectedValue) > 0)
                            {
                                    if (gridArticulos.Rows.Count > 0)
                                    {
                                        DateTime hoy;
                                        int anio;
                                        hoy = DateTime.Now;
                                        anio = hoy.Year;

                                        pedidoLN = new PedidoLNBorrar();
                                        pedidoEN = new PedidoENBorrar();

                                        pedidoEN.idAccion = Convert.ToInt32(dropAccion.SelectedValue);
                                        pedidoEN.idSolicitante = Convert.ToInt32(dropSolicitante.SelectedValue);
                                        pedidoEN.idJefeDireccion = Convert.ToInt32(dropJefeDir.SelectedValue);
                                        pedidoEN.Justificacion = txtJustificacion.Text;
                                        pedidoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                                        pedidoLN.Insertar_ccVale(pedidoEN);

                                        pedidoEN.ccidVale= pedidoLN.maxccidVale();


                                        if (pedidoEN.ccidVale > 0)
                                        {
                                            int contar = 0;
                                            double sumarVale = 0;
                                            foreach (DataRow fila in tblDetalle.Tables[0].Rows)
                                            {

                                                sumarVale += Convert.ToDouble(fila["Costo"]);
                                            }

                                           if (sumarVale <= 1000)
                                           { 
                                            foreach (DataRow fila in tblDetalle.Tables[0].Rows)
                                            {

                                                pedidoEN.cantidad = Convert.ToInt32(fila["Cantidad"]);
                                                pedidoEN.descripcion = Convert.ToString(fila["Descripcion"]);
                                                pedidoEN.costoEstimado = Convert.ToDouble(fila["Costo"]);

                                                if (pedidoLN.Insertar_ccValeDetalle(pedidoEN) > 0)
                                                { contar += 1; }


                                            }

                                            if (contar == 0)
                                            {
                                                Response.Redirect("NoPedido.aspx?No=" + pedidoEN.ccidVale + "&msg=VALE");

                                            }
                                            else
                                            {
                                                string mensaje;
                                                mensaje = "<< El Vale No se ha Generado >>";
                                                mostrarMsg(1, mensaje);
                                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                            }
                                           }

                                           else
                                           {
                                               string mensaje;
                                               mensaje = "El valor Maximo del Vale es de Q1,000, este vale sobrepasa el limite";
                                               mostrarMsg(1, mensaje);
                                               ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                           }
                                        }
                                        else
                                        {
                                            string mensaje;
                                            mensaje = "XXXXX .El Vale No se ha Generado. XXXXX";
                                            mostrarMsg(1, mensaje);
                                            ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                        }
                                    }
                                    else
                                    {
                                        string mensaje;
                                        mensaje = "Debe de Ingresar Articulos para realizar el Vale.";
                                        mostrarMsg(1, mensaje);
                                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                                    }

                               
                            }
                            else
                            {
                                string mensaje;
                                mensaje = "Selecciona el Jefe Inmediato.";
                                mostrarMsg(1, mensaje);
                                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                            }

                        }
                        else
                        {
                            string mensaje;
                            mensaje = "Selecciona el Solicitante.";
                            mostrarMsg(1, mensaje);
                            ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                        }

                    }
                    else
                    {
                        string mensaje;
                        mensaje = "Selecciona el No. de Accion.";
                        mostrarMsg(1, mensaje);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    }
                }


            }
            catch
            {

            }


        }

        protected void gridArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            mostrarMsg(2, "");
            tblDetalle.Tables[0].Rows.RemoveAt(e.RowIndex);
            gridArticulos.DataSource = tblDetalle.Tables[0];
            gridArticulos.DataBind();
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
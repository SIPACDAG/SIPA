using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Presupuesto
{
    public partial class PptoDependencia : System.Web.UI.Page
    {
        PresupuestoLN presupuestoLN;
        PresupuestoEN presupuestoEN;
        double total = 0;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                llenarAnio(dropAnio);
                presupuestoLN = new PresupuestoLN();
                presupuestoLN.dropUsuarioUnidad(dropUnidad,((Label)Master.FindControl("lblUsuario")).Text);
                dropUnidad.SelectedValue = dropUnidad.SelectedItem.Value; 
                presupuestoLN.dropDependencia(dropDependencia, Convert.ToInt32(dropUnidad.SelectedValue));
                presupuestoLN.gridPresupuestoDep(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text), Convert.ToInt32(dropUnidad.SelectedValue));
                presupuestoEN = new PresupuestoEN();
                presupuestoEN.idUnidad = Convert.ToInt32(dropUnidad.SelectedValue);
                presupuestoEN.anio = Convert.ToInt32(dropAnio.SelectedItem.Text);
                lblMontoAsignable.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", presupuestoLN.saldoPresUnidad(presupuestoEN));

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
            drop.SelectedIndex = 1;
            
        }



        protected void dropAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            presupuestoLN = new PresupuestoLN();
            presupuestoLN.gridPresupuestoDep(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text), Convert.ToInt32(dropUnidad.SelectedValue));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Page.Validate("vacios");
                if (this.Page.IsValid)
                {


                    if (Convert.ToInt32(dropDependencia.SelectedValue) > 0)
                    {
                        presupuestoLN = new PresupuestoLN();
                        presupuestoEN = new PresupuestoEN();
                        presupuestoEN.idDependencia = Convert.ToInt32(dropDependencia.SelectedValue);
                        presupuestoEN.monto = Convert.ToDouble(txtMonto.Text);
                        presupuestoEN.anio = Convert.ToInt32(dropAnio.SelectedItem.Text);
                        presupuestoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                         presupuestoEN.idUnidad =Convert.ToInt32(dropUnidad.SelectedValue);
                        double saldo =0;
                        saldo = presupuestoLN.saldoPresUnidad(presupuestoEN) - presupuestoEN.monto;
                        if (saldo >= 0)
                        {
                            if (presupuestoLN.valPresDep(presupuestoEN) == 0)
                            {
                                if (presupuestoLN.InsertarPresDep(presupuestoEN) == 0)
                                {
                                    mostrarMsg(0, "Ingreso de Presupuesto Exitoso");
                                    txtMonto.Text = String.Empty;
                                    presupuestoLN.gridPresupuestoDep(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text), Convert.ToInt32(dropUnidad.SelectedValue));
                                    lblMontoAsignable.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);
                                }
                                else
                                {
                                    mostrarMsg(1, "El registro no se pudo Ingresar");
                                }

                            }
                            else
                            {
                                mostrarMsg(1, "El Presupuesto ya Fue Ingresado");
                            }
                        }
                        else
                        {
                            mostrarMsg(1, "Saldo Insuficiente");
                        }
                    }
                    else
                    {
                        mostrarMsg(1, "Selecciones la Unidad");
                    }
                }
            }

            catch (Exception)
            {
                mostrarMsg(1, "Error: No es posible Insertar este Presupuesto");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtMonto.Text = String.Empty;
            dropDependencia.SelectedValue = "0";
            mostrarMsg(2, "");

        }

        protected void gridPresupuesto_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total);
            }

        }

 

        protected void dropUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            presupuestoLN = new PresupuestoLN();
            presupuestoLN.dropDependencia(dropDependencia, Convert.ToInt32(dropUnidad.SelectedValue));
            presupuestoLN.gridPresupuestoDep(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text), Convert.ToInt32(dropUnidad.SelectedValue));
            presupuestoEN = new PresupuestoEN();
            presupuestoEN.idUnidad = Convert.ToInt32(dropUnidad.SelectedValue);
            presupuestoEN.anio = Convert.ToInt32(dropAnio.SelectedItem.Text);
            lblMontoAsignable.Text= String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", presupuestoLN.saldoPresUnidad(presupuestoEN));
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
            }


        }

        protected void gridPresupuesto_RowDeleting(object sender, GridViewDeleteEventArgs e,string usuario)
        {
            try
            {
                int idPU;
                idPU = Convert.ToInt32(gridPresupuesto.Rows[e.RowIndex].Cells[1].Text);
                if (idPU != 0)
                {
                    presupuestoLN = new PresupuestoLN();
                    presupuestoEN = new PresupuestoEN();
                    presupuestoEN.idPresupuestoUnidad = idPU;
                    if (presupuestoLN.EliminarPresUnidad(presupuestoEN,usuario) == 0)
                    {
                        presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text));
                        lblSuccess.Text = "Registro eliminado correctamente";
                        lblError.Text = string.Empty;
                    }
                    else
                    {
                        lblError.Text = "Error al eliminar el registro";
                        lblSuccess.Text = string.Empty;
                    }
                }
                else
                {
                    lblError.Text = "Seleccione un presupuesto";
                    lblSuccess.Text = string.Empty;
                }
            }

            catch (Exception)
            {
                lblError.Text = "Error al eliminar el registro";
                lblSuccess.Text = string.Empty;
            }
        }


    }
}
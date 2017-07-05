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
    public partial class PptoUnidad : System.Web.UI.Page
    {
        PresupuestoLN presupuestoLN;
        PresupuestoEN presupuestoEN;
        double total=0;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                llenarAnio(dropAnio);
                presupuestoLN = new PresupuestoLN();
                presupuestoLN.dropUnidad(dropUnidad);
                presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text));
            }
        }
        private void llenarAnio(DropDownList drop)
        {
            DateTime hoy;
            int anio,i;
            hoy = DateTime.Now;
            anio = hoy.Year+1;
            i = 0;
            for (int index = 0; index <= anio - 2016; index++)
            {
                drop.Items.Insert(index, Convert.ToString(anio-index));
                i += 1;
            }
            drop.SelectedIndex = i-1;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            try
            {
                            this.Page.Validate("vacios");
                            if (this.Page.IsValid)
                            {


                                if (Convert.ToInt32(dropUnidad.SelectedValue) > 0)
                                {
                                    presupuestoLN = new PresupuestoLN();
                                    presupuestoEN = new PresupuestoEN();
                                    presupuestoEN.idUnidad = Convert.ToInt32(dropUnidad.SelectedValue);
                                    presupuestoEN.monto = Convert.ToDouble(txtMonto.Text);
                                    presupuestoEN.anio = Convert.ToInt32(dropAnio.SelectedItem.Text);
                                    presupuestoEN.usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                                    if (presupuestoLN.valPresUnidad(presupuestoEN)==0)
                                    {
                                        if (presupuestoLN.InsertarPresUnidad(presupuestoEN, Session["usuario"].ToString()) == 0)
                                        {
                                            txtMonto.Text = String.Empty;
                                            presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text));

                                            lblError.Text = string.Empty;
                                            lblSuccess.Text = "El registro fue ingresado correctamente ";
                                        }
                                        else
                                        {
                                            lblError.Text = "Error al ingresar el registro";
                                            lblSuccess.Text = string.Empty;
                                        }

                                    }
                                    else
                                    {
                                        lblError.Text = "El presupuesto ya fue asignado";
                                        lblSuccess.Text = string.Empty;
                                    }
                                }
                                else
                                {
                                    lblError.Text = "Seleccione una unidad";
                                    lblSuccess.Text = string.Empty;
                                }
                            }
            }

            catch (Exception ex)
            {
                lblError.Text = "Error al ingresar el registro" + ex.Message;
                lblSuccess.Text = string.Empty;
            }
            
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            txtMonto.Text = String.Empty;
            dropUnidad.SelectedValue = "0";
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;

            presupuestoLN = new PresupuestoLN();
            presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text));
        }

        protected void gridPresupuesto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            limpiarControlesError();

            try
            {
                int idPU;
                idPU = Convert.ToInt32(gridPresupuesto.Rows[e.RowIndex].Cells[1].Text);
                if (idPU != 0)
                {
                    presupuestoLN = new PresupuestoLN();
                    presupuestoEN = new PresupuestoEN();
                    presupuestoEN.idPresupuestoUnidad = idPU;
                    if (presupuestoLN.EliminarPresUnidad(presupuestoEN, Session["usuario"].ToString()) == 0)
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
                    btnCancelar_Click(sender, e);
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

        protected void dropAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
            presupuestoLN = new PresupuestoLN();
            presupuestoLN.gridPresupuesto(gridPresupuesto, Convert.ToInt32(dropAnio.SelectedItem.Text));

        }

        protected void gridPresupuesto_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void dropUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();

            txtMonto.Focus();
        }

        protected void limpiarControlesError()
        {
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;
        }

        protected void gridPresupuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
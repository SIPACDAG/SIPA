using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.RH
{
    public partial class ListadoEmpleados : System.Web.UI.Page
    {
        private EmpleadosLN eEmpleadosLN;
        private EmpleadosEN eEmpleadosEN;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    nuevaBusqueda();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        public void nuevaBusqueda()
        {
            try
            {
                rblCriterio.Items.Add(new ListItem("Apellidos", "apellidos"));
                rblCriterio.Items.Add(new ListItem("Nombres", "nombres"));
                rblCriterio.Items.Add(new ListItem("Fecha Nac.", "fecha_nacimiento"));
                rblCriterio.Items.Add(new ListItem("DPI", "cui"));
                rblCriterio.Items.Add(new ListItem("Nit", "nit"));
                rblCriterio.Items.Add(new ListItem("Genero", "genero"));
                rblCriterio.Items.Add(new ListItem("Unidad", "unidad_administrativa"));
                rblCriterio.Items.Add(new ListItem("Puesto", "puesto"));
                rblCriterio.Items.Add(new ListItem("Renglón", "renglon"));
                rblCriterio.SelectedValue = "apellidos";
                rblCriterio.DataBind();

                txtBValor.Text = string.Empty;

                filtrarGrid();
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoPedidoEnc(). " + ex.Message);
            }
        }

        protected void filtrarGrid()
        {
            try
            {
                gridEmpleados.DataSource = null;
                gridEmpleados.DataBind();
                gridEmpleados.SelectedIndex = -1;

                eEmpleadosLN = new EmpleadosLN();
                DataSet dsResultado = eEmpleadosLN.InformacionEmpleado(0, 5);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridEmpleados.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridEmpleados.DataBind();

                    string filtro = string.Empty;

                    object obj = gridEmpleados.DataSource;
                    System.Data.DataTable tbl = gridEmpleados.DataSource as System.Data.DataTable;
                    System.Data.DataView dv = tbl.DefaultView;

                    filtro = "0 = 0";
                    if(!txtBValor.Text.Equals(string.Empty))
                        filtro += " AND " + rblCriterio.SelectedValue + " LIKE '%" + txtBValor.Text + "%'";

                    dv.RowFilter = filtro;
                    gridEmpleados.DataSource = dv;
                    gridEmpleados.DataBind();
                }
                else
                {
                    gridEmpleados.DataSource = null;
                    gridEmpleados.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridDetalles(). " + ex.Message);
            }
        }

        protected void limpiarControlesError()
        {
            lblError.Text = lblSuccess.Text = string.Empty;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnBuscar(). " + ex.Message;
            }
        }

        protected void gridEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                limpiarControlesError();
                gridEmpleados.PageIndex = e.NewPageIndex;
                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "gridEmpleados(). " + ex.Message;
            }
        }

        protected void gridEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idEmpleado = 0;
                int.TryParse(gridEmpleados.SelectedValue.ToString(), out idEmpleado);

                Response.Redirect("IngresoEmpleados.aspx?No=" + idEmpleado.ToString());
            }
            catch (Exception ex)
            {
                lblError.Text = "gridEmpleados(). " + ex.Message;
            }
        }

    }
}
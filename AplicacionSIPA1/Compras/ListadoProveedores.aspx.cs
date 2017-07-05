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

namespace AplicacionSIPA1.Compras
{
    public partial class ListadoProveedores : System.Web.UI.Page
    {
        private PedidosLN lnPedidos;
        private ProveedoresEN enEmpleados;
        
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
                rblCriterio.Items.Add(new ListItem("Nit", "nit"));
                rblCriterio.Items.Add(new ListItem("Nombre", "nombre_proveedor"));
                rblCriterio.Items.Add(new ListItem("Direccion", "direccion"));
                rblCriterio.Items.Add(new ListItem("Teléfono", "telefono"));
                rblCriterio.Items.Add(new ListItem("Activo", "activo"));
                rblCriterio.DataBind();

                rblCriterio.SelectedValue = "nit";
                txtBValor.Text = string.Empty;

                filtrarGrid();
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoEnc(). " + ex.Message);
            }
        }

        protected void filtrarGrid()
        {
            try
            {
                gridProveedores.DataSource = null;
                gridProveedores.DataBind();
                gridProveedores.SelectedIndex = -1;

                lnPedidos = new PedidosLN();
                DataSet dsResultado = lnPedidos.InformacionProveedores(0, 0, 1);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridProveedores.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridProveedores.DataBind();

                    string filtro = string.Empty;

                    object obj = gridProveedores.DataSource;
                    System.Data.DataTable tbl = gridProveedores.DataSource as System.Data.DataTable;
                    System.Data.DataView dv = tbl.DefaultView;

                    filtro = "0 = 0";
                    if(!txtBValor.Text.Equals(string.Empty))
                        filtro += " AND " + rblCriterio.SelectedValue + " LIKE '%" + txtBValor.Text + "%'";

                    dv.RowFilter = filtro;
                    gridProveedores.DataSource = dv;
                    gridProveedores.DataBind();
                }
                else
                {
                    gridProveedores.DataSource = null;
                    gridProveedores.DataBind();
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

        protected void gridProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                limpiarControlesError();
                gridProveedores.PageIndex = e.NewPageIndex;
                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "gridEmpleados(). " + ex.Message;
            }
        }

        protected void gridProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idEncabezado = 0;
                int.TryParse(gridProveedores.SelectedValue.ToString(), out idEncabezado);

                Response.Redirect("IngresoProveedores.aspx?No=" + idEncabezado.ToString());
            }
            catch (Exception ex)
            {
                lblError.Text = "gridProveedores(). " + ex.Message;
            }
        }

    }
}
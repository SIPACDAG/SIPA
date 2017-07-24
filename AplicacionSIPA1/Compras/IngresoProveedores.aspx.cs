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
    public partial class IngresoProveedores : System.Web.UI.Page
    {
        private PedidosLN lnProveedores;
        private ProveedoresEN enProveedores;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    btnNuevo_Click(sender, e);

                    string s = Convert.ToString(Request.QueryString["No"]);

                    if (s != null)
                    {
                        int idEncabezado = 0;
                        int.TryParse(s, out idEncabezado);
                        lblNo.Text = idEncabezado.ToString();

                        lnProveedores = new PedidosLN();
                        DataSet dsResultado = lnProveedores.InformacionProveedores(idEncabezado, 0, 2);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables.Count == 0)
                            throw new Exception("Error al consultar la información del proveedor.");

                        if (dsResultado.Tables[0].Rows.Count == 0)
                            throw new Exception("No existe información del proveedor");

                        txtNit.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NIT"].ToString();
                        txtRazonSocial.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["RAZON_SOCIAL"].ToString();
                        txtNombre.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE_PROVEEDOR"].ToString();
                        txtDireccion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DIRECCION"].ToString();
                        txtTel.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["TELEFONO"].ToString();
                        int estado;

                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ACTIVO"].ToString(), out estado);

                        ListItem item = ddlEstado.Items.FindByValue(estado.ToString());
                        if (item != null)
                            ddlEstado.SelectedValue = estado.ToString();

                        ddlEstado.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        public void NuevoIngresoProveedor()
        {
            try
            {
                lblNo.Text = "0";
                txtNit.Text = txtRazonSocial.Text = txtNombre.Text = txtDireccion.Text = txtTel.Text = string.Empty;
                ddlEstado.SelectedValue = "1";
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoPedidoEnc(). " + ex.Message);
            }
        }

        protected void limpiarControlesError()
        {
            lblErrorNit.Text = lblErrorRazon.Text = lblErrorNombre.Text = lblErrorDireccion.Text = lblErrorTel.Text = string.Empty;
            lblError.Text = lblSuccess.Text = string.Empty;
        }

        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                txtNit.Text = txtNit.Text.Replace('\'', ' ');
                txtNit.Text = txtNit.Text.Trim();

                txtRazonSocial.Text = txtRazonSocial.Text.Replace('\'', ' ');
                txtRazonSocial.Text = txtRazonSocial.Text.Trim();

                txtNombre.Text = txtNombre.Text.Replace('\'', ' ');
                txtNombre.Text = txtNombre.Text.Trim();

                txtDireccion.Text = txtDireccion.Text.Replace('\'', ' ');
                txtDireccion.Text = txtDireccion.Text.Trim();

                txtTel.Text = txtTel.Text.Replace('\'', ' ');
                txtTel.Text = txtTel.Text.Trim();

                if (txtNit.Text.Equals(string.Empty))
                {
                    lblErrorNit.Text = "Ingrese un valor. ";
                    lblError.Text += "Ingrese nit. ";
                }
                
                if (txtRazonSocial.Text.Equals(string.Empty))
                {
                    lblErrorRazon.Text = "Ingrese un valor. ";
                    lblError.Text += "Ingrese razón social. ";
                }

                if (txtNombre.Text.Equals(string.Empty))
                {
                    lblErrorNombre.Text = "Ingrese un valor. ";
                    lblError.Text += "Ingrese nombre. ";
                }

                if (lblError.Text.Equals(string.Empty))
                    controlesValidos = true;

                if (controlesValidos && Page.IsValid)
                    controlesValidos = true;
                else
                    controlesValidos = false;
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }
            return controlesValidos;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarControlesABC())
                {
                    int idEncabezado = 0;
                    int.TryParse(lblNo.Text, out idEncabezado);

                    enProveedores = new ProveedoresEN();
                    enProveedores.vid_proveedor = idEncabezado;
                    enProveedores.vnit = txtNit.Text;
                    enProveedores.vrazon_social = txtRazonSocial.Text;
                    enProveedores.vnombre_proveedor = txtNombre.Text;
                    enProveedores.vdireccion = txtDireccion.Text;
                    enProveedores.vtelefono = txtTel.Text;
                    enProveedores.vactivo = int.Parse(ddlEstado.SelectedValue);
                    
                    if (true)
                    {
                        lnProveedores = new PedidosLN();
                        DataSet dsResultado = lnProveedores.AlmacenarProveedor(enProveedores,Session["usuario"].ToString());

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ el pedido: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idEncabezado);
                        lblNo.Text = idEncabezado.ToString();

                        btnNuevo_Click(sender, e);
                        lblSuccess.Text = "Proveedor ALMACENADO exitosamente: ";
                    }                    
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar(). " + ex.Message;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoIngresoProveedor();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo(). " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idEncabezado = 0;
                int.TryParse(lblNo.Text, out idEncabezado);

                if (idEncabezado  == 0)
                    throw new Exception("No existe Proveedor para eliminar");

                lnProveedores = new PedidosLN();
                DataSet dsResultado = lnProveedores.EliminarProveedor(idEncabezado);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                NuevoIngresoProveedor();
                lblSuccess.Text = "Proveedor eliminado correctamente!";
            }
            catch (Exception ex)
            {
                lblError.Text = "btnEliminar(). " + ex.Message;
            }
        }

    }
}
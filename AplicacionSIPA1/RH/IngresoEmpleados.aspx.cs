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
    public partial class IngresoEmpleados : System.Web.UI.Page
    {
        private EmpleadosLN eEmpleadosLN;
        private EmpleadosEN eEmpleadosEN;
        
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
                        int idEmpleado = 0;
                        int.TryParse(s, out idEmpleado);
                        txtNoEmpleado.Text = idEmpleado.ToString();

                        eEmpleadosLN = new EmpleadosLN();
                        DataSet dsResultado = eEmpleadosLN.InformacionEmpleado(idEmpleado, 6);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables.Count == 0)
                            throw new Exception("Error al consultar la información del empleado.");

                        if (dsResultado.Tables[0].Rows.Count == 0)
                            throw new Exception("No existe información del empleado");

                        txtNombres.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRES"].ToString();
                        txtApellidos.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["APELLIDOS"].ToString();
                        txtDireccion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DIRECCION"].ToString();
                        txtFechaNacimiento.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["FECHA_NACIMIENTO"].ToString();
                        txtCui.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["CUI"].ToString();
                        txtNit.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NIT"].ToString();
                        txtTel.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["TELEFONO"].ToString();
                        txtEmail.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["EMAIL"].ToString();
                        txtSueldo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["SUELDO_BASE"].ToString();
                        int idGenero, idUnidad, idPuesto, idEstado;
                        string renglon;

                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_GENERO"].ToString(), out idGenero);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_UNIDAD"].ToString(), out idUnidad);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_PUESTO"].ToString(), out idPuesto);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO"].ToString(), out idEstado);
                        renglon = dsResultado.Tables["BUSQUEDA"].Rows[0]["RENGLON"].ToString();

                        ListItem item = rblGenero.Items.FindByValue(idGenero.ToString());
                        if (item != null)
                            rblGenero.SelectedValue = idGenero.ToString();

                        item = ddlUnidades.Items.FindByValue(idUnidad.ToString());
                        if (item != null)
                            ddlUnidades.SelectedValue = idUnidad.ToString();

                        item = ddlPuestos.Items.FindByValue(idPuesto.ToString());
                        if (item != null)
                            ddlPuestos.SelectedValue = idPuesto.ToString();

                        item = ddlRenglones.Items.FindByValue(renglon);
                        if (item != null)
                            ddlRenglones.SelectedValue = renglon.ToString();

                        item = ddlEstado.Items.FindByValue(idEstado.ToString());
                        if (item != null)
                            ddlEstado.SelectedValue = idEstado.ToString();

                        ddlEstado.Enabled = true;
                        validarEstadoEmpleado(idEmpleado);
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        public void NuevoIngresoEmpleado()
        {
            try
            {
                validarEstadoEmpleado(0);
                txtNoEmpleado.Text = "0";
                txtNombres.Text = txtApellidos.Text = txtDireccion.Text = string.Empty;
                rblGenero.SelectedValue = "1";
                txtFechaNacimiento.Text = string.Empty;
                txtCui.Text = txtNit.Text = txtTel.Text = txtEmail.Text = string.Empty;

                ddlUnidades.SelectedIndex = 0;
                ddlPuestos.SelectedIndex = 0;
                ddlRenglones.SelectedIndex = 0;
                ddlEstado.SelectedIndex = 0;
                ddlEstado.Enabled = false;

                eEmpleadosLN = new EmpleadosLN();
                eEmpleadosLN.DdlUnidades(ddlUnidades);
                eEmpleadosLN.DdlPuestos(ddlPuestos);
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoPedidoEnc(). " + ex.Message);
            }
        }

        protected void limpiarControlesError()
        {
            lblErrorNo.Text = string.Empty;
            lblErrorNombres.Text = lblErrorApellidos.Text = lblErrorDireccion.Text = lblErrorGenero.Text = lblErrorFechaNac.Text = string.Empty;
            lblErrorCui.Text = lblErrorNit.Text = lblErrorTel.Text = lblErrorEmail.Text = string.Empty;
            lblErrorUnidades.Text = lblErrorPuestos.Text = lblErrorRenglones.Text = lblErrorEstado.Text = string.Empty;
            lblError.Text = lblSuccess.Text = string.Empty;
            lblErrorSueldo.Text = string.Empty;
        }

        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                txtNoEmpleado.Text = txtNoEmpleado.Text.Replace('\'', ' ');
                txtNoEmpleado.Text = txtNoEmpleado.Text.Trim();

                txtNombres.Text = txtNombres.Text.Replace('\'', ' ');
                txtNombres.Text = txtNombres.Text.Trim();

                txtApellidos.Text = txtApellidos.Text.Replace('\'', ' ');
                txtApellidos.Text = txtApellidos.Text.Trim();

                txtDireccion.Text = txtDireccion.Text.Replace('\'', ' ');
                txtDireccion.Text = txtDireccion.Text.Trim();

                txtTel.Text = txtTel.Text.Replace('\'', ' ');
                txtTel.Text = txtTel.Text.Trim();

                txtEmail.Text = txtEmail.Text.Replace('\'', ' ');
                txtEmail.Text = txtEmail.Text.Trim();

                txtNit.Text = txtNit.Text.Replace('\'', ' ');
                txtNit.Text = txtNit.Text.Trim();

                txtCui.Text = txtCui.Text.Replace('\'', ' ');
                txtCui.Text = txtCui.Text.Trim();


                if (txtNoEmpleado.Text.Equals(string.Empty))
                {
                    lblErrorNo.Text = "Ingrese un valor. ";
                    lblError.Text += "Ingrese código de empleado. ";
                }

                int noEmpleado = 0;
                int.TryParse(txtNoEmpleado.Text, out noEmpleado);

                if(noEmpleado < 1)
                {
                    lblErrorNo.Text = "Ingrese un código válido. ";
                    lblError.Text += "Ingrese código válido. ";
                }

                if (txtNombres.Text.Equals(string.Empty))
                {
                    lblErrorNombres.Text = "Ingrese un valor. ";
                    lblError.Text += "Ingrese nombres. ";
                }

                /*if (txtApellidos.Text.Equals(string.Empty))
                {
                    lblErrorApellidos.Text = "Ingrese un valor. ";
                    lblError.Text += "Ingrese apellidos. ";
                }*/

                if (!txtFechaNacimiento.Text.Equals(string.Empty))
                {
                    try
                    {
                        string[] s = txtFechaNacimiento.Text.Split('/');

                        if (s.Length != 3)
                            throw new Exception("");

                        string fecha = s[0] + "/" + s[1] + "/" + s[2];
                        DateTime fechaNac;

                        if(!DateTime.TryParse(fecha, out fechaNac))
                            throw new Exception("");
                    }
                    catch (Exception ex)
                    {
                        lblErrorFechaNac.Text = "Fecha inválida. ";
                        lblError.Text += "Fecha inválida. ";
                    }
                }

                decimal sueldo = 0;
                decimal.TryParse(txtSueldo.Text, out sueldo);

                if (sueldo <= 0)
                {
                    lblErrorSueldo.Text = "Sueldo no válido. ";
                    lblError.Text += "Sueldo no válido. ";
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


        protected bool validarEstadoEmpleado(int idEmpleado)
        {
            bool pedidoValido = false;
            try
            {
                if (idEmpleado == 0)
                {
                    btnEliminar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = true;
                    lblErrorPoa.Text = lblError.Text = "";
                    pedidoValido = true;
                }
                else
                {
                    btnEliminar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = false;

                    eEmpleadosLN = new EmpleadosLN();
                    DataSet dsResultado = eEmpleadosLN.InformacionEmpleado(idEmpleado, 6);
                    
                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar el estado del empleado.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe estado asignado al empleado");

                    int idEstadoEmpleado = 1;

                    if(dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO"].ToString(), out idEstadoEmpleado);

                    //EL EMPLEADO ESTÁ DE ALTA
                    if (idEstadoEmpleado == 1)
                    {
                        btnEliminar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = true;
                        lblErrorPoa.Text = lblError.Text = "";
                        pedidoValido = true;
                    }//EL EMPLEADO ESTÁ DE BAJA
                    else if (idEstadoEmpleado == 2)
                    {
                        //btnEliminar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = false;
                        btnEliminar.Visible = btnGuardar.Visible = btnLimpiarC.Visible = true;
                        //lblErrorPoa.Text = lblError.Text = "El PEDIDO seleccionado se encuenta en estado: " + lblEstadoPedido.Text + ", por: " + dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES"].ToString();
                        lblErrorPoa.Text = lblError.Text = "";
                        pedidoValido = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            return pedidoValido;
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
                    int idEmpleado = 0;
                    int.TryParse(txtNoEmpleado.Text, out idEmpleado);

                    eEmpleadosEN = new EmpleadosEN();
                    eEmpleadosEN.ID_EMPLEADO = idEmpleado;
                    eEmpleadosEN.NOMBRES = txtNombres.Text;
                    eEmpleadosEN.APELLIDOS = txtApellidos.Text;
                    eEmpleadosEN.DIRECCION = txtDireccion.Text;
                    eEmpleadosEN.TELEFONO = txtTel.Text;
                    eEmpleadosEN.EMAIL = txtEmail.Text;
                    eEmpleadosEN.ID_GENERO = int.Parse(rblGenero.SelectedValue);
                    eEmpleadosEN.NIT = txtNit.Text;
                    eEmpleadosEN.CUI = txtCui.Text;
                    eEmpleadosEN.FECHA_NACIMINETO = txtFechaNacimiento.Text;
                    eEmpleadosEN.ID_PUESTO = int.Parse(ddlPuestos.SelectedValue);
                    eEmpleadosEN.RENGLON = ddlRenglones.SelectedValue;
                    eEmpleadosEN.ID_UNIDAD = int.Parse(ddlUnidades.SelectedValue);
                    eEmpleadosEN.ID_ESTADO = int.Parse(ddlEstado.SelectedValue);
                    eEmpleadosEN.SUELDO_NOMINAL = decimal.Parse(txtSueldo.Text);
                    eEmpleadosEN.USUARIO = Session["USUARIO"].ToString();

                    if (validarEstadoEmpleado(idEmpleado))
                    {
                        eEmpleadosLN = new EmpleadosLN();
                        DataSet dsResultado = eEmpleadosLN.AlmacenarEmpleado(eEmpleadosEN);

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ el pedido: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idEmpleado);
                        txtNoEmpleado.Text = idEmpleado.ToString();

                        validarEstadoEmpleado(idEmpleado);
                        btnNuevo_Click(sender, e);
                        lblSuccess.Text = "Empleado ALMACENADO exitosamente: ";
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
                NuevoIngresoEmpleado();
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
                int idEmpleado = 0;
                int.TryParse(txtNoEmpleado.Text, out idEmpleado);

                if (idEmpleado  == 0)
                    throw new Exception("No existe Empleado para eliminar");

                eEmpleadosLN = new EmpleadosLN();
                DataSet dsResultado = eEmpleadosLN.EliminarEmpleado(idEmpleado);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                NuevoIngresoEmpleado();
                lblSuccess.Text = "Empleado eliminado correctamente!";
            }
            catch (Exception ex)
            {
                lblError.Text = "btnEliminar(). " + ex.Message;
            }
        }

    }
}
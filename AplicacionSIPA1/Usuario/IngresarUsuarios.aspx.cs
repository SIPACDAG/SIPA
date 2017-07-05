using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Usuario
{
    public partial class IngresarUsuarios : System.Web.UI.Page
    {

        private UsuariosLN usuarioL;
        private UsuariosEN usuarioE;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                usuarioL = new UsuariosLN();
                usuarioL.dropEmpleados(ddlEmpleados);
                
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {//inicio
            usuarioL = new UsuariosLN();
            usuarioE = new UsuariosEN();
         
            this.lblError.Visible = false;
            this.lblError.Text = String.Empty;
            this.lblError.ForeColor = System.Drawing.Color.White;

            this.lblSuccess.Visible = false;
            this.lblSuccess.Text = String.Empty;
            this.lblSuccess.ForeColor = System.Drawing.Color.White;
            this.Page.Validate("vacios");

            //Verifica que los campos no esten  vacios 
            if (this.Page.IsValid)
            {
                Regex val = new Regex("^[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ]+$");
                //Verifica que las contrañas no contengas caracteres especiales
                if (val.IsMatch(this.TextPass_Nuevo.Text) && val.IsMatch(this.TextPass_Confirmar.Text))
                {
                    //Verifica que las contraseñas coincidan
                    if (this.TextPass_Nuevo.Text == this.TextPass_Confirmar.Text)
                    {
                        //Verifica que el nombre de usuario no exista 
                        if (usuarioL.Exite_NombreUsuario(this.text_usuario.Text,0) == 0)
                        {
                            try
                            {
                                int idEmpleado = 0;
                                int.TryParse(ddlEmpleados.SelectedValue, out idEmpleado);
                                //if(idEmpleado > 0)
                                if (true)
                                {
                                    usuarioE.Usuario = this.text_usuario.Text.ToLower();
                                    usuarioE.Contrasena = this.TextPass_Nuevo.Text;
                                    //usuarioE.Nombre = txtNombre.Text;
                                    usuarioE.idEmpleado = Convert.ToInt32(ddlEmpleados.SelectedValue);
                                    
                                    if (usuarioL.IngresarUsuario(usuarioE, ((Label)Master.FindControl("lblUsuario")).Text) == 0)
                                    { 
                                        this.text_usuario.Text = string.Empty;
                                        this.lblSuccess.Visible = true;
                                        this.lblSuccess.ForeColor = System.Drawing.Color.White;
                                        this.lblSuccess.Text = "El usuario fue ingresado correctamente ";
                                        limpiarControles();

                                    }
                                    else
                                    {
                                        this.lblError.Visible = true;
                                        this.lblError.Text = "Error: Usuario No Ingresado";
                                    }
                                                                    
                                }
                                else
                                {
                                    this.lblError.Visible = true;
                                    this.lblError.Text = "Error: Ingrese un nombre válido";
                                
                                }
                            }
                            catch (Exception ex)
                            {

                                this.lblError.Visible = true;
                                this.lblError.Text = "Error al ingresar el usuario a la base de Datos";
                            }
                        }

                        else
                        {
                            this.lblError.Visible = true;
                            this.lblError.Text = "El nombre de usuario ya existe";
                        }

                    }

                    else
                    {
                        this.lblError.Visible = true;
                        this.lblError.Text = "Las contraseñas no coinciden";
                    }

                }

                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "No se permiten caracteres especiales";

                }



            }//fin

        }//final

        protected void btnCancelar_Click(object sender, EventArgs e)
        {//inicio
            limpiarControles();
        }//final

        private void limpiarControles()
        {
            ddlEmpleados.ClearSelection();
            this.text_usuario.Text = string.Empty;
            this.TextPass_Nuevo.Text = string.Empty;
            this.TextPass_Confirmar.Text = string.Empty;
         

            //dropEmpleado.SelectedValue = "0";
        
        }

       



        
    }
}
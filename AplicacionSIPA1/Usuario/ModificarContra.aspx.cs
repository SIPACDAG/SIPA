using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using CapaEN;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace AplicacionSIPA1.Usuario
{
    public partial class ModificarContra : System.Web.UI.Page
    {
        private UsuariosEN usuarioE;
        private UsuariosLN usuarioL;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioE = new UsuariosEN();
            usuarioL = new UsuariosLN();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {//inicio


            this.TextPass_Anterior.Text = "";
            this.TextPass_Nuevo.Text = "";
            this.TextPass_Confirmar.Text = "";

            

        }//fin

        protected void Button1_Click(object sender, EventArgs e)
        {//inicio

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
                if (val.IsMatch(this.TextPass_Anterior.Text) && val.IsMatch(this.TextPass_Nuevo.Text) && val.IsMatch(this.TextPass_Confirmar.Text))
                {
                    //Verifica que las contraseñas coincidan
                    if (this.TextPass_Nuevo.Text == this.TextPass_Confirmar.Text)
                    {

                        usuarioE.Usuario = ((Label)Master.FindControl("lblUsuario")).Text;
                        usuarioE.Contrasena = this.TextPass_Anterior.Text;

                        //Verifica que el usuario exita  
                        if (usuarioL.UsuarioExiste(usuarioE) > 0)
                        {
                            try
                            {
                                usuarioE.Contrasena = this.TextPass_Nuevo.Text;
                                //se llama al metodo para modificar la contraseña
                                if (usuarioL.ModificaPass(usuarioE, ((Label)Master.FindControl("lblUsuario")).Text))
                                {
                                    this.lblSuccess.Visible = true;
                                    this.lblSuccess.ForeColor = System.Drawing.Color.White;
                                    this.lblSuccess.Text = "La contraseña fue Actualizada correctamente ";
                                }
                                else
                                    this.lblError.Text = "El usuario no tiene los permisos necesarios";     
                              

                              
                            }
                            catch (Exception)
                            {
                                this.lblError.Visible = true;
                                this.lblError.Text = "  Error al intentar modificar la contraseña";
                            }


                        }
                        else
                        {
                            this.lblError.Visible = true;
                            this.lblError.Text = "Contraseña inválida";

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



        }

    }
}
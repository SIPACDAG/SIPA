using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CapaLN;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace AplicacionSIPA1
{
    public partial class Login : System.Web.UI.Page
    {

        LogeoLN mstLogeo;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextUsuario.Focus();
            //Response.Redirect("http://192.9.200.247/");
        }

        protected void btniniciar_Click(object sender, EventArgs e)
        
        {

            Regex val = new Regex("^[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ]+$");

            if (val.IsMatch(this.TextUsuario.Text) && val.IsMatch(this.TextContraseña.Text))
            {
                


            try
            {
                   //VARIABLES DE SESIÓN           
                this.Session["usuar"] = this.TextUsuario.Text;
                this.Session["Usuario"] = this.TextUsuario.Text;

                mstLogeo= new LogeoLN();

                if (mstLogeo.Logearse(this.TextUsuario.Text,this.TextContraseña.Text)>0)
                {
                    
                    FormsAuthentication.RedirectFromLoginPage(this.TextUsuario.Text,false);
                    Response.Redirect("~/Inicio.aspx");
                }
                else
            	{
                    this.resultado.Text = "Usuario no autorizado...";
	                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Error en inicio de sesión");
                throw;
            }

                   }
            else
            {
                this.resultado.Text = "Usuario no autorizado...";
                this.TextUsuario.Text = "";
                this.TextContraseña.Text = "";
                this.TextUsuario.Focus();
            }



        }//termina evento

    }
}
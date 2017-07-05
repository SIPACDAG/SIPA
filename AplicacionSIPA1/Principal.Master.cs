using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using System.Security;

namespace AplicacionSIPA1
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Context.Request.Browser.Adapters.Clear();
                this.lblUsuario.Text = this.Session["Usuario"].ToString().ToLower();

                if (!Page.IsPostBack)
                {
                    LogeoLN llenarMenu = new LogeoLN();
                    llenarMenu.LlenarMenu(this.Menu1, this.Session["Usuario"].ToString().ToLower());
                 }

                if (Request.Url.Segments[Request.Url.Segments.Length - 1].ToString() != "Inicio.aspx")
                {

                    LogeoLN BloquearMenu = new LogeoLN();

                    if (BloquearMenu.BloquearAcceso(this.Session["usuar"].ToString().ToLower(), Request.Url.Segments[Request.Url.Segments.Length - 1].ToString()) == 0)
                    {
                        Response.Redirect("~/Inicio.aspx");
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Redirect("~/Login.aspx");
                Console.WriteLine(ex.Message + "     error");
                //throw;
            }

        }
      protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {

        }
    }
}
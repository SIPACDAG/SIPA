using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;

namespace AplicacionSIPA1.PacInsumos
{
    public partial class NoPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Context.Request.Browser.Adapters.Clear();
                this.lblUsuario.Text = this.Session["Usuario"].ToString();

                if (!Page.IsPostBack)
                {
                    LogeoLN llenarMenu = new LogeoLN();
                    llenarMenu.LlenarMenu(this.Menu1, this.Session["Usuario"].ToString());
                    lblNoPedido.Text = Convert.ToString(Request.QueryString["No"]);
                    lblMonto.Text= Convert.ToString(Request.QueryString["monto"]);
                    lblMensaje.Text = Convert.ToString(Request.QueryString["msg"]);
                }


                if (Request.Url.Segments[Request.Url.Segments.Length - 1].ToString() != "~/Inicio.aspx")
                {


                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "     error");

            }
        }

        protected void btnVerListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresarPac.aspx?msg=Listado");
        }
    }
}
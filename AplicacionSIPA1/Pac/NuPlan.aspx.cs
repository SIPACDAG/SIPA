using CapaLN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Pac
{
    public partial class NuPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Context.Request.Browser.Adapters.Clear();
               

                if (!Page.IsPostBack)
                {
                    LogeoLN llenarMenu = new LogeoLN();
                    
                    lblNoPedido.Text = Convert.ToString(Request.QueryString["No"]);
                    lblAccion.Text = Convert.ToString(Request.QueryString["monto"]);
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

        protected void btnPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresarPac.aspx");
        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresarPac.aspx");
        }
    }
}
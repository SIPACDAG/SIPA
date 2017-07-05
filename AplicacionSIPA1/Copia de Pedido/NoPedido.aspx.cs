using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
namespace AplicacionSIPA1.Pedido
{
    public partial class NoPedido : System.Web.UI.Page
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
                    lblMensaje.Text = Convert.ToString(Request.QueryString["msg"]);

                    if (lblMensaje.Text == "VALE")
                    {
                        HyperLink1.NavigateUrl = "~/Pedido/ccVale.aspx";
                    }
                    if (lblMensaje.Text == "PEDIDO")
                    {
                        HyperLink1.NavigateUrl = "~/Pedido/CrearPedido.aspx";
                    }
                    
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
    }
}
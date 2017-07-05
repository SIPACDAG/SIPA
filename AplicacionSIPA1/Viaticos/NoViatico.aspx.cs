using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
namespace AplicacionSIPA1.Viaticos
{
    public partial class NoViatico : System.Web.UI.Page
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
                    lblAccion.Text = Convert.ToString(Request.QueryString["acc"]);

                    if (lblMensaje.Text == "VIATICO_AL_INTERIOR")
                    {
                        HyperLink1.Text = "Nuevo Viático al Interior";
                        HyperLink1.NavigateUrl = "~/Viaticos/ViaticosIngreso.aspx";

                        HyperLink3.Text = "Listado de Viáticos";
                        HyperLink3.NavigateUrl = "~/Viaticos/ViaticosListado.aspx";
                    }

                    if (lblMensaje.Text == "VIATICO_AL_EXTERIOR")
                    {
                        HyperLink1.Text = "Nuevo Viático al Exterior";
                        HyperLink1.NavigateUrl = "~/Viaticos/ViaticosIngresoExt.aspx";

                        HyperLink3.Text = "Listado de Viáticos";
                        HyperLink3.NavigateUrl = "~/Viaticos/ViaticosListado.aspx";
                    }

                    //~/Pedido/PedidoListado.aspx
                    
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
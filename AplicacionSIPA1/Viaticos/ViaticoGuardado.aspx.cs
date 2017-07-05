using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Viaticos
{
    public partial class ViaticoGuardado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Context.Request.Browser.Adapters.Clear();


                if (!Page.IsPostBack)
                {
                    lblNoPedido.Text = Convert.ToString(Request.QueryString["No"]);
                    lblMensaje.Text = Convert.ToString(Request.QueryString["msg"]);
                    lblAccion.Text = Convert.ToString(Request.QueryString["acc"]);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "     error");

            }
        }
    }
}
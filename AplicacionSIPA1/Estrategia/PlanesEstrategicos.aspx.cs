using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Estrategia
{
    public partial class PlanesEstrategicos : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private EjesEN pEstrategicoEN = new EjesEN();

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
                        int idEncabezado = 0;
                        int.TryParse(s, out idEncabezado);
                        lblIdPlan.Text = idEncabezado.ToString();

                        pEstrategicoLN = new PlanEstrategicoLN();
                        DataSet dsResultado = pEstrategicoLN.InformacionPlanEstrategico(idEncabezado, 0, "", 2);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables.Count == 0)
                            throw new Exception("Error al consultar la información del registro");

                        if (dsResultado.Tables[0].Rows.Count == 0)
                            throw new Exception("No existe información del registro");

                        int anioIni, anioFin = 0;

                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO_INI"].ToString(), out anioIni);
                        int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO_FIN"].ToString(), out anioFin);

                        txtNombre.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE"].ToString();
                        txtDescripcion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DESCRIPCION"].ToString();
                        txtAnioIni.Text = anioIni.ToString();
                        txtAnioFin.Text = anioFin.ToString();
                    }

                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_Load(). " + ex.Message;
                }
            }
        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                lblIdPlan.Text = "0";
                txtNombre.Text = txtDescripcion.Text = txtAnioIni.Text = txtAnioFin.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo(). " + ex.Message;
            }
        }  

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                pEstrategicoLN = new PlanEstrategicoLN();
                pEstrategicoEN = new EjesEN();

                DataSet dsResultado = new DataSet();

                if (validarControlesABC())
                {
                    pEstrategicoEN.Id_Plan = int.Parse(lblIdPlan.Text);
                    pEstrategicoEN.NOMBRE_PLAN = txtNombre.Text;
                    pEstrategicoEN.DESCRIPCION = txtDescripcion.Text;
                    pEstrategicoEN.ANIO_INI = int.Parse(txtAnioIni.Text);
                    pEstrategicoEN.ANIO_FIN = int.Parse(txtAnioFin.Text);
                    pEstrategicoEN.USUARIO = Session["usuario"].ToString();

                    dsResultado = pEstrategicoLN.AlmacenarPlanEstrategico(pEstrategicoEN,Session["usuario"].ToString());

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ el registro: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    btnNuevo_Click(sender, e);
                    lblSuccess.Text = "Registro almacenado exitosamente!";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al operar el registro. " + ex.Message;
            }
        }

        protected void limpiarControlesError()
        {
            lblError.Text = lblSuccess.Text = string.Empty;
            lblErrorNombre.Text = lblErrorDescripcion.Text = lblErrorAnioIni.Text = lblErrorAnioFin.Text = string.Empty;
        }

        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            try
            {
                limpiarControlesError();

                if (txtNombre.Text.Equals(""))
                {
                    lblErrorNombre.Text = "*";
                    lblError.Text += "Ingrese el nombre del plan. ";
                }

                if (txtDescripcion.Text.Equals(""))
                {
                    lblErrorDescripcion.Text = "*";
                    lblError.Text += "Ingrese la descripción del plan. ";
                }

                if (txtAnioIni.Text.Equals(""))
                {
                    lblErrorAnioIni.Text = "*";
                    lblError.Text += "Ingrese el año de inicio del plan. ";
                }
                else
                {
                    int anio = 0;
                    int.TryParse(txtAnioIni.Text, out anio);

                    if (anio <= 0)
                    {
                        lblErrorAnioIni.Text = "*";
                        lblError.Text += "Ingrese un año inicial válido. ";
                    }
                }

                if (txtAnioFin.Text.Equals(""))
                {
                    lblErrorAnioFin.Text = "*";
                    lblError.Text += "Ingrese el año de finalización del plan. ";
                }
                else
                {
                    int anio = 0;
                    int.TryParse(txtAnioFin.Text, out anio);

                    if (anio <= 0)
                    {
                        lblErrorAnioFin.Text = "*";
                        lblError.Text += "Ingrese un año final válido. ";
                    }
                }

                if (lblErrorAnioIni.Text.Equals("") && lblErrorAnioFin.Text.Equals(""))
                {
                    int anioIni, anioFin = 0;
                    anioIni = int.Parse(txtAnioIni.Text);
                    anioFin = int.Parse(txtAnioFin.Text);

                    if (anioFin <= anioIni)
                    {
                        lblErrorAnioIni.Text = lblErrorAnioFin.Text = "*";
                        lblError.Text += "Rango de años no válido. ";
                    }
                }

                bool b1 = lblError.Text.Equals("");
                bool b2 = lblError.Text.Equals(string.Empty);

                if (lblError.Text.Equals("") || lblError.Text.Equals(string.Empty))
                    controlesValidos = true;

            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }

            return controlesValidos;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idEncabezado = 0;
                int.TryParse(lblIdPlan.Text, out idEncabezado);

                if (idEncabezado == 0)
                    throw new Exception("No existe registro para eliminar");

                pEstrategicoLN = new PlanEstrategicoLN();
                DataSet dsResultado = pEstrategicoLN.EliminarPlanEstrategico(idEncabezado,Session["usuario"].ToString());
                
                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                btnNuevo_Click(sender, e);
                lblSuccess.Text = "Pedido eliminado correctamente!";
            }
            catch (Exception ex)
            {
                lblError.Text = "btnEliminar(). " + ex.Message;
            }
        }

    }
}
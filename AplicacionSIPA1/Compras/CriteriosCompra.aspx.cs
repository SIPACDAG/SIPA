using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Compras
{
    public partial class CriteriosCompra : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private UsuariosLN uUsuariosLN;
        private PedidosLN pInsumoLN;
        private PedidosEN pInsumoEN;

        private FuncionesVarias funciones;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    NuevoCriterio();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        public void NuevoCriterio()
        {
            try
            {
                limpiarControlesError();
                lblId.Text = "0";
                txtNombre.Text = txtPuntuacion.Text = string.Empty;
                chkEsPrecio.Checked = false;

                btnGuardar.Visible = true;
                filtrarGridCriterios();
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoCriterio()" + ex.Message);
            }
        }


        protected void filtrarGridCriterios()
        {
            try
            {
                gridCriterios.DataSource = null;
                gridCriterios.DataBind();
                gridCriterios.SelectedIndex = -1;
                
                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionCriteriosCompra(0, 0, "", 1);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridCriterios.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridCriterios.DataBind();
                }
                else
                {
                    gridCriterios.DataSource = null;
                    gridCriterios.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridCriterios(). " + ex.Message);
            }
        }

        protected void limpiarControlesError()
        {
            lblError.Text = lblSuccess.Text = string.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                
                if (validarControlesABC() == true)
                {
                    int idCriterio = 0;

                    if (gridCriterios.SelectedValue != null)
                        int.TryParse(gridCriterios.SelectedValue.ToString(), out idCriterio);

                    pInsumoLN = new PedidosLN();
                    string usuario = Session["usuario"].ToString();

                    int criterioPrecio = 0;
                    if (chkEsPrecio.Checked == true)
                        criterioPrecio = 1;

                    DataSet dsResultado = pInsumoLN.AlmacenarCriterio(0, idCriterio, 0, txtNombre.Text, decimal.Parse(txtPuntuacion.Text), criterioPrecio, usuario, 1);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ el criterio: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    NuevoCriterio();
                    lblSuccess.Text = "Criterio almacenado con éxito!";

                }

            }
            catch (Exception ex)
            {
                lblError.Text = "btnAprobar(). " + ex.Message;
            }
        }

        protected bool esEntero(string valor)
        {
            try
            {
                int.Parse(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected bool esDecimal(string valor)
        {
            try
            {
                decimal.Parse(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected bool validarControlesABC()
        {
            bool controlesValidos = false;
            try
            {
                txtNombre.Text = txtNombre.Text.Trim();

                if (txtNombre.Text.Equals("") || txtNombre.Text.Equals(string.Empty))
                    throw new Exception("Ingrese un criterio");

                funciones = new FuncionesVarias();
                txtPuntuacion.Text = funciones.StringToDecimal(txtPuntuacion.Text).ToString();

                if (esDecimal(txtPuntuacion.Text) == false)
                    throw new Exception("Ingrese una puntuación válida");

                if(decimal.Parse(txtPuntuacion.Text) < 1)
                    throw new Exception("Ingrese una puntuación válida");

                controlesValidos = true;
                
                if (lblError.Text.Equals(string.Empty))
                    controlesValidos = true;
                else
                    controlesValidos = false;

                if (controlesValidos && Page.IsValid)
                    controlesValidos = true;
                else
                    controlesValidos = false;
                
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }
            return controlesValidos;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoCriterio();
        }

        protected void gridCriterios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idDetalle = 0;
                int.TryParse(gridCriterios.DataKeys[gridCriterios.SelectedIndex].Value.ToString(), out idDetalle);

                lblId.Text = idDetalle.ToString();

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionCriteriosCompra(idDetalle, 0, "", 2);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                txtNombre.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE"].ToString();
                txtPuntuacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["PUNTUACION_DEFAULT"].ToString();

                string esCriterioPrecio = dsResultado.Tables["BUSQUEDA"].Rows[0]["CRITERIO_PRECIO"].ToString();

                if (esCriterioPrecio.Equals("0"))
                    chkEsPrecio.Checked = false;
                else if (esCriterioPrecio.Equals("1"))
                    chkEsPrecio.Checked = true;
                else
                    throw new Exception("Valor de criterio de precio inválido!");

            }
            catch (Exception ex)
            {
                lblError.Text = "gridCriterios(). " + ex.Message;
            }
        }

        protected void gridCriterios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idDetalle = int.Parse(e.Keys["ID"].ToString());

                if (idDetalle == 0)
                    throw new Exception("No existe criterio para eliminar");

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.AlmacenarCriterio(idDetalle, 0, 0, "", 0, 0, "", 2);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                lblSuccess.Text = "Criterio eliminado correctamente!";
                filtrarGridCriterios();

            }
            catch (Exception ex)
            {
                lblError.Text = "gridCriterios(). " + ex.Message;
            }
        }
    }
}
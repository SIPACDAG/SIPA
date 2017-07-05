using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using CapaEN;

namespace AplicacionSIPA1.Estrategia
{
    public partial class EjesEstrategicosB : System.Web.UI.Page
    {
        private EjesLN ejeL;
        private EjesEN ejeE;

        private PlanEstrategicoLN pEstrategico;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ejeL = new EjesLN();
                ejeL.GridBusqueda(gridBusqueda);

                rblCriterio.Items.Add(new ListItem("Código", "codigo"));
                rblCriterio.Items.Add(new ListItem("Eje", "eje"));
                rblCriterio.Items.Add(new ListItem("Plan", "plan"));
                rblCriterio.SelectedValue = "codigo";
                rblCriterio.DataBind();

                upModificar.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            ejeL = new EjesLN();
            ejeL.GridBusqueda(gridBusqueda);
            
            string vBuscado = txtBValor.Text.Replace('\'', ' ');

            string filtro = string.Empty;

            object obj = gridBusqueda.DataSource;
            System.Data.DataTable tbl = gridBusqueda.DataSource as System.Data.DataTable;
            System.Data.DataView dv = tbl.DefaultView;

            filtro = " anio > 0 ";

            if (!vBuscado.Equals(string.Empty))
            {
                if(rblCriterio.SelectedValue.Equals("codigo"))
                    filtro = filtro + " AND " + rblCriterio.SelectedValue + " = '" + vBuscado + "'";

                if (rblCriterio.SelectedValue.Equals("eje"))
                    filtro = filtro + " AND " + rblCriterio.SelectedValue + " LIKE '%" + vBuscado + "%'";

                if (rblCriterio.SelectedValue.Equals("plan"))
                    filtro = filtro + " AND " + rblCriterio.SelectedValue + " LIKE '%" + vBuscado + "%'";
            }
            dv.RowFilter = filtro;

            gridBusqueda.DataSource = dv;
            gridBusqueda.DataBind();
        }

        protected void gridBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ejeL = new EjesLN();
            gridBusqueda.PageIndex = e.NewPageIndex;
            ejeL.GridBusqueda(gridBusqueda);
        }

        protected void gridBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesModificar(true);
            try
            {
                string idBuscar = gridBusqueda.SelectedValue.ToString();
                
                ejeL = new EjesLN();                
                System.Data.DataSet ds = ejeL.BuscarId(idBuscar);
                
                if (bool.Parse(ds.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                lblID.Text = ds.Tables["BUSQUEDA"].Rows[0]["ID"].ToString();
                txtCodigo.Text = ds.Tables["BUSQUEDA"].Rows[0]["CODIGO"].ToString();
                txtEje.Text = ds.Tables["BUSQUEDA"].Rows[0]["EJE"].ToString();
                ddlPlanesE.Enabled = false;

                pEstrategico = new PlanEstrategicoLN();
                pEstrategico.DdlPlanes(ddlPlanesE);
                ddlPlanesE.SelectedValue = ds.Tables["BUSQUEDA"].Rows[0]["ID_PLAN"].ToString();
                btnModificar.Visible = true;
                btnEliminar.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar los datos: " + ex.Message;
                lblError.Visible = true;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        protected void gridBusqueda_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            limpiarControlesModificar(false);
            try
            {
                GridViewRowCollection rc = gridBusqueda.Rows;
                string idBuscar = int.Parse(e.Keys["ID"].ToString()).ToString();

                ejeL = new EjesLN();
                System.Data.DataSet ds = ejeL.BuscarId(idBuscar);

                if (bool.Parse(ds.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                lblID.Text = ds.Tables["BUSQUEDA"].Rows[0]["ID"].ToString();
                txtCodigo.Text = ds.Tables["BUSQUEDA"].Rows[0]["CODIGO"].ToString();
                txtEje.Text = ds.Tables["BUSQUEDA"].Rows[0]["EJE"].ToString();

                pEstrategico = new PlanEstrategicoLN();
                pEstrategico.DdlPlanes(ddlPlanesE);
                ddlPlanesE.SelectedValue = ds.Tables["BUSQUEDA"].Rows[0]["ID_PLAN"].ToString();   

                btnModificar.Visible = false;
                btnEliminar.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar los datos: " + ex.Message;
                lblError.Visible = true;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        protected void limpiarControlesModificar(Boolean enabled)
        {
            upBuscar.Visible = false;
            upModificar.Visible = true;
            ddlPlanesE.Enabled = enabled;
            txtCodigo.Enabled = enabled;
            txtEje.Enabled = enabled;

            lblError.Visible = false;
            lblError.Text = "";
            lblSuccess.Visible = false;
            lblSuccess.Text = "";
        }

        protected void rblCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBValor.Focus();
        }

        private void limpiarControlesNuevo()
        {
            pEstrategico = new PlanEstrategicoLN();
            pEstrategico.DdlPlanes(ddlPlanesE);

            lblID.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtEje.Text = string.Empty;
            lblError.Text = "";
            lblSuccess.Text = "";

        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ejeL = new EjesLN();
            ejeE = new EjesEN();

            if (validarControlesInsertar())
            {
                try
                {
                    ejeE.Id_Plan = int.Parse(ddlPlanesE.SelectedValue);
                    ejeE.Codigo_Eje = int.Parse(txtCodigo.Text);
                    ejeE.Eje_Estrategico = txtEje.Text.Replace('\'', ' ');
                    ejeE.Id_Eje_Estrategico = int.Parse(lblID.Text);

                    System.Data.DataSet dsResultado = ejeL.Actualizar(ejeE,Session["usuario"].ToString());

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());
                    else
                    {
                        this.lblSuccess.Visible = true;
                        this.lblSuccess.Text = "El registro fue actualizado correctamente. ";
                        lblError.Text = "";
                        lblError.Visible = false;
                        btnModificar.Visible = false;
                    }
                }
                catch (Exception ex)
                {

                    this.lblError.Visible = true;
                    this.lblError.Text = "Error al actualizar el registro. " + ex.Message;
                    this.lblSuccess.Visible = false;
                    this.lblSuccess.Text = "";
                }
            }
        }

        private bool validarControlesInsertar()
        {
            bool controlesValidos = false;
            lblErrorAnio.Text = string.Empty;

            try
            {
                if (ddlPlanesE.SelectedValue.Equals("0") || ddlPlanesE.Items.Count == 0)
                    lblErrorAnio.Text = "Seleccione un valor!";

                if (!lblErrorAnio.Text.Equals(string.Empty))
                    return controlesValidos;

                this.Page.Validate("grpDatos");
                controlesValidos = Page.IsValid;
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesInsertar(). " + ex.Message);
            }

            return controlesValidos;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ejeL = new EjesLN();
            ejeE = new EjesEN();

            try
            {
                ejeE.Id_Eje_Estrategico = int.Parse(lblID.Text);

                System.Data.DataSet dsResultado = ejeL.Eliminar(ejeE,Session["usuario"].ToString());

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());
                else
                {
                    this.lblSuccess.Visible = true;
                    this.lblSuccess.Text = "El registro fue eliminado correctamente. ";
                    lblError.Text = "";
                    lblError.Visible = false;
                    btnEliminar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                this.lblError.Visible = true;
                this.lblError.Text = "Error al eliminar el registro. " + ex.Message;
                this.lblSuccess.Visible = false;
                this.lblSuccess.Text = "";
            }
        }

        protected void btnNuevaB_Click(object sender, EventArgs e)
        {
            upBuscar.Visible = true;
            upModificar.Visible = false;
            txtBValor.Focus();

            ejeL = new EjesLN();
            ejeL.GridBusqueda(gridBusqueda);
        }       

    }
}
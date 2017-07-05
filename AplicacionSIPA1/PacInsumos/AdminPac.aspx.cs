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

namespace AplicacionSIPA1.PacInsumos
{
    public partial class AdminPac : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private PlanAnualEN pAnualEN;
        private DataSet dsPacDet;

        public DataSet dsPac
        {
            get
            {
                object o = ViewState["dsPac"];
                return (DataSet)o;
            }
            set { ViewState["dsPac"] = value; }
        }
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    NuevoEncabezadoPoa();
                    NuevaAccion();
                    NuevoPacEnc();
                    NuevoPacDet();


                    /*LogeoLN llenarMenu = new LogeoLN();
                    llenarMenu.LlenarMenu(this.Menu1, this.Session["Usuario"].ToString());
                    lblNoPedido.Text = Convert.ToString(Request.QueryString["No"]);
                    lblMonto.Text = Convert.ToString(Request.QueryString["monto"]);
                    lblMensaje.Text = Convert.ToString(Request.QueryString["msg"]);*/
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        public void NuevoEncabezadoPoa()
        {
            try
            {
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pAccionLN = new PlanAccionLN();
                pAnualLN = new PlanAnualLN();

                pEstrategicoLN.DdlPlanes(ddlPlanes);

                int idPlan = 0;
                int anioIni = 0;
                int anioFin = 0;
                if (ddlPlanes.Items.Count == 2)
                {
                    ddlPlanes.SelectedIndex = 1;
                    idPlan = int.Parse(ddlPlanes.SelectedValue);
                    anioIni = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[0].Trim());
                    anioFin = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[1].Trim());
                    lblPlanE.Visible = false;
                    ddlPlanes.Visible = false;
                }
                pEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                ddlAnios.Items.RemoveAt(0);

                int anioActual = DateTime.Now.Year;

                ListItem item = ddlAnios.Items.FindByValue(anioActual.ToString());
                if (item != null)
                    ddlAnios.SelectedValue = anioActual.ToString();

                //string usuario = Session["Usuario"].ToString().ToLower();
                //pOperativoLN.DdlUnidades(ddlUnidades, usuario);
                UsuariosLN userLN = new UsuariosLN();
                userLN.dropUnidad(ddlUnidades);
                //pAccionLN.DdlDependencias(ddlDependencias, usuario, 0);

                if (ddlUnidades.Items.Count == 1)
                {
                    pAccionLN.DdlDependencias(ddlDependencias, Session["usuario"].ToString(), int.Parse(ddlUnidades.SelectedValue));
                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void NuevaAccion()
        {
            try
            {
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, 0);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                filtrarGridDetallesAccion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void NuevoPacEnc()
        {
            try
            {
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pAccionLN = new PlanAccionLN();
                pAnualLN = new PlanAnualLN();

                pAnualLN.DdlPac(ddlPac, 0);
                ddlPac.Items[0].Text = "<< Nuevo Ingreso >>";

                pAnualLN.DdlCategorias(ddlCategorias, "0");
                pAnualLN.DdlExcepciones(ddlExcepciones);
                pAnualLN.DdlModalidades(ddlModalidades);
                txtDescripcion.Text = string.Empty;

                lblTechoP.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
                lblCodificadoP.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
                lblDisponibleP.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void NuevoPacDet()
        {
            try
            {
                dsPacDet = armarDsDet();

                for (int index = 1; index <= 12; index++)
                {
                    DataRow Agregar = dsPacDet.Tables[0].NewRow();
                    Agregar["id"] = index;
                    Agregar["Mes"] = nombreMes(index);
                    Agregar["Cantidad"] = string.Empty;
                    Agregar["Monto"] = string.Empty;
                    Agregar["Subtotal"] = string.Empty;
                    dsPacDet.Tables[0].Rows.Add(Agregar);
                }

                gridDet.DataSource = dsPacDet.Tables[0];
                gridDet.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected DataSet armarDsDet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("id", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Mes", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Cantidad", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Monto", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Subtotal", Type.GetType("System.String"));

            return ds;
        }

        public string nombreMes(int mes)
        {
            DateTimeFormatInfo conver = new CultureInfo("es-ES", false).DateTimeFormat;
            return conver.GetMonthName(mes);
        }

        protected void filtrarGridDetallesAccion()
        {
            gridRenglon.SelectedIndex = -1;

            pAnualLN = new PlanAnualLN();
            int idAccion = 0;
            int.TryParse(ddlAcciones.SelectedValue, out idAccion);
            pAnualLN.GridDetallesAccion(gridRenglon, idAccion);

            if (gridRenglon.Rows.Count == 1)
            {
                gridRenglon.SelectedIndex = 0;
                //gridRenglon_SelectedIndexChanging(sender, e);
                string noRenglon = gridRenglon.DataKeys[0].Values["NO_RENGLON"].ToString();


                int idDetalleAccion = 0;
                int.TryParse(gridRenglon.SelectedValue.ToString(), out idDetalleAccion);

                pAnualLN = new PlanAnualLN();
                pAnualLN.DdlPac(ddlPac, idDetalleAccion);
                ddlPac.Items[0].Text = "<< Nuevo Ingreso >>";
                pAnualLN.DdlCategorias(ddlCategorias, noRenglon);
            }

            /*if (gridRenglon.Rows.Count > 1 && gridRenglon.SelectedIndex > -1)
            {
                string filtro = string.Empty;

                object obj = gridRenglon.DataSource;
                System.Data.DataTable tbl = gridRenglon.DataSource as System.Data.DataTable;
                System.Data.DataView dv = tbl.DefaultView;

                filtro = " anio = " + ddlAnios.SelectedValue;

                string id = gridRenglon.SelectedValue.ToString();
                if (!id.Equals(string.Empty))
                    filtro += " AND id = " + id;

                dv.RowFilter = filtro;

                gridRenglon.DataSource = dv;
                gridRenglon.DataBind();
            }*/
        }

        /*protected void filtrarDetalleAccion()
        {
            pAnualLN = new PlanAnualLN();
            int idAccion = 0;
            int.TryParse(ddlAcciones.SelectedValue, out idAccion);
            pAnualLN.GridDetallesAccion(gridRenglon, idAccion);

            if (gridRenglon.Rows.Count > 1 && gridRenglon.SelectedIndex > -1)
            {
                string filtro = string.Empty;

                object obj = gridRenglon.DataSource;
                System.Data.DataTable tbl = gridRenglon.DataSource as System.Data.DataTable;
                System.Data.DataView dv = tbl.DefaultView;

                string id = gridRenglon.SelectedValue.ToString();
                if (!id.Equals(string.Empty))
                    filtro += " id = " + id;

                dv.RowFilter = filtro;

                gridRenglon.DataSource = dv;
                gridRenglon.DataBind();

                if (gridRenglon.Rows.Count == 1)
                    gridRenglon.SelectedIndex = 0;
            }
        }*/

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevaAccion();
                NuevoPacEnc();
                NuevoPacDet();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoa(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";
                    
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void limpiarControlesError()
        {
            lblErrorAccion.Text = lblErrorAnio.Text = lblErrorCategoria.Text = lblErrorDependencia.Text = lblErrorModalidad.Text = string.Empty;
            lblErrorDetalles.Text = lblErrorPac.Text = lblErrorPlan.Text = lblErrorUnidad.Text = string.Empty;
            lblErrorDetalles.Text = lblError.Text = lblSuccess.Text = string.Empty;
        }

        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                if (ddlAnios.SelectedValue.Equals("0") || ddlAnios.Items.Count == 0)
                {
                    lblErrorAnio.Text = "*";
                    lblError.Text += "Seleccione un año. ";
                }

                if (ddlPlanes.SelectedValue.Equals("0") || ddlPlanes.Items.Count == 0)
                {
                    lblErrorPlan.Text = "*";
                    lblError.Text += "Seleccione un plan. ";
                }

                if (ddlUnidades.SelectedValue.Equals("0") || ddlUnidades.Items.Count == 0)
                {
                    lblErrorUnidad.Text = "*";
                    lblError.Text += "Seleccione una unidad. ";
                }

                if (ddlAcciones.SelectedValue.Equals("0") || ddlAcciones.Items.Count == 0)
                {
                    lblErrorAccion.Text = "*";
                    lblError.Text += "Seleccione una acción. ";
                }

                if (ddlModalidades.SelectedValue.Equals("0") || ddlModalidades.Items.Count == 0)
                {
                    lblErrorModalidad.Text = "*";
                    lblError.Text += "Seleccione una modalidad. ";
                }

                if(gridRenglon.SelectedIndex < 0)
                {
                    //lblErrorModalidad.Text = "*";
                    lblError.Text += "Seleccione un Renglón. ";
                }
                
                if ((ddlCategorias.SelectedValue.Equals("0") || ddlCategorias.Items.Count == 0))
                {
                    lblErrorCategoria.Text = "*";
                    lblError.Text += "Seleccione una categoría. ";
                }


                rfvDescripcion.Enabled = true;
                rfvDescripcion.Validate();
                if (!rfvDescripcion.IsValid)
                    lblError.Text += "Ingrese una descripción";

                if(txtDescripcion.Text.Length < 40)
                    lblError.Text += "Ingrese por lo menos 40 caracteres en la descripción";
                
                bool valido = true;
                int vacios = 0;
                double totalQ = 0;
                double totalC = 0;
                for (int i = 0; i < gridDet.Rows.Count; i++)
                {
                    string cantidad = ((TextBox)(gridDet.Rows[i].FindControl("txtCantidad"))).Text;
                    string monto = ((TextBox)(gridDet.Rows[i].FindControl("txtMonto"))).Text;
                    int c;
                    double m;

                    if (!cantidad.Equals(string.Empty) || !monto.Equals(string.Empty))
                    {
                        if (int.TryParse(cantidad, out c) && double.TryParse(monto, out m))
                            if (c < 1 || m < 1)
                            {
                                valido = false;
                                ((Label)(gridDet.Rows[i].FindControl("lblObservaciones"))).Text = "Ingrese cantidad y monto válido";
                            }
                            else
                            {
                                //((Label)(gridDet.Rows[i].FindControl("lblSubtotal"))).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", c * m);
                                //total += c * m;
                                totalQ += m;
                                totalC += c;
                            }
                    }
                    else
                        vacios++;
                }
                if (vacios == 12)
                    lblErrorDetalles.Text = "Ingrese por lo menos un mes";

                if (!valido)
                    lblErrorDetalles.Text = "Error en los detalles del PAC";
                else
                {
                    gridDet.FooterRow.Cells[1].Text = "Total (Q): ";
                    gridDet.FooterRow.Cells[2].Text = totalC.ToString();
                    gridDet.FooterRow.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", totalQ);
                }

                if (lblError.Text.Equals(string.Empty) && lblErrorDetalles.Text.Equals(string.Empty))
                    controlesValidos = true;

                this.Page.Validate("grpDatos");

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

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevaAccion();
                NuevoPacEnc();
                NuevoPacDet();

                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoa(idUnidad, anio);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);
                pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios_SelectedIndexChanged(). " + ex.Message;
            }
        }



        protected bool validarPoa(int idUnidad, int anio)
        {
            bool poaValido = false;
            btnGuardar.Visible = false;
            lblIdPoa.Text = "0";
            try
            {                
                pOperativoLN = new PlanOperativoLN();                
                DataSet dsPoa = pOperativoLN.DatosPoaUnidad(idUnidad, anio);
                
                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                string estadoPoa = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString();
                
                lblEstadoPoa.Text = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString() + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString();

                int idPoa = int.Parse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString());
                lblIdPoa.Text = idPoa.ToString();

                if (!estadoPoa.Equals("8"))
                    lblErrorPac.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString();
                else
                    btnGuardar.Visible = true;

                poaValido = true;
            }
            catch (Exception ex)
            {
                lblErrorPac.Text = lblError.Text = "Error: " + ex.Message;
            }
            btnGuardar.Visible = true;
            return poaValido;
            
        }

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoPacEnc();
                NuevoPacDet();
                filtrarGridDetallesAccion();                
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones_SelectedIndexChanged(). " + ex.Message;
            }
        }


        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*limpiarControlesError();
            int anio = int.Parse(ddlAnios.SelectedValue);
            int idDependencia = int.Parse(ddlDependencias.SelectedValue);
            pAccionLN = new PlanAccionLN();
            
            //pAccionLN.DdlAcciones_x_Dependencia(ddlAcciones, anio, idDependencia);
            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
            ddlAcciones.Items[0].Text = "<< Elija un valor >>";*/
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void ddlModalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlExcepciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                pAnualEN = new PlanAnualEN();
                if (validarControlesABC())
                {
                    dsPac = pAnualEN.armarDsPac();
                    DataRow dr = dsPac.Tables["ENC"].NewRow();

                    int idDetalleAccion = 0;
                    int idPac = 0;

                    int.TryParse(gridRenglon.SelectedValue.ToString(), out idDetalleAccion);
                    int.TryParse(ddlPac.SelectedValue, out idPac);

                    dr["ID_PAC"] = idPac;
                    dr["ID_DETALLE"] = idDetalleAccion;
                    dr["ID_MODALIDAD"] = ddlModalidades.SelectedValue;
                    dr["ID_CATEGORIA"] = ddlCategorias.SelectedValue;
                    dr["ID_EXCEPCION"] = ddlExcepciones.SelectedValue;
                    dr["DESCRIPCION"] = txtDescripcion.Text;
                    dr["ANIO"] = ddlAnios.SelectedValue;
                    dr["USUARIO"] = Session["USUARIO"];
                    dsPac.Tables["ENC"].Rows.Add(dr);

                    string c, m = "";
                    int cantidad = 0;
                    decimal monto = 0;
                    decimal total = 0;
                    for (int i = 0; i < gridDet.Rows.Count; i++)
                    {
                        c = ((TextBox)(gridDet.Rows[i].FindControl("txtCantidad"))).Text;
                        cantidad = c == string.Empty ? 0 : int.Parse(c);
                        m = ((TextBox)(gridDet.Rows[i].FindControl("txtMonto"))).Text;
                        monto = c == string.Empty ? 0 : decimal.Parse(m);
                        //total += (cantidad * monto);
                        total += monto;

                        dr = dsPac.Tables["DET"].NewRow();
                        dr["ID_DETALLE"] = "0";
                        dr["ID_PAC"] = "";
                        dr["MES"] = i + 1;
                        dr["CANTIDAD"] = cantidad;
                        dr["MONTO"] = monto;
                        dr["USUARIO"] = Session["USUARIO"];
                        dsPac.Tables["DET"].Rows.Add(dr);
                    }

                    int idAccion = int.Parse(ddlAcciones.SelectedValue);
                    //int idPac = int.Parse(Session["ID_PAC"].ToString());

                    if (ValidarPpto(idDetalleAccion, idPac, total))
                    {
                        pAnualLN = new PlanAnualLN();
                        DataSet dsResultado = pAnualLN.AlmacenarPac(dsPac);

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ el PAC: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        btnNuevo_Click(sender, e);

                        string noPac = dsResultado.Tables[0].Rows[0]["VALOR"].ToString();
                        //lblSuccess.Text = "Plan Anual de Compras ALMACENADO exitosamente, número de Pac: " + noPac;

                        Response.Redirect("NoPlan.aspx?No=" + Convert.ToString(noPac) + "&monto=" + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", total) + "&msg=CREADO/ACTUALIZADO");
                    }               

                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar_Click(). " + ex.Message;
            }
        }

        protected bool ValidarPpto(int idDetalleAccion, int idPac, decimal totalPac)
        {
            pAccionLN = new PlanAccionLN();
            pAnualLN = new PlanAnualLN();
            bool pptoValido = false;

            //DataSet dsPptoAccion = pAccionLN.PptoAccion(idAccion);
            DataSet dsPptoRenglon = pAnualLN.InformacionRenglonAccion(idDetalleAccion);
            DataSet dsPptoPac = pAnualLN.InformacionPac(idPac);

            if (bool.Parse(dsPptoRenglon.Tables[0].Rows[0]["ERRORES"].ToString()))
                throw new Exception("No se consultó el presupuesto del Renglón: " + dsPptoRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

            if (bool.Parse(dsPptoPac.Tables[0].Rows[0]["ERRORES"].ToString()))
                throw new Exception("No se consultó el presupuesto del Plan: " + dsPptoRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

            decimal saldoRenglon = 0;
            decimal codificadoPac = 0;
            decimal montoActualPac = 0;

            decimal.TryParse(dsPptoRenglon.Tables["BUSQUEDA"].Rows[0]["SALDO_PAC"].ToString(), out saldoRenglon);
            decimal.TryParse(dsPptoPac.Tables["ENCABEZADO"].Rows[0]["MONTO"].ToString(), out montoActualPac);

            decimal diferenciaRenglonMontoN = (saldoRenglon + montoActualPac) - totalPac;
            if(diferenciaRenglonMontoN < 0)
                throw new Exception("El monto máximo debe ser igual o menor al monto disponible: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (saldoRenglon + montoActualPac)));


            decimal.TryParse(dsPptoPac.Tables["ENCABEZADO"].Rows[0]["CODIFICADO"].ToString(), out codificadoPac);
            decimal diferenciaCodificadoMontoN = totalPac - codificadoPac; 
            if (diferenciaCodificadoMontoN < 0)
                throw new Exception("El monto mínimo debe ser igual o mayor al monto codificado/comprometido: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", codificadoPac));
                
            pptoValido = true;
            return pptoValido;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoEncabezadoPoa();
                NuevoPacEnc();
                NuevoPacDet();
                NuevaAccion();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo_Click(). " + ex.Message;
            }
        }

        protected void btnNuevaB_Click(object sender, EventArgs e)
        {

        }

        protected void gridDet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*protected void gridPac_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                limpiarControlesError();
                
                int idPac = Convert.ToInt32(e.Keys["ID"].ToString());

                pAnualLN = new PlanAnualLN();
                DataSet dsResultado = pAnualLN.EliminarPac(idPac);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se ELIMINÓ el PAC: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                btnNuevo_Click(sender, e);

                lblSuccess.Text = "Plan ELIMINADO correctamente, número de PAC: " + idPac;
                lblError.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblError.Text = "gridPac(). " + ex.Message;
            }           

        }*/

        protected void gridRenglon_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*try
            {
                limpiarControlesError();
                NuevoPacEnc();
                NuevoPacDet();



            }
            catch (Exception ex)
            {
                lblError.Text = "gridRenglon_SelectedIndexChanged(). " + ex.Message;
            }  */          
        }

        protected void gridRenglon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridRenglon.PageIndex = e.NewPageIndex;
                filtrarGridDetallesAccion();
            }
            catch (Exception ex)
            {
                lblError.Text = "gridRenglon_PageIndexChanging(). " + ex.Message;
            }
        }

        protected void gridRenglon_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoPacEnc();
                NuevoPacDet();
                //filtrarDetalleAccion();

                int i = e.NewSelectedIndex;
                string noRenglon = gridRenglon.DataKeys[i].Values["NO_RENGLON"].ToString();
                
                pAnualLN = new PlanAnualLN();
                pAnualLN.DdlCategorias(ddlCategorias, noRenglon);

                int idDetalleAccion = 0;
                int.TryParse(gridRenglon.DataKeys[i].Values["ID"].ToString(), out idDetalleAccion);

                pAnualLN = new PlanAnualLN();
                pAnualLN.DdlPac(ddlPac, idDetalleAccion);
                ddlPac.Items[0].Text = "<< Nuevo Ingreso >>";
            }
            catch (Exception ex)
            {
                lblError.Text = "gridRenglon_PageIndexChanging(). " + ex.Message;
            }
            
        }

        protected void ddlPac_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                
                int idPac = 0;
                int.TryParse(ddlPac.SelectedValue, out idPac);

                NuevoPacEnc();
                NuevoPacDet();

                pAnualLN = new PlanAnualLN();

                int idDetalleAccion = 0;
                int.TryParse(gridRenglon.SelectedValue.ToString(), out idDetalleAccion);

                pAnualLN.DdlPac(ddlPac, idDetalleAccion);
                ddlPac.Items[0].Text = "<< Nuevo Ingreso >>";
                ddlPac.SelectedValue = idPac.ToString();

                if (idPac > 0)
                {
                    DataSet dsResultado = pAnualLN.InformacionPac(idPac);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se CONSULTÓ el PAC: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    int idModalidad = 0;
                    int idCategoria = 0;
                    int idExcepcion = 0;
                    string noRenglon = string.Empty;
                    string descripcion = string.Empty;
                    int cantidadDetalle = 0;
                    decimal monto = 0;
                    decimal codificado = 0;
                    decimal saldo = 0;

                    noRenglon = dsResultado.Tables["ENCABEZADO"].Rows[0]["NO_RENGLON"].ToString();
                    pAnualLN.DdlCategorias(ddlCategorias, noRenglon);

                    int.TryParse(dsResultado.Tables["ENCABEZADO"].Rows[0]["ID_MODALIDAD"].ToString(), out idModalidad);
                    int.TryParse(dsResultado.Tables["ENCABEZADO"].Rows[0]["ID_CATEGORIA"].ToString(), out idCategoria);
                    int.TryParse(dsResultado.Tables["ENCABEZADO"].Rows[0]["ID_EXCEPCION"].ToString(), out idExcepcion);
                    descripcion = dsResultado.Tables["ENCABEZADO"].Rows[0]["DESCRIPCION"].ToString();
                    int.TryParse(dsResultado.Tables["ENCABEZADO"].Rows[0]["CANTIDAD"].ToString(), out cantidadDetalle);
                    decimal.TryParse(dsResultado.Tables["ENCABEZADO"].Rows[0]["MONTO"].ToString(), out monto);
                    decimal.TryParse(dsResultado.Tables["ENCABEZADO"].Rows[0]["CODIFICADO"].ToString(), out codificado);
                    decimal.TryParse(dsResultado.Tables["ENCABEZADO"].Rows[0]["SALDO"].ToString(), out saldo);


                    ddlModalidades.SelectedValue = idModalidad.ToString();
                    ddlCategorias.SelectedValue = idCategoria.ToString();
                    ddlExcepciones.SelectedValue = idExcepcion.ToString();
                    txtDescripcion.Text = descripcion;
                    lblTechoP.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", monto);
                    lblCodificadoP.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", codificado);
                    lblDisponibleP.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", saldo);

                    dsPacDet = armarDsDet();

                    for (int index = 1; index <= 12; index++)
                    {
                        int cantidad = 0;
                        decimal montoMes = 0;

                        int.TryParse(dsResultado.Tables["DETALLES"].Rows[index - 1]["CANTIDAD"].ToString(), out cantidad);
                        decimal.TryParse(dsResultado.Tables["DETALLES"].Rows[index - 1]["MONTO"].ToString(), out montoMes);

                        DataRow Agregar = dsPacDet.Tables[0].NewRow();
                        Agregar["id"] = index;
                        Agregar["Mes"] = nombreMes(index);
                        Agregar["Cantidad"] = string.Empty;
                        Agregar["Monto"] = string.Empty;
                        Agregar["Subtotal"] = string.Empty;

                        if (cantidad > 0)
                            Agregar["Cantidad"] = cantidad;

                        if(montoMes > 0)
                            Agregar["Monto"] = montoMes;

                        dsPacDet.Tables[0].Rows.Add(Agregar);
                    }

                    gridDet.DataSource = dsPacDet.Tables[0];
                    gridDet.DataBind();

                    gridDet.FooterRow.Cells[1].Text = "Total (Q): ";
                    gridDet.FooterRow.Cells[2].Text = cantidadDetalle.ToString();
                    gridDet.FooterRow.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", monto);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlPac_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void btnListadoPac_Click(object sender, EventArgs e)
        {

        }
    }
}
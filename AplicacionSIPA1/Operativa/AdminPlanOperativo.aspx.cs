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

namespace AplicacionSIPA1.Operativa
{
    public partial class AdminPlanOperativo : System.Web.UI.Page
    {
        private PlanEstrategicoLN planEstrategicoLN = new PlanEstrategicoLN();
        
        private PlanOperativoLN planOperativoLN;
        private ObjOperativosEN objetivosEN;
        private IndOperativosEN indicadoresEN;
        private MetasOperativasEN metasEN;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    btnNuevo_Click(sender, e);
                    /*upModificar.Visible = false;
                    lblErrorBusqueda.Text = string.Empty;

                    planOperativoLN = new PlanOperativoLN();

                    planEstrategicoLN = new PlanEstrategicoLN();
                    planEstrategicoLN.DdlPlanes(ddlBPlanes);

                    int idPlan = 0;
                    int anioIni = 0;
                    int anioFin = 0;


                    if (ddlBPlanes.Items.Count == 2)
                    {
                        ddlBPlanes.SelectedIndex = 1;
                        idPlan = int.Parse(ddlBPlanes.SelectedValue);
                        anioIni = int.Parse(ddlBPlanes.SelectedItem.Text.Split('-')[0].Trim());
                        anioFin = int.Parse(ddlBPlanes.SelectedItem.Text.Split('-')[1].Trim());

                        lblBPlan.Visible = false;
                        ddlBPlanes.Visible = false;
                    }

                    planEstrategicoLN.DdlAniosPlan(ddlBAnio, anioIni, anioFin);
                    
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlUnidades(ddlBUnidades, Session["Usuario"].ToString().ToLower());
                    
                    planOperativoLN.DdlObjetivosB(ddlBObjetivos, 0, 0);
                    planOperativoLN.DdlIndicadores(ddlBIndicadores, 0, 0);

                    ddlBAnio.Items[0].Text = "<< Elija un valor >>";
                    ddlBUnidades.Items[0].Text = "<< Elija un valor >>";
                    ddlBObjetivos.Items[0].Text = "<< Elija un valor >>";
                    ddlBIndicadores.Items[0].Text = "<< Elija un valor >>";

                    //planOperativoLN.GridBusqueda(gridBusqueda, Session["Usuario"].ToString().ToLower());
                    gridBusqueda.DataSource = null;
                    gridBusqueda.DataBind();*/


                }
                catch (Exception ex)
                {
                    lblErrorBusqueda.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void ddlBAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblErrorBusqueda.Text = string.Empty;
                planOperativoLN = new PlanOperativoLN();
                int anio = int.Parse(ddlBAnio.SelectedValue);
                int idUnidad = int.Parse(ddlBUnidades.SelectedValue);
                
                planOperativoLN.DdlObjetivosB(ddlBObjetivos, anio, idUnidad);
                planOperativoLN.DdlIndicadores(ddlBIndicadores, 0, 0);

                ddlBObjetivos.Items[0].Text = "<< Elija un valor >>";
                ddlBIndicadores.Items[0].Text = "<< Elija un valor >>";

                filtrarGridBusqueda();

            }
            catch (Exception ex)
            {
                lblErrorBusqueda.Text = "ddlBAnio_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlBUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblErrorBusqueda.Text = string.Empty;
                planOperativoLN = new PlanOperativoLN();
                int anio = int.Parse(ddlBAnio.SelectedValue);
                int idUnidad = int.Parse(ddlBUnidades.SelectedValue);

                planOperativoLN.DdlObjetivosB(ddlBObjetivos, anio, idUnidad);
                planOperativoLN.DdlIndicadores(ddlBIndicadores, 0, 0);

                ddlBObjetivos.Items[0].Text = "<< Elija un valor >>";
                ddlBIndicadores.Items[0].Text = "<< Elija un valor >>";

                filtrarGridBusqueda();
            }
            catch (Exception ex)
            {
                lblErrorBusqueda.Text = "ddlBUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }
        
        protected void ddlBObjetivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblErrorBusqueda.Text = string.Empty;
                planOperativoLN = new PlanOperativoLN();
                
                int idObjetivo = int.Parse(ddlBObjetivos.SelectedValue);
                //planOperativoLN.DdlIndicadores(ddlBIndicadores, idObjetivo, );

                ddlBObjetivos.Items[0].Text = "<< Elija un valor >>";
                ddlBIndicadores.Items[0].Text = "<< Elija un valor >>";

                filtrarGridBusqueda();
            }
            catch (Exception ex)
            {
                lblErrorBusqueda.Text = "ddlBObjetivos_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlBIndicadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblErrorBusqueda.Text = string.Empty;

                ddlBObjetivos.Items[0].Text = "<< Elija un valor >>";
                ddlBIndicadores.Items[0].Text = "<< Elija un valor >>";

                filtrarGridBusqueda();
            }
            catch (Exception ex)
            {
                lblErrorBusqueda.Text = "ddlBIndicadores_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                upBuscar.Visible = false;
                upModificar.Visible = true;

                planEstrategicoLN = new PlanEstrategicoLN();
                planEstrategicoLN.DdlPlanes(ddlPlanes);
                lblEstadoPoa.Text = string.Empty;

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
                planEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                planEstrategicoLN.DdlEjes(ddlEjes, idPlan);
                planEstrategicoLN.DdlObjetivos_X_Eje(ddlObjetivosE, 0);
                

                int anioActual = (DateTime.Now.Year + 1);

                ListItem item = ddlAnios.Items.FindByValue(anioActual.ToString());
                if (item != null)
                    ddlAnios.SelectedValue = anioActual.ToString();

                planEstrategicoLN.DdlMetas_X_Obj_Estr(ddlMetasE, 0, anioActual);

                ddlObjetivosE.Items[0].Text = "<< Elija un valor >>";
                ddlMetasE.Items[0].Text = "<< Elija un valor >>";

                planOperativoLN = new PlanOperativoLN();
                planOperativoLN.DdlUnidades(ddlUnidades);
                planOperativoLN.DdlProcesos(ddlProcesos);
                lblIdPoa.Text = string.Empty;

                gridPlanE.DataSource = null;
                gridPlanE.DataBind();

                limpiarCNuevoObjetivo();
                limpiarCNuevoIndicador();
                limpiarCNuevaMeta();

                lblResponsable.Text = string.Empty;
                if (ddlUnidades.Items.Count == 1)
                {
                    lblResponsable.Text = ddlUnidades.Items[0].Text;
                    
                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                        //planOperativoLN.DdlObjetivosB(ddlObjetivos, int.Parse(ddlAnios.SelectedValue), int.Parse(ddlUnidades.SelectedValue));
                        //ddlObjetivos.Items[0].Text = "<< Elija un valor >>";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo_Click()" + ex.Message;
            }
        }

        protected void gridBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
            upBuscar.Visible = false;
            upModificar.Visible = true;

            try
            {
                string idBuscar = gridBusqueda.SelectedValue.ToString();

                planEstrategicoLN = new PlanEstrategicoLN();
                planOperativoLN = new PlanOperativoLN();
                System.Data.DataSet ds = planOperativoLN.BuscarId(idBuscar);

                if (bool.Parse(ds.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                int idPlan = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_PLAN"].ToString());
                int idEje = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_EE"].ToString());
                int idObjetivoE = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_OE"].ToString());
                int idKpiE = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_KPI_E"].ToString());
                int idMetaE = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_ME"].ToString());
                int idObjetivoO = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_OO"].ToString());
                int idKpiO = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_KPI_O"].ToString());
                int idMetaO = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_MO"].ToString());
                int idUnidad = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_UA"].ToString());
                int anio = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ANIO"].ToString());
                int anioIni = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ANIO_INI"].ToString());
                int anioFin = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ANIO_FIN"].ToString());

                planEstrategicoLN.DdlPlanes(ddlPlanes);
                planEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                
                planOperativoLN.DdlUnidades(ddlUnidades);
                planOperativoLN.DdlProcesos(ddlProcesos);
                
                planEstrategicoLN.DdlEjes(ddlEjes, idPlan);
                planEstrategicoLN.DdlObjetivos_X_Eje(ddlObjetivosE, idEje);
                planEstrategicoLN.GridBusqueda(gridPlanE);
                
                planOperativoLN.DdlObjetivos(ddlObjetivosO, idObjetivoE, idUnidad, anio);
                planOperativoLN.DdlIndicadores(ddlIndicadores, idObjetivoO, idMetaE);
                planOperativoLN.DdlMetas(ddlMetas, idKpiO);

                ddlPlanes.SelectedValue = idPlan.ToString();
                ddlPlanes_SelectedIndexChanged(sender, e);
                
                ddlAnios.SelectedValue = anio.ToString();
                ddlAnios_SelectedIndexChanged(sender, e);
                
                ddlUnidades.SelectedValue = idUnidad.ToString();
                ddlUnidades_SelectedIndexChanged(sender, e);
                
                ddlProcesos.SelectedValue = "1";
                ddlEjes.SelectedValue = idEje.ToString();
                ddlObjetivosE.SelectedValue = idObjetivoE.ToString();
                filtrarGridPlanE(idMetaE.ToString());
                
                gridPlanE.SelectedIndex = 0;

                ddlObjetivosO.SelectedValue = idObjetivoO.ToString();
                ddlObjetivosO_SelectedIndexChanged(sender, e);

                ddlIndicadores.SelectedValue = idKpiO.ToString();
                ddlIndicadores_SelectedIndexChanged(sender, e);

                ddlMetas.SelectedValue = idMetaO.ToString();
                ddlMetas_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar los datos: " + ex.Message;
            }
        }

        protected void gridBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridBusqueda.PageIndex = e.NewPageIndex;
                filtrarGridBusqueda();
            }
            catch (Exception ex)
            {
                lblErrorBusqueda.Text = "gridBusqueda_PageIndexChanging(). " + ex.Message;
            }
        }

        protected void limpiarCNuevoObjetivo()
        {
            planOperativoLN = new PlanOperativoLN();
            planOperativoLN.DdlObjetivosxMeta(ddlObjetivosO, 0, 0);
            txtCodigo.Text = txtObjetivo.Text = string.Empty;
            txtCodigo.Enabled = false;
            rfvCodigo.Enabled = rfvObjetivo.Enabled = false;
        }

        protected void limpiarCNuevoIndicador()
        {
            planOperativoLN = new PlanOperativoLN();
            planOperativoLN.DdlIndicadores(ddlIndicadores, 0);
            txtIndicador.Text = string.Empty;
            rfvIndicador.Enabled = false;
        }

        protected void limpiarCNuevaMeta()
        {
            planOperativoLN = new PlanOperativoLN();
            planOperativoLN.DdlMetas(ddlMetas, 0);
            txtMeta.Text = string.Empty;
            rfvMeta.Enabled = false;
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                int anio = int.Parse(ddlAnios.SelectedValue);
                int idUnidad = int.Parse(ddlUnidades.SelectedValue);

                btnNuevo_Click(sender, e);
                ddlPlanes.SelectedValue = idPlan.ToString();
                ddlAnios.SelectedValue = anio.ToString();               

                btnGuardar.Visible = false;
                lblResponsable.Text = string.Empty;

                if (idUnidad > 0)
                {
                    ddlUnidades.SelectedValue = idUnidad.ToString();
                    lblResponsable.Text = ddlUnidades.SelectedItem.Text;
                    if (anio > 0 && idUnidad > 0)
                        validarPoa(idUnidad, anio);
                }                            
                    
                /*
                limpiarControlesError();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                int anio = int.Parse(ddlAnios.SelectedValue);
                int idUnidad = int.Parse(ddlUnidades.SelectedValue);

                btnNuevo_Click(sender, e);
                
                lblResponsable.Text = string.Empty;
                btnGuardar.Visible = false;
              
                if (idUnidad > 0)
                {
                    planEstrategicoLN = new PlanEstrategicoLN();
                    planEstrategicoLN.DdlPlanes(ddlPlanes);
                    ddlPlanes.SelectedValue = idPlan.ToString();

                    int anioIni = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[0].Trim());
                    int anioFin = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[1].Trim());

                    planEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                    planEstrategicoLN.DdlEjes(ddlEjes, idPlan);

                    ddlAnios.SelectedValue = anio.ToString();
                    ddlUnidades.SelectedValue = idUnidad.ToString();

                    if (anio > 0)
                        if (!validarPoa(idUnidad, anio))
                            btnGuardar.Visible = false;
                        else
                            btnGuardar.Visible = true;

                    lblResponsable.Text = ddlUnidades.SelectedItem.Text;
                }*/
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }


        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                int anio = int.Parse(ddlAnios.SelectedValue);
                int idUnidad = int.Parse(ddlUnidades.SelectedValue);

                btnNuevo_Click(sender, e);
                ddlPlanes.SelectedValue = idPlan.ToString();
                ddlUnidades.SelectedValue = idUnidad.ToString();

                btnGuardar.Visible = false;
                if (anio > 0)
                {
                    ddlAnios.SelectedValue = anio.ToString();
                    if (anio > 0 && idUnidad > 0)
                        validarPoa(idUnidad, anio);
                }

                /*btnGuardar.Visible = false;
                if (anio > 0)
                {
                    planEstrategicoLN = new PlanEstrategicoLN();
                    planEstrategicoLN.DdlPlanes(ddlPlanes);
                    ddlPlanes.SelectedValue = idPlan.ToString();
                    
                    int anioIni = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[0].Trim());
                    int anioFin = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[1].Trim());

                    planEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                    planEstrategicoLN.DdlEjes(ddlEjes, idPlan);

                    ddlAnios.SelectedValue = anio.ToString();
                    ddlUnidades.SelectedValue = idUnidad.ToString();

                    if (idUnidad > 0)
                        if (!validarPoa(idUnidad, anio))
                            btnGuardar.Visible = false;
                        else
                            btnGuardar.Visible = true;
                }*/
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            planOperativoLN = new PlanOperativoLN();
            objetivosEN = new ObjOperativosEN();
            indicadoresEN = new IndOperativosEN();
            metasEN = new MetasOperativasEN();

            string mensaje = "";
            DataSet dsResultado = new DataSet();
            int idObjetivo = int.Parse(ddlObjetivosO.SelectedValue);
            int idIndicador = int.Parse(ddlIndicadores.SelectedValue);
            int idMeta = int.Parse(ddlMetas.SelectedValue);              

            try
            {
                //INSERTAR/ACTUALIZAR
                if (validarControlesABC())
                {
                    rfvCodigo.Enabled = rfvObjetivo.Enabled = false;
                    rfvIndicador.Enabled = rfvMeta.Enabled = false;

                    objetivosEN.Id_Objetivo_Operativo = idObjetivo;
                    objetivosEN.Id_Objetivo_Estrategico = int.Parse(ddlObjetivosE.SelectedValue);
                    objetivosEN.Id_Meta = int.Parse(gridPlanE.SelectedValue.ToString());
                    objetivosEN.Id_Unidad = int.Parse(ddlUnidades.SelectedValue);

                    if (!txtCodigo.Text.Equals(string.Empty))
                        objetivosEN.Codigo = int.Parse(txtCodigo.Text);

                    FuncionesVarias fv = new FuncionesVarias();
                    string[] ip = fv.DatosUsuarios();
                    objetivosEN.Nombre = txtObjetivo.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                    txtObjetivo.Text = objetivosEN.Nombre;
                    objetivosEN.Anio = int.Parse(ddlAnios.SelectedValue);
                    objetivosEN.Usuario = Session["usuario"].ToString();

                    dsResultado = planOperativoLN.AlmacenarObjetivo(objetivosEN,Session["usuario"].ToString(),ip[0],ip[1],ip[2]);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ el objetivo: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    txtCodigo.Text = dsResultado.Tables[0].Rows[0]["CODIGO"].ToString();
                    txtCodigo.Enabled = true;

                    if (idObjetivo == 0)
                    {
                        mensaje += "Objetivo INSERTADO correctamente. \n";
                    }
                    else
                        mensaje += "Objetivo ACTUALIZADO correctamente. \n";

                    idObjetivo = int.Parse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString());

                    if (!txtIndicador.Text.Equals(string.Empty) && !txtMeta.Text.Equals(string.Empty))
                    {
                        indicadoresEN.Id_Kpi_Operativo = idIndicador;
                        indicadoresEN.Id_Objetivo_Operativo = idObjetivo;
                        indicadoresEN.Id_Meta_Estrategica = int.Parse(gridPlanE.SelectedValue.ToString());
                        indicadoresEN.Nombre = txtIndicador.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                        txtIndicador.Text = indicadoresEN.Nombre;
                        indicadoresEN.Anio = int.Parse(ddlAnios.SelectedValue);
                        indicadoresEN.Usuario = Session["usuario"].ToString();

                        dsResultado = planOperativoLN.AlmacenarIndicador(indicadoresEN);

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ el indicador: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        if (idIndicador == 0)
                            mensaje += "Indicador INSERTADO correctamente. \n";
                        else
                            mensaje += "Indicador ACTUALIZADO correctamente. \n";

                        idIndicador = int.Parse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString());

                        metasEN.Id_Meta_Operativa = idMeta;
                        metasEN.Id_Kpi_Operativo = idIndicador;
                        metasEN.Id_Respondable = int.Parse(ddlUnidades.SelectedValue);
                        metasEN.Nombre = txtMeta.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                        txtMeta.Text = metasEN.Nombre;
                        metasEN.Anio = int.Parse(ddlAnios.SelectedValue);
                        metasEN.Usuario = Session["usuario"].ToString();

                        dsResultado = planOperativoLN.AlmacenarMeta(metasEN,Session["usuario"].ToString());

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ la meta: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());
                        
                        if (idMeta == 0)
                            mensaje += "Meta INSERTADA correctamente. \n";
                        else
                            mensaje += "Meta ACTUALIZADA correctamente. \n";

                        idMeta = int.Parse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString());
                    }

                    lblSuccess.Text = "Operación exitosa! ;-). " + mensaje;
                    
                    ListItem item;
                    int i = 0;
                    if (gridPlanE.SelectedRow != null)
                        i = int.Parse(gridPlanE.SelectedValue.ToString());

                    planOperativoLN.DdlObjetivosxMeta(ddlObjetivosO, i, int.Parse(ddlUnidades.SelectedValue));
                    //planOperativoLN.DdlObjetivos(ddlObjetivosO, int.Parse(ddlObjetivosE.SelectedValue));
                    item = ddlObjetivosO.Items.FindByValue(idObjetivo.ToString());
                    if (item != null)
                        ddlObjetivosO.SelectedValue = idObjetivo.ToString();

                    planOperativoLN.DdlIndicadores(ddlIndicadores, idObjetivo);
                    //planOperativoLN.DdlIndicadores(ddlIndicadores, idObjetivo, int.Parse(gridPlanE.SelectedValue.ToString()));
                    item = ddlIndicadores.Items.FindByValue(idIndicador.ToString());
                    if (item != null)
                        ddlIndicadores.SelectedValue = idIndicador.ToString();

                    planOperativoLN.DdlMetas(ddlMetas, idIndicador);
                    item = ddlMetas.Items.FindByValue(idMeta.ToString());
                    if (item != null)
                        ddlMetas.SelectedValue = idMeta.ToString();
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = mensaje;
                lblError.Text = "Error al operar el registro. " + ex.Message;
            }

        }

        protected void btnNuevaB_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            lblErrorBusqueda.Text = string.Empty;

            upBuscar.Visible = true;
            upModificar.Visible = false;

            ddlBAnio.Focus();
            filtrarGridBusqueda();
        }

        protected void limpiarControlesError()
        {
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;

            lblEAnio.Text = string.Empty;
            lblEUnidad.Text = string.Empty;
            lblEProceso.Text = string.Empty;
            lblEEje.Text = string.Empty;
            lblEOEstr.Text = string.Empty;
            lblEMEstr.Text = string.Empty;
        }

        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            lblEAnio.Text = string.Empty;
            lblEUnidad.Text = string.Empty;
            lblEProceso.Text = string.Empty;
            lblEEje.Text = string.Empty;
            lblEOEstr.Text = string.Empty;

            try
            {
                if (ddlAnios.SelectedValue.Equals("0") || ddlAnios.Items.Count == 0)
                {
                    lblEAnio.Text = "*";
                    lblError.Text += "Seleccione un Año!. ";
                }

                if (ddlUnidades.SelectedValue.Equals("0") || ddlUnidades.Items.Count == 0)
                {
                    lblEUnidad.Text = "*";
                    lblError.Text += "Seleccione una Unidad!. ";
                }

                if (ddlProcesos.SelectedValue.Equals("0") || ddlProcesos.Items.Count == 0)
                {
                    lblEProceso.Text = "*";
                    lblError.Text += "Seleccione un Proceso!. ";
                }

                if (ddlEjes.SelectedValue.Equals("0") || ddlEjes.Items.Count == 0)
                {
                    lblEEje.Text = "*";
                    lblError.Text += "Seleccione un Eje Estratégico!. ";
                }

                if (ddlObjetivosE.SelectedValue.Equals("0") || ddlObjetivosE.Items.Count == 0)
                {
                    lblEOEstr.Text = "*";
                    lblError.Text += "Seleccione un Objetivo Estratégico!. ";
                }

                if (ddlMetasE.SelectedValue.Equals("0") || ddlMetasE.Items.Count == 0)
                {
                    lblEMEstr.Text = "*";
                    lblError.Text += "Seleccione una Meta Estratégica!. ";
                }

                if (gridPlanE.SelectedValue == null)
                {
                    lblEPlan.Text = "*";
                    lblError.Text += "Seleccione una Meta Estratégica!. ";
                }

                if (lblEAnio.Text.Equals(string.Empty) && lblEUnidad.Text.Equals(string.Empty) && lblEProceso.Text.Equals(string.Empty) && lblEEje.Text.Equals(string.Empty) && lblEOEstr.Text.Equals(string.Empty) && lblEMEstr.Text.Equals(string.Empty) && lblEPlan.Text.Equals(string.Empty))
                    controlesValidos = true;

                if (ddlObjetivosO.SelectedIndex != 0 && ddlIndicadores.SelectedIndex == 0)
                {
                    rfvCodigo.Enabled = true;
                    rfvObjetivo.Enabled = true;
                    rfvIndicador.Enabled = false;
                    rfvMeta.Enabled = false;
                }
                else
                {
                    rfvCodigo.Enabled = false;
                    if(txtCodigo.Enabled)
                        rfvCodigo.Enabled = true;
                    rfvObjetivo.Enabled = true;
                    rfvIndicador.Enabled = true;
                    rfvMeta.Enabled = true;
                }

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

        protected bool validarPoa(int idUnidad, int anio)
        {
            lblError.Text = string.Empty;
            lblErrorPoa.Text = string.Empty;
            bool poaValido = false;
            btnGuardar.Visible = false;
            lblIdPoa.Text = "0";
            lblEstadoPoa.Text = string.Empty;

            try
            {
                planOperativoLN = new PlanOperativoLN();
                planOperativoLN.DatosPoaUnidad(idUnidad, anio);

                DataSet dsPoa = planOperativoLN.DatosPoaUnidad(idUnidad, anio);

                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                string estadoPoa = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString();
                lblEstadoPoa.Text = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString() + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString();

                int idPoa = int.Parse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString());
                lblIdPoa.Text = idPoa.ToString();

                //1	Aprobado
                if (estadoPoa.Equals("9"))
                {
                    lblErrorPoa.Text = lblError.Text = string.Empty;

                    btnGuardar.Visible = btnEliminarIndicador.Visible = btnEliminarMeta.Visible = btnEliminarObjetivo.Visible = true;
                }
                //2	Revisión Subgerencia, 4	Revisión Analista POA, 7	Revisión Dirección
                else /*if (estadoPoa.Equals("2") || estadoPoa.Equals("4") || estadoPoa.Equals("7"))*/
                {
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + lblEstadoPoa.Text + " y no se puede modificar";

                    btnGuardar.Visible = btnEliminarIndicador.Visible = btnEliminarMeta.Visible = btnEliminarObjetivo.Visible = false;
                }
                //3	Rechazado Subgerencia, 6	Rechazado Analista POA, 8	Rechazado Dirección, 
                /*else if (estadoPoa.Equals("3") || estadoPoa.Equals("6") || estadoPoa.Equals("8"))
                {
                    string motivoRechazo = dsPoa.Tables[0].Rows[0]["OBSERVACIONES"].ToString();
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + lblEstadoPoa.Text + ", por: " + motivoRechazo;

                    btnGuardar.Visible = btnEliminarIndicador.Visible = btnEliminarMeta.Visible = btnEliminarObjetivo.Visible = true;
                }
                //9	Aprobado Dirección
                else if (estadoPoa.Equals("9"))
                {
                    lblErrorPoa.Text = lblError.Text = string.Empty;

                    btnGuardar.Visible = btnEliminarIndicador.Visible = btnEliminarMeta.Visible = btnEliminarObjetivo.Visible = false;
                }
                else
                {
                    lblErrorPoa.Text = lblError.Text = "Estado desconocido: " + estadoPoa + ", por favor consulte con el administrador del sistema";

                    btnGuardar.Visible = btnEliminarIndicador.Visible = btnEliminarMeta.Visible = btnEliminarObjetivo.Visible = false;
                }*/
                
                /*if (!estadoPoa.Equals("1") && !estadoPoa.Equals("3") && !estadoPoa.Equals("6") && !estadoPoa.Equals("8"))
                    lblErrorPoa.Text = lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString() + " y no se puede modificar";
                else
                    btnGuardar.Visible = true;
                 * */

                poaValido = true;
            }
            catch (Exception ex)
            {
                lblError.Text = lblErrorPoa.Text = "Error: " + ex.Message;
            }
            return poaValido;
        }

        protected void btnBObjEstrategico_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorBusqueda.Text = string.Empty;

                planEstrategicoLN = new PlanEstrategicoLN();
                planEstrategicoLN.GridBusqueda(gridPlanE);


                string filtro = string.Empty;

                object obj = gridBusqueda.DataSource;
                System.Data.DataTable tbl = gridBusqueda.DataSource as System.Data.DataTable;
                System.Data.DataView dv = tbl.DefaultView;

                filtro = " anio = " + ddlAnios.SelectedValue;

                if (!ddlEjes.SelectedValue.Equals("0"))
                    filtro += " AND cod_ee = " + ddlEjes.SelectedItem.Text.Split('-')[0].Trim();

                if (!ddlObjetivosE.SelectedValue.Equals("0"))
                    filtro += " AND cod_oe = " + ddlObjetivosE.SelectedItem.Text.Split('-')[0].Trim();

                dv.RowFilter = filtro;

                gridBusqueda.DataSource = dv;
                gridBusqueda.DataBind();
            }
            catch (Exception ex)
            {
                lblErrorBusqueda.Text = "btnBuscar_Click(). " + ex.Message;
            }
        }

        protected void gridPlanE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int selectedIndex = gridPlanE.SelectedIndex;
                int idMeta = int.Parse(gridPlanE.DataKeys[selectedIndex].Value.ToString());

                planEstrategicoLN = new PlanEstrategicoLN();
                
                DataSet dsDatos = planEstrategicoLN.BuscarId(idMeta.ToString());                

                int idObjEstrategico = int.Parse(dsDatos.Tables["BUSQUEDA"].Rows[0]["ID_OBJETIVO"].ToString());
                ListItem item = ddlObjetivosE.Items.FindByValue(idObjEstrategico.ToString());
                if (item != null)
                {
                    ddlObjetivosE.SelectedValue = idObjEstrategico.ToString();
                    ddlObjetivosE_SelectedIndexChanged(sender, e);

                    int idMetaEstrategica = int.Parse(dsDatos.Tables["BUSQUEDA"].Rows[0]["ID_META"].ToString());
                    item = ddlMetasE.Items.FindByValue(idMetaEstrategica.ToString());

                    if (item != null)
                    {
                        ddlMetasE.SelectedValue = idMetaEstrategica.ToString();
                        ddlMetasE_SelectedIndexChanged(sender, e);
                    }
                }
                
                planOperativoLN = new PlanOperativoLN();
                planOperativoLN.DdlObjetivosxMeta(ddlObjetivosO, idMeta, int.Parse(ddlUnidades.SelectedValue));

                filtrarGridPlanE(idMeta.ToString());
            }
            catch (Exception ex)
            {
                lblError.Text = "gridPlanE_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void gridPlanE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                limpiarControlesError();

                gridPlanE.PageIndex = e.NewPageIndex;
                filtrarGridPlanE(string.Empty);
            }
            catch (Exception ex)
            {
                lblError.Text = "gridPlanE_PageIndexChanging(). " + ex.Message;
            }
        }

        protected void ddlEjes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                
                int vValue = int.Parse(ddlEjes.SelectedValue);

                if (vValue > 0)
                {
                    planEstrategicoLN = new PlanEstrategicoLN();
                    planEstrategicoLN.DdlObjetivos_X_Eje(ddlObjetivosE, int.Parse(ddlEjes.SelectedValue));
                    ddlObjetivosE.Items[0].Text = "<< Elija un valor >>";


                    if (ddlObjetivosE.Items.Count == 2)
                    {
                        ddlObjetivosE.SelectedIndex = 1;
                        ddlObjetivosE_SelectedIndexChanged(sender, e);
                        ddlObjetivosE.Enabled = false;
                    }
                    else
                    {
                        ddlObjetivosE.SelectedIndex = 0;
                        ddlObjetivosE.Enabled = true;

                        filtrarGridPlanE(string.Empty);
                        //ddlObjetivosE_SelectedIndexChanged(sender, e);

                    }
                }
                else
                    limpiarCPlanEstrategico();

                /*limpiarCNuevoObjetivo();
                limpiarCNuevoIndicador();
                limpiarCNuevaMeta();*/
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlEjes_SelectedIndexChanged. " + ex.Message;
            }
        }

        protected void limpiarCPlanEstrategico()
        {
            planEstrategicoLN = new PlanEstrategicoLN();

            int idPlan = 0;
            int.TryParse(ddlPlanes.SelectedValue, out idPlan);

            planEstrategicoLN.DdlEjes(ddlEjes, idPlan);
            planEstrategicoLN.DdlObjetivos_X_Eje(ddlObjetivosE, 0);
            planEstrategicoLN.DdlMetas_X_Obj_Estr(ddlMetasE, 0, 0);
            ddlEjes.Items[0].Text = "<< Elija un valor >>";
            ddlObjetivosE.Items[0].Text = "<< Elija un valor >>";
            ddlMetasE.Items[0].Text = "<< Elija un valor >>";

            chkModAlineacion.Checked = false;            

            ddlEjes.Enabled = ddlObjetivosE.Enabled = ddlMetasE.Enabled = true;
            gridPlanE.DataSource = null;
            gridPlanE.DataBind();
        }

        protected void filtrarGridPlanE(string id)
        {
            gridPlanE.SelectedIndex = -1;

            planEstrategicoLN = new PlanEstrategicoLN();
            planEstrategicoLN.GridBusqueda(gridPlanE);

            string filtro = string.Empty;

            object obj = gridBusqueda.DataSource;
            System.Data.DataTable tbl = gridPlanE.DataSource as System.Data.DataTable;
            System.Data.DataView dv = tbl.DefaultView;

            filtro = " anio = " + ddlAnios.SelectedValue;

            if (!ddlEjes.SelectedValue.Equals("0"))
                filtro += " AND cod_ee = " + ddlEjes.SelectedItem.Text.Split('-')[0].Trim();

            if (!ddlObjetivosE.SelectedValue.Equals("0"))
                filtro += " AND cod_oe = " + ddlObjetivosE.SelectedItem.Text.Split('-')[0].Trim();

            if(!id.Equals(string.Empty))
                filtro += " AND id = " + id;

            dv.RowFilter = filtro;

            gridPlanE.DataSource = dv;
            gridPlanE.DataBind();

            if (gridPlanE.Rows.Count == 1)
            {
                gridPlanE.SelectedIndex = 0;
                
                planEstrategicoLN = new PlanEstrategicoLN();
                DataSet dsDatos = planEstrategicoLN.BuscarId(gridPlanE.SelectedValue.ToString());
                int idOEstrategico = int.Parse(dsDatos.Tables["BUSQUEDA"].Rows[0]["ID_OBJETIVO"].ToString());

                ListItem item = ddlObjetivosE.Items.FindByValue(idOEstrategico.ToString());
                if (item != null)
                    ddlObjetivosE.SelectedValue = idOEstrategico.ToString();

                if (chkModAlineacion.Checked == false)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlObjetivosxMeta(ddlObjetivosO, int.Parse(gridPlanE.SelectedValue.ToString()), int.Parse(ddlUnidades.SelectedValue));
                    ddlObjetivosO_SelectedIndexChanged(new Object(), new EventArgs());
                    txtCodigo.Visible = false;
                }
                else
                    txtCodigo.Visible = true;
            }
        }

        protected void filtrarGridBusqueda()
        {
            planOperativoLN = new PlanOperativoLN();
            planOperativoLN.GridBusqueda(gridBusqueda, Session["usuario"].ToString());

            string filtro = string.Empty;

            object obj = gridBusqueda.DataSource;
            System.Data.DataTable tbl = gridBusqueda.DataSource as System.Data.DataTable;
            System.Data.DataView dv = tbl.DefaultView;

            filtro = " anio = " + ddlBAnio.SelectedValue;

            if (!ddlBUnidades.SelectedValue.Equals("0"))
                filtro += " AND id_unidad = " + ddlBUnidades.SelectedValue;

            if (!ddlBObjetivos.SelectedValue.Equals("0"))
                filtro += " AND id_objetivo_operativo = " + ddlBObjetivos.SelectedValue;

            if (!ddlBIndicadores.SelectedValue.Equals("0"))
                filtro += " AND id_kpi_operativo = " + ddlBIndicadores.SelectedValue;
            
            dv.RowFilter = filtro;

            gridBusqueda.DataSource = dv;
            gridBusqueda.DataBind();
        }

        protected void ddlObjetivosE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int vValue = int.Parse(ddlObjetivosE.SelectedValue);
                int vAnio = int.Parse(ddlAnios.SelectedValue);

                planEstrategicoLN = new PlanEstrategicoLN();
                planEstrategicoLN.DdlMetas_X_Obj_Estr(ddlMetasE, vValue, vAnio);
                ddlMetasE.Items[0].Text = "<< Elija un valor >>";

                if (ddlMetasE.Items.Count == 2)
                {
                    ddlMetasE.SelectedIndex = 1;
                    ddlMetasE_SelectedIndexChanged(sender, e);
                    ddlMetasE.Enabled = false;
                }
                else
                {
                    ddlMetasE.SelectedIndex = 0;
                    ddlMetasE.Enabled = true;
                    filtrarGridPlanE(string.Empty);

                }

                /*limpiarCNuevoObjetivo();
                limpiarCNuevoIndicador();
                limpiarCNuevaMeta();*/
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlObjetivosE_SelectedIndexChanged. " + ex.Message;
            }
        }

        protected void ddlObjetivosO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                limpiarCNuevoIndicador();
                limpiarCNuevaMeta();
                txtObjetivo.Focus();
                txtCodigo.Text = txtObjetivo.Text = string.Empty;
                txtCodigo.Enabled = false;

                planOperativoLN = new PlanOperativoLN();

                int vValue = int.Parse(ddlObjetivosO.SelectedValue);
                if (vValue > 0)
                {
                    DataSet dsResultado = planOperativoLN.InformacionObjetivo(int.Parse(ddlObjetivosO.SelectedValue));

                    txtCodigo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["CODIGO"].ToString();
                    txtObjetivo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE"].ToString();
                    txtCodigo.Enabled = true;

                    int idMetaEstrategica = int.Parse(gridPlanE.SelectedValue.ToString());
                    //planOperativoLN.DdlIndicadores(ddlIndicadores, vValue, idMetaEstrategica);
                    planOperativoLN.DdlIndicadores(ddlIndicadores, vValue);
                    planOperativoLN.DdlMetas(ddlMetas, 0);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlObjetivosE_SelectedIndexChanged. " + ex.Message;
            }
        }

        protected void ddlIndicadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                limpiarCNuevaMeta();
                txtIndicador.Focus();
                txtIndicador.Text = string.Empty;

                planOperativoLN = new PlanOperativoLN();

                int vValue = int.Parse(ddlIndicadores.SelectedValue);
                if (vValue > 0)
                {
                    DataSet dsResultado = planOperativoLN.InformacionIndicador(vValue);
                    txtIndicador.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE"].ToString();

                    planOperativoLN.DdlMetas(ddlMetas, vValue);
                }   
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlIndicadores_SelectedIndexChanged. " + ex.Message;
            }
        }

        protected void ddlMetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                txtMeta.Focus();
                txtMeta.Text = string.Empty;

                planOperativoLN = new PlanOperativoLN();

                int vValue = int.Parse(ddlMetas.SelectedValue);
                if (vValue > 0)
                {
                    DataSet dsResultado = planOperativoLN.InformacionMeta(vValue);
                    txtMeta.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlMetas_SelectedIndexChanged. " + ex.Message;
            }
        }

        protected void btnEliminarObjetivo_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            try
            {
                planOperativoLN = new PlanOperativoLN();
                int id = int.Parse(ddlObjetivosO.SelectedValue);

                if (id > 0)
                    if (eliminarObjetivo(id))
                    {
                        limpiarCNuevoObjetivo();
                        limpiarCNuevoIndicador();
                        limpiarCNuevaMeta();
                        planOperativoLN.DdlObjetivosxMeta(ddlObjetivosO, int.Parse(gridPlanE.SelectedValue.ToString()), int.Parse(ddlUnidades.SelectedValue));
                        //planOperativoLN.DdlObjetivos(ddlObjetivosO, int.Parse(gridPlanE.SelectedValue.ToString()));
                        lblSuccess.Text += "Objetivo ELIMINADO correctamente. \n";
                        lblError.Text = string.Empty;
                    }
            }
            catch (Exception ex)
            {
                lblError.Text = "No se pudo eliminar el objetivo. ";
                lblSuccess.Text = string.Empty;

            }
        }

        protected bool eliminarObjetivo(int id)
        {
            try
            {
                planOperativoLN = new PlanOperativoLN();
                DataSet dsResultado = planOperativoLN.EliminarObjetivo(id);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnEliminarIndicador_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            try
            {
                planOperativoLN = new PlanOperativoLN();
                int id = int.Parse(ddlIndicadores.SelectedValue);

                if (id > 0)
                    if (eliminarIndicador(id))
                    {
                        limpiarCNuevoIndicador();
                        limpiarCNuevaMeta();
                        planOperativoLN.DdlIndicadores(ddlIndicadores, int.Parse(ddlObjetivosO.SelectedValue), int.Parse(gridPlanE.SelectedValue.ToString()));
                        lblSuccess.Text += "Indicador ELIMINADO correctamente. \n";
                        lblError.Text = string.Empty;
                    }
            }
            catch (Exception ex)
            {
                lblError.Text = "No se pudo eliminar el indicador. ";
                lblSuccess.Text = string.Empty;

            }
        }

        protected bool eliminarIndicador(int id)
        {
            try
            {
                planOperativoLN = new PlanOperativoLN();
                DataSet dsResultado = planOperativoLN.EliminarIndicador(id);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnEliminarMeta_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            try
            {
                planOperativoLN = new PlanOperativoLN();
                int id = int.Parse(ddlMetas.SelectedValue);

                if (id > 0)
                    if (eliminarMeta(id))
                    {
                        limpiarCNuevaMeta();
                        planOperativoLN.DdlMetas(ddlMetas, int.Parse(ddlIndicadores.SelectedValue));
                        lblSuccess.Text += "Meta ELIMINADA correctamente. \n";
                        lblError.Text = string.Empty;
                    }
            }
            catch (Exception ex)
            {
                lblError.Text = "No se pudo eliminar la meta. ";
                lblSuccess.Text = string.Empty;

            }
        }

        protected bool eliminarMeta(int id)
        {
            try
            {
                planOperativoLN = new PlanOperativoLN();
                DataSet dsResultado = planOperativoLN.EliminarMeta(id);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idPlan = int.Parse(ddlPlanes.SelectedValue);
                btnNuevo_Click(sender, e);

                if (idPlan > 0)
                {
                    ddlPlanes.SelectedValue = idPlan.ToString();
                    int anioIni = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[0].Trim());
                    int anioFin = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[1].Trim());

                    planEstrategicoLN = new PlanEstrategicoLN();

                    planEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                    planEstrategicoLN.DdlEjes(ddlEjes, idPlan);                   
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlPlanes. " + ex.Message;
            }
        }

        protected void btnRevisarPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerPlan.aspx?Anio=" + ddlAnios.SelectedItem.Value + "&unidad=" + ddlUnidades.SelectedItem.Value);
        }

        protected void ddlMetasE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                limpiarControlesError();

                string vIdMetaE = ddlMetasE.SelectedValue;
                filtrarGridPlanE(vIdMetaE);
                /*limpiarCNuevoObjetivo();
                limpiarCNuevoIndicador();
                limpiarCNuevaMeta();*/
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlMetasE_SelectedIndexChanged. " + ex.Message;
            }
        }
    }
}
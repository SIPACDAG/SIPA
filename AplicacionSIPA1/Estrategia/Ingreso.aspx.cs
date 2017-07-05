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
    public partial class Ingreso : System.Web.UI.Page
    {
        private PlanEstrategicoLN ObjLN;

        private ObjEstrategicosEN objetivosEN = new ObjEstrategicosEN();
        private IndEstrategicosEN indicadoresEN = new IndEstrategicosEN();
        private MetasEstrategicasEN metasEN = new MetasEstrategicasEN();

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    upModificar.Visible = false;
                    //btnNuevaB_Click(sender, e);


                    ddlBAnio.Focus();

                    ObjLN = new PlanEstrategicoLN();

                    ObjLN.DdlPlanes(ddlBAnio);
                    ObjLN.DdlEjes(ddlBEjes, 0);
                    ObjLN.DdlObjetivos_X_Eje(ddlBObjetivos, 0);
                    ddlBObjetivos.Items[0].Text = "<< Elija un valor >>";
                    ObjLN.DdlIndicadores_X_Objetivo(ddlBIndicadores, 0);
                    ddlBIndicadores.Items[0].Text = "<< Elija un valor >>";
                    ObjLN.DdlMetas_X_Indicador(ddlBMetas, 0);
                    ddlBMetas.Items[0].Text = "<< Elija un valor >>";

                    gridBusqueda.DataSource = null;
                    gridBusqueda.DataBind();
                }
                catch (Exception ex)
                {
                    lblErrorBusqueda.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void ddlBAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorBusqueda.Text = string.Empty;
            ObjLN = new PlanEstrategicoLN();

            ObjLN.DdlEjes(ddlBEjes, int.Parse(ddlBAnio.SelectedValue));
            ObjLN.DdlObjetivos_X_Eje(ddlBObjetivos, 0);

            int anioIni = 0;
            int anioFin = 0;
            if (ddlBAnio.SelectedValue != "0")
            {
                anioIni = int.Parse(ddlBAnio.SelectedItem.Text.Split('-')[0]);
                anioFin = int.Parse(ddlBAnio.SelectedItem.Text.Split('-')[1]);
            }
            ObjLN.DdlAniosMeta(ddlBAniosMeta, anioIni, anioFin);
            ObjLN.DdlIndicadores_X_Objetivo(ddlBIndicadores, 0);
            ObjLN.DdlMetas_X_Indicador(ddlBMetas, 0);

            ddlBObjetivos.Items[0].Text = "<< Elija un valor >>";            
            ddlBIndicadores.Items[0].Text = "<< Elija un valor >>";
            ddlBMetas.Items[0].Text = "<< Elija un valor >>";

            filtrarGridBusqueda();
        }

        protected void rblCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorBusqueda.Text = string.Empty;
            //txtBValor.Focus();
        }

        protected void filtrarGridBusqueda()
        {
            try{
                lblErrorBusqueda.Text = string.Empty;

                ObjLN = new PlanEstrategicoLN();
                ObjLN.GridBusqueda(gridBusqueda);


                string filtro = string.Empty;

                object obj = gridBusqueda.DataSource;
                System.Data.DataTable tbl = gridBusqueda.DataSource as System.Data.DataTable;
                System.Data.DataView dv = tbl.DefaultView;

                filtro = " id_plan = " + ddlBAnio.SelectedValue;

                if (!ddlBEjes.SelectedValue.Equals("0"))
                    filtro += " AND cod_ee = " + ddlBEjes.SelectedItem.Text.Split('-')[0].Trim();

                if (!ddlBObjetivos.SelectedValue.Equals("0"))
                    filtro += " AND cod_oe = " + ddlBObjetivos.SelectedItem.Text.Split('-')[0].Trim();

                if (ddlBAniosMeta.Items.Count > 0)
                    filtro += " AND anio = " + ddlBAniosMeta.SelectedItem.Text.Split('-')[0].Trim();

                if (!ddlBIndicadores.SelectedValue.Equals("0"))
                    filtro += " AND id_kpi = " + ddlBIndicadores.SelectedValue;

                if (!ddlBMetas.SelectedValue.Equals("0"))
                    filtro += " AND id = " + ddlBMetas.SelectedValue;

                dv.RowFilter = filtro;

                gridBusqueda.DataSource = dv;
                gridBusqueda.DataBind();
            }
            catch (Exception ex)
            {
                lblErrorBusqueda.Text = "filtrarGridBusqueda(). " + ex.Message;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                activarControlesMoE(true);

                ObjLN = new PlanEstrategicoLN();
                ObjLN.DdlPlanes(ddlAnios);
                ObjLN.DdlEjes(ddlEjes, 0);

                limpiarCNuevoObjetivo();
                limpiarCNuevoIndicador();
                limpiarCNuevaMeta();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo_Click()" + ex.Message;
            }
        }  

        protected void gridBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                limpiarControlesError();

                gridBusqueda.PageIndex = e.NewPageIndex;
                filtrarGridBusqueda();
            }
            catch (Exception ex)
            {
                lblError.Text = "gridBusqueda_PageIndexChanging(). " + ex.Message;
            }
        }

        protected void gridBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
            activarControlesMoE(true);

            try
            {
                string idBuscar = gridBusqueda.SelectedValue.ToString();

                ObjLN = new PlanEstrategicoLN();
                System.Data.DataSet ds = ObjLN.BuscarId(idBuscar);

                if (bool.Parse(ds.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(ds.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                int anio = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ANIO"].ToString());
                int idEje = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_EJE"].ToString());
                int idObjetivo = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_OBJETIVO"].ToString());
                int idIndicador = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_KPI"].ToString());
                int idMeta = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_META"].ToString());
                int idPlan = int.Parse(ds.Tables["BUSQUEDA"].Rows[0]["ID_PLAN"].ToString());

                ObjLN.DdlPlanes(ddlAnios);
                ddlAnios.SelectedValue = idPlan.ToString();

                ObjLN.DdlEjes(ddlEjes, idPlan);
                ObjLN.DdlObjetivos_X_Eje(ddlObjetivos, idEje);
                ObjLN.DdlIndicadores_X_Objetivo(ddlIndicadores, idObjetivo);
                ObjLN.DdlMetas_X_Indicador(ddlMetas, idIndicador);

                ddlEjes.SelectedValue = idEje.ToString();
                
                ddlObjetivos.SelectedValue = idObjetivo.ToString();
                ddlObjetivos_SelectedIndexChanged(sender, e);
                ddlIndicadores.SelectedValue = idIndicador.ToString();
                ddlIndicadores_SelectedIndexChanged(sender, e);
                ddlMetas.SelectedValue = idMeta.ToString();
                ddlMetas_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar los datos: " + ex.Message;
            }
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                ObjLN = new PlanEstrategicoLN();
                ObjLN.DdlEjes(ddlEjes, 0);
                limpiarCNuevoObjetivo();
                limpiarCNuevoIndicador();
                limpiarCNuevaMeta();


                if (ddlAnios.SelectedValue != "0")
                {
                    int vValue = int.Parse(ddlAnios.SelectedValue);
                    ObjLN.DdlEjes(ddlEjes, vValue);
                    int anioIni = int.Parse(ddlAnios.SelectedItem.Text.Split('-')[0].Trim());
                    int anioFin = int.Parse(ddlAnios.SelectedItem.Text.Split('-')[1].Trim());
                    ObjLN.DdlAniosMeta(ddlAniosMeta, anioIni, anioFin);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlEjes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                limpiarCNuevoObjetivo();
                limpiarCNuevoIndicador();
                limpiarCNuevaMeta();

                ObjLN = new PlanEstrategicoLN();               

                int vValue = int.Parse(ddlEjes.SelectedValue);
                if (vValue > 0)
                {
                    ObjLN.DdlObjetivos_X_Eje(ddlObjetivos, int.Parse(ddlEjes.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlEjes_SelectedIndexChanged. " + ex.Message;
            }
        }

        protected void ddlObjetivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                limpiarCNuevoIndicador();
                limpiarCNuevaMeta();
                txtCodigo.Focus();

                ObjLN = new PlanEstrategicoLN();

                int vValue = int.Parse(ddlObjetivos.SelectedValue);

                if (vValue > 0)
                {
                    DataSet dsResultado = ObjLN.InformacionObjetivo(int.Parse(ddlObjetivos.SelectedValue));

                    lblIdO.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_OBJETIVO_ESTRATEGICO"].ToString();
                    txtCodigo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["CODIGO_OBJETIVO_ESTRATEGICO"].ToString();
                    txtObjetivo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["OBJETIVO_ESTRATEGICO"].ToString();

                    ObjLN.DdlIndicadores_X_Objetivo(ddlIndicadores, int.Parse(ddlObjetivos.SelectedValue));
                }
                else
                {
                    lblIdO.Text = txtCodigo.Text = txtObjetivo.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlObjetivos_SelectedIndexChanged. " + ex.Message;
            }
        }

        protected void ddlIndicadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                limpiarCNuevaMeta();
                txtIndicador.Focus();

                ObjLN = new PlanEstrategicoLN();

                int vValue = int.Parse(ddlIndicadores.SelectedValue);

                if (vValue > 0)
                {
                    DataSet dsResultado = ObjLN.InformacionIndicador(int.Parse(ddlIndicadores.SelectedValue));

                    lblIdI.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_KPI"].ToString();
                    txtIndicador.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE"].ToString();
                    txtFormula.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["FORMULA"].ToString();
                    txtDescripcion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DESCRIPCION"].ToString();

                    ObjLN.DdlMetas_X_Indicador(ddlMetas, int.Parse(ddlIndicadores.SelectedValue));
                }
                else
                {
                    lblIdI.Text = txtIndicador.Text = txtFormula.Text = txtDescripcion.Text = string.Empty;
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

                ObjLN = new PlanEstrategicoLN();

                int vValue = int.Parse(ddlMetas.SelectedValue);

                if (ddlAniosMeta.Items.Count == 0)
                {
                    int anioIni = int.Parse(ddlAnios.SelectedItem.Text.Split('-')[0].ToString());
                    int anioFin = int.Parse(ddlAnios.SelectedItem.Text.Split('-')[1].ToString());
                    ObjLN.DdlAniosMeta(ddlAniosMeta, anioIni, anioFin);
                }

                if (rblUnidades.Items.Count == 0)
                    ObjLN.RblUnidades(rblUnidades);

                rblUnidades.ClearSelection();

                if (vValue > 0)
                {
                    DataSet dsResultado = ObjLN.InformacionMeta(int.Parse(ddlMetas.SelectedValue));

                    lblIdM.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_META"].ToString();
                    txtMeta.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE"].ToString().Split('-')[0].Trim();
                    txtMetaPropuesta.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["META_PROPUESTA"].ToString();
                    ddlAniosMeta.SelectedValue = dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO"].ToString();
                    rblUnidades.SelectedValue = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_RESPONSABLE"].ToString();
                }
                else
                {
                    lblIdM.Text = txtMeta.Text = txtMetaPropuesta.Text = string.Empty;
                    ddlAniosMeta.ClearSelection();
                    rblUnidades.ClearSelection();
                    rblUnidades.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlMetas_SelectedIndexChanged. " + ex.Message;
            }            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            ObjLN = new PlanEstrategicoLN();
            objetivosEN = new ObjEstrategicosEN();
            indicadoresEN = new IndEstrategicosEN();
            metasEN = new MetasEstrategicasEN();

            string mensaje = "";
            DataSet dsResultado = new DataSet();
            int idObjetivo = 0;
            int idIndicador = 0;
            int idMeta = 0;

            try
            {

                idObjetivo = lblIdO.Text.Length == 0 ? 0 : int.Parse(lblIdO.Text);
                idIndicador = lblIdI.Text.Length == 0 ? 0 : int.Parse(lblIdI.Text);
                idMeta = lblIdM.Text.Length == 0 ? 0 : int.Parse(lblIdM.Text);

                if (idMeta != 0 && txtMeta.Text.Trim().Equals(string.Empty))
                {
                    if (eliminarMeta(idMeta))
                        mensaje += "Meta ELIMINADA correctamente. \n";
                }
                
                if (idIndicador != 0 && txtIndicador.Text.Trim().Equals(string.Empty))
                {
                    if (eliminarIndicador(idIndicador))
                        mensaje += "Indicador ELIMINADO correctamente. \n";
                }

                if (idObjetivo != 0 && txtObjetivo.Text.Trim().Equals(string.Empty))
                {
                    if (eliminarObjetivo(idObjetivo))
                        mensaje += "Objetivo ELIMINADO correctamente. \n";
                }

                if (!txtObjetivo.Text.Trim().Equals(string.Empty) || !txtIndicador.Text.Trim().Equals(string.Empty) || !txtMeta.Text.Trim().Equals(string.Empty))
                {
                    bool camposLlenos = validarControlesABC();
                    objetivosEN.Id_Objetivo_Estrategico = idObjetivo;
                    objetivosEN.Objetivo_Estrategico = txtObjetivo.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                    txtObjetivo.Text = objetivosEN.Objetivo_Estrategico; 
                    objetivosEN.Anio = int.Parse(ddlAnios.SelectedItem.Text.Split('-')[0].ToString());
                    objetivosEN.Anio_Fin = int.Parse(ddlAnios.SelectedItem.Text.Split('-')[1].ToString());
                    objetivosEN.Codigo_Objetivo_Estrategico = int.Parse(txtCodigo.Text);
                    objetivosEN.Id_Eje_Estrategico = int.Parse(ddlEjes.SelectedValue);
                    objetivosEN.Medios = string.Empty;
                    objetivosEN.Normativa = string.Empty;
                    objetivosEN.Usuario = Session["usuario"].ToString();

                    //INSERTAR/ACTUALIZAR
                    if (camposLlenos)
                    {
                        dsResultado = ObjLN.AlmacenarObjetivo(objetivosEN);

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ el objetivo: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        lblIdO.Text = dsResultado.Tables[0].Rows[0]["VALOR"].ToString();
                        if (idObjetivo == 0)
                            mensaje += "Objetivo INSERTADO correctamente. \n";
                        else
                            mensaje += "Objetivo ACTUALIZADO correctamente. \n";

                        idObjetivo = int.Parse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString());

                        indicadoresEN.Id_Objetivo = idObjetivo;
                        indicadoresEN.Id_Kpi = idIndicador;
                        indicadoresEN.Nombre = txtIndicador.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                        txtIndicador.Text = indicadoresEN.Nombre; 
                        indicadoresEN.Formula = txtFormula.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                        txtFormula.Text = indicadoresEN.Formula;
                        indicadoresEN.Descripcion = txtDescripcion.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                        txtDescripcion.Text = indicadoresEN.Descripcion;
                        indicadoresEN.Usuario = Session["usuario"].ToString();

                        dsResultado = ObjLN.AlmacenarIndicador(indicadoresEN);

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ el indicador: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        lblIdI.Text = dsResultado.Tables[0].Rows[0]["VALOR"].ToString();
                        if (idIndicador == 0)
                            mensaje += "Indicador INSERTADO correctamente. \n";
                        else
                            mensaje += "Indicador ACTUALIZADO correctamente. \n";

                        idIndicador = int.Parse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString());

                        metasEN.Id_Meta = idMeta;
                        metasEN.Nombre = txtMeta.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                        txtMeta.Text = metasEN.Nombre;
                        metasEN.Id_Kpi = idIndicador;
                        metasEN.Anio = int.Parse(ddlAniosMeta.SelectedValue);
                        metasEN.Meta_Propuesta = txtMetaPropuesta.Text.Replace('\'', ' ').Replace('"', ' ').Trim();
                        txtMetaPropuesta.Text = metasEN.Meta_Propuesta;
                        metasEN.Id_Respondable = int.Parse(rblUnidades.SelectedValue);
                        metasEN.Usuario = Session["usuario"].ToString();

                        dsResultado = ObjLN.AlmacenarMeta(metasEN,Session["usuario"].ToString());

                        if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se INSERTÓ/ACTUALIZÓ la meta: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        lblIdM.Text = dsResultado.Tables[0].Rows[0]["VALOR"].ToString();
                        if (idMeta == 0)
                            mensaje += "Meta INSERTADA correctamente. \n";
                        else
                            mensaje += "Meta ACTUALIZADA correctamente. \n";

                        idMeta = int.Parse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString());

                        lblSuccess.Text = "Operación exitosa! ;-). " + mensaje;
                    }
                    else
                    {
                        if (!mensaje.Equals(string.Empty))
                        {
                            lblSuccess.Text = "Operación exitosa! ;-). " + mensaje;
                        }
                    }
                }
                else
                {
                    if (mensaje.Equals(string.Empty))
                        validarControlesABC();
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = mensaje;
                lblError.Text = "Error al operar el registro. " + ex.Message;
            }
            ObjLN.DdlObjetivos_X_Eje(ddlObjetivos, int.Parse(ddlEjes.SelectedValue));
            ListItem item = ddlObjetivos.Items.FindByValue(idObjetivo.ToString());
            if (item != null)
                ddlObjetivos.SelectedValue = idObjetivo.ToString();

            ObjLN.DdlIndicadores_X_Objetivo(ddlIndicadores, idObjetivo);
            item = ddlIndicadores.Items.FindByValue(idIndicador.ToString());
            if (item != null)
                ddlIndicadores.SelectedValue = idIndicador.ToString();

            ObjLN.DdlMetas_X_Indicador(ddlMetas, idIndicador);
            item = ddlMetas.Items.FindByValue(idMeta.ToString());
            if (item != null)
                ddlMetas.SelectedValue = idMeta.ToString();
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

        //Limpiar controles al hacer Modificar o Eliminar un registro
        protected void activarControlesMoE(Boolean enabled)
        {
            upBuscar.Visible = false;
            upModificar.Visible = true;
        }

        protected void limpiarControlesError()
        {
            lblError.Text = lblSuccess.Text = string.Empty;
            lblEA.Text = lblEE.Text = lblECod.Text = lblEObj.Text = lblEI.Text = lblEM.Text = string.Empty;
        }

        private bool validarControlesABC()
        {
            lblEA.Text = lblEE.Text = lblECod.Text = lblEObj.Text = lblEI.Text = lblEM.Text = string.Empty;

            bool controlesValidos = false;
            
            try
            {
                if (ddlAnios.SelectedValue.Equals("0") || ddlAnios.Items.Count == 0)
                    lblEA.Text = "*";

                if (ddlEjes.SelectedValue.Equals("0") || ddlEjes.Items.Count == 0)
                    lblEE.Text = "*";

                if (txtCodigo.Text.Trim().Equals(string.Empty))
                    lblECod.Text = "*";

                if (txtObjetivo.Text.Trim().Equals(string.Empty))
                    lblEObj.Text = "*";

                if (txtIndicador.Text.Trim().Equals(string.Empty))
                    lblEI.Text = "*";

                if (txtMeta.Text.Trim().Equals(string.Empty))
                    lblEM.Text = "*";

                if (!lblEA.Text.Equals(string.Empty) || !lblEE.Text.Equals(string.Empty) || !lblECod.Text.Equals(string.Empty) || !lblEObj.Text.Equals(string.Empty) || !lblEI.Text.Equals(string.Empty) || !lblEM.Text.Equals(string.Empty))
                    return controlesValidos;

                this.Page.Validate("grpDatos");
                controlesValidos = Page.IsValid;
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }

            return controlesValidos;
        }

        protected void ddlAniosMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
            txtMeta.Focus();
        }

        protected void btnLimpiarC_Click(object sender, EventArgs e)
        {
            btnNuevo_Click(sender, e);
        }

        protected void btnEliminarObjetivo_Click(object sender, EventArgs e)
        {
            limpiarControlesError();
            try
            {
                int id = lblIdM.Text.Length == 0 ? 0 : int.Parse(lblIdM.Text);

                if (id > 0)
                    if (eliminarObjetivo(id))
                    {
                        ObjLN.DdlObjetivos_X_Eje(ddlObjetivos, int.Parse(ddlEjes.SelectedValue));
                        txtCodigo.Text = txtObjetivo.Text = string.Empty;
                        lblSuccess.Text += "Objetivo ELIMINADO correctamente. \n";
                        lblError.Text = string.Empty;
                    }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al operar el registro. " + ex.Message;
                lblSuccess.Text = string.Empty;

            }
        }

        protected bool eliminarObjetivo(int id)
        {
            try
            {
                ObjLN = new PlanEstrategicoLN();
                DataSet dsResultado = ObjLN.EliminarObjetivo(id);

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
                int id = lblIdI.Text.Length == 0 ? 0 : int.Parse(lblIdI.Text);

                if (id > 0)
                    if (eliminarIndicador(id))
                    {
                        ObjLN.DdlIndicadores_X_Objetivo(ddlIndicadores, int.Parse(ddlObjetivos.SelectedValue));
                        lblIdI.Text = txtIndicador.Text = txtFormula.Text = txtDescripcion.Text = string.Empty;
                        lblSuccess.Text += "Indicador ELIMINADO correctamente. \n";
                        lblError.Text = string.Empty;
                    }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al operar el registro. " + ex.Message;
                lblSuccess.Text = string.Empty;

            }
        }

        protected bool eliminarIndicador(int id)
        {
            try
            {
                ObjLN = new PlanEstrategicoLN();
                DataSet dsResultado = ObjLN.EliminarIndicador(id);

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
                int id = lblIdM.Text.Length == 0 ? 0 : int.Parse(lblIdM.Text);

                if (id > 0)
                    if (eliminarMeta(id))
                    {
                        ObjLN.DdlMetas_X_Indicador(ddlMetas, int.Parse(ddlIndicadores.SelectedValue));
                        lblIdM.Text = txtMeta.Text = txtMetaPropuesta.Text = string.Empty;
                        ddlAniosMeta.ClearSelection();
                        ddlAniosMeta.SelectedIndex = 0;
                        rblUnidades.ClearSelection();
                        rblUnidades.SelectedIndex = 0;
                        
                        lblSuccess.Text += "Meta ELIMINADA correctamente. \n";
                        lblError.Text = string.Empty;
                    }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al operar el registro. " + ex.Message;
                lblSuccess.Text = string.Empty;
            }
        }

        protected bool eliminarMeta(int id)
        {
            try
            {
                ObjLN = new PlanEstrategicoLN();
                DataSet dsResultado = ObjLN.EliminarMeta(id);

                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void limpiarCNuevoObjetivo()
        {
            ObjLN = new PlanEstrategicoLN();
            ObjLN.DdlObjetivos_X_Eje(ddlObjetivos, 0);
            lblIdO.Text = txtCodigo.Text = txtObjetivo.Text = string.Empty;
        }

        protected void limpiarCNuevoIndicador()
        {
            ObjLN = new PlanEstrategicoLN();
            ObjLN.DdlIndicadores_X_Objetivo(ddlIndicadores, 0);
            lblIdI.Text = txtIndicador.Text = txtFormula.Text = txtDescripcion.Text = string.Empty;
        }

        protected void limpiarCNuevaMeta()
        {
            ObjLN = new PlanEstrategicoLN();
            ObjLN.DdlMetas_X_Indicador(ddlMetas, 0);
            lblIdM.Text = txtMeta.Text = txtMetaPropuesta.Text = string.Empty;

            int anioIni = 0;
            int anioFin = 0;

            if (ddlAnios.SelectedValue != "0")
            {
                anioIni = int.Parse(ddlAnios.SelectedItem.Text.Split('-')[0].ToString());
                anioFin = int.Parse(ddlAnios.SelectedItem.Text.Split('-')[1].ToString());
            }
            ObjLN.DdlAniosMeta(ddlAniosMeta, anioIni, anioFin);
            ObjLN.RblUnidades(rblUnidades);
        }

        protected void ddlBEjes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorBusqueda.Text = string.Empty;
            ObjLN = new PlanEstrategicoLN();
            ObjLN.DdlObjetivos_X_Eje(ddlBObjetivos, int.Parse(ddlBEjes.SelectedValue));            
            ObjLN.DdlIndicadores_X_Objetivo(ddlBIndicadores, 0);
            ObjLN.DdlMetas_X_Indicador(ddlBMetas, 0);

            ddlBObjetivos.Items[0].Text = "<< Elija un valor >>";
            ddlBIndicadores.Items[0].Text = "<< Elija un valor >>";
            ddlBMetas.Items[0].Text = "<< Elija un valor >>";

            filtrarGridBusqueda();
        }

        protected void ddlBObjetivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorBusqueda.Text = string.Empty;
            ObjLN = new PlanEstrategicoLN();
            ObjLN.DdlIndicadores_X_Objetivo(ddlBIndicadores, int.Parse(ddlBObjetivos.SelectedValue));
            ObjLN.DdlMetas_X_Indicador(ddlBMetas, 0);

            ddlBObjetivos.Items[0].Text = "<< Elija un valor >>";
            ddlBIndicadores.Items[0].Text = "<< Elija un valor >>";
            ddlBMetas.Items[0].Text = "<< Elija un valor >>";

            filtrarGridBusqueda();
        }

        protected void ddlBAniosMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarGridBusqueda();    
        }
        
        protected void ddlBIndicadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorBusqueda.Text = string.Empty;
            ObjLN = new PlanEstrategicoLN();
            ObjLN.DdlMetas_X_Indicador(ddlBMetas, int.Parse(ddlBIndicadores.SelectedValue));

            ddlBObjetivos.Items[0].Text = "<< Elija un valor >>";
            ddlBIndicadores.Items[0].Text = "<< Elija un valor >>";
            ddlBMetas.Items[0].Text = "<< Elija un valor >>";

            filtrarGridBusqueda();
        }

        protected void ddlBMetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarGridBusqueda();
        }



    }
}
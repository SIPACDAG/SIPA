using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using System.Data;

namespace AplicacionSIPA1.Usuario
{
    public partial class Permisos_aspx : System.Web.UI.Page
    {
        private UsuariosLN usuarioL;
        

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                usuarioL = new UsuariosLN();
                usuarioL.gridUsuario(gridUsuario);
                usuarioL.dropMenuPadre(dropMenu);

                usuarioL.dropUnidad(dropUnidad);
                usuarioL.dropTipoUsuario(dropTipoUsuario);

                rblCriterio.Items.Add(new ListItem("Usuario", "usuario"));
                rblCriterio.Items.Add(new ListItem("Empleado", "empleado"));
                rblCriterio.Items.Add(new ListItem("Activo", "habilitado"));
                rblCriterio.SelectedValue = "usuario";
                rblCriterio.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string idUsuario = lblUsuario.Text.Split('-')[0].Trim();
            string id = ((Label)Master.FindControl("lblUsuario")).Text;
            try
            {          
                if (validarControlesInsertar())
                {                    
                    if (idUsuario.Equals(string.Empty))
                        throw new Exception("Seleccione un usuario!");
                    
                    usuarioL = new UsuariosLN();
                    DataSet dsResultado = usuarioL.IngresarCargoUsuario(int.Parse(idUsuario), int.Parse(dropUnidad.SelectedValue), int.Parse(dropDependencia.SelectedValue), int.Parse(dropTipoUsuario.SelectedValue),id);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    usuarioL.gridCargoUsuario(gridCargo, int.Parse(idUsuario));

                    lblSuccess.Text = "El registro fue ingresado correctamente";
                    lblError.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                string mensaje = "Error al ingresar el registro: " + ex.Message;
                if (ex.Message.Equals("Seleccione un usuario!"))
                    mensaje = "Seleccione un usuario!";

                lblError.Text = mensaje;
                lblSuccess.Text = string.Empty;
            }
            lblErrorM.Text = string.Empty;
            lblSuccessM.Text = string.Empty;
        }

        protected void dropMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarioL = new UsuariosLN();
           
            usuarioL.listbtenerMenus(cbListMenus, int.Parse(dropMenu.SelectedValue));

            if(!lblUsuario.Text.Split('-')[0].Trim().Equals(string.Empty))
                usuarioL.listUsuariosMenus(cbListMenus, int.Parse(lblUsuario.Text.Split('-')[0].Trim()));

            ocultarLblSuccess();
            ocultarLblError();
        }

        protected void gridUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarioL = new UsuariosLN();
            usuarioL.listUsuariosMenus(cbListMenus, int.Parse(gridUsuario.SelectedValue.ToString()));
            usuarioL.gridCargoUsuario(gridCargo, int.Parse(gridUsuario.SelectedValue.ToString()));
            
            lblUsuario.Text = gridUsuario.SelectedValue.ToString() + " - " + gridUsuario.SelectedRow.Cells[2].Text;

            ocultarLblSuccess(); 
            ocultarLblError();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }

        protected void dropUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarioL = new UsuariosLN();
            usuarioL.dropDependencia(dropDependencia, Convert.ToInt16(dropUnidad.SelectedValue));

            dropDependencia.Enabled = true;
            if (dropDependencia.Items.Count <= 2)
                dropDependencia.Enabled = false;

            dropDependencia.ClearSelection();
            if (dropDependencia.Items.Count == 2)
                dropDependencia.SelectedIndex = 1;

            ocultarLblSuccess();
            ocultarLblError();
        }

        protected void gridCargo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idcu;
                idcu = Convert.ToInt32(gridCargo.Rows[e.RowIndex].Cells[2].Text);
                usuarioL = new UsuariosLN();
                if (usuarioL.desactivarCargoUsuario(idcu, ((Label)Master.FindControl("lblUsuario")).Text))
                {
                    usuarioL.gridCargoUsuario(gridCargo, int.Parse(lblUsuario.Text.Split('-')[0].Trim()));
                    lblSuccess.Text = "El registro fue eliminado correctamente";
                    ocultarLblError();
                }
                else
                    lblError.Text = "El usuario no tiene los permisos para realizar la accion";
                
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al eliminar el registro: " + ex.Message;
                lblSuccess.Text = string.Empty;
            }           

        }

        protected void gridUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            usuarioL = new UsuariosLN();
            
            gridUsuario.PageIndex = e.NewPageIndex;
            usuarioL.gridUsuario(gridUsuario);
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dropMenu.SelectedIndex < 1)
                    throw new Exception("Seleccione un menú!");

                string idUsuario = lblUsuario.Text.Split('-')[0].Trim();

                if (idUsuario.Equals(string.Empty))
                    throw new Exception("Seleccione un usuario!");

                usuarioL = new UsuariosLN();
                usuarioL.AsignarPermisos(cbListMenus, int.Parse(idUsuario), ((Label)Master.FindControl("lblUsuario")).Text);

                lblSuccessM.Text = "El registro fue ingresado correctamente ";
                lblErrorM.Text = string.Empty;

                lblError.Text = string.Empty;
                lblSuccess.Text = string.Empty;
            }
            catch (Exception ex)
            {
                string mensaje = "Error al ingresar el registro: " + ex.Message;
                if (ex.Message.Equals("Seleccione un usuario!") || ex.Message.Equals("Seleccione un menú!"))
                    mensaje = "Seleccione un usuario!";

                if (ex.Message.Equals("Seleccione un menú!"))
                    mensaje = "Seleccione un menú!";

                lblErrorM.Text = mensaje;
                lblSuccessM.Text = string.Empty;
            }
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;
        }

        protected void rblCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBValor.Focus();

            ocultarLblSuccess();
            ocultarLblError();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            usuarioL = new UsuariosLN();
            usuarioL.gridUsuario(gridUsuario);

            string vBuscado = txtBValor.Text.Replace('\'', ' ');

            string filtro = string.Empty;

            object obj = gridUsuario.DataSource;
            System.Data.DataTable tbl = gridUsuario.DataSource as System.Data.DataTable;
            System.Data.DataView dv = tbl.DefaultView;

            filtro = " 0 = 0 ";

            if (!vBuscado.Equals(string.Empty))
            {
                if (rblCriterio.SelectedValue.Equals("usuario"))
                    filtro = filtro + " AND " + rblCriterio.SelectedValue + " LIKE '%" + vBuscado + "%'";

                if (rblCriterio.SelectedValue.Equals("empleado"))
                    filtro = filtro + " AND " + rblCriterio.SelectedValue + " LIKE '%" + vBuscado + "%'";

                if (rblCriterio.SelectedValue.Equals("habilitado"))
                {
                    if (vBuscado.ToUpper().Equals("SI"))
                        vBuscado = "true";

                    if (vBuscado.ToUpper().Equals("NO"))
                        vBuscado = "false";

                    bool b = true;
                    bool.TryParse(vBuscado, out b);
                    
                    if(b)
                        filtro = filtro + " AND " + rblCriterio.SelectedValue + " = " + vBuscado + "";
                    else
                        filtro = filtro + " AND 0 > 1 ";
                }
            }
            dv.RowFilter = filtro;

            gridUsuario.DataSource = dv;
            gridUsuario.DataBind();

            dropMenu.ClearSelection();
            dropTipoUsuario.ClearSelection();
            dropUnidad.ClearSelection();
            dropDependencia.ClearSelection();
            cbListMenus.Items.Clear();
            gridCargo.DataSource = null;
            gridCargo.DataBind();

            ocultarLblSuccess();
            ocultarLblError();
        }

        private bool validarControlesInsertar()
        {
            bool controlesValidos = false;
            lblErrorTipo.Text = string.Empty;
            lblErrorUnidad.Text = string.Empty;

            try
            {
                if (dropTipoUsuario.SelectedValue.Equals("0") || dropTipoUsuario.Items.Count == 0)
                    lblErrorTipo.Text = "Seleccione un valor!";

                if (dropUnidad.SelectedValue.Equals("0") || dropUnidad.Items.Count == 0)
                    lblErrorUnidad.Text = "Seleccione un valor!";

                if (dropDependencia.SelectedValue.Equals("0") || dropUnidad.Items.Count == 0)
                    lblErrorDependencia.Text = "Seleccione un valor!";

                if (!lblErrorTipo.Text.Equals(string.Empty) || !lblErrorUnidad.Text.Equals(string.Empty) || !lblErrorDependencia.Text.Equals(string.Empty))
                    return controlesValidos;

                controlesValidos = true;
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesInsertar(). " + ex.Message);
            }

            return controlesValidos;
        }

        protected void ocultarLblError()
        {
            lblError.Text = string.Empty;
            lblErrorM.Text = string.Empty;

            lblErrorTipo.Text = string.Empty;
            lblErrorUnidad.Text = string.Empty;
            lblErrorDependencia.Text = string.Empty;
        }

        protected void ocultarLblSuccess()
        {
            lblSuccess.Text = string.Empty;
            lblSuccessM.Text = string.Empty;
        }

        protected void dropDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ocultarLblSuccess();
            ocultarLblError();
        }

        protected void dropTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ocultarLblSuccess();
            ocultarLblError();
        }
       
    }
}
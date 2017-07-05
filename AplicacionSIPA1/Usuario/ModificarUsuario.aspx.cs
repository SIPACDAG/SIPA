using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using CapaEN;
using System.Data;

namespace AplicacionSIPA1.Usuario
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        private UsuariosLN usuarioL;
        private UsuariosEN usuarioE;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                usuarioL = new UsuariosLN();
                usuarioL.gridUsuario(gridUsuario);
                usuarioL.dropEmpleados(ddlEmpleados);
                ViewState["idU"] = 0;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {//inicio
            usuarioL = new UsuariosLN();
            usuarioE = new UsuariosEN();

            this.lblError.Visible = false;
            this.lblError.Text = String.Empty;
            this.lblError.ForeColor = System.Drawing.Color.White;

            this.lblSuccess.Visible = false;
            this.lblSuccess.Text = String.Empty;
            this.lblSuccess.ForeColor = System.Drawing.Color.White;

            this.Page.Validate("vacios");

            //Verifica que los campos no esten  vacios 
            if (this.Page.IsValid)
            {
                if (Convert.ToInt32(ViewState["idU"]) != 0)
                {

                    //Verifica que el nombre de usuario no exista 
                    if (usuarioL.Exite_NombreUsuario(this.text_usuario.Text, Convert.ToInt32(ViewState["idU"])) == 0)
                    {
                        try
                        {
                            int idEmpleado = 0;
                            int.TryParse(ddlEmpleados.SelectedValue, out idEmpleado);
                            //if(idEmpleado > 0)
                            if (true)
                            {
                                if (TextPass_Nuevo.Text.Length > 0)
                                {
                                    Regex val = new Regex("^[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ]+$");
                                    //Verifica que las contrañas no contengas caracteres especiales
                                    if (val.IsMatch(this.TextPass_Nuevo.Text) && val.IsMatch(this.TextPass_Confirmar.Text))
                                    {
                                        //Verifica que las contraseñas coincidan
                                        if (this.TextPass_Nuevo.Text == this.TextPass_Confirmar.Text)
                                        {
                                            usuarioE.IdUsuario = Convert.ToInt32(ViewState["idU"]);
                                            usuarioE.Usuario = this.text_usuario.Text.ToLower();
                                            usuarioE.Contrasena = TextPass_Nuevo.Text;
                                            usuarioE.idEmpleado = Convert.ToInt32(ddlEmpleados.SelectedValue);
                                            usuarioE.Habilitado = Convert.ToInt16(dropActivo.SelectedValue);
                                            //usuarioE.Nombre = txtNombre.Text;
                                            if (usuarioL.ModificarUsuario(usuarioE, ((Label)Master.FindControl("lblUsuario")).Text))
                                            {
                                                this.text_usuario.Text = string.Empty;
                                                this.lblSuccess.Visible = true;
                                                this.lblSuccess.ForeColor = System.Drawing.Color.White;
                                                this.lblSuccess.Text = "El usuario fue Modificado correctamente ";
                                            }
                                            else
                                                this.lblError.Text = "El usuario no tienen los permisos para realizar la accion";
                                            
                                            limpiarControles();

                                        }
                                        else
                                        {
                                            this.lblError.Visible = true;
                                            this.lblError.Text = "Las contraseñas no coinciden";
                                        }

                                    }
                                    else
                                    {
                                        this.lblError.Visible = true;
                                        this.lblError.Text = "No se permiten caracteres especiales";
                                    }
                                }
                                else
                                {
                                    usuarioE.IdUsuario = Convert.ToInt32(ViewState["idU"]);
                                    usuarioE.Usuario = this.text_usuario.Text.ToLower();
                                    usuarioE.Contrasena = Convert.ToString(ViewState["Contra"]);
                                    usuarioE.idEmpleado = Convert.ToInt32(ddlEmpleados.SelectedValue);
                                    usuarioE.Habilitado = Convert.ToInt16(dropActivo.SelectedValue);
                                    //usuarioE.Nombre = txtNombre.Text;
                                    if (usuarioL.ModificarUsuario(usuarioE, ((Label)Master.FindControl("lblUsuario")).Text))
                                    {
                                        this.text_usuario.Text = string.Empty;
                                        this.lblSuccess.Visible = true;
                                        this.lblSuccess.ForeColor = System.Drawing.Color.White;
                                        this.lblSuccess.Text = "El usuario fue Modificado correctamente ";
                                    }
                                    else
                                        this.lblError.Text = "El usuario no tiene los permisos necesarios";
                                    
                                    limpiarControles();
                                    usuarioL.gridUsuario(gridUsuario);
                                }
                            }
                            else
                            {
                                this.lblError.Visible = true;
                                this.lblError.Text = "Error: Ingrese un nombre válido";

                            }
                        }
                        catch (Exception ex)
                        {

                            this.lblError.Visible = true;
                            this.lblError.Text = "Error al ingresar el usuario a la base de Datos: " + ex.Message;
                        }
                    }

                    else
                    {
                        this.lblError.Visible = true;
                        this.lblError.Text = "El nombre de usuario ya existe";
                    }


                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Debe de Seleccionar el Usuario";
                }

            }//fin

        }//final

        protected void btnCancelar_Click(object sender, EventArgs e)
        {//inicio
            limpiarControles();
        }//final

        private void limpiarControles()
        {

            this.text_usuario.Text = string.Empty;
            this.TextPass_Nuevo.Text = string.Empty;
            this.TextPass_Confirmar.Text = string.Empty;
            //txtNombre.Text = string.Empty;
            ddlEmpleados.ClearSelection();
            lblError.Visible = false;

            ViewState["idU"] = 0;
        }


 
        protected void gridUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["idU"] = gridUsuario.SelectedValue;
            usuarioL = new UsuariosLN();
            DataTable tabla;
            tabla = usuarioL.datosUsuario(Convert.ToInt32(ViewState["idU"]));

            text_usuario.Text = Convert.ToString(tabla.Rows[0]["Usuario"]).Trim();

            int idEmpleado = 0;
            int.TryParse(tabla.Rows[0]["ID_EMPLEADO"].ToString(), out idEmpleado);
            ddlEmpleados.SelectedValue = idEmpleado.ToString();

            TextPass_Nuevo.Text = Convert.ToString(tabla.Rows[0]["Contrasena"]).Trim();
            ViewState["Contra"] = Convert.ToString(tabla.Rows[0]["Contrasena"]).Trim();
            dropActivo.SelectedValue = Convert.ToString(tabla.Rows[0]["Habilitado"]);
            
        }

        protected void gridUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
              try
            {
            int idU;
            idU = Convert.ToInt32(gridUsuario.Rows[e.RowIndex].Cells[2].Text);
            if (idU != 0)
            {
                usuarioL = new UsuariosLN();
                usuarioE = new UsuariosEN();
                usuarioE.IdUsuario = idU;
                if (usuarioL.EliminarUsuario(usuarioE) == 0)
                {
                    this.text_usuario.Text = string.Empty;
                    this.lblSuccess.Visible = true;
                    this.lblSuccess.ForeColor = System.Drawing.Color.White;
                    this.lblSuccess.Text = "El usuario fue Eliminado correctamente ";
                    limpiarControles();
                    usuarioL.gridUsuario(gridUsuario);

                }
                else
                {
                    this.lblSuccess.Visible = false;
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error: Usuario No Eliminado :(";
                }
            }
            else
            {
                this.lblSuccess.Visible = false;
                this.lblError.Visible = true;
                this.lblError.Text = "Selecciones el Usuario";
            }
            }

              catch (Exception)
              {
                  this.lblSuccess.Visible = false;
                  this.lblError.Visible = true;
                  this.lblError.Text = "Error: No es posible Eliminar este usuario";
              }           



                
        }

        protected void gridUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            usuarioL = new UsuariosLN();
            gridUsuario.PageIndex = e.NewPageIndex;
            usuarioL.gridUsuario(gridUsuario);
            ViewState["idU"] = 0;
        }

       
    }
}
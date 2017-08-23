<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresarUsuarios.aspx.cs" Inherits="AplicacionSIPA1.Usuario.IngresarUsuarios" MasterPageFile="~/Principal.Master" %>





<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style3 {
            width: 15%;
        }

        .auto-style4 {
            width: 25%;
        }

        .auto-style11 {
            text-align: center;
            font-size: x-large;
        }
    </style>
</asp:Content>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width:80%;" >
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11" colspan="4"><strong>Ingresar Usuarios</strong></td>
                </tr>
                <tr>
                    <td class="auto-style3">Empleado</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="ddlEmpleados" runat="server" class="form-control" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style12">Usuario<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="text_usuario" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="text_usuario" runat="server" class="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                    </td>
                </tr>
                            <tr>
                                <td class="auto-style3">Usuario</td>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                <tr>
                    <td class="auto-style3">Contraseña<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextPass_Nuevo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextPass_Nuevo" runat="server" class="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style12">Confirmar<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextPass_Confirmar" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="TextPass_Confirmar" runat="server" class="form-control" placeholder="Confirmar Contraseña" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        <span class="label label-danger"><asp:Label ID="lblError" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span>
                    <span class="label label-success"><asp:Label ID="lblSuccess" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span>      
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" Width="142px" />
                        <asp:Button ID="btnCancelar" runat="server" class="btn btn-default" OnClick="btnCancelar_Click" Text="CANCELAR" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
            </table>
                        </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>





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
            color: #006699;
        }
        .auto-style12 {
            width: 15%;
        }
        .auto-style13 {
            width: 15%;
            text-align: right;
            height: 69px;
            color: #006699;
            font-size: medium;
        }
        .auto-style14 {
            width: 15%;
            text-align: right;
            font-size: medium;
        }
        .auto-style17 {
            width: 23%;
            height: 99px;
        }
        .auto-style18 {
            width: 25%;
            height: 99px;
        }
        .auto-style19 {
            width: 23%;
        }
        .auto-style20 {
            width: 15%;
            height: 82px;
        }
        .auto-style21 {
            width: 23%;
            height: 82px;
        }
        .auto-style22 {
            width: 25%;
            height: 82px;
        }
        .auto-style23 {
            width: 15%;
            height: 99px;
        }
        .auto-style24 {
            width: 23%;
            height: 69px;
        }
        .auto-style25 {
            width: 15%;
            height: 69px;
        }
        .auto-style26 {
            height: 69px;
        }
        .auto-style27 {
            color: #006699;
        }
        .auto-style29 {
            width: 15%;
            text-align: right;
            color: #006699;
            font-size: medium;
        }
        .auto-style30 {
            font-weight: normal;
        }
    </style>
</asp:Content>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width:81%; height: 352px;" >
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style19">
                        &nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11" colspan="4"><strong>Ingresar Usuarios</strong></td>
                </tr>
                <tr>
                    <td class="auto-style29">&nbsp;&nbsp;&nbsp;&nbsp; Empleado&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style19">

                            
                        <div class="dropdown show">
                             <asp:DropDownList ID="ddlEmpleados" runat="server" class="form-control dropdown" Width="100%">
                        </asp:DropDownList>
                        </div>
                       
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                            <tr>
                                <td class="auto-style13">
                                    <span class="auto-style30">
                                    <br />
                                    </span><b class="auto-style30">&nbsp;&nbsp;&nbsp;&nbsp; Usuario<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="text_usuario" CssClass="auto-style27" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                                    <span class="auto-style27">&nbsp;&nbsp;&nbsp; </span></b>
                                </td>
                                <td class="auto-style24">
                                    <asp:TextBox ID="text_usuario" runat="server" class="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                                </td>
                                <td class="auto-style25"></td>
                                <td class="auto-style26"></td>
                            </tr>
                <tr>
                    <td class="auto-style14"><span class="auto-style27">&nbsp;&nbsp;&nbsp;&nbsp; Contraseña</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextPass_Nuevo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios" CssClass="auto-style27"></asp:RequiredFieldValidator>
                        <span class="auto-style27">&nbsp;&nbsp;&nbsp; </span>
                    </td>
                    <td class="auto-style19">
                        <asp:TextBox ID="TextPass_Nuevo" runat="server" class="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style29"><strong class="auto-style30">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Confirmar<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextPass_Confirmar" CssClass="auto-style27" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp; </strong></td>
                    <td class="auto-style21">
                        <asp:TextBox ID="TextPass_Confirmar" runat="server" class="form-control" placeholder="Confirmar Contraseña" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style20"></td>
                    <td class="auto-style22"></td>
                </tr>
                <tr>
                    <td class="auto-style23">
                        <br />
                        <br />
                        <br />
                    </td>
                    <td class="auto-style17">
                        <br /><span class="label label-danger">
                        <asp:Label ID="lblError" runat="server" Font-Size="Medium" Text="Label" visible="False"></asp:Label>
                        </span><span class="label label-success">
                        <asp:Label ID="lblSuccess" runat="server" Font-Size="Medium" Text="Label" visible="False"></asp:Label>
                        </span><br />
                            
                    </td>
                    <td class="auto-style23"></td>
                    <td class="auto-style18"></td>
                </tr>
                            
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style19">
                                    <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" Width="142px" />
                                </td>
                                <td class="auto-style3">&nbsp;&nbsp;<asp:Button ID="btnCancelar" runat="server" class="btn btn-danger" OnClick="btnCancelar_Click" Text="CANCELAR" />
                                </td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            
            </table>
                        </ContentTemplate>
                    
 </asp:UpdatePanel>
</asp:Content>





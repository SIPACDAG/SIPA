<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjesEstrategicos.aspx.cs" Inherits="AplicacionSIPA1.Estrategia.EjesEstrategicos" MasterPageFile="~/Principal.Master" %>





<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    &nbsp;&nbsp;&nbsp;
    <br />
    <style type="text/css">
        .auto-style3 {
        }

        .auto-style4 {
            width: 25%;
        }

        .auto-style11 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style12 {
            width: 15%;
            height: 24px;
        }
        .auto-style13 {
            width: 25%;
            height: 24px;
        }
        .auto-style14 {
        }
        .auto-style17 {
            width: 15%;
            height: 22px;
        }
        .auto-style18 {
            width: 37%;
            height: 22px;
        }
        .auto-style19 {
            width: 25%;
            height: 22px;
        }
        .auto-style24 {
            width: 24%;
            height: 24px;
        }
        .auto-style25 {
            height: 22px;
        }
        .auto-style26 {
            font-size: small;
        }
        .auto-style30 {
            width: 21%;
            height: 24px;
        }
        .auto-style32 {
        }
        .auto-style33 {
            text-align: right;
            color: #006699;
            font-weight: bold;
        }
        .auto-style34 {
            width: 15%;
            height: 24px;
            text-align: right;
            color: #006699;
            font-weight: bold;
        }
        </style>
</asp:Content>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width:81%; height: 450px;" >
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style14" colspan="2">
                        &nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11" colspan="5"><strong>EJES ESTRATÉGICOS</strong></td>
                </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style14" colspan="2">&nbsp;</td>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style33">Planes Estratégicos:&nbsp;&nbsp;&nbsp; </td>
                                <td class="auto-style32" colspan="2">
                                    <asp:DropDownList ID="ddlPlanE" runat="server" AutoPostBack="True"  CssClass="dropdown dropdown-primary " class="form-control" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style17"></td>
                                <td class="auto-style18" colspan="2">
                                    <asp:Label ID="lblErrorAnio" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                    </td>
                                <td class="auto-style17">
                                </td>
                                <td class="auto-style19"></td>
                            </tr>
                            <tr>
                                <td class="auto-style34">Id:&nbsp;&nbsp;&nbsp; <br />
                                    <br />
                                    Código:&nbsp;&nbsp;&nbsp; </td>
                                <td class="auto-style24">
                                    <asp:Label ID="lblID" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control" placeholder="Código" MaxLength="2" Width="85%"></asp:TextBox>
                                </td>
                                <td class="auto-style30">
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="* Ingrese un valor" ForeColor="Red" ValidationGroup="grpDatos" CssClass="auto-style26"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="revCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="*Ingrese un valor numérico" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="grpDatos" CssClass="auto-style26"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style12">
                                    &nbsp;</td>
                                <td class="auto-style13">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style33">Eje Estratégico:&nbsp;&nbsp;&nbsp; </td>
                                <td class="auto-style14" colspan="2">
                                    <asp:TextBox ID="txtEje" runat="server" class="form-control" placeholder="Eje Estratégico" Width="95%"></asp:TextBox>
                                </td>
                                <td class="auto-style3" colspan="2">
                                    <asp:RequiredFieldValidator ID="rfvEje" runat="server" ControlToValidate="txtEje" ErrorMessage="* Ingrese un valor" ForeColor="Red" ValidationGroup="grpDatos" CssClass="auto-style26"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style25"></td>
                                <td class="auto-style25" colspan="4">
                                    <span >
                                    <asp:Label ID="lblError" runat="server" Font-Size="Medium" visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    &nbsp;<asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green" visible="False"></asp:Label>
                                    </span></td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style14" colspan="2">
                                    <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="grpDatos" Width="120px" />
                                    <asp:Button ID="btnNuevo" runat="server" class="btn btn-warning" OnClick="btnNuevo_Click" Text=" Nuevo  " Width="120px" />
                                    <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" class="btn btn-info" OnClick="btnBuscar_Click" Text="Buscar" Width="120px" />
                                    <br />
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style14" colspan="4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style14" colspan="2">
                                    &nbsp;</td>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style14" colspan="2">
                                    &nbsp;</td>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style14" colspan="2">&nbsp;</td>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
            </table>
                        </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>





<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanesEstrategicos.aspx.cs" Inherits="AplicacionSIPA1.Estrategia.PlanesEstrategicos" MasterPageFile="~/Principal.Master" %>





<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head"></asp:Content>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <asp:UpdatePanel ID="upIngreso" runat="server">
                <ContentTemplate>
                    <br />
                    <table style="width:80%;">
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="12" style="font-size: x-large; text-align: center;"><strong>PLANES ESTRATÉGICOS</strong></td>
                            <td style="width:5%;">
                                <asp:Label ID="lblIdPlan" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="12" style="color: #006699"><b>Nombre del Plan:</b><strong><asp:Label ID="lblErrorNombre" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="color: #CC0000">*</asp:Label>
                                </strong></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="12">
                                <asp:TextBox ID="txtNombre" runat="server" BackColor="#FFFF99" class="form-control" Height="100%" MaxLength="100" placeholder="Ingrese el nombre del plan" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="12" style="color: #006699"><b>Descripción del Plan:</b><strong><asp:Label ID="lblErrorDescripcion" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="color: #CC0000">*</asp:Label>
                                </strong></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="12">
                                <asp:TextBox ID="txtDescripcion" runat="server" BackColor="#FFFF99" class="form-control" Height="60px" MaxLength="500" placeholder="Ingrese la descripción del plan" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="4" style="color: #006699"><b>Año de inicio:</b><asp:Label ID="lblErrorAnioIni" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="font-weight: bold; color: #CC0000">*</asp:Label>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="4" style="color: #006699"><b>Año de finalización:</b><strong><asp:Label ID="lblErrorAnioFin" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="color: #CC0000">*</asp:Label>
                                </strong></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="4">
                                <asp:TextBox ID="txtAnioIni" runat="server" BackColor="#FFFF99" class="form-control" MaxLength="4" placeholder="" Width="60%"></asp:TextBox>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="4">
                                <asp:TextBox ID="txtAnioFin" runat="server" BackColor="#FFFF99" class="form-control" MaxLength="4" placeholder="" Width="60%"></asp:TextBox>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="12" style="text-align: center;"><span>
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                                </span></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="12" style="text-align: center;">
                                <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="grpDatos" Width="120px" />
                                <asp:Button ID="btnEliminar" runat="server" class="btn btn-danger" OnClick="btnEliminar_Click" Text="Eliminar" Width="120px" />
                                <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" class="btn btn-info" Text="Buscar" Width="120px" PostBackUrl="~/Estrategia/PlanesEstrategicosB.aspx" />
                                <asp:Button ID="btnNuevo" runat="server" class="btn btn-primary" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>





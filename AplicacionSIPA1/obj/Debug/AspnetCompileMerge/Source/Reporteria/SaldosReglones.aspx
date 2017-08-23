<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaldosReglones.aspx.cs" Inherits="AplicacionSIPA1.Reporteria.SaldosReglones" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <table style="width:100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td style="font-size: x-large">
                                    <b>Reglones</b></td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>Año</td>
                                <td>
                                    <asp:DropDownList ID="dropAnio" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="dropAnio_SelectedIndexChanged" Width="99%">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Unidades</td>
                                <td>
                                    <asp:DropDownList ID="dropUnidades" runat="server" AutoPostBack="True" BackColor="#003366" class="form-control" ForeColor="White" OnSelectedIndexChanged="dropUnidades_SelectedIndexChanged" Width="99%">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:RadioButtonList ID="rblOpcion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblOpcion_SelectedIndexChanged" RepeatDirection="Horizontal" Width="817px">
                                        <asp:ListItem Selected="True" Value="0">Todo</asp:ListItem>
                                        <asp:ListItem Value="P">Unidad Costo Poa</asp:ListItem>
                                        <asp:ListItem Value="C">Unidad Codificado</asp:ListItem>
                                        <asp:ListItem Value="S">Unidad Saldo</asp:ListItem>
                                        <asp:ListItem Value="E">Unidad Estimado</asp:ListItem>
                                        <asp:ListItem Value="R">Unidad Realizado</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="gridReportes" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnRowDataBound="gridReportes_RowDataBound" PageSize="5" ShowFooter="True" Width="95%" OnSelectedIndexChanged="gridReportes_SelectedIndexChanged">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#339933" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 81px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 81px">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    
                        </ContentTemplate>
                </asp:UpdatePanel>

            </asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <asp:LinkButton ID="lbExportar" runat="server" Font-Bold="True" Font-Size="Large" OnClick="lbExportar_Click">Exportar a Excel</asp:LinkButton>
</asp:Content>

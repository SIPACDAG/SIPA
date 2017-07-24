<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarAnalista.aspx.cs" Inherits="AplicacionSIPA1.Operativa.AsignarAnalista" MasterPageFile="~/Principal.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upBuscar" runat="server">
                <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="font-size: x-large;" class="text-center" colspan="9"><strong>CMI - ASIGNAR ANALISTA</strong></td>
                    <td colspan="2">
                        <br />
                        Asignados:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">Analistas POA:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="text-right" colspan="2">&nbsp;</td>
                    <td colspan="9" rowspan="8">
                        <asp:GridView ID="gridAsignaciones" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID,ANIO,ID_UNIDAD" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="5" Width="94%" OnPageIndexChanging="gridAsignaciones_PageIndexChanging" OnRowDeleting="gridAsignaciones_RowDeleting" CssClass="table table-hover table-responsive" style="margin-left: 24px">
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/delete.png" onclientclick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Eliminar" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="anio" HeaderText="Año">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Unidad" HeaderText="Unidad">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="monto" HeaderText="Monto">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="estado" HeaderText="Estado" Visible="False">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="10">
                        <asp:DropDownList ID="ddlAnalistas" runat="server" class="form-control" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddlAnalistas_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">
                        <asp:Label ID="lblPlanE" runat="server" Text="Plan Estratégico:"></asp:Label>
                    </td>
                    <td colspan="8">
                        <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">Año:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">Unidad:</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="5">
                        <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="5">
                        <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">Dependencia:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">Jefatura/Unidad:</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                 <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="5">
                        <asp:DropDownList ID="ddlDependencia" runat="server" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" AutoPostBack="True" class="form-control"  Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="5">
                        <asp:DropDownList ID="ddlJefaturaUnidad" runat="server" OnSelectedIndexChanged="ddlJefaturaUnidad_SelectedIndexChanged" AutoPostBack="True" class="form-control"  Width="100%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td class="text-center" colspan="10"><span>
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                        </span></td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="text-center" colspan="6">
                        <asp:Button ID="btnAsignar" runat="server" CausesValidation="False" class="btn btn-info" OnClick="btnAsignar_Click" Text="Asignar POA" Width="120px" />
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="3">Pendientes de asignar:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="10">
                        <asp:GridView ID="gridPlanes" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID,ANIO,ID_UNIDAD" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnPageIndexChanging="gridPlanes_PageIndexChanging" OnSelectedIndexChanged="gridPlanes_SelectedIndexChanged" PageSize="20" Width="100%" CssClass="table table-hover table-responsive" >
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkPlan" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="anio" HeaderText="Año">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Unidad" HeaderText="Unidad">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="monto" HeaderText="Monto">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="estado" HeaderText="Estado" Visible="False">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>

            </table>
                    <br />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>





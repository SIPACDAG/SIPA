<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminListadoPlan.aspx.cs" Inherits="AplicacionSIPA1.Pac.AdminListadoPlan" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <br />
                        <br />
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="18"style="font-size: x-large; text-align: center;" class="text-center"><strong>LISTADO - PLAN ANUAL DE COMPRAS</strong></td>
                                <td style="width: 5%"><strong>
                                    <asp:Label ID="lblIdPoa" runat="server" ForeColor="White" style="font-size: medium">0</asp:Label>
                                    </strong></td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="18" style="text-align: center"></b><strong>
                                <asp:Label ID="lblErrorPoa" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                                </strong></td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="9">Año:</td>
                                <td colspan="9">Unidad:</td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="9">
                                    <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="9">
                                    <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
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
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">
                                    <asp:Label ID="lblPlanE" runat="server" Text="PE"></asp:Label>
                                </td>
                                <td style="width: 5%">
                                    <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" Width="50%">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="9">Acciones:</td>
                                <td colspan="9">Renglones:</td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="9">
                                    <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="9">
                                    <asp:DropDownList ID="ddlRenglones" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlRenglones_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
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
                                <td colspan="18" style="text-align: center;"><span>
                                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                    </span></td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="18" style="text-align: center">
                                    <asp:Button ID="btnActualizar" runat="server" class="btn btn-default" OnClick="btnActualizar_Click" Text="Actualizar" Width="120px" />
                                    <asp:Button ID="btnModificar" runat="server" BackColor="#FF6600" class="btn btn-primary" Font-Bold="True" OnClick="btnModificar_Click" Text="MODIFICAR PAC" Visible="False" Width="120px" />
                                </td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="18">
                                    <asp:GridView ID="gridPac" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnRowDataBound="gridPac_RowDataBound" OnRowDeleting="gridPac_RowDeleting" OnSelectedIndexChanged="gridPac_SelectedIndexChanged" ShowFooter="True" Width="100%" Font-Size="X-Small">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <Columns>
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:CommandField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/delete.png" onclientclick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Eliminar" />
                                                </ItemTemplate>
                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" HeaderText="NoPac">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" Font-Size="Large" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="accion" HeaderText="Acción">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="no_renglon" HeaderText="No Renglon">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="monto" HeaderText="Monto">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="codificado" HeaderText="Codificado">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="saldo" HeaderText="Saldo">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="categoria" HeaderText="Categoria">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="modalidad" HeaderText="Modalidad">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="excepcion" HeaderText="Excepcion">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fecha_ing" HeaderText="Fecha Ingreso">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
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
                        <br />
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Content>



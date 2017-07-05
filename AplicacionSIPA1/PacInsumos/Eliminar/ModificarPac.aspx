<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPac.aspx.cs" Inherits="AplicacionSIPA1.Pac.ModificarPac" MasterPageFile="~/Principal.Master" %>
<%@ PreviousPageType VirtualPath="~/Pac/ListadoPacs.aspx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td colspan="5">
                                    <asp:DropDownList ID="dropAccion" runat="server" AutoPostBack="True" BackColor="#003366" class="form-control" ForeColor="White" OnSelectedIndexChanged="dropAccion_SelectedIndexChanged" Width="99%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:GridView ID="gridRenglon" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Width="95%">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <Columns>
                                            <asp:BoundField DataField="ID" HeaderText="ID">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NoReglon" HeaderText="Renglon">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Fuente" HeaderText="Fuente">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CostoPoa" DataFormatString="{0:c}" HeaderText="MontoPoa">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Codificado" DataFormatString="{0:c}" HeaderText="Codificado">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SaldoPoa" DataFormatString="{0:c}" HeaderText="SaldoPoa">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MontoPac" DataFormatString="{0:c}" HeaderText="MontoPacs">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SaldoPac" DataFormatString="{0:c}" HeaderText="SaldoPac">
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
                            </tr>
                            <tr>
                                <td style="width: 232px">Modalidad</td>
                                <td>
                                    <asp:DropDownList ID="dropModalidad" runat="server" AutoPostBack="True" class="form-control" Width="99%">
                                    </asp:DropDownList>
                                </td>
                                <td>Excepcion</td>
                                <td>
                                    <asp:DropDownList ID="dropExcepcion" runat="server" AutoPostBack="True" class="form-control" Width="99%">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 232px">Descripcion<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" MaxLength="800" placeholder="Descripcion del Pac" TextMode="MultiLine" Width="99%"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 232px">Monto Pac
                                    <asp:Label ID="lblMontoPac" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#006600">0</asp:Label>
                                    &nbsp;Codificado
                                    <asp:Label ID="lblCodificadoPac" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#339933">0</asp:Label>
                                </td>
                                <td colspan="3">
                                    Saldo<asp:Label ID="lblSaldoPac" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#006600">0</asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 232px">&nbsp;</td>
                                <td colspan="3">
                                    <asp:Button ID="btnModificar" runat="server" BackColor="#FF3300" class="btn btn-primary" OnClick="btnModificar_Click" Text="Modificar Pac" Width="40%" />
                                    <asp:Button ID="btnCancelar" runat="server" class="btn btn-default" PostBackUrl="~/Pac/ListadoPacs.aspx" Text="CANCELAR" Width="20%" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style19" colspan="5">
                                    <span class="label label-danger"><asp:Label ID="lblError" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span>
                    <span class="label label-success"><asp:Label ID="lblSuccess" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span> </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>

    <asp:GridView ID="gridDetalle" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnRowDataBound="gridDetalle_RowDataBound" OnSelectedIndexChanged="gridDetalle_SelectedIndexChanged" PageSize="5" Width="50%">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <Columns>
                                            <asp:BoundField DataField="ID" HeaderText="ID">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Mes" HeaderText="Mes">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="MontoTotal">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblModificarMes" runat="server" Text="0"></asp:Label>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtMonto" runat="server" Width="50%"></asp:TextBox>
                                                    <asp:RangeValidator ID="RangeValidatorMonto" runat="server" ControlToValidate="txtMonto" ErrorMessage="Solo Numeros" Font-Bold="True" ForeColor="#CC0000" MaximumValue="5000000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                                                </ItemTemplate>
                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cantidad">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCantidad" runat="server" Width="40%"></asp:TextBox>
                                                    <asp:RangeValidator ID="RangeValidatorCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Solo Numeros" Font-Bold="True" ForeColor="#CC0000" MaximumValue="100000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                                                </ItemTemplate>
                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="idPD" Visible="False">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("idPD") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblidPD" runat="server" Text="0"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>

            </asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <p>

    
        <span style="font-weight: normal; font-size: large">

        </span><span style="font-family: 'Arial Black'; font-weight: normal; color: #008000; font-size: large">No. de PAC:</span><span style="font-family: 'Arial Black'; font-weight: normal; font-size: medium; color: #008000"> </span>
        <asp:Label ID="lblPac" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#006600">0</asp:Label>
    </p>
</asp:Content>



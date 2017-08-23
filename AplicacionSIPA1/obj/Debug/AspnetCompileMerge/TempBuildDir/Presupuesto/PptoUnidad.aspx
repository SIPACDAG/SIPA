<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PptoUnidad.aspx.cs" Inherits="AplicacionSIPA1.Presupuesto.PptoUnidad" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style3 {
        }

        .auto-style4 {
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
                    <td class="auto-style11" colspan="4"><strong>PRESUPUESTO/UNIDAD</strong></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp; Año</td>
                    <td class="auto-style4" colspan="3">
                        <asp:DropDownList ID="dropAnio" runat="server" class="form-control" Width="20%" OnSelectedIndexChanged="dropAnio_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                            <tr>
                                <td class="auto-style3">&nbsp; Unidad</td>
                                <td class="auto-style4" colspan="3">
                                    <asp:DropDownList ID="dropUnidad" runat="server" class="form-control" OnSelectedIndexChanged="dropUnidad_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                <tr>
                    <td class="auto-style3">&nbsp; Monto<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMonto" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtMonto" runat="server" class="form-control" placeholder="Monto a Asignar" Width="25%"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtMonto" ErrorMessage="* Ingrese un valor numérico" Font-Bold="True" ForeColor="Red" MaximumValue="300000000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4" colspan="3">
                        <asp:Label ID="lblError" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="Red" ></asp:Label></span>
                        <asp:Label ID="lblSuccess" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="Green" ></asp:Label></span>      
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" Width="120px" />
                        <asp:Button ID="btnCancelar" runat="server" class="btn btn-default" OnClick="btnCancelar_Click" Text="Nuevo" Width="120px" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                            <tr>
                                <td class="auto-style7">
                                    &nbsp;</td>
                                <td class="auto-style7" colspan="3">
                                    <asp:GridView ID="gridPresupuesto" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnRowDataBound="gridPresupuesto_RowDataBound" OnRowDeleting="gridPresupuesto_RowDeleting" PageSize="5" ShowFooter="True" Width="65%">
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
                                            <asp:BoundField DataField="Unidad" HeaderText="Unidad">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Monto" HeaderText="Monto">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Anio" DataFormatString="{0:d}" HeaderText="Año">
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
            </table>
                        </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>





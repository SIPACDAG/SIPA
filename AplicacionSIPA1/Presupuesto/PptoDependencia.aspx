<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PptoDependencia.aspx.cs" Inherits="AplicacionSIPA1.Presupuesto.PptoDependencia" MasterPageFile="~/Principal.Master" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style3 {
        }

        .auto-style4 {
            width: 65%;
        }
        .auto-style5 {
            width: 80%;
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
                    <td class="auto-style11" colspan="4"><strong>PRESUPUESTO/DEPENDENCIA</strong></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp; Año</td>
                    <td class="auto-style4" colspan="3">
                        <asp:DropDownList ID="dropAnio" runat="server" class="form-control" Width="20%" OnSelectedIndexChanged="dropAnio_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                            <tr>
                                <td class="auto-style3">&nbsp; Saldo</td>
                                <td class="auto-style4" colspan="3">
                                    <asp:Label ID="lblMontoAsignable" runat="server" Font-Bold="True" Font-Size="Large" Text="0.00"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;Unidad</td>
                                <td class="auto-style4" colspan="3">
                                    <asp:DropDownList ID="dropUnidad" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropUnidad_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp; Dependencia</td>
                                <td class="auto-style4" colspan="3">
                                    <asp:DropDownList ID="dropDependencia" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                <tr>
                    <td class="auto-style3">&nbsp; Monto<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMonto" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtMonto" runat="server" class="form-control" placeholder="Monto a Asignar" Width="25%"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtMonto" ErrorMessage="Solo Numeros" Font-Bold="True" ForeColor="Red" MaximumValue="300000000" MinimumValue="1" Type="Double"></asp:RangeValidator>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblError" runat="server"  visible="False" Font-Size="Medium" Font-Bold="True" ForeColor="Red" ></asp:Label></span>
                    <asp:Label ID="lblSuccess" runat="server"  visible="False" Font-Size="Medium" Font-Bold="True" ForeColor="Green" ></asp:Label></span>      
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
                            <tr>
                                <td class="auto-style5" colspan="4">
                                    <asp:GridView ID="gridPresupuesto" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="5" Width="65%" ShowFooter="True" OnRowDataBound="gridPresupuesto_RowDataBound" OnRowDeleting="gridPresupuesto_RowDeleting">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <Columns>                                         
                                            <asp:BoundField DataField="ID" HeaderText="ID">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Dependencia" HeaderText="Dependencia">
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
                                        <FooterStyle BackColor="White" ForeColor="Black"  BorderStyle="Inset"  HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
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






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
        .auto-style12 {
            text-align: right;
        }
        .auto-style13 {
            display: block;
            font-size: small;
            line-height: 1.42857143;
            color: #2c3e50;
            border-radius: 4px;
            -webkit-box-shadow: none;
            box-shadow: none;
            -webkit-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            border: 1px solid #dce4ec;
            padding: 10px 15px;
            background-color: #ffffff;
            background-image: none;
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
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4" colspan="3">
                       <%-- <asp:DropDownList ID="ddlPlanE" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlPlanE_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>--%>
                        <asp:DropDownList ID="ddlPlanE" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlPlanE_SelectedIndexChanged" Width="30%"></asp:DropDownList>
                    </td>
                </tr>
                            <tr>
                                <td class="auto-style12">&nbsp; Año&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td class="auto-style4" colspan="3">
                                    <asp:DropDownList ID="dropAnio" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="dropAnio_SelectedIndexChanged" Width="20%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">&nbsp; Unidades&nbsp;&nbsp;&nbsp; </td>
                                <td class="auto-style4" colspan="3">
                                   <%-- <asp:DropDownList ID="dropUnidad" runat="server" class="form-control" OnSelectedIndexChanged="dropUnidad_SelectedIndexChanged" Height="45%">
                                    </asp:DropDownList>--%>
                                    <asp:DropDownList ID="ddlUnidad" AutoPostBack="true" runat="server" CssClass="auto-style13" OnSelectedIndexChanged="ddlUnidad_SelectedIndexChanged" Height="45%" Width="315px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">&nbsp; Dependencias&nbsp;&nbsp;&nbsp; </td>
                                <td class="auto-style4" colspan="3">
                                    <asp:DropDownList ID="ddlDependencias" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" Height="45%" Width="314px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">&nbsp; Unidades/Jefaturas&nbsp;&nbsp;&nbsp; </td>
                                <td class="auto-style4" colspan="3">
                                    <asp:DropDownList ID="ddlJefaturasSub" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlJefaturasSub_SelectedIndexChanged" class="form-control" Height="45%" Width="313px" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                <tr>
                    <td class="auto-style12">&nbsp; Monto<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMonto" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;
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
                    <td class="auto-style12"><asp:Label Text="Monto Global" ID="lblMontoGlobal" runat="server"  ></asp:Label></span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMonto" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtMontoGlobal" runat="server" class="form-control" placeholder="Monto a Asignar" Width="25%"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtMontoGlobal" ErrorMessage="* Ingrese un valor numérico" Font-Bold="True" ForeColor="Red" MaximumValue="300000000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                    </td>
                    <td class="text-left">&nbsp; Monto Global: <asp:Label ID="lblMontoGlobalUni" Font-Size="Medium" runat ="server" Font-Bold="true" ForeColor="Green" Text="0.00"></asp:Label> </td>
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
                        <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" Width="120px" />
                        <asp:Button ID="btnCancelar" runat="server" class="btn btn-warning" OnClick="btnCancelar_Click" Text="Nuevo" Width="120px" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                            <tr>
                                <td class="auto-style7">
                                    &nbsp;</td>
                                <td class="auto-style7" colspan="3">
                                    <asp:GridView ID="gridPresupuesto" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnRowDataBound="gridPresupuesto_RowDataBound" OnRowDeleting="gridPresupuesto_RowDeleting" PageSize="5" ShowFooter="True" Width="65%" CssClass="table table-hover table-responsive" OnSelectedIndexChanged="gridPresupuesto_SelectedIndexChanged" >
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





<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoBoN2.aspx.cs" Inherits="AplicacionSIPA1.Operativa.VoBoN2" MasterPageFile="~/Principal.Master" %>



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
                    <table style="width:100%">
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
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16" style="text-align: center">
                                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="X-Large" Text="CMI - APROBACIÓN ANALISTA"></asp:Label>
                                </td>
                            <td colspan="2"><strong>
                                <asp:Label ID="lblIdPoa" runat="server" style="font-size: medium" ForeColor="White"></asp:Label>
                                </strong></td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16" style="text-align: center"><strong>
                                <asp:Label ID="lblErrorPoa" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                                </strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">Año:</td>
                            <td colspan="8">
                                <asp:Label ID="lblPlanE" runat="server" Text="Plan Estratégico:"></asp:Label>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlAnios" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlPlanes" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">Unidad:</td>
                            <td colspan="8">Dependencia:</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlUnidades" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlDependencias" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">Jefatura/Unidad:</td>
                            
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlJefaturaUnidad" runat="server" class="form-control" AutoPostBack="True"  Width="100%" OnSelectedIndexChanged="ddlJefaturaUnidad_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td colspan="8">
                                
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4">Presupuesto Aprobado:</td>
                            <td colspan="4">Presupuesto Disponible:</td>
                            <td colspan="4">Presupuesto Aprobado:</td>
                            <td colspan="4">Presupuesto Disponible:</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4" style="text-align: right"><asp:Label ID="lblTechoU" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="0.00"></asp:Label>
                                </td>
                            <td colspan="4" style="text-align: right"><asp:Label ID="lblDisponibleU" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="0.00"></asp:Label>
                                </td>
                            <td colspan="4" style="text-align: right"><asp:Label ID="lblTechoD" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="0.00"></asp:Label>
                                </td>
                            <td colspan="4" style="text-align: right"><asp:Label ID="lblDisponibleD" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="0.00"></asp:Label>
                                </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">Acciones:</td>
                            <td colspan="4" style="text-align: right">Estado del CMI:</td>
                            <td colspan="4" style="text-align: right"><strong>
                                <asp:Label ID="lblEstadoPoa" runat="server" style="font-size: medium"></asp:Label>
                                </strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16">
                                <asp:DropDownList ID="ddlAcciones" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
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
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">
                                <asp:RadioButtonList ID="rblMostrar" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblMostrar_SelectedIndexChanged" RepeatDirection="Horizontal" Width="90%">
                                    <asp:ListItem Selected="True" Value="1">Todo</asp:ListItem>
                                    <asp:ListItem Value="2">Estratégico/Operativo</asp:ListItem>
                                    <asp:ListItem Value="3">Operativo/Acciones</asp:ListItem>
                                    <asp:ListItem Value="4">Acción</asp:ListItem>
                                </asp:RadioButtonList>
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
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16">
                                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16">
                                <asp:TextBox ID="txtObser" runat="server" class="form-control" Enabled="False" Height="100px" MaxLength="750" placeholder="Observaciones" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16" style="text-align: center"><span>
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                                </span></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16" style="text-align: center">
                                <asp:Button ID="btnAprobar" runat="server" CausesValidation="False" class="btn btn-success" OnClick="btnAprobar_Click" Text="Aprobar" Width="120px" />
                                <asp:Button ID="btnRechazar" runat="server" class="btn btn-danger" OnClick="btnRechazar_Click" Text="Rechazar" ValidationGroup="grpDatos" Width="120px" />
                                <asp:Button ID="btnVerReporte" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnVerReporte_Click" Text="Ver Reporte" Width="120px" />
                                <asp:Button ID="btnCodificar" runat="server" class="btn btn-warning" OnClick="btnCodificar_Click" Text="Codificar" ValidationGroup="grpDatos" Width="120px" />
                                <asp:Button ID="btnActualizar" runat="server" CausesValidation="False" class="btn btn-info" OnClick="btnActualizar_Click" Text="Actualizar!" Width="120px" />
                            </td>
                            <td style="width: 5%">&nbsp;</td>
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
                    <div>
                        <table style="width:100%">
                            <tr>
                            <td colspan="24">
                                <asp:GridView ID="gridPlan" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID,ID_ACCION" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="50" Width="100%" OnRowDataBound="gridPlan_RowDataBound">
                                    <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cod_ee" HeaderText="Cód. EE">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" Font-Size="Large" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="eje" HeaderText="Eje">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Cód OE">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("cod_oe") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("cod_oe") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="objetivo_estrategico" HeaderText="OE">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="indicador_e" HeaderText="KPI">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="meta_e" HeaderText="Meta">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Cód. OO">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("cod_oo") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("cod_oo") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="objetivo_operativo" HeaderText="OOp.">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="anio" HeaderText="Año">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="indicador_o" HeaderText="Indicador O.">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="meta_o" HeaderText="Meta O.">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="responsable" HeaderText="Responsable">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Cod. A.">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigo_accion") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("codigo_accion") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="accion" HeaderText="Acción">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="meta_general" HeaderText="Meta">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="meta_1" HeaderText="Meta 1er. C.">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="meta_2" HeaderText="Meta 2do. C.">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="meta_3" HeaderText="Meta 3er. C.">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Ponderación">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ponderacion") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ponderacion") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Presupuesto">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("presupuesto") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:GridView ID="gridRenglon" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" PageSize="50" ShowFooter="True" Width="100%">
                                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                                        <Columns>
                                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="no_renglon" HeaderText="Renglon">
                                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle BorderStyle="Inset" Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="CostoPoa">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("monto") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <div class="text-right">
                                                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Small" Text='<%# Bind("monto", "Q.{0:0,0.00}") %>'></asp:Label>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Codificado">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("codificado") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <div class="text-right">
                                                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Small" Text='<%# Bind("codificado", "Q.{0:0,0.00}") %>'></asp:Label>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Saldo">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("saldo") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <div class="text-right">
                                                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Small" Text='<%# Bind("saldo", "Q.{0:0,0.00}") %>'></asp:Label>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Right" VerticalAlign="Middle" />
                                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                                    </asp:GridView>
                                                    <br />
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("presupuesto", "Q.{0:0,0.00}") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="responsable_accion" HeaderText="Responsable">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ene" HeaderText="E">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="feb" HeaderText="F">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="mar" HeaderText="M">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="abr" HeaderText="A">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="may" HeaderText="M">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="jun" HeaderText="J">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="jul" HeaderText="J">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ago" HeaderText="A">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sep" HeaderText="S">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="oct" HeaderText="O">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nov" HeaderText="N">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dic" HeaderText="D">
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
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <div>
                        <table style="width:100%">
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
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="12">
                                    <asp:GridView ID="gridRenglonesUnidad" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" PageSize="50" ShowFooter="True" Width="100%">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <Columns>
                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="no_renglon" HeaderText="Renglon">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="CostoPoa">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("monto") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <div class="text-right">
                                                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="X-Small" Text='<%# Bind("monto", "Q.{0:0,0.00}") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Codificado">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("codificado") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <div class="text-right">
                                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="X-Small" Text='<%# Bind("codificado", "Q.{0:0,0.00}") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Saldo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("saldo") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <div class="text-right">
                                                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="X-Small" Text='<%# Bind("saldo", "Q.{0:0,0.00}") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
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
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>





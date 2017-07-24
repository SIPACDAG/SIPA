<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoBoN2.aspx.cs" Inherits="AplicacionSIPA1.Pedido.Ajustes.VoBoN2" MasterPageFile="~/Principal.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <p>
        d</p>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upIngreso" runat="server">
                <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td style="width: 5%; background-color: #006600;">
                        <asp:Label ID="lblPlanE" runat="server" Text="*"></asp:Label>
                    </td>
                    <td style="width: 5%; background-color: #006600;"><strong>
                        <asp:Label ID="lblErrorPlan" runat="server" ForeColor="Red" style="font-size: medium" Visible="False">*</asp:Label>
                        <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" Width="50%" Visible="False">
                        </asp:DropDownList>
                        </strong></td>
                    <td style="font-size: x-large; text-align: center; color: #FFFFFF; background-color: #006600;" class="text-center" colspan="16"><strong>VoBo UNIDAD DE PRESUPUESTO<br /> AJUSTE DE REQUISICIONES</strong></td>
                    <td class="text-right" colspan="2" style="font-size: x-large; background-color: #006600;">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td colspan="18" style="text-align: center;"><strong>
                        <asp:Label ID="lblErrorPoa" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td style="width: 5%"><strong>
                        <asp:Label ID="lblIdPoa" runat="server" ForeColor="White" style="font-size: medium">0</asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="9">Año:<strong><asp:Label ID="lblErrorAnio" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="3">Unidad:<strong><asp:Label ID="lblErrorUnidad" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td class="text-right" colspan="6">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
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
                    <td>&nbsp;</td>
                    <td colspan="9">Dependencia:</td>
                    <td colspan="3">Jefatura/Unidad:</td>
                    <td class="text-right" colspan="6">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td colspan="9">
                        <asp:DropDownList ID="ddlDependencia" runat="server" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" AutoPostBack="True" class="form-control"  Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="9">
                        <asp:DropDownList ID="ddlJefaturaUnidad" runat="server" OnSelectedIndexChanged="ddlJefaturaUnidad_SelectedIndexChanged" AutoPostBack="True" class="form-control"  Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="18"><strong><asp:Label ID="lblErrorAccion" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="18">
                        <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" BackColor="#003366" class="form-control" ForeColor="White" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" Width="100%" Visible="False">
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
                    <td colspan="9">Ajustes:&nbsp;</td>
                    <td colspan="9">Estado del ajuste:</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="9">
                        <asp:DropDownList ID="ddlAjustes" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" OnSelectedIndexChanged="ddlAjustes_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="9">
                        <strong>
                        <asp:Label ID="lblEstadoAjuste" runat="server" style="font-size: medium"></asp:Label>
                        </strong>
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
                    <td colspan="9">Requisición relacionada al ajuste:<strong><asp:Label ID="lblNoAjuste" runat="server" style="font-size: medium" ForeColor="White">0</asp:Label>
                        <asp:Label ID="lblIdAjuste" runat="server" ForeColor="White" style="font-size: medium">0</asp:Label>
                        </strong></td>
                    <td class="text-left" colspan="9">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="9">
                        <asp:DropDownList ID="ddlNoDocumento" runat="server" AutoPostBack="True" class="form-control" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td class="text-left" colspan="9"><strong>
                        <asp:RadioButtonList ID="rblTipoDocto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblTipoDocto_SelectedIndexChanged" RepeatDirection="Horizontal" Visible="False" Width="95%">
                            <asp:ListItem Selected="True" Value="1">Requisiciones</asp:ListItem>
                            <asp:ListItem Value="2">Vales</asp:ListItem>
                        </asp:RadioButtonList>
                        </strong></td>
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
                    <td colspan="9">Solicitantes:<strong><asp:Label ID="lblErrorSolicitante" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="9">Subgerentes/Directores:<strong><asp:Label ID="lblErrorJefe" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="9">
                        <asp:DropDownList ID="ddlSolicitantes" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" OnSelectedIndexChanged="ddlSolicitantes_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="9">
                        <asp:DropDownList ID="ddlJefes" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" OnSelectedIndexChanged="ddlJefes_SelectedIndexChanged" Width="100%">
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="16">Justificación:<strong><asp:Label ID="lblErrorJustificacion" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="16">
                        <asp:TextBox ID="txtJustificacion" runat="server" class="form-control" Enabled="true" Height="100px" MaxLength="750" placeholder="Ingrese la justificación del ajuste" TextMode="MultiLine" Width="100%" BackColor="#FFFF99"></asp:TextBox>
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
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="16">
                        <asp:GridView ID="gridDet" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID_AJUSTE_PEDIDO_DET,ID_PEDIDO_DETALLE,ID_DETALLE_ACCION,ID_PAC" Font-Size="XX-Small" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="12" ShowFooter="True" Width="100%"
                            CssClass="table table-hover table-responsive">
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True" Visible ="false">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:CommandField>
                                <asp:TemplateField ShowHeader="False" Visible ="false">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/delete.png" onclientclick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Eliminar" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID_AJUSTE_PEDIDO_DET" HeaderText="ID_AJUSTE_PEDIDO_DET" Visible="False">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="numero" HeaderText="No.">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN DEL BIEN Y/O SERVICIO">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="unidad_medida" HeaderText="UNIDAD MEDIDA">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="CANTIDAD">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True" Text='<%# Bind("cantidad") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text='<%# Bind("cantidad") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VALOR ESTIMADO INDIVIDUAL SIN IVA">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" Text='<%# Bind("costo_estimado") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Bind("costo_estimado", "Q.{0:0,0.00}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SUBTOTAL">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Font-Bold="True" Text='<%# Bind("subtotal") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Bind("subtotal", "Q.{0:0,0.00}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="renglon_ppto" HeaderText="RENGLÓN PPTO.">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="MONTO AJUSTE">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Font-Bold="True" Text='<%# Bind("monto_ajuste") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:TextBox ID="txtMontoAjuste" runat="server" Text='<%# Bind("monto_ajuste") %>' BackColor="#FFFF99" class="form-control" Font-Size="Large" MaxLength="10" Style="text-align: right" Width="100%" ReadOnly="True"></asp:TextBox>
                                            <asp:Label ID="lblErrorMontoAjuste" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">Observaciones:<strong><asp:Label ID="lblErrorObservaciones" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">
                        <asp:TextBox ID="txtObser" runat="server" class="form-control" Height="100px" MaxLength="750" placeholder="Observaciones" TextMode="MultiLine" Width="100%" BackColor="#FFFF99"></asp:TextBox>
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="16" style="text-align: center">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <img alt="Cargando" class="auto-style20" longdesc="Imagen de Cargando" src="../img/cargar.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="16" style="text-align: center"><span>
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                        </span></td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16" style="text-align: center">
                        <asp:Button ID="btnAprobar" runat="server" class="btn btn-success" OnClick="btnAprobar_Click" Text="Aprobar" ValidationGroup="grpDatos" Width="120px" />
                        <asp:Button ID="btnRechazar" runat="server" class="btn btn-danger" Text="Rechazar" Width="120px" OnClick="btnRechazar_Click" Visible="False" />
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16" style="text-align: center"><span>
                        </span></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">
                        &nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="7">&nbsp;</td>
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
                    <td colspan="16">&nbsp;</td>
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
                        <asp:GridView ID="gridSaldos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Width="100%"
                            CssClass="table table-hover table-responsive">
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="no_renglon" HeaderText="Renglon">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="renglon" HeaderText="Descripcion">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fuente" HeaderText="Fuente">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Costo Poa">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("costo_poa") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("costo_poa", "Q.{0:0,0.00}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Codificado">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("codificado") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("codificado", "Q.{0:0,0.00}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Saldo">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("saldo_poa") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("saldo_poa", "Q.{0:0,0.00}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle BackColor="#339933" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
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
            <div></div>                  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>





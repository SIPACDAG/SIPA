<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PedidoAnulacion.aspx.cs" Inherits="AplicacionSIPA1.Pedido.PedidoAnulacion" MasterPageFile="~/Principal.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
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
                    <td style="font-size: x-large; text-align: center; background-color: #006600; color: #FFFFFF;" class="text-center" colspan="16"><strong>ANULACIONES DE
                        <br />
                        REQUISICIONES,&nbsp; VALES DE CAJA CHICA,
                        <br />
                        TRANFERENCIAS APOYOS Y OTROS GASTOS</strong></td>
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
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                    <td style="width: 5%; height: 18px;"></td>
                </tr>
                <tr>
                    <td style="height: 18px">&nbsp;</td>
                    <td colspan="9" style="height: 18px">Año:</td>
                    <td colspan="9" style="height: 18px">Unidad:</td>
                    <td style="width: 5%; height: 18px;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 18px">&nbsp;</td>
                    <td colspan="9" style="height: 18px">
                        <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="9" style="height: 18px">
                        <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%; height: 18px;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="width: 5%; height: 18px;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px" colspan="18">Acciones:</td>
                    <td style="width: 5%; height: 18px;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 18px">&nbsp;</td>
                    <td colspan="18" style="height: 18px">
                        <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" class="form-control" BackColor="#003366" ForeColor="White" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" Visible="False" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%; height: 18px;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="height: 18px">&nbsp;</td>
                    <td style="width: 5%; height: 18px;">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="5">Tipos de documento:</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="3">No. Req. o Vale:</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="9">
                        <asp:RadioButtonList ID="rblTipoDocto" runat="server" RepeatDirection="Horizontal" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="rblTipoDocto_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="1">Requisiciones</asp:ListItem>
                            <asp:ListItem Value="2">Vales</asp:ListItem>
                            <asp:ListItem Value="3">Gastos</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="3">
                        &nbsp;</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNo" runat="server" BackColor="#FFFF99" class="form-control" Enabled="true" Font-Size="Large" MaxLength="5" Style="text-align: right" TextMode="Number" Width="95%"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <asp:Button ID="btnBuscar" runat="server" class="btn btn-info" OnClick="btnBuscar_Click" Text="Buscar" Width="95%" />
                    </td>
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
                    <td colspan="18">
                         <asp:DetailsView ID="dvPedido" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="ID,ID_ACCION" OnPageIndexChanging="dvPedido_PageIndexChanging" Width="100%"
                            CssClass="table table-hover table-responsive">
                            
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Fields>
                                <asp:BoundField DataField="ID" HeaderText="Id" Visible="false">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BackColor="#99FF99" BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="no_anio_solicitud" HeaderText="No. Pedido">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BackColor="#99FF99" BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_accion" HeaderText="id_accion" Visible="false">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="documento" HeaderText="Tipo de Documento">
                                <ItemStyle BackColor="#FF6600" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha_pedido" DataFormatString="{0:d}" HeaderText="Fecha Pedido">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="accion" HeaderText="Acción">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tipo_pedido" HeaderText="Tipo de pedido">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="solicitante" HeaderText="Solicitante">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="encargado" HeaderText="Jefe Direccion">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="justificacion" HeaderText="Justificacion">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="unidad" HeaderText="Unidad">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dependencia" HeaderText="Dependencia">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fadn" HeaderText="FADN" >
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#FF6600" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Anexos">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" NavigateUrl="" Text='<%# Eval("tipo_anexo") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="estado_pedido" HeaderText="Estado" >
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#FF6600" Font-Bold="True" />
                                </asp:BoundField>
                            </Fields>
                            <FooterStyle Font-Bold="False" />
                            <PagerStyle BackColor="White" BorderStyle="Solid" Font-Bold="True" Font-Names="Algerian" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="False" />
                        </asp:DetailsView>
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
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="18">
                         <asp:GridView ID="gridDetalle" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID,COSTO_ESTIMADO" Font-Size="Small" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="12" ShowFooter="True" Width="100%"
                            CssClass="table table-hover table-responsive">
                          
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True" Visible="False">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:CommandField>
                                <asp:TemplateField ShowHeader="False" Visible="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/delete.png" onclientclick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Eliminar" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
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
                                <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="costo_estimado" HeaderText="VALOR ESTIMADO SIN IVA" DataFormatString="Q {0:0,00.00}">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="subtotal" HeaderText="SUBTOTAL ESTIMADO" DataFormatString="Q {0:0,00.00}">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="no_renglon_ppto" HeaderText="RENGLÓN PPTO.">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ajuste" HeaderText="AJUSTE">
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
                    <td colspan="16">Observaciones:<strong><asp:Label ID="lblErrorObser" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">
                        <asp:TextBox ID="txtObser" runat="server" BackColor="#FFFF99" class="form-control" Enabled="true" Height="75px" MaxLength="750" placeholder="Ingrese las observaciones del pedido en caso de rechazo" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
                    <td colspan="16" style="text-align: center;"><span>
                        <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                        <br />
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        </span></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16" style="text-align: center;">
                         <asp:Button ID="btnReactivar" runat="server" class="btn btn-success" OnClick="btnRechazar_Click" Text="Reactivar" Width="300px" OnClientClick="javascript:if(!confirm('¿Desea REACTIVAR este registro?'))return false" />
                        <asp:Button ID="btnAnular" runat="server" class="btn btn-danger" OnClick="btnAnular_Click" Text="Anular Pedido" Width="300px" OnClientClick="javascript:if(!confirm('¿Desea ANULAR este registro?'))return false" />
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
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="18">
                        <asp:GridView ID="gridSaldos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Width="100%" Visible="False"
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div></div>                  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>





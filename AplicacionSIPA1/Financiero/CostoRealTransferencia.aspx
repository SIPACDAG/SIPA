<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostoRealTransferencia.aspx.cs" Inherits="AplicacionSIPA1.Financiero.CostoRealTransferencia" MasterPageFile="~/Principal.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upIngreso" runat="server">
                <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td style="width: 8%">
                        <asp:Label ID="lblPlanE" runat="server" Text="*"></asp:Label>
                    </td>
                    <td style="width: 5%"><strong>
                        <asp:Label ID="lblErrorPlan" runat="server" ForeColor="Red" style="font-size: medium" Visible="False">*</asp:Label>
                        <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" Width="50%" Visible="False">
                        </asp:DropDownList>
                        </strong></td>
                    <td style="font-size: x-large; text-align: center;" class="text-center" colspan="16"><strong>COSTO REAL DE TRANSFERENCIAS, APOYOS Y OTROS GASTOS</strong></td>
                    <td class="text-right" colspan="2" style="font-size: x-large;"><strong>
                        <asp:Label ID="lblIdPoa" runat="server" style="font-size: medium" ForeColor="White">0</asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="width: 8%">
                        &nbsp;</td>
                    <td colspan="18" style="text-align: center;"><strong>
                        <asp:Label ID="lblErrorPoa" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">
                        &nbsp;</td>
                    <td colspan="9">
                        <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" Width="100%" Visible="False">
                        </asp:DropDownList>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" BackColor="#003366" ForeColor="White" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" Width="100%" Visible="False">
                        </asp:DropDownList>
                    </td>
                    <td class="text-right" colspan="6">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
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
                    <td style="width: 8%">&nbsp;</td>
                    <td colspan="5">Tipos de documento:</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">No. Documento:</td>
                    <td>&nbsp;</td>
                    <td colspan="3">Año:</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td colspan="9">
                        <asp:RadioButtonList ID="rblTipoDocto" runat="server" RepeatDirection="Horizontal" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="rblTipoDocto_SelectedIndexChanged">
                            <asp:ListItem Value="3" Selected="True">Transferencias, apoyos y otros gastos</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNo" runat="server" BackColor="#FFFF99" class="form-control" Enabled="true" MaxLength="5" TextMode="Number" Width="95%" Font-Size="Large" Style="text-align: right"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlAnios" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="3">
                        <asp:Button ID="btnBuscar" runat="server" class="btn btn-info" OnClick="btnBuscar_Click" Text="Buscar" Width="95%" />
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
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
                    <td style="width: 8%">&nbsp;</td>
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
                    <td style="width: 8%">&nbsp;</td>
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
                                        <asp:LinkButton ID="LinkButton1" runat="server" NavigateUrl="" Text='<%# Eval("tipo_anexo") %>' OnClick="LinkButton1_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Fields>
                            <FooterStyle Font-Bold="False" />
                            <PagerStyle BackColor="White" BorderStyle="Solid" Font-Bold="True" Font-Names="Algerian" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="False" />
                        </asp:DetailsView>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>

                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td colspan="10">
                       <asp:CheckBox ID="chkProveedores" runat="server" Text="Mostrar proveedores del cuadro de comparación" Visible="False" />
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
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
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
                    <td colspan="18"><strong>Cambios importantes:</strong><br /> * Liquidación en base a la cantidad y SUBTOTAL adjudicado sin IVA(en vez de monto individual), siempre y cuando no sea superado el monto del renglón de presupuesto ni el monto planificado en el PAC.<br />
                        * Selección del tipo de documento de compra
                        <br />
                        * Si el producto no se adquirió, se pude liquidar con cantidad y subtotal adjudicado de cero (Q.0.00) el sistema no solicitará los datos restantes concluyendo que el producto no se adquirió, sin embargo para liquidar deberá existir por lo menos un item adquirido<br />
                        * Posibilidad de rechazar (18 - Rechazado técnico compras) una requisición cuando se encuentre en estado 12 - Liquidado
                        <br />
                        * Si el artículo se adquirió con valor cero (Q. 0.00), deje los campos numéricos en cero y selecciones los datos restantes (proveedor, tipo docto. compra, etc.)<br />
                        <span class="auto-style2">* Posibilidad de liquidar nuevamente una requisición que se encuentre en estado 12 - Liquidado.</span><br /> <br /> </td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="20">
                        <asp:GridView ID="gridDetalle" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID,COSTO_ESTIMADO" Font-Size="Small" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnRowDataBound="gridDetalle_RowDataBound" PageSize="12" ShowFooter="True" Width="100%">
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
                                <asp:TemplateField HeaderText="CANTIDAD">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cantidad") %>' Font-Bold="True"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("cantidad") %>' Font-Bold="True"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VALOR ESTIMADO INDIVIDUAL SIN IVA">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("costo_estimado") %>' Font-Bold="True"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("costo_estimado", "Q.{0:0,0.00}") %>' Font-Bold="True"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SUBTOTAL ESTIMADO">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("subtotal") %>' Font-Bold="True"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="lblSubtotalEstimado" runat="server" Text='<%# Bind("subtotal", "Q.{0:0,0.00}") %>' Font-Bold="True"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="no_renglon_ppto" HeaderText="RENGLÓN PPTO." Visible ="false">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ajuste" HeaderText="AJUSTE">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="CANTIDAD ADJUDICADA">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:TextBox ID="txtCantidadReal" runat="server" Text='<%# Bind("cantidad_compras") %>' Style="text-align: right" Width="50px"></asp:TextBox>
                                            <asp:Label ID="lblErrorCantidadReal" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                   <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MONTO INDIVIDUAL ADJUDICADO SIN IVA">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:TextBox ID="txtCostoUReal" runat="server" ReadOnly="True" Style="text-align: right" Text='<%# Bind("costo_u_compras", "Q.{0:0,0.00}") %>' Width="85px"></asp:TextBox>
                                            <asp:Label ID="lblErrorCostoUReal" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                   <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SUBTOTAL ADJUDICADO SIN IVA">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:TextBox ID="txtCostoReal" Style="text-align: right" runat="server" Text='<%# Bind("subtotal_compras", "Q.{0:0,0.00}") %>' Width="95px" ReadOnly = "True"></asp:TextBox>
                                            <asp:Label ID="lblErrorCostoReal" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                   <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IVA">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:TextBox ID="txtIva" Style="text-align: right" runat="server" Text='<%# Bind("iva", "Q.{0:0,0.00}") %>'  Width="95px" ReadOnly = "True"></asp:TextBox>
                                            <asp:Label ID="lblErrorIva" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TOTAL MULTIANUAL">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox33" runat="server" Text='<%# Bind("total_pedido_multianual") %>' Font-Bold="True"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label33" runat="server" Text='<%# Bind("total_pedido_multianual", "Q.{0:0,0.00}") %>' Font-Bold="True"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                   <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PROVEEDOR">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="dropProveedor" runat="server" data-placeholder="Busque Proveedor..."   class="chzn-select" Style="width: auto;">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblErrorProveedor" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                   <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TIPO DOCTO. COMPRA">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="dropTipoDoctoDetalle" runat="server" class="chzn-select" data-placeholder="Busque Tipo Docto...." Style="width: auto;">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblErrorTipoDoctoDetalle" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NO DOCTO. COMPRA">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtNoOrdenDetalle" Style="text-align: right" Text='<%# Bind("no_orden_compra") %>' runat="server" Width="50px"></asp:TextBox>
                                        <asp:Label ID="lblErrorNoOrden" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                   <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FECHA DOCTO. COMPRA">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFechaOrdenDetalle" Style="text-align: right" runat="server" Text='<%# Bind("fecha_orden_compra_string") %>' TextMode="Date"></asp:TextBox>
                                        <asp:Label ID="lblErrorFechaNoOrden" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                   <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="no_renglon_ppto" HeaderText="RENGLÓN PPTO.">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="PAGOS P.">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkLiquidacionParcial" runat="server" />
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
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="text-align: center;" colspan="10"><span>
                        <asp:Label ID="lblErrorCalculo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        </span></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16" style="text-align: center;">
                        <asp:Button ID="btnCalcular" runat="server" BackColor="#00cc99" class="btn" OnClick="btnCalcular_Click" Text="Calcular" Width="300px" style="color: #FFFFFF" />
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">Observaciones (en caso de anular el pedido):<strong><asp:Label ID="lblErrorObser" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">
                        <asp:TextBox ID="txtObser" runat="server" BackColor="#FFFF99" class="form-control" Enabled="true" Height="75px" MaxLength="750" placeholder="Ingrese las observaciones del pedido en caso de rechazo" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
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
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:CheckBox ID="chkConstantes" runat="server" Text="Asignar todo el pedido con los siguiente datos:" AutoPostBack="True" OnCheckedChanged="chkConstantes_CheckedChanged" />
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
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
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
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="6">Proveedor&nbsp;</td>
                    <td colspan="2">Tipo Docto. de compra</td>
                    <td colspan="2">No. documento Compra</td>
                    <td colspan="3">Fecha documento de compra:</td>
                    <td colspan="3">Liquidaciones Parciales:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:DropDownList ID="ddlProveedoresC" runat="server" AutoPostBack="True" class="form-control" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTipoDocumentoCompraC" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="ddlTipoDocumentoCompraC_SelectedIndexChanged" Visible="False">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNoOrdenC" runat="server" class="form-control" Enabled="true" placeholder="" TextMode="Number" Width="100%" Visible="False"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtFechaOrdenC" runat="server" class="form-control" Enabled="true" placeholder="Ingrese las observaciones del pedido en caso de rechazo" TextMode="Date" Width="100%"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <asp:RadioButtonList ID="rblLiquidacionesC" runat="server" RepeatDirection="Horizontal" Width="95%">
                            <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                            <asp:ListItem Value="1">Si</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8"><strong>
                        <asp:Label ID="lblErrorProveedorC" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="2"><strong>
                        <asp:Label ID="lblErrorTipoDoctoCompraC" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="2"><strong>
                        <asp:Label ID="lblErrorOrdenC" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="3"><strong>
                        <asp:Label ID="lblErrorFechaC" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="3"><strong>
                        <asp:Label ID="lblErrorLiquidacionesC" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16" style="text-align: center;"><span>
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                        </span></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16" style="text-align: center;">
                        <asp:Button ID="btnAprobar" runat="server" class="btn btn-success" OnClick="btnAprobar_Click" Text="Guardar Montos" Width="300px" OnClientClick="javascript:if(!confirm('¿Desea GUARDAR este registro?'))return false" />
                        <asp:Button ID="btnRechazar" runat="server" class="btn btn-danger" OnClick="btnRechazar_Click" Text="Rechazar Gasto" Width="300px" OnClientClick="javascript:if(!confirm('¿Desea RECHAZAR este registro?'))return false" />
                        
                        <asp:Button ID="btnAnular" runat="server" class="btn btn-primary" OnClick="btnAnular_Click" Text="Anular Gasto" Width="300px" OnClientClick="javascript:if(!confirm('¿Desea ANULAR este registro?'))return false" />
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
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
                    <td style="width: 8%">&nbsp;</td>
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
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
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
                    <td style="width: 8%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
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





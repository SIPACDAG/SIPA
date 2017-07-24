<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresarPac.aspx.cs" Inherits="AplicacionSIPA1.Pac.IngresarPac" MasterPageFile="~/Principal.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upIngreso" runat="server">
                <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="font-size: x-large; text-align: center;" class="text-center" colspan="16"><strong>INGRESO - PLAN ANUAL DE COMPRAS</strong></td>
                    <td class="text-right" colspan="2" style="font-size: x-large;"><strong>
                        <asp:Label ID="lblIdPoa" runat="server" style="font-size: medium" ForeColor="White"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td class="text-center" colspan="18" style="text-align: center"><strong>
                        <asp:Label ID="lblErrorPac" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td colspan="9">Año:<strong><asp:Label ID="lblErrorAnio" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td colspan="3">
                        Unidad:<strong><asp:Label ID="lblErrorUnidad" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong>
                    </td>
                    <td class="text-right" colspan="6">Estado CMI: <strong>
                        <asp:Label ID="lblEstadoPoa" runat="server" style="font-size: medium"></asp:Label>
                        </strong></td>
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
                    <td>
                        &nbsp;</td>
                    <td colspan="9">Dependencia:<strong><asp:Label ID="Label6" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td colspan="3">
                        Jefatura/Unidad:<strong><asp:Label ID="Label7" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong>
                    </td>
                    <td class="text-right" colspan="6"></td>
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
                    <td colspan="5">
                        <asp:Label ID="lblPlanE" runat="server" Text="Plan Estratégico:"></asp:Label>
                        <strong>
                        <asp:Label ID="lblErrorPlan" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td style="width: 5%">
                        <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td><strong>
                        <asp:Label ID="lblErrorDependencia" runat="server" ForeColor="Red" style="font-size: medium" Visible="False">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">
                        <asp:DropDownList ID="ddlDependencias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" Visible="False" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="3">&nbsp;</td>
                    <td style="width: 5%">
                        &nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="4">Acciones:&nbsp;<strong><asp:Label ID="lblErrorAccion" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
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
                    <td>
                        &nbsp;</td>
                    <td colspan="18">
                        <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" BackColor="#003366" class="form-control" ForeColor="White" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
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
                    <td>&nbsp;</td>
                    <td colspan="18">
                        <asp:GridView ID="gridRenglon" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID,NO_RENGLON" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="gridRenglon_SelectedIndexChanged" Width="100%" AllowPaging="True" OnPageIndexChanging="gridRenglon_PageIndexChanging" OnSelectedIndexChanging="gridRenglon_SelectedIndexChanging" CssClass="table table-hover table-responsive">
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:CommandField>
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="no_renglon" HeaderText="No Renglón">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="descripcion" HeaderText="Renglón">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fuente_financiamiento" HeaderText="Fuente">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Monto Poa">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("costo_poa") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text='<%# Bind("costo_poa", "Q.{0:0,0.00}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cod. Fin.">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("codificado") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text='<%# Bind("codificado", "Q.{0:0,0.00}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Saldo Poa">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("saldo_poa") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" Text='<%# Bind("saldo_poa", "Q.{0:0,0.00}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monto Pac">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("monto_pac") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" Text='<%# Bind("monto_pac", "Q.{0:0,0.00}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Saldo Pac">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("saldo_pac") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" Text='<%# Bind("saldo_pac", "Q.{0:0,0.00}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
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
                    <td>&nbsp;</td>
                    <td colspan="18">
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="9" style="font-size: large"><strong>Pac No.:
                        <asp:Label ID="lblIdPac" runat="server" Text="0"></asp:Label>
                        </strong></td></td>
                    <td class="text-right" colspan="9">Estado del PAC: <strong><asp:Label ID="lblEstadoPac" runat="server" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="6">Modalidad:<strong><asp:Label ID="lblErrorModalidad" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td colspan="6">Excepción:</td>
                    <td colspan="6">Categoría:<strong><asp:Label ID="lblErrorCategoria" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="6">
                        <asp:DropDownList ID="ddlModalidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlModalidades_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="6">
                        <asp:DropDownList ID="ddlExcepciones" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlExcepciones_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="6">
                        <asp:DropDownList ID="ddlCategorias" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="18">Descripción:<asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" Enabled="False" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="gpDatos"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="18">
                        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" Enabled="true" Height="100px" MaxLength="750" placeholder="Ingresar una descripción de por lo menos 40 caracteres" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
                    <td colspan="3">Presupuesto Plan de Compras:</td>
                    <td colspan="3">Codificado:</td>
                    <td colspan="3">Presupuesto Disponible:</td>
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
                    <td colspan="3" style="text-align: right;">
                        <asp:Label ID="lblTechoP" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="0.00"></asp:Label>
                    </td>
                    <td colspan="3" style="text-align: right;">
                        <asp:Label ID="lblCodificadoP" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Green" Text="0.00"></asp:Label>
                    </td>
                    <td colspan="3" style="text-align: right;">
                        <asp:Label ID="lblDisponibleP" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="0.00"></asp:Label>
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="12">
                        <asp:GridView ID="gridDet" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnSelectedIndexChanged="gridDet_SelectedIndexChanged" PageSize="12" ShowFooter="True" Width="100%" CssClass="table table-hover table-responsive">
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="mes" HeaderText="Mes">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Cantidad Estimada">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cantidad") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:TextBox ID="txtCantidad" runat="server" Font-Size="Large" Style="text-align: right" Text='<%# Bind("cantidad") %>' Width="120px" MaxLength="20"></asp:TextBox>
                                            <br />
                                            <asp:RangeValidator ID="rvCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Sólo números" Font-Bold="True" ForeColor="Red" MaximumValue="100000000" MinimumValue="1" Type="Integer" ValidationGroup="grpDatos" Enabled="False"></asp:RangeValidator>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monto Estimado (Q)">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("monto") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:TextBox ID="txtMonto" runat="server" Font-Size="Large" Style="text-align: right" Text='<%# Bind("monto", "Q.{0:0,0.00}") %>' Width="120px" MaxLength="20"></asp:TextBox>
                                            <br />
                                            <asp:RangeValidator ID="rvMonto" runat="server" ControlToValidate="txtMonto" ErrorMessage="Sólo números" Font-Bold="True" ForeColor="Red" MaximumValue="100000000" MinimumValue="1" Type="Double" ValidationGroup="grpDatos" Enabled="False"></asp:RangeValidator>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subtotal (Q)" Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text=""></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="lblSubtotal" runat="server" Font-Size="Large" Text='<%# Bind("subtotal") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Right" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Observaciones">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblObservaciones" runat="server" ForeColor="Red"></asp:Label>
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="15" style="text-align: center"><strong>
                        <asp:Label ID="lblErrorDetalles" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="15" style="text-align: center"><span>
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                        </span></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="15" style="text-align: center">
                        <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="grpDatos" Width="120px" />
                        <asp:Button ID="btnLimpiarC" runat="server" class="btn btn-warning" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                        <asp:Button ID="btnListadoPac" runat="server" CausesValidation="False" class="btn btn-info" OnClick="btnListadoPac_Click" Text="Ver Listado" Width="120px" />
                    </td>
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
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div></div>  
            <asp:UpdatePanel ID="upConsulta" runat="server">
                <ContentTemplate>
                   <table style="width: 100%;">
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="18"style="font-size: x-large; text-align: center;" class="text-center"><strong>LISTADO - PLAN ANUAL DE COMPRAS</strong></td>
                                <td style="width: 5%"><strong>
                                    <asp:Label ID="lblCIdPoa" runat="server" ForeColor="White" style="font-size: medium">0</asp:Label>
                                    </strong></td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="18" style="text-align: center"></b><strong>
                                <asp:Label ID="lblCErrorPac" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
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
                                    <asp:DropDownList ID="ddlCAnios" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlCAnios_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="9">
                                    <asp:DropDownList ID="ddlCUnidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlCAnios_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                       <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="9">Dependencia:</td>
                                <td colspan="9">Jefatura/Unidad:</td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="9">
                                    <asp:DropDownList ID="ddlCDependencia" runat="server" OnSelectedIndexChanged="ddlCDependencia_SelectedIndexChanged" AutoPostBack="True" class="form-control"  Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="9">
                                    <asp:DropDownList ID="ddlCJefaturaUnidad" runat="server" OnSelectedIndexChanged="ddlCJefaturaUnidad_SelectedIndexChanged" AutoPostBack="True" class="form-control"  Width="100%">
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
                                    &nbsp;</td>
                                <td style="width: 5%">
                                    &nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="9">Acciones:</td>
                                <td colspan="9">Renglones de la acción:</td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="9">
                                    <asp:DropDownList ID="ddlCAcciones" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlCAcciones_SelectedIndexChanged" Width="100%">
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
                                    <asp:Label ID="lblCError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblCSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                                    </span></td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">&nbsp;</td>
                                <td colspan="18" style="text-align: center">
                                    <asp:Button ID="btnActualizar0" runat="server" class="btn btn-primary" OnClick="btnActualizar_Click" Text="Actualizar!" Width="120px" CausesValidation="False" />
                                    <asp:Button ID="btnEnviar" runat="server" class="btn btn-success" OnClick="btnEnviar_Click" Text="Enviar" ValidationGroup="grpDatos" Width="120px" />
                                    <asp:Button ID="btnVerReporte" runat="server" CausesValidation="False" class="btn btn-info" OnClick="btnVerReporte_Click" Text="Ver Reporte" Width="120px" />
                                    <asp:Button ID="btnModificar" runat="server" BackColor="#FF6600" class="btn btn-primary" Font-Bold="True" OnClick="btnModificar_Click" Text="Consultar" Visible="False" Width="120px" />
                                </td>
                                <td style="width: 5%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="20">
                                    <asp:GridView ID="gridPac" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" Font-Size="X-Small" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnRowDataBound="gridPac_RowDataBound" OnRowDeleting="gridPac_RowDeleting" OnSelectedIndexChanged="gridPac_SelectedIndexChanged" ShowFooter="True" Width="100%" style="margin-left: 38px" CssClass="table table-hover table-responsive">
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
                                            <ItemStyle BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="accion" HeaderText="Acción">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="insumo" HeaderText="Insumo" Visible="False">
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
                                            <asp:TemplateField HeaderText="Monto">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("monto") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <div class="text-right">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("monto", "Q.{0:0,0.00}") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
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
                                                <ItemStyle BorderStyle="Inset" Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Saldo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("saldo") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <div class="text-right">
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("saldo", "Q.{0:0,0.00}") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
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
                </ContentTemplate>
            </asp:UpdatePanel>                   
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>





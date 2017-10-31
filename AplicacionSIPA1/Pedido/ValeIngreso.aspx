<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValeIngreso.aspx.cs" Inherits="AplicacionSIPA1.Pedido.ValeIngreso" MasterPageFile="~/Principal.Master" %>



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
                        <asp:Label ID="lblPlanE" runat="server" Text="*" CssClass="auto-style10"></asp:Label>
                    </td>
                    <td style="width: 5%; background-color: #006600;"><strong>
                        <asp:Label ID="lblErrorPlan" runat="server" ForeColor="Red" style="font-size: medium" CssClass="auto-style10">*</asp:Label>
                        <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" Width="50%" CssClass="auto-style10">
                        </asp:DropDownList>
                        </strong></td>
                    <td style="font-size: x-large; text-align: center; color: #FFFFFF; background-color: #006600;" class="text-center" colspan="16"><strong>INGRESO - VALE DE CAJA CHICA</strong></td>
                    <td class="text-right" colspan="2" style="font-size: x-large; background-color: #006600;">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td colspan="18" style="text-align: center;"><strong>
                        <asp:Label ID="lblErrorPoa" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td style="width: 5%"><strong>
                        <asp:Label ID="lblIdPoa" runat="server" CssClass="auto-style10" ForeColor="White" style="font-size: medium">0</asp:Label>
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
                    <td colspan="9">Depencias:</td>
                    <td colspan="3">Jefatura/Unidad:</td>
                    <td class="text-right" colspan="6">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td colspan="9">
                        <asp:DropDownList ID="ddldepencia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddldepencia_SelectedIndexChanged" class="form-control"  Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="9">
                        <asp:DropDownList ID="ddlJefatura" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlJefatura_SelectedIndexChanged" class="form-control" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="18">Acciones:<strong><asp:Label ID="lblErrorAccion" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="18">
                        <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" BackColor="#003366" class="form-control" ForeColor="White" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="6">&nbsp;</td>
                    <td colspan="6">&nbsp;</td>
                    <td colspan="6">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">No. Vale:</td>
                    <td colspan="3"><strong>
                        <asp:Label ID="lblNoVale" runat="server" style="font-size: medium">0-0</asp:Label>
                        </strong></td>
                    <td>&nbsp;</td>
                    <td colspan="6"><strong>
                        <asp:Label ID="lblIdVale" runat="server" style="font-size: medium" ForeColor="White">0</asp:Label>
                        </strong></td>
                    <td colspan="6" class="text-right">Estado del vale: <strong>
                        <asp:Label ID="lblEstadoVale" runat="server" style="font-size: medium"></asp:Label>
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
                    <td colspan="6">Vale a:<strong><asp:Label ID="lblErrorSolicitante" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="6">Jefe Inmediato:<strong><asp:Label ID="lblErrorJefe" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="6">Tipo de Pedido:<strong><asp:Label ID="lblErrorTipoPedido" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="6">
                        <asp:DropDownList ID="ddlSolicitantes" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" OnSelectedIndexChanged="ddlSolicitantes_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="6">
                        <asp:DropDownList ID="ddlJefes" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" OnSelectedIndexChanged="ddlJefes_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="6">
                        <asp:DropDownList ID="ddlTipoPedido" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" OnSelectedIndexChanged="ddlTipoPedido_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">Justificación:<strong><asp:Label ID="lblErrorJustificacion" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">
                        <asp:TextBox ID="txtJustificacion" runat="server" BackColor="#FFFF99" class="form-control" Enabled="true" Height="50px" MaxLength="750" placeholder="Ingrese la justificación del pedido" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
                    <td colspan="6">Pedido para:<strong><asp:Label ID="lblErrorTipoDestino" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="6">FADN:<strong><asp:Label ID="lblErrorFand" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="6">Anexos:<strong><asp:Label ID="lblErrorAnexos" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="6">
                        <asp:RadioButtonList ID="rblTipoDestino" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblTipoDestino_SelectedIndexChanged" RepeatDirection="Horizontal" Width="90%">
                            <asp:ListItem Selected="True" Value="1">CDAG</asp:ListItem>
                            <asp:ListItem Value="2">FADN</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="6">
                        <asp:DropDownList ID="ddlFADN" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlFADN_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="6">
                        <asp:RadioButtonList ID="rblAnexos" runat="server" OnSelectedIndexChanged="rblAnexos_SelectedIndexChanged" RepeatDirection="Horizontal" Width="90%">
                            <asp:ListItem Selected="True" Value="1">Especificaciones Téc.</asp:ListItem>
                            <asp:ListItem Value="2">Términos Ref.</asp:ListItem>
                        </asp:RadioButtonList>
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
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="background-color: #006600">&nbsp;</td>
                    <td style="width: 5%; background-color: #006600;">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="6"><strong><asp:Label ID="lblNoDet" runat="server" Visible="False"></asp:Label>
                        </strong></td>
                    <td colspan="6">&nbsp;</td>
                    <td class="text-right" style="font-size: large" colspan="6">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="6">Descripción del Bien/Servicio:<strong><asp:Label ID="lblErrorDescripcion" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="6">&nbsp;</td>
                    <td class="text-right" colspan="6" style="font-size: large">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="16">
                        <asp:TextBox ID="txtDescripcion" runat="server" BackColor="#FFFF99" class="form-control" Enabled="true" Height="40px" MaxLength="750" placeholder="Ingrese la descripción del Bien o Servicio que desea adquirir" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="4">Unidad de medida:<strong><asp:Label ID="lblErrorUnidadMedida" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="3">Cantidad</td>
                    <td colspan="9">Valor Estimado INDIVIDUAL sin IVA (Q.)</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="4">
                        <asp:DropDownList ID="ddlUnidadesMedida" runat="server" class="form-control" OnSelectedIndexChanged="ddlUnidadesMedida_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtCantidad" runat="server" BackColor="#FFFF99" class="form-control" Font-Size="Large" MaxLength="10" Style="text-align: right" Width="100%"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtCosto" runat="server" BackColor="#FFFF99" class="form-control" Font-Size="Large" MaxLength="12" Style="text-align: right" Width="100%"></asp:TextBox>
                    </td>
                    <td colspan="6">
                        <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="grpDatos" Width="120px" OnClientClick="javascript:if(!confirm('¿Desea GUARDAR este registro?'))return false" />
                        <asp:Button ID="btnLimpiarC" runat="server" class="btn btn-warning" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                        <asp:Button ID="btnListado" runat="server" CausesValidation="False" class="btn btn-info" OnClick="btnListado_Click" Text="Ver Listado" Width="120px"  />
                    </td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="4">&nbsp;</td>
                    <td colspan="3"><strong>
                        <asp:Label ID="lblErrorCantidad" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="3"><strong>
                        <asp:Label ID="lblErrorMonto" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="6">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="text-right" style="font-size: medium"><strong>Nota:</strong></td>
                    <td colspan="16" class="text-left">El monto máximo de solicitud por vale es de Q 892.86, exceptuando los casos en los cuales se vaya a realizar compras a Pequeños Contribuyentes para los cuales el monto será de Q1,0000.00</td>
                    <td>&nbsp;</td>
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
                        <asp:Button ID="btnEnviar" runat="server" class="btn btn-success" Text="Enviar" ValidationGroup="grpDatos" Width="120px" OnClick="btnEnviar_Click" OnClientClick="javascript:if(!confirm('¿Desea ENVIAR este registro?'))return false" />
                        <asp:Button ID="btnAnular" runat="server" class="btn btn-danger" Text="Anular" Width="120px" OnClick="btnAnular_Click" Visible="False" OnClientClick="javascript:if(!confirm('¿Desea ANULAR este registro?'))return false" />
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td class="text-right" style="width: 5%;"></td>
                    <td class="text-left" colspan="16"><span>
                        <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" style="text-align: center" Visible="False">IMPORTANTE! A partir de la fecha, si la requisición/vale se encuentra en estado 7 - Rechazado por presupuesto, al hacer clic en Enviar, enviará la requisición/vale a estado 6 - Revisión de Ppto, con el fin de agilizar el proceso de compra. </p><p></p> Si la requisición/vale se encuentra en estado 9 - Rechazado Mesa Entrada, al hacer clic en Enviar, enviará la requisición/vale a estado 8 - Imprimir, con el objetivo de agilizar el proceso de compra.</p></asp:Label>
                        </span></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">
                        <asp:GridView ID="gridDet" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID,NUMERO" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="12" ShowFooter="True" Width="100%" OnRowDeleting="gridDet_RowDeleting" OnSelectedIndexChanged="gridDet_SelectedIndexChanged" Font-Size="XX-Small"
                            CssClass="table table-hover table-responsive">
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
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
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
                                <asp:BoundField DataField="unidad_medida" HeaderText="UNIDAD MEDIDA" Visible="true">
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
                                <asp:TemplateField HeaderText="SUBTOTAL">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("subtotal") %>' Font-Bold="True"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("subtotal", "Q.{0:0,0.00}") %>' Font-Bold="True"></asp:Label>
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
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16"><strong>Total en letras:</strong>
                        <asp:Label ID="lblTotalEnLetras" runat="server"></asp:Label>
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
                    <td colspan="18">
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div></div>                  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>





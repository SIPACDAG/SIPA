<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAccionesPoaEstr.aspx.cs" Inherits="AplicacionSIPA1.Operativa.AdminAccionesPoaEstr" MasterPageFile="~/Principal.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <p>
        }</p>
    <p>
        &nbsp;</p>
    <script type="text/javascript">
        function verPanelModalReglon() {
            $('#ContentPlaceHolder3_PanelModalReglon').modal('show');
        }
     </script>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upBuscar" runat="server">
                <ContentTemplate>
                    <br />
                                <table style="width:80%;">
                <tr>
                    <td class="auto-style3" style="width: 178px">&nbsp;</td>
                    <td class="auto-style11" style="font-size: x-large"><strong>BÚSQUEDA</strong></td>
                </tr>
                <tr>
                    <td class="auto-style3" style="width: 178px">&nbsp;</td>
                    <td class="auto-style14"><strong>Acciones</strong></td>
                </tr>
                                    <tr>
                                        <td class="auto-style3" style="width: 178px; text-align: right;">Año:&nbsp;&nbsp;&nbsp; </td>
                                        <td class="auto-style14">
                                            <asp:DropDownList ID="ddlBAnio" runat="server" AutoPostBack="True" class="form-control" Width="15%" OnSelectedIndexChanged="ddlBAnio_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3" style="width: 178px; text-align: right;">Unidad Administrativa:&nbsp;&nbsp; </td>
                                        <td class="auto-style14">
                                            <asp:DropDownList ID="ddlBUnidades" runat="server" AutoPostBack="True" class="form-control" Width="90%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
            </table>
            <table style="width:80%;">
                <tr>
                    <td class="auto-style3" style="width: 180px; text-align: right;">Criterio de búsqueda:&nbsp;&nbsp; </td>
                    <td class="auto-style14" colspan="3">
                        <asp:RadioButtonList ID="rblCriterio" runat="server" OnSelectedIndexChanged="rblCriterio_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="width: 180px">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width:80%;">
                <tr>
                    <td class="auto-style3" style="width: 180px; text-align: right;">&nbsp;Valor de búsqueda:&nbsp;&nbsp; </td>
                    <td style="width: 425px">
                        <asp:TextBox ID="txtBValor" runat="server" class="form-control" MaxLength="250" Width="95%" OnTextChanged="txtBValor_TextChanged"></asp:TextBox>
                    </td>
                    <td class="auto-style14">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="width: 180px">&nbsp;</td>
                    <td colspan="2"><span>
                        <asp:Label ID="lblErrorBusqueda" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        </span></td>
                </tr>
                <tr>
                    <td class="auto-style3" style="width: 180px">&nbsp;</td>
                    <td style="width: 425px">
                        <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" class="btn btn-warning" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                    </td>
                    <td class="auto-style14">&nbsp;</td>
                </tr>
            </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
            <br />
            &nbsp;<br />
            <br />
            <table style="width:80%;">
                <tr>
                    <td class="auto-style3" style="width: 180px">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:GridView ID="gridBusqueda" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnSelectedIndexChanged="gridBusqueda_SelectedIndexChanged" PageSize="5" Width="95%" OnPageIndexChanging="gridBusqueda_PageIndexChanging" CssClass="table table-hover table-responsive">
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True" HeaderText="Seleccionar">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:CommandField>
                                
                                <asp:BoundField DataField="id" HeaderText="ID">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codigo_cmi" HeaderText="CMI" >
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codigo_accion" HeaderText="Cód. Acción">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="accion" HeaderText="Acción">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="meta_general" HeaderText="Meta">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ponderacion" HeaderText="Ponderación">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Anio" HeaderText="Año">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codigo_oo" HeaderText="Cód. OO">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="o_operativo" HeaderText="Objetivo Operativo">
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:UpdatePanel ID="upModificar" runat="server">
                <ContentTemplate>
                    <br />
                    <table style="width:100%;">
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16" style="font-size: x-large; text-align: center"><strong>ADMINISTRAR ACCIONES ESTRATEGIA</strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16" style="text-align: center"></b><strong>
                                <asp:Label ID="lblErrorPoa" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                                </strong></td>
                            <td colspan="2"><strong>
                                <asp:Label ID="lblIdPoa" runat="server" style="font-size: medium" ForeColor="White"></asp:Label>
                                </strong></td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="lblPlanE" runat="server" Text="Plan Estratégico:"></asp:Label>
                            </td>
                            <td style="width: 5%">
                                <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged">
                                </asp:DropDownList>
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
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">Año:<asp:Label ID="lblEAnio" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td colspan="8">Unidad:<asp:Label ID="lblEUnidad" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td colspan="3">Presupuesto Aprobado:</td>
                            <td colspan="3">Presupuesto Disponible:</td>
                            <td>&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td colspan="3" style="text-align: right;">
                                <asp:Label ID="lblTechoU" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="0.00"></asp:Label>
                            </td>
                            <td colspan="3" style="text-align: right;">
                                <asp:Label ID="lblDisponibleU" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="0.00"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16" style="text-align: center"><strong>
                                <asp:Label ID="lblEncabezado" runat="server" Font-Bold="True" Font-Size="Medium" style="text-align: center"></asp:Label>
                                </strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="text-align: center" colspan="16"><strong>
                                <asp:Label ID="lblEstadoPoa" runat="server" style="font-size: medium"></asp:Label>
                                </strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16" style="border: 1px solid #000000; color: #FFFFFF; background-color: #3498DB;">
                                <asp:CheckBox ID="chkAccion" runat="server" AutoPostBack="True" OnCheckedChanged="chkAccion_CheckedChanged" />
                                <b>Acciones</b></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="15" style="border: 1px solid #000000;">
                                <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: center; border: 1px solid #000000;"><span>
                                <asp:Button ID="btnEliminarAccion" runat="server" CausesValidation="False" class="btn btn-danger" ForeColor="White" OnClick="btnEliminarAccion_Click" Text="-" Width="100%" />
                                </span></td>
                            <td style="width: 5%">
                                <asp:DropDownList ID="ddlMetas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMetas_SelectedIndexChanged" Visible="False" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="text-align: center">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="5" style="border: 1px solid #000000; color: #FFFFFF; background-color: #3498DB;"><b>Objetivos Operativos:</b><asp:Label ID="lblEObjetivo" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                                </span></td>
                            <td colspan="5" style="border: 1px solid #000000; color: #FFFFFF; background-color: #3498DB;"><b>Indicadores:</b><asp:Label ID="lblEIndicador" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                                </span></td>
                            <td colspan="6" style="border: 1px solid #000000; color: #FFFFFF; background-color: #3498DB;"><b>Metas:</b><asp:Label ID="lblEMetasO" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                                </span></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="5" style="border: 1px solid #000000;">
                                <asp:DropDownList ID="ddlObjetivos" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlObjetivos_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="5" style="border: 1px solid #000000;">
                                <asp:DropDownList ID="ddlIndicadores" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlIndicadores_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="6" style="border: 1px solid #000000;">
                                <asp:DropDownList ID="ddlMetasO" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="ddlMetasO_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td class="text-right" style="width: 5%">
                                <asp:Label ID="lblEPlan" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="font-size: xx-large">*</asp:Label>
                            </td>
                            <td colspan="16" style="border: 1px solid #000000;">
                                <asp:GridView ID="gridPlanO" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" Font-Size="X-Small" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnPageIndexChanging="gridPlanO_PageIndexChanging" OnSelectedIndexChanged="gridPlanO_SelectedIndexChanged" PageSize="5" Width="100%" CssClass="table table-hover table-responsive">
                                    <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                    <Columns>
                                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="ID">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cod_ee" HeaderText="Cód. EE">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="eje" HeaderText="Eje">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cod_oe" HeaderText="Cód OE">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
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
                                        <asp:BoundField DataField="cod_oo" HeaderText="Cód. OO">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
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
                            <td class="text-right" style="width: 5%">&nbsp;</td>
                            <td colspan="16">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="9" style="border: 1px solid #000000; color: #FFFFFF; background-color: #3498DB;"><b>Dependencia:</b><asp:Label ID="lblEDependencia" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:Label>
                            </td>
                            <td colspan="3" style="border: 1px solid #000000; color: #FFFFFF; background-color: #3498DB;"><b>Presupuesto Aprobado:</b></td>
                            <td colspan="3" style="border: 1px solid #000000; color: #FFFFFF; background-color: #3498DB;"><b>Presupuesto Disponible:</b></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="9" style="border: 1px solid #000000;">
                                <asp:DropDownList ID="ddlDependencias" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="3" style="text-align: right; border: 1px solid #000000;">
                                <asp:Label ID="lblTechoD" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="0.00"></asp:Label>
                            </td>
                            <td colspan="3" style="text-align: right; border: 1px solid #000000;">
                                <asp:Label ID="lblDisponibleD" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="0.00"></asp:Label>
                            </td>
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
                            <td colspan="3" style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;"><b>Acción<asp:RequiredFieldValidator ID="rfvAccion" runat="server" ControlToValidate="txtAccion" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </b></td>
                            </b>
                            <td colspan="3" style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;"><b>Meta<span class="auto-style10"><strong><asp:RequiredFieldValidator ID="rfvMeta" runat="server" ControlToValidate="txtMeta" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </strong></span></b></td>
                            <td colspan="3" style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;"><b>Meta<strong><asp:RequiredFieldValidator ID="rfvMetaC1" runat="server" ControlToValidate="txtMeta1" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </strong></b>
                                &nbsp;<br />
                                <b>Primer Cuatrimestre</b></td>
                            <td colspan="3" style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;"><b>Meta<span class="auto-style10"><strong><asp:RequiredFieldValidator ID="rfvMetaC2" runat="server" ControlToValidate="txtMeta2" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </strong></span></b>
                                &nbsp;<br />
                                <b>Segundo Cuatrimestre</b></td>
                            <td colspan="3" style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;"><b>Meta<strong><span class="bg-info"><asp:RequiredFieldValidator ID="rfvMetaC3" runat="server" ControlToValidate="txtMeta3" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </span></strong></b>
                                &nbsp;<br />
                                <b>Tercer Cuatrimestre</b></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">
                                <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtCodigo" runat="server" class="form-control" Font-Bold="True" Font-Size="X-Large" MaxLength="2" TextMode="Number" ToolTip="Valores entre 1 y 99" Visible="False" Width="100%"></asp:TextBox>
                                <asp:RangeValidator ID="rvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="Entre 1 - 99" Font-Bold="True" ForeColor="Red" MaximumValue="99" MinimumValue="1" Type="Integer" ValidationGroup="grpDatos"></asp:RangeValidator>
                                <br />
                            </td>
                            <td colspan="3" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtAccion" runat="server" class="form-control" Height="250px" MaxLength="250" placeholder="Descripción" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="3" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtMeta" runat="server" class="form-control" Height="250px" MaxLength="250" placeholder="Meta Global" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="3" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtMeta1" runat="server" class="form-control" Height="250px" MaxLength="250" placeholder="Meta 1er. Cuatrimestre" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="3" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtMeta2" runat="server" class="form-control" Height="250px" MaxLength="250" placeholder="Meta 2do. Cuatrimestre" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="3" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtMeta3" runat="server" class="form-control" Height="250px" MaxLength="250" placeholder="Meta 3er. Cuatrimestre" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">
                                &nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
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
                            <td style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;" colspan="7"><b>Responsables<asp:RequiredFieldValidator ID="rfvResponsable" runat="server" ControlToValidate="txtResponsable" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </b></td>
                            </b>
                            <td style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB; font-size: x-small;" colspan="2"><b>Pond. Meta<asp:RequiredFieldValidator ID="rfvPond1" runat="server" ControlToValidate="txtPonderacion1" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos" style="font-size: large"></asp:RequiredFieldValidator>
                                </b>
                                &nbsp;<span style="font-size: x-small"><br /> <b>1er. Cuatrimestre(%)</b></span></td>
                            </span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span>
                            <td style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;" colspan="2"></span><b><span style="font-size: x-small">Pond. Meta</span><asp:RequiredFieldValidator ID="rfvPond2" runat="server" ControlToValidate="txtPonderacion2" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos" style="font-size: large"></asp:RequiredFieldValidator>
                                </b>
                                &nbsp;<span style="font-size: x-small"><br /><b>2do. Cuatrimestre(%)</b></span></td>
                            <td style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;" colspan="2"></span><b><span style="font-size: x-small">Pond. Meta</span><strong><asp:RequiredFieldValidator ID="rfvPond3" runat="server" ControlToValidate="txtPonderacion3" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="font-size: large" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </strong></b>&nbsp;<span style="font-size: x-small"><br /></span><b><span style="font-size: x-small">3er. Cuatrimestre(%)</span></b></td>
                            <td style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;" colspan="2"><strong>Ponderación<b><asp:RequiredFieldValidator ID="rfvPonderacion" runat="server" ControlToValidate="txtPonderacion" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="font-size: large" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </b>&nbsp;de Acciones (%)</strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="7" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtResponsable" runat="server" class="form-control" MaxLength="250" placeholder="Responsable" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="2" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtPonderacion1" runat="server" Style="text-align: right" class="form-control" MaxLength="5" TextMode="Number" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="2" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtPonderacion2" runat="server" Style="text-align: right" class="form-control" MaxLength="5" TextMode="Number" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="2" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtPonderacion3" runat="server" Style="text-align: right" class="form-control" MaxLength="5" TextMode="Number" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="2" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtPonderacion" runat="server" Style="text-align: right" class="form-control" MaxLength="5" TextMode="Number" Width="100%">100000000</asp:TextBox>
                            </td>
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
                            <td>
                                &nbsp;</td>
                            <td colspan="2">
                                <asp:RangeValidator ID="rvPond1" runat="server" ControlToValidate="txtPonderacion1" ErrorMessage="Entre 1 y 100" Font-Bold="True" ForeColor="Red" MaximumValue="100" MinimumValue="0" Type="Double" ValidationGroup="grpDatos"></asp:RangeValidator>
                            </td>
                            <td colspan="2">
                                <asp:RangeValidator ID="rvPond2" runat="server" ControlToValidate="txtPonderacion2" ErrorMessage="Entre 1 y 100" Font-Bold="True" ForeColor="Red" MaximumValue="100" MinimumValue="0" Type="Double" ValidationGroup="grpDatos"></asp:RangeValidator>
                            </td>
                            <td colspan="2">
                                <asp:RangeValidator ID="rvPond3" runat="server" ControlToValidate="txtPonderacion3" ErrorMessage="Entre 1 y 100" Font-Bold="True" ForeColor="Red" MaximumValue="100" MinimumValue="0" Type="Double" ValidationGroup="grpDatos"></asp:RangeValidator>
                            </td>
                            <td colspan="2">
                                <asp:RangeValidator ID="rvPond" runat="server" ControlToValidate="txtPonderacion" ErrorMessage="Entre 1 y 100" Font-Bold="True" ForeColor="Red" MaximumValue="100" MinimumValue="1" Type="Double" ValidationGroup="grpDatos" Enabled="False"></asp:RangeValidator>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="15">
                                <div style="text-align:center;">
                                <table style="width: 100%; margin: 0 auto;" >
                                    <tr>
                                        <td style="width: 4%">&nbsp;</td>
                                        <td colspan="12" style="color: #FFFFFF; text-align: center; border: 1px solid #000000; background-color: #3498DB">&nbsp;<strong><asp:CheckBox ID="chkCronograma" runat="server" AutoPostBack="True" OnCheckedChanged="chkCronograma_CheckedChanged" Text="CRONOGRAMA" />
                                            <asp:Label ID="lblEMeses" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                                            </strong></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 4%">&nbsp;</td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>ENE</b></td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>FEB</b></td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>MAR</b></td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>ABR</b></td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>MAY</b></td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>JUN</b></td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>JUL</b></td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>AGO</b></td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>SEP</b></td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>OCT</b></td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>NOV</b></td>
                                        <td style="border: 1px solid #000000; text-align:center; width: 8%"><b>DIC</b></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 4%">
                                            &nbsp;</td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM1" runat="server" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Style="text-align: center" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM2" runat="server" Style="text-align: center" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM3" runat="server" Style="text-align: center" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM4" runat="server" Style="text-align: center" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM5" runat="server" Style="text-align: center" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM6" runat="server" Style="text-align: center" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM7" runat="server" Style="text-align: center" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM8" runat="server" Style="text-align: center" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM9" runat="server" Style="text-align: center" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM10" runat="server" Style="text-align: center" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM11" runat="server" Style="text-align: center" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 8%">
                                            <asp:TextBox ID="txtM12" runat="server" Style="text-align: center" class="form-control" Font-Bold="True" Font-Size="Medium" MaxLength="1" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            </td>
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
                            <td colspan="8"><strong>
                                <asp:CheckBox ID="chkListadoInsumos" runat="server" AutoPostBack="True" OnCheckedChanged="chkListadoInsumos_CheckedChanged" Text="Ver renglones de esta acción" />
                                </strong></td>
                            <td style="width: 5%">&nbsp;</td>
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
                            <td colspan="20">
                                <asp:Panel ID="pnlRenglones" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td style="width: 5%">&nbsp;</td>
                                            <td style="width: 5%">&nbsp;</td>
                                            <td colspan="8" style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;"><b>Renglón</b></td>
                                            <td colspan="5" style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;"><b>Fuente</b></td>
                                            <td colspan="2" style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;"><b>Monto (Q)<asp:RequiredFieldValidator ID="rfvMonto" runat="server" ControlToValidate="txtMonto" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos2"></asp:RequiredFieldValidator>
                                                </b></td>
                                            <td style="border-left: 1px solid #000000; text-align: center;">&nbsp;</td>
                                            <td style="width: 5%">&nbsp;</td>
                                            <td style="width: 5%">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 5%">&nbsp;</td>
                                            <td style="width: 5%">&nbsp;</td>
                                            <td colspan="8" style="border: 1px solid #000000">
                                                <asp:DropDownList ID="ddlRenglones" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="ddlRenglones_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td colspan="5" style="border: 1px solid #000000">
                                                <asp:DropDownList ID="ddlFuentes" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="ddlFuentes_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td colspan="2" style="border: 1px solid #000000">
                                                <asp:TextBox ID="txtMonto" runat="server" Style="text-align: right" class="form-control" MaxLength="12" TextMode="Number" Width="100%">100000000</asp:TextBox>
                                            </td>
                                            <td style="border-left: 1px solid #000000; width: 5%">&nbsp;</td>
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
                                            <td colspan="3">
                                                <asp:RangeValidator ID="rvMonto" runat="server" ControlToValidate="txtMonto" ErrorMessage="Entre 1 y el disponible" Font-Bold="True" ForeColor="Red" MaximumValue="100000000" MinimumValue="0" Type="Double" ValidationGroup="grpDatos"></asp:RangeValidator>
                                            </td>
                                            <td style="width: 5%">&nbsp;</td>
                                            <td style="width: 5%">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 5%">&nbsp;</td>
                                            <td style="width: 5%">&nbsp;</td>
                                            <td colspan="15">
                                                <asp:GridView ID="gridRenglon" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" OnRowDataBound="gridRenglon_RowDataBound" OnRowDeleting="gridRenglon_RowDeleting" OnSelectedIndexChanged="gridRenglon_SelectedIndexChanged" PageSize="50" ShowFooter="True" Width="100%" CssClass="table table-hover table-responsive">
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
                                                        <asp:BoundField DataField="no_renglon" HeaderText="Renglon">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="" HeaderText="Descripcion" Visible="False">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="fuente_financiamiento" HeaderText="Fuente">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="monto" HeaderText="CostoPoa">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="codificado" HeaderText="Codificado">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="saldo" HeaderText="Saldo">
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
                                </asp:Panel>
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
                            <td colspan="3" style="border: 1px solid #000000; text-align: center; color: #FFFFFF; background-color: #3498DB;"><b>Presupuesto</b></td>
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
                            <td style="width: 5%">
                                &nbsp;</td>
                            <td style="width: 5%">
                                <asp:Label ID="lblAsignado" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#006600" style="text-align: right" Text="0.00" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 5%">
                                &nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="3" style="border: 1px solid #000000; background-color: #000000;" class="text-right">
                                <asp:Label ID="lblPpto" runat="server" BackColor="Black" Font-Bold="True" Font-Names="Lucida Console" Font-Size="Medium" ForeColor="Lime"></asp:Label>
                            </td>
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
                                <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="grpDatos" Width="120px" />
                                <asp:Button ID="btnLimpiarC" runat="server" class="btn btn-warning" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                                <asp:Button ID="btnRevisarPlan" runat="server" CausesValidation="False" class="btn btn-info" OnClick="btnNuevaB_Click" Text="RevisarPlan" Width="120px" />
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
                    <asp:Panel ID="PanelModalReglon" runat="server" role="dialog" CssClass="modal fade">
                    <asp:Panel ID="panelInnerReglon" runat="server" CssClass="modal-dialog modal-lg">
                        <asp:Panel ID="panelContentReglon" CssClass="modal-content" runat="server">
                            <asp:Panel ID="Panel1" runat="server" class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                                </button>
                                <h4 class="modal-title">Accion: <asp:Label ID="lblAccion" runat="server" /></h4>
                            </asp:Panel>

                            <asp:Panel ID="Panel2" runat="server" class="modal-body">
                                <table style="width: 70%;" >
                                    <tr>
                                        <td class="auto-style5"></td>
                                        <td class="text-right">Reglon:&nbsp; </td>
                                        <td style="text-align: center" class="auto-style5">
                                            <div class="form-group">
                                                <div class="col-lg-10" >
                                                    <asp:Label ID="lblReglonMod" runat="server" Font-Bold="True" Font-Size="X-Large" Text="0"></asp:Label>
                                                </div>
                                            </div>
                                        </td>
                                        <td class="auto-style5"></td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style5"></td>
                                        <td class="text-right">Fuente:&nbsp; </td>
                                        <td style="text-align: center" class="auto-style5">
                                            <div class="form-group">
                                                <div class="col-lg-10" >
                                                   <asp:DropDownList ID="dropFuenteFMod" runat="server" class="form-control" Width="60%">
                                            </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div>
                                                <asp:Label ID="lblErrorModRenglon" runat ="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                            </div>
                                        </td>
                                        
                                    </tr>

                                    <tr>
                                        <td class="auto-style5"></td>
                                        <td class="text-right">Monto:<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMontoMod" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vaciosMod"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtMontoMod" ErrorMessage="Solo Numeros" Font-Bold="True" ForeColor="Red" MaximumValue="300000000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                                        </td>
                                        <td style="text-align: center" class="auto-style5">
                                            <div class="form-group">
                                                <div class="col-lg-10" >
                                                    <asp:TextBox ID="txtMontoMod" runat="server" placeholder="Monto" class="form-control" ></asp:TextBox>
                                                </div>
                                            </div>
                                        </td>
                                        <td class="auto-style5"></td>
                                    </tr>

                                </table>
                            </asp:Panel>

                            <asp:Panel ID="Panel3" runat="server" class="modal-footer">
                                <asp:Button ID="btnModalCerrarR" runat="server" class="btn btn-danger" Text="Cerrar" data-dismiss="modal" aria-hidden="true" />
                                <asp:Button ID="btnModalModificarR" runat="server" class="btn btn-primary" Text="Modificar" UseSubmitBehavior="false" data-dismiss="modal" OnClick="btnModalModificarR_Click"  />
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
                    <br />
                    <br />                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>





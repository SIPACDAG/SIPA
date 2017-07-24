<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanOperativo.aspx.cs" Inherits="AplicacionSIPA1.Operativa.PlanOperativo" MasterPageFile="~/Principal.Master" %>





<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head"></asp:Content>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upBuscar" runat="server">
                <ContentTemplate>
                    <table style="width:80%;">
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="font-size: x-large;" class="text-center" colspan="12"><strong>BÚSQUEDA</strong></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td class="text-center" colspan="12">Planificación Operativa</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: right">
                                <asp:Label ID="lblBPlan" runat="server" Text="Plan Estratégico:"></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                            </td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlBPlanes" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlBAnio_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: right">Año:&nbsp;&nbsp;&nbsp; </td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlBAnio" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlBAnio_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: right">Unidad:&nbsp;&nbsp;&nbsp; </td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlBUnidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlBUnidades_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: right">Objetivos Operativos:&nbsp;&nbsp;&nbsp; </td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlBObjetivos" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlBObjetivos_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">&nbsp;</td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlBIndicadores" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlBIndicadores_SelectedIndexChanged" Width="100%" Visible="False">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="10"><span>
                                <asp:Label ID="lblErrorBusqueda" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                </span></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="6">
                                <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" class="btn btn-info" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="16">
                                <asp:GridView ID="gridBusqueda" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnPageIndexChanging="gridBusqueda_PageIndexChanging" OnSelectedIndexChanged="gridBusqueda_SelectedIndexChanged" PageSize="25" Width="95%" style="margin-left: 39px" CssClass="table table-hover table-hover">
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
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
            <br />
            &nbsp;<br />
            <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
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
                    <table style="width:100%">
                    <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="font-size: x-large; text-align: center;" colspan="16"><strong>PLAN OPERATIVO</strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16" style="text-align: center"><strong>
                                <asp:Label ID="lblErrorPoa" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                                </strong></td>
                            <td colspan="2"><strong>
                                <asp:Label ID="lblIdPoa" runat="server" style="font-size: small" ForeColor="White">0</asp:Label>
                                </strong></td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4">
                                <asp:Label ID="lblPlanE" runat="server" Text="Plan Estratético:"></asp:Label>
                            </td>
                            <td style="width: 5%">
                                <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" Width="100%">
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
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">Año:<asp:Label ID="lblEAnio" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td colspan="8">Unidad Administrativa:<asp:Label ID="lblEUnidad" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
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
                            <td colspan="8">Dependencia/Direccion:<asp:Label ID="lblDependencia" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td colspan="8">Unidadaes/Jefaturas:<asp:Label ID="lblUnidadJefatura" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlDependencias" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                            </td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlUnidadJefatura" runat ="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlUnidadJefatura_SelectedIndexChanged1" Width="100%"></asp:DropDownList>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%"></td>
                             <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                           
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
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
                            <td colspan="16" style="text-align: center">REGISTRO</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16" style="text-align: center; font-size: large"><strong>CUADRO DE MANDO INTEGRAL</strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="text-align: center;" colspan="16"><strong>
                                <asp:Label ID="lblEstadoPoa" runat="server" style="font-size: medium"></asp:Label>
                                </strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">Del Proceso:<asp:Label ID="lblEProceso" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td colspan="8">Código:</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlProcesos" runat="server" AutoPostBack="True" class="form-control" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="8"><strong>
                                &nbsp;
                                <asp:Label ID="lblCodFormato" runat="server" Font-Bold="True" Font-Size="X-Large">GES-FOR-1</asp:Label>
                                </strong></td>
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
                                <asp:CheckBox ID="chkModAlineacion" runat="server" />
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
                            <td style="width: 5%" colspan="5">Ejes Estratégicos:<asp:Label ID="lblEEje" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td colspan="5">Objetivos Estratégicos:<asp:Label ID="lblEOEstr" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td colspan="6">Metas Estratégicas:<asp:Label ID="lblEMEstr" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="5" style="width: 5%">
                                <asp:DropDownList ID="ddlEjes" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlEjes_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlObjetivosE" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlObjetivosE_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="6">
                                <asp:DropDownList ID="ddlMetasE" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlMetasE_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%"></td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">
                                <asp:Label ID="lblEPlan" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td colspan="16">
                                <asp:GridView ID="gridPlanE" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnPageIndexChanging="gridPlanE_PageIndexChanging" OnSelectedIndexChanged="gridPlanE_SelectedIndexChanged" PageSize="3" Width="100%" CssClass="table table-hover table-responsive">
                                    <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                    <Columns>
                                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cod_ee" HeaderText="Cód. E.">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="eje" HeaderText="Eje">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cod_oe" HeaderText="Cód OE.">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="objetivo" HeaderText="OE">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="indicador" HeaderText="KPI">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="meta" HeaderText="Meta">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="anio" HeaderText="Año">
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
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
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
                            <td colspan="5">Objetivos Operativos<asp:RequiredFieldValidator ID="rfvObjetivo" runat="server" ControlToValidate="txtObjetivo" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="5">Indicadores<asp:RequiredFieldValidator ID="rfvIndicador" runat="server" ControlToValidate="txtIndicador" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="5">Metas<asp:RequiredFieldValidator ID="rfvMeta" runat="server" ControlToValidate="txtMeta" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlObjetivosO" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlObjetivosO_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%"><span>
                                <asp:Button ID="btnEliminarObjetivo" runat="server" CausesValidation="False" class="btn btn-danger" ForeColor="White" OnClick="btnEliminarObjetivo_Click" Text="-" Width="100%" />
                                </span></td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlIndicadores" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlIndicadores_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%"><span>
                                <asp:Button ID="btnEliminarIndicador" runat="server" CausesValidation="False" class="btn btn-danger" ForeColor="White" OnClick="btnEliminarIndicador_Click" Text="-" Width="100%" />
                                </span></td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlMetas" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlMetas_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td><span>
                                <asp:Button ID="btnEliminarMeta" runat="server" CausesValidation="False" class="btn btn-danger" ForeColor="White" OnClick="btnEliminarMeta_Click" Text="-" Width="100%" />
                                </span></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">
                                <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtCodigo" runat="server" class="form-control" Font-Bold="True" Font-Size="XX-Large" MaxLength="2" Visible="False" Width="100%"></asp:TextBox>
                                <asp:RangeValidator ID="rvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="Entre 1 - 99" Font-Bold="True" ForeColor="Red" MaximumValue="99" MinimumValue="1" Type="Integer" ValidationGroup="grpDatos"></asp:RangeValidator>
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="txtObjetivo" runat="server" class="form-control" Height="313px" MaxLength="500" placeholder="Objetivo Operativo" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4">
                                <asp:TextBox ID="txtIndicador" runat="server" class="form-control" Height="313px" MaxLength="500" placeholder="Indicador/Kpi" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4">
                                <asp:TextBox ID="txtMeta" runat="server" class="form-control" Height="313px" MaxLength="500" placeholder="Meta Operativa" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="9">Responsable:</td>
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
                            <td colspan="9"><strong>
                                <asp:Label ID="lblResponsable" runat="server"></asp:Label>
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
                            <td style="text-align: center;" colspan="16"><span>
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                                </span></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="text-align: center;" colspan="16">
                                <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="grpDatos" Width="120px" />
                                <asp:Button ID="btnLimpiarC" runat="server" class="btn btn-warning" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                                <asp:Button ID="btnNuevaB" runat="server" CausesValidation="False" class="btn btn-info" OnClick="btnNuevaB_Click" Text="Buscar" Visible="False" Width="120px" />
                                <asp:Button ID="btnRevisarPlan" runat="server" class="btn btn-primary" OnClick="btnRevisarPlan_Click" Text="Revisar Plan" Width="120px" />
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
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
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





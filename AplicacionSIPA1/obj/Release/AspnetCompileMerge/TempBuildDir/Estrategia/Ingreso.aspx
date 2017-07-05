<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="AplicacionSIPA1.Estrategia.Ingreso" MasterPageFile="~/Principal.Master" %>





<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head"></asp:Content>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upBuscar" runat="server">
                <ContentTemplate>
            &nbsp;<table style="width:80%;">
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
                            <td colspan="12" style="font-size: x-large"><strong>BÚSQUEDA</strong></td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="6">Planificación Estratégica</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="color: #006699; text-align: right"><b>Plan:&nbsp;&nbsp;&nbsp; </b></td>
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
                            <td colspan="4" style="color: #006699; text-align: right"><b>Ejes Estratégicos:&nbsp;&nbsp;&nbsp; </b></td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlBEjes" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="ddlBEjes_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="color: #006699; text-align: right"><b>Objetivos Estratégicos:&nbsp;&nbsp;&nbsp; </b></td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlBObjetivos" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="ddlBObjetivos_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="color: #006699; text-align: right"><b>Anios Meta:&nbsp;&nbsp;&nbsp; </b></td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlBAniosMeta" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlBAniosMeta_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="color: #006699; text-align: right"><b>Indicadores Estratégicos:&nbsp;&nbsp;&nbsp;&nbsp; </b></td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlBIndicadores" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlBIndicadores_SelectedIndexChanged" Width="100%">
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
                                <asp:DropDownList ID="ddlBMetas" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="ddlBMetas_SelectedIndexChanged" Visible="False">
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
                                <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" class="btn btn-success" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
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
                                <asp:GridView ID="gridBusqueda" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnPageIndexChanging="gridBusqueda_PageIndexChanging" OnSelectedIndexChanged="gridBusqueda_SelectedIndexChanged" PageSize="5" Width="95%" CssClass="table table-responsive table-hover" style="margin-left: 60px">
                                    <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" HeaderText="Seleccionar" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="ID">
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
                    <div></div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
            <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
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
                    <table style="width:80%;">
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="10" style="font-size: x-large"><strong>PLANIFICACIÓN ESTRATÉGICA</strong></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="4">&nbsp;</td>
                            <td style="width:7%;">&nbsp;</td>
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
                            <td colspan="4">&nbsp;</td>
                            <td style="width:7%;">&nbsp;</td>
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
                            <td colspan="4" style="color: #006699">
                                <b>Plan Estratégico:</b><strong><asp:Label ID="lblEA" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="color: #CC0000"></asp:Label>
                                </strong>
                            </td>
                            <td style="width: 7%">&nbsp;</td>
                            <td colspan="4" style="color: #006699">
                                <b>Eje Estratégico:</b><asp:Label ID="lblEE" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="font-weight: bold; color: #CC0000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 7%">&nbsp;</td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlEjes" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlEjes_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:7%;">&nbsp;</td>
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
                            <td colspan="3" style="color: #006699"><b>Objetivos Estratégicos</b></td>
                            </b></b></b></b>
                            <td colspan="6"><b>
                                <asp:Label ID="lblIdO" runat="server" Font-Size="Small"></asp:Label>
                                </b></td>
                            </b>
                            <td colspan="2" style="color: #006699">
                                &nbsp;</td>
                            <td colspan="4"><span style="color: #003366">Indicadores</span></b></b>&nbsp;&nbsp; <b>
                                <asp:Label ID="lblIdI" runat="server" Font-Size="Small"></asp:Label>
                                </b></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="color: #006699">
                                &nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlObjetivos" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlObjetivos_SelectedIndexChanged" Width="99%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 7%"><span>
                                <asp:Button ID="btnEliminarObjetivo" runat="server" CausesValidation="False" class="btn btn-danger" ForeColor="White" Text="-" Width="85%" OnClick="btnEliminarObjetivo_Click" Height="32px" />
                                </span></td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlIndicadores" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlIndicadores_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;"><span>
                                <asp:Button ID="btnEliminarIndicador" runat="server" CausesValidation="False" class="btn btn-danger" ForeColor="White" Text="-" Width="85%" OnClick="btnEliminarIndicador_Click" Height="32px" />
                                </span></td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%; height: 81px;"></td>
                            <td colspan="2" style="color: #006699; height: 81px;"><b>Código:</b><strong><asp:Label ID="lblECod" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="color: #CC0000"></asp:Label>
                                </strong>
                            </td>
                            <td colspan="3" style="height: 81px"><span style="color: #006699"><b>Objetivo Estratégico:</b></span><strong><asp:Label ID="lblEObj" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="color: #CC0000"></asp:Label>
                                </strong>
                            </td>
                            <td colspan="3" style="height: 81px"><span style="color: #006699"><b>Indicador (KPR):</b></span><strong><asp:Label ID="lblEI" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" style="color: #CC0000"></asp:Label>
                                </strong></td>
                            <td colspan="3" style="height: 81px"><span style="color: #006699"><b>Fórmula:</b></span></td>
                            </b></span></b></span></b></span></b></span></b></span>
                            <td colspan="3" style="height: 81px">Descripción:</b></span></td>
                            <td style="width:5%; height: 81px;"></td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtCodigo" runat="server" class="form-control" MaxLength="2" placeholder="Código" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="3" rowspan="11">
                                <asp:TextBox ID="txtObjetivo" runat="server" class="form-control" Height="200px" MaxLength="500" placeholder="Objetivo Estratégico" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="3" rowspan="11">
                                <asp:TextBox ID="txtIndicador" runat="server" class="form-control" Height="200px" MaxLength="500" placeholder="Indicador/Kpi" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="3" rowspan="11">
                                <asp:TextBox ID="txtFormula" runat="server" class="form-control" Height="200px" MaxLength="500" placeholder="Fórmula de Indicador" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="3" rowspan="11">
                                <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" Height="200px" MaxLength="500" placeholder="Descripción del Indicador" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="2">
                                <asp:RangeValidator ID="rvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="Entre 1 - 99" Font-Bold="True" ForeColor="Red" MaximumValue="99" MinimumValue="1" Type="Integer" ValidationGroup="grpDatos"></asp:RangeValidator>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
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
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
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
                        </tr>
                        <tr>
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
                        </tr>
                        <tr>
                            <td style="width:5%;"></td>
                            <td style="width:5%;"></td>
                            <td style="width:5%;"></td>
                            <td style="width:5%;"></td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="5" style="color: #006699"><b>Metas Estratégicas</b></td>
                            </b></b></b></b></b>
                            <td colspan="2">
                                <asp:Label ID="lblIdM" runat="server" Font-Size="Small" style="color: #CC0000"></asp:Label>
                                </b>
                            </td>
                            <td colspan="6"><span>
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                                </span></td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="6">
                                <asp:DropDownList ID="ddlMetas" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlMetas_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;"><span>
                                <asp:Button ID="btnEliminarMeta" runat="server" CausesValidation="False" class="btn btn-danger" ForeColor="White" Text="-" Width="85%" OnClick="btnEliminarMeta_Click" Height="32px" />
                                </span></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="4">
                                <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="grpDatos" Width="120px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td colspan="3" style="color: #006699"><b>Meta:</b><strong><asp:Label ID="lblEM" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" style="color: #CC0000"></asp:Label>
                                </strong></td>
                            <td colspan="3">&nbsp;</td>
                            <td colspan="3">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlAniosMeta" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddlAniosMeta_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td colspan="3">&nbsp;</td>
                            <td colspan="3" style="color: #006699"><b>Responsable:</b></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td colspan="3" rowspan="12">
                                <asp:TextBox ID="txtMeta" runat="server" class="form-control" Height="200px" MaxLength="500" placeholder="Meta Estratégica" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="3" rowspan="12">
                                <asp:TextBox ID="txtMetaPropuesta" runat="server" class="form-control" Height="200px" MaxLength="500" placeholder="Meta Propuesta" TextMode="MultiLine" Width="100%" Visible="False"></asp:TextBox>
                            </td>
                            <td colspan="6" rowspan="12">
                                <asp:RadioButtonList ID="rblUnidades" runat="server" Font-Size="X-Small" RepeatColumns="4" RepeatDirection="Horizontal" Height="198px" Width="350px">
                                </asp:RadioButtonList>

                            </td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:7%;">&nbsp;</td>
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
                            <td colspan="6">
                                <asp:Button ID="btnLimpiarC" runat="server" class="btn btn-primary" OnClick="btnLimpiarC_Click" Text="Nuevo" Width="120px" />
                                <asp:Button ID="btnNuevaB" runat="server" CausesValidation="False" class="btn btn-info" OnClick="btnNuevaB_Click" Text="Buscar" Width="120px" />
                            </td>
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
                            <td style="width:7%;">&nbsp;</td>
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
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
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





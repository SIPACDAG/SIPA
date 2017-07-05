<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GESFOR2.aspx.cs" Inherits="AplicacionSIPA1.Operativa.Modificaciones.GESFOR2" MasterPageFile="~/Principal.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upNuevo" runat="server">
                <ContentTemplate>
                    <br />
                    <table style="width:90%;">
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="border: 1px solid #000000;" colspan="2" rowspan="3">
                                <asp:Image ID="Image1" runat="server" Height="62px" ImageAlign="AbsMiddle" ImageUrl="~/img/logoEnc.png" Width="62px" />
                            </td>
                            <td style="border-top: 1px solid #000000; width: 5%">&nbsp;</td>
                            <td style="border-top: 1px solid #000000; width: 5%" colspan="2">&nbsp;</td>
                            <td style="border-top: 1px solid #000000; width: 5%">&nbsp;</td>
                            <td style="border-top: 1px solid #000000; width: 5%">&nbsp;</td>
                            <td style="border-top: 1px solid #000000; width: 5%">&nbsp;</td>
                            <td style="border-top: 1px solid #000000; width: 5%">&nbsp;</td>
                            <td style="border-top: 1px solid #000000; width: 5%">&nbsp;</td>
                            <td style="border-top: 1px solid #000000; width: 5%">&nbsp;</td>
                            <td style="border-top: 1px solid #000000; width: 5%" colspan="2">&nbsp;</td>
                            <td style="border-top: 1px solid #000000; width: 5%">&nbsp;</td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center; ">Código:</td>
                            <td style="border: 1px solid #000000; width: 5%; font-size: x-small; ">GES-FOR-2</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="11" style="text-align: center;"><strong>Confederación Deportiva Autónoma de Guatemala -CDAG-</strong></td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center; ">Versión:</td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center; ">1</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="border-bottom: 1px solid #000000; width: 5%">&nbsp;</td>
                            <td colspan="11" style="border-bottom: 1px solid #000000; text-align: center;"><strong>Formato: SOLICITUD DE MODIFICACIONES AL POA</strong></td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center; ">Página:</td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center; ">1</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="14" style="text-align: center"><strong>
                                <asp:Label ID="lblErrorPoa" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                                </strong></td>
                            <td style="text-align: center"><strong>
                                <asp:Label ID="lblIdPoa" runat="server" style="font-size: medium" ForeColor="White"></asp:Label>
                                </strong></td>
                            <td style="width: 5%"><strong>
                                <asp:Label ID="lblIdSol" runat="server" ForeColor="White" style="font-size: medium">0</asp:Label>
                                </strong></td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td class="text-right" colspan="5"><strong>No.</strong>
                                <asp:Label ID="lblAnioSol" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                <strong><span style="font-size: large">-</span></strong><asp:Label ID="lblNo" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="border: 1px solid #000000;" class="text-left" colspan="6"><strong>Unidad solicitante:<asp:Label ID="lblEUnidad" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:Label>
                                </strong></td>
                            <td style="border: 1px solid #000000;" colspan="10">
                                <asp:DropDownList ID="ddlDependencias" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td class="text-left" colspan="6" style="border: 1px solid #000000;"><strong>Fecha:<asp:Label ID="lblEFecha" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:Label>
                                </strong></td>
                            <td colspan="10" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtFecha" runat="server" placeholder="Ej. 01/01/2016" TextMode="Date" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="border: 1px solid #000000;" class="text-left" colspan="6"><strong>Estado:</strong></td>
                            <td style="border: 1px solid #000000;" class="text-right" colspan="10"><strong>
                                <asp:Label ID="lblEstado" runat="server" style="font-size: medium"></asp:Label>
                                </strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td class="text-left" colspan="6" style="border-top: 1px solid #000000;">&nbsp;</td>
                            <td class="text-right" colspan="10" style="border-top: 1px solid #000000;">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="text-align: center;" colspan="6">Ubicación de modificación en el Plan Estratégico:<strong><asp:Label ID="lblEAccion" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:Label>
                                </strong></td>
                            <td colspan="10">
                                <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="6" style="text-align: center;">&nbsp;</td>
                            <td colspan="5">&nbsp;</td>
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="6" style="border: 1px solid #000000; text-align: left;"><strong>Eje Estratégico:</strong></td>
                            <td colspan="10" style="border: 1px solid #000000; text-align: center;">
                                <asp:HiddenField ID="hfIdEE" runat="server" />
                                <asp:Label ID="lblEje" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="6" style="border: 1px solid #000000; text-align: left;"><strong>Objetivo Estratégico:</strong></td>
                            <td colspan="10" style="border: 1px solid #000000; text-align: center;">
                                <asp:HiddenField ID="hfIdOE" runat="server" />
                                <asp:Label ID="lblOE" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="border: 1px solid #000000; text-align: left;" colspan="6"><strong>Indicador
                                <asp:Label ID="lblAnio2" runat="server" Font-Bold="True"></asp:Label>
                                :</strong></td>
                            <td style="border: 1px solid #000000; text-align: center;" colspan="10">
                                <asp:Label ID="lblIE" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="6" style="border: 1px solid #000000; text-align: left;"><strong>Meta
                                <asp:Label ID="lblAnio3" runat="server" Font-Bold="True"></asp:Label>
                                :</strong></td>
                            <td colspan="10" style="border: 1px solid #000000; padding: 1px 4px; text-align: center;">
                                <asp:HiddenField ID="hfIdME" runat="server" />
                                <asp:Label ID="lblME" runat="server" Font-Bold="True"></asp:Label>
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
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="6">Agregar el cambio que desea realizar:</td>
                            <td colspan="5">
                                <asp:RadioButtonList ID="rblCambio" runat="server" RepeatDirection="Horizontal" Width="90%" OnSelectedIndexChanged="rblCambio_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="1">Modificación</asp:ListItem>
                                    <asp:ListItem Value="2">Adición</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width: 5%" colspan="2">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4">
                                <asp:HiddenField ID="hfIdOO" runat="server" />
                            </td>
                            <td colspan="4">
                                <asp:HiddenField ID="hfIdIO" runat="server" />
                            </td>
                            <td colspan="4">
                                <asp:HiddenField ID="hfIdMO" runat="server" />
                            </td>
                            <td colspan="4">
                                <asp:HiddenField ID="hfIdAC" runat="server" />
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="border: 1px solid #000000; text-align: center;" colspan="4"><b>
                                <asp:CheckBox ID="chk1" runat="server" OnCheckedChanged="chk1_CheckedChanged" AutoPostBack="True" />
                                Objetivo operativo<asp:RequiredFieldValidator ID="rfvObjetivo" runat="server" ControlToValidate="txtObjetivo0" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </b></td>
                            </b></b>
                            <td colspan="4" style="border: 1px solid #000000; text-align: center;"><strong>Indicador<asp:RequiredFieldValidator ID="rfvIndicador" runat="server" ControlToValidate="txtIndicador0" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </strong></td>
                            <td colspan="4" style="border: 1px solid #000000; text-align: center;"><strong>Meta </strong>
                                <asp:Label ID="lblAnio" runat="server" Font-Bold="True"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvMetaO" runat="server" ControlToValidate="txtMetaO0" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="4" style="border: 1px solid #000000; text-align: center;"><strong>Acción</b><asp:RequiredFieldValidator ID="rfvAccion" runat="server" ControlToValidate="txtAccion0" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtObjetivo" runat="server" class="form-control" Height="150px" MaxLength="500" placeholder="Objetivo Operativo" TextMode="MultiLine" Width="100%" Enabled="False"></asp:TextBox>
                            </td>
                            <td colspan="4" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtIndicador" runat="server" class="form-control" Height="150px" MaxLength="500" placeholder="Indicador/Kpi" TextMode="MultiLine" Width="100%" Enabled="False"></asp:TextBox>
                            </td>
                            <td colspan="4" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtMetaO" runat="server" class="form-control" Height="150px" MaxLength="500" placeholder="Meta Operativa" TextMode="MultiLine" Width="100%" Enabled="False"></asp:TextBox>
                            </td>
                            <td colspan="4" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtAccion" runat="server" class="form-control" Height="150px" MaxLength="250" placeholder="Descripción" TextMode="MultiLine" Width="100%" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtObjetivo0" runat="server" class="form-control" Height="150px" MaxLength="500" placeholder="Escriba aquí el nuevo Objetivo" TextMode="MultiLine" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td colspan="4" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtIndicador0" runat="server" class="form-control" Height="150px" MaxLength="500" placeholder="Escriba aquí el nuevo Indicador/Kpi" TextMode="MultiLine" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td colspan="4" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtMetaO0" runat="server" class="form-control" Height="150px" MaxLength="500" placeholder="Escriba aquí el nuevo Meta Operativa" TextMode="MultiLine" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td colspan="4" style="border: 1px solid #000000;">
                                <asp:TextBox ID="txtAccion0" runat="server" class="form-control" Height="150px" MaxLength="250" placeholder="Escriba aquí la nueva Acción" TextMode="MultiLine" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2">
                                <asp:CheckBox ID="chkMostrarDet" runat="server" OnCheckedChanged="chkMostrarDet_CheckedChanged" AutoPostBack="True" Text="KPI 3er nivel" />
                            </td>
                            <td colspan="4">
                                <asp:HiddenField ID="hfIdMA" runat="server" />
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%" colspan="2">&nbsp;</td>
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
                                <asp:Panel ID="pnlDetAccion" runat="server" Height="465px">
                                    <table style="width:100%;">
                                    <tr>
                                        <td style="border: 1px solid #000000; width: 25%; text-align: center;"><b>Meta
                                            <asp:Label ID="lblAnio1" runat="server" Font-Bold="True"></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvMeta" runat="server" ControlToValidate="txtMetaM" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                            </b></td>
                                        <td style="border: 1px solid #000000; width: 25%; text-align: center;"><strong>Meta 1er. Cuatrimestre</b></b><asp:RequiredFieldValidator ID="rfvMetaC1" runat="server" ControlToValidate="txtMetaM1" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                            </strong></td>
                                        <td style="border: 1px solid #000000; width: 25%; text-align: center;"><b>Meta 2do. Cuatrimestre<asp:RequiredFieldValidator ID="rfvMetaC2" runat="server" ControlToValidate="txtMetaM2" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                            </b></td>
                                        <td style="border: 1px solid #000000; width: 25%; text-align: center;"><b>Meta 3er. Cuatrimestre<asp:RequiredFieldValidator ID="rfvMetaC3" runat="server" ControlToValidate="txtMetaM3" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                            </b></td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px solid #000000; width: 25%">
                                            <asp:TextBox ID="txtMeta" runat="server" class="form-control" Height="150px" MaxLength="250" placeholder="Meta Global" TextMode="MultiLine" Width="100%" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 25%">
                                            <asp:TextBox ID="txtMeta1" runat="server" class="form-control" Height="150px" MaxLength="250" placeholder="Meta 1er. Cuatrimestre" TextMode="MultiLine" Width="100%" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 25%">
                                            <asp:TextBox ID="txtMeta2" runat="server" class="form-control" Height="150px" MaxLength="250" placeholder="Meta 2do. Cuatrimestre" TextMode="MultiLine" Width="100%" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 25%">
                                            <asp:TextBox ID="txtMeta3" runat="server" class="form-control" Height="150px" MaxLength="250" placeholder="Meta 3er. Cuatrimestre" TextMode="MultiLine" Width="100%" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px solid #000000; width: 25%">
                                            <asp:TextBox ID="txtMetaM" runat="server" class="form-control" Height="150px" MaxLength="250" placeholder="Escriba aquí la nueva Meta" TextMode="MultiLine" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 25%">
                                            <asp:TextBox ID="txtMetaM1" runat="server" class="form-control" Height="150px" MaxLength="250" placeholder="Escriba aquí la nueva Meta" TextMode="MultiLine" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 25%">
                                            <asp:TextBox ID="txtMetaM2" runat="server" class="form-control" Height="150px" MaxLength="250" placeholder="Escriba aquí la nueva Meta" TextMode="MultiLine" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                                        </td>
                                        <td style="border: 1px solid #000000; width: 25%">
                                            <asp:TextBox ID="txtMetaM3" runat="server" class="form-control" Height="150px" MaxLength="250" placeholder="Escriba aquí la nueva Meta" TextMode="MultiLine" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; width: 25%">&nbsp;</td>
                                            <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; width: 25%">&nbsp;</td>
                                            <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; width: 25%">&nbsp;</td>
                                            <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; width: 25%">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="border: 1px solid #000000; width: 25%; text-align: center;"><strong>Responsable:<asp:RequiredFieldValidator ID="rfvResponsable" runat="server" ControlToValidate="txtResponsable" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                                <br />
                                                <b>
                                                <asp:Label ID="lblResponsable" runat="server" Font-Bold="False"></asp:Label>
                                                </b></strong></td>
                                            <td style="border: 1px solid #000000; width: 25%; text-align: center;"><strong>Pond. 1er. Cuatr.<b>: <asp:RequiredFieldValidator ID="rfvPond1" runat="server" ControlToValidate="txtPond1" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:Label ID="lblPond1" runat="server" Font-Bold="False"></asp:Label>
                                                %</b></strong></td>
                                            <td style="border: 1px solid #000000; width: 25%; text-align: center;"><strong>Pond. 1er. Cuatr.: <b>
                                                <asp:RequiredFieldValidator ID="rfvPond2" runat="server" ControlToValidate="txtPond2" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:Label ID="lblPond2" runat="server" Font-Bold="False"></asp:Label>
                                                %</b></strong></td>
                                            <td style="border: 1px solid #000000; width: 25%; text-align: center;"><strong>Pond. 1er. Cuatr.: <b>
                                                <asp:RequiredFieldValidator ID="rfvPond3" runat="server" ControlToValidate="txtPond3" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:Label ID="lblPond3" runat="server" Font-Bold="False"></asp:Label>
                                                %</b></strong></td>
                                        </tr>
                                        <tr>
                                            <td style="border: 1px solid #000000; width: 25%">
                                                <asp:TextBox ID="txtResponsable" runat="server" class="form-control" MaxLength="250" placeholder="Responsable" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                                            </td>
                                            <td style="border: 1px solid #000000; width: 25%">
                                                <asp:TextBox ID="txtPond1" runat="server" class="form-control" MaxLength="3" placeholder="Ponderación" TextMode="Number" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                                            </td>
                                            <td style="border: 1px solid #000000; width: 25%">
                                                <asp:TextBox ID="txtPond2" runat="server" class="form-control" MaxLength="3" placeholder="Ponderación" TextMode="Number" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                                            </td>
                                            <td style="border: 1px solid #000000; width: 25%">
                                                <asp:TextBox ID="txtPond3" runat="server" class="form-control" MaxLength="3" placeholder="Ponderación" TextMode="Number" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border-top: 1px solid #000000; width: 25%">&nbsp;</td>
                                            <td style="border-top: 1px solid #000000; width: 25%">
                                                <asp:RangeValidator ID="rvPond0" runat="server" ControlToValidate="txtPond1" ErrorMessage="Entre 1 y 100" Font-Bold="True" ForeColor="Red" MaximumValue="100" MinimumValue="1" Type="Integer" ValidationGroup="grpDatos"></asp:RangeValidator>
                                            </td>
                                            <td style="border-top: 1px solid #000000; width: 25%">
                                                <asp:RangeValidator ID="rvPond1" runat="server" ControlToValidate="txtPond2" ErrorMessage="Entre 1 y 100" Font-Bold="True" ForeColor="Red" MaximumValue="100" MinimumValue="1" Type="Integer" ValidationGroup="grpDatos"></asp:RangeValidator>
                                            </td>
                                            <td style="border-top: 1px solid #000000; width: 25%">
                                                <asp:RangeValidator ID="rvPond2" runat="server" ControlToValidate="txtPond3" ErrorMessage="Entre 1 y 100" Font-Bold="True" ForeColor="Red" MaximumValue="100" MinimumValue="1" Type="Integer" ValidationGroup="grpDatos"></asp:RangeValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <br />
                                    <br />
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
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center;" colspan="4"><b>Ponderación<asp:RequiredFieldValidator ID="rfvPonderacion" runat="server" ControlToValidate="txtPonderacion" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                &nbsp;(<asp:Label ID="lblPorcentaje" runat="server" Font-Bold="True"></asp:Label>
                                )%</b></td>
                            </b></b></b></b></b>
                            <td colspan="4" style="text-align: center; border: 1px solid #000000">&nbsp;</td>
                            </b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b></b>
                            <td colspan="4" style="text-align: center; border: 1px solid #000000"><strong><b>
                                <asp:Label ID="lblS1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" Visible="False">(-)</asp:Label>
                                &nbsp;</b><asp:RequiredFieldValidator ID="rfvPresupuesto" runat="server" ControlToValidate="txtPpto1" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos" Visible="False"></asp:RequiredFieldValidator>
                                </strong></td>
                            <td colspan="4" style="text-align: center; border: 1px solid #000000">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4" style="border: 1px solid #000000">
                                <asp:TextBox ID="txtPonderacion" runat="server" class="form-control" MaxLength="3" placeholder="Ponderación" TextMode="Number" Width="100%" Enabled="False"></asp:TextBox>
                            </td>
                            <td colspan="4" style="border: 1px solid #000000" class="text-right">
                                <asp:Label ID="lblPpto1" runat="server" Font-Bold="False" Font-Size="Large" Visible="False"></asp:Label>
                            </td>
                            <td colspan="4" style="border: 1px solid #000000" class="text-right">
                                <asp:TextBox ID="txtPpto1" runat="server" Style="text-align: right" class="form-control" MaxLength="20" ToolTip="Debe ser menor al presupuesto disponible" Width="100%" Font-Size="Large" Visible="False">100, 000, 000.00</asp:TextBox>
                            </td>
                            <td colspan="4" style="border: 1px solid #000000" class="text-right">
                                <asp:Label ID="lblPptoM1" runat="server" Font-Bold="False" Font-Size="Large" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4">
                                <asp:RangeValidator ID="rvPond" runat="server" ControlToValidate="txtPonderacion" ErrorMessage="Entre 1 y 100" Font-Bold="True" ForeColor="Red" MaximumValue="100" MinimumValue="1" Type="Integer" ValidationGroup="grpDatos"></asp:RangeValidator>
                            </td>
                            <td colspan="4">&nbsp;</td>
                            <td colspan="4">
                                <asp:RangeValidator ID="rvPresupuesto" runat="server" ControlToValidate="txtPpto1" ErrorMessage="Entre 0 y el disponible" Font-Bold="True" ForeColor="Red" MaximumValue="100000000" MinimumValue="0" Type="Double" ValidationGroup="grpDatos" Enabled="False"></asp:RangeValidator>
                            </td>
                            <td colspan="4">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">* Colocar en la casilla en blanco la modificación que se requiere</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2" style="width: 5%">&nbsp;</td>
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
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="border: 1px solid #000000; width: 5%" rowspan="3">&nbsp;</td>
                            <td style="border: 1px solid #000000; text-align: center;" colspan="14"><strong>
                                <asp:CheckBox ID="chkCronograma" runat="server" AutoPostBack="True" OnCheckedChanged="chkCronograma_CheckedChanged" />
                                CRONOGRAMA<asp:Label ID="lblEMeses" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                                </strong></td>
                            <td style="border: 1px solid #000000; width: 5%" rowspan="3"></b></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            </b></b></b></b></b></b></b></b></b></b></b>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center;"><b>ENE<strong><asp:Label ID="lblM1" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </strong></b></td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center;"><strong>FEB<b><asp:Label ID="lblM2" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </b></strong></td>
                            <td colspan="2" style="border: 1px solid #000000; width: 5%; text-align: center;"><strong>MAR<b><asp:Label ID="lblM3" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </b></strong></td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center;"><strong>ABR<b><asp:Label ID="lblM4" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </b></strong></td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center;"><strong>MAY<b><asp:Label ID="lblM5" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </b></strong></td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center;"><strong>JUN<b><asp:Label ID="lblM6" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </b></strong></td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center;"><strong>JUL<b><asp:Label ID="lblM7" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </b></strong></td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center;"><strong>AGO<b><asp:Label ID="lblM8" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </b></strong></td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center;"><strong>SEP<b><asp:Label ID="lblM9" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </b></strong></td>
                            <td colspan="2" style="border: 1px solid #000000; width: 5%; text-align: center;"><strong>OCT<b><asp:Label ID="lblM10" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </b></strong></td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center;"><strong>NOV<b><asp:Label ID="lblM11" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </b></strong></td>
                            <td style="border: 1px solid #000000; width: 5%; text-align: center;"><strong>DIC</b><b><asp:Label ID="lblM12" runat="server" Font-Bold="True" Font-Size="Large" Text="*"></asp:Label>
                                </b></strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM1" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM2" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td colspan="2" style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM3" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM4" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM5" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM6" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM7" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM8" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM9" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td colspan="2" style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM10" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM11" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
                            </td>
                            <td style="border: 1px solid #000000; width: 5%">
                                <asp:TextBox ID="txtM12" runat="server" class="form-control" Font-Bold="True" MaxLength="1" Width="100%" BackColor="#FFFF99"></asp:TextBox>
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
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="text-align: center;" colspan="4" class="text-right"><strong><asp:Label ID="lblEAccion2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Visible="False">*</asp:Label>
                                </strong></td>
                            <td colspan="4" style="text-align: center;" class="text-right">
                                <asp:RadioButtonList ID="rblModPpto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblModPpto_SelectedIndexChanged" RepeatDirection="Horizontal" Visible="False" Width="90%">
                                    <asp:ListItem Value="1">Interna</asp:ListItem>
                                    <asp:ListItem Value="2">Externa</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td colspan="4" style="text-align: center;" class="text-right"><strong><b>
                                <asp:Label ID="lblS2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" Visible="False">(+)</asp:Label>
                                &nbsp;</b><asp:RequiredFieldValidator ID="rfvPresupuesto2" runat="server" ControlToValidate="txtPpto2" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos" Visible="False"></asp:RequiredFieldValidator>
                                </strong></td>
                            <td colspan="4" style="text-align: center;" class="text-right">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlAcciones2" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAcciones2_SelectedIndexChanged" Width="100%" Visible="False">
                                </asp:DropDownList>
                            </td>
                            <td colspan="4" class="text-right">
                                <asp:Label ID="lblPpto2" runat="server" Font-Bold="False" Font-Size="Large" Visible="False"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="txtPpto2" runat="server" class="form-control" Font-Size="Large" MaxLength="20" Style="text-align: right" ToolTip="Debe ser menor al presupuesto disponible" Width="100%" Visible="False" BackColor="#FFFF99">100, 000, 000.00</asp:TextBox>
                            </td>
                            <td colspan="4" class="text-right">
                                <asp:Label ID="lblPptoM2" runat="server" Font-Bold="False" Font-Size="Large" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="4">&nbsp;</td>
                            <td class="text-right" colspan="4" >&nbsp;</td>
                            <td colspan="4" ><asp:RangeValidator ID="rvPresupuesto0" runat="server" ControlToValidate="txtPpto2" ErrorMessage="Entre 0 y el disponible" Font-Bold="True" ForeColor="Red" MaximumValue="100000000" MinimumValue="0" ValidationGroup="grpDatos" Enabled="False"></asp:RangeValidator>
                                </td>
                            <td class="text-right" colspan="4">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="border-left: 1px solid #000000; border-right: 1px solid #000000; border-top: 1px solid #000000;" colspan="16"><strong>Justificación de la modificación:<asp:RequiredFieldValidator ID="rfvJustificacion" runat="server" ControlToValidate="txtJustificacion" Enabled="False" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </strong></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="border-left: 1px solid #000000; border-right: 1px solid #000000; border-bottom: 1px solid #000000;" colspan="16">
                                <asp:TextBox ID="txtJustificacion" runat="server" class="form-control" Height="100px" MaxLength="1000" placeholder="Justificación" TextMode="MultiLine" Width="100%" Font-Size="Small" BackColor="#FFFF99"></asp:TextBox>
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
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2" style="width: 5%">&nbsp;</td>
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
                            <td colspan="16" style="text-align: center;">
                                <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" Width="120px" />
                                <asp:Button ID="btnEnviar" runat="server" class="btn btn-primary" Text="Enviar" Width="120px" />
                                <asp:Button ID="btnLimpiarC" runat="server" class="btn btn-warning" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                                <asp:Button ID="btnListado" runat="server" class="btn btn-info" Text="Listado" Width="120px" PostBackUrl="~/Operativa/Modificaciones/GESFOR2Listado.aspx" />
                                <asp:Button ID="btnImprimir" runat="server" CausesValidation="False" class="btn btn-default" OnClick="btnImprimir_Click" Text="Imprimir" Width="120px" />
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
                            <td colspan="2" style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="2" style="width: 5%">&nbsp;</td>
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
                            <td style="width: 5%" colspan="2">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%" colspan="2">&nbsp;</td>
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
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
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
            <asp:UpdatePanel ID="upConfirmar" runat="server">
                <ContentTemplate>
                    <table style="width:80%;">
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="13" style="font-size: x-large" class="text-center"><strong>ACCIONES</strong></td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="13" class="text-center">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="2" style="text-align: right">
                                <asp:Label ID="lblPlanE" runat="server" Text="Plan Estratégico:"></asp:Label>
                            </td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" class="form-control" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="4" style="text-align: right">Año:<asp:Label ID="lblEAnio" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="5" style="text-align: right">Unidad:</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" class="form-control" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td class="text-center" colspan="15" style="text-align: right">
                                <strong>
                                <asp:Label ID="lblEncabezado" runat="server" Font-Bold="True" Font-Size="Medium" style="text-align: center"></asp:Label>
                                </strong></td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="5" style="text-align: right">Objetivos Operativos:<span class="auto-style25" style="font-size: small"><asp:Label ID="lblEObjetivo" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                                </span></td>
                            <td colspan="5" style="text-align: right">Indicadores:<span class="auto-style25" style="font-size: small"><asp:Label ID="lblEIndicador" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                                </span></td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlObjetivos" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="ddlObjetivos_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlIndicadores" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="ddlIndicadores_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="2" style="text-align: right">
                                <asp:Label ID="lblEPlan" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td colspan="5">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="16">
                                <asp:GridView ID="gridPlanO" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="5" Width="95%" OnPageIndexChanging="gridPlanO_PageIndexChanging" OnSelectedIndexChanged="gridPlanO_SelectedIndexChanged" style="margin-left: 70px" CssClass="table table-hover table-responsive">
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
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="4" style="text-align: right">Acciones:</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="8">
                                &nbsp;</td>
                            <td><span>
                                <asp:Button ID="btnEliminarAccion" runat="server" CausesValidation="False" class="btn btn-danger" ForeColor="White" OnClick="btnEliminarAccion_Click" Text="-" Width="79%" Height="30px" />
                                </span></td>
                            <td colspan="6">
                                <asp:DropDownList ID="ddlMetas" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlMetas_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="4" style="text-align: right">Dependencia:<asp:Label ID="lblEDependencia" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="8">
                                &nbsp;</td>
                            <td class="text-right" colspan="2" style="font-size: large">
                                <strong>Estado:</strong></td>
                            <td class="text-right" colspan="3">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="2">
                                <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="text-right" colspan="2" style="font-size: large"><strong>Ppto. Aprobado:</strong></td>
                            <td colspan="3" class="text-right">
                                <asp:Label ID="lblTecho" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="0.00"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="2" rowspan="2">
                                <asp:TextBox ID="txtCodigo" runat="server" class="form-control" Font-Bold="True" Font-Size="X-Large" MaxLength="2" TextMode="Number" ToolTip="Valores entre 1 y 99" Width="100%" Visible="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="text-right" colspan="2"><strong><span style="font-size: large">Asignado:</span></strong></td>
                            <td colspan="3" class="text-right">
                                <asp:Label ID="lblAsignado" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#006600" style="text-align: right" Text="0.00"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">|</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="font-size: large;" class="text-right">&nbsp;</td>
                            <td class="text-right" colspan="2" style="font-size: large;"><strong><span style="font-size: large">Disponible:</span></strong></td>
                            <td class="text-right" colspan="3" style="font-size: large">
                                <asp:Label ID="lblDisponible" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="0.00"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%; height: 19px;"></td>
                            <td style="height: 19px; text-align: right;" colspan="2">
                                <asp:RangeValidator ID="rvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="Entre 1 - 99" Font-Bold="True" ForeColor="Red" MaximumValue="99" MinimumValue="1" Type="Integer" ValidationGroup="grpDatos"></asp:RangeValidator>
                            </td>
                            <td style="height: 19px;">
                                &nbsp;</td>
                            <td style="height: 19px;"></td>
                            <td style="height: 19px;"></td>
                            <td style="height: 19px;" colspan="2">&nbsp;</td>
                            <td style="height: 19px;" class="text-right" colspan="2"></td>
                            <td class="text-right" colspan="3" style="height: 19px;">
                                <br />
                            </td>
                            <td style="height: 19px;">
                                &nbsp;</td>
                            <td style="height: 19px;">&nbsp;</td>
                            <td style="height: 19px;">&nbsp;</td>
                            <td style="width: 4%; height: 19px;"></td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="14">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td colspan="15">
                                &nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
                            <td style="width: 4%">&nbsp;</td>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>





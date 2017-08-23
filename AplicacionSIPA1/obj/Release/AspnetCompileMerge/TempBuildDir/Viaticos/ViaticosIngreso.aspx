<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViaticosIngreso.aspx.cs" Inherits="AplicacionSIPA1.Viaticos.ViaticosIngreso" MasterPageFile="~/Principal.Master" %>



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
                        <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" Width="50%">
                        </asp:DropDownList>
                        </strong></td>
                    <td style="font-size: x-large; text-align: center; color: #FFFFFF; background-color: #006600;" class="text-center" colspan="16">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Text="INGRESO DE SOLICITUD DE VIATICOS AL INTERIOR"></asp:Label>
                    </td>
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
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
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
                    <td style="width: 5%"><strong>
                        <asp:Label ID="lblIdEncabezado" runat="server" ForeColor="White" style="font-size: medium">0</asp:Label>
                        </strong></td>
                    <td colspan="8">Nombramiento de Comisión No. <strong><span style="font-size: medium">CDAG-</span><asp:Label ID="lblUnidadAbr" runat="server" style="font-size: medium">ABC</asp:Label>
                        </strong>-<strong><asp:Label ID="lblNoEncabezado" runat="server" style="font-size: medium">0</asp:Label>
                        -<asp:Label ID="lblAnio" runat="server" style="font-size: medium">0</asp:Label>
                        </strong></td>
                    <td class="text-right" colspan="8">Estado: <strong>
                        <asp:Label ID="lblEstado" runat="server" style="font-size: medium"></asp:Label>
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
                    <td colspan="8">Jefe o Director:<strong><asp:Label ID="lblErrorJefeDirector" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="8">Subgerente:<strong><asp:Label ID="lblErrorSubgerente" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:DropDownList ID="ddlJefeDirector" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" Width="100%" OnSelectedIndexChanged="ddlJefeDirector_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td colspan="8">
                        <asp:DropDownList ID="ddlSubgerente" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" Width="100%" OnSelectedIndexChanged="ddlSubgerente_SelectedIndexChanged">
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
                    <td colspan="4">Fecha Nombramiento (dd/mm/yyyy):<strong><asp:Label ID="lblErrorFechaNombramiento" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="6">Dependencia:<strong><asp:Label ID="lblErrorDependencia" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="5">Tipo de persona:<strong><asp:Label ID="lblErrorTipoPersona" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtFecha" runat="server" BackColor="#FFFF99" class="" Font-Size="Large" Style="text-align: right" Width="100%" TextMode="Date"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="6">
                        <asp:TextBox ID="txtDependencia" runat="server" BackColor="#FFFF99" class="form-control" Style="text-align: left" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td class="text-right" colspan="5">
                        <asp:RadioButtonList ID="rblTipoPersonal" runat="server" RepeatDirection="Horizontal" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="rblTipoPersonal_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="1">Personal de CDAG</asp:ListItem>
                            <asp:ListItem Value="2">Deportista</asp:ListItem>
                            <asp:ListItem Value="3">Otro</asp:ListItem>
                        </asp:RadioButtonList>
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
                    <td colspan="8">Señor (a)(ita):<strong><asp:Label ID="lblErrorEmpleado" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="8">Puesto:<strong><asp:Label ID="lblErrorPuesto" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:TextBox ID="txtNombre" runat="server" BackColor="#FFFF99" class="form-control" Style="text-align: left" Width="100%"></asp:TextBox>
                        <asp:DropDownList ID="ddlEmpleados" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" Width="100%" OnSelectedIndexChanged="ddlEmpleados_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td colspan="8">
                        <asp:TextBox ID="txtPuesto" runat="server" BackColor="#FFFF99" class="form-control" ReadOnly="True" Style="text-align: left" Width="100%"></asp:TextBox>
                        <asp:DropDownList ID="ddlPuestos" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" Width="100%" OnSelectedIndexChanged="ddlPuestos_SelectedIndexChanged" Visible="False">
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
                    <td colspan="4">Correo electrónico:<strong><asp:Label ID="lblErrorEmail" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="4">Teléfono:<strong><asp:Label ID="lblErrorTelefono" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="4">NIT:<strong><asp:Label ID="lblErrorNit" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="4">Sueldo Base (Q.):<strong><asp:Label ID="lblErrorSueldo" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtEmail" runat="server" BackColor="#FFFF99" class="" Style="text-align: left" Width="95%"></asp:TextBox>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtTelefono" runat="server" BackColor="#FFFF99" class="" Style="text-align: left" Width="95%"></asp:TextBox>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtNit" runat="server" BackColor="#FFFF99" class="" Style="text-align: left" Width="95%"></asp:TextBox>
                    </td>
                    <td colspan="4" class="text-right">
                        <asp:TextBox ID="txtSueldoBase" runat="server" BackColor="#FFFF99" class="" Style="text-align: right" Width="95%" ReadOnly="True" ForeColor="#FFFF99"></asp:TextBox>
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
                    <td colspan="16">Descripción de la comisión:<strong><asp:Label ID="lblErrorJustificacion" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">
                        <asp:TextBox ID="txtJustificacion" runat="server" BackColor="#FFFF99" class="" Style="text-align: left" Width="100%" Height="40px" TextMode="MultiLine"></asp:TextBox>
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
                    <td colspan="16">Destino:<strong><asp:Label ID="lblErrorDestino" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">
                        <asp:TextBox ID="txtDestino" runat="server" BackColor="#FFFF99" class="" Style="text-align: left" Width="100%" Height="40px" TextMode="MultiLine"></asp:TextBox>
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
                    <td colspan="4" style="text-align: center">Fecha de la Comisión</td>
                    <td style="text-align: center;" colspan="4">Hora de la Comisión (Salida/Retorno):</td>
                    <td style="text-align: center;" colspan="8">Observaciones:<strong><asp:Label ID="lblErrorObservaciones" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>

                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="text-align: center;" colspan="4">(Salida/Retorno) (dd/mm/yyyy):</td>
                    <td style="width: 5%; text-align: center;">Hrs.</td>
                    <td style="width: 5%; text-align: center;">Mins</td>
                    <td style="width: 5%; text-align: center;">Hrs.</td>
                    <td style="width: 5%; text-align: center;">Mins.</td>
                    <td class="text-right" colspan="8" rowspan="4">
                        <asp:TextBox ID="txtObservaciones" runat="server" BackColor="#FFFF99" class="" Height="80px" Style="text-align: left" TextMode="MultiLine" Width="98%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="text-align: center;" colspan="4">
                        <asp:TextBox ID="txtFechaIni" runat="server" BackColor="#FFFF99" class="" MaxLength="10" Style="text-align: right" TextMode="Date" Width="45%" Font-Bold="True" Font-Size="X-Small">01/01/2016</asp:TextBox>
                        &nbsp;
                        <asp:TextBox ID="txtFechaFin" runat="server" BackColor="#FFFF99" class="" MaxLength="10" Style="text-align: right" TextMode="Date" Width="45%" Font-Bold="True" Font-Size="X-Small">01/01/2016</asp:TextBox>
                    </td>
                    <td style="width: 5%">
                        <asp:DropDownList ID="ddlHoraIni" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="" Width="75%" Height="30px" OnSelectedIndexChanged="ddlJefeDirector_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%">
                        <asp:DropDownList ID="ddlMinIni" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="" Width="75%" Height="30px" OnSelectedIndexChanged="ddlJefeDirector_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%" class="text-right">
                        <asp:DropDownList ID="ddlHoraFin" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="" Width="75%" Height="30px" OnSelectedIndexChanged="ddlJefeDirector_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%" class="text-right">
                        <asp:DropDownList ID="ddlMinFin" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="" Width="75%" Height="30px" OnSelectedIndexChanged="ddlJefeDirector_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="4"><strong>
                        <asp:Label ID="lblErrorFechas" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="4"><strong>
                        <asp:Label ID="lblErrorHoras" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
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
                </tr>

                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2" rowspan="2"><strong>Forma de<br /> Transporte</strong></td>
                    <td colspan="3">Vehículo de la Institución:</td>
                    <td colspan="3">Pasajes (Q.)</td>
                    <td colspan="3">Vehículo Propio (Kms):</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="3" style="text-align: center">
                        Cuota Diaria:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="3">
                        <asp:RadioButtonList ID="rblVehiculoInst" runat="server" RepeatDirection="Horizontal" Width="95%" OnSelectedIndexChanged="rblVehiculoInst_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtPasajes" runat="server" class="" MaxLength="10" Style="text-align: right" Width="100%"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtKilometraje" runat="server" class="" MaxLength="10" Style="text-align: right" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="3" style="text-align: center">
                        <asp:TextBox ID="txtCuotaDiaria" runat="server" class="" MaxLength="12" Style="text-align: right" Width="100%" ReadOnly="True"></asp:TextBox>
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
                    <td colspan="3"><strong>
                        <asp:Label ID="lblErrorPasajes" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td colspan="3"><strong>
                        <asp:Label ID="lblErrorKms" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="3"><strong>
                        <asp:Label ID="lblErrorCuota" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="10">
                        <asp:RadioButtonList ID="rblCategoria" runat="server" AutoPostBack="True" Font-Size="X-Small" OnSelectedIndexChanged="rblCategoria_SelectedIndexChanged" RepeatDirection="Horizontal" Width="90%">
                            <asp:ListItem Selected="True" Value="36">CATEGORÍA I</asp:ListItem>
                            <asp:ListItem Value="37">CATEGORÍA II</asp:ListItem>
                            <asp:ListItem Value="38">CATEGORÍA III</asp:ListItem>
                            <asp:ListItem Value="39">CATEGORÍA IV</asp:ListItem>
                            <asp:ListItem Value="40">CATEGORÍA V</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
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
                        <asp:TextBox ID="txtCategoria" runat="server" Font-Size="X-Small" Height="40px" ReadOnly="True" Style="text-align: left" TextMode="MultiLine" Width="100%" Visible="False"></asp:TextBox>
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
                    <td colspan="3" style="border: 1px solid #000000; padding: 1px 4px; text-align: center; font-weight: bold;"><b>Pasajes (Q.)</b></td>
                    </b></b></b></b></b></b></b></b></b></b></b></b>
                    <td colspan="3" style="border: 1px solid #000000; padding: 1px 4px; text-align: center;"><b>Kilometraje (Q.)</b></td>
                    <td colspan="3" style="border: 1px solid #000000; padding: 1px 4px; text-align: center;"><strong>Viáticos (Q.)</strong></td>
                    <td colspan="3" style="border: 1px solid #000000; padding: 1px 4px; text-align: center;"><strong>TOTAL</b></b></strong></td>
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
                    <td colspan="3" style="border: 1px solid #000000; padding: 1px 4px; text-align: center;"><strong>
                        <asp:Label ID="lblSubtotalP" runat="server" Font-Bold="False" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td colspan="3" style="border: 1px solid #000000; padding: 1px 4px; text-align: center;"><strong>
                        <asp:Label ID="lblSubtotalK" runat="server" Font-Bold="False" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td colspan="3" style="border: 1px solid #000000; padding: 1px 4px; text-align: center;"><strong>
                        <asp:Label ID="lblSubtotalV" runat="server" Font-Bold="False" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td colspan="3" style="border: 1px solid #000000; padding: 1px 4px; text-align: center;"><strong>
                        <asp:Label ID="lblTotal" runat="server" Font-Bold="False" style="font-size: medium"></asp:Label>
                        </strong></td>
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
                    <td colspan="16" style="text-align: center"><strong><span>
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                        </span></strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                 <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16" style="text-align: center">
                        <strong>
                        <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="grpDatos" Width="120px" />
                        <asp:Button ID="btnLimpiarC" runat="server" class="btn btn-default" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                        </strong>
                        <asp:Button ID="btnEnviar" runat="server" class="btn btn-primary" Text="Enviar" ValidationGroup="grpDatos" Width="120px" OnClick="btnEnviar_Click" />
                        <asp:Button ID="btnAnular" runat="server" class="btn btn-default" Text="Anular" Width="120px" OnClick="btnAnular_Click" Visible="False" />
                        <asp:Button ID="btnListado" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnListado_Click" PostBackUrl="~/Viaticos/ViaticosListado.aspx" Text="Ver Listado" Width="120px" />
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
                        <asp:CheckBoxList ID="chkViaticosSalida" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="chkViaticosSalida_SelectedIndexChanged" RepeatDirection="Horizontal" Visible="False" Width="95%">
                            <asp:ListItem Value="1">Desayuno</asp:ListItem>
                            <asp:ListItem Value="2">Almuerzo</asp:ListItem>
                            <asp:ListItem Value="3">Cena</asp:ListItem>
                            <asp:ListItem Value="4">Hospedaje</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td colspan="8">
                        <asp:CheckBoxList ID="chkViaticosRetorno" runat="server" AutoPostBack="True" OnSelectedIndexChanged="chkViaticosRetorno_SelectedIndexChanged" RepeatDirection="Horizontal" Width="95%" Enabled="False" Visible="False">
                            <asp:ListItem Value="1">Desayuno</asp:ListItem>
                            <asp:ListItem Value="2">Almuerzo</asp:ListItem>
                            <asp:ListItem Value="3">Cena</asp:ListItem>
                            <asp:ListItem Value="4">Hospedaje</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16">
                        <asp:GridView ID="gridDet" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnRowDeleting="gridDet_RowDeleting" OnSelectedIndexChanged="gridDet_SelectedIndexChanged" PageSize="12" Width="100%">
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
                                <asp:BoundField DataField="dia" HeaderText="Cuota por Fracción Día">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha_dia" HeaderText="Fecha">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Desayuno">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("monto_desayuno") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <div class="text-right">
                                            <asp:LinkButton ID="lbDesayuno" runat="server" Text='<%# Bind("monto_desayuno", "Q.{0:0,0.00}") %>' OnClick="lbDesayuno_Click" OnClientClick="javascript:if(!confirm('¿Desea eliminar este desayuno?'))return false"></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Almuerzo">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("monto_almuerzo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbAlmuerzo" runat="server" Text='<%# Bind("monto_almuerzo", "Q.{0:0,0.00}") %>' OnClick="lbAlmuerzo_Click" OnClientClick="javascript:if(!confirm('¿Desea eliminar este almuerzo?'))return false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cena">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("monto_cena") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbCena" runat="server" Text='<%# Bind("monto_cena", "Q.{0:0,0.00}") %>' OnClick="lbCena_Click" OnClientClick="javascript:if(!confirm('¿Desea eliminar esta cena?'))return false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hospedaje">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("monto_hospedaje") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbHospedaje" runat="server" Text='<%# Bind("monto_hospedaje", "Q.{0:0,0.00}") %>' OnClick="lbHospedaje_Click" OnClientClick="javascript:if(!confirm('¿Desea eliminar esta hospedaje?'))return false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="cuota_q" HeaderText="SUBTOTAL" DataFormatString="Q.{0:0,0.00}">
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
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div></div>                  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>





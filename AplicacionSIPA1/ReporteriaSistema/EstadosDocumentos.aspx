<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EstadosDocumentos.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.EstadosDocumentos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>&nbsp;&nbsp;&nbsp;&nbsp; Listado de Tiempos Por documento </h2>
    <div class="col-md-5">
        <asp:Label ID="lblUnidad" runat="server" Text="Unidad"></asp:Label>
        <asp:DropDownList ID="ddlUnidades" runat="server" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" AutoPostBack="True" class="form-control" Width="80%"></asp:DropDownList>
    </div>
    <div class="col-md-5">
        <asp:Label ID="Label1" runat="server" Text="Tipo de Documento"></asp:Label>
        <br />
        <asp:CheckBoxList ID="chkTiposSalida" CssClass="form-control" OnSelectedIndexChanged="chkTiposSalida_SelectedIndexChanged" runat="server"  RepeatDirection="Horizontal" AutoPostBack="True">
            
            <asp:ListItem Selected="True" Value="1">Requisiciones &nbsp;</asp:ListItem>
            <asp:ListItem Selected="True" Value="2">Vales &nbsp;</asp:ListItem>
            <asp:ListItem Selected="True" Value="3">Gastos y Transferencias &nbsp; </asp:ListItem>
            <asp:ListItem Selected="True" Value="4">Viáticos &nbsp;</asp:ListItem>
        </asp:CheckBoxList>
    </div>
    <br />
    <br />
    <div class="col-xs-12" style="width: 100%; height: 100%;">

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="475px">
            <LocalReport ReportPath="Reportes\EstadosDocumentos.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>

        </rsweb:ReportViewer>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT no_solicitud, documento, estadoAnterior, EstadoNuevo, iniciales, fecha_comparacion_anterior, dias, horas, minutos, segundos, usuario_ing, observaciones FROM (SELECT p.no_solicitud, d.documento, ep.nombre_estado AS estadoAnterior, ep2.nombre_estado AS EstadoNuevo, u.iniciales, d.fecha_comparacion_anterior, d.dias, d.horas, d.minutos, d.segundos, d.usuario_ing, d.observaciones FROM sipa_documentos_wkf d INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = d.id_estado_anterior INNER JOIN sipa_estados_pedido ep2 ON ep2.id_estado_pedido = d.id_estado_nuevo INNER JOIN sipa_pedidos p ON p.id_pedido = d.id_documento INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad WHERE (d.id_tipo_documento = 1) UNION ALL SELECT p.no_solicitud, d.documento, ep.nombre_estado AS estadoAnterior, ep2.nombre_estado AS EstadoNuevo, u.iniciales, d.fecha_comparacion_anterior, d.dias, d.horas, d.minutos, d.segundos, d.usuario_ing, d.observaciones FROM sipa_documentos_wkf d INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = d.id_estado_anterior INNER JOIN sipa_estados_pedido ep2 ON ep2.id_estado_pedido = d.id_estado_nuevo INNER JOIN sipa_ccvale p ON p.id_ccvale = d.id_documento INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad WHERE (d.id_tipo_documento = 2) UNION ALL SELECT p.no_solicitud, d.documento, ep.nombre_estado AS estadoAnterior, ep2.nombre_estado AS EstadoNuevo, u.iniciales, d.fecha_comparacion_anterior, d.dias, d.horas, d.minutos, d.segundos, d.usuario_ing, d.observaciones FROM sipa_documentos_wkf d INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = d.id_estado_anterior INNER JOIN sipa_estados_pedido ep2 ON ep2.id_estado_pedido = d.id_estado_nuevo INNER JOIN sipa_gastos p ON p.id_gasto = d.id_documento INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad WHERE (d.id_tipo_documento = 3) UNION ALL SELECT p.no_solicitud, d.documento, ep.nombre_estado AS estadoAnterior, ep2.nombre_estado AS EstadoNuevo, u.iniciales, d.fecha_comparacion_anterior, d.dias, d.horas, d.minutos, d.segundos, d.usuario_ing, d.observaciones FROM sipa_documentos_wkf d INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = d.id_estado_anterior INNER JOIN sipa_estados_pedido ep2 ON ep2.id_estado_pedido = d.id_estado_nuevo INNER JOIN sipa_viaticos p ON p.id_viatico = d.id_documento INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad WHERE (d.id_tipo_documento = 4)) t ORDER BY no_solicitud, documento, fecha_comparacion_anterior"></asp:SqlDataSource>





    </div>
</asp:Content>


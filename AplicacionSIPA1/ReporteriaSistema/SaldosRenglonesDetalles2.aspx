<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="SaldosRenglonesDetalles2.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.SaldosRenglonesDetalles2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h3>&nbsp;&nbsp;&nbsp;&nbsp; Consulta Renglones Presupuestarios Detalle </h3>
    <asp:Label ID="lblPoa" runat="server" Visible="false"></asp:Label>
    <div class="row">
        <div class="col-xs-5">
            <label>Año</label>
            <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" class="form-control" Width="90%"></asp:DropDownList>
        </div>
        <div class="col-xs-6">
            <label>Unidad</label>
            <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" Width="80%"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-7">
            <label>Acciones</label>
            <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" BackColor="#003366" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" class="form-control" ForeColor="White" Width="100%"></asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-5">
            <label>Tipo de Documento</label>
            <br />
            <asp:CheckBoxList ID="chkTiposSalida" runat="server" OnSelectedIndexChanged="chkTiposSalida_SelectedIndexChanged" CssClass="form-control" RepeatDirection="Horizontal" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="1">Requisiciones</asp:ListItem>
                <asp:ListItem Selected="True" Value="2">Vales</asp:ListItem>
                <asp:ListItem Selected="True" Value="3">Gastos y Transferencias</asp:ListItem>
                <asp:ListItem Selected="True" Value="4">Viáticos</asp:ListItem>
            </asp:CheckBoxList>
        </div>
        <div class="col-xs-3">
            <label>Fecha Inicio</label>
            <br />
            <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-xs-3">
            <label>Fecha Final</label>
            <br />
            <asp:TextBox ID="txtFechaFinal" OnTextChanged="txtFechaFinal_TextChanged" AutoPostBack="true" runat="server" TextMode="Date"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-11">
            <label>Estados</label>
            <br />
            <asp:CheckBoxList ID="chkEstados" runat="server" OnSelectedIndexChanged="chkEstados_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True"></asp:CheckBoxList>
        </div>
    </div>
    <br />
    <div class="col-xs-12" style="width: 100%; height: 100%; left: 23px; top: 3px;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1473px">
            <LocalReport ReportPath="Reportes\SaldosRenglonesDet.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT no_solicitud, Año, Accion, Documento, fecha_pedido, Descripcion, Estado, unidad_administrativa, Pedido, costo_estimado, costo_real, no_renglon, no_pac, renglon_pac, anio_solicitud, id_unidad, id_accion, id_tipo_documento, id_estado_pedido, Solicitante, AnalistaPpto, TecnicoCompras FROM (SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.Descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_pedido AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, p.id_pac AS no_pac, da.no_renglon AS renglon_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante, CONCAT(sep.id_empleado, ' - ', sep.nombres) AS AnalistaPpto, CONCAT(sec.id_empleado, ' - ', sec.nombres) AS TecnicoCompras FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_pedido_detalle c ON a.id_pedido = c.id_pedido LEFT OUTER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN sipa_pac p ON p.id_pac = c.id_pac INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante LEFT OUTER JOIN ccl_empleados sep ON sep.id_empleado = a.id_direc_financiera LEFT OUTER JOIN ccl_empleados sec ON sec.id_empleado = a.id_tecnico INNER JOIN sipa_detalles_accion da ON p.id_detalle = da.id_detalle WHERE (a.id_tipo_documento = 1) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_vale AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, 'N/A' AS no_pac, 'N/A' AS renglon_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante, CONCAT(sep.id_empleado, ' - ', sep.nombres) AS AnalistaPpto, CONCAT(sec.id_empleado, ' - ', sec.nombres) AS TecnicoCompras FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_ccvale_detalle c ON a.id_pedido = c.id_ccvale LEFT OUTER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante LEFT OUTER JOIN ccl_empleados sep ON sep.id_empleado = a.id_direc_financiera LEFT OUTER JOIN ccl_empleados sec ON sec.id_empleado = a.id_tecnico WHERE (a.id_tipo_documento = 2) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon, 'N/A' AS no_pac, 'N/A' AS renglon_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante, CONCAT(sep.id_empleado, ' - ', sep.nombres) AS AnalistaPpto, CONCAT(sec.id_empleado, ' - ', sec.nombres) AS TecnicoCompras FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_viaticos c ON a.id_pedido = c.id_viatico LEFT OUTER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico LEFT OUTER JOIN ccl_empleados sep ON sep.id_empleado = a.id_direc_financiera LEFT OUTER JOIN ccl_empleados sec ON sec.id_empleado = a.id_tecnico WHERE (a.id_tipo_documento = 3) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon, 'N/A' AS no_pac, 'N/A' AS renglon_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante, CONCAT(sep.id_empleado, ' - ', sep.nombres) AS AnalistaPpto, CONCAT(sec.id_empleado, ' - ', sec.nombres) AS TecnicoCompras FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_viaticos c ON a.id_pedido = c.id_viatico LEFT OUTER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico LEFT OUTER JOIN ccl_empleados sep ON sep.id_empleado = a.id_direc_financiera LEFT OUTER JOIN ccl_empleados sec ON sec.id_empleado = a.id_tecnico WHERE (a.id_tipo_documento = 4)) t WHERE (id_estado_pedido &gt; 0) ORDER BY id_unidad"></asp:SqlDataSource>
    </div>
</asp:Content>

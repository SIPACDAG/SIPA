<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="AplicacionSIPA1.Inicio" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <div class="col-xs-12">
            <h3  class="text-primary" >¡Bienvenido!</h3>
              <p  class="text-primary" style="font-size: small" >    
                Sistema Integrado de Procesos Administrativos (SIPA) es un sistema creado para el personal de la Confederación Deportiva Autónoma de Guatemala para la Automatizacion de los procesos Administrativos de la Institucion.
              </p>
    
        </div>
      </div>
    <div class="row">
        <div class="col-xs-1">
            <label>Año</label>
            <asp:DropDownList ID="ddlAnios" runat="server" class="form-control"  Width="100%"></asp:DropDownList>
        </div>
        <div class="col-xs-4">
            <label>Unidad</label>
            <asp:DropDownList ID="ddlUnidades" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged"  Width="100%"></asp:DropDownList>
        </div>
         
    </div>
    <br />
    <div class="row">
        <rsweb:ReportViewer ShowToolBar="False" ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="525px" Width="1530px">
            <LocalReport ReportPath="Reportes\dashboard.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource2" Name="DataSet2" />
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource3" Name="DataSet3" />
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource4" Name="DataSet4" />
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource5" Name="DataSet5" />
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource6" Name="DataSet6" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        

        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT g.no_solicitud, p.nombre_estado, u.Unidad FROM sipa_gastos g INNER JOIN sipa_estados_pedido p ON p.id_estado_pedido = g.id_estado_gasto INNER JOIN ccl_unidades u ON u.id_unidad = g.id_unidad"></asp:SqlDataSource>

        

        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_ccvale p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_vale INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad"></asp:SqlDataSource>

        

        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa ON aa.id_accion = d.id_accion WHERE (up.estado_financiero = 1) AND (aa.id_poa = 23)"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT SUM(d.monto) AS monto
        FROM     sipa_detalles_accion d INNER JOIN sipa_acciones aa ON aa.id_accion = d.id_accion INNER JOIN sipa_renglones r ON d.no_renglon = r.No_Renglon INNER JOIN sipa_tipos_financiamiento f ON d.id_tipo_financiamiento = f.id_tipo
        WHERE  (aa.id_poa = 23)
        GROUP BY d.no_renglon"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT v.no_solicitud, ev.nombre_estado, u.id_unidad, u.Unidad, v.id_tipo_viatico FROM sipa_viaticos v INNER JOIN sipa_estados_viaticos ev ON ev.id_estado_viatico = v.id_estado_viatico INNER JOIN ccl_unidades u ON u.id_unidad = v.id_unidad  where v.id_unidad =22"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_pedidos p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_pedido INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad where u.id_unidad =31"></asp:SqlDataSource>
    </div>
    <div class="row">
        <div class="col-xs-6">
            <p class="text-danger">Puede enviar sus solicitudes de apoyo al correo: soporte.sistemas@cdag.com.gt</p>
        </div>
    </div>
</asp:Content>

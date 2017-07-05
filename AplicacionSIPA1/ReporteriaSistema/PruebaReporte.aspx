<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="PruebaReporte.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.PruebaReporte" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
  
           <div class="dropdown">
              <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                Dropdown button
              </button>
              <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                <a class="dropdown-item" href="#">Action</a>
                <a class="dropdown-item" href="#">Another action</a>
                <a class="dropdown-item" href="#">Something else here</a>
              </div>
            </div>
             <br />
             <br />
             <br />
             <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1313px" Height="528px" style="margin-top: 0px">
                 <LocalReport ReportPath="ReporteriaSistema\Report1.rdlc">
                     <DataSources>
                         <rsweb:ReportDataSource DataSourceId="SqlDataSource2" Name="DataSet1" />
                     </DataSources>
                 </LocalReport>
             </rsweb:ReportViewer>
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString.ProviderName %>" 
                 SelectCommand="SELECT 	pu.id_poa id,
			u.iniciales,
			pu.monto,
			pu.anio 
	FROM sipa_poa pu
	INNER JOIN ccl_unidades u ON pu.id_Unidad = u.id_unidad 
	WHERE pu.anio = 2017
	ORDER BY u.Unidad"></asp:SqlDataSource>
           
         
</asp:Content>

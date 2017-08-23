<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmReporte.aspx.cs" Inherits="Reporte.frmReporte" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
    <div>
    </div>

    <div>

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%">
        </rsweb:ReportViewer>

    </div>

    </form>
</body>
</html>

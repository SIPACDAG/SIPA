<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="SaldosPorUnidad.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.SaldosPorUnidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="col-md-5">
        <h2>Saldos de Unidades</h2>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <div class="col-md-10">
        <asp:GridView ID="gridReportes" runat="server"  Width="100%" ShowFooter="True" OnRowDataBound="gridReportes_RowDataBound"
            CssClass="table table-hover table-responsive">
            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
            <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle BackColor="#339933" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </div>
</asp:Content>

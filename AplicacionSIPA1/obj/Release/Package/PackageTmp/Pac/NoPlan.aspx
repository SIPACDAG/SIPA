<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NoPlan.aspx.cs" Inherits="AplicacionSIPA1.Pac.NoPlan" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="jumbotron">
        <div class="container">
            <div class="row">
                <div class="col-md-6" style="left: 23px; top: 3px; width: 592px">
                    <h2 class="success"> PAC NO.
                    <asp:Label ID="lblNoPedido" runat="server" CssClass="text-success"></asp:Label>
                    &nbsp; <asp:Label ID="lblMensaje" runat="server"></asp:Label>  &nbsp;Con exito por un Monto de
                    <asp:Label ID="lblAccion" runat="server" CssClass="text-primary"></asp:Label>
                        .</h2>
                </div>
              
            </div>
            <div class ="row">
                  <div class="col-md-6  ">
                    <asp:Button ID="btnPedido" runat="server" CausesValidation="false" class="btn btn-warning" OnClick="btnPedido_Click" Text="Nuevo Pedido" Width="166px"  />
                    
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
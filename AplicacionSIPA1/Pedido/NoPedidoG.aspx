<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoPedidoG.aspx.cs" Inherits="AplicacionSIPA1.Pedido.NoPedidoG" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="jumbotron">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="success"> <asp:Label ID="lblMensaje" runat="server"></asp:Label>  </h2>
                    <asp:Label ID="lblNoPedido" runat="server" CssClass="text-success"></asp:Label>
                    <asp:Label ID="lblAccion" runat="server" CssClass="text-primary"></asp:Label>
                </div>
              
            </div>
            <div class ="row">
                  <div class="col-md-6  ">
                    <asp:Button ID="btnPedido" runat="server" CausesValidation="false" class="btn btn-warning" OnClick="btnPedido_Click" Text="Nuevo Pedido"  />
                    <asp:Button ID="btnListado" runat="server" CausesValidation ="false" class="btn btn-info" OnClick="btnListado_Click" Text="Ver Listado"  />
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>

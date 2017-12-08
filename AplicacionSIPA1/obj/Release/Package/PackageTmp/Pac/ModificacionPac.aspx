<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ModificacionPac.aspx.cs" Inherits="AplicacionSIPA1.Pac.ModificacionPac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/Content/bootstrap.css" rel="stylesheet" media="screen" />
    <script src="../Scripts/bootstrap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2 style="text-align: center">Regularizacion PAC</h2>
    <div class="row">
        <div class="col-xs-1">
            <label>Año</label>
            <asp:DropDownList ID="ddlAnio" runat="server" CssClass="form-control" Width="85%"></asp:DropDownList>
        </div>
        <div class="col-xs-4">
            <label>Unidad</label>
            <asp:DropDownList ID="ddlUnidad" runat="server" CssClass="form-control" Width="90%"></asp:DropDownList>
        </div>
        <div class="col-xs-2">
            <label>No. de Documento</label>
            <asp:TextBox ID="txtNo" runat="server" BackColor="#FFFF99" class="form-control" Font-Bold="True"></asp:TextBox>
        </div>
        <div class="col-xs-3">
            <br />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-info" />
        </div>
    </div>
    <div class="row">
        <div class="col-xs-4">
            <label>Dependencia</label>
            <asp:DropDownList ID="ddlDependencia" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
        </div>
        <div class="col-xs-4">
            <label>Jefatura/Unidad</label>
            <asp:DropDownList ID="ddlJefatura" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <br />
        &nbsp;<label class="label label-default">&nbsp;&nbsp; &nbsp;&nbsp; En esta pantalla unicamente se mostraran los estados 8:Impreso, 10:Realizando Gestion de Compras y 12:Liquidado</label>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-11">
            <div class="panel panel-default">
                <div class="panel-heading">PAC</div>
                <div class="panel-body">
                    <asp:DetailsView ID="dvPedido" runat="server" RowStyle-BorderColor="Black" RowStyle-BackColor="#18bc9c" AlternatingRowStyle-BackColor="White" RowStyle-CssClass="table-bordered" AllowPaging="True" Width="100%" CssClass="table table-hover table-responsive">
                    </asp:DetailsView>
                    <asp:GridView ID="gvPedido" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="modal-header alert-info" RowStyle-BorderColor="Black" CssClass="table table-responsive table-bordered" DataKeyNames="monto"
                        OnSelectedIndexChanged="gvPedido_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="Solicitud" HeaderText="Solicitud" Visible="true"></asp:BoundField>
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="true"></asp:BoundField>
                            <asp:BoundField DataField="Monto" HeaderText="Monto" Visible="true"></asp:BoundField>
                            <asp:BoundField DataField="PAC" HeaderText="PAC" Visible="true"></asp:BoundField>
                            <asp:BoundField DataField="No. Renglon PAC" HeaderText="No. Renglon PAC" Visible="true"></asp:BoundField>
                            <asp:BoundField DataField="No. Renglon Ppto" HeaderText="No. Renglon Ppto" Visible="true"></asp:BoundField>
                            <asp:TemplateField HeaderText="Nuevo PAC">
                                <ItemTemplate>
                                    <div class="text-center">
                                        <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True"></asp:TextBox>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False" Visible="true">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" ImageUrl="~/img/24_bits/edit.png" Text="Editar" />
                                    <asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="~/img/24_bits/save.png" Text="Guardar" />
                                </ItemTemplate>
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="tabla_listado" runat="server" Width="100%">

                    </asp:GridView>
                    <asp:Table runat="server" ID="tabla_pedido" Width="100%" GridLines="Both" CssClass="table-striped table" on>
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Requisicion</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Descripción</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Monto</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">PAC</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">No. Renglon PAC</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">No. Renglon Ppto</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Nuevo PAC</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Acciones</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>


                </div>
            </div>
        </div>
    </div>
</asp:Content>


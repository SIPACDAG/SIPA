<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearPedido.aspx.cs" Inherits="AplicacionSIPA1.Pedido.CrearPedido" MasterPageFile="../Principal.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style3 {
        }

        .auto-style4 {
            width: 25%;
        }

        .auto-style16 {
            width: 25%;
            height: 16px;
            background-color: #2C3E50;
        }
        .auto-style17 {
            height: 16px;
            background-color: #2C3E50;
        }
        .auto-style18 {
            text-align: center;
            font-size: x-large;
            color: #FFFFFF;
            background-color: #2C3E50;
        }
        .auto-style19 {
            font-size: large;
        }
        .auto-style20 {
            width: 249px;
            height: 70px;
        }
        .auto-style21 {
            font-size: large;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                           <table style="width:80%;">
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style4"></td>
                                <td class="auto-style12">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                               <tr>
                                   <td class="auto-style18" colspan="4"><strong>Crear Pedido</strong></td>
                               </tr>
                               <tr>
                                   <td class="auto-style3" colspan="4"><strong><span class="auto-style19">Acci<span>ó</span>n</span></strong><asp:DropDownList ID="dropAccion" runat="server" class="form-control" Width="99%" AutoPostBack="True" OnSelectedIndexChanged="dropAccion_SelectedIndexChanged">
                                       </asp:DropDownList>
                                   </td>
                               </tr>
                            <tr>
                                <td class="auto-style3">Solicitante</td>
                                <td class="auto-style4">
                                    <asp:DropDownList ID="dropSolicitante" runat="server" class="form-control" Width="98%">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style12">Jefe Direccion</td>
                                <td>
                                    <asp:DropDownList ID="dropJefeDir" runat="server" class="form-control" Width="98%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                               <tr>
                                   <td class="auto-style3">Pedido a:</td>
                                   <td class="auto-style4">
                                       <asp:DropDownList ID="dropTipoGasto" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="dropTipoGasto_SelectedIndexChanged" Width="98%">
                                       </asp:DropDownList>
                                   </td>
                                   <td class="auto-style12">FADN</td>
                                   <td>
                                       <asp:DropDownList ID="dropFand" runat="server" class="form-control" Enabled="False" Width="98%">
                                       </asp:DropDownList>
                                   </td>
                               </tr>
                               <tr>
                                   <td class="auto-style3" colspan="4">Justificacion<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtJustificacion" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                                       <asp:TextBox ID="txtJustificacion" runat="server" class="form-control" MaxLength="500" placeholder="Justificacion" TextMode="MultiLine" Width="95%"></asp:TextBox>
                                   </td>
                               </tr>
                               <tr>
                                   <td class="auto-style3">Tipo de Pedido</td>
                                   <td class="auto-style4">
                                       <asp:DropDownList ID="dropTipoPedido" runat="server" class="form-control" Width="98%" AutoPostBack="True" OnSelectedIndexChanged="dropTipoPedido_SelectedIndexChanged">
                                       </asp:DropDownList>
                                   </td>
                                   <td class="auto-style12">&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td class="auto-style17">&nbsp;</td>
                                   <td class="auto-style16"></td>
                                   <td class="auto-style17"></td>
                                   <td class="auto-style17"></td>
                               </tr>
                               <tr>
                                   <td class="auto-style3" colspan="4"><span class="auto-style21">NoPac:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Saldo Pac:<asp:Label ID="lblSaldoPac" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#006600">0</asp:Label>
                                       </span><asp:DropDownList ID="dropNoPac" runat="server" class="form-control" Width="99%" AutoPostBack="True" OnSelectedIndexChanged="dropNoPac_SelectedIndexChanged">
                                       </asp:DropDownList>
                                   </td>
                               </tr>
                               <tr>
                                   <td class="auto-style3"><strong>Cantidad<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCantidad" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vaciosD"></asp:RequiredFieldValidator>
                                       <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Solo Numeros" Font-Bold="True" ForeColor="Red" MaximumValue="100000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                       </strong></td>
                                   <td class="auto-style4">
                                       <asp:TextBox ID="txtCantidad" runat="server" class="form-control" ForeColor="Black" MaxLength="10" placeholder="Cantidad" TextMode="Number" Width="40%"></asp:TextBox>
                                   </td>
                                   <td class="auto-style3"><strong>Unidad Medida</strong></td>
                                   <td class="auto-style4">
                                       <asp:DropDownList ID="dropUnidadMedida" runat="server" class="form-control" Width="98%">
                                       </asp:DropDownList>
                                   </td>
                               </tr>
                               <tr>
                                   <td class="auto-style3" colspan="4"><strong>Descripcion<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vaciosD"></asp:RequiredFieldValidator>
                                       <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" MaxLength="1000" placeholder="Descripcion del Pedido" TextMode="MultiLine" Width="99%"></asp:TextBox>
                                       </strong></td>
                               </tr>
                               <tr>
                                   <td class="auto-style3"><strong>Costo Estimado Total<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCosto" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vaciosD"></asp:RequiredFieldValidator>
                                       <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtCosto" ErrorMessage="Solo Numeros" Font-Bold="True" ForeColor="Red" MaximumValue="300000000" MinimumValue="0.01" Type="Double"></asp:RangeValidator>
                                       </strong></td>
                                   <td class="auto-style4">
                                       <asp:TextBox ID="txtCosto" runat="server" class="form-control" MaxLength="12" placeholder="Costo Estimado Total" Width="70%" ForeColor="Black"></asp:TextBox>
                                   </td>
                                   <td class="auto-style3">
                                       <asp:Button ID="btnAgregar" runat="server" BackColor="#009933" class="btn btn-primary" OnClick="btnAgregar_Click" Text="Agregar" Width="142px" />
                                   </td>
                                   <td class="auto-style4">&nbsp;</td>
                               </tr>
                               <tr>
                                   <td class="auto-style3" colspan="4">
                                       <asp:GridView ID="gridArticulos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="5" ShowFooter="True" Width="65%" OnRowDataBound="gridArticulos_RowDataBound" OnSelectedIndexChanged="gridArticulos_SelectedIndexChanged" OnRowDeleting="gridArticulos_RowDeleting">
                                           <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                           <Columns>
                                               <asp:TemplateField ShowHeader="False">
                                                   <ItemTemplate>
                                                       <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/delete.png" onclientclick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Eliminar" />
                                                   </ItemTemplate>
                                                   <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                   <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:TemplateField>
                                               <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                               <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:BoundField>
                                               <asp:BoundField DataField="UnidadMedida" HeaderText="Medida">
                                               <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:BoundField>
                                               <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                               <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:BoundField>
                                               <asp:BoundField DataField="Costo" HeaderText="Costo">
                                               <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:BoundField>
                                           </Columns>
                                           <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                           <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                           <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                           <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                       </asp:GridView>
                                   </td>
                               </tr>
                               <tr>
                                   <td class="auto-style19" colspan="4">
                                       <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                           <ProgressTemplate>
                                               <img alt="Cargando" class="auto-style20" longdesc="Imagen de Cargando" src="../img/cargarCOG.gif" />
                                           </ProgressTemplate>
                                       </asp:UpdateProgress>
                                    <span class="label label-danger"><asp:Label ID="lblError" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span>
                    <span class="label label-success"><asp:Label ID="lblSuccess" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span> </td>
                               </tr>
                               <tr>
                                   <td class="auto-style3">&nbsp;</td>
                                   <td class="auto-style4">
                                       <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="GUARDAR" Width="142px" />
                                       <asp:Button ID="btnCancelar" runat="server" class="btn btn-default" Text="CANCELAR" PostBackUrl="~/Inicio.aspx" />
                                   </td>
                                   <td class="auto-style3">&nbsp;</td>
                                   <td class="auto-style4">&nbsp;</td>
                               </tr>
                        </table>
              
                        </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Content>




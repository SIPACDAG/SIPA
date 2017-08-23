<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="AplicacionSIPA1.Usuario.ModificarUsuario" MasterPageFile="~/Principal.Master" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style3 {
            width: 15%;
        }

        .auto-style4 {
            width: 25%;
        }

        .auto-style11 {
            text-align: center;
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                           <table style="width:100%;">
                            <tr>
                                <td><strong>
                                    <br />
                                    Modificar Usuario</strong></td>
                            </tr>
                               <tr>
                                   <td>
                                       <asp:GridView ID="gridUsuario" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnSelectedIndexChanged="gridUsuario_SelectedIndexChanged" PageSize="5" Width="65%" OnRowDeleting="gridUsuario_RowDeleting" OnPageIndexChanging="gridUsuario_PageIndexChanging">
                                           <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                           <Columns>
                                               <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True">
                                               <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:CommandField>
                                               <asp:TemplateField ShowHeader="False">
                                                   <ItemTemplate>
                                                       <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/delete.png" onclientclick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Eliminar" />
                                                   </ItemTemplate>
                                                   <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                   <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:TemplateField>
                                               <asp:BoundField DataField="ID" HeaderText="ID">
                                               <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:BoundField>
                                               <asp:BoundField DataField="Usuario" HeaderText="Usuario">
                                               <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:BoundField>
                                               <asp:BoundField DataField="Empleado" HeaderText="Empleado">
                                               <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:BoundField>
                                               <asp:CheckBoxField DataField="Habilitado" HeaderText="Activo">
                                               <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:CheckBoxField>
                                           </Columns>
                                           <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                           <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                           <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                           <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                       </asp:GridView>
                                   </td>
                               </tr>
                        </table>
              
                        <table style="width:80%;" >
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11" colspan="4"><strong>Modificar Usuario</strong></td>
                </tr>
                <tr>
                    <td class="auto-style3">Empleado:</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="ddlEmpleados" runat="server" class="form-control" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style12">Usuario<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="text_usuario" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="text_usuario" runat="server" class="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Contraseña</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextPass_Nuevo" runat="server" class="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style12">Confirmar</td>
                    <td>
                        <asp:TextBox ID="TextPass_Confirmar" runat="server" class="form-control" placeholder="Confirmar Contraseña" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Activo</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="dropActivo" runat="server" class="form-control" Width="40%">
                            <asp:ListItem Value="1">Si</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        <span class="label label-danger"><asp:Label ID="lblError" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span>
                    <span class="label label-success"><asp:Label ID="lblSuccess" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span>      
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Modificar" Width="142px" ValidationGroup="vacios" />
                        <asp:Button ID="btnCancelar" runat="server" class="btn btn-default" OnClick="btnCancelar_Click" Text="CANCELAR" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
            </table>
                        </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Content>




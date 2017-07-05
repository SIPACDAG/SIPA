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
        .auto-style12 {
            width: 31%;
        }
        .auto-style13 {
            width: 27%;
        }
        .auto-style15 {
            width: 161px;
        }
        .auto-style16 {
            color: #006699;
        }
        .auto-style17 {
            width: 15%;
            font-weight: bold;
            color: #006699;
            text-align: right;
        }
        .auto-style18 {
            width: 31%;
            font-weight: bold;
            height: 41px;
            text-align: right;
        }
        .auto-style19 {
            width: 31%;
            font-weight: bold;
            color: #006699;
            text-align: right;
        }
        .auto-style20 {
            width: 15%;
            font-weight: bold;
            color: #006699;
            text-align: right;
            height: 41px;
        }
        .auto-style21 {
            width: 27%;
            height: 41px;
        }
        .auto-style22 {
            height: 41px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                           <table style="width:100%; margin-left: auto; margin-right: auto;" >
                            <tr>
                                <td class="auto-style15" style="font:40" colspan="2"><strong class="text-info">
                                    &nbsp;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style16">&nbsp;Modificar Usuario</span></h3>
                                    </strong></h3>
                                </td>
                            </tr>
                               <tr>
                                   <td class="auto-style15">
                                       <br />
                                   </td>
                                   <td>
                                       <asp:GridView ID="gridUsuario" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" CssClass="table table-hover table-responsive" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" Height="305px" HorizontalAlign="Center" OnPageIndexChanging="gridUsuario_PageIndexChanging" OnRowDeleting="gridUsuario_RowDeleting" OnSelectedIndexChanged="gridUsuario_SelectedIndexChanged" PageSize="5" Width="74%">
                                           <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                           <Columns>
                                               <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True">
                                               <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:CommandField>
                                               <asp:TemplateField ShowHeader="False">
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
                    <td class="auto-style13">
                        
                        &nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11" colspan="4"><strong>Modificar Usuario</strong></td>
                </tr>
                <tr>
                    <td class="auto-style20">Empleado:&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style21">
                        <asp:DropDownList ID="ddlEmpleados" runat="server" class="form-control" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style18"><span class="auto-style16">Usuario</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="text_usuario" ErrorMessage="*" ForeColor="Red" ValidationGroup="vacios" CssClass="auto-style16"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="auto-style22">
                        <asp:TextBox ID="text_usuario" runat="server" class="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">Contraseña&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style13">
                        <asp:TextBox ID="TextPass_Nuevo" runat="server" class="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style19">Confirmar&nbsp;&nbsp;&nbsp; </td>
                    <td>
                        <asp:TextBox ID="TextPass_Confirmar" runat="server" class="form-control" placeholder="Confirmar Contraseña" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">Activo&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style13">
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
                    <td class="auto-style13">
                        <span class="label label-danger"><asp:Label ID="lblError" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span>
                    <span class="label label-success"><asp:Label ID="lblSuccess" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span>      
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style13">
                        <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" OnClick="btnGuardar_Click" Text="Modificar" Width="142px" ValidationGroup="vacios" />
                        <asp:Button ID="btnCancelar" runat="server" class="btn btn-danger" OnClick="btnCancelar_Click" Text="CANCELAR" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
            </table>
                        </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Content>




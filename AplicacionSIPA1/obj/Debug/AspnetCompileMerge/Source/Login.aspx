<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AplicacionSIPA1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>Login</title>

    <link href="css/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="css/utilities.css" rel="stylesheet" type="text/css" media="screen" />
 
    <style type="text/css">

        .style11
        {
            /*border-style: inherit;
            border-color: inherit;
            border-width: medium;*/
            width: 22px;
            height: 300px;
            /*background: #EFEFEF url(imagenesM/blue_gradiente.jpg) fixed center;*/
        }
        
        

        .style23
        {
          
        }


        .auto-style1 {
            font-size: x-large;
            font-weight: normal;
            color: #FFFFFF;
            text-align: left;
        }


        .auto-style2 {
            width: 280px;
            text-align: left;
            font-weight: 700;
        }
        .auto-style7 {
            width: 280px;
            height: 8px;
            font-weight: normal;
        }
        

        .auto-style9 {
        }


        .auto-style10 {
            color: #FFFFFF;
        }
        

        </style>
    
     <script type="text/javascript">
         if (window.history) {
             function noBack() { window.history.forward() }
             noBack();
             window.onload = noBack;
             window.onpageshow = function (evt) { if (evt.persisted) noBack() }
             window.onunload = function () { void (0) }
         }
        </script>


  </head>
  
 
    <body id="body2">
        
            <form id="form1" runat="server">

        <br />
        <br />
        <br />

    <div id="two-columns2"">

		<div id="col1">
									
            <table align="center" class="style11">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" valign="bottom">
                        <asp:TextBox ID="TextUsuario" runat="server" BorderStyle="None" CssClass=" InputUsuario " placeholder="Usuario" Style="font-size: large; text-align: left;" Height="40px" Width="244px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7" valign="top">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextContraseña" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="InputUsuario" Style="font-size: large; text-align: left;" BorderStyle="None" Height="40px" Width="244px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Button ID="btniniciar" runat="server" CssClass="button" Text="Iniciar Sesión" OnClick="btniniciar_Click" Height="40px" Width="244px" />
                    </td>
                </tr>
                <tr>
                    <td class="style23" style="text-align: left">
                        <asp:Label ID="resultado" runat="server" ForeColor="#dddddd" style="color: #CC0000"></asp:Label>
                    </td>
                </tr>
            </table>
			
						
		</div>

		<div id="col2" style="padding:0px 50px 0px 50px">
	        
            <div id="DivContenedorMenu_EW2" > 
                <asp:Image ID="Image1" runat="server" Height="334px" ImageUrl="~/css/Fondos/logoCdag.png" Width="280px" />
                </div>
  </div>
	</div>
            

        <div id="welcome">
    
           
       
            <br />

            <br />
            <br />

        </div>
        <footer id="#footer p" style="text-align: center" class="auto-style10">

            Todos los Derechos Reservados CDAG, Guatemala 2,016</footer>
                    </form>


            </body>



</html>

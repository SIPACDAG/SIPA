<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoPlan.aspx.cs" Inherits="AplicacionSIPA1.PacInsumos.NoPlan" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Comite Olimpico Guatemalteco</title>


    <script type="text/javascript">


        if (window.history) {
            function noBack() { window.history.forward() }
            noBack();
            window.onload = noBack;
            window.onpageshow = function (evt)
            { if (evt.persisted) noBack() }
            window.onunload = function () { void (0) }
        }
    </script>


    <link href="~/css/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="~/css/utilities.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="~/Content/bootstrap.css" rel="stylesheet" media="screen" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.dropotron-1.0.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.slidertron-1.1.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.js" type="text/javascript"></script>

    $(function () {
        $('#menu > ul').dropotron({
            mode: 'fade',
            globalOffsetY: 11,
            offsetY: -15
        });

        $('#slider').slidertron({
            viewerSelector: '.viewer',
            indicatorSelector: '.indicator span',
            reelSelector: '.reel',
            slidesSelector: '.slide',
            speed: 'slow',
            advanceDelay: 4000
        });
    });
</script>

   

    <style type="text/css">
        .auto-style11 {
            font-size: xx-large;
            font-family: Arial;
            font-weight: normal;
        }

        .auto-style12 {
            color: #008000;
        }
    </style>
</head>
<body>
    <form class="form-horizontal" id ="form1" runat="server">
       
 
<nav class="navbar  navbar-default navbar-fixed-top" role="navigation">

<div class="container-header" >

<div class="navbar-collapse collapse navbar-responsive-collapse in" >


        <div id="DivContenedorMenu_EW" > 
            <asp:Menu ID="Menu1" runat="server" style="color: #FFFFFF" MaximumDynamicDisplayLevels="10" Orientation="Horizontal" Font-Bold="True" CssClass="menu_EW" >
                <DynamicSelectedStyle Font-Bold="False" />
            </asp:Menu>
        </div>


 </div>
        </div>


                <div style="text-align: right">
                    <span class="label label-success"> 
                         Usuario: 
                         <asp:Label ID="lblUsuario" runat="server" style="text-align: center;"></asp:Label>
                     </span>
                    &nbsp;
                     <span class="label label-default"> 
                          <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="INICIAR SESIÓN" LogoutText="CERRAR SESIÓN" Font-Bold="True" ForeColor="Black"  />
                     </span>
                    </div>
 
        </nav>

         <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
         </div>    

         <br /><br /><br /><br /><br />


        <p class="auto-style11">
            <span class="auto-style12">
&nbsp;Pac No. </span>
            <asp:Label ID="lblNoPedido" runat="server" CssClass="auto-style12" ForeColor="#000099" Text="0"></asp:Label>
            &nbsp;<span class="auto-style12"><asp:Label ID="lblMensaje" runat="server"></asp:Label>
&nbsp;con Exito, por un Monto de:
            <asp:Label ID="lblMonto" runat="server" ForeColor="#FF9900"></asp:Label>
            </span></p>
        <p>
                        <asp:Button ID="btnVerListado" runat="server" class="btn btn-primary" OnClick="btnVerListado_Click" Text="Ver Listado" Width="120px" />
        </p>
        <p>
                        <asp:Button ID="btnLimpiarC" runat="server" class="btn btn-default" Text="Nuevo" Width="120px" PostBackUrl="~/Pac/IngresarPac.aspx" />
        </p>
        <p>
            &nbsp;</p>


        </form>

</body>


</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="AplicacionSIPA1.Inicio" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <br />

    <div class="jumbotron">
        <div class="container">
        <h1 style="font-size: large">¡Bienvenido!</h1>
        <p class="text-primary" style="font-size: medium" >Sistema Integrado de Procesos Administrativos (SIPA) es un sistema creado para el personal de la Confederación Deportiva Autónoma de Guatemala
            para la Automatizacion de los procesos Administrativos de la Institucion.
        </p>
            <p class="text-primary" style="font-size: 12pt; color: #FF3300; text-align: center" >
                <strong>IMPORTANTE: A todos los usuarios del módulo de Viáticos se les informa que a partir de la fecha, la impresión del formulario de viáticos se debe realizar cuando se encuentra en estado: 6 - Aprobado Nivel II, para obtener firmas respectivas y presentarlo a la Unidad de Viáticos para su revisión en el sistema SIPA.</strong></p>
            <p class="text-primary" style="font-size: 12pt; color: #FF3300; text-align: center" >
                p<strong>uede consultar las presentaciones de la capacitación haciendo clic 
                <asp:HyperLink ID="hlPresentaciones" target="_blank" runat="server" NavigateUrl="http://192.9.200.247/manuales/index.php/SUBGERENCIA%20DE%20DESARROLLO%20INSTITUCIONAL/INNOVACI%C3%93N%20Y%20TECNOLOG%C3%8DA/SIPA/detail" ToolTip="Abrirá una nueva pestaña">aquí</asp:HyperLink><br />
                Puede acceder al sistema de forma externa a las oficinas de CDAG en la siguiente dirección: http://190.106.208.4/CDAGSIPA
            <br />
                Puede enviar sus solicitudes de apoyo al correo: soporte.sistemas@cdag.com.gt                                                                                      
            </strong></p>
            <p><a class="btn btn-primary btn-lg" href="#" role="button">Leer más</a></p>
        
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>


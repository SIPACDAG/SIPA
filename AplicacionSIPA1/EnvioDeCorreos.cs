using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace AplicacionSIPA1
{
    public class EnvioDeCorreos
    {
        public void EnvioCorreo(string correo_enviar, string encabezado, string cuerpo)
        {
            try
            {
                string prueba = "esta es una prueba";
                SmtpClient cliente = new SmtpClient("smtp.office365.com");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("soporte.sistemas@cdag.com.gt", "Soporte SIPA", System.Text.Encoding.UTF8);
                mail.Subject = encabezado;
                mail.Body = cuerpo + " \n  \n SIPA - 2017 GUATEMALA SOPORTE TECNICO.";
                mail.To.Add(correo_enviar);
                string prueba2;
                cliente.Port = 587;
                cliente.Credentials = new System.Net.NetworkCredential("soporte.sistemas@cdag.com.gt", "sistemas2017*");
                cliente.EnableSsl = true;
                cliente.Send(mail);
                cliente.Dispose();
                mail.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
    }
}
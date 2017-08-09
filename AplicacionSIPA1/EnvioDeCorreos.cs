using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace AplicacionSIPA1
{
    public class EnvioDeCorreos
    {
        public void EnvioCorreo(string correo_enviar, string encabezado, string cuerpo,string persona)
        {
            try
            {
                
                SmtpClient cliente = new SmtpClient("smtp.office365.com");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("soporte.sistemas@cdag.com.gt", "Soporte SIPA", System.Text.Encoding.UTF8);
                mail.Subject = " MENSAJE DE ALERTA -SIPA-" + encabezado;
                mail.Body = "Tiene un documento, "+cuerpo + ". Realizado por "+persona+" Que necestia su Atencion \n Atentamente  \n \n \n Sistema Integrado de Procesos Administrativos -SIPA-.";
                mail.To.Add(correo_enviar);
                
                cliente.Port = 587;
                cliente.Credentials = new System.Net.NetworkCredential("soporte.sistemas@cdag.com.gt", "sistemascdag17*");
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
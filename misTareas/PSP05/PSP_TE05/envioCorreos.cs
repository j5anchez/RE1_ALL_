using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.Windows.Forms;
using System.IO;
namespace Correos
{
    public class envioCorreos
    {

        public void envioEmail(string usuario, string correo)
        {
            try
            {
                MailMessage mensaje = new MailMessage("pepitopiscinascooperativa@gmail.com", correo, "Clave Privada", "Clave de acceso a contraseñas en el gestor de password.");
                Attachment data = new Attachment(@"..\..\privatekeys\" + usuario + "_private.xml", MediaTypeNames.Application.Octet);
                mensaje.Attachments.Add(data);
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("pepitopiscinascooperativa@gmail.com", "PSP04JSR"),
                    EnableSsl = true,


                };


                smtp.Send(mensaje);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido mandar el correo."); Console.WriteLine(ex.ToString());
            }




        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace clienteFTP
{
    public class manipuladorCliente
    {

        public void descargaFicheros(string user, string pwd, string url, string seleccionDescarga, string pathDescarga)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + user + ":" + pwd + "@" + url + "/" + seleccionDescarga);
            request.Credentials = new NetworkCredential(user, pwd);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string arreglado = pathDescarga;

            using (FileStream writer = new FileStream(pathDescarga + "\\" + seleccionDescarga, FileMode.Create))
            {

                long length = response.ContentLength;
                int bufferSize = 32768;
                int readCount;
                byte[] buffer = new byte[32768];

                readCount = responseStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    writer.Write(buffer, 0, readCount);
                    readCount = responseStream.Read(buffer, 0, bufferSize);
                }
            }

            reader.Close();
            response.Close();
        }

        public void subirFicheros(string user, string pwd, string url, string path, string nombreFicheroSubida)
        {
            string nombreFichero = Path.GetFileName(path);
            string urlSubida;
            if (nombreFicheroSubida.Length > 0)
                urlSubida = "ftp://" + url + "//" + nombreFicheroSubida;
            else
                urlSubida = "ftp://" + url + "//" + nombreFichero;

            var request = (FtpWebRequest)WebRequest.Create(urlSubida);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(user, pwd);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (var fileStream = File.OpenRead(path))
            {
                using (var requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                    requestStream.Close();
                }
            }

            var response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }


        public void enviarEmailSubida(string emailSubida, string seleccionSubida, string url)
        {

            string nombre = string.Empty;
            for (int i = 0; i < emailSubida.Length; i++)
            {
                if (emailSubida[i] == '@')
                    break;

                nombre += emailSubida[i];
            }

            MailAddress origen = new MailAddress("pepitopiscinascooperativa@gmail.com", "Pepito Piscinas Coop.");

            MailAddress destino = new MailAddress(emailSubida, nombre);

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(origen.Address, "PSP04JSR"),
                EnableSsl = true
            };




            using (MailMessage mensaje = new MailMessage(origen, destino)
            {
                Subject = "Confirmación Subida Fichero",
                Body = "Su fichero " + seleccionSubida + " se ha subido a " + url,
            })

                try
                {
                    smtp.Send(mensaje);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

        }

        public void enviarEmailDescarga(string emailDescarga, string seleccionDescarga, string url)
        {

            string nombre = string.Empty;
            for (int i = 0; i < emailDescarga.Length; i++)
            {
                if (emailDescarga[i] == '@')
                    break;

                nombre += emailDescarga[i];
            }

            MailAddress origen = new MailAddress("pepitopiscinascooperativa@gmail.com", "Pepito Piscinas Coop.");

            MailAddress destino = new MailAddress(emailDescarga, nombre);

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(origen.Address, "PSP04JSR"),
                EnableSsl = true
            };




            using (MailMessage mensaje = new MailMessage(origen, destino)
            {
                Subject = "Confirmación Descarga Fichero",
                Body = "Su fichero " + seleccionDescarga + " se ha descargado desde " + url,
            })

                try
                {
                    smtp.Send(mensaje);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }



        }

    }
}

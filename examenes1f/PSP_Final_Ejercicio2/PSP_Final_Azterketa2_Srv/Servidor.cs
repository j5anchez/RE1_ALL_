using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace CompartirImagen
{
  
    public class TCPServidor
    {

        private TcpClient socketcliente = null;
        NetworkStream network = null;
        StreamReader reader = null;
        StreamWriter writer = null;

        private string nombrefichkey = string.Empty; //Nombre de fichero local, donde guardará el contenido del la clave recibida vía FTP
        private string nombrefichIV = string.Empty; //Nombre de fichero local, donde guardará el contenido del la key recibida vía FTP
        private string fichero = string.Empty; //Nombre de fichero local, donde se guardará el contenido de la imagen cifrada. Recibida vía TCP/IP
        private string IPFTPServer = string.Empty; //Dirección IP del servidor FTP
        private string FTPUser = string.Empty; //Nombre de usuario del servidor FTP
        private string FTPPassword = string.Empty; //Password en texto plano del servidor FTP.
        private string IPServerTCP = string.Empty; //IP del servidor TCPIP
        private Int32 ServerPortTCP = Int32.MaxValue; //Puerto TCPIP del servidor


        public int num = 15;
        private Object o = new object();
        private Aes objAES = null;
        private byte[] bytextoCifrado;



        public static int Main(String[] args)
        {


            TCPServidor appserver = new TCPServidor("key.txt", "IV.txt", "imagen.txt", "ftps4.us.freehostia.com", "asfasf392", "w23w4SHYl", "127.0.0.1", 13000);
            appserver.Connect();
            appserver.GestionDatos();
            appserver.Cerrar();

            return 0;
        }
        public TCPServidor(string fichkey, string fichIV, string ficherotexto, string IPdir, string FTPUse, string FTPPass, string IPServTCP, Int32 ServPortTCP)
        {
            //Inicializa los atributos
            this.nombrefichkey = fichkey;
            this.nombrefichIV = fichIV;
            this.fichero = ficherotexto;
            this.IPFTPServer = IPdir;
            this.FTPUser = FTPUse;
            this.FTPPassword = FTPPass;
            this.IPServerTCP = IPServTCP;
            this.ServerPortTCP = ServPortTCP;
        }

        private void Connect()
        {

            
            //A COMPLETAR************************************************************************************************************************************************************************************
        }

        private void Cerrar()
        {
            socketcliente.Close();
            network.Close();
            reader.Close();
            Console.WriteLine("Fin de la transmisión por parte del servidor.");

        }


        private void GestionDatos()
        {
          
            string data = string.Empty;

            try
            {

                    //A COMPLETAR******************************************************************************************************************************************************************************
                    string imagen = CrearImagen(data);

                    this.objAES = Aes.Create();

                    StringAFichero(Convert.ToBase64String(objAES.Key), this.nombrefichkey);
                    StringAFichero(Convert.ToBase64String(objAES.IV), this.nombrefichIV);
                                        
                    EncriptarTextoAFichero(imagen, objAES.Key, objAES.IV);

                    EnviarTexto();

                    subirFTP(nombrefichkey, IPFTPServer, FTPUser, FTPPassword);
                    subirFTP(nombrefichIV, IPFTPServer, FTPUser, FTPPassword);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
          
        }


        private string CrearImagen(string data)
        {

            int num = Int32.Parse(data);
            string imagen = string.Empty;

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    imagen += "*";
                }
                imagen += "\n";
            }
            Console.Write(imagen);
            return imagen;
        }

        public void EnviarTexto()
        {
            FileInfo fileinfo = new FileInfo(this.fichero);
            long tamano = fileinfo.Length;

            byte[] bytes = Encoding.ASCII.GetBytes(Convert.ToString(tamano));
            byte[] bytesdato = new byte[1024];
            network.Write(bytes, 0, bytes.Length);

            try
            {
                int bytesReadTotal = 0;
                using (FileStream fs = File.OpenRead(this.fichero))
                {
                    while (bytesReadTotal < tamano)
                    {
                        int bytesRead = fs.Read(bytesdato, 0, bytesdato.Length);
                        network.Write(bytesdato, 0, bytesRead);             
                        bytesReadTotal += bytesRead;
                    }

                };
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Fichero no encontrado: {0}", e.Message);
            }
        }

        public void StringAFichero(string str, string nomfich)
        {
            using (StreamWriter swwr = new StreamWriter(nomfich))
            {
                swwr.WriteLine(str);
            }
        }

        public  void EncriptarTextoAFichero(String Data,  byte[] Key, byte[] IV)
        {

            try
            {
                using (FileStream fstream = File.Open(this.fichero, FileMode.Create))
                {
                    using (Aes Aesalg = Aes.Create())
                    {

                        var ojb = Aesalg.CreateEncryptor(Key, IV);
                        using (CryptoStream cStream = new CryptoStream(fstream, ojb, CryptoStreamMode.Write))
                        {
                            using (StreamWriter sWriter = new StreamWriter(cStream))
                            {
                                sWriter.Write(Data);
                            }
                        }

                    }
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Error criptofráfico: {0}", e.Message);
              
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Error de acceso a fichero: {0}", ex.Message);
              
            }

        }

        public void subirFTP(string fich, string IP, string strUser, string strPassword)
        {

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + IP + "/" + fich);
            request.Credentials = new NetworkCredential(strUser, strPassword);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            using (Stream requestStream = request.GetRequestStream())
            {


                using (StreamReader reader = new StreamReader(fich))
                using (StreamWriter destination = new StreamWriter(requestStream))
                {
                    destination.Write(reader.ReadToEnd());
                    destination.Flush();
                }


            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine("Fichero subido con código: " + response.StatusDescription);
            }
        }

    }



}


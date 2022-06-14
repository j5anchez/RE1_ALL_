using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;


namespace CompartirImagen
{

    public class TCPCliente
    {

        private TcpClient socket = null;
        private NetworkStream network = null;
        private StreamWriter writer = null;
        private StreamReader reader = null;

        private string nombrefichkey = string.Empty; //Nombre de fichero local, donde guardará el contenido del la clave recibida vía FTP.
        private string nombrefichIV = string.Empty; //Nombre de fichero local, donde guardará el contenido del la key recibida vía FTP.
        private string fichero = string.Empty; //Nombre de fichero local, donde se guardará el contenido de la imagen cifrada. Recibida vía TCP/IP.
        private string IPFTPServer = string.Empty; //Dirección IP del servidor FTP.
        private string FTPUser = string.Empty; //Nombre de usuario del servidor FTP.
        private string FTPPassword = string.Empty; //Password en texto plano del servidor FTP.
        private string IPServerTCP = string.Empty; //IP del servidor TCPIP.
        private Int32 ServerPortTCP = Int32.MaxValue; //Puerto TCPIP del servidor.


        public static int Main(String[] args)
        {
//PartidaCliente partidaCliente = new PartidaCliente();
            TCPCliente appcliente = new TCPCliente("key.txt", "IV.txt","textocifrado.txt", "ftps4.us.freehostia.com/", "asfasf392", "w23w4SHYl", "127.0.0.1", 13000);
            
            //Crea una conexión con el servidor, inicializa los atributos necesarios para la comunicación con el servidor, socket y streams.
            appcliente.Connect();

            //Realiza todas las operaciones necesarias para la transmisión de datos y funcionamiento.
            appcliente.GestionDatos();

            //Cierra los streams y socket de la comunición.
            appcliente.Cerrar();

            //Mensaje de fin de programa
            Console.WriteLine("\n Fin de la transmisión Cliente");
            Console.Read();
            return 0;
        }

        public TCPCliente(string fichkey, string fichIV, string ficherotexto, string IPdir, string FTPUse, string FTPPass, string IPServTCP, Int32 ServPortTCP)
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
            using (FtpWebRequest conn = new FtpWebRequest())
            {
                conn.Host = IPFTPServer;
                conn.Credentials = new NetworkCredential(FTPUser, FTPPassword);
                conn.Connect();
            }
            //A COMPLETAR****************************************************************************************************************************************

        }

        private void GestionDatos()
        {
            string datouser = string.Empty;
            Aes objAES = null;

            try
            {
                //Solicita al usuario el número para crear el fichero
                
                datouser = RecogerDatoUser();

                //Enviar dato a servidor
                // A COMPLETAR**************************************************************************************************************************************

                //Recepciona los datos del servidor (imagen cifrada) lo guarda en el fichero que pasamos como parámetro.

                RecepcionDatosDeServidor(fichero);

                //Descarga clave y vector desde un servidor FTP (el servidor guarda en este servidor los ficheros)
                Thread.Sleep(2000);
                Download(this.nombrefichkey, this.nombrefichkey, this.IPFTPServer, this.FTPUser, this.FTPPassword);
                Download(nombrefichIV, nombrefichIV, IPFTPServer, FTPUser, FTPPassword);

                Thread.Sleep(2000);

                //Lee la clave y vector de cada uno de los ficheros correspondientes y los guarda en objetos
                objAES = Aes.Create();
                objAES.Key = LecturaClave(nombrefichkey);
                objAES.IV = LecturaClave(nombrefichIV);

                //Desencripta el fichero generado con los datos enviado desde el servidor, se pasa como parámetro el fichero recibido por TCP/IP y las claves recibidas vía FTP
                string result = DesencriptarFicheroATexto(fichero, objAES.Key, objAES.IV);

                //Mostrar por pantalla el contenido del mensaje
                Console.WriteLine("Texto descrifrado:\n" + result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Out.Flush();
            }

        }
        private string RecogerDatoUser()
        {
            Console.WriteLine("Indica el tamaño de la imagen que quieres crear:\n");
            string numero = Console.ReadLine();
            return numero;
        }
        private void RecepcionDatosDeServidor(string rutaynombrefich)
        {
            byte[] bytes = new Byte[1024];
            byte[] tamanob = new Byte[16];

            int bytesRec = this.network.Read(tamanob, 0, sizeof(long));
            string data = Encoding.ASCII.GetString(tamanob, 0, bytesRec);
            int tamano = Convert.ToInt32(data);

            try
            {

                int bytesReadTotal = 0;
                using (FileStream fs = File.Create(rutaynombrefich))
                {

                    while (bytesReadTotal < tamano)
                    {
                        int bytesRead = this.network.Read(bytes, 0, bytes.Length);
                        fs.Write(bytes, 0, bytesRead);
                        bytesReadTotal += bytesRead;
                    }

                };
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Fichero no encontrado: {0}", e.Message);
            }
        }

        private byte[] LecturaClave(string nombrefich)
        {
            if (!File.Exists(nombrefich))
            {
                return null;
            }
            string texto = string.Empty;
            using (StreamReader srtream = new StreamReader(nombrefich))
            {
                texto = srtream.ReadToEnd();
                srtream.Close();
                Console.WriteLine("Clave o Key Recibida es:" + texto);
            }

            return System.Convert.FromBase64String(texto);
        }

        private void Cerrar()
        {
            this.socket.Close();
            this.writer.Close();
            this.network.Close();
            this.socket.Close();
        }

        public void Download(string strFileNameFTP, string strFileNameLocal,string IP, string strUser, string strPassword)
        {
            //A COMPLETAR********************************************************************************************************************************************************************

        }

        public static string DesencriptarFicheroATexto(string FileName, byte[] Key, byte[] IV)
        {
            //A COMPLETAR********************************************************************************************************************************************************************
            return "";
        }
    }
}
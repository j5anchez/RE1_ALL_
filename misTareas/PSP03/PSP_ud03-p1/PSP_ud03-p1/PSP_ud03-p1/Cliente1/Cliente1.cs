using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PSP03_SocketClass_TCP_Cliente
{

    internal class Cliente1
    {
        private readonly Socket sender = null;
        private readonly int port = 13000;
        private readonly IPAddress ipAddress = null;

        public Cliente1()
        {
            ipAddress = IPAddress.Parse("127.0.0.1");
            sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Socket Cliente creado.");
        }


        public void establecerConexion()
        {
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
            sender.Connect(remoteEP);
            Console.WriteLine("Buffer de escritura y lectura creados.");
        }

        public void transfiriendoInfo(string datos)
        {
            byte[] msg = Encoding.ASCII.GetBytes(datos);
            int bytesSnd = sender.Send(msg);
        }

        public string recibiendoInfo()
        {

            object o = new object();
            lock (o)
            {
                byte[] bytes = new byte[1024];
                int bytesRec = sender.Receive(bytes);
                string datos = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                return datos;

            }
        }
        public void cerrarCliente()
        {
            sender.Shutdown(SocketShutdown.Both);

            sender.Close();

        }

    }
}
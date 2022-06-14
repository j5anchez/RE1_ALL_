using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 13000);
            TcpClient clientSocket = new TcpClient();
            int counter = 0;
            serverSocket.Start();
            Console.WriteLine("Servidor iniciado en. . . " + serverSocket.LocalEndpoint);
            counter = 0;

            while (true)
            {
                if (counter >= 5) { Console.WriteLine("Numero maximo de clientes conectados, acceso denegado"); return; }
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine(">> Cliente numero " + counter + " :" + clientSocket.Client.AddressFamily);
                ManipuladorCliente manipuladorCliente = new ManipuladorCliente();
                manipuladorCliente.StartCliente(clientSocket, Convert.ToString(counter));
            }
        }
    }
}

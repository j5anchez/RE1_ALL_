using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Utils;

namespace Server
{
    public class HandleClient
    {
        private const string Directorio = @"..\..\fotos";
        TcpClient _clientSocket;
        string _clientNo = "";
        private Thread _clientThread;
        private byte[] _bytesFrom;
        private NetworkStream _networkStream;
        private TcpListener _serverSocket;


        public void StartCliente(TcpClient clientSocket, string clientNo)
        {
            this._clientSocket = clientSocket;
            this._clientNo = clientNo;
            _clientThread = new Thread(Manipulador);
            _clientThread.Start();
            _networkStream = clientSocket.GetStream();
        }

        private void Manipulador()
        {
            bool fileFlag = false;
            while (true)
            {
                if (!fileFlag)
                {
                    ArbolEnvioFichero();
                    fileFlag = true;
                }
                try
                {
                    _bytesFrom = new byte[_clientSocket.ReceiveBufferSize];
                    _networkStream.Read(_bytesFrom, 0, (int)_clientSocket.ReceiveBufferSize);
                    string dataFromClient = Encoding.ASCII.GetString(_bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.Length);
                    ComprobarFicheroDescargado(dataFromClient);
              
                }
                catch (Exception e)
                {
                    Console.WriteLine("Catch desde Servidor >>> " + e.Message);
                }
            }
        }

        private void ComprobarFicheroDescargado(string dataFromClient)
        {
            FileRequest fileRequest = JsonConvert.DeserializeObject<FileRequest>(dataFromClient);
            if (fileRequest != null)
            {
                try
                {
                    byte[] fichero = File.ReadAllBytes(fileRequest.Path);
                    _bytesFrom = new byte[fichero.Length];
                    _networkStream.Write(fichero, 0, fichero.Length);
                    _networkStream.Flush();
                 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void ArbolEnvioFichero()
        {
            string arbolfichero = GetFilesInfo();

            try
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes(arbolfichero);
                _networkStream.Write(sendBytes, 0, sendBytes.Length);
                _networkStream.Flush();
              

            }
            catch (Exception e)
            {
                Console.WriteLine("Error en el servidor: " + e.Message);
            }
        }

        private string GetFilesInfo()
        {
            List<FilesInfo> infos = new List<FilesInfo>();
            string[] files = System.IO.Directory.GetFiles(Directorio, "*.*").Select(Path.GetFileName).ToArray();
            string[] nombres = { "1.- FotoCiudad", "2.- FotoMonte", "3.- FotoPlaya" };
            int x = 0;
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(Path.Combine(Directorio, file));
                infos.Add(new FilesInfo
                {
                    FileName = nombres[x],
                    AbsolutePath = fileInfo.FullName,
                    Extension = fileInfo.Extension,
                    DateCreated = fileInfo.CreationTimeUtc,
                    Size = fileInfo.Length
                });
                x++;
            }
            string serializeObject = JsonConvert.SerializeObject(infos);
            return serializeObject;
        }
    }
}

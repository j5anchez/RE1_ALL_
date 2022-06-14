using System;
using System.Text;
using System.IO.Pipes;
namespace PipeCliente
{
    class Program
    {
        public static void Main(string[] args)
        {
            Main llamadaMain = new Main();
            llamadaMain.index();
        }
    }
    class Main
    {
        string line = "";
        string request = "";
        string palabra = "";
        string resultado = "";
        string contadorstr = "";
        int contadorint = 0;
        int paso = 0;
        bool sw = false;
        public void resetVariables()
        {
            try
            {
                line = "";
                request = "";
                palabra = "";
                resultado = "";
                contadorstr = "";
                contadorint = 0;
                paso = 0;
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
        public void conexion()
        {
            try
            {
                if (sw == false)
                {
                    Console.WriteLine("Estableciendo conexion con el servidor\n");
                    sw = true;
                }
                using (var ClienteStream = new NamedPipeClientStream("pipes"))
                {
                    line = "";
                    ClienteStream.Connect();
                    for (int i = 0; i < i + 1; ++i)
                    {
                        Console.WriteLine("Indica el nombre del cuento elegido o escribe salir para terminar:\n");
                        line = Console.ReadLine();
                        if (line == "salir")
                        {
                            byte[] bufferinline = ASCIIEncoding.ASCII.GetBytes(line);
                            ClienteStream.Write(bufferinline, 0, bufferinline.Length);
                            ClienteStream.Close();
                            Environment.Exit(0);
                        }
                        else if ((!File.Exists(@"..\..\..\..\Servidor\" + line + ".txt") && (!File.Exists(@"..\Servidor\" + line + ".txt"))))
                        {
                            Console.WriteLine("Archivo inexistente, vuelve a intentarlo");
                            continue;
                        }
                        break;
                    }
                    byte[] buffer = ASCIIEncoding.ASCII.GetBytes(line);
                    ClienteStream.Write(buffer, 0, buffer.Length);
                    Console.WriteLine("Tubo cliente procesando datos: 'N {0}'", line);
                    reciboContarPalabras();
                }
                return;
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
        public void reciboContarPalabras()
        {
            try
            {
                using (var ClienteStream = new NamedPipeClientStream("pipes"))
                {
                    ClienteStream.Connect();
                    byte[] buffer = new byte[255];
                    ClienteStream.Read(buffer, 0, 255);
                    contadorstr = ASCIIEncoding.ASCII.GetString(buffer);
                    contadorstr = contadorstr.Trim('\0');
                    contadorint = Convert.ToInt32(contadorstr);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
        public void recibir()
        {
            try
            {
                using (var ClienteStream = new NamedPipeClientStream("pipes"))
                {
                    request = "";
                    ClienteStream.Connect();
                    byte[] buffer = new byte[255];
                    ClienteStream.Read(buffer, 0, 255);
                    request = ASCIIEncoding.ASCII.GetString(buffer);
                    request = request.Trim('\0');
                    if (paso == 0)
                    {
                        Console.WriteLine(request + ":");
                        paso = 1;
                    }
                    else if (paso == 1)
                    {
                        Console.WriteLine("Tubo cliente recibiendo datos: 'P {0}'\n{0}:", request);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
        public void enviarPalabra()
        {
            try
            {
                using (var ClienteStream = new NamedPipeClientStream("pipes"))
                {
                    palabra = "";
                    ClienteStream.Connect();
                    palabra = Console.ReadLine();
                    byte[] buffer = ASCIIEncoding.ASCII.GetBytes(palabra);
                    ClienteStream.Write(buffer, 0, buffer.Length);
                    Console.WriteLine("Tubo cliente procesando datos: 'P {0}'", palabra);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
        public void recibirResultado()
        {
            try
            {
                using (var ClienteStream = new NamedPipeClientStream("pipes"))
                {
                    resultado = "";
                    ClienteStream.Connect();
                    using (StreamReader abrircuento = new StreamReader(ClienteStream))
                    {
                        resultado = abrircuento.ReadToEnd();
                    }
                    Console.WriteLine("\n*****************\n\n"
                    + "El cuento creado es:"
                    + "\n\n*****************\n\n" + resultado + "\n\n");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
        public void index()
        {
            try
            {
                for (int i = 0; i < i + 1; ++i)
                {
                    resetVariables();
                    conexion();
                    while (contadorint > 0)
                    {
                        recibir();
                        enviarPalabra();
                        contadorint--;
                    }
                    recibirResultado();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
    }
}
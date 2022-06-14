using System.Net.Mime;
using System.Net.Sockets;
using System;
using System.Text;
using System.IO.Pipes;
namespace PipeServer
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
        List<string> listaPalabrasCliente = new List<string>();
        List<string> listaPalabrasServidor = new List<string>();
        string request = "";
        string path = "";
        string lineas = "";
        string texto = "";
        string tipo = "";
        string borrador = "";
        string guardar = "";
        string textoresultado = "";
        string contadorstr = "";
        int carBorrar = 0;
        int contadorint = 0;
        int largo;
        int lista = 0;
        int i = 0;
        bool sw = false;
        bool ficheroabierto = false;
        public void resetVariables()
        {
            try
            {
                listaPalabrasCliente.Clear();
                listaPalabrasServidor.Clear();
                request = "";
                path = "";
                lineas = "";
                texto = "";
                tipo = "";
                borrador = "";
                guardar = "";
                textoresultado = "";
                contadorstr = "";
                contadorint = 0;
                carBorrar = 0;
                lista = 0;
                i = 0;
                sw = false;
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
                if (!ficheroabierto) { Console.WriteLine("Conectando servidor"); }
                using (var ServidorStream = new NamedPipeServerStream("pipes"))
                {
                    ServidorStream.WaitForConnection();
                    Console.WriteLine("Pipe servidor esperando datos\n");
                    byte[] buffer = new byte[255];
                    ServidorStream.Read(buffer, 0, 255);
                    request = ASCIIEncoding.ASCII.GetString(buffer);
                    request = request.Trim('\0');
                    //Console.WriteLine(request);
                    if (request == "salir")
                    {
                        Environment.Exit(0);
                    }
                }
                path = request + ".txt";
                if ((File.Exists(@"..\..\..\" + path) || (File.Exists(@"..\" + path))))
                {
                    Console.WriteLine("Tubo servidor recibiendo datos: 'N {0}'\n", request);
                    Console.WriteLine("Apertura de fichero:{0}\n", path);
                    envioContarPalabras();
                    return;
                }
                else
                {
                    Console.WriteLine("No se encuentra el fichero");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
        public void envioContarPalabras()
        {
            try
            {
                using (var ServidorStream = new NamedPipeServerStream("pipes"))
                {
                    string cuentostr = File.ReadAllText(@"..\..\..\" + path);
                    for (int i = 0; i < cuentostr.Length; ++i)
                    {
                        if (cuentostr[i] == '<')
                        {
                            contadorint++;
                        }
                    }
                    contadorstr = contadorint.ToString();
                    ServidorStream.WaitForConnection();
                    byte[] buffer = ASCIIEncoding.ASCII.GetBytes(contadorstr);
                    ServidorStream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
        public void abrirFichero()
        {
            try
            {
                using (StreamReader abrircuento = new StreamReader(@"..\..\..\" + path))
                {
                    if (!ficheroabierto) { Console.WriteLine("Fichero abierto. {0}", path); ficheroabierto = true; }
                    lineas = abrircuento.ReadToEnd();
                    largo = lineas.Length;
                    texto = "";
                    tipo = "";
                    for (; i < largo; ++i)
                    {
                        if (lineas[i] == 10 || lineas[i] == 13)
                        {
                            texto += " ";
                            ++i;
                            continue;
                        }
                        texto += lineas[i];
                        carBorrar = i;
                        if (lineas[i] == '<')
                        {
                            sw = true;
                            continue;
                        }
                        else if (lineas[i] == '>')
                        {
                            sw = false;
                            listaPalabrasServidor.Add(tipo);
                            ++i;
                            break;
                        }
                        if (sw == true)
                        {
                            tipo += lineas[i];
                        }
                    }
                    guardar = lineas;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
        public void enviar()
        {
            try
            {
                using (var ServidorStream = new NamedPipeServerStream("pipes"))
                {
                    ServidorStream.WaitForConnection();
                    Console.WriteLine("Tubo servidor procesando datos: '" + texto + "'\n");
                    byte[] buffer = ASCIIEncoding.ASCII.GetBytes(tipo);
                    ServidorStream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
        public void recibirPalabra()
        {
            try
            {
                using (var ServidorStream = new NamedPipeServerStream("pipes"))
                {
                    ServidorStream.WaitForConnection();
                    Console.WriteLine("Tubo servidor emitiendo datos: '" + tipo + "'\n");
                    byte[] buffer = new byte[255];
                    ServidorStream.Read(buffer, 0, 255);
                    request = ASCIIEncoding.ASCII.GetString(buffer);
                    request = request.Trim('\0');
                    listaPalabrasCliente.Add(request);
                    Console.WriteLine("Tubo Servidor recibiendo datos: 'P {0}'\n", request);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
        public void enviarResultado()
        {
            try
            {
                char c;
                int p1 = 0;
                int p2 = 0;
                lista = 0;
                for (int o = 0; o < guardar.Length; ++o)
                {
                    c = guardar[o];
                    if (c == 10 || c == 13) { continue; }
                    if (c == '<') { p1 = o; p2 = 0; }
                    else if (c == '>') { p2 = o; }
                    if (p1 > 0 && p2 > 0 && p1 < p2 && lista <= listaPalabrasServidor.Count)
                    {
                        guardar = guardar.Remove(p1 + 1, p2 - p1 - 1);
                        guardar = guardar.Replace("<>", listaPalabrasCliente[lista]);
                        o -= listaPalabrasServidor[lista].Length + listaPalabrasCliente[lista].Length;
                        lista++;
                        p1 = 0; p2 = 0;
                    }
                }
                using (var ServidorStream = new NamedPipeServerStream("pipes"))
                {
                    ServidorStream.WaitForConnection();
                    Console.WriteLine("Tubo servidor emitiendo datos cuento");
                    using (StreamWriter escritor = new StreamWriter(ServidorStream))
                    {
                        escritor.WriteLine(guardar);
                    }
                }
                using (StreamWriter ef = new StreamWriter(@"..\..\..\resultado.txt"))
                {
                    ef.WriteLine(guardar);
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
                        abrirFichero();
                        enviar();
                        recibirPalabra();
                        contadorint--;
                    }
                    enviarResultado();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
    }
}

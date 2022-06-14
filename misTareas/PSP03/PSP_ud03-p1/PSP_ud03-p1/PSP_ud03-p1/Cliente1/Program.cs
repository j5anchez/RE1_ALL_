using System.Net;
using System.Net.Sockets;

namespace PSP03_SocketClass_TCP_Cliente
{

    public class Program
    {

        public static int Main(string[] args)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            Random rdm = new Random();
            int nmax = 101;
            int nmin = 1;
  
            try
            {
                Cliente1 cliente = new Cliente1();
                cliente.establecerConexion();
                cliente.transfiriendoInfo("cliente");
                string msg = cliente.recibiendoInfo();
                Console.WriteLine("Identificador de cliente: " + msg.ToString() + "\nIntenta adivinar mi numero:");
                int njugadas = 0;
                string findelapartida = "*****************\nFin de la partida.\n*****************\nFin del juego";
                while (true)
                {
                    //Thread.Sleep(1000);
                    string cadena = rdm.Next(nmin, nmax).ToString();
                    cliente.transfiriendoInfo(cadena);
                    Console.WriteLine(cadena);
                    njugadas++;
                    msg = cliente.recibiendoInfo();
                    Console.WriteLine(msg);
                    if (msg.Equals("Has acertado!!Zorionak!") || cadena.Equals("salir"))
                    {
                        Console.WriteLine("Numero de jugadas realizadas por ti: {0}", njugadas);
                        Console.WriteLine(findelapartida);
                        break;
                    }
                    else if (msg.Substring(0, 13).Equals("El ganador es"))
                    {
                        Console.WriteLine(findelapartida);
                        break;
                    }
                    else if (msg.Equals("El numero es mayor."))
                    {
                        nmin = int.Parse(cadena);
                    }
                    else if (msg.Equals("El numero es menor."))
                    {
                        nmax = int.Parse(cadena);

                    }
                }
                cliente.cerrarCliente();

            }
            catch (SocketException se)
            {
                Console.WriteLine("Cliente ha tenido problemas  de SocketException : {0}", se.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cliente ha tenido problemas al establecer la conexión con el servidor");
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\nPresiona intro para continuar...");
            Console.Read();


            return 0;
        }
    }

}
/* Programa que muestra el funcionamiento de BlockingCollection
 * BlockingCollection: Es una lista de elementos.
 * Es seguro, ya  que mediante sus métodos se asegura que recoger objetos y agregarlos en esa colección se va a realizar de forma segura. 
 * Realiza una gestión de threads interna y abstrae al programador de su realización.
 * Funcionamiento:
 *  El programa tendrá una cola de 100 números que se podrán consumir y producir simultáneamente.
 *  Los valores que se generarán y consumirán tendrán unos valores comprendidos entre el 0 y el 1000.
 *  La ejecución puede ser multithreading o multihilo.
*/

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace TareaEvaluacion1p1
{
    class Program
    {

        static void Main(string[] args)
        {
            int almacen2 = 0;
            Random random = new Random();
            bool AnadirElemento = true;
            bool stocksobrante = true;


            BlockingCollection<int> dataItems = new BlockingCollection<int>(100);


            Task consumidor1 = Task.Run(() =>
            {
                while (!dataItems.IsCompleted)
                {

                    int data = -1;

                    try
                    {

                        data = dataItems.Take();
                        Console.WriteLine("Un usuario en la zona Gros ha alquilado la bicicleta{0}", data);


                    }
                    catch (InvalidOperationException) { }
                    try
                    {
                        if (data % 3 == 0)
                        {

                            if (AnadirElemento)
                            {

                                dataItems.Add(data);

                                Console.WriteLine("Un usuario en la zona Gros ha devuelto la bicicleta{0}", data);
                            }
                            else
                            {
                                almacen2++;
                                Console.WriteLine("El almacen principal esta completo. se depositaran las bicis en el secundario.\nUn usuario en la zona Gros ha devuelto la bicicleta{0} al segundo almacen", data);

                            }
                        }
                    }
                    catch (InvalidOperationException) { }
                }

                Console.WriteLine("En zona Gros no hay mas bicis en el almacen");

                if (!stocksobrante)
                {
                    Console.WriteLine("El stock sobrante es {0} bicis", almacen2);
                }
                stocksobrante = false;

            });

            Task consumidor2 = Task.Run(() =>
            {
                while (!dataItems.IsCompleted) 
                {

                    int data = -1;
               

                    try
                    {
                        

                        data = dataItems.Take();
                        Console.WriteLine("Un usuario en la zona Amara ha alquilado la bicicleta{0}", data);
                        

                    }
                    catch (InvalidOperationException) { }
                    try
                    {
                        if (data % 5 == 0)
                        {


                            if (AnadirElemento)
                            {

                                dataItems.Add(data);
                                Console.WriteLine("Un usuario en la zona Amara ha devuelto la bicicleta{0}", data);
                            }
                            else
                            {
                                almacen2++;
                                Console.WriteLine("El almacen principal esta completo. se depositaran las bicis en el secundario.\nUn usuario en la zona Amara ha devuelto la bicicleta{0} al segundo almacen", data);

                            }
                        }
                    }
                    catch (InvalidOperationException) { }
                }

                Console.WriteLine("En zona Amara no hay mas bicis en el almacen");
                if (!stocksobrante)
                {
                    Console.WriteLine("El stock sobrante es {0} bicis", almacen2);
                }
                stocksobrante = false;
            });



            Task productor1 = Task.Run(() =>
            {
                int data = 0;

                while (AnadirElemento)
                {                 
                    dataItems.Add(data);
                    Console.WriteLine("La empresa de bicis ha comprado la bicicleta{0} y la tiene en el almacen principal", data);
                   
                    data++;

                 
                    if (data == 200)
                    {
                        AnadirElemento = false;
                        Console.WriteLine("Cierre de almacen. Nadie podra depositar bicicletas en dicho almacen.");
                    }

                }
                dataItems.CompleteAdding();


            });

            consumidor1.Wait();
            consumidor2.Wait();
            productor1.Wait();
            Console.ReadKey();
        }
    }
}
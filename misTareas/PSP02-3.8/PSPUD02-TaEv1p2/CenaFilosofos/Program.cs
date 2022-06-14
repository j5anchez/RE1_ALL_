using System;
using System.Threading;

namespace CenaFilosofos
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Filosofo filosofo1 = new Filosofo(Mesa.num1, Mesa.num2, "filosofo 1", random.Next(4, 10));
            Filosofo filosofo2 = new Filosofo(Mesa.num2, Mesa.num3, "filosofo 2", random.Next(4, 10));
            Filosofo filosofo3 = new Filosofo(Mesa.num3, Mesa.num4, "filosofo 3", random.Next(4, 10));
            Filosofo filosofo4 = new Filosofo(Mesa.num4, Mesa.num5, "filosofo 4", random.Next(4, 10));
            Filosofo filosofo5 = new Filosofo(Mesa.num5, Mesa.num1, "filosofo 5", random.Next(4, 10));

            new Thread(filosofo1.Pensando).Start();
            new Thread(filosofo2.Pensando).Start();
            new Thread(filosofo3.Pensando).Start();
            new Thread(filosofo4.Pensando).Start();
            new Thread(filosofo5.Pensando).Start();

            Console.ReadKey();
        }
    }
}

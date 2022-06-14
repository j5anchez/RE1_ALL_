using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CenaFilosofos
{
    enum EstadoFilosofo { Comiendo, Pensando }

    class Filosofo
    {
        public string Nombre { get; set; }
        public EstadoFilosofo Estado { get; set; }

        readonly int limiteHambre;
        public readonly Palillo palilloDcha;
        public readonly Palillo palilloIzq;

        Random random = new Random();

        int contPensamientos = 0;
        int f1 = 0;
        int f2 = 0;
        int f3 = 0;
        int f4 = 0;
        int f5 = 0;

        public Filosofo(Palillo palilloizq, Palillo palillodcha, string nombre, int limitehambre)
        {
            palilloIzq = palilloizq;
            palilloDcha = palillodcha;
            Nombre = nombre;
            limiteHambre = limitehambre;
            Estado = EstadoFilosofo.Pensando;

        }

        public void Comer()
        {
            if (CogerPalilloManoDcha())
            {

                if (CogerPalilloManoIzq())
                {

                    this.Estado = EstadoFilosofo.Comiendo;
                    Console.WriteLine("El {0} esta comiendo", Nombre);
                    if (Nombre == "filosofo 1") { f1++; } else if (Nombre == "filosofo 2") { f2++; } else if (Nombre == "filosofo 3") { f3++; } else if (Nombre == "filosofo 4") { f4++; } else if (Nombre == "filoso 5") { f5++; }

                    Thread.Sleep(1000);

                    contPensamientos = 0;

                    palilloDcha.ColocarEnMesa();
                    Console.WriteLine("El {0} deja el palillo derecho {1}", Nombre, palilloDcha.IdPalillo);

                    palilloIzq.ColocarEnMesa();
                    Console.WriteLine("El {0} deja el palillo izquierdo {1}", Nombre, palilloIzq.IdPalillo);

                }
                else
                {
                    Thread.Sleep(random.Next(100, 400));
                    if (CogerPalilloManoIzq())
                    {
                        this.Estado = EstadoFilosofo.Comiendo;
                        Console.WriteLine("El {0} esta comiendo", Nombre);
                        if (Nombre == "filosofo 1") { f1++; } else if (Nombre == "filosofo 2") { f2++; } else if (Nombre == "filosofo 3") { f3++; } else if (Nombre == "filosofo 4") { f4++; } else if (Nombre == "filoso 5") { f5++; }
                        Thread.Sleep(1000);

                        contPensamientos = 0;

                        palilloDcha.ColocarEnMesa();
                        Console.WriteLine("El {0} deja el palillo derecho {1}", Nombre, palilloDcha.IdPalillo);

                        palilloIzq.ColocarEnMesa();
                        Console.WriteLine("El {0} deja el palillo izquierdo {1}", Nombre, palilloIzq.IdPalillo);

                    }
                    else
                    {
                        palilloDcha.ColocarEnMesa();
                        Console.WriteLine("El {0} deja el palillo derecho {1}", Nombre, palilloDcha.IdPalillo);
                    }

                }
            }
            else
            {
                if (CogerPalilloManoIzq())
                {
                    Thread.Sleep(random.Next(100, 400));
                    if (CogerPalilloManoDcha())
                    {
                        this.Estado = EstadoFilosofo.Comiendo;
                        Console.WriteLine("{0} esta comiendo", Nombre);
                        if (Nombre == "filosofo 1") { f1++; } else if (Nombre == "filosofo 2") { f2++; } else if (Nombre == "filosofo 3") { f3++; } else if (Nombre == "filosofo 4") { f4++; } else if (Nombre == "filoso 5") { f5++; }

                        Thread.Sleep(1000);

                        contPensamientos = 0;

                        palilloDcha.ColocarEnMesa();
                        Console.WriteLine("El {0} deja el palillo derecho {1}", Nombre, palilloDcha.IdPalillo);

                        palilloIzq.ColocarEnMesa();
                        Console.WriteLine("El {0} deja el palillo izquierdo {1}", Nombre, palilloIzq.IdPalillo);

                    }
                    else
                    {
                        palilloIzq.ColocarEnMesa();
                        Console.WriteLine("El {0} deja el palillo izquierdo {1}", Nombre, palilloIzq.IdPalillo);
                    }

                }
            }
            if (f1 >= 5) { Console.WriteLine("El {0} comio suficiente se retira a pensar", Nombre); Environment.Exit(0); }
            else if (f2 >= 5) { Console.WriteLine("El {0} comio suficiente se retira a pensar", Nombre); Environment.Exit(0); }
            else if (f3 >= 5) { Console.WriteLine("El {0} comio suficiente se retira a pensar", Nombre); Environment.Exit(0); }
            else if (f4 >= 5) { Console.WriteLine("El {0} comio suficiente se retira a pensar", Nombre); Environment.Exit(0); }
            else if (f5 >= 5) { Console.WriteLine("El {0} comio suficiente se retira a pensar", Nombre); Environment.Exit(0); }

            Pensando();
        }

        public void Pensando()
        {
            this.Estado = EstadoFilosofo.Pensando;
            //Console.WriteLine("{0} esta pensando ... ", Nombre);
            Thread.Sleep(1000);
            contPensamientos++;

            if (contPensamientos > limiteHambre)
                Console.WriteLine("El {0} esta hambriento", Nombre);

            Comer();
        }

        private bool CogerPalilloManoIzq()
        {
            Console.WriteLine("El {0} coge el palillo izquierdo {1}", Nombre, palilloIzq.IdPalillo);

            return palilloIzq.Cogido(Nombre);
        }

        private bool CogerPalilloManoDcha()
        {
            Console.WriteLine("El {0} coge el palillo derecho {1}", Nombre, palilloDcha.IdPalillo);

            return palilloDcha.Cogido(Nombre);
        }
    }
}

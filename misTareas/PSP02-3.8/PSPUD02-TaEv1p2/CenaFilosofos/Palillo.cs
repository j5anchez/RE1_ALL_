using System;

namespace CenaFilosofos
{
    enum EstadoPalillo { Cogido, enMesa }

    class Palillo
    {
        public string IdPalillo { get; set; }
        public EstadoPalillo Estado { get; set; }
        public string CogidoPor { get; set; }

        public bool Cogido(string cogidoPor)
        {
            lock (this)
            {
                if (this.Estado == EstadoPalillo.enMesa)
                {
                    Estado = EstadoPalillo.Cogido;
                    CogidoPor = cogidoPor;
                    return true;
                }
                else
                {
                    Estado = EstadoPalillo.Cogido;
                    return false;
                }
            }
        }

        public void ColocarEnMesa()
        {
            Estado = EstadoPalillo.enMesa;
            CogidoPor = string.Empty;
        }
    }
}

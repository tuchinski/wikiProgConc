using System;
using System.Threading;

namespace JantarFilosofos
{
    class Filosofo
    {
        int idFilosofo;
        int tempoComer;
        int tempoPensar;
        Garfo listGarfos;
        int garfoDir, garfoEsq;

        public Filosofo(int idFilosofo, Garfo listGarfos)
        {
            Random rnd = new Random();
            this.idFilosofo = idFilosofo;
            this.listGarfos = listGarfos;
            this.tempoComer = rnd.Next(1000, 2000);
            this.tempoPensar = rnd.Next(1000, 2000);

            if(this.idFilosofo == Constants.qtdeGarfos-1)
            {
                this.garfoDir = (this.idFilosofo + 1) % Constants.qtdeGarfos;
                this.garfoEsq = this.idFilosofo;
            }
            else
            {
                this.garfoDir = this.idFilosofo;
                this.garfoEsq = (this.idFilosofo + 1)%Constants.qtdeGarfos;
            }
        }

        public void ThreadProc()
        {
            int i = 0;
            while (i != 10)
            {
                try
                {
                    Console.WriteLine("O filósofo " + this.idFilosofo + "está pensando");
                    Thread.Sleep(this.tempoPensar);
                    this.listGarfos.pegarGarfos(this.garfoDir, this.garfoEsq);
                    Console.WriteLine("O filósofo " + this.idFilosofo + "está comendo");
                    Thread.Sleep(this.tempoComer);
                    this.listGarfos.devolverGarfos(this.garfoDir, this.garfoEsq);
                }
                catch
                {
                    Console.WriteLine("Deu ruim aqui heim");
                }
                finally
                {

                    i++;
                }
            }
        }
    }
}

using System;
using System.Threading;




namespace JantarFilosofos
{
    class Garfo
    {
        bool[] garfos = new bool[Constants.qtdeGarfos];

        public void pegarGarfos(int garfo1, int garfo2)
        {
            lock (this)
            {
                while (this.garfos[garfo1] || this.garfos[garfo2])
                {
                    Monitor.Wait(this);
                }
                garfos[garfo1] = true;
                garfos[garfo2] = true;

            }
        }

        public void devolverGarfos(int garfo1, int garfo2)
        {
            lock (this)
            {
                garfos[garfo1] = false;
                garfos[garfo2] = false;
                Monitor.PulseAll(this);
            }
        }
    }
}

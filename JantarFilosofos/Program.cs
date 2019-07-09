using System;
using System.Threading;

static class Constants
{
    public const int qtdeGarfos = 5;
}

namespace JantarFilosofos
{
    class Program
    {
        static void Main(string[] args)
        {
            Garfo g = new Garfo();
            Filosofo f1 = new Filosofo(0, g);
            Filosofo f2 = new Filosofo(1, g);
            Filosofo f3 = new Filosofo(2, g);
            Filosofo f4 = new Filosofo(3, g);
            Filosofo f5 = new Filosofo(4, g);

            Thread t1 = new Thread(new ThreadStart(f1.ThreadProc));
            Thread t2 = new Thread(new ThreadStart(f2.ThreadProc));
            Thread t3 = new Thread(new ThreadStart(f3.ThreadProc));
            Thread t4 = new Thread(new ThreadStart(f4.ThreadProc));
            Thread t5 = new Thread(new ThreadStart(f5.ThreadProc));

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            Console.WriteLine("Statou as threads!!!!!!!!!!!!!");

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();


        }
    }
}

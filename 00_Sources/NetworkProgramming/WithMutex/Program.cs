using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WithMutex
{
    class Program
    {
        static Mutex mut = new Mutex();
        static int Count;

        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(ThreadProc));
            Thread th2 = new Thread(new ThreadStart(ThreadProc));
            th1.Start();
            th2.Start();

            Console.ReadKey();
        }

        static void ThreadProc()
        {
            mut.WaitOne();
            // Start of critical section
            for (int i = 0; i < 10; i++)
            {
                Count++;
                Console.WriteLine("Thread ID : {0} ||| Count : {1}", Thread.CurrentThread.GetHashCode(), Count);
            }
            // End of critical section
            mut.ReleaseMutex();
        }
    }
}

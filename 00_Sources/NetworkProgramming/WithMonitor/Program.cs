using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WithMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th1 = new Thread(new ThreadStart(test.IncreaseCount));
            Thread th2 = new Thread(new ThreadStart(test.IncreaseCount));

            th1.Start();
            th2.Start();

            Console.ReadKey();
        }

        class Test
        {
            int Count;
            object obj = new object();
            
            public void IncreaseCount()
            {
                Monitor.Enter(obj);
                // Start of critical section
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Count++;
                        Console.WriteLine("Thread ID : {0} ||| Count : {1}", Thread.CurrentThread.GetHashCode(), Count);
                    }
                }
                finally
                {
                    // End of critical section
                    Monitor.Exit(obj);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WithoutLock
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th1 = new Thread(new ThreadStart(test.ThreadProc));
            Thread th2 = new Thread(new ThreadStart(test.ThreadProc));
            th1.Start();
            th2.Start();

            Console.ReadKey();
        }
    }

    class Test
    {
        static int Count;

        public void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Count++;
                Console.WriteLine("Thread ID : {0} ||| Result : {1}", Thread.CurrentThread.GetHashCode(), Count);
            }
        }
    }
}

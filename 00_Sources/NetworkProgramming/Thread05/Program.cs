using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread05
{
    class Program
    {
        static void Func1()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Call Func1 : {0}", i);
            }
        }

        static void Func2()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Call Func2 : {0}", i);
            }
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(Func1));
            Thread th2 = new Thread(new ThreadStart(Func2));
            th1.Start();
            th2.Start();

            Console.WriteLine("Exitting...");

            Console.ReadKey();
        }
    }
}

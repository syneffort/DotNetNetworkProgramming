using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread01
{
    class Program
    {
        static void Func()
        {
            Console.WriteLine("Call thread");
        }

        static void ParameterizedFunc(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
            {
                Console.WriteLine("Call parameterized thread : {0}", i);
            }
        }

        static void Main(string[] args)
        {
            //ThreadStart thStart = new ThreadStart(Func);
            //Thread th1 = new Thread(thStart);
            Thread th1 = new Thread(new ThreadStart(Func));
            th1.Start();

            int i = 5;
            //ParameterizedThreadStart thParamStart = new ParameterizedThreadStart(ParameterizedFunc);
            //Thread th2 = new Thread(thParamStart);
            Thread th2 = new Thread(new ParameterizedThreadStart(ParameterizedFunc));
            th2.Start(i);
            Console.ReadKey();
        }
    }
}

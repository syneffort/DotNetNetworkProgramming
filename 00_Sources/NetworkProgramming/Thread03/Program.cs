using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread03
{
    class Program
    {
        static void Func1()
        {
            Console.WriteLine("call thread1");
        }

        static void Func2()
        {
            Console.WriteLine("call thread2");
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(Func1));
            Thread th2 = new Thread(new ThreadStart(Func2));

            th1.Start();
            th2.Start();
            Console.WriteLine("Exitting");
            Console.ReadLine();
        }
    }
}

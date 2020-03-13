using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread02
{
    class Program
    {
        class Test
        {
            public void Print()
            {
                Console.WriteLine("Test print");
            }
        }

        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th = new Thread(new ThreadStart(test.Print));
            th.Start();

            Console.ReadKey();
        }
    }
}

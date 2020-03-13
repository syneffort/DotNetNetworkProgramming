using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockForObject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test test = new Test(false);
            Test test = new Test(true);
            Thread[] threads = new Thread[3];
            for (int i = 0; i < 3; i ++)
            {
                threads[i] = new Thread(new ThreadStart(test.ThreadProc));
            }

            for (int i = 0; i < 3; i++)
            {
                threads[i].Start();
            }

            Console.ReadKey();
        }
    }

    class ThisLock
    {
        public void IncreaseCount(ref int count)
        {
            count++;
        }
    }

    class Test
    {
        ThisLock lockObject = new ThisLock();
        int Count = 0;
        bool UseLock;

        public Test(bool UseLock)
        {
            this.UseLock = UseLock;
        }

        public void ThreadProc()
        {
            if (UseLock)
            {
                lock (lockObject)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        lockObject.IncreaseCount(ref Count);
                        Console.WriteLine("Thread ID : {0} ||| Count : {1}", Thread.CurrentThread.GetHashCode(), Count);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    lockObject.IncreaseCount(ref Count);
                    Console.WriteLine("Thread ID : {0} ||| Count : {1}", Thread.CurrentThread.GetHashCode(), Count);
                }
            }
        }
    }
}
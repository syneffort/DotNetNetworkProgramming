using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("IP : ");
            string Address = Console.ReadLine();
            IPAddress IP = IPAddress.Parse(Address);

            Console.WriteLine("IP : {0}", IP.ToString());

            IPAddress[] IPs = Dns.GetHostAddresses("www.google.com");
            foreach (IPAddress HostIP in IPs)
            {
                Console.WriteLine("IP : {0}", HostIP);
            }

            Console.ReadKey();
        }
    }
}

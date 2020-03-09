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
            Console.Write("Input mode key : ");
            string mode = Console.ReadLine();

            string input;
            switch (mode)
            {
                // IP parsing
                case "1":
                    {
                        Console.Write("IP : ");
                        input = Console.ReadLine();
                        IPAddress IP = IPAddress.Parse(input);

                        Console.WriteLine("IP : {0}", IP.ToString());
                        break;
                    }
                // Get host addresses (ip + domain)
                case "2":
                    {
                        Console.Write("DNS : ");
                        input = Console.ReadLine();
                        IPAddress[] IPs = Dns.GetHostAddresses(input);

                        foreach (IPAddress hostIP in IPs)
                        {
                            Console.WriteLine("IP : {0}", hostIP);
                        }
                        break;
                    }
                // Get host entry (ip + hostname)
                case "3":
                    {
                        Console.Write("DNS : ");
                        input = Console.ReadLine();
                        IPHostEntry HostInfo = Dns.GetHostEntry(input);

                        foreach (IPAddress hostIP in HostInfo.AddressList)
                        {
                            Console.WriteLine("IP : {0}", hostIP);
                        }
                        Console.WriteLine("HostName : {0}", HostInfo.HostName);
                        break;
                    }
                // Set ip end point (ip + port)
                case "4":
                    {
                        Console.Write("IP : ");
                        input = Console.ReadLine();
                        IPAddress IPInfo = IPAddress.Parse(input);
                        int port = 13;
                        IPEndPoint EndPointInfo = new IPEndPoint(IPInfo, port);

                        Console.WriteLine("IP : {0} Port : {1}", EndPointInfo.Address, EndPointInfo.Port);
                        Console.WriteLine(EndPointInfo.ToString());
                        break;
                    }
                default:
                    Console.WriteLine("Unknown mode");
                    break;
            }

            Console.ReadKey();
        }
    }
}

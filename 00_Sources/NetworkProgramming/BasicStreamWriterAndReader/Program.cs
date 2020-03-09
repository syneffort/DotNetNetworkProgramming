using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BasicStreamWriterAndReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Server = 1, Client = 2 ****");
            Console.Write("Input mode key : ");
            string mode = Console.ReadLine();

            string input;
            switch (mode)
            {
                case "1":
                    {
                        TcpListener tcpListener = new TcpListener(3000);
                        tcpListener.Start();
                        Console.WriteLine("Waiting...");
                        TcpClient tcpClient = tcpListener.AcceptTcpClient();

                        bool YesNo = false;
                        int Val1 = 12;
                        float Pi = 3.14f;
                        string Message = "Hello World!";

                        NetworkStream ns = tcpClient.GetStream();
                        using (StreamWriter sw = new StreamWriter(ns))
                        {
                            sw.AutoFlush = true;
                            sw.WriteLine(YesNo);
                            sw.WriteLine(Val1);
                            sw.WriteLine(Pi);
                            sw.WriteLine(Message);
                        }

                        ns.Close();
                        tcpClient.Close();
                        tcpListener.Stop();

                        break;
                    }
                case "2":
                    {
                        TcpClient tcpClient = new TcpClient("localhost", 3000);
                        NetworkStream ns = tcpClient.GetStream();
                        Console.WriteLine("Success to connect server");

                        char[] buffer = new char[100];
                        using (StreamReader sr = new StreamReader(ns))
                        {
                            string str = sr.ReadLine();
                            Console.WriteLine(str);

                            str = sr.ReadLine();
                            Console.WriteLine(str);

                            str = sr.ReadLine();
                            Console.WriteLine(str);

                            str = sr.ReadLine();
                            Console.WriteLine(str);
                        }

                        ns.Close();
                        tcpClient.Close();

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

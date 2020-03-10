using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BasicNetworkStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Server = 1, Client = 2 ****");
            Console.Write("Input mode key : ");
            string mode = Console.ReadLine();

            switch (mode)
            {
                case "1":
                    {
                        TcpListener tcpListener = new TcpListener(IPAddress.Any, 7);
                        tcpListener.Start();
                        byte[] Buffer = new byte[1024];
                        int TotalByteCount = 0;
                        int ReadByteCount = 0;
                        
                        Console.WriteLine("Waiting...");
                        TcpClient tcpClient = tcpListener.AcceptTcpClient();
                        NetworkStream ns = tcpClient.GetStream();

                        while (true)
                        {
                            ReadByteCount = ns.Read(Buffer, 0, Buffer.Length);
                            if (ReadByteCount == 0)
                                break;

                            TotalByteCount += ReadByteCount;
                            ns.Write(Buffer, 0, ReadByteCount);

                            Console.Write(Encoding.ASCII.GetString(Buffer));
                        }

                        ns.Close();
                        tcpClient.Close();
                        tcpListener.Stop();

                        break;
                    }
                case "2":
                    {
                        TcpClient tcpClient = new TcpClient("localhost", 7);
                        NetworkStream ns = tcpClient.GetStream();

                        Console.WriteLine("Success to connect server");
                        byte[] Buffer = new byte[1024];
                        byte[] SendMessage = Encoding.ASCII.GetBytes("Hello World!");
                        ns.Write(SendMessage, 0, SendMessage.Length);
                        int TotalCount = 0;
                        int ReadCount = 0;

                        while (TotalCount < SendMessage.Length)
                        {
                            ReadCount = ns.Read(Buffer, 0, Buffer.Length);
                            TotalCount += ReadCount;

                            string RecvMessage = Encoding.ASCII.GetString(Buffer);
                            Console.Write(RecvMessage);
                        }

                        Console.WriteLine("Received byte count : {0}", TotalCount);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace BasicTCPServerAndClient
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
                        Console.Write("IP : ");
                        input = Console.ReadLine();
                        IPAddress IP = IPAddress.Parse(input);

                        TcpListener tcpListener = new TcpListener(IP, 7);
                        tcpListener.Start();
                        Console.WriteLine("Waiting...");
                        TcpClient tcpClient = tcpListener.AcceptTcpClient();
                        NetworkStream ns = tcpClient.GetStream();
                        byte[] ReceiveMessage = new byte[100];
                        ns.Read(ReceiveMessage, 0, 100);
                        string strMessage = Encoding.ASCII.GetString(ReceiveMessage);
                        Console.WriteLine(strMessage);

                        string EchoMessage = "Hi~~";
                        byte[] SendMessage = Encoding.ASCII.GetBytes(EchoMessage);
                        ns.Write(SendMessage, 0, SendMessage.Length);
                        ns.Close();
                        tcpClient.Close();
                        tcpListener.Stop();

                        break;
                    }
                case "2":
                    {
                        Console.Write("IP : ");
                        input = Console.ReadLine();

                        TcpClient tcpClient = new TcpClient(input, 7);
                        if (tcpClient.Connected)
                        {
                            Console.WriteLine("Sucess to connect server");
                            NetworkStream ns = tcpClient.GetStream();
                            string Message = "Hello World";
                            byte[] SendByteMessage = Encoding.ASCII.GetBytes(Message);
                            ns.Write(SendByteMessage, 0, SendByteMessage.Length);

                            byte[] ReceiveByteMessage = new byte[32];
                            ns.Read(ReceiveByteMessage, 0, 32);
                            string ReceiveMessage = Encoding.ASCII.GetString(ReceiveByteMessage);
                            Console.WriteLine(ReceiveMessage);
                            ns.Close();
                        }
                        else
                        {
                            Console.WriteLine("Fail to connect server");
                        }

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

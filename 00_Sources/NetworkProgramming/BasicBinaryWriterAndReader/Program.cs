using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BasicBinaryWriterAndReader
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
                        TcpListener tcpListener = new TcpListener(IPAddress.Any, 3000);
                        tcpListener.Start();
                        Console.WriteLine("Waiting...");
                        TcpClient tcpClient = tcpListener.AcceptTcpClient();

                        NetworkStream ns = tcpClient.GetStream();
                        using (BinaryWriter bw = new BinaryWriter(ns))
                        {
                            bool YesNo = true;
                            int Number = 12;
                            float Pi = 3.14f;
                            string Message = "Hello World";

                            bw.Write(YesNo);
                            bw.Write(Number);
                            bw.Write(Pi);
                            bw.Write(Message);
                        }

                        ns.Close();
                        tcpClient.Close();
                        tcpListener.Stop();

                        break;
                    }
                case "2":
                    {
                        bool YesNo;
                        int Number;
                        float Pi;
                        string Message;

                        TcpClient tcpClient = new TcpClient("localhost", 3000);
                        NetworkStream ns = tcpClient.GetStream();
                        Console.WriteLine("Success to connect server");
                        using (BinaryReader br = new BinaryReader(ns))
                        {
                            YesNo = br.ReadBoolean();
                            Number = br.ReadInt32();
                            Pi = br.ReadSingle();
                            Message = br.ReadString();
                        }

                        ns.Close();
                        tcpClient.Close();

                        Console.WriteLine("YesNo : {0}", YesNo);
                        Console.WriteLine("Number : {0}", Number);
                        Console.WriteLine("Pi : {0}", Pi);
                        Console.WriteLine("Message : {0}", Message);

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

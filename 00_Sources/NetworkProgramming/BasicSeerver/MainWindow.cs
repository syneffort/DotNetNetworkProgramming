using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BasicSeerver
{
    public partial class MainWindow : Form
    {
        TcpListener tcpListener;
        TcpClient tcpClient;
        NetworkStream ns;
        BinaryWriter bw;
        BinaryReader br;

        public MainWindow()
        {
            InitializeComponent();

            InitInstance();
        }

        private void InitInstance()
        {
            tcpListener = new TcpListener(IPAddress.Any, 3000);
            tcpListener.Start();

            this.Load += Form1_Load;
            this.btnConnnect.Click += btnConnnect_Click;
            this.btnStart.Click += btnStart_Click;
        }

        void btnStart_Click(object sender, EventArgs e)
        {
            
        }

        void btnConnnect_Click(object sender, EventArgs e)
        {
            tcpClient = tcpListener.AcceptTcpClient();
            if (tcpClient.Connected)
                txtClientIP.Text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();

            ns = tcpClient.GetStream();
            bw = new BinaryWriter(ns);
            br = new BinaryReader(ns);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = 0 ; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    txtServerIP.Text = host.AddressList[i].ToString();
                    break;
                }
            }
        }
    }
}

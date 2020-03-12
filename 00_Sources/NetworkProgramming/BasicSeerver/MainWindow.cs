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

        int intValue;
        float floatValue;
        string strValue;

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
            this.btnEnable.Click += btnConnnect_Click;
            this.btnStart.Click += btnStart_Click;
            this.FormClosing += MainWindow_FormClosing;
        }

        private int DataReceive()
        {
            intValue = br.ReadInt32();
            if (intValue == -1)
                return -1;

            floatValue = br.ReadSingle();
            strValue = br.ReadString();

            string str = string.Format("{0} / {1} / {2}", intValue, floatValue, strValue);
            MessageBox.Show(str);

            return 0;
        }

        private void SendData()
        {
            bw.Write(intValue);
            bw.Write(floatValue);
            bw.Write(strValue);

            MessageBox.Show("Send data");
        }

        private void AllClose()
        {
            if (bw != null)
            {
                bw.Close();
                bw = null;
            }

            if (br != null)
            {
                br.Close();
                br = null;
            }

            if (ns != null)
            {
                ns.Close();
                ns = null;
            }

            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
            }
        }

        void btnStart_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (tcpClient.Connected)
                {
                    if (DataReceive() == -1)
                        break;

                    SendData();
                }
                else
                {
                    AllClose();
                    break;
                }
            }

            AllClose();
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

        void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            AllClose();
            tcpListener.Stop();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicClient
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        NetworkStream ns;
        BinaryWriter bw;
        BinaryReader br;

        int intValue;
        float floatValue;
        string strValue;

        public Form1()
        {
            InitializeComponent();

            InitInstance();

        }

        private void InitInstance()
        {
            this.btnConnnect.Click += btnConnnect_Click;
            this.btnStart.Click += btnStart_Click;
            this.FormClosing += Form1_FormClosing;
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bw.Write(-1);
            bw.Close();
            br.Close();
            ns.Close();
            tcpClient.Close();
        }

        void btnStart_Click(object sender, EventArgs e)
        {
            bw.Write(int.Parse(txtInt.Text));
            bw.Write(float.Parse(txtFloat.Text));
            bw.Write(txtString.Text);

            intValue = br.ReadInt32();
            floatValue = br.ReadSingle();
            strValue = br.ReadString();

            string str = string.Format("{0} / {1} / {2}", intValue, floatValue, strValue);
            MessageBox.Show(str);
        }

        void btnConnnect_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient(txtServerIP.Text, 3000);
            if (tcpClient.Connected)
            {
                ns = tcpClient.GetStream();
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);

                MessageBox.Show("Connected");
            }
            else
            {
                MessageBox.Show("Failed to connect server");
            }
        }
    }
}

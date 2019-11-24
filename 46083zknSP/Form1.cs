using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using SimpleTCP;

namespace _46083zknSP
{
    public partial class Form1 : Form
    {
 
        public Form1()
        {
            InitializeComponent();

           /* sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);*/
        }

        SimpleTcpServer server;

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += ServerDataReceived;
        }
        private void ServerDataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Text += Environment.NewLine + e.MessageString;
                e.ReplyLine(string.Format("You said: {0}{1}", e.MessageString, Environment.NewLine));
            });
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            txtStatus.Text += "Server starting...";
            System.Net.IPAddress ip = IPAddress.Parse(txtHost.Text);
            server.Start(ip, Convert.ToInt32(txtPort.Text));
            btnStart.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
                server.Stop();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textMedusaIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textMedusaPort_TextChanged(object sender, EventArgs e)
        {

        }




    }
}

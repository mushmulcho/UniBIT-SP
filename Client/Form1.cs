using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }


        SimpleTCP.SimpleTcpClient  client;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client.Connect(txtHost.Text, Convert.ToInt32(txtPort.Text));
            btnConnect.Enabled = false;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            client = new SimpleTCP.SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += ClientDataReceived;
        }

        private void ClientDataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Text += Environment.NewLine + e.MessageString;
            });
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(3));
        }

        private void textHost_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

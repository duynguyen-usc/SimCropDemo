using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CropClient
{
    public partial class frmClient : Form
    {
        SimpleTCP.SimpleTcpClient client;

        private int Port = 8910;
        private string IpAddress = "127.0.0.1";


        public frmClient()
        {
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            txtIp.Text = IpAddress;
            txtPort.Text = Port.ToString();
            SetupClient();
        }

        private void SetupClient()
        {
            client = new SimpleTCP.SimpleTcpClient
            {
                StringEncoder = Encoding.UTF8
            };
            client.DataReceived += Client_DataReceived;
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            rtxtConsole.Invoke((MethodInvoker)delegate () 
            {
                rtxtConsole.Text += e.MessageString + "\n";
            });
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            const string CONNECT = "Connect";
            const string DISCONNECT = "Disconnect";

            if(btnConnect.Text == CONNECT)
            {
                client.Connect(IpAddress, Port);
                btnConnect.Text = DISCONNECT;
            }
            else
            {
                client.Disconnect();
                btnConnect.Text = CONNECT;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply("Testing 123", TimeSpan.FromSeconds(10));
        }
    }
}

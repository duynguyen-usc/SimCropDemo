using System;
using System.Windows.Forms;

namespace CropClient
{
    public partial class frmClient : Form
    {   
        private CropClient client;
        
        public frmClient()
        {
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
           
            client = new CropClient();
            txtIp.Text = client.IpAddress;
            txtPort.Text = client.Port.ToString();
            client.DataReceived += Client_DataReceived;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            const string CONNECT = "Connect";
            const string DISCONNECT = "Disconnect";

            if (btnConnect.Text == CONNECT)
            {
                try
                {
                    client.ConnectToServer();
                    btnConnect.Text = DISCONNECT;
                }
                catch(Exception ex)
                {
                    ShowWarning(ex.Message, "Connection Failed");
                }
            }
            else
            {
                try
                {
                    client.Disconnect();
                    btnConnect.Text = CONNECT;
                    rtxtConsole.Text += "Disconnected.";
                }
                catch(Exception ex)
                {
                    ShowWarning(ex.Message, "Discconect Failed");
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
           
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            rtxtConsole.Invoke((MethodInvoker)delegate ()
            {
                rtxtConsole.Text += e.MessageString + "\n";
            });
        }

        private void ShowWarning(string warning, string title)
        {
            MessageBox.Show(warning, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}

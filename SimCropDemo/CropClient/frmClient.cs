using System;
using System.Text;
using System.Windows.Forms;
using CropServer;

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

        #region EventHandlers

        private void frmClient_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            txtIp.Text = IpAddress;
            txtPort.Text = Port.ToString();
            SetupClient();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            const string CONNECT = "Connect";
            const string DISCONNECT = "Disconnect";

            if (btnConnect.Text == CONNECT)
            {
                try
                {
                    client.Connect(IpAddress, Port);
                    client.Write(ServerCommands.TestConnection.ToString());
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

        #endregion

        private void SetupClient()
        {
            client = new SimpleTCP.SimpleTcpClient
            {
                StringEncoder = Encoding.UTF8
            };
            client.DataReceived += Client_DataReceived;
        }
    }
}

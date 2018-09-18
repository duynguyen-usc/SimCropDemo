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
            txtIp.Text = "127.0.0.1";
            txtPort.Text = "8910";
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
                    client.Connect(GetIp(), GetPort());
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
            if (rdoGetInfoAllFields.Checked)
            {
                //client.SendGetInfoAllFiends();
            }
            else if (rdoGetInfoSingleField.Checked)
            {
                //client.SendGetInfoSingleFieldCommand(cbxFieldName.SelectedText);
            }
            else if (rdoPlant.Checked)
            {
                //client.SendPlantCommand(cbxFieldName.SelectedText);
            }
            else if (rdoHarvest.Checked)
            {
                //client.SendHarvestCommand(cbxFieldName.SelectedText);
            }
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            rtxtConsole.Invoke((MethodInvoker)delegate ()
            {
                rtxtConsole.Text += e.MessageString + "\n";
            });
        }

        private string GetIp()
        {
            return System.Net.IPAddress.Parse(txtIp.Text).ToString();
        }
        
        private int GetPort()
        {
            return Convert.ToInt32(txtPort.Text);
        }
        private void ShowWarning(string warning, string title)
        {
            MessageBox.Show(warning, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}

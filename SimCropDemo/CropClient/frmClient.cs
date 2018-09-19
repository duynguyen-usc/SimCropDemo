using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CropServer;

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

            foreach (CropType ct in (CropType[])Enum.GetValues((typeof(CropType))))
            {
                cbxCropType.Items.Add(ct);
            }
            EnableDisableDropDowns();
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
                    client.SendGetInfoAllFieldsCommand();

                    cbxFieldName.Items.Clear();
                    client.LastServerMessage.Fields.ForEach(x => 
                    {
                        cbxFieldName.Items.Add(x.Name);
                    });
                    cbxFieldName.SelectedIndex = 0;
                    btnConnect.Text = DISCONNECT;
                    rtxtConsole.Text += "Connected.\n";
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
                    cbxFieldName.Items.Clear();
                    rtxtConsole.Text += "Disconnected.\n";
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
                client.SendGetInfoAllFieldsCommand();
                client.LastServerMessage.Fields.ForEach(x => 
                {
                    rtxtConsole.Text += x.ToString();
                });
            }
            else if (rdoGetInfoSingleField.Checked)
            {
                client.SendGetInfoSingleFieldCommand(cbxFieldName.SelectedText);
            }
            else if (rdoPlant.Checked)
            {
                CropType ct = new CropType();
                Enum.TryParse<CropType>(cbxCropType.SelectedText, out ct);

                var fieldInfo = new Field
                {
                    Name = cbxFieldName.SelectedText,
                    Crop = new Crop(ct)
                };
                client.SendPlantCommand(fieldInfo);
            }
            else if (rdoHarvest.Checked)
            {
                var fieldInfo = new Field(cbxFieldName.SelectedText);
                client.SendHarvestCommand(fieldInfo);
            }
        }

        private void rdoGetInfoSingleField_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableDropDowns();
        }

        private void rdoHarvest_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableDropDowns();
        }

        private void rdoPlant_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableDropDowns();
        }

        private void rdoGetInfoAllFields_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableDropDowns();
        }

        private void ShowWarning(string warning, string title)
        {
            MessageBox.Show(warning, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        
        private void EnableDisableDropDowns()
        {
            if (rdoGetInfoAllFields.Checked)
            {
                cbxCropType.Enabled = false;
                cbxFieldName.Enabled = false;
            }
            else if (rdoPlant.Checked)
            {
                cbxCropType.Enabled = true;
                cbxFieldName.Enabled = true;
            }
            else
            {
                cbxCropType.Enabled = false;
                cbxFieldName.Enabled = true;
            }
        }

        private string GetIp()
        {
            return System.Net.IPAddress.Parse(txtIp.Text).ToString();
        }

        private int GetPort()
        {
            return Convert.ToInt32(txtPort.Text);
        }
    }
}

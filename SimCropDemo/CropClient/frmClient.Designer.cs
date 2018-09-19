namespace CropClient
{
    partial class frmClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtxtConsole = new System.Windows.Forms.RichTextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpCommands = new System.Windows.Forms.GroupBox();
            this.rdoGetInfoAllFields = new System.Windows.Forms.RadioButton();
            this.rdoHarvest = new System.Windows.Forms.RadioButton();
            this.rdoPlant = new System.Windows.Forms.RadioButton();
            this.rdoGetInfoSingleField = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxFieldName = new System.Windows.Forms.ComboBox();
            this.cbxCropType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(386, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(92, 32);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(368, 110);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(92, 32);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtxtConsole
            // 
            this.rtxtConsole.Location = new System.Drawing.Point(12, 202);
            this.rtxtConsole.Name = "rtxtConsole";
            this.rtxtConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtxtConsole.Size = new System.Drawing.Size(466, 222);
            this.rtxtConsole.TabIndex = 2;
            this.rtxtConsole.Text = "";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(84, 19);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(180, 20);
            this.txtIp.TabIndex = 3;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(302, 19);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(78, 20);
            this.txtPort.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port";
            // 
            // grpCommands
            // 
            this.grpCommands.Controls.Add(this.label4);
            this.grpCommands.Controls.Add(this.cbxCropType);
            this.grpCommands.Controls.Add(this.rdoGetInfoAllFields);
            this.grpCommands.Controls.Add(this.rdoHarvest);
            this.grpCommands.Controls.Add(this.rdoPlant);
            this.grpCommands.Controls.Add(this.rdoGetInfoSingleField);
            this.grpCommands.Controls.Add(this.label3);
            this.grpCommands.Controls.Add(this.cbxFieldName);
            this.grpCommands.Controls.Add(this.btnSend);
            this.grpCommands.Location = new System.Drawing.Point(12, 45);
            this.grpCommands.Name = "grpCommands";
            this.grpCommands.Size = new System.Drawing.Size(466, 151);
            this.grpCommands.TabIndex = 7;
            this.grpCommands.TabStop = false;
            this.grpCommands.Text = "Commands";
            // 
            // rdoGetInfoAllFields
            // 
            this.rdoGetInfoAllFields.AutoSize = true;
            this.rdoGetInfoAllFields.Location = new System.Drawing.Point(26, 19);
            this.rdoGetInfoAllFields.Name = "rdoGetInfoAllFields";
            this.rdoGetInfoAllFields.Size = new System.Drawing.Size(151, 17);
            this.rdoGetInfoAllFields.TabIndex = 7;
            this.rdoGetInfoAllFields.Text = "Get information on all fields";
            this.rdoGetInfoAllFields.UseVisualStyleBackColor = true;
            this.rdoGetInfoAllFields.CheckedChanged += new System.EventHandler(this.rdoGetInfoAllFields_CheckedChanged);
            // 
            // rdoHarvest
            // 
            this.rdoHarvest.AutoSize = true;
            this.rdoHarvest.Location = new System.Drawing.Point(26, 88);
            this.rdoHarvest.Name = "rdoHarvest";
            this.rdoHarvest.Size = new System.Drawing.Size(62, 17);
            this.rdoHarvest.TabIndex = 6;
            this.rdoHarvest.Text = "Harvest";
            this.rdoHarvest.UseVisualStyleBackColor = true;
            this.rdoHarvest.CheckedChanged += new System.EventHandler(this.rdoHarvest_CheckedChanged);
            // 
            // rdoPlant
            // 
            this.rdoPlant.AutoSize = true;
            this.rdoPlant.Location = new System.Drawing.Point(26, 65);
            this.rdoPlant.Name = "rdoPlant";
            this.rdoPlant.Size = new System.Drawing.Size(49, 17);
            this.rdoPlant.TabIndex = 5;
            this.rdoPlant.Text = "Plant";
            this.rdoPlant.UseVisualStyleBackColor = true;
            this.rdoPlant.CheckedChanged += new System.EventHandler(this.rdoPlant_CheckedChanged);
            // 
            // rdoGetInfoSingleField
            // 
            this.rdoGetInfoSingleField.AutoSize = true;
            this.rdoGetInfoSingleField.Checked = true;
            this.rdoGetInfoSingleField.Location = new System.Drawing.Point(26, 42);
            this.rdoGetInfoSingleField.Name = "rdoGetInfoSingleField";
            this.rdoGetInfoSingleField.Size = new System.Drawing.Size(163, 17);
            this.rdoGetInfoSingleField.TabIndex = 4;
            this.rdoGetInfoSingleField.TabStop = true;
            this.rdoGetInfoSingleField.Text = "Get information on single field";
            this.rdoGetInfoSingleField.UseVisualStyleBackColor = true;
            this.rdoGetInfoSingleField.CheckedChanged += new System.EventHandler(this.rdoGetInfoSingleField_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Field Name";
            // 
            // cbxFieldName
            // 
            this.cbxFieldName.FormattingEnabled = true;
            this.cbxFieldName.Location = new System.Drawing.Point(339, 41);
            this.cbxFieldName.Name = "cbxFieldName";
            this.cbxFieldName.Size = new System.Drawing.Size(121, 21);
            this.cbxFieldName.TabIndex = 2;
            // 
            // cbxCropType
            // 
            this.cbxCropType.FormattingEnabled = true;
            this.cbxCropType.Location = new System.Drawing.Point(339, 68);
            this.cbxCropType.Name = "cbxCropType";
            this.cbxCropType.Size = new System.Drawing.Size(121, 21);
            this.cbxCropType.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Crop Type";
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 436);
            this.Controls.Add(this.grpCommands);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.rtxtConsole);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClient";
            this.Text = "Crop Client";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.grpCommands.ResumeLayout(false);
            this.grpCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtxtConsole;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpCommands;
        private System.Windows.Forms.RadioButton rdoGetInfoAllFields;
        private System.Windows.Forms.RadioButton rdoHarvest;
        private System.Windows.Forms.RadioButton rdoPlant;
        private System.Windows.Forms.RadioButton rdoGetInfoSingleField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxFieldName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxCropType;
    }
}
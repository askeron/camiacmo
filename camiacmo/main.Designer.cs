namespace camiacmo
{
    partial class main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMicActive = new System.Windows.Forms.Label();
            this.lblCamActive = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPostWebhookUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGetWebhookUrlWebcamActive = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxGetWebhookUrlWebcamInactive = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxGetWebhookUrlMicrophoneActive = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxGetWebhookUrlMicrophoneInactive = new System.Windows.Forms.TextBox();
            this.checkBoxBeep = new System.Windows.Forms.CheckBox();
            this.checkBoxNotification = new System.Windows.Forms.CheckBox();
            this.checkBoxWebhooks = new System.Windows.Forms.CheckBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMicActive);
            this.groupBox1.Controls.Add(this.lblCamActive);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 89);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "State";
            // 
            // lblMicActive
            // 
            this.lblMicActive.AutoSize = true;
            this.lblMicActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMicActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMicActive.Location = new System.Drawing.Point(111, 50);
            this.lblMicActive.Name = "lblMicActive";
            this.lblMicActive.Size = new System.Drawing.Size(58, 20);
            this.lblMicActive.TabIndex = 9;
            this.lblMicActive.Text = "Active";
            // 
            // lblCamActive
            // 
            this.lblCamActive.AutoSize = true;
            this.lblCamActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCamActive.Location = new System.Drawing.Point(111, 21);
            this.lblCamActive.Name = "lblCamActive";
            this.lblCamActive.Size = new System.Drawing.Size(58, 20);
            this.lblCamActive.TabIndex = 8;
            this.lblCamActive.Text = "Active";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Microphone:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Webcam:";
            // 
            // chkStartup
            // 
            this.chkStartup.AutoSize = true;
            this.chkStartup.Location = new System.Drawing.Point(12, 233);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(143, 17);
            this.chkStartup.TabIndex = 19;
            this.chkStartup.Text = "Run on Windows startup";
            this.chkStartup.UseVisualStyleBackColor = true;
            this.chkStartup.CheckedChanged += new System.EventHandler(this.chkStartup_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "HttpPostWebhookUrl";
            this.label3.Visible = false;
            // 
            // textBoxPostWebhookUrl
            // 
            this.textBoxPostWebhookUrl.Location = new System.Drawing.Point(281, 256);
            this.textBoxPostWebhookUrl.Name = "textBoxPostWebhookUrl";
            this.textBoxPostWebhookUrl.Size = new System.Drawing.Size(529, 20);
            this.textBoxPostWebhookUrl.TabIndex = 21;
            this.textBoxPostWebhookUrl.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Webcam activated";
            // 
            // textBoxGetWebhookUrlWebcamActive
            // 
            this.textBoxGetWebhookUrlWebcamActive.Location = new System.Drawing.Point(6, 43);
            this.textBoxGetWebhookUrlWebcamActive.Name = "textBoxGetWebhookUrlWebcamActive";
            this.textBoxGetWebhookUrlWebcamActive.Size = new System.Drawing.Size(529, 20);
            this.textBoxGetWebhookUrlWebcamActive.TabIndex = 23;
            this.textBoxGetWebhookUrlWebcamActive.TextChanged += new System.EventHandler(this.textBoxGetWebhookUrlWebcamActive_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Webcam deactivated";
            // 
            // textBoxGetWebhookUrlWebcamInactive
            // 
            this.textBoxGetWebhookUrlWebcamInactive.Location = new System.Drawing.Point(6, 82);
            this.textBoxGetWebhookUrlWebcamInactive.Name = "textBoxGetWebhookUrlWebcamInactive";
            this.textBoxGetWebhookUrlWebcamInactive.Size = new System.Drawing.Size(529, 20);
            this.textBoxGetWebhookUrlWebcamInactive.TabIndex = 25;
            this.textBoxGetWebhookUrlWebcamInactive.TextChanged += new System.EventHandler(this.textBoxGetWebhookUrlWebcamInactive_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Microphone activated";
            // 
            // textBoxGetWebhookUrlMicrophoneActive
            // 
            this.textBoxGetWebhookUrlMicrophoneActive.Location = new System.Drawing.Point(6, 121);
            this.textBoxGetWebhookUrlMicrophoneActive.Name = "textBoxGetWebhookUrlMicrophoneActive";
            this.textBoxGetWebhookUrlMicrophoneActive.Size = new System.Drawing.Size(529, 20);
            this.textBoxGetWebhookUrlMicrophoneActive.TabIndex = 27;
            this.textBoxGetWebhookUrlMicrophoneActive.TextChanged += new System.EventHandler(this.textBoxGetWebhookUrlMicrophoneActive_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Microphone deactivated";
            // 
            // textBoxGetWebhookUrlMicrophoneInactive
            // 
            this.textBoxGetWebhookUrlMicrophoneInactive.Location = new System.Drawing.Point(6, 160);
            this.textBoxGetWebhookUrlMicrophoneInactive.Name = "textBoxGetWebhookUrlMicrophoneInactive";
            this.textBoxGetWebhookUrlMicrophoneInactive.Size = new System.Drawing.Size(529, 20);
            this.textBoxGetWebhookUrlMicrophoneInactive.TabIndex = 29;
            this.textBoxGetWebhookUrlMicrophoneInactive.TextChanged += new System.EventHandler(this.textBoxGetWebhookUrlMicrophoneInactive_TextChanged);
            // 
            // checkBoxBeep
            // 
            this.checkBoxBeep.AutoSize = true;
            this.checkBoxBeep.Location = new System.Drawing.Point(11, 108);
            this.checkBoxBeep.Name = "checkBoxBeep";
            this.checkBoxBeep.Size = new System.Drawing.Size(105, 17);
            this.checkBoxBeep.TabIndex = 30;
            this.checkBoxBeep.Text = "Beep on change";
            this.checkBoxBeep.UseVisualStyleBackColor = true;
            this.checkBoxBeep.CheckedChanged += new System.EventHandler(this.checkBoxBeep_CheckedChanged);
            // 
            // checkBoxNotification
            // 
            this.checkBoxNotification.AutoSize = true;
            this.checkBoxNotification.Location = new System.Drawing.Point(11, 132);
            this.checkBoxNotification.Name = "checkBoxNotification";
            this.checkBoxNotification.Size = new System.Drawing.Size(161, 17);
            this.checkBoxNotification.TabIndex = 31;
            this.checkBoxNotification.Text = "Show notification on change";
            this.checkBoxNotification.UseVisualStyleBackColor = true;
            this.checkBoxNotification.CheckedChanged += new System.EventHandler(this.checkBoxNotification_CheckedChanged);
            // 
            // checkBoxWebhooks
            // 
            this.checkBoxWebhooks.AutoSize = true;
            this.checkBoxWebhooks.Checked = true;
            this.checkBoxWebhooks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWebhooks.Location = new System.Drawing.Point(11, 156);
            this.checkBoxWebhooks.Name = "checkBoxWebhooks";
            this.checkBoxWebhooks.Size = new System.Drawing.Size(114, 17);
            this.checkBoxWebhooks.TabIndex = 32;
            this.checkBoxWebhooks.Text = "Enable Webhooks";
            this.checkBoxWebhooks.UseVisualStyleBackColor = true;
            this.checkBoxWebhooks.CheckedChanged += new System.EventHandler(this.checkBoxWebhooks_CheckedChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(11, 257);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 33;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxGetWebhookUrlWebcamActive);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxGetWebhookUrlMicrophoneInactive);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxGetWebhookUrlWebcamInactive);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxGetWebhookUrlMicrophoneActive);
            this.groupBox2.Location = new System.Drawing.Point(275, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 204);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HTTP-Get-Webhook-Urls";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 287);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.checkBoxWebhooks);
            this.Controls.Add(this.checkBoxNotification);
            this.Controls.Add(this.checkBoxBeep);
            this.Controls.Add(this.textBoxPostWebhookUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkStartup);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camiacmo (Camera and Microphone Activity Monitor)";
            this.Load += new System.EventHandler(this.main_Load);
            this.Shown += new System.EventHandler(this.main_Shown);
            this.Resize += new System.EventHandler(this.main_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMicActive;
        private System.Windows.Forms.Label lblCamActive;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPostWebhookUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGetWebhookUrlWebcamActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxGetWebhookUrlWebcamInactive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGetWebhookUrlMicrophoneActive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxGetWebhookUrlMicrophoneInactive;
        private System.Windows.Forms.CheckBox checkBoxBeep;
        private System.Windows.Forms.CheckBox checkBoxNotification;
        private System.Windows.Forms.CheckBox checkBoxWebhooks;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


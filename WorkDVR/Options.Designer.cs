namespace WorkDVR
{
    partial class Options
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
            this.captureFrameEveryLabel = new System.Windows.Forms.Label();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.captureFrameEveryTextBox = new System.Windows.Forms.TextBox();
            this.storeFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.storeFolderLabel = new System.Windows.Forms.Label();
            this.runOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.keepLabel = new System.Windows.Forms.Label();
            this.keepMbRecodingsTextBox = new System.Windows.Forms.TextBox();
            this.mbRecordingsLabel = new System.Windows.Forms.Label();
            this.deleteStoredButton = new System.Windows.Forms.Button();
            this.storeFolderTextBox = new System.Windows.Forms.TextBox();
            this.storeFolderButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.capturingGroupBox = new System.Windows.Forms.GroupBox();
            this.storringGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteOptionsComboBox = new System.Windows.Forms.ComboBox();
            this.licenseGroupBox = new System.Windows.Forms.GroupBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.enterLicKeyTextBox = new System.Windows.Forms.TextBox();
            this.enterLicKeyLabel = new System.Windows.Forms.Label();
            this.buyLicenseLinkLabel = new System.Windows.Forms.LinkLabel();
            this.capturingGroupBox.SuspendLayout();
            this.storringGroupBox.SuspendLayout();
            this.licenseGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // captureFrameEveryLabel
            // 
            this.captureFrameEveryLabel.AutoSize = true;
            this.captureFrameEveryLabel.Location = new System.Drawing.Point(10, 25);
            this.captureFrameEveryLabel.Name = "captureFrameEveryLabel";
            this.captureFrameEveryLabel.Size = new System.Drawing.Size(102, 13);
            this.captureFrameEveryLabel.TabIndex = 1;
            this.captureFrameEveryLabel.Text = "Capture frame every";
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Location = new System.Drawing.Point(164, 25);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(47, 13);
            this.secondsLabel.TabIndex = 3;
            this.secondsLabel.Text = "seconds";
            // 
            // captureFrameEveryTextBox
            // 
            this.captureFrameEveryTextBox.Location = new System.Drawing.Point(118, 22);
            this.captureFrameEveryTextBox.Name = "captureFrameEveryTextBox";
            this.captureFrameEveryTextBox.Size = new System.Drawing.Size(44, 20);
            this.captureFrameEveryTextBox.TabIndex = 2;
            // 
            // storeFolderLabel
            // 
            this.storeFolderLabel.AutoSize = true;
            this.storeFolderLabel.Location = new System.Drawing.Point(10, 55);
            this.storeFolderLabel.Name = "storeFolderLabel";
            this.storeFolderLabel.Size = new System.Drawing.Size(154, 13);
            this.storeFolderLabel.TabIndex = 4;
            this.storeFolderLabel.Text = "Store captured frames in folder:";
            // 
            // runOnStartupCheckBox
            // 
            this.runOnStartupCheckBox.AutoSize = true;
            this.runOnStartupCheckBox.Location = new System.Drawing.Point(15, 20);
            this.runOnStartupCheckBox.Name = "runOnStartupCheckBox";
            this.runOnStartupCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.runOnStartupCheckBox.Size = new System.Drawing.Size(96, 17);
            this.runOnStartupCheckBox.TabIndex = 0;
            this.runOnStartupCheckBox.Text = "Run on startup";
            this.runOnStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // keepLabel
            // 
            this.keepLabel.AutoSize = true;
            this.keepLabel.Location = new System.Drawing.Point(10, 25);
            this.keepLabel.Name = "keepLabel";
            this.keepLabel.Size = new System.Drawing.Size(32, 13);
            this.keepLabel.TabIndex = 7;
            this.keepLabel.Text = "Keep";
            // 
            // keepMbRecodingsTextBox
            // 
            this.keepMbRecodingsTextBox.Location = new System.Drawing.Point(48, 22);
            this.keepMbRecodingsTextBox.Name = "keepMbRecodingsTextBox";
            this.keepMbRecodingsTextBox.Size = new System.Drawing.Size(48, 20);
            this.keepMbRecodingsTextBox.TabIndex = 8;
            // 
            // mbRecordingsLabel
            // 
            this.mbRecordingsLabel.AutoSize = true;
            this.mbRecordingsLabel.Location = new System.Drawing.Point(102, 25);
            this.mbRecordingsLabel.Name = "mbRecordingsLabel";
            this.mbRecordingsLabel.Size = new System.Drawing.Size(87, 13);
            this.mbRecordingsLabel.TabIndex = 9;
            this.mbRecordingsLabel.Text = "MB of recordings";
            // 
            // deleteStoredButton
            // 
            this.deleteStoredButton.Location = new System.Drawing.Point(131, 58);
            this.deleteStoredButton.Name = "deleteStoredButton";
            this.deleteStoredButton.Size = new System.Drawing.Size(130, 23);
            this.deleteStoredButton.TabIndex = 10;
            this.deleteStoredButton.Text = "Delete stored recordings";
            this.deleteStoredButton.UseVisualStyleBackColor = true;
            this.deleteStoredButton.Click += new System.EventHandler(this.deleteStoredButton_Click);
            // 
            // storeFolderTextBox
            // 
            this.storeFolderTextBox.Location = new System.Drawing.Point(13, 80);
            this.storeFolderTextBox.Name = "storeFolderTextBox";
            this.storeFolderTextBox.Size = new System.Drawing.Size(211, 20);
            this.storeFolderTextBox.TabIndex = 5;
            // 
            // storeFolderButton
            // 
            this.storeFolderButton.Location = new System.Drawing.Point(230, 78);
            this.storeFolderButton.Name = "storeFolderButton";
            this.storeFolderButton.Size = new System.Drawing.Size(31, 23);
            this.storeFolderButton.TabIndex = 6;
            this.storeFolderButton.Text = "...";
            this.storeFolderButton.UseVisualStyleBackColor = true;
            this.storeFolderButton.Click += new System.EventHandler(this.storeFolderButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(135, 476);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(214, 476);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // capturingGroupBox
            // 
            this.capturingGroupBox.Controls.Add(this.storeFolderButton);
            this.capturingGroupBox.Controls.Add(this.storeFolderTextBox);
            this.capturingGroupBox.Controls.Add(this.storeFolderLabel);
            this.capturingGroupBox.Controls.Add(this.captureFrameEveryTextBox);
            this.capturingGroupBox.Controls.Add(this.secondsLabel);
            this.capturingGroupBox.Controls.Add(this.captureFrameEveryLabel);
            this.capturingGroupBox.Location = new System.Drawing.Point(15, 50);
            this.capturingGroupBox.Name = "capturingGroupBox";
            this.capturingGroupBox.Size = new System.Drawing.Size(275, 118);
            this.capturingGroupBox.TabIndex = 13;
            this.capturingGroupBox.TabStop = false;
            this.capturingGroupBox.Text = "Capturing";
            // 
            // storringGroupBox
            // 
            this.storringGroupBox.Controls.Add(this.deleteOptionsComboBox);
            this.storringGroupBox.Controls.Add(this.deleteStoredButton);
            this.storringGroupBox.Controls.Add(this.mbRecordingsLabel);
            this.storringGroupBox.Controls.Add(this.keepMbRecodingsTextBox);
            this.storringGroupBox.Controls.Add(this.keepLabel);
            this.storringGroupBox.Location = new System.Drawing.Point(15, 182);
            this.storringGroupBox.Name = "storringGroupBox";
            this.storringGroupBox.Size = new System.Drawing.Size(275, 98);
            this.storringGroupBox.TabIndex = 14;
            this.storringGroupBox.TabStop = false;
            this.storringGroupBox.Text = "Storring";
            // 
            // deleteOptionsComboBox
            // 
            this.deleteOptionsComboBox.FormattingEnabled = true;
            this.deleteOptionsComboBox.Items.AddRange(new object[] {
            "the past hour",
            "the last 24 hours",
            "the last week",
            "everything"});
            this.deleteOptionsComboBox.Location = new System.Drawing.Point(13, 59);
            this.deleteOptionsComboBox.Name = "deleteOptionsComboBox";
            this.deleteOptionsComboBox.Size = new System.Drawing.Size(111, 21);
            this.deleteOptionsComboBox.TabIndex = 11;
            this.deleteOptionsComboBox.SelectedIndexChanged += new System.EventHandler(this.deleteOptionsComboBox_SelectedIndexChanged);
            // 
            // licenseGroupBox
            // 
            this.licenseGroupBox.Controls.Add(this.registerButton);
            this.licenseGroupBox.Controls.Add(this.enterLicKeyTextBox);
            this.licenseGroupBox.Controls.Add(this.enterLicKeyLabel);
            this.licenseGroupBox.Controls.Add(this.buyLicenseLinkLabel);
            this.licenseGroupBox.Location = new System.Drawing.Point(15, 294);
            this.licenseGroupBox.Name = "licenseGroupBox";
            this.licenseGroupBox.Size = new System.Drawing.Size(274, 157);
            this.licenseGroupBox.TabIndex = 15;
            this.licenseGroupBox.TabStop = false;
            this.licenseGroupBox.Text = "License";
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(186, 116);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 3;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // enterLicKeyTextBox
            // 
            this.enterLicKeyTextBox.Location = new System.Drawing.Point(13, 80);
            this.enterLicKeyTextBox.Name = "enterLicKeyTextBox";
            this.enterLicKeyTextBox.Size = new System.Drawing.Size(248, 20);
            this.enterLicKeyTextBox.TabIndex = 2;
            this.enterLicKeyTextBox.TextChanged += new System.EventHandler(this.enterLicKeyTextBox_TextChanged);
            // 
            // enterLicKeyLabel
            // 
            this.enterLicKeyLabel.AutoSize = true;
            this.enterLicKeyLabel.Location = new System.Drawing.Point(10, 55);
            this.enterLicKeyLabel.Name = "enterLicKeyLabel";
            this.enterLicKeyLabel.Size = new System.Drawing.Size(251, 13);
            this.enterLicKeyLabel.TabIndex = 1;
            this.enterLicKeyLabel.Text = "Enter the license key from the purchase e-mail here:";
            // 
            // buyLicenseLinkLabel
            // 
            this.buyLicenseLinkLabel.AutoSize = true;
            this.buyLicenseLinkLabel.Location = new System.Drawing.Point(78, 25);
            this.buyLicenseLinkLabel.Name = "buyLicenseLinkLabel";
            this.buyLicenseLinkLabel.Size = new System.Drawing.Size(120, 13);
            this.buyLicenseLinkLabel.TabIndex = 0;
            this.buyLicenseLinkLabel.TabStop = true;
            this.buyLicenseLinkLabel.Text = "http://www.google.com";
            this.buyLicenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buyLicenseLinkLabel_LinkClicked);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 520);
            this.Controls.Add(this.licenseGroupBox);
            this.Controls.Add(this.storringGroupBox);
            this.Controls.Add(this.capturingGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.runOnStartupCheckBox);
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkDVR Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.VisibleChanged += new System.EventHandler(this.Options_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.capturingGroupBox.ResumeLayout(false);
            this.capturingGroupBox.PerformLayout();
            this.storringGroupBox.ResumeLayout(false);
            this.storringGroupBox.PerformLayout();
            this.licenseGroupBox.ResumeLayout(false);
            this.licenseGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label captureFrameEveryLabel;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.TextBox captureFrameEveryTextBox;
        private System.Windows.Forms.FolderBrowserDialog storeFolderDialog;
        private System.Windows.Forms.Label storeFolderLabel;
        private System.Windows.Forms.CheckBox runOnStartupCheckBox;
        private System.Windows.Forms.Label keepLabel;
        private System.Windows.Forms.TextBox keepMbRecodingsTextBox;
        private System.Windows.Forms.Label mbRecordingsLabel;
        private System.Windows.Forms.Button deleteStoredButton;
        private System.Windows.Forms.TextBox storeFolderTextBox;
        private System.Windows.Forms.Button storeFolderButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox capturingGroupBox;
        private System.Windows.Forms.GroupBox storringGroupBox;
        private System.Windows.Forms.ComboBox deleteOptionsComboBox;
        private System.Windows.Forms.GroupBox licenseGroupBox;
        private System.Windows.Forms.LinkLabel buyLicenseLinkLabel;
        private System.Windows.Forms.Label enterLicKeyLabel;
        private System.Windows.Forms.TextBox enterLicKeyTextBox;
        private System.Windows.Forms.Button registerButton;
    }
}
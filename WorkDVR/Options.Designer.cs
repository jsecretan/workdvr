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
            this.SuspendLayout();
            // 
            // captureFrameEveryLabel
            // 
            this.captureFrameEveryLabel.AutoSize = true;
            this.captureFrameEveryLabel.Location = new System.Drawing.Point(12, 55);
            this.captureFrameEveryLabel.Name = "captureFrameEveryLabel";
            this.captureFrameEveryLabel.Size = new System.Drawing.Size(102, 13);
            this.captureFrameEveryLabel.TabIndex = 1;
            this.captureFrameEveryLabel.Text = "Capture frame every";
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Location = new System.Drawing.Point(177, 55);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(47, 13);
            this.secondsLabel.TabIndex = 3;
            this.secondsLabel.Text = "seconds";
            // 
            // captureFrameEveryTextBox
            // 
            this.captureFrameEveryTextBox.Location = new System.Drawing.Point(123, 52);
            this.captureFrameEveryTextBox.Name = "captureFrameEveryTextBox";
            this.captureFrameEveryTextBox.Size = new System.Drawing.Size(44, 20);
            this.captureFrameEveryTextBox.TabIndex = 2;
            // 
            // storeFolderLabel
            // 
            this.storeFolderLabel.AutoSize = true;
            this.storeFolderLabel.Location = new System.Drawing.Point(12, 90);
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
            this.keepLabel.Location = new System.Drawing.Point(12, 155);
            this.keepLabel.Name = "keepLabel";
            this.keepLabel.Size = new System.Drawing.Size(32, 13);
            this.keepLabel.TabIndex = 7;
            this.keepLabel.Text = "Keep";
            // 
            // keepMbRecodingsTextBox
            // 
            this.keepMbRecodingsTextBox.Location = new System.Drawing.Point(52, 152);
            this.keepMbRecodingsTextBox.Name = "keepMbRecodingsTextBox";
            this.keepMbRecodingsTextBox.Size = new System.Drawing.Size(36, 20);
            this.keepMbRecodingsTextBox.TabIndex = 8;
            // 
            // mbRecordingsLabel
            // 
            this.mbRecordingsLabel.AutoSize = true;
            this.mbRecordingsLabel.Location = new System.Drawing.Point(97, 155);
            this.mbRecordingsLabel.Name = "mbRecordingsLabel";
            this.mbRecordingsLabel.Size = new System.Drawing.Size(87, 13);
            this.mbRecordingsLabel.TabIndex = 9;
            this.mbRecordingsLabel.Text = "MB of recordings";
            // 
            // deleteStoredButton
            // 
            this.deleteStoredButton.Location = new System.Drawing.Point(12, 194);
            this.deleteStoredButton.Name = "deleteStoredButton";
            this.deleteStoredButton.Size = new System.Drawing.Size(130, 23);
            this.deleteStoredButton.TabIndex = 10;
            this.deleteStoredButton.Text = "Delete stored recordings";
            this.deleteStoredButton.UseVisualStyleBackColor = true;
            // 
            // storeFolderTextBox
            // 
            this.storeFolderTextBox.Location = new System.Drawing.Point(15, 115);
            this.storeFolderTextBox.Name = "storeFolderTextBox";
            this.storeFolderTextBox.Size = new System.Drawing.Size(211, 20);
            this.storeFolderTextBox.TabIndex = 5;
            // 
            // storeFolderButton
            // 
            this.storeFolderButton.Location = new System.Drawing.Point(232, 115);
            this.storeFolderButton.Name = "storeFolderButton";
            this.storeFolderButton.Size = new System.Drawing.Size(31, 23);
            this.storeFolderButton.TabIndex = 6;
            this.storeFolderButton.Text = "...";
            this.storeFolderButton.UseVisualStyleBackColor = true;
            this.storeFolderButton.Click += new System.EventHandler(this.storeFolderButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(109, 261);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(188, 261);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 305);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.storeFolderButton);
            this.Controls.Add(this.deleteStoredButton);
            this.Controls.Add(this.mbRecordingsLabel);
            this.Controls.Add(this.storeFolderTextBox);
            this.Controls.Add(this.keepMbRecodingsTextBox);
            this.Controls.Add(this.keepLabel);
            this.Controls.Add(this.runOnStartupCheckBox);
            this.Controls.Add(this.storeFolderLabel);
            this.Controls.Add(this.captureFrameEveryTextBox);
            this.Controls.Add(this.secondsLabel);
            this.Controls.Add(this.captureFrameEveryLabel);
            this.Name = "Options";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkDVR Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.VisibleChanged += new System.EventHandler(this.Options_VisibleChanged);
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
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
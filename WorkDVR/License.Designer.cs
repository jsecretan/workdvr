namespace WorkDVR
{
    partial class License
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
            this.registerButton = new System.Windows.Forms.Button();
            this.enterLicKeyTextBox = new System.Windows.Forms.TextBox();
            this.enterLicKeyLabel = new System.Windows.Forms.Label();
            this.buyLicenseLinkLabel = new System.Windows.Forms.LinkLabel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registerButton
            // 
            this.registerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.registerButton.Location = new System.Drawing.Point(230, 177);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 5;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // enterLicKeyTextBox
            // 
            this.enterLicKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.enterLicKeyTextBox.Location = new System.Drawing.Point(15, 130);
            this.enterLicKeyTextBox.Name = "enterLicKeyTextBox";
            this.enterLicKeyTextBox.Size = new System.Drawing.Size(371, 20);
            this.enterLicKeyTextBox.TabIndex = 4;
            this.enterLicKeyTextBox.TextChanged += new System.EventHandler(this.enterLicKeyTextBox_TextChanged);
            // 
            // enterLicKeyLabel
            // 
            this.enterLicKeyLabel.AutoSize = true;
            this.enterLicKeyLabel.Location = new System.Drawing.Point(12, 20);
            this.enterLicKeyLabel.Name = "enterLicKeyLabel";
            this.enterLicKeyLabel.Size = new System.Drawing.Size(361, 13);
            this.enterLicKeyLabel.TabIndex = 0;
            this.enterLicKeyLabel.Text = "The trial period has ended. The software will no longer record screen shots.";
            // 
            // buyLicenseLinkLabel
            // 
            this.buyLicenseLinkLabel.AutoSize = true;
            this.buyLicenseLinkLabel.Location = new System.Drawing.Point(137, 70);
            this.buyLicenseLinkLabel.Name = "buyLicenseLinkLabel";
            this.buyLicenseLinkLabel.Size = new System.Drawing.Size(120, 13);
            this.buyLicenseLinkLabel.TabIndex = 2;
            this.buyLicenseLinkLabel.TabStop = true;
            this.buyLicenseLinkLabel.Text = "http://www.google.com";
            this.buyLicenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buyLicenseLinkLabel_LinkClicked);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(311, 177);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Later";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "If you like the software, please purchase the it by clicking here:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter the license key from the purchase e-mail here:";
            // 
            // License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 219);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.enterLicKeyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enterLicKeyLabel);
            this.Controls.Add(this.buyLicenseLinkLabel);
            this.Name = "License";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License";
            this.Load += new System.EventHandler(this.License_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.TextBox enterLicKeyTextBox;
        private System.Windows.Forms.Label enterLicKeyLabel;
        private System.Windows.Forms.LinkLabel buyLicenseLinkLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
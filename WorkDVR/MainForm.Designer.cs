namespace WorkDVR
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.recordingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPlaybackMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameTimeLabel = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.playLabel = new System.Windows.Forms.Label();
            this.pauseLabel = new System.Windows.Forms.Label();
            this.forwardFrameLabel = new System.Windows.Forms.Label();
            this.backFrameLabel = new System.Windows.Forms.Label();
            this.rewindLabel = new System.Windows.Forms.Label();
            this.fastForwardLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.showImagePictureBox = new System.Windows.Forms.PictureBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.rewindButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "WorkDVR";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordingMenuItem,
            this.optionsMenuItem,
            this.showPlaybackMenuItem,
            this.exitMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(156, 92);
            // 
            // recordingMenuItem
            // 
            this.recordingMenuItem.Name = "recordingMenuItem";
            this.recordingMenuItem.Size = new System.Drawing.Size(155, 22);
            this.recordingMenuItem.Text = "Start Recording";
            this.recordingMenuItem.Click += new System.EventHandler(this.recordingMenuItem_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(155, 22);
            this.optionsMenuItem.Text = "Options";
            this.optionsMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
            // 
            // showPlaybackMenuItem
            // 
            this.showPlaybackMenuItem.Name = "showPlaybackMenuItem";
            this.showPlaybackMenuItem.Size = new System.Drawing.Size(155, 22);
            this.showPlaybackMenuItem.Text = "Show Playback";
            this.showPlaybackMenuItem.Click += new System.EventHandler(this.showPlaybackMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // frameTimeLabel
            // 
            this.frameTimeLabel.AutoSize = true;
            this.frameTimeLabel.Location = new System.Drawing.Point(12, 10);
            this.frameTimeLabel.Name = "frameTimeLabel";
            this.frameTimeLabel.Size = new System.Drawing.Size(76, 13);
            this.frameTimeLabel.TabIndex = 0;
            this.frameTimeLabel.Text = "Desktop from: ";
            // 
            // trackBar
            // 
            this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar.AutoSize = false;
            this.trackBar.Location = new System.Drawing.Point(15, 329);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(512, 45);
            this.trackBar.TabIndex = 1;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // playLabel
            // 
            this.playLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playLabel.AutoSize = true;
            this.playLabel.Location = new System.Drawing.Point(258, 418);
            this.playLabel.Name = "playLabel";
            this.playLabel.Size = new System.Drawing.Size(27, 13);
            this.playLabel.TabIndex = 5;
            this.playLabel.Text = "Play";
            // 
            // pauseLabel
            // 
            this.pauseLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pauseLabel.AutoSize = true;
            this.pauseLabel.Location = new System.Drawing.Point(253, 418);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(37, 13);
            this.pauseLabel.TabIndex = 6;
            this.pauseLabel.Text = "Pause";
            // 
            // forwardFrameLabel
            // 
            this.forwardFrameLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.forwardFrameLabel.AutoSize = true;
            this.forwardFrameLabel.Location = new System.Drawing.Point(309, 418);
            this.forwardFrameLabel.Name = "forwardFrameLabel";
            this.forwardFrameLabel.Size = new System.Drawing.Size(86, 13);
            this.forwardFrameLabel.TabIndex = 7;
            this.forwardFrameLabel.Text = "Forward 1 Frame";
            // 
            // backFrameLabel
            // 
            this.backFrameLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.backFrameLabel.AutoSize = true;
            this.backFrameLabel.Location = new System.Drawing.Point(154, 418);
            this.backFrameLabel.Name = "backFrameLabel";
            this.backFrameLabel.Size = new System.Drawing.Size(73, 13);
            this.backFrameLabel.TabIndex = 7;
            this.backFrameLabel.Text = "Back 1 Frame";
            // 
            // rewindLabel
            // 
            this.rewindLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rewindLabel.AutoSize = true;
            this.rewindLabel.Location = new System.Drawing.Point(169, 418);
            this.rewindLabel.Name = "rewindLabel";
            this.rewindLabel.Size = new System.Drawing.Size(43, 13);
            this.rewindLabel.TabIndex = 7;
            this.rewindLabel.Text = "Rewind";
            // 
            // fastForwardLabel
            // 
            this.fastForwardLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fastForwardLabel.AutoSize = true;
            this.fastForwardLabel.Location = new System.Drawing.Point(318, 418);
            this.fastForwardLabel.Name = "fastForwardLabel";
            this.fastForwardLabel.Size = new System.Drawing.Size(68, 13);
            this.fastForwardLabel.TabIndex = 7;
            this.fastForwardLabel.Text = "Fast Forward";
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(58, 385);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(77, 13);
            this.speedLabel.TabIndex = 8;
            this.speedLabel.Text = "Speed: Normal";
            // 
            // showImagePictureBox
            // 
            this.showImagePictureBox.AccessibleName = "replayBox";
            this.showImagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.showImagePictureBox.BackColor = System.Drawing.Color.Black;
            this.showImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.showImagePictureBox.Location = new System.Drawing.Point(15, 30);
            this.showImagePictureBox.Name = "showImagePictureBox";
            this.showImagePictureBox.Size = new System.Drawing.Size(512, 288);
            this.showImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showImagePictureBox.TabIndex = 0;
            this.showImagePictureBox.TabStop = false;
            this.showImagePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.showImagePictureBox_Paint);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nextButton.Image = global::WorkDVR.Properties.Resources.Next;
            this.nextButton.Location = new System.Drawing.Point(315, 374);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 35);
            this.nextButton.TabIndex = 4;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.forwardButton.Image = global::WorkDVR.Properties.Resources.Forward;
            this.forwardButton.Location = new System.Drawing.Point(315, 374);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(75, 35);
            this.forwardButton.TabIndex = 4;
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // playButton
            // 
            this.playButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playButton.Image = global::WorkDVR.Properties.Resources.Play;
            this.playButton.Location = new System.Drawing.Point(234, 374);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 35);
            this.playButton.TabIndex = 3;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // rewindButton
            // 
            this.rewindButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rewindButton.Image = ((System.Drawing.Image)(resources.GetObject("rewindButton.Image")));
            this.rewindButton.Location = new System.Drawing.Point(153, 374);
            this.rewindButton.Name = "rewindButton";
            this.rewindButton.Size = new System.Drawing.Size(75, 35);
            this.rewindButton.TabIndex = 2;
            this.rewindButton.UseVisualStyleBackColor = true;
            this.rewindButton.Click += new System.EventHandler(this.rewindButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.prevButton.Image = ((System.Drawing.Image)(resources.GetObject("prevButton.Image")));
            this.prevButton.Location = new System.Drawing.Point(153, 374);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(75, 35);
            this.prevButton.TabIndex = 2;
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pauseButton.Image = global::WorkDVR.Properties.Resources.Pause;
            this.pauseButton.Location = new System.Drawing.Point(234, 374);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 35);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Visible = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 449);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.rewindLabel);
            this.Controls.Add(this.backFrameLabel);
            this.Controls.Add(this.fastForwardLabel);
            this.Controls.Add(this.forwardFrameLabel);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.showImagePictureBox);
            this.Controls.Add(this.frameTimeLabel);
            this.Controls.Add(this.playLabel);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.rewindButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.pauseButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkDVR Replay";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox showImagePictureBox;
        private System.Windows.Forms.Button rewindButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem recordingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPlaybackMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.Label frameTimeLabel;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label playLabel;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Label forwardFrameLabel;
        private System.Windows.Forms.Label backFrameLabel;
        private System.Windows.Forms.Label rewindLabel;
        private System.Windows.Forms.Label fastForwardLabel;
        private System.Windows.Forms.Label speedLabel;
    }
}


using System.Windows.Forms;
using System.Windows.Media.Effects;

namespace AudioPlayer
{
    partial class FormUI
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
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUI));
            this.openLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNetworkStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playYouTubeUrlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMultipleFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.xuiButton1 = new XanderUI.XUIButton();
            this.xuiButton2 = new XanderUI.XUIButton();
            this.playButton = new XanderUI.XUIButton();
            this.endButton = new XanderUI.XUIButton();
            this.restartButton = new XanderUI.XUIButton();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.pauseButton = new XanderUI.XUIButton();
            this.muteButton = new XanderUI.XUIButton();
            this.unmuteButton = new XanderUI.XUIButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.playYoutubeXUIButton = new XanderUI.XUIButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.hintLabel = new System.Windows.Forms.Label();
            this.youtubeTextBox = new System.Windows.Forms.TextBox();
            this.playYoutubeButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.coverImagePanel = new System.Windows.Forms.Panel();
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.YoutubeQueryBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.YoutubeUrlsBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.playlistPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.songAndArtistNamePanel = new System.Windows.Forms.Panel();
            this.visualizationPanel = new System.Windows.Forms.Panel();
            this.spectrumAnalyser = new System.Windows.Forms.Integration.ElementHost();
            this.spectrumAnalyser1 = new AudioPlayer.SpectrumAnalyser();
            this.coverPictureBox = new AudioPlayer.RoundedPictureBox();
            this.progressBarSlider = new AudioPlayer.ProgressBarSlider();
            this.volumeSlider = new AudioPlayer.TrackSlider();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.coverImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            this.playlistPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.songAndArtistNamePanel.SuspendLayout();
            this.visualizationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLocalToolStripMenuItem,
            this.openNetworkStreamToolStripMenuItem,
            this.playYouTubeUrlsToolStripMenuItem,
            this.openRecentToolStripMenuItem,
            this.openMultipleFilesToolStripMenuItem,
            this.exitToolStripMenuItem});
            fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            fileToolStripMenuItem.Text = "Play";
            // 
            // openLocalToolStripMenuItem
            // 
            this.openLocalToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.openLocalToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openLocalToolStripMenuItem.Name = "openLocalToolStripMenuItem";
            this.openLocalToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.openLocalToolStripMenuItem.Text = "Open File";
            this.openLocalToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openNetworkStreamToolStripMenuItem
            // 
            this.openNetworkStreamToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.openNetworkStreamToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openNetworkStreamToolStripMenuItem.Name = "openNetworkStreamToolStripMenuItem";
            this.openNetworkStreamToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.openNetworkStreamToolStripMenuItem.Text = "Open Network Stream";
            this.openNetworkStreamToolStripMenuItem.Click += new System.EventHandler(this.openNetworkStreamToolStripMenuItem_Click);
            // 
            // playYouTubeUrlsToolStripMenuItem
            // 
            this.playYouTubeUrlsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.playYouTubeUrlsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.playYouTubeUrlsToolStripMenuItem.Name = "playYouTubeUrlsToolStripMenuItem";
            this.playYouTubeUrlsToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.playYouTubeUrlsToolStripMenuItem.Text = "Play From YouTube URL";
            this.playYouTubeUrlsToolStripMenuItem.Click += new System.EventHandler(this.playFromYouTubeUrlToolStripMenuItem_Click);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.openRecentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearRecentToolStripMenuItem});
            this.openRecentToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.openRecentToolStripMenuItem.Text = "Open Recent";
            // 
            // clearRecentToolStripMenuItem
            // 
            this.clearRecentToolStripMenuItem.Name = "clearRecentToolStripMenuItem";
            this.clearRecentToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.clearRecentToolStripMenuItem.Text = "Clear Recent";
            this.clearRecentToolStripMenuItem.Click += new System.EventHandler(this.clearRecentToolStripMenuItem_Click);
            // 
            // openMultipleFilesToolStripMenuItem
            // 
            this.openMultipleFilesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.openMultipleFilesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openMultipleFilesToolStripMenuItem.Name = "openMultipleFilesToolStripMenuItem";
            this.openMultipleFilesToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.openMultipleFilesToolStripMenuItem.Text = "Play Mutiple";
            this.openMultipleFilesToolStripMenuItem.Click += new System.EventHandler(this.playMultipleToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.controlPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.controlPanel.Controls.Add(this.volumeLabel);
            this.controlPanel.Controls.Add(this.xuiButton1);
            this.controlPanel.Controls.Add(this.xuiButton2);
            this.controlPanel.Controls.Add(this.playButton);
            this.controlPanel.Controls.Add(this.endButton);
            this.controlPanel.Controls.Add(this.restartButton);
            this.controlPanel.Controls.Add(this.progressBarSlider);
            this.controlPanel.Controls.Add(this.totalTimeLabel);
            this.controlPanel.Controls.Add(this.volumeSlider);
            this.controlPanel.Controls.Add(this.elapsedTimeLabel);
            this.controlPanel.Controls.Add(this.pauseButton);
            this.controlPanel.Controls.Add(this.muteButton);
            this.controlPanel.Controls.Add(this.unmuteButton);
            this.controlPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(185)))), ((int)(((byte)(128)))));
            this.controlPanel.Location = new System.Drawing.Point(0, 767);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(1827, 102);
            this.controlPanel.TabIndex = 2;
            // 
            // volumeLabel
            // 
            this.volumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.BackColor = System.Drawing.Color.Transparent;
            this.volumeLabel.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeLabel.ForeColor = System.Drawing.Color.White;
            this.volumeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.volumeLabel.Location = new System.Drawing.Point(375, 63);
            this.volumeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.volumeLabel.Size = new System.Drawing.Size(33, 20);
            this.volumeLabel.TabIndex = 23;
            this.volumeLabel.Text = "100";
            // 
            // xuiButton1
            // 
            this.xuiButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.xuiButton1.ButtonImage = global::AudioPlayer.Properties.Resources.play_next_icon;
            this.xuiButton1.ButtonStyle = XanderUI.XUIButton.Style.Material;
            this.xuiButton1.ButtonText = "Button";
            this.xuiButton1.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuiButton1.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuiButton1.CornerRadius = 10;
            this.xuiButton1.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuiButton1.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuiButton1.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.xuiButton1.Location = new System.Drawing.Point(941, 31);
            this.xuiButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xuiButton1.Name = "xuiButton1";
            this.xuiButton1.Size = new System.Drawing.Size(67, 62);
            this.xuiButton1.TabIndex = 19;
            this.xuiButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuiButton1.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // xuiButton2
            // 
            this.xuiButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.xuiButton2.ButtonImage = global::AudioPlayer.Properties.Resources.play_previous_icon;
            this.xuiButton2.ButtonStyle = XanderUI.XUIButton.Style.Material;
            this.xuiButton2.ButtonText = "Button";
            this.xuiButton2.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuiButton2.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuiButton2.CornerRadius = 10;
            this.xuiButton2.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton2.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuiButton2.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuiButton2.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.xuiButton2.Location = new System.Drawing.Point(792, 31);
            this.xuiButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xuiButton2.Name = "xuiButton2";
            this.xuiButton2.Size = new System.Drawing.Size(67, 62);
            this.xuiButton2.TabIndex = 20;
            this.xuiButton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuiButton2.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton2.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // playButton
            // 
            this.playButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.playButton.ButtonImage = global::AudioPlayer.Properties.Resources.play_icon;
            this.playButton.ButtonStyle = XanderUI.XUIButton.Style.Material;
            this.playButton.ButtonText = "Button";
            this.playButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.playButton.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.playButton.CornerRadius = 10;
            this.playButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.playButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.playButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.playButton.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.playButton.Location = new System.Drawing.Point(867, 31);
            this.playButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(67, 62);
            this.playButton.TabIndex = 18;
            this.playButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.playButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // endButton
            // 
            this.endButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.endButton.ButtonImage = global::AudioPlayer.Properties.Resources.stop_icon;
            this.endButton.ButtonStyle = XanderUI.XUIButton.Style.Material;
            this.endButton.ButtonText = "";
            this.endButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.endButton.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.endButton.CornerRadius = 10;
            this.endButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.endButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.endButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.endButton.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.endButton.Location = new System.Drawing.Point(11, 52);
            this.endButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(47, 43);
            this.endButton.TabIndex = 16;
            this.endButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.endButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.restartButton.ButtonImage = global::AudioPlayer.Properties.Resources.replay_icon;
            this.restartButton.ButtonStyle = XanderUI.XUIButton.Style.Material;
            this.restartButton.ButtonText = "Button";
            this.restartButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.restartButton.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.restartButton.CornerRadius = 10;
            this.restartButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.restartButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.restartButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.restartButton.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.restartButton.Location = new System.Drawing.Point(65, 52);
            this.restartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(47, 43);
            this.restartButton.TabIndex = 15;
            this.restartButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.restartButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // totalTimeLabel
            // 
            this.totalTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.totalTimeLabel.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTimeLabel.ForeColor = System.Drawing.Color.White;
            this.totalTimeLabel.Location = new System.Drawing.Point(1739, 0);
            this.totalTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.totalTimeLabel.Size = new System.Drawing.Size(88, 25);
            this.totalTimeLabel.TabIndex = 10;
            this.totalTimeLabel.Text = "0:00";
            this.totalTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.elapsedTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.elapsedTimeLabel.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTimeLabel.ForeColor = System.Drawing.Color.White;
            this.elapsedTimeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(-4, 0);
            this.elapsedTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.elapsedTimeLabel.Size = new System.Drawing.Size(88, 25);
            this.elapsedTimeLabel.TabIndex = 4;
            this.elapsedTimeLabel.Text = "0:00";
            this.elapsedTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pauseButton
            // 
            this.pauseButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pauseButton.ButtonImage = global::AudioPlayer.Properties.Resources.pause_icon;
            this.pauseButton.ButtonStyle = XanderUI.XUIButton.Style.Material;
            this.pauseButton.ButtonText = "Button";
            this.pauseButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.pauseButton.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.pauseButton.CornerRadius = 10;
            this.pauseButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.pauseButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.pauseButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.pauseButton.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.pauseButton.Location = new System.Drawing.Point(867, 31);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(67, 62);
            this.pauseButton.TabIndex = 17;
            this.pauseButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.pauseButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // muteButton
            // 
            this.muteButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.muteButton.ButtonImage = global::AudioPlayer.Properties.Resources.volume_icon;
            this.muteButton.ButtonStyle = XanderUI.XUIButton.Style.Material;
            this.muteButton.ButtonText = "Button";
            this.muteButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.muteButton.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.muteButton.CornerRadius = 10;
            this.muteButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.muteButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.muteButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.muteButton.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.muteButton.Location = new System.Drawing.Point(121, 52);
            this.muteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(47, 43);
            this.muteButton.TabIndex = 22;
            this.muteButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.muteButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.muteButton.Click += new System.EventHandler(this.muteButton_Click);
            // 
            // unmuteButton
            // 
            this.unmuteButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unmuteButton.ButtonImage = global::AudioPlayer.Properties.Resources.muted_icon;
            this.unmuteButton.ButtonStyle = XanderUI.XUIButton.Style.Material;
            this.unmuteButton.ButtonText = "Button";
            this.unmuteButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.unmuteButton.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.unmuteButton.CornerRadius = 10;
            this.unmuteButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.unmuteButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.unmuteButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.unmuteButton.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.unmuteButton.Location = new System.Drawing.Point(121, 52);
            this.unmuteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.unmuteButton.Name = "unmuteButton";
            this.unmuteButton.Size = new System.Drawing.Size(47, 43);
            this.unmuteButton.TabIndex = 21;
            this.unmuteButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.unmuteButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.unmuteButton.Click += new System.EventHandler(this.unmuteButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 31);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.menuStrip.Size = new System.Drawing.Size(52, 26);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.bottomPanel.Controls.Add(this.playYoutubeXUIButton);
            this.bottomPanel.Controls.Add(this.pictureBox1);
            this.bottomPanel.Controls.Add(this.panel2);
            this.bottomPanel.Controls.Add(this.playYoutubeButton);
            this.bottomPanel.Controls.Add(this.menuStrip);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomPanel.ForeColor = System.Drawing.Color.White;
            this.bottomPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1827, 63);
            this.bottomPanel.TabIndex = 3;
            // 
            // playYoutubeXUIButton
            // 
            this.playYoutubeXUIButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.playYoutubeXUIButton.ButtonImage = null;
            this.playYoutubeXUIButton.ButtonStyle = XanderUI.XUIButton.Style.Material;
            this.playYoutubeXUIButton.ButtonText = "Play";
            this.playYoutubeXUIButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.playYoutubeXUIButton.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.playYoutubeXUIButton.CornerRadius = 10;
            this.playYoutubeXUIButton.Enabled = false;
            this.playYoutubeXUIButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playYoutubeXUIButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.playYoutubeXUIButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.playYoutubeXUIButton.HoverTextColor = System.Drawing.Color.White;
            this.playYoutubeXUIButton.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.playYoutubeXUIButton.Location = new System.Drawing.Point(1713, 14);
            this.playYoutubeXUIButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playYoutubeXUIButton.Name = "playYoutubeXUIButton";
            this.playYoutubeXUIButton.Size = new System.Drawing.Size(100, 36);
            this.playYoutubeXUIButton.TabIndex = 24;
            this.playYoutubeXUIButton.TextColor = System.Drawing.Color.DarkGray;
            this.playYoutubeXUIButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.playYoutubeXUIButton.EnabledChanged += new System.EventHandler(this.playYoutubeXUIButton_EnabledChanged);
            this.playYoutubeXUIButton.Click += new System.EventHandler(this.playYoutubeButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AudioPlayer.Properties.Resources.youtube_logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1243, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 36);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel2.Controls.Add(this.hintLabel);
            this.panel2.Controls.Add(this.youtubeTextBox);
            this.panel2.Location = new System.Drawing.Point(1312, 14);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 36);
            this.panel2.TabIndex = 26;
            // 
            // hintLabel
            // 
            this.hintLabel.AutoSize = true;
            this.hintLabel.BackColor = System.Drawing.Color.Transparent;
            this.hintLabel.Enabled = false;
            this.hintLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hintLabel.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintLabel.ForeColor = System.Drawing.Color.DimGray;
            this.hintLabel.Location = new System.Drawing.Point(9, 7);
            this.hintLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(139, 21);
            this.hintLabel.TabIndex = 27;
            this.hintLabel.Text = "Enter song name";
            // 
            // youtubeTextBox
            // 
            this.youtubeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.youtubeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.youtubeTextBox.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.youtubeTextBox.ForeColor = System.Drawing.Color.White;
            this.youtubeTextBox.Location = new System.Drawing.Point(8, 7);
            this.youtubeTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.youtubeTextBox.Name = "youtubeTextBox";
            this.youtubeTextBox.Size = new System.Drawing.Size(361, 20);
            this.youtubeTextBox.TabIndex = 6;
            this.youtubeTextBox.TextChanged += new System.EventHandler(this.youtubeTextBox_TextChanged);
            // 
            // playYoutubeButton
            // 
            this.playYoutubeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playYoutubeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.playYoutubeButton.Enabled = false;
            this.playYoutubeButton.FlatAppearance.BorderSize = 0;
            this.playYoutubeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playYoutubeButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playYoutubeButton.ForeColor = System.Drawing.Color.White;
            this.playYoutubeButton.Location = new System.Drawing.Point(1067, 14);
            this.playYoutubeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playYoutubeButton.Name = "playYoutubeButton";
            this.playYoutubeButton.Size = new System.Drawing.Size(100, 36);
            this.playYoutubeButton.TabIndex = 2;
            this.playYoutubeButton.Text = "Play";
            this.playYoutubeButton.UseVisualStyleBackColor = false;
            this.playYoutubeButton.Visible = false;
            this.playYoutubeButton.Click += new System.EventHandler(this.playYoutubeButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.titleLabel.Size = new System.Drawing.Size(968, 46);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "Song Name";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleLabel.Visible = false;
            // 
            // artistLabel
            // 
            this.artistLabel.BackColor = System.Drawing.Color.Transparent;
            this.artistLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.artistLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistLabel.ForeColor = System.Drawing.Color.White;
            this.artistLabel.Location = new System.Drawing.Point(0, 57);
            this.artistLabel.Margin = new System.Windows.Forms.Padding(0);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(968, 25);
            this.artistLabel.TabIndex = 14;
            this.artistLabel.Text = "Artist Name";
            this.artistLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.artistLabel.Visible = false;
            // 
            // coverImagePanel
            // 
            this.coverImagePanel.BackColor = System.Drawing.Color.Transparent;
            this.coverImagePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("coverImagePanel.BackgroundImage")));
            this.coverImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.coverImagePanel.Controls.Add(this.coverPictureBox);
            this.coverImagePanel.Location = new System.Drawing.Point(327, 82);
            this.coverImagePanel.Margin = new System.Windows.Forms.Padding(0);
            this.coverImagePanel.Name = "coverImagePanel";
            this.coverImagePanel.Size = new System.Drawing.Size(315, 283);
            this.coverImagePanel.TabIndex = 15;
            this.coverImagePanel.Visible = false;
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.loadingPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("loadingPictureBox.Image")));
            this.loadingPictureBox.Location = new System.Drawing.Point(840, 1);
            this.loadingPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(117, 103);
            this.loadingPictureBox.TabIndex = 33;
            this.loadingPictureBox.TabStop = false;
            this.loadingPictureBox.Visible = false;
            // 
            // YoutubeQueryBackgroundWorker
            // 
            this.YoutubeQueryBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.YoutubeQueryBackgroundWorker_DoWork);
            this.YoutubeQueryBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.YoutubeQueryBackgroundWorker_RunWorkerCompleted);
            // 
            // YoutubeUrlsBackgroundWorker
            // 
            this.YoutubeUrlsBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.YoutubeUrlsBackgroundWorker_DoWork);
            this.YoutubeUrlsBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.YoutubeUrlsBackgroundWorker_RunWorkerCompleted);
            // 
            // playlistPanel
            // 
            this.playlistPanel.BackColor = System.Drawing.Color.Transparent;
            this.playlistPanel.Controls.Add(this.flowLayoutPanel2);
            this.playlistPanel.Controls.Add(this.panel1);
            this.playlistPanel.Controls.Add(this.panel3);
            this.playlistPanel.Location = new System.Drawing.Point(0, 60);
            this.playlistPanel.Margin = new System.Windows.Forms.Padding(0);
            this.playlistPanel.Name = "playlistPanel";
            this.playlistPanel.Size = new System.Drawing.Size(1827, 373);
            this.playlistPanel.TabIndex = 35;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1397, 2);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(429, 367);
            this.flowLayoutPanel2.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 373);
            this.panel1.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.songAndArtistNamePanel);
            this.panel3.Controls.Add(this.coverImagePanel);
            this.panel3.Location = new System.Drawing.Point(429, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(968, 369);
            this.panel3.TabIndex = 19;
            // 
            // songAndArtistNamePanel
            // 
            this.songAndArtistNamePanel.Controls.Add(this.titleLabel);
            this.songAndArtistNamePanel.Controls.Add(this.artistLabel);
            this.songAndArtistNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.songAndArtistNamePanel.Location = new System.Drawing.Point(0, 0);
            this.songAndArtistNamePanel.Margin = new System.Windows.Forms.Padding(0);
            this.songAndArtistNamePanel.Name = "songAndArtistNamePanel";
            this.songAndArtistNamePanel.Size = new System.Drawing.Size(968, 82);
            this.songAndArtistNamePanel.TabIndex = 18;
            // 
            // visualizationPanel
            // 
            this.visualizationPanel.BackColor = System.Drawing.Color.Transparent;
            this.visualizationPanel.Controls.Add(this.loadingPictureBox);
            this.visualizationPanel.Controls.Add(this.spectrumAnalyser);
            this.visualizationPanel.Location = new System.Drawing.Point(0, 433);
            this.visualizationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.visualizationPanel.Name = "visualizationPanel";
            this.visualizationPanel.Size = new System.Drawing.Size(1827, 334);
            this.visualizationPanel.TabIndex = 36;
            // 
            // spectrumAnalyser
            // 
            this.spectrumAnalyser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spectrumAnalyser.Location = new System.Drawing.Point(0, 0);
            this.spectrumAnalyser.Margin = new System.Windows.Forms.Padding(4);
            this.spectrumAnalyser.Name = "spectrumAnalyser";
            this.spectrumAnalyser.Size = new System.Drawing.Size(1827, 334);
            this.spectrumAnalyser.TabIndex = 0;
            this.spectrumAnalyser.Text = "spectrumAnalyser";
            this.spectrumAnalyser.Child = this.spectrumAnalyser1;
            // 
            // coverPictureBox
            // 
            this.coverPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coverPictureBox.BackColor = System.Drawing.Color.White;
            this.coverPictureBox.BackgroundImage = global::AudioPlayer.Properties.Resources.default_thumbnail;
            this.coverPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.coverPictureBox.Location = new System.Drawing.Point(20, 23);
            this.coverPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.coverPictureBox.Name = "coverPictureBox";
            this.coverPictureBox.Size = new System.Drawing.Size(268, 238);
            this.coverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coverPictureBox.TabIndex = 0;
            this.coverPictureBox.TabStop = false;
            // 
            // progressBarSlider
            // 
            this.progressBarSlider.AllowQuickTracking = true;
            this.progressBarSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.progressBarSlider.BackgroundBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.progressBarSlider.BarHeight = 4;
            this.progressBarSlider.Enabled = false;
            this.progressBarSlider.FilledBarColor = System.Drawing.Color.White;
            this.progressBarSlider.ForeColor = System.Drawing.Color.Transparent;
            this.progressBarSlider.KnobImage = global::AudioPlayer.Properties.Resources.knob_white;
            this.progressBarSlider.Location = new System.Drawing.Point(92, 6);
            this.progressBarSlider.Margin = new System.Windows.Forms.Padding(4);
            this.progressBarSlider.Maximum = 1000000000;
            this.progressBarSlider.Name = "progressBarSlider";
            this.progressBarSlider.Size = new System.Drawing.Size(1639, 15);
            this.progressBarSlider.TabIndex = 11;
            this.progressBarSlider.UseRoundedRectangle = true;
            this.progressBarSlider.SliderDown += new System.EventHandler(this.progressBarSlider1_SliderDown);
            this.progressBarSlider.SliderUp += new System.EventHandler(this.progressBarSlider1_SliderUp);
            this.progressBarSlider.SliderMoved += new System.EventHandler(this.progressBarSlider1_SliderMoved);
            // 
            // volumeSlider
            // 
            this.volumeSlider.AllowQuickTracking = true;
            this.volumeSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.volumeSlider.BackgroundBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.volumeSlider.BarHeight = 4;
            this.volumeSlider.Enabled = false;
            this.volumeSlider.FilledBarColor = System.Drawing.Color.White;
            this.volumeSlider.ForeColor = System.Drawing.Color.White;
            this.volumeSlider.KnobImage = global::AudioPlayer.Properties.Resources.knob_white;
            this.volumeSlider.Location = new System.Drawing.Point(204, 66);
            this.volumeSlider.Margin = new System.Windows.Forms.Padding(4);
            this.volumeSlider.Maximum = 1000000;
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(159, 15);
            this.volumeSlider.TabIndex = 0;
            this.volumeSlider.UseRoundedRectangle = true;
            this.volumeSlider.ValueChanged += new System.EventHandler(this.trackSlider1_ValueChanged);
            // 
            // FormUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::AudioPlayer.Properties.Resources.dark_blue_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1827, 869);
            this.Controls.Add(this.visualizationPanel);
            this.Controls.Add(this.playlistPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.controlPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(661, 190);
            this.Name = "FormUI";
            this.Text = "AudioPlayer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUI_FormClosing);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.coverImagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            this.playlistPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.songAndArtistNamePanel.ResumeLayout(false);
            this.visualizationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openLocalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNetworkStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.ToolStripMenuItem openMultipleFilesToolStripMenuItem;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Label totalTimeLabel;
        private TrackSlider volumeSlider;
        private ProgressBarSlider progressBarSlider;
        private ToolStripMenuItem playYouTubeUrlsToolStripMenuItem;
        private Timer timer1;
        private Button playYoutubeButton;
        private Label titleLabel;
        private Label artistLabel;
        private RoundedPictureBox coverPictureBox;
        private XanderUI.XUIButton restartButton;
        private Panel coverImagePanel;
        private XanderUI.XUIButton pauseButton;
        private XanderUI.XUIButton endButton;
        private XanderUI.XUIButton playButton;
        private XanderUI.XUIButton xuiButton2;
        private XanderUI.XUIButton xuiButton1;
        private Panel panel2;
        private TextBox youtubeTextBox;
        private XanderUI.XUIButton unmuteButton;
        private XanderUI.XUIButton muteButton;
        private Label hintLabel;
        private PictureBox loadingPictureBox;
        private System.ComponentModel.BackgroundWorker YoutubeQueryBackgroundWorker;
        private Label volumeLabel;
        private System.ComponentModel.BackgroundWorker YoutubeUrlsBackgroundWorker;
        private Panel playlistPanel;
        private FlowLayoutPanel flowLayoutPanel2;
        private ToolStripMenuItem clearRecentToolStripMenuItem;
        private Panel visualizationPanel;
        private System.Windows.Forms.Integration.ElementHost spectrumAnalyser;
        private SpectrumAnalyser spectrumAnalyser1;
        private Panel songAndArtistNamePanel;
        private Panel panel3;
        private Panel panel1;
        private PictureBox pictureBox1;
        private XanderUI.XUIButton playYoutubeXUIButton;
    }
}


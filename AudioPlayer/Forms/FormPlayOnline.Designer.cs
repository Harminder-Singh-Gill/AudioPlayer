
namespace AudioPlayer.Forms
{
    partial class FormPlayOnline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlayOnline));
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.onlineTextBox = new System.Windows.Forms.TextBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.onlinePlayButton = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.onlineCancelButton = new System.Windows.Forms.Button();
            this.onlineLabel = new System.Windows.Forms.Label();
            this.panel18.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.Transparent;
            this.panel18.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel18.BackgroundImage")));
            this.panel18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel18.Controls.Add(this.panel19);
            this.panel18.Location = new System.Drawing.Point(19, 27);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(545, 43);
            this.panel18.TabIndex = 32;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(61)))));
            this.panel19.Controls.Add(this.onlineTextBox);
            this.panel19.Location = new System.Drawing.Point(9, 2);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(524, 30);
            this.panel19.TabIndex = 25;
            // 
            // onlineTextBox
            // 
            this.onlineTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(61)))));
            this.onlineTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.onlineTextBox.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlineTextBox.ForeColor = System.Drawing.Color.White;
            this.onlineTextBox.Location = new System.Drawing.Point(6, 6);
            this.onlineTextBox.Name = "onlineTextBox";
            this.onlineTextBox.Size = new System.Drawing.Size(505, 19);
            this.onlineTextBox.TabIndex = 6;
            this.onlineTextBox.TextChanged += new System.EventHandler(this.onlineTextBox_TextChanged);
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.Transparent;
            this.panel17.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel17.BackgroundImage")));
            this.panel17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel17.Controls.Add(this.onlinePlayButton);
            this.panel17.Location = new System.Drawing.Point(386, 76);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(81, 42);
            this.panel17.TabIndex = 33;
            // 
            // onlinePlayButton
            // 
            this.onlinePlayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(80)))));
            this.onlinePlayButton.FlatAppearance.BorderSize = 0;
            this.onlinePlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onlinePlayButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlinePlayButton.ForeColor = System.Drawing.Color.White;
            this.onlinePlayButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.onlinePlayButton.Location = new System.Drawing.Point(3, 0);
            this.onlinePlayButton.Name = "onlinePlayButton";
            this.onlinePlayButton.Size = new System.Drawing.Size(75, 30);
            this.onlinePlayButton.TabIndex = 26;
            this.onlinePlayButton.Text = "Play";
            this.onlinePlayButton.UseVisualStyleBackColor = false;
            this.onlinePlayButton.Click += new System.EventHandler(this.onlinePlayButton_Click);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel13.BackgroundImage")));
            this.panel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel13.Controls.Add(this.onlineCancelButton);
            this.panel13.Location = new System.Drawing.Point(473, 76);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(81, 42);
            this.panel13.TabIndex = 37;
            // 
            // onlineCancelButton
            // 
            this.onlineCancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(80)))));
            this.onlineCancelButton.FlatAppearance.BorderSize = 0;
            this.onlineCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onlineCancelButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlineCancelButton.ForeColor = System.Drawing.Color.White;
            this.onlineCancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.onlineCancelButton.Location = new System.Drawing.Point(3, 0);
            this.onlineCancelButton.Name = "onlineCancelButton";
            this.onlineCancelButton.Size = new System.Drawing.Size(75, 30);
            this.onlineCancelButton.TabIndex = 26;
            this.onlineCancelButton.Text = "Cancel";
            this.onlineCancelButton.UseVisualStyleBackColor = false;
            this.onlineCancelButton.Click += new System.EventHandler(this.onlineCancelButton_Click);
            // 
            // onlineLabel
            // 
            this.onlineLabel.AutoSize = true;
            this.onlineLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlineLabel.ForeColor = System.Drawing.Color.White;
            this.onlineLabel.Location = new System.Drawing.Point(25, 8);
            this.onlineLabel.Name = "onlineLabel";
            this.onlineLabel.Size = new System.Drawing.Size(76, 17);
            this.onlineLabel.TabIndex = 38;
            this.onlineLabel.Text = "Enter a URL";
            // 
            // FormPlayOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(576, 119);
            this.Controls.Add(this.onlineLabel);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.panel18);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPlayOnline";
            this.Text = "FormPlayOnline";
            this.panel18.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.TextBox onlineTextBox;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button onlinePlayButton;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button onlineCancelButton;
        private System.Windows.Forms.Label onlineLabel;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;

namespace AudioPlayer.Forms
{
    public partial class ImagePanel : UserControl
    {
        public ImagePanel()
        {
            InitializeComponent();
        }

        public Image Image
        {
            get { return imagePictureBox.Image; }
            set { imagePictureBox.Image = value; }
        }

        public Font TitleFont
        {
            get { return titleLabel.Font; }
            set { titleLabel.Font = value; }
        }
        public int Id { get; set; } = -1;

        public event EventHandler ImagePanelClick;

        private void InvokeImagePanelClick()
        {
            ImagePanelClick?.Invoke(this, EventArgs.Empty);
        }



        public string TitleText
        {
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; }
        }

        private Color _textSectionBackColor;
        public Color TextSectionBackColor
        {
            get { return _textSectionBackColor; }
            set { _textSectionBackColor = value; panel1.BackColor = value; }
        }

        public Color ImageBackColor
        {
            get { return imagePictureBox.BackColor; }
            set { imagePictureBox.BackColor = value;}
        }
        private bool _imagePositionRight = false;
        public bool ImagePositionRight
        {
            get { return _imagePositionRight; }
            set 
            { 
                if (_imagePositionRight != value)
                {
                    _imagePositionRight = value;
                    Control control =  flowLayoutPanel1.Controls[0];
                    flowLayoutPanel1.Controls.Remove(control);
                    flowLayoutPanel1.Controls.Add(control);
                }

            }
        }
        public Color TitleColor
        {
            get { return titleLabel.ForeColor; }
            set { titleLabel.ForeColor = value; }
        }

        public Color MouseDownBackColor { get; set; } = Color.FromArgb(30, Color.White);

        public Color MouseOverBackColor { get; set; } = Color.FromArgb(30, Color.White);

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            imagePictureBox.Width = imagePictureBox.Height = this.Height;
            panel1.Height = this.Height;
            panel1.Width = this.Width - imagePictureBox.Width;
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = MouseOverBackColor;
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = _textSectionBackColor;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.BackColor = MouseDownBackColor;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.BackColor = MouseOverBackColor;
        }

        private void Control_Click(object sender, EventArgs e)
        {
            InvokeImagePanelClick();
        }
    }
}

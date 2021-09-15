using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioPlayer.Forms
{
    public partial class FormPlayOnline : Form
    {
        public string Url;

        public FormPlayOnline()
        {
            InitializeComponent();
        }

        private void onlineTextBox_TextChanged(object sender, EventArgs e)
        {
            if (onlineTextBox.Text == String.Empty)
            {
                onlinePlayButton.Enabled = false;
            }else
            {
                onlinePlayButton.Enabled = true;
            }
        }

        private void onlinePlayButton_Click(object sender, EventArgs e)
        {
            this.Url = onlineTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void onlineCancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

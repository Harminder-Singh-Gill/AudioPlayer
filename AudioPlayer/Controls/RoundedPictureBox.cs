using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioPlayer
{
    class RoundedPictureBox : PictureBox
    {
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            
            using (var gp = DesignUtility.GetFillet(this.ClientRectangle, CornerRadius))
            { 
                this.Region = new Region(gp);
            }
        }
        [Category("Appearance")]
        [Description("Change the radius at the corners of the PictureBox")]
        [DefaultValue(10)]
        public int CornerRadius { get; set; } = 10;
    }
}

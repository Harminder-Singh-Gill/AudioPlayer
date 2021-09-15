using System.Drawing;
using System.Windows.Forms;

namespace AudioPlayer
{
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new MyColors()) { }
    }

    public class MyColors : ProfessionalColorTable
    {
        Color menuStripColor = Color.FromArgb(55, 55, 64);
        Color menuItemSelectedColor = Color.FromArgb(28, 29, 35);
        public override Color MenuItemSelected
        {
            get { return menuItemSelectedColor; }
        }
        public override Color MenuItemBorder
        {

            get { return Color.Empty; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return menuItemSelectedColor; }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return menuItemSelectedColor; }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return menuStripColor; }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return menuStripColor; }
        }

        public override Color MenuBorder
        {
            get { return Color.Empty; }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return menuStripColor; }
        }
        public override Color ImageMarginGradientBegin => menuStripColor;
        public override Color ImageMarginGradientEnd => menuStripColor;
    }
}

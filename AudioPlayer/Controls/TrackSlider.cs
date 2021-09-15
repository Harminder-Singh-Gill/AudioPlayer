using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace AudioPlayer
{
    class TrackSlider : Slider
    {
        protected override void DrawBar(Graphics graphics)
        {
            Point sliderBarLocation = new Point(_knobRect.Width / 2, this.Height / 2 - _barHeight / 2);
            Rectangle backgroundRect = new Rectangle();
            backgroundRect.Location = sliderBarLocation;
            backgroundRect.Width = this.Width - _knobRect.Width;
            backgroundRect.Height = _barHeight;
            GraphicsPath roundedRectangle;
            if (_useRoundedRectangle)
            {
                roundedRectangle = DesignUtility.MakeRoundedRect(backgroundRect, 2, 2, true, true, true, true);
                graphics.FillPath(new SolidBrush(_backgroundBarColor), roundedRectangle);

            }else
            {
                graphics.FillRectangle(new SolidBrush(_backgroundBarColor), backgroundRect);
            }

            if (KnobX == 0)
            {
                return;
            }

            Rectangle valueRect = new Rectangle();
            valueRect.Location = sliderBarLocation;
            valueRect.Width = base.KnobX;
            valueRect.Height = _barHeight;

            if (_useRoundedRectangle)
            {
                roundedRectangle = DesignUtility.MakeRoundedRect(valueRect, 2, 2, true, true, true, true);
                graphics.FillPath(new SolidBrush(_filledBarColor), roundedRectangle);
            }
            else
            {
                graphics.FillRectangle(new SolidBrush(_filledBarColor), valueRect);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (base._draggingKnob)
            {
                OnSliderMoved();
            }
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            OnSliderUp();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            KnobX = e.X - base._knobRect.Width / 2;
            Percent = (float)_knobRect.Left / (this.Width - _knobRect.Width);
            base._draggingKnob = true;
            OnSliderDown();
        }

        [Description("Occurs when the mouse is down on the slider")]
        public event EventHandler SliderDown;
        [Description("Occurs when the mouse is up on the slider")]
        public event EventHandler SliderUp;
        public event EventHandler SliderMoved;

        private void OnSliderMoved()
        {
            SliderMoved?.Invoke(this, EventArgs.Empty);
        }
        private void OnSliderDown()
        {
            SliderDown?.Invoke(this, EventArgs.Empty);
        }

        private void OnSliderUp()
        {
            SliderUp?.Invoke(this, EventArgs.Empty);
        }


        private bool _useRoundedRectangle;
        [Category("Appearance")]
        [Description("Use a rounded bar instead of a rectangular bar")]
        [DefaultValue(false)]
        public bool UseRoundedRectangle
        {
            get { return this._useRoundedRectangle; }
            set { _useRoundedRectangle = value; }
        }

        private Color _filledBarColor;
        [Category("Appearance")]
        [Description("The color of the the bar that is to the left of the knob")]
        public Color FilledBarColor
        {
            get { return _filledBarColor; }
            set { _filledBarColor = value; }
        }
       
        private Color _backgroundBarColor;
        [Category("Appearance")]
        [Description("The color of the the bar in the background")]
        public Color BackgroundBarColor
        {
            get { return _backgroundBarColor; }
            set { _backgroundBarColor = value; }
        }

        private int _barHeight;
        [Category("Appearance")]
        [Description("The height of the progress bar")]
        [DefaultValue(5)]
        public int BarHeight
        {
            get { return this._barHeight; }
            set { this._barHeight = value; }
        }
        
    }
}

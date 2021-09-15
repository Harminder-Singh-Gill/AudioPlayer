using System;
using System.Windows.Forms;

namespace AudioPlayer
{
    class ProgressBarSlider : TrackSlider
    {
        protected override void OnMouseLeave(EventArgs e)
        {
            //invalidates the knob on mouse leaving the knob
            base.OnMouseLeave(e);
            //invalidates the knob on mouse leaving the progressBarSlider
            this.Invalidate(base._knobRect);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base._bufGraphics.Graphics.Clear(this.BackColor);
            DrawBar(_bufGraphics.Graphics);

            if (base._knobBitmap != null && ProgressBarIsActive)
            {
                _bufGraphics.Graphics.DrawImage(base._knobBitmap, _knobRect);
            }

            _bufGraphics.Render(e.Graphics);
        }

        //returns true if the knob is being dragged or the cursor is within 
        //the bounds of the progressBarSlider
        private bool ProgressBarIsActive
        {
            get { return _draggingKnob || this.DisplayRectangle.Contains(this.PointToClient(Cursor.Position)); }
        }

    }
}

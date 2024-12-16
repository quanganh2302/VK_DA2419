using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DDA2419_Application_VS19.Component
{
    public class CustomSlider : Control
    {
        private int _value; // giá trị hiện tại của slider
        private int _minimum = 0; // phần trăm min của slider
        private int _maximum = 100; // Phần trăm max của slider
        private bool _isDragging = false; // sự kiện nắm thả hình tròn nằm trên slider

        public event EventHandler ValueChanged;
        [Category("Custom props")]
        public int MinimumPercent
        {
            get => _minimum;
            set
            {
                _minimum = value;
                Invalidate();
            }
        }
        [Category("Custom props")]
        public int MaximumPercent
        {
            get => _maximum;
            set
            {
                _maximum = value;
                Invalidate();
            }
        }

        public int Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = Math.Max(_minimum, Math.Min(_maximum, value));
                    Invalidate();
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }
        [Category("Custom props")]
        public Color TrackColorLeft { get; set; } = Color.Blue;
        [Category("Custom props")]
        public Color TrackColorRight { get; set; } = Color.Gray;
        [Category("Custom props")]
        public Color ThumbColor { get; set; } = Color.Red;

        public CustomSlider()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.MouseDown += CustomSlider_MouseDown;
            this.MouseMove += CustomSlider_MouseMove;
            this.MouseUp += CustomSlider_MouseUp;
            this.MouseLeave += CustomSlider_MouseLeave;
        }

        private void CustomSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                UpdateValueFromPosition(e.X);
            }
        }

        private void CustomSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                UpdateValueFromPosition(e.X);
            }
            else
            {
                // Check if the mouse is over the thumb
                int thumbX = (int)((float)(Value - MinimumPercent) / (MaximumPercent - MinimumPercent) * (Width - 20)) + 10;
                int thumbSize = 20; // Diameter of the thumb circle
                Rectangle thumbRect = new Rectangle(thumbX - thumbSize / 2, Height / 2 - thumbSize / 2, thumbSize, thumbSize);

                if (thumbRect.Contains(e.Location))
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void CustomSlider_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
            }
        }

        private void CustomSlider_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void UpdateValueFromPosition(int x)
        {
            int newValue = (int)((float)(x - 10) / (Width - 20) * (_maximum - _minimum) + _minimum);
            Value = newValue;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Calculate thumb position
            int thumbX = (int)((float)(Value - MinimumPercent) / (MaximumPercent - MinimumPercent) * (Width - 20)) + 10;
            int thumbSize = 20; // Diameter of the thumb circle

            // Draw the left part of the track
            Rectangle leftTrackRect = new Rectangle(10, Height / 2 - 2, thumbX - 10, 4);
            using (Brush leftTrackBrush = new SolidBrush(TrackColorLeft))
            {
                e.Graphics.FillRectangle(leftTrackBrush, leftTrackRect);
            }

            // Draw the right part of the track
            Rectangle rightTrackRect = new Rectangle(thumbX, Height / 2 - 2, Width - thumbX - 10, 4);
            using (Brush rightTrackBrush = new SolidBrush(TrackColorRight))
            {
                e.Graphics.FillRectangle(rightTrackBrush, rightTrackRect);
            }

            // Draw the thumb as a smooth circle
            Rectangle thumbRect = new Rectangle(thumbX - thumbSize / 2, Height / 2 - thumbSize / 2, thumbSize, thumbSize);
            using (Brush thumbBrush = new SolidBrush(ThumbColor))
            {
                e.Graphics.FillEllipse(thumbBrush, thumbRect);
            }
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
    }
}
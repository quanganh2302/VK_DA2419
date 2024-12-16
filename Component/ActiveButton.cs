using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DA2419_Application_VS19.Component
{
    public class ActiveButton : Panel
    {
        // Cài đặt 3 trạng thái mặc định của LED 
        public enum ButtonState
        {
            Normal,
            Active,
            Emergency
        }

        private readonly Color normalColor = ColorTranslator.FromHtml("#696969");
        private readonly Color activeColor = ColorTranslator.FromHtml("#00d26a");
        private readonly Color emergencyColor = ColorTranslator.FromHtml("#f92f60");
        private ButtonState currentState = ButtonState.Normal;

        [Category("Custom props")]
        public ButtonState State
        {
            get { return currentState; }
            set
            {
                currentState = value;
                Invalidate(); // Redraw the panel
            }
        }
        private Point position;
        [Category("Custom props")]
        public Point Position
        {
            get { return position; }
            set
            {
                position = value;
                Location = position; // Update the location of the button
            }
        }
        public ActiveButton()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(32, 32); // Default size
            //this.Click += ActiveButton_Click;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Determine the size of the circle
            int diameter = Math.Min(ClientSize.Width, ClientSize.Height) - 4;
            Rectangle rect = new Rectangle(2, 2, diameter, diameter);

            // Determine the color based on the state
            Color fillColor = normalColor;
            switch (State)
            {
                case ButtonState.Active:
                    fillColor = activeColor;
                    break;
                case ButtonState.Emergency:
                    fillColor = emergencyColor;
                    break;
            }

            // Draw the circle
            using (Brush brush = new SolidBrush(fillColor))
            {
                g.FillEllipse(brush, rect);
            }
        }
    }
}
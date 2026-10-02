using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Flaminguage
{
    [ToolboxItem(true)]
    public class RoundedButton : Button
    {
        private int cornerRadius = 20;
        private int borderSize = 0;

        private Color borderColor = Color.Black;
        private Color hoverColor;
        private Color pressedColor;

        private bool isHover;
        private bool isPressed;

        [Category("Appearance")]
        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value < 1 ? 1 : value;
                UpdateRegion();
                Invalidate();
            }
        }

        [Category("Appearance")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color HoverColor
        {
            get { return hoverColor; }
            set { hoverColor = value; }
        }

        [Category("Appearance")]
        public Color PressedColor
        {
            get { return pressedColor; }
            set { pressedColor = value; }
        }

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            hoverColor = Color.LightGray;
            pressedColor = Color.Gray;

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            using (GraphicsPath path = GetRoundPath(
                new Rectangle(0, 0, Width - 1, Height - 1),
                cornerRadius))
            {
                if (Region != null)
                    Region.Dispose();

                Region = new Region(path);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            isHover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHover = false;
            isPressed = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            isPressed = true;
            Invalidate();
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            isPressed = false;
            Invalidate();
            base.OnMouseUp(mevent);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color fillColor = BackColor;

            if (isPressed)
                fillColor = pressedColor;
            else if (isHover)
                fillColor = hoverColor;

            using (GraphicsPath path = GetRoundPath(
                new Rectangle(0, 0, Width - 1, Height - 1),
                cornerRadius))
            {
                using (SolidBrush brush = new SolidBrush(fillColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                if (borderSize > 0)
                {
                    using (Pen pen = new Pen(borderColor, borderSize))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    Text,
                    Font,
                    ClientRectangle,
                    ForeColor,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter);
            }
        }

        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);

            path.CloseFigure();

            return path;
        }
    }
}
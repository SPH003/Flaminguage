using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Flaminguage
{
    class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; }

    public RoundedPanel()
    {
        CornerRadius = 20;

        SetStyle(ControlStyles.UserPaint |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        using (GraphicsPath path = GetRoundPath(
            new Rectangle(0, 0, Width - 1, Height - 1),
            CornerRadius))
        {
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            this.Region = new Region(path);
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
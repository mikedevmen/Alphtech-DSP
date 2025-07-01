using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomTrackBar : TrackBar
{
    public CustomTrackBar()
    {
        SetStyle(ControlStyles.UserPaint, true);
        this.Height = 30;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;

        int trackHeight = 4;
        int thumbSize = 12;

        int trackY = this.Height / 2 - trackHeight / 2;
        int thumbX = (int)(((float)(Value - Minimum) / (Maximum - Minimum)) * (Width - thumbSize));
        int thumbY = this.Height / 2 - thumbSize / 2;

        graphics.FillRectangle(Brushes.Gray, 0, trackY, Width, trackHeight);

        Rectangle thumbRect = new Rectangle(thumbX, thumbY, thumbSize, thumbSize);
        graphics.FillEllipse(Brushes.White, thumbRect);
        graphics.DrawEllipse(Pens.DimGray, thumbRect);
    }
}

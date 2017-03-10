using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Controls
{
  public class TransparentPanel : Panel
  {
    private Color brushColor = Color.Transparent;
    private Timer delay = new Timer();
    private int opacity = 50;

    public Color BrushColor
    {
      get { return this.brushColor; }
      set
      {
        this.brushColor = value;
        base.RecreateHandle();
      }
    }

    public int Opacity
    {
      get { return this.opacity; }
      set
      {
        if (value > 100)
          this.opacity = 100;
        else if (value < 0)
          this.opacity = 0;
        else
          this.opacity = value;

        base.RecreateHandle();
      }
    }

    public TransparentPanel()
    {
      this.delay.Tick += new EventHandler(this.TimerOnTick);
      this.delay.Enabled = true;
      this.delay.Interval = 50;
    }

    protected override void OnMove(EventArgs e)
    {
      base.RecreateHandle();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      int alpha;

      Graphics graphics = e.Graphics;
      Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
      Color baseColor = this.brushColor;

      if (baseColor == Color.Transparent)
      {
        alpha = 0;
      }
      else
      {
        alpha = (this.opacity * 0xff) / 100;
      }

      Pen pen = new Pen(Color.Black);
      SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, baseColor));
      graphics.FillRectangle(brush, rect);
      graphics.DrawRectangle(pen, rect);

      pen.Dispose();
      brush.Dispose();
      graphics.Dispose();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ExStyle |= 0x20;
        return createParams;
      }
    }

    private void TimerOnTick(object source, EventArgs e)
    {
      base.RecreateHandle();
      this.delay.Stop();
    }
}

}

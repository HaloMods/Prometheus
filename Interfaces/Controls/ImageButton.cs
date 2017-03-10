using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using Interfaces;

namespace Prometheus.Controls
{
  public class ImageButton : Control
  {
    private Bitmap image;
    //private bool invalidated = false;
    private bool rollover = false;
    private bool showFocusRectangle = true;
    private bool shrinkOnPush = true;
    private bool pressing = false;
    private bool hasFocus = false;

    [DefaultValue(true)]
    public bool ShowFocusRectangle
    {
      get { return showFocusRectangle; }
      set { showFocusRectangle = value; }
    }

    [DefaultValue(true)]
    public bool ShrinkOnPush
    {
      get { return shrinkOnPush; }
      set { shrinkOnPush = value; }
    }
    
    public Bitmap Image
    {
      get { return image; }
      set
      {
        image = value;
        Invalidate();
      }
    }

    public ImageButton()
    {
      MouseEnter += new EventHandler(ImageButton_MouseEnter);
      MouseLeave += new EventHandler(ImageButton_MouseLeave);
      //Invalidated += new InvalidateEventHandler(ImageButton_Invalidated);
      KeyDown += new KeyEventHandler(ImageButton_KeyDown);
      KeyUp += new KeyEventHandler(ImageButton_KeyUp);
      MouseDown += new MouseEventHandler(ImageButton_MouseDown);
      MouseUp += new MouseEventHandler(ImageButton_MouseUp);
      GotFocus += new EventHandler(ImageButton_GotFocus);
      LostFocus += new EventHandler(ImageButton_LostFocus);

      SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      SetStyle(ControlStyles.UserPaint, true);
    }

    void ImageButton_LostFocus(object sender, EventArgs e)
    {
      hasFocus = false;
      rollover = false;
      Invalidate();
    }

    void ImageButton_GotFocus(object sender, EventArgs e)
    {
      hasFocus = true;
      rollover = true;
      Invalidate();
    }

    void ImageButton_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Space)
      {
        pressing = false;
        Invalidate();

        OnClick(new EventArgs());
      }
    }

    void ImageButton_KeyDown(object sender, KeyEventArgs e)
    {
      if (!Enabled) return;

      if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Space)
      {
        pressing = true;
        Invalidate();
      }
    }

    void ImageButton_MouseUp(object sender, MouseEventArgs e)
    {
      pressing = false;
      Invalidate();
    }

    void ImageButton_MouseDown(object sender, MouseEventArgs e)
    {
      if (!Enabled) return;
      pressing = true;
      Invalidate();
    }

    //void ImageButton_Invalidated(object sender, InvalidateEventArgs e)
    //{
    //  if (!invalidated) InvalidateEx();
    //}

    //protected override CreateParams CreateParams
    //{
    //  get
    //  {
    //    CreateParams cp = base.CreateParams;
    //    cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
    //    return cp;
    //  }
    //}

    //protected void InvalidateEx()
    //{
    //  invalidated = true;
    //  if (Parent == null) return;
    //  Rectangle rc = new Rectangle(Location, Size);
    //  Parent.Invalidate(rc, true);
    //  invalidated = false;
    //}
    
    void ImageButton_MouseLeave(object sender, EventArgs e)
    {
      Cursor = Cursors.Default;
      rollover = false;
      Invalidate();
    }

    void ImageButton_MouseEnter(object sender, EventArgs e)
    {
      if (!Enabled) return;
      Cursor = Cursors.Hand;
      rollover = true;
      Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      PaintImage(e.Graphics, Image);
    }

    protected void PaintImage(Graphics graphics, Image image)
    {
      using (Brush b = new SolidBrush(BackColor))
        graphics.FillRectangle(b, Bounds);

      if (image != null)
      {
        int x = (Width - image.Width) / 2;
        int y = (Height - image.Height) / 2;
        Rectangle r = new Rectangle(x, y, image.Width, image.Height);

        ImageAttributes ia = new ImageAttributes();
        if (Enabled)
        {
          if (rollover)
          {
            ia.SetColorMatrix(SaturationMatrix(2.3f));
            if (shrinkOnPush && pressing)
            {
              r.Location = new Point(x + 1, y + 1);
              r.Size = new Size(r.Width - 2, r.Height - 2);
            }
          }
        }
        else
        {
          ia.SetColorMatrix(GrayScaleColorMatrix);
        }
        graphics.DrawImage(image, r, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);
        if (hasFocus && showFocusRectangle)
        {
          using (Pen p = new Pen(Color.Gray))
          {
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            graphics.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
          }
        }
      }
      else
        using (Pen p = new Pen(Color.Gray))
        {
          p.DashPattern = new float[] { 3f, 3f, 3f, 3f };
          graphics.DrawRectangle(p, 0, 0, Width-1, Height-1);
        }
    }

    protected ColorMatrix GrayScaleColorMatrix
    {
      get
      {
        ColorMatrix saturationMatrix = new ColorMatrix();
        saturationMatrix.Matrix00 = 1 / 3f;
        saturationMatrix.Matrix01 = 1 / 3f;
        saturationMatrix.Matrix02 = 1 / 3f;
        saturationMatrix.Matrix10 = 1 / 3f;
        saturationMatrix.Matrix11 = 1 / 3f;
        saturationMatrix.Matrix12 = 1 / 3f;
        saturationMatrix.Matrix20 = 1 / 3f;
        saturationMatrix.Matrix21 = 1 / 3f;
        saturationMatrix.Matrix22 = 1 / 3f;
        saturationMatrix.Matrix33 = 0.5f; // Reduce the alpha so that the image is lighter.
        return saturationMatrix;
      }
    }
    
    protected ColorMatrix SaturationMatrix(float saturation)
    {
      float rLum = 0.3086f;
      float gLum = 0.6094f;
      float bLum = 0.082f;
      float a, b, c, d, e, f, g, h, i;

      a = (1.0f - saturation) * rLum + saturation;
      b = (1.0f - saturation) * rLum;
      c = (1.0f - saturation) * rLum;
      d = (1.0f - saturation) * gLum;
      e = (1.0f - saturation) * gLum + saturation;
      f = (1.0f - saturation) * gLum;
      g = (1.0f - saturation) * bLum;
      h = (1.0f - saturation) * bLum;
      i = (1.0f - saturation) * bLum + saturation;
     
      ColorMatrix saturationMatrix = new ColorMatrix(new float[][]{
        new float[] {a, b, c, 0, 0},
        new float[] {d, e, f, 0, 0},
        new float[] {g, h, i, 0, 0},
        new float[] {0, 0, 0, 1, 0},
        new float[] {0, 0, 0, 0, 1}});

      return saturationMatrix;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Controls
{
  public class ToggleButton : ImageButton
  {
    private Bitmap toggledImage;
    private bool toggled = false;

    public event EventHandler BeforeToggle;
    public event EventHandler AfterToggle;

    public Bitmap ToggledImage
    {
      get { return toggledImage; }
      set
      {
        toggledImage = value;
        Invalidate();
      }
    }
    
    public bool Toggled
    {
      get { return toggled; }
      set
      {
        if (toggled != value)
        {
          if (BeforeToggle != null)
            BeforeToggle(this, new EventArgs());
          toggled = value;
          if (AfterToggle != null)
            AfterToggle(this, new EventArgs());
          Invalidate();
        }
      }
    }

    public ToggleButton()
    {
      Click += new EventHandler(ToggleButton_MouseEnter);
    }

    void ToggleButton_MouseEnter(object sender, EventArgs e)
    {
      Toggled = !Toggled;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (Toggled)
        PaintImage(e.Graphics, ToggledImage);
      else
        PaintImage(e.Graphics, Image);
    }
  }
}
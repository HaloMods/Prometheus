using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Prometheus.Controls.TagExplorers
{
  public partial class BusyIndicator : Control
  {
    float angle = 0.0f;
    Timer timer = new Timer();
    Timer fadeTimer = new Timer();
    bool active;
    Bitmap image;
    FadeState fadeState = FadeState.Idle;
    int alpha = 0;
    float circleDiameter = 5f;
    
    public float CircleDiameter
    {
      get { return circleDiameter; }
      set
      {
        circleDiameter = value;
        Invalidate();
      }
    }
    
    public float Angle
    {
      get { return angle; }
      set
      {
        angle = value;
        if (angle >= 360)
          angle -= 360;
      }
    }
   
    protected bool Active
    {
      get { return active; }
      set
      {
        active = value;
        if (active)
        {
          Angle = 0.0f;
          timer.Start();
        }
        else timer.Stop();
      }
    }

    public Bitmap Image
    {
      get { return image; }
      set { image = value; }
    }

    public BusyIndicator()
    {
      Initialize();
    }
    
    public void FadeIn()
    {
      Active = true;
      fadeState = FadeState.FadingIn;
      fadeTimer.Start();
    }
    
    public void FadeOut()
    {
      fadeState = FadeState.FadingOut;
      fadeTimer.Start();
    }

    private void Initialize()
    {
      ForeColor = Color.DarkBlue;
      SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      BackColor = Color.Transparent;
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
      timer.Interval = 100;
      timer.Tick += new EventHandler(timer_Tick);
      fadeTimer.Interval = 250;
      fadeTimer.Tick += new EventHandler(fadeTimer_Tick);
    }

    void fadeTimer_Tick(object sender, EventArgs e)
    {
      if (fadeState == FadeState.FadingIn)
      {
        alpha += 12;
        if (alpha >= 255)
        {
          alpha = 255;
          fadeTimer.Stop();
          fadeState = FadeState.Idle;
        }
      }
      else if (fadeState == FadeState.FadingOut)
      {
        alpha -= 12;
        if (alpha <= 0)
        {
          alpha = 0;
          fadeTimer.Stop();
          fadeState = FadeState.Idle;
          Active = false;
        }
      }
    }
    
    void timer_Tick(object sender, EventArgs e)
    {
      Angle += 45.0f;
      Invalidate();
      Update();
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      Graphics g = pe.Graphics;
      g.SmoothingMode = SmoothingMode.AntiAlias;
      g.PixelOffsetMode = PixelOffsetMode.HighQuality;
      g.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 0, Width, Height));
      float effectiveWidth = (Width - circleDiameter) - 2;
      float effectiveHeight = (Height - circleDiameter) - 2;
      
      for (int x = 0; x < 359; x += 45)
      {
        int alphaValue = (int)(x * (255f / 360f));
        Color newColor = Color.FromArgb(alphaValue < alpha ? alphaValue : alpha, ForeColor);
        if (DesignMode) newColor = ForeColor;
        using (Brush b = new SolidBrush(newColor))
        {
          double angleR = (angle + x) * (Math.PI / 180);
          double destinationX = (effectiveWidth / 2) + (Math.Sin(angleR) * effectiveWidth / 2);
          double destinationY = effectiveHeight / 2 - (Math.Cos(angleR) * effectiveHeight / 2);
          g.FillEllipse(b, (float)destinationX, (float)destinationY, circleDiameter, circleDiameter);
        }
      }
    }
    private enum FadeState
    {
      FadingIn,
      FadingOut,
      Idle
    }
  }
}
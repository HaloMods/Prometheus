using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Prometheus.Controls
{
  public class NicktureBox : PictureBox
  {
    private Image grayscaleImage = null;
    private Image normalImage = null;
    public NicktureBox()
    {
      this.EnabledChanged += new EventHandler(NicktureBox_EnabledChanged);
    }

    void NicktureBox_EnabledChanged(object sender, EventArgs e)
    {
      if (!Enabled && this.Image != null)
      {
        normalImage = this.Image;
        if (grayscaleImage == null)
          grayscaleImage = CreateGrayScaleImage();
        this.Image = grayscaleImage;
      }
      else
      {
        if (normalImage != null)
          this.Image = normalImage;
      }
    }

    private Image CreateGrayScaleImage()
    {
      Bitmap gray = new Bitmap(normalImage);
      for (int y = 0; y < gray.Height; y++)
      {
        for (int x = 0; x < gray.Width; x++)
        {
          Color c = gray.GetPixel(x, y);
          int luma = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
          gray.SetPixel(x, y, Color.FromArgb(c.A, luma, luma, luma));
        }
      }
      return gray;
    }
  }
}
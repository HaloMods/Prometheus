using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
//using System.Threading.Tasks;
using System.Threading;
using Interfaces.Rendering.Interfaces;

namespace Core.Radiosity.TextureMapping
{
  class ExposureMapOperator : IToneMapOperator
  {
    public Bitmap CreateImage(double[, ,] HDRi, params object[] optionalsettings)
    {
      int width = (int)optionalsettings[0];
      int height = (int)optionalsettings[1];

      Bitmap bitmap = new Bitmap(width, height);

      Parallel.For(0, width, delegate(int x)
      {
        for(int y=0;y<height;y++)
          for (int c = 0; c < 3; c++)
          {
            if (HDRi[x, y, c] != 0.0)
            {
              double temp = Expose(HDRi[x, y, c] * 10, 0.1);
              //System.Diagnostics.Debugger.Break();
              temp = temp;
            }
            HDRi[x, y, c] = Expose(HDRi[x, y, c], 0.1);
          }
        lock (bitmap)
        {
          for (int y = 0; y < height; y++)
            bitmap.SetPixel(x, y, Color.FromArgb((int)Math.Round(HDRi[x, y, 0]), (int)Math.Round(HDRi[x, y, 1]), (int)Math.Round(HDRi[x, y, 2])));
        }
      });
      return bitmap;
    }
    static double Expose(double light, double k) { return (1.0 - Math.Exp(-(light * k))) * 255.0; }
  }
}

using System;
using System.Drawing;

using Interfaces.Rendering.Interfaces;

namespace Core.Radiosity.TextureMapping
{
  public class LinearToneMapper : IToneMapOperator
  {
    bool useMax = false;
    double max = float.NaN;

    public LinearToneMapper(double max)
    {
      this.max = max;
      useMax = true;
    }
    public LinearToneMapper()
    {
    }

    public Bitmap CreateImage(double[, ,] HDRi, params object[] optionalsettings)
    {
      int width = (int)optionalsettings[0];
      int height = (int)optionalsettings[1];

      //int width = HDRi.GetLength(0);
      //int height = HDRi.GetLength(1);
      int colorDepth = 3;//HDRi.GetLength(2);
      double total = width * height * colorDepth;

      double average = 0f;
      double maxValue = double.MinValue;
      for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
          for (int c = 0; c < colorDepth; c++)
          {
            if (HDRi[x, y, c] == 0)
            {
              total -= 1;
              continue;
            }
            if (HDRi[x, y, c] > maxValue)
              maxValue = HDRi[x, y, c];            
            average += (double)HDRi[x, y, c];
          }
      average /= total;
      double deviationMean = 0;
      for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
          for (int c = 0; c < colorDepth; c++)
          {
            if (HDRi[x, y, c] == 0)
              continue;
            double deviation = average - HDRi[x, y, c];
            deviationMean += (deviation * deviation) / total;
          }
      double standardDeviation = Math.Sqrt(deviationMean);
      double max = (standardDeviation * 3) + average;
      for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
          for (int c = 0; c < colorDepth; c++)
            if (HDRi[x, y, c] > max)              
              HDRi[x, y, c] = (float)max;

      byte[, ,] newMap = new byte[width, height, colorDepth];
      float multiplier = 255f / (float)max;
      //for (int x = 0; x < width; x++)
      for (int x = 0; x < width; x++)
      {
        for (int y = 0; y < height; y++)
        {
          for (int c = 0; c < colorDepth; c++)
            if (HDRi[x, y, c] != 0)
              newMap[x, y, c] = (byte)(Math.Round((HDRi[x, y, c] * multiplier)));
          Interfaces.Rendering.Primitives.RealColor color = new Interfaces.Rendering.Primitives.RealColor((float)HDRi[x, y, 0], (float)HDRi[x, y, 1], (float)HDRi[x, y, 2]);
        }
      }
      Bitmap bmp = new Bitmap(width, height);
      for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
          bmp.SetPixel(x, y, Color.FromArgb(newMap[x, y, 0], newMap[x, y, 1], newMap[x, y, 2]));
      newMap = null;
      return bmp;

      /*Bitmap bitmap = new Bitmap(width, height);

      #region compute the maximum and minimum values.
      double min = double.MaxValue;//, max = new double[3];
      double max = double.MinValue;

      #region compute min and max
      for (int x = 0; x < width; x++)
      {
        for (int y = 0; y < height; y++)
        {
          for (int c = 0; c < 3; c++)
          {
            if (HDRi[x, y, c] < min)
              min = HDRi[x, y, c];
            if (HDRi[x, y, c] > max)
              max = HDRi[x, y, c];
          }
        }
      }
      #endregion
      #endregion

      if (useMax)
        max = this.max;

      double[] diff = new double[3];
      for (int x = 0; x < 3; x++)
      {
        diff[x] = max - min;
      }

      /*double[] slope = new double[3];
      for (int x = 0; x < 3; x++)
        slope[x] = diff[x]/255;

      

      Interfaces.Output.Write(Interfaces.OutputTypes.Debug, string.Format("Computing lightmap... Avg dif. {0} max r {1} max g {2} max b {3}", (diff[0] + diff[1] + diff[2]) / 3, max, max, max));

      for (int x=0;x<width;x++)
      {
        for (int y=0;y<height;y++)
        {
          double[] newColors = new double[3];
          for (int c = 0; c < 3; c++)
          {
            if (diff[c] == 0)
              continue;
            HDRi[x, y, c] += min;
            newColors[c] = (HDRi[x,y,c] - min) / diff[c];
            newColors[c] *= 255f;
            //newColors[c] *= (2 << 31);
            if (newColors[c] < 0)
              newColors[c] = 0;
            #if DEBUG
            System.Diagnostics.Debug.Assert(newColors[c] >= 0);
            System.Diagnostics.Debug.Assert(newColors[c] <= 255);
            #endif
          }
          bitmap.SetPixel(x,y,Color.FromArgb((int)newColors[0], (int)newColors[1], (int)newColors[2]));
        }
      }

      return bitmap;*/
    }
    public Color[,] CreateColors(double[, ,] HDRi, params object[] optionalsettings)
    {
      int width = (int)optionalsettings[0];
      int height = (int)optionalsettings[1];

      Color[,] color = new Color[width, height];

      #region compute the maximum and minimum values.
      double[] min = new double[3], max = new double[3];
      #region initialize min and max
      for (int x = 0; x < 3; x++)
      {
        min[x] = double.MaxValue;
        max[x] = double.MinValue;
      }
      #endregion

      #region compute min and max
      for (int x = 0; x < width; x++)
      {
        for (int y = 0; y < height; y++)
        {
          for (int c = 0; c < 3; c++)
          {
            if (HDRi[x, y, c] < min[c])
              min[c] = HDRi[x, y, c];
            if (HDRi[x, y, c] > max[c])
              max[c] = HDRi[x, y, c];
          }
        }
      }
      #endregion
      #endregion

      double[] diff = new double[3];
      for (int x = 0; x < 3; x++)
      {
        diff[x] = max[x] - min[x];
      }

      double[] slope = new double[3];
      for (int x = 0; x < 3; x++)
        slope[x] = diff[x] / 255;

      for (int x = 0; x < width; x++)
      {
        for (int y = 0; y < height; y++)
        {
          double[] newColors = new double[3];
          for (int c = 0; c < 3; c++)
          {
            if (diff[c] == 0)
              continue;
            HDRi[x, y, c] += min[c];
            newColors[c] = (HDRi[x, y, c] - min[c]) / diff[c];
            newColors[c] *= 255;
#if DEBUG
            System.Diagnostics.Debug.Assert(newColors[c] >= 0);
            System.Diagnostics.Debug.Assert(newColors[c] <= 255);
#endif
          }
          //bitmap.SetPixel(x, y, Color.FromArgb((int)newColors[0], (int)newColors[1], (int)newColors[2]));
          color[x, y] = Color.FromArgb((int)newColors[0], (int)newColors[1], (int)newColors[2]);
        }
      }

      return color;
    }
  }
}
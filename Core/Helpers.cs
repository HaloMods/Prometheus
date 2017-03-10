using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Interfaces.Rendering.Interfaces;
using AForge.Imaging.Filters;

namespace Core
{
  public static class Helpers
  {
    /// <summary>
    /// Returns a string representing the amount of time elapsed since the specified DateTime.
    /// </summary>
    public static string ElapsedTimeString(DateTime time)
    {
      TimeSpan elapsed = DateTime.Now.Subtract(time);
      string modifiedString = elapsed.TotalMinutes.ToString("0.0") + " minutes ago";
      if (elapsed.TotalMinutes >= 60)
      {
        modifiedString = elapsed.TotalHours.ToString("0.0") + " hours ago";
        if (elapsed.TotalHours >= 24)
        {
          modifiedString = elapsed.TotalDays.ToString("0.0") + " days ago";
        }
      }
      return modifiedString;
    }
    public static Bitmap BlurBitmap(Bitmap bitmap)
    {
      using (Bitmap newBitm = new Bitmap(bitmap, new Size(128, 128)))
      {
        GaussianBlur blur = new GaussianBlur(2, 10);
        using (Bitmap blurredImage = blur.Apply(newBitm))
          return new Bitmap(blurredImage, new Size(bitmap.Width, bitmap.Height));
      }
    }

    /// <summary>
    /// Returns all files from the specified folder and all child folders.
    /// </summary>
    public static string[] GetRecursiveFiles(string path)
    {
      return GetRecursiveFiles(path, "*");
    }

    /// <summary>
    /// Returns all files with the specified extension from the specified folder and all child folders.
    /// </summary>
    public static string[] GetRecursiveFiles(string path, string extension)
    {
      extension = "." + extension.Trim('.');
      if (extension == "*") extension = "";

      if (!Directory.Exists(path))
      {
        Interfaces.Output.Write(Interfaces.OutputTypes.Error, "GetRecursiveFiles() is returning null because the parameter \"" + path + "\" did not point to a valid path.");
        return null; // TODO: Proper error handling mb? -ZF
      }

      List<string> results = new List<string>();
      string[] folders = Directory.GetDirectories(path);
      foreach (string folder in folders)
      {
        string[] files = GetRecursiveFiles(folder, extension);
        foreach (string file in files)
          if (Path.GetExtension(file) == extension || extension == ".")
            results.Add(file);
      }
      results.AddRange(Directory.GetFiles(path));
      return results.ToArray();
    }
    /// <summary>
    /// Returns all files with the specified extension from the specified folder and all child folders, up to a certain depth.
    /// </summary>
    public static string[] GetRecursiveFiles(string path, string extension, int maxDepth)
    {
      if (maxDepth == 0)
        return null;

      extension = "." + extension.Trim('.');
      if (extension == "*") extension = "";

      if (!Directory.Exists(path))
      {
        Interfaces.Output.Write(Interfaces.OutputTypes.Error, "GetRecursiveFiles() is returning null because the parameter \"" + path + "\" did not point to a valid path.");
        return null; // TODO: Proper error handling mb? -ZF
      }

      List<string> results = new List<string>();
      string[] folders = Directory.GetDirectories(path);
      foreach (string folder in folders)
      {
        if (maxDepth > 1)
        {
          string[] files = GetRecursiveFiles(folder, extension, maxDepth - 1);
          foreach (string file in files)
            if (Path.GetExtension(file) == extension || extension == ".")
              results.Add(file);
        }
      }
      results.AddRange(Directory.GetFiles(path));
      return results.ToArray();
    }
    
    /// <summary>
    /// Writes the contents of the source stream to the destination stream.
    /// </summary>
    public static void WriteStream(Stream sourceStream, Stream destimationStream)
    {
      WriteStream(sourceStream, destimationStream, 102400); //Default chunk size of 100kb.
    }

    /// <summary>
    /// Writes the contents of the source stream to the destination, using the specified chunk size.
    /// </summary>
    /// <param name="chunkSize">The number of bytes to read and write at one time.</param>
    public static void WriteStream(Stream sourceStream, Stream destimationStream, int chunkSize)
    {
      byte[] data = new byte[chunkSize];
      while (sourceStream.Position < sourceStream.Length)
      {
        int totalBytesRead = sourceStream.Read(data, 0, chunkSize);
        destimationStream.Write(data, 0, totalBytesRead);
      }
    }

    /// <summary>
    /// Uses a hack to generate a proper ImageList with correct alpha from a set of Bitmap objects.
    /// </summary>
    public static ImageList GenerateImageList(Bitmap[] images)
    {
      return GenerateImageList(images, -1, -1);
    }

    /// <summary>
    /// Uses a hack to generate a proper ImageList with correct alpha from a set of Bitmap objects.
    /// </summary>
    public static ImageList GenerateImageList(Bitmap[] images, int imageWidth, int imageHeight)
    {
      ImageList il = new ImageList();
      if (imageWidth > -1 && imageHeight > -1)
        il.ImageSize = new Size(imageWidth, imageHeight);

      il.ColorDepth = ColorDepth.Depth32Bit;

      if (images.Length > 0)
      {
        for (int i = 0; i < images.Length; i++)
        {
          int ReSizeHeight = 256;
          int ReSizeWidth = 256;

          if (images[i] != null)
          {
            if (images[i].Width > ReSizeWidth || images[i].Height > ReSizeHeight)
            {
              double Scaling;
              double WidthScaling = ReSizeWidth / (double)images[i].Width;
              double HeightScaling = ReSizeHeight / (double)images[i].Height;

              if (WidthScaling < HeightScaling)
              {
                Scaling = WidthScaling;
              }
              else
              {
                Scaling = HeightScaling;
              }

              int newWidth = (int)(images[i].Width * Scaling);
              int newHeight = (int)(images[i].Height * Scaling);
              Bitmap bm = new Bitmap(newWidth, newHeight);
              Graphics graphics = Graphics.FromImage(bm);
              graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
              graphics.DrawImage(images[i], 0, 0, newWidth, newHeight);
              images[i] = bm;
            }
          }
          else
          {
            images[i] = new Bitmap(1, 1);
          }
        }

        il.ImageSize = new Size(images[0].Width, images[0].Height);

        foreach (Bitmap image in images)
        {
          il.Images.Add(image);
          Bitmap bm = (Bitmap)il.Images[il.Images.Count - 1];
          for (int x = 0; x < bm.Width; x++)
          {
            for (int y = 0; y < bm.Height; y++)
            {
              bm.SetPixel(x, y, image.GetPixel(x, y));
            }
          }
        }
      }
      return il;
    }
  }
}

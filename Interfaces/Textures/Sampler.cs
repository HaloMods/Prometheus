using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using System.IO;

namespace Interfaces.Textures
{
  public class Sampler
  {
    private int width;
    private int height;
    private float bytesPerPixel;
    private Format format = Format.Unknown;
    private Texture texture = null;
    private MemoryStream decodeStream = null;

    public Sampler(Texture texture, Format format, int width, int height)
    {
      byte[] buffer;
      GraphicsStream stream;

      switch (format)
      {
        case Format.R5G6B5:
          bytesPerPixel = 2.0f;
          break;
        case Format.A8R8G8B8:
          bytesPerPixel = 4.0f;
          break;
        case Format.Dxt1:
          stream = texture.LockRectangle(0, LockFlags.ReadOnly);
          buffer = new byte[width * height / 2];
          stream.Position = 0;
          stream.Read(buffer, 0, width * height / 2);
          texture.UnlockRectangle(0);
          decodeStream = new MemoryStream(DXT.DecodeDXT1(height, width, buffer));
          bytesPerPixel = 4.0f;
          format = Format.A8R8G8B8;
          break;
        case Format.Dxt2:
        case Format.Dxt3:
          stream = texture.LockRectangle(0, LockFlags.ReadOnly);
          buffer = new byte[width * height];
          stream.Position = 0;
          stream.Read(buffer, 0, width * height);
          texture.UnlockRectangle(0);
          decodeStream = new MemoryStream(DXT.DecodeDXT23(height, width, buffer));
          bytesPerPixel = 4.0f;
          format = Format.A8R8G8B8;
          break;
        case Format.Dxt4:
        case Format.Dxt5:
          stream = texture.LockRectangle(0, LockFlags.ReadOnly);
          buffer = new byte[width * height];
          stream.Position = 0;
          stream.Read(buffer, 0, width * height);
          texture.UnlockRectangle(0);
          decodeStream = new MemoryStream(DXT.DecodeDXT45(height, width, buffer));
          bytesPerPixel = 4.0f;
          format = Format.A8R8G8B8;
          break;
      }

      this.texture = texture;
      this.width = width;
      this.height = height;
      this.format = format;
    }

    public Color Sample(Vector2 coordinates)
    { return Sample(coordinates.X, coordinates.Y); }

    private void Wrap(ref float value)
    {
      while (value > 1.0f)
        value -= 1.0f;
      while (value < 0.0f)
        value += 1.0f;
    }

    public Color Sample(float u, float v)
    {
      Wrap(ref u);
      Wrap(ref v);

      Color color = Color.Black;
      if (bytesPerPixel > 0.0f)
      {
        Stream pixelStream;
        if (decodeStream == null)
          pixelStream = texture.LockRectangle(0, LockFlags.ReadOnly);
        else
          pixelStream = decodeStream;
        pixelStream.Position = (int)((float)(width - 1) * u) * (int)bytesPerPixel + (int)((float)(height - 1) * v) * width * (int)bytesPerPixel;
        byte[] buffer = new byte[(int)bytesPerPixel];
        pixelStream.Read(buffer, 0, (int)bytesPerPixel);
        if (decodeStream == null)
          texture.UnlockRectangle(0);

        uint colorValue = 0;
        switch ((int)bytesPerPixel)
        {
          case 1:
            colorValue = buffer[0];
            break;
          case 2:
            colorValue = BitConverter.ToUInt16(buffer, 0);
            break;
          case 4:
            colorValue = BitConverter.ToUInt32(buffer, 0);
            break;
        }

        uint r = 0, g = 0, b = 0, a = 255;
        switch (format)
        {
          case Format.R5G6B5:
            b = (colorValue & 0x1f) * 8;
            g = ((colorValue >> 5) & 0x3f) * 4;
            r = ((colorValue >> 11) & 0x1f) * 8;
            break;
          case Format.A8R8G8B8:
            b = colorValue & 0xff;
            g = (colorValue >> 8) & 0xff;
            r = (colorValue >> 16) & 0xff;
            a = (colorValue >> 24) & 0xff;
            break;
        }
        color = Color.FromArgb((int)a, (int)r, (int)g, (int)b);
      }
      return color;
    }
    public void Write(Color color, float u, float v)
    {
      Wrap(ref u);
      Wrap(ref v);

      //Color color = Color.Black;
      if (bytesPerPixel > 0.0f)
      {
        Stream pixelStream;
        if (decodeStream == null)
          pixelStream = texture.LockRectangle(0, LockFlags.None);
        else
          pixelStream = decodeStream;
        pixelStream.Position = (int)((float)(width - 1) * u) * (int)bytesPerPixel + (int)((float)(height - 1) * v) * width * (int)bytesPerPixel;
        byte[] buffer = new byte[(int)bytesPerPixel];
        //pixelStream.Read(buffer, 0, (int)bytesPerPixel);

        int argb = color.ToArgb();
        switch ((int)bytesPerPixel)
        {
          case 1:
            // do nothing
            break;
          case 2:
            int b = (argb & 0xFF) >> 3;
            int g = ((argb >> 8) & 0xff) >> 2;
            int r = ((argb >> 16) & 0xff) >> 3;

            byte msb = (byte)((r << 3) | (g >> 3));
            byte lsb = (byte)((g & 0x7) | b);
            buffer[0] = msb;
            buffer[1] = lsb;
            break;
          case 4:
            buffer = BitConverter.GetBytes(argb);
            break;
        }
        pixelStream.Write(buffer, 0, buffer.Length);
        if (decodeStream == null)
          texture.UnlockRectangle(0);
      }
    }
  }
}

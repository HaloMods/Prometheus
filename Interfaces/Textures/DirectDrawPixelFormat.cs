using System;
using System.IO;
using Microsoft.DirectX.Direct3D;

namespace Interfaces.Textures
{
  /// <summary>
  /// Represents the DDPIXELFORMAT Microsoft DirectDraw structure.
  /// </summary>
  public struct DirectDrawPixelFormat
  {
    private int size;
    private int flags;
    private string fourcc;
    private int rgbBitCount;
    private int redBitMask;
    private int greenBitMask;
    private int blueBitMask;
    private int alphaBitMask;

    public int BitCount
    {
      get
      { return rgbBitCount; }
    }

    public void Write(BinaryWriter bw)
    {
      bw.Write(size);
      bw.Write(flags);
      bw.Write(Convert.ToByte(fourcc[0]));
      bw.Write(Convert.ToByte(fourcc[1]));
      bw.Write(Convert.ToByte(fourcc[2]));
      bw.Write(Convert.ToByte(fourcc[3]));
      bw.Write(rgbBitCount);
      bw.Write(redBitMask);
      bw.Write(greenBitMask);
      bw.Write(blueBitMask);
      bw.Write(alphaBitMask);
    }

    public void Generate(Format pixelFormat)
    {
      size = 32;
      flags = 0;

      if (pixelFormat == Format.Dxt1)
      {
        fourcc = "DXT1";
        flags |= (int)DirectDrawPixelFormatFlags.FourCC;
      }
      else if (pixelFormat == Format.Dxt3)
      {
        fourcc = "DXT3";
        flags |= (int)DirectDrawPixelFormatFlags.FourCC;
      }
      else if (pixelFormat == Format.Dxt4)
      {
        fourcc = "DXT4";
        flags |= (int)DirectDrawPixelFormatFlags.FourCC;
      }
      else
      {
        fourcc = "\0\0\0\0";
        flags |= (int)DirectDrawPixelFormatFlags.RGB;
      }

      switch (pixelFormat)
      {
        case Format.Dxt1:
          flags |= (int)DirectDrawPixelFormatFlags.AlphaPixels;
          flags |= (int)DirectDrawPixelFormatFlags.AlphaPremultiplied;
          rgbBitCount = 4;
          break;
        case Format.Dxt3:
        case Format.Dxt4:
          rgbBitCount = 8;
          break;
        case Format.R5G6B5:
          rgbBitCount = 16;
          redBitMask = 0xF800;
          greenBitMask = 0x7E0;
          blueBitMask = 0x1F;
          alphaBitMask = 0x0;
          break;
        case Format.A8:
          rgbBitCount = 8;
          flags &= ~(int)DirectDrawPixelFormatFlags.RGB;
          flags |= (int)DirectDrawPixelFormatFlags.AlphaOnly;
          redBitMask = 0x0;
          greenBitMask = 0x0;
          blueBitMask = 0x0;
          alphaBitMask = 0xFF;
          break;
        case Format.L8: // Y8
          rgbBitCount = 8;
          flags &= ~(int)DirectDrawPixelFormatFlags.RGB;
          flags |= (int)DirectDrawPixelFormatFlags.LuminosityOnly;
          redBitMask = 0xFF;
          greenBitMask = 0x0;
          blueBitMask = 0x0;
          alphaBitMask = 0x0;
          break;
        case Format.P8:
          rgbBitCount = 8;
          flags |= (int)DirectDrawPixelFormatFlags.AlphaPixels;
          redBitMask = 0x0;
          greenBitMask = 0x0;
          blueBitMask = 0x0;
          alphaBitMask = 0xFF;
          break;
        case Format.A4L4: // AY8
          rgbBitCount = 8;
          flags |= (int)DirectDrawPixelFormatFlags.AlphaPixels;
          redBitMask = 0xF;
          greenBitMask = 0x0;
          blueBitMask = 0x0;
          alphaBitMask = 0xF0;
          break;
        case Format.A8L8: // A8L8
          rgbBitCount = 16;
          flags |= (int)DirectDrawPixelFormatFlags.AlphaPixels;
          redBitMask = 0xFF;
          greenBitMask = 0x0;
          blueBitMask = 0x0;
          alphaBitMask = 0xFF00;
          break;
        case Format.A1R5G5B5:
          rgbBitCount = 16;
          flags |= (int)DirectDrawPixelFormatFlags.AlphaPixels;
          redBitMask = 0x7C00;
          greenBitMask = 0x3E0;
          blueBitMask = 0x1F;
          alphaBitMask = 0x8000;
          break;
        case Format.A4R4G4B4:
          rgbBitCount = 16;
          flags |= (int)DirectDrawPixelFormatFlags.AlphaPixels;
          redBitMask = 0xF00;
          greenBitMask = 0xF0;
          blueBitMask = 0xF;
          alphaBitMask = 0xF000;
          break;
        case Format.X8R8G8B8:
          rgbBitCount = 32;
          redBitMask = 0xFF0000;
          greenBitMask = 0xFF00;
          blueBitMask = 0xFF;
          alphaBitMask = 0x00000000;
          break;
        case Format.A8R8G8B8:
          rgbBitCount = 32;
          flags |= (int)DirectDrawPixelFormatFlags.AlphaPixels;
          redBitMask = 0xFF0000;
          greenBitMask = 0xFF00;
          blueBitMask = 0xFF;
          alphaBitMask = unchecked((int)0xFF000000);
          break;
        default:
          throw new ArgumentException("Invalid pixel format of type " + pixelFormat.ToString() + " was encountered while generating a dds header.", "pixelFormat");
      }
    }
  }
}

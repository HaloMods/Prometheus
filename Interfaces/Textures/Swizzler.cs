using System;

namespace Interfaces.Textures
{
	/// <summary>
	/// Swizzles an array of pixels.
	/// </summary>
  public static class Swizzler
  {
    public static byte[] Swizzle(byte[] raw, int offset, int width, int height, int depth, int bitCount, bool deswizzle)
    {
      int a = 0, b = 0;
      if (width <= 0)
        width = 1;
      if (height <= 0)
        height = 1;
      if (depth <= 0)
        depth = 1;
      byte[] data = new byte[raw.Length];
      MaskSet masks = new MaskSet(width, height, depth);
      bitCount /= 8;

      for (int z = 0; z < depth; z++)
      {
        for (int y = 0; y < height; y++)
        {
          for (int x = 0; x < width; x++)
          {
            if (deswizzle)
            {
              a = ((z * width * height) + (y * width) + x) * bitCount;
              b = Swizzle(x, y, z, masks) * bitCount;
            }
            else
            {
              b = ((z * width * height) + (y * width) + x) * bitCount;
              a = Swizzle(x, y, z, masks) * bitCount;
            }
            for (int i = offset; i < bitCount + offset; i++)
              data[a + i] = raw[b + i];
          }
        }
      }

      for (int u = 0; u < offset; u++)
        data[u] = raw[u];
      for (int v = offset + (height * width * depth * bitCount); v < data.Length; v++)
        data[v] = raw[v];

      return data;
    }

    public static byte[] Swizzle(byte[] raw, int width, int height, int depth, int bitCount, bool deswizzle)
    { return Swizzle(raw, 0, width, height, depth, bitCount, deswizzle); }

    private static int Swizzle(int x, int y, int z, MaskSet masks)
    { return SwizzleAxis(x, masks.x) | SwizzleAxis(y, masks.y) | (z < 0 ? 0 : SwizzleAxis(z, masks.z)); }

    private static int SwizzleAxis(int val, int mask)
    {
      int bit = 1;
      int result = 0;

      while (bit <= mask)
      {
        if ((mask & bit) > 0)
          result |= val & bit;
        else
          val <<= 1;
        bit <<= 1;
      }

      return result;
    }

    private class MaskSet
    {
      public int x = 0;
      public int y = 0;
      public int z = 0;

      public MaskSet(int w, int h, int d)
      {
        int bit = 1;
        int index = 1;

        while (bit < w || bit < h || bit < d)
        {
          if (bit < w)
          {
            x |= index;
            index <<= 1;
          }
          if (bit < h)
          {
            y |= index;
            index <<= 1;
          }
          if (bit < d)
          {
            z |= index;
            index <<= 1;
          }
          bit <<= 1;
        }
      }
    }
  }
}

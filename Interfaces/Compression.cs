using System;

namespace Interfaces
{
  public static class Compression
  {
    public static uint Round(uint value, uint pageSize)
    {
      if (value == 0)
        return 0;
      //return (uint)Math.Ceiling((double)value / (double)pageSize) * pageSize;

      uint mod = value % pageSize;
      if (mod == 0)
        return value;
      else
        return (uint)(pageSize - mod) + value;
    }

    public static int Round(int value, int pageSize)
    {
      if (value == 0)
        return 0;
      //return (int)Math.Ceiling((double)value / (double)pageSize) * pageSize;

      int mod = value % pageSize;
      if (mod == 0)
        return value;
      else
        return (pageSize - mod) + value;
    }

    public static uint Pad(uint value, uint pageSize)
    {
      if (value == 0)
        return 0;
      //return (uint)(((uint)Math.Ceiling((double)value / (double)pageSize) * pageSize) - value);

      uint mod = value % pageSize;
      if (mod == 0)
        return 0;
      else
        return (uint)(pageSize - mod);
    }

    public static int Pad(int value, int pageSize)
    {
      if (value == 0)
        return 0;
      //return ((int)Math.Ceiling((double)value / (double)pageSize) * pageSize) - value;

      int mod = value % pageSize;
      if (mod == 0)
        return 0;
      else
        return pageSize - mod;
    }

    public static uint Compress111110(Array data)
    {
      int x = (int)Math.Floor(Clamp((float)data.GetValue(0)) * 1023.5f) & 0x7ff;
      int y = (int)Math.Floor(Clamp((float)data.GetValue(1)) * 1023.5f) & 0x7ff;
      int z = (int)Math.Floor(Clamp((float)data.GetValue(2)) * 511.5f) & 0x3ff;
      return BitConverter.ToUInt32(BitConverter.GetBytes(x | (y << 11) | (z << 22)), 0);
    }

    public static Array Decompress111110(uint data)
    {
      Array vector = Array.CreateInstance(typeof(float), 3);

      /*uint x = data & 0x7ff;
      uint y = (data >> 11) & 0x7ff;
      uint z = (data >> 22) & 0x3ff;
      vector.SetValue((float)x / (float)0x7ff, 0);
      vector.SetValue((float)y / (float)0x7ff, 1);
      vector.SetValue((float)z / (float)0x3ff, 2);*/

      int cx, cy, cz;
      //int signed = *(int*)&data;
        // unsafe code not allowed; sigh
      int signed = BitConverter.ToInt32(BitConverter.GetBytes(data), 0);

      cx = (int)(signed << 21);
      cy = (int)((signed >> 11) << 21);
      cz = (int)((signed >> 22) << 22);

      vector.SetValue((float)((((float)cx / 1048576.0) + 1.0) / 2047.0), 0);
      vector.SetValue((float)((((float)cy / 1048576.0) + 1.0) / 2047.0), 1);
      vector.SetValue((float)((((float)cz / 1048576.0) + 1.0) / 2047.0), 2);

      return vector;
    }

    public static uint Compress1616(Array data)
    {
      return (uint)(((uint)(Math.Floor(UClamp((float)data.GetValue(0)) * 65535.0f)) << 16) | (uint)(Math.Floor(UClamp((float)data.GetValue(1)) * 65535.0f)));
    }

    public static uint Compress16Half16(Array data)
    {
      return (uint)(((uint)(Math.Floor(UClamp((float)data.GetValue(1)) * 32767.0f)) << 16) | (uint)(Math.Floor(UClamp((float)data.GetValue(0)) * 32767.0f)));
    }

    public static ushort CompressFraction16(float value)
    {
      return (ushort)(Math.Floor(UClamp(value) * 65535.0f));
    }

    public static ushort CompressHalf16(float value)
    {
      return (ushort)(Math.Floor(UClamp(value) * 32767.0f));
    }

    public static float DecompressHalf16(ushort value)
    {
      return (float)value / 32767.0f;
    }

    public static Array Decompress16Half16(ushort x, ushort y)
    {
      Array vector = Array.CreateInstance(typeof(float), 2);
      vector.SetValue(DecompressHalf16(x), 0);
      vector.SetValue(DecompressHalf16(y), 1);
      return vector;
    }

    public static float Clamp(float value)
    {
      if (value > 1.0f)
        value = 1.0f;
      if (value < -1.0f)
        value = -1.0f;
      return value;
    }

    public static float UClamp(float value)
    {
      if (value > 1.0f)
        value = 1.0f;
      if (value < 0.0f)
        value = 0.0f;
      return value;
    }
  }
}

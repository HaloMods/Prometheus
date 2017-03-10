using System;

namespace Interfaces.Textures
{
  public static class DXT
  {
    private struct RGBA_COLOR_STRUCT
    {
      public int r;
      public int g;
      public int b;
      public int a;
    }

    private static RGBA_COLOR_STRUCT short_to_rgba(int color)
    {
      RGBA_COLOR_STRUCT rc;
      rc.r = (((color >> 11) & 31) * 255) / 31;
      rc.g = (((color >> 5) & 63) * 255) / 63;
      rc.b = (((color >> 0) & 31) * 255) / 31;
      rc.a = 255;
      return rc;
    }

    private static int rgba_to_int(RGBA_COLOR_STRUCT c)
    {
      return (c.a << 24) | (c.r << 16) | (c.g << 8) | c.b;
    }

    private static RGBA_COLOR_STRUCT GradientColors(RGBA_COLOR_STRUCT Col1, RGBA_COLOR_STRUCT Col2)
    {
      RGBA_COLOR_STRUCT ret;
      ret.r = ((Col1.r * 2 + Col2.r)) / 3;
      ret.g = ((Col1.g * 2 + Col2.g)) / 3;
      ret.b = ((Col1.b * 2 + Col2.b)) / 3;
      ret.a = 255;
      return ret;
    }

    private static RGBA_COLOR_STRUCT GradientColorsHalf(RGBA_COLOR_STRUCT Col1, RGBA_COLOR_STRUCT Col2)
    {
      RGBA_COLOR_STRUCT ret;
      ret.r = (Col1.r / 2 + Col2.r / 2);
      ret.g = (Col1.g / 2 + Col2.g / 2);
      ret.b = (Col1.b / 2 + Col2.b / 2);
      ret.a = 255;
      return ret;
    }

    public static byte[] DecodeDXT1(int height, int width, byte[] SourceData)
    {
      byte[] DestData = new byte[(width * height) * 4];
      RGBA_COLOR_STRUCT[] Color = new RGBA_COLOR_STRUCT[4];
      int i;
      int dptr = 0;
      RGBA_COLOR_STRUCT CColor;
      int CData;
      int ChunksPerHLine = width / 4;
      bool trans;
      RGBA_COLOR_STRUCT zeroColor = new RGBA_COLOR_STRUCT();
      int c1;
      int c2;

      if (ChunksPerHLine == 0)
      {
        ChunksPerHLine += 1;
      }
      for (i = 0; i <= (width * height) - 1; i += 16)
      {
        c1 = ((int)SourceData[dptr + 1] << 8) | SourceData[dptr];
        c2 = ((int)SourceData[dptr + 3] << 8) | SourceData[dptr + 2];
        if (c1 > c2)
        {
          trans = false;
        }
        else
        {
          trans = true;
        }
        Color[0] = short_to_rgba(c1);
        Color[1] = short_to_rgba(c2);
        if (!(trans))
        {
          Color[2] = GradientColors(Color[0], Color[1]);
          Color[3] = GradientColors(Color[1], Color[0]);
        }
        else
        {
          Color[2] = GradientColorsHalf(Color[0], Color[1]);
          Color[3] = zeroColor;
        }
        CData = (Convert.ToInt32(SourceData[dptr + 4]) << 0) | (Convert.ToInt32(SourceData[dptr + 5]) << 8) | (Convert.ToInt32(SourceData[dptr + 6]) << 16) | (Convert.ToInt32(SourceData[dptr + 7]) << 24);
        int ChunkNum = i / 16;
        long XPos = ChunkNum % ChunksPerHLine;
        long YPos = (ChunkNum - XPos) / ChunksPerHLine;
        long ttmp;
        int sizeh = height < 4 ? height : 4;
        int sizew = width < 4 ? width : 4;

        for (int x = 0; x <= sizeh - 1; x++)
        {
          for (int y = 0; y <= sizew - 1; y++)
          {
            CColor = Color[CData & 3];
            CData >>= 2;
            ttmp = ((YPos * 4 + x) * width + XPos * 4 + y) * 4;
            DestData[ttmp] = (byte)CColor.b;
            DestData[ttmp + 1] = (byte)CColor.g;
            DestData[ttmp + 2] = (byte)CColor.r;
            DestData[ttmp + 3] = (byte)CColor.a;
          }
        }
        dptr += 8;
      }
      return DestData;
    }

    public static byte[] DecodeDXT23(int height, int width, byte[] SourceData)
    {
      byte[] DestData = new byte[(width * height) * 4];
      RGBA_COLOR_STRUCT[] Color = new RGBA_COLOR_STRUCT[4];
      int i;
      RGBA_COLOR_STRUCT CColor;
      int CData;
      int ChunksPerHLine = width / 4;

      if (ChunksPerHLine == 0)
      {
        ChunksPerHLine += 1;
      }
      for (i = 0; i <= (width * height) - 1; i += 16)
      {
        Color[0] = short_to_rgba(Convert.ToInt32(SourceData[i + 8]) | Convert.ToInt32(SourceData[i + 9]) << 8);
        Color[1] = short_to_rgba(Convert.ToInt32(SourceData[i + 10]) | Convert.ToInt32(SourceData[i + 11]) << 8);
        Color[2] = GradientColors(Color[0], Color[1]);
        Color[3] = GradientColors(Color[1], Color[0]);
        CData = (Convert.ToInt32(SourceData[i + 12]) << 0) | (Convert.ToInt32(SourceData[i + 13]) << 8) | (Convert.ToInt32(SourceData[i + 14]) << 16) | (Convert.ToInt32(SourceData[i + 15]) << 24);
        int ChunkNum = i / 16;
        long XPos = ChunkNum % ChunksPerHLine;
        long YPos = (ChunkNum - XPos) / ChunksPerHLine;
        long ttmp;
        int alpha;
        int sizeh = height < 4 ? height : 4;
        int sizew = width < 4 ? width : 4;

        for (int x = 0; x <= sizeh - 1; x++)
        {
          alpha = SourceData[i + (2 * x)] | (int)SourceData[i + (2 * x) + 1] << 8;
          for (int y = 0; y <= sizew - 1; y++)
          {
            CColor = Color[CData & 3];
            CData >>= 2;
            CColor.a = (alpha & 15) * 16;
            alpha >>= 4;
            ttmp = ((YPos * 4 + x) * width + XPos * 4 + y) * 4;
            DestData[ttmp] = (byte)CColor.b;
            DestData[ttmp + 1] = (byte)CColor.g;
            DestData[ttmp + 2] = (byte)CColor.r;
            DestData[ttmp + 3] = (byte)CColor.a;
          }
        }
      }
      return DestData;
    }

    public static byte[] DecodeDXT45(int height, int width, byte[] SourceData)
    {
      byte[] DestData = new byte[(width * height) * 4];
      RGBA_COLOR_STRUCT[] Color = new RGBA_COLOR_STRUCT[4];
      int i;
      RGBA_COLOR_STRUCT CColor;
      int CData;
      int ChunksPerHLine = width / 4;

      // TODO: NotImplemented statement: ICSharpCode.SharpRefactory.Parser.AST.VB.ReDimStatement
      if (ChunksPerHLine == 0)
      {
        ChunksPerHLine += 1;
      }
      for (i = 0; i <= (width * height) - 1; i += 16)
      {
        Color[0] = short_to_rgba(Convert.ToInt32(SourceData[i + 8]) | Convert.ToInt32(SourceData[i + 9]) << 8);
        Color[1] = short_to_rgba(Convert.ToInt32(SourceData[i + 10]) | Convert.ToInt32(SourceData[i + 11]) << 8);
        Color[2] = GradientColors(Color[0], Color[1]);
        Color[3] = GradientColors(Color[1], Color[0]);
        CData = (Convert.ToInt32(SourceData[i + 12]) << 0) | (Convert.ToInt32(SourceData[i + 13]) << 8) | (Convert.ToInt32(SourceData[i + 14]) << 16) | (Convert.ToInt32(SourceData[i + 15]) << 24);
        byte[] Alpha = new byte[8];
        Alpha[0] = SourceData[i];
        Alpha[1] = SourceData[i + 1];
        if ((Alpha[0] > Alpha[1]))
        {
          Alpha[2] = (byte)((6 * Alpha[0] + 1 * Alpha[1] + 3) / 7);
          Alpha[3] = (byte)((5 * Alpha[0] + 2 * Alpha[1] + 3) / 7);
          Alpha[4] = (byte)((4 * Alpha[0] + 3 * Alpha[1] + 3) / 7);
          Alpha[5] = (byte)((3 * Alpha[0] + 4 * Alpha[1] + 3) / 7);
          Alpha[6] = (byte)((2 * Alpha[0] + 5 * Alpha[1] + 3) / 7);
          Alpha[7] = (byte)((1 * Alpha[0] + 6 * Alpha[1] + 3) / 7);
        }
        else
        {
          Alpha[2] = (byte)((4 * Alpha[0] + 1 * Alpha[1] + 2) / 5);
          Alpha[3] = (byte)((3 * Alpha[0] + 2 * Alpha[1] + 2) / 5);
          Alpha[4] = (byte)((2 * Alpha[0] + 3 * Alpha[1] + 2) / 5);
          Alpha[5] = (byte)((1 * Alpha[0] + 4 * Alpha[1] + 2) / 5);
          Alpha[6] = 0;
          Alpha[7] = 255;
        }
        long tmpdword;
        uint tmpword;
        long alphaDat;
        tmpword = SourceData[i + 2] | (Convert.ToUInt32(SourceData[i + 3]) << 8);
        tmpdword = SourceData[i + 4] | (Convert.ToInt32(SourceData[i + 5]) << 8) | (SourceData[i + 6] << 16) | (Convert.ToInt32(SourceData[i + 7]) << 24);
        alphaDat = tmpword | (tmpdword << 16);
        int ChunkNum = i / 16;
        long XPos = ChunkNum % ChunksPerHLine;
        long YPos = (ChunkNum - XPos) / ChunksPerHLine;
        long ttmp;
        int sizeh = height < 4 ? height : 4;
        int sizew = width < 4 ? width : 4;

        for (int x = 0; x <= sizeh - 1; x++)
        {
          for (int y = 0; y <= sizew - 1; y++)
          {
            CColor = Color[CData & 3];
            CData >>= 2;
            CColor.a = Alpha[alphaDat & 7];
            alphaDat >>= 3;
            ttmp = ((YPos * 4 + x) * width + XPos * 4 + y) * 4;
            DestData[ttmp] = (byte)CColor.b;
            DestData[ttmp + 1] = (byte)CColor.g;
            DestData[ttmp + 2] = (byte)CColor.r;
            DestData[ttmp + 3] = (byte)CColor.a;
          }
        }
      }
      return DestData;
    }
  }
}

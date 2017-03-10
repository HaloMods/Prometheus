using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Interfaces.IO;

namespace Games.Halo.Compiler.XPE
{
  public class Cxpe
  {
    Xpe[] xpes;

    public Cxpe(Stream stream)
    {
      EndianReader er = new EndianReader(stream, ByteOrder.LittleEndian);
      xpes = new Xpe[er.ReadInt32()];

      for (int x = 0; x < xpes.Length; x++)
      {
        er.Position = 4 + (4 * x);
        er.Position = er.ReadInt32();
        xpes[x] = new Xpe(er);
      }
    }

    public string GetFourCCFromExtension(string extension)
    {
      for (int x = 0; x < xpes.Length; x++)
        if (xpes[x].Extension == extension)
          return xpes[x].FourCC;
      return null;
    }

    public Xpe this[string type]
    {
      get
      {
        for (int x = 0; x < xpes.Length; x++)
          if (xpes[x].FourCC == type)
            return xpes[x];
        return null;
      }
    }
  }
}

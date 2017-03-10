using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Halo2.Compiler.Data
{
  public static class AlignmentConstants
  {
    public const int PageAlignment = 0x200;
    public const int FileAlignment = 0x800;
    public const int MetaAlignment = 0x10;
    public const int BlockAlignment = 0x4;
    public const int StringAlignment = 0x80;
  }
}

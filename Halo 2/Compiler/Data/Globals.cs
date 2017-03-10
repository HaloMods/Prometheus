using System;
using System.IO;

namespace Games.Halo2.Compiler.Data
{
  /// <summary>
  /// This class contains information key to modifying unicode strings.
  /// </summary>
  public class Globals
  {
    public const int LanguageCount = 9;

    private int[] counts;
    private int[] tableSizes;
    private int[] indexOffsets;
    private int[] tableOffsets;

    public Globals(BinaryReader reader)
    {
      reader.BaseStream.Position += 392;

      counts = new int[LanguageCount];
      tableSizes = new int[LanguageCount];
      indexOffsets = new int[LanguageCount];
      tableOffsets = new int[LanguageCount];

      for (int i = 0; i < LanguageCount; i++)
      {
        reader.BaseStream.Position += 8;
        counts[i] = reader.ReadInt32();
        tableSizes[i] = reader.ReadInt32();
        indexOffsets[i] = reader.ReadInt32();
        tableOffsets[i] = reader.ReadInt32();
        reader.BaseStream.Position += 4;
      }
    }

    public void WriteToMapStream(BinaryWriter writer)
    {
      writer.BaseStream.Position += 392;

      for (int i = 0; i < LanguageCount; i++)
      {
        writer.BaseStream.Position += 8;
        writer.Write(counts[i]);
        writer.Write(tableSizes[i]);
        writer.Write(indexOffsets[i]);
        writer.Write(tableOffsets[i]);
        writer.BaseStream.Position += 4;
      }
    }

    public int[] Counts
    {
      get
      { return counts; }
    }

    public int[] TableSizes
    {
      get
      { return tableSizes; }
    }

    public int[] IndexOffsets
    {
      get
      { return indexOffsets; }
    }

    public int[] TableOffsets
    {
      get
      { return tableOffsets; }
    }
  }
}

using System;
using Interfaces.IO;

namespace Games.Halo.Platforms.Shared
{
  /// <summary>
  /// Represents a page in a Halo map index.
  /// </summary>
  public class IndexItem
  {
    public string type;
    public string parent;
    public string grandparent;
    public uint identifier;
    public uint stringOffset;
    public uint metaOffset;
    public int flags;
    public int reserved;
    public const int StructSize = 0x20;

    public void Read(EndianReader er, uint magic)
    {
      type = er.ReadFourCC();
      parent = er.ReadFourCC();
      grandparent = er.ReadFourCC();
      identifier = er.ReadUInt32();
      stringOffset = (uint)(er.ReadUInt32() - magic);
      metaOffset = er.ReadUInt32();
      flags = er.ReadInt32();
      reserved = er.ReadInt32();
      if ((flags & 1) > 0)
        if (type == "bitm")
          return;
      metaOffset -= magic;
    }

    public void Write(EndianWriter ew, uint magic)
    {
      ew.WriteFourCC(type);
      ew.WriteFourCC(parent);
      ew.WriteFourCC(grandparent);
      ew.Write(identifier);
      ew.Write((uint)(stringOffset + magic));
      ew.Write((uint)(metaOffset + magic));
      ew.Write(flags);
      ew.Write(reserved);
    }
  }
}
